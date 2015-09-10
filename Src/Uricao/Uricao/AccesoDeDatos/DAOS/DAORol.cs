using System;
using System.Collections.Generic;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using System.Data;
using System.Data.SqlClient;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using System.Linq;
using System.Web;
using System.Configuration;


namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAORol : DAOSQLServer, iDAORol 
    {
        IConexionDAOS conex = new ConexionDAOS();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader = null;
        private Entidad _miUsuario = FabricaEntidad.NuevaUsuario();


        # region Agregar Rol

        public bool AgregarRol(Entidad nuevoRol)
        {

            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex2 = new ConexionDAOS();
            SqlCommand command2 = new SqlCommand();

            bool resultado = false;
            string estado;

            if ((nuevoRol as Rol).Estado == true)
            {
                estado = "Activo";
            }
            else
            {
                estado = "Inactivo";
            }

            try
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnUricao"].ToString());
                conexion.Open();


                conex2.AbrirConexion();
                command2.Connection = conexion;
                command2.CommandType = System.Data.CommandType.StoredProcedure;
                command2.CommandText = "[dbo].[AgregarRol]";
                command2.CommandTimeout = 50;


                command2.Parameters.AddWithValue("@nombreRol",(nuevoRol as Rol).NombreRol);
                command2.Parameters.AddWithValue("@descripcionRol",(nuevoRol as Rol).Descripcion);
                command2.Parameters.AddWithValue("@estadoRol", estado);

                command2.ExecuteNonQuery();

               /* if ((nuevoRol as Rol).Estado == true)
                {

                  
                  estado = "Activo";

                }
                else
                {

                    command2.Parameters.AddWithValue("@estado", "Inactivo");
                }*/

               //command2.Parameters.AddWithValue("@estadoRolMo", (nuevoRol as Rol).Estado);

                //reader = command2.ExecuteReader();
             

                //reader.Close();

                resultado = true;          
            }
            catch (SqlException e)
            {
               //En caso de que se viole la restriccion UNIQUE sobre el Rol
               if (e.Message.Contains("UNIQUE KEY"))
                   throw (new ExceptionHistoriaClinica("Error: El Id del Rol ya se encuentra registrado", e));
                else
                    throw (new ExceptionHistoriaClinica("Error: " + e.Message, e));

            //throw new Exception("Error en la conexion", e);
            }
            catch (Exception errorGeneral)
            {
                // para capturar cualquier excepcion y posterior estudio para solventar el problema
                String errror2 = errorGeneral.Message;
                throw (new ExceptionHistoriaClinica("Error: " + errror2, errorGeneral));
            }
            /*catch (NullReferenceException e)
            {
                throw new Exception("Error Referencia Nula", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error" + e.Message, e);
            }*/
            finally
            {
                conex.CerrarConexion();
            }

            return resultado;
        }

        # endregion Agregar Rol

        #region Consultar Rol Parametrizado
        public List<Entidad> ConsultarRolParametrizado(int id, String nombre, String descrip, Boolean estado, int opcion)
        {
            List<Entidad> listaRoles = new List<Entidad>();
            DAORol ConsultaBD = new DAORol();
            //listaRoles = ConsultaBD.ConsultarRolTodo();
            //return listaRoles;

            try
            {
                switch (opcion)
                {
                    case 0:
                        listaRoles = ConsultaBD.ConsultarRolTodo(id, nombre, descrip, estado);
                        break;

                    case 1:
                        listaRoles = ConsultaBD.ConsultarRolId(id);
                        break;

                    case 2:
                        listaRoles = ConsultaBD.ConsultarRolNombre(nombre);
                        break;

                    case 3:
                        listaRoles = ConsultaBD.ConsultarRolDescrip(descrip);
                        break;

                    case 4:
                        listaRoles = ConsultaBD.ConsultarRolEstado(estado);
                        break;
                }

                return listaRoles;
            }

            catch (NullReferenceException e)
            {
                throw new Exception("Error en las Referenciasn estan Nulas", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error General", e);
            }
        }
        #endregion Consultar Rol Parametrizado
        
        # region Buscar Rol por todo

        public List<Entidad> ConsultarRolTodo(int idRol, String nombreRol, String descripcionRol, Boolean estadoRol)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD

            List<Entidad> miLista = new List<Entidad>();
            Entidad _miRol;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            try
            {
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsltarRoltodo]";
                command.CommandTimeout = 10;


                reader = command.ExecuteReader();
                
                

                while (reader.Read())
                {
                    _miRol = FabricaEntidad.NuevoRol();
                    string estados = null;

                    //(miRol as Rol).IdRol = Convert.ToInt32(reader.GetValue(0));

                    (_miRol as Rol).IdRol = int.Parse(reader.GetValue(0).ToString());
                    (_miRol as Rol).NombreRol = reader.GetValue(1).ToString();
                    (_miRol as Rol).Descripcion = reader.GetValue(2).ToString();

                    estados = reader.GetValue(3).ToString();
                    estados = estados.ToUpper();
                    if (estados.Contains("ACTIVO"))
                    {
                        (_miRol as Rol).Estado = true;
                    }
                    else
                    {
                        (_miRol as Rol).Estado = false;
                    }

                    miLista.Add(_miRol);
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error en la conexion", e);
            }

            catch (NullReferenceException e)
            {
                throw new Exception("Error Referencia Nula", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error" + e.Message, e);
            }
            
            finally
            {
                conex.CerrarConexion();
            }
            if (miLista.Count == 0)
               {
                  return null;
               }else
                    {
                       return miLista;
                     }
        }

        # endregion Buscar Rol por todo

        # region Buscar Rol por id

        public List<Entidad> ConsultarRolId(int id)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            List<Entidad> miLista = new List<Entidad>();
            Entidad _miRol;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            try
            {
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsltarRolid]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@idRolBusca", id);
                command.Parameters["@idRolBusca"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _miRol = FabricaEntidad.NuevoRol();
                    string estados = null;

                    (_miRol as Rol).IdRol = int.Parse(reader.GetValue(0).ToString());
                    (_miRol as Rol).NombreRol = reader.GetValue(1).ToString();
                    (_miRol as Rol).Descripcion = reader.GetValue(2).ToString();

                    estados = reader.GetValue(3).ToString();
                    estados = estados.ToUpper();
                    if (estados.Contains("ACTIVO"))
                    {
                        (_miRol as Rol).Estado= true;
                    }
                    else
                    {
                        (_miRol as Rol).Estado = false;
                    }

                    miLista.Add(_miRol);
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error en la conexion", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Error Referencia Nula", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error" + e.Message, e);
            }
            finally
            {
                conex.CerrarConexion();
            }
            if (miLista.Count == 0)
            {
                return null;
            }
            else
            {
                return miLista;
            }
        }

        # endregion Buscar Rol por id

        # region Buscar Rol por nombre

        public List<Entidad> ConsultarRolNombre(string nombre)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD

            List<Entidad> miLista = new List<Entidad>();
            Entidad _miRol;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            

            try
            {
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsltarRolnombre]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@nombreRolBusca", "%"+nombre+"%");
                command.Parameters["@nombreRolBusca"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _miRol = FabricaEntidad.NuevoRol();
                    string estados = null;

                    (_miRol as Rol).IdRol = int.Parse(reader.GetValue(0).ToString());
                    (_miRol as Rol).NombreRol = reader.GetValue(1).ToString();
                    (_miRol as Rol).Descripcion = reader.GetValue(2).ToString();

                    estados = reader.GetValue(3).ToString();
                    estados = estados.ToUpper();
                    if (estados.Contains("ACTIVO"))
                    {
                        (_miRol as Rol).Estado = true;
                    }
                    else
                    {
                        (_miRol as Rol).Estado = false;
                    }

                    miLista.Add(_miRol);
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error en la conexion", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Error Referencia Nula", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error" + e.Message, e);
            }
            finally
            {
                conex.CerrarConexion();
            }
            if (miLista.Count == 0)
            {
                return null;
            }
            else
            {
                return miLista;
            }
        }

        # endregion Buscar Rol por nombre

        # region Buscar Rol por descripcion

        public List<Entidad> ConsultarRolDescrip(string descrip)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            List<Entidad> miLista = new List<Entidad>();
            Entidad _miRol;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;


            try
            {
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsltarRoldescrip]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@descripRolBusca", "%"+descrip+"%");
                command.Parameters["@descripRolBusca"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _miRol = FabricaEntidad.NuevoRol();
                    string estados = null;

                    (_miRol as Rol).IdRol = int.Parse(reader.GetValue(0).ToString());
                    (_miRol as Rol).NombreRol = reader.GetValue(1).ToString();
                    (_miRol as Rol).Descripcion = reader.GetValue(2).ToString();

                    estados = reader.GetValue(3).ToString();
                    estados = estados.ToUpper();
                    if (estados.Contains("ACTIVO"))
                    {
                        (_miRol as Rol).Estado = true;
                    }
                    else
                    {
                        (_miRol as Rol).Estado = false;
                    }

                    miLista.Add(_miRol);
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error en la conexion", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Error Referencia Nula", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error" + e.Message, e);
            }
            finally
            {
                conex.CerrarConexion();
            }
            if (miLista.Count == 0)
            {
                return null;
            }
            else
            {
                return miLista;
            }
        }

        # endregion Buscar Rol por descripcion

        # region Buscar Rol por estado

        public List<Entidad> ConsultarRolEstado(Boolean estadoRol)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD

            List<Entidad> miLista = new List<Entidad>();
            Entidad _miRol;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;


            string estadoReal = null;
            try
            {
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsltarRolestado]";
                command.CommandTimeout = 10;

                if (estadoRol == true)
                {
                    estadoReal = "ACTIVO";
                }
                else
                {
                    estadoReal = "INACTIVO";
                }
                command.Parameters.AddWithValue("@estadoRolBusca", "%"+estadoReal+"%");
                command.Parameters["@estadoRolBusca"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _miRol = FabricaEntidad.NuevoRol();
                    string estados = null;

                    (_miRol as Rol).IdRol = int.Parse(reader.GetValue(0).ToString());
                    (_miRol as Rol).NombreRol = reader.GetValue(1).ToString();
                    (_miRol as Rol).Descripcion = reader.GetValue(2).ToString();

                    estados = reader.GetValue(3).ToString();
                    estados = estados.ToUpper();
                    if (estados.Contains("ACTIVO"))
                    {
                        (_miRol as Rol).Estado = true;
                    }
                    else
                    {
                        (_miRol as Rol).Estado = false;
                    }

                    miLista.Add(_miRol);
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error en la conexion", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Error Referencia Nula", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error" + e.Message, e);
            }
            finally
            {
                conex.CerrarConexion();
            }
            if (miLista.Count == 0)
            {
                return null;
            }
            else
            {
                return miLista;
            }
        }

        # endregion Buscar Rol por estado

        #region EnlistarRoles
        public List<string> ListaRoles()
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                List<string> ListaRoles = new List<string>();

                // List<Banco> listaBanco = new List<Banco>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[ConsultarRol]";
                    command.CommandTimeout = 10;
                    reader = command.ExecuteReader();

                    
                    while (reader.Read())
                    {


                        ListaRoles.Add(reader.GetString(0));

                    }

                    return ListaRoles;
                }
                catch (SqlException)
                {
                    throw new Exception();
                }

                finally
                {
                    if (reader != null)
                        reader.Close();
                    conex.CerrarConexion();
                }
            }
        }
        #endregion EnlistarRoles parametro Proveedor

        # region Modificar Roles

        public bool ModificarRoles(Entidad _rol)
        {

            string estado = null;
            bool modificar = false;
            SqlCommand command = new SqlCommand();
            //SqlDataReader reader;

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ModificarRol]";
                command.CommandTimeout = 10;


                command.Parameters.AddWithValue("@idRolModf", (_rol as Rol).IdRol);
                //command.Parameters["@idRolModf"].Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("@nombreRolModf", (_rol as Rol).NombreRol);
                //command.Parameters["@nombreRolModf"].Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("@descripRolModf", (_rol as Rol).Descripcion);
                //command.Parameters["@descripRolModf"].Direction = ParameterDirection.Input; 

                if ((_rol as Rol).Estado == true)
                {
                    estado = "Activo";

                }
                else
                {
                    estado = "Inactivo";
                }

                /*command.Parameters.AddWithValue("@respuesta", (_rol as Rol).Respuesta);
                command.Parameters.AddWithValue("@estadoRol", (_rol as Rol).Estado); */

                command.Parameters.AddWithValue("@estadoRolModf", estado);
                //command.Parameters["@estadoRolModf"].Direction = ParameterDirection.Input;
                //reader = command.ExecuteReader();
                command.ExecuteNonQuery();
                //reader.Read();  //estos comandos no estaban
                //reader.Close();


                modificar = true;
            }
            catch (SqlException e)
            {
                throw new Exception("Error en la conexion", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Error Referencia Nula", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error" + e.Message, e);
            }
            finally
            {
                conex.CerrarConexion();
            }
            return modificar;
        }

        # endregion

        #region Modificar Rol

        public Rol ModificarRol(Entidad _rol)
        {
            Rol rolModificar = new Rol();
            bool modificar = false;
            try
            {
                /* rolModificar.IdRol = id;
                 rolModificar.NombreRol = nombre;
                 rolModificar.Descripcion = descrip;
                 rolModificar.Estado = estado;*/

                modificar = new DAORol().ModificarRoles(rolModificar);

                if (modificar == true)
                {
                    return rolModificar;
                }
                else
                {
                    return null;
                }
            }

            catch (NullReferenceException e)
            {
                throw new Exception("Error en las Referenciasn estan Nulas", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error General", e);
            }
        }
        #endregion Modificar Rol

        # region Asignar Roles a Usuarios
        
        public Boolean AsirgnarRol(Usuario miUsuario, Rol miRol)
        {
            
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            Boolean resultado = false;
            try
            {
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[AsignarRol]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@idRolAsig", miRol.IdRol);
                command.Parameters["@idRolAsig"].Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("@idUsuarioAsig", miUsuario.IdUsuario);
                command.Parameters["@idUsuarioAsig"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();

                resultado = true;
            }
            catch (SqlException e)
            {
                throw new Exception("Error en la conexion", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Error Referencia Nula", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error" + e.Message, e);
            }
            finally
            {
                conex.CerrarConexion();
            }

            return resultado;
        }

        # endregion
    }
}
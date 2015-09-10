using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.Entidades.EEmpleados;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOEmpleado : DAOSQLServer, iDAOEmpleado
    {
        IConexionDAOS conexion = FabricaConexion.AccesoConexion();
        SqlDataReader reader = null;
        SqlCommand command = new SqlCommand();
        private Entidad _miEmpleado = FabricaEntidad.NuevoEmpleado();
		Entidad detalle = FabricaEntidad.NuevaDireccion("Detalle");

        #region Agregar Empleado

        public bool AgregarEmpleado(Entidad empleado, Entidad direccion)
        {
            try
            {
                SqlCommand command0 = new SqlCommand();
                conexion.AbrirConexion();
                command0.Connection = conexion.ObjetoConexion();
                command0.CommandType = System.Data.CommandType.StoredProcedure;
                command0.CommandText = "[dbo].[AgregarDireccionEmpleado]";
                command0.CommandTimeout = 10;
                command0.Parameters.AddWithValue("@detalle", (direccion as Direccion).Nombre);
                command0.Parameters.AddWithValue("@ciudad", (direccion as Direccion).Ciudad);
                command0.ExecuteReader();
                conexion.CerrarConexion();


                conexion.AbrirConexion();
                command.Connection = conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[AgregarEmpleado]";
                command.CommandTimeout = 10;


                command.Parameters.AddWithValue("@login", (empleado as Empleado).PrimerNombre);
                command.Parameters.AddWithValue("@password", (empleado as Empleado).Identificacion);
                command.Parameters.AddWithValue("@tipoCi", (empleado as Empleado).TipoIdentificacion);
                command.Parameters.AddWithValue("@cedula", (empleado as Empleado).Identificacion);
                command.Parameters.AddWithValue("@primerNombre", (empleado as Empleado).PrimerNombre);
                command.Parameters.AddWithValue("@primerApellido", (empleado as Empleado).PrimerApellido);
                command.Parameters.AddWithValue("@fechaNace", (empleado as Empleado).FechaNace);
                command.Parameters.AddWithValue("@sexo", (empleado as Empleado).Sexo);
                command.Parameters.AddWithValue("@correo", (empleado as Empleado).Correo);

                command.Parameters.AddWithValue("@estado", "Activo");
                command.Parameters.AddWithValue("@sueldo", (empleado as Empleado).Sueldo);


                command.ExecuteReader();
                conexion.CerrarConexion();

                conexion.AbrirConexion();
                SqlCommand command2 = new SqlCommand();
                command2.Connection = conexion.ObjetoConexion();
                command2.CommandType = System.Data.CommandType.StoredProcedure;
                command2.CommandText = "[dbo].[AsignarRolEmpleado]";
                command2.CommandTimeout = 10;
                command2.Parameters.AddWithValue("@especialidad", (empleado as Empleado).Especialidad);
                command2.ExecuteReader();


                conexion.AbrirConexion();
                SqlCommand command3 = new SqlCommand();
                command3.Connection = conexion.ObjetoConexion();
                command3.CommandType = System.Data.CommandType.StoredProcedure;
                command3.CommandText = "[dbo].[AgregarTelefonoEmpleado]";
                command3.CommandTimeout = 10;
                command3.Parameters.AddWithValue("@telefono", (empleado as Empleado).Telefono[0]);
                command3.Parameters.AddWithValue("@tipo", "CECULAR");
                command3.ExecuteReader();

                conexion.CerrarConexion();
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionEmpleado("Parametros invalidos", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ExcepcionEmpleado("Operacion Invalida", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionEmpleado("Empleado no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionEmpleado("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error General", e);
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return true;
        }

        #endregion Agregar Empleado

        #region Modificar Empleado

        public bool ModificarEmpleado(Entidad empleado, Entidad direccion)
        {
            try
            {

                System.Diagnostics.Debug.WriteLine("DAOEmpleado: antes de direccion");

                SqlCommand command0 = new SqlCommand();
                conexion.AbrirConexion();
                command0.Connection = conexion.ObjetoConexion();
                command0.CommandType = System.Data.CommandType.StoredProcedure;
                command0.CommandText = "[dbo].[ModificarDireccionEmpleado]";
                command0.CommandTimeout = 10;
                command0.Parameters.AddWithValue("@detalle", (direccion as Direccion).Nombre);
                command0.Parameters.AddWithValue("@ciudad", (direccion as Direccion).Ciudad);
                command0.Parameters.AddWithValue("@idUsuario", (empleado as Empleado).IdUsuario);
                command0.ExecuteReader();
                conexion.CerrarConexion();

                System.Diagnostics.Debug.WriteLine("DAOEmpleado: antes de modificar usuario");
                conexion.AbrirConexion();
                command.Connection = conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ModificarEmpleado]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@idUsuario", (empleado as Empleado).IdUsuario);
                command.Parameters.AddWithValue("@login", (empleado as Empleado).PrimerNombre);
                command.Parameters.AddWithValue("@password", (empleado as Empleado).Identificacion);
                command.Parameters.AddWithValue("@tipoCi", (empleado as Empleado).TipoIdentificacion);
                command.Parameters.AddWithValue("@cedula", (empleado as Empleado).Identificacion);
                command.Parameters.AddWithValue("@primerNombre", (empleado as Empleado).PrimerNombre);
              //command.Parameters.AddWithValue("@segundoNombre", empleado.SegundoNombre);
                command.Parameters.AddWithValue("@primerApellido", (empleado as Empleado).PrimerApellido);
              //command.Parameters.AddWithValue("@segundoApellido", empleado.SegundoApellido);
                command.Parameters.AddWithValue("@fechaNace", (empleado as Empleado).FechaNace);
              //command.Parameters.AddWithValue("@fechaIngreso", empleado.FechaRegistro);
                command.Parameters.AddWithValue("@sexo", (empleado as Empleado).Sexo);
                command.Parameters.AddWithValue("@correo", (empleado as Empleado).Correo);
              //command.Parameters.AddWithValue("@ocupacion", null);
              //command.Parameters.AddWithValue("@foto", empleado.Foto);
                command.Parameters.AddWithValue("@sueldo", (empleado as Empleado).Sueldo);
                command.ExecuteReader();
                conexion.CerrarConexion();



                System.Diagnostics.Debug.WriteLine("DAOEmpleado: antes de modificar rol");

                conexion.AbrirConexion();
                SqlCommand command2 = new SqlCommand();
                command2.Connection = conexion.ObjetoConexion();
                command2.CommandType = System.Data.CommandType.StoredProcedure;
                command2.CommandText = "[dbo].[ModificarRolEmpleado]";
                command2.CommandTimeout = 10;
                command2.Parameters.AddWithValue("@especialidad", (empleado as Empleado).Especialidad);
                command2.Parameters.AddWithValue("@idUsuario", (empleado as Empleado).IdUsuario);
                command2.ExecuteReader();


                conexion.AbrirConexion();
                SqlCommand command3 = new SqlCommand();
                command3.Connection = conexion.ObjetoConexion();
                command3.CommandType = System.Data.CommandType.StoredProcedure;
                command3.CommandText = "[dbo].[ModificarTelefonoEmpleado]";
                command3.CommandTimeout = 10;
                command3.Parameters.AddWithValue("@telefono", (empleado as Empleado).Telefono[0]);
                command3.Parameters.AddWithValue("@tipo", "CECULAR");
                command3.Parameters.AddWithValue("@idUsuario", (empleado as Empleado).IdUsuario);
                command3.ExecuteReader();
                conexion.CerrarConexion();
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionEmpleado("Parametros invalidos", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ExcepcionEmpleado("Operacion Invalida", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionEmpleado("Empleado no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionEmpleado("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error General", e);
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return true;
        }

        #endregion Agregar Empleado

        #region Consultar todos los Empleados

        public List<Entidad> ConsultarTodosEmpleados(string nombreProcedimiento)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            List<Entidad> _empleados = new List<Entidad>();
            Entidad _empleado;
            

            try
            {
                conexion.AbrirConexion();
                //cmd = new SqlCommand("dbo.ListaEmpleadoActivos", conexion.ObjetoConexion());
                cmd = new SqlCommand("dbo."+nombreProcedimiento, conexion.ObjetoConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    _empleado = FabricaEntidad.NuevoEmpleado();

                    (_empleado as Empleado).IdUsuario = int.Parse(dr.GetValue(0).ToString());
                    (_empleado as Empleado).Login = dr.GetValue(1).ToString();
                    (_empleado as Empleado).Password = dr.GetValue(2).ToString();
                    (_empleado as Empleado).PrimerNombre = dr.GetValue(5).ToString();
                    (_empleado as Empleado).SegundoNombre = dr.GetValue(6).ToString();
                    (_empleado as Empleado).PrimerApellido = dr.GetValue(7).ToString();
                    (_empleado as Empleado).SegundoApellido = dr.GetValue(8).ToString();
                    (_empleado as Empleado).FechaNace = (System.DateTime)dr.GetValue(10);
                    (_empleado as Empleado).Sexo = dr.GetValue(11).ToString();
                    (_empleado as Empleado).Correo = dr.GetValue(12).ToString();
                    (_empleado as Empleado).TipoIdentificacion = dr.GetValue(3).ToString();
                    (_empleado as Empleado).Identificacion = dr.GetValue(4).ToString();
                    

                    //Lleno la direccion completa
                    (_empleado as Empleado).Direccion = (detalle as Direccion);
                    //Detalle
                    (_empleado as Empleado).Direccion.Id = int.Parse(dr.GetValue(19).ToString());
                    (_empleado as Empleado).Direccion.Nombre = dr.GetValue(20).ToString();
                    System.Diagnostics.Debug.WriteLine(int.Parse(dr.GetValue(19).ToString()) + dr.GetValue(20).ToString());

                    //Ciudad
                    (_empleado as Empleado).Direccion.Fk_dir.Id = int.Parse(dr.GetValue(21).ToString());
                    (_empleado as Empleado).Direccion.Fk_dir.Ciudad = dr.GetValue(22).ToString();
                    System.Diagnostics.Debug.WriteLine(int.Parse(dr.GetValue(21).ToString()) + dr.GetValue(22).ToString());

                    //Estado
                    (_empleado as Empleado).Direccion.Fk_dir.Fk_dir.Id = int.Parse(dr.GetValue(23).ToString());
                    (_empleado as Empleado).Direccion.Fk_dir.Fk_dir.Estado = dr.GetValue(24).ToString();

                    System.Diagnostics.Debug.WriteLine(int.Parse(dr.GetValue(23).ToString()) + dr.GetValue(24).ToString());

                    //Pais
                    (_empleado as Empleado).Direccion.Fk_dir.Fk_dir.Fk_dir.Id = int.Parse(dr.GetValue(25).ToString());
                    (_empleado as Empleado).Direccion.Fk_dir.Fk_dir.Fk_dir.Pais = dr.GetValue(26).ToString();

                    System.Diagnostics.Debug.WriteLine(int.Parse(dr.GetValue(25).ToString()) + dr.GetValue(26).ToString());

                    //private DateTime fechaNace;
                    //private DateTime fechaRegistro;
                    //objetoEmpleado.Telefono = dr.GetValue().ToString();
                    (_empleado as Empleado).Estado = dr.GetValue(16).ToString();
                    (_empleado as Empleado).Sueldo = (float)dr.GetValue(17);
                    (_empleado as Empleado).Especialidad = dr.GetValue(18).ToString();

                    _empleados.Add(_empleado);
                }

                conexion.CerrarConexion();
            }
            catch (ArgumentException e) 
            {
                throw new ExcepcionEmpleado("Parametros invalidos", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ExcepcionEmpleado("Operacion Invalida", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionEmpleado("Empleado no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionEmpleado("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error General", e);
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return _empleados;
        }

        #endregion Consultar todos los Empleados

        #region Activar/Inactivar Empleados
        public bool CambiarEstadoEmpleado(Entidad _empleado)
        {
            SqlCommand cmd = new SqlCommand();
            
            try
            {
            conexion.AbrirConexion();

            cmd.Connection = conexion.ObjetoConexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[ActivarInactivarEmpleado]";
            cmd.CommandTimeout = 10;

            cmd.Parameters.AddWithValue("@id", (_empleado as Empleado).IdUsuario);
            cmd.Parameters.AddWithValue("@estado", (_empleado as Empleado).Estado);
            cmd.ExecuteReader();
            
            conexion.CerrarConexion();
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionEmpleado("Parametros invalidos", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ExcepcionEmpleado("Operacion Invalida", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionEmpleado("Empleado no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionEmpleado("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error General", e);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return true;
        }
        /*public bool ActivarInactivarEmpleados(List<string> cedula)
        {
            Empleado objetoEmpleado = new Empleado();
            List<Empleado> miListaEmpleado = new List<Empleado>();
            List<Empleado> miListaEmpleadoEstado = new List<Empleado>();

            miListaEmpleado = objetoEmpleado.Consultar();

            foreach (string ci in cedula)
            {
                foreach (Empleado emp in miListaEmpleado)
                {
                    if (ci == emp.Identificacion)
                        miListaEmpleadoEstado.Add(emp);
                }
            }
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.ActivarInactivarEmpleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                db.AbrirConexion();
                foreach (Empleado emp in miListaEmpleadoEstado)
                {
                    if (emp.Estado.ToUpper().Contains("ACTIVO"))
                    {
                        cmd.Parameters.AddWithValue("@cedula", emp.Identificacion);
                        cmd.Parameters.AddWithValue("@estado", "INACTIVO");
                    }
                    else if (emp.Estado.ToUpper().Contains("INACTIVO"))
                    {
                        cmd.Parameters.AddWithValue("@cedula", emp.Identificacion);
                        cmd.Parameters.AddWithValue("@estado", "ACTIVO");
                    }
                }
                db.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception("Error en la conexion", e);
            }
            finally
            {
                db.CerrarConexion();
            }
            return true;
        }*/
        #endregion Activar/Inactivar Empleados

        #region Consultar Direcciones

        public List<Entidad> ConsultarPais()
        {
            List<Entidad> _paises = new List<Entidad>();
            Entidad _pais;

            try
            {
                conexion.AbrirConexion();
                command = new SqlCommand("dbo.ConsultarPais", conexion.ObjetoConexion());
                command.CommandType = CommandType.StoredProcedure;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _pais = FabricaEntidad.NuevaDireccion();

                    (_pais as Direccion).Id = int.Parse(reader.GetValue(0).ToString());
                    (_pais as Direccion).Pais = reader.GetValue(1).ToString();

                    _paises.Add(_pais);
                }

                conexion.CerrarConexion();
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionEmpleado("Parametros invalidos", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ExcepcionEmpleado("Operacion Invalida", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionEmpleado("Empleado no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionEmpleado("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error General", e);
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return _paises;
        }

        public List<Entidad> ConsultarEstado(Entidad _pais)
        {
            List<Entidad> _estados = new List<Entidad>();
            Entidad _estado;

            try
            {
                conexion.AbrirConexion();
   
                command.Connection = conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarEstadoPais]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@parametro", (_pais as Direccion).Pais);

                reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    _estado = FabricaEntidad.NuevaDireccion();

                    (_estado as Direccion).Id = int.Parse(reader.GetValue(0).ToString());
                    (_estado as Direccion).Estado = reader.GetValue(1).ToString();
                    _estados.Add(_estado);
                }

                conexion.CerrarConexion();
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionEmpleado("Parametros invalidos", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ExcepcionEmpleado("Operacion Invalida", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionEmpleado("Empleado no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionEmpleado("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error General", e);
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return _estados;
        }

        public List<Entidad> ConsultarCiudad(Entidad _estado)
        {
            List<Entidad> _ciudades = new List<Entidad>();
            Entidad _ciudad;

            try
            {
                conexion.AbrirConexion();

                command.Connection = conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarCiudadEstado]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@parametro", (_estado as Direccion).Estado);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _ciudad = FabricaEntidad.NuevaDireccion();

                    (_ciudad as Direccion).Id = int.Parse(reader.GetValue(0).ToString());
                    (_ciudad as Direccion).Ciudad = reader.GetValue(1).ToString();
                    _ciudades.Add(_ciudad);
                }

                conexion.CerrarConexion();
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionEmpleado("Parametros invalidos", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ExcepcionEmpleado("Operacion Invalida", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionEmpleado("Empleado no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionEmpleado("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error General", e);
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return _ciudades;
        }
        #endregion


    }
}
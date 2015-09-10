using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;



namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOUsuario : DAOSQLServer, iDAOUsuario
    {
        IConexionDAOS conex = new ConexionDAOS();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader = null;
        private Entidad _miUsuario = FabricaEntidad.NuevaUsuario();


        #region Confirmacion para el loggin del usuario parametro nombreUser y contraseña
        public Usuario ConfirmacionLoggin(string Loggin, string password)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                Usuario usuarioConfirmado = new Usuario();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[BuscarLogin]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@nombreUsuario", Loggin);
                    command.Parameters.AddWithValue("@contraseña", password);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@nombreUsuario"].Direction = ParameterDirection.Input;
                    command.Parameters["@contraseña"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto
                    while (reader.Read())
                    {

                        usuarioConfirmado.Login = reader.GetString(0);
                        usuarioConfirmado.Password = reader.GetString(1);
                        usuarioConfirmado.Estatus = reader.GetString(2).ToLower().Equals("activado");


                    }

                    return usuarioConfirmado;
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
        #endregion Confirmacion para el loggin del usuario parametro nombreUser y contraseña

        #region Lista de los privilegios de un usuario
        public List<Privilegio> ListadoPrivilegiosUsuario(string Loggin, string password)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                List<Privilegio> listaPrivilegio = new List<Privilegio>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[BuscarPrivilegios]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@nombreUsuario", Loggin);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@nombreUsuario"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto 
                    Privilegio privilegio = new Privilegio();
                    while (reader.Read())
                    {

                        privilegio.IdPrivilegio = Convert.ToInt32(reader.GetString(0));
                        listaPrivilegio.Add(privilegio);

                    }

                    return listaPrivilegio;
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
        #endregion Lista de los privilegios de un usuario

        public Usuario TraerUsuario(string Loggin)
        {
            Usuario Us = new Usuario();
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;


            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[ConsultarUsuario]";
                command.CommandTimeout = 50;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@loggin", Loggin);
                //Se indica que es un parametro de entrada
                command.Parameters["@loggin"].Direction = ParameterDirection.Input;
                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto
                while (reader.Read())
                {
                    Us.Login = reader.GetString(0);
                    Us.PrimerNombre = reader.GetString(1);
                    Us.SegundoNombre = reader.GetValue(2).ToString();
                    Us.PrimerApellido = reader.GetString(3);
                    Us.SegundoApellido = reader.GetValue(4).ToString();
                    Us.TipoIdentificacion = reader.GetString(5);
                    Us.Identificacion = reader.GetValue(6).ToString();
                    Us.FechaNace = reader.GetDateTime(7);
                    Us.Rol.NombreRol = reader.GetString(8);
                    Us.Sexo = reader.GetString(9);
                    Us.Foto = reader.GetString(10);
                    Us.Estatus = reader.GetString(11).Equals("ACTIVO");
                    Us.Correo = reader.GetString(12);


                }
                Us = TraerUsuarioDireccion(Us, Loggin);
                Us = TraerUsuarioTelefono(Us, Loggin);
                return Us;
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

        private Usuario TraerUsuarioTelefono(Usuario Us, string Loggin)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;


            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarUsuarioTelefono]";
                command.CommandTimeout = 50;
                command.Parameters.AddWithValue("@loggin", Loggin);
                //Se indica que es un parametro de entrada
                command.Parameters["@loggin"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto
                while (reader.Read())
                {
                    Us.Telefono.Add(reader.GetString(0));
                }

                return Us;
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
        private Usuario TraerUsuarioDireccion(Usuario Us, string Loggin)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarUsuarioDireccion]";
                command.CommandTimeout = 50;
                command.Parameters.AddWithValue("@loggin", Loggin);
                //Se indica que es un parametro de entrada
                command.Parameters["@loggin"].Direction = ParameterDirection.Input;
                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto
                while (reader.Read())
                {

                    Us.Direccion.Edificio = reader.GetString(0);
                    Us.Direccion.Calle = reader.GetString(1);
                    Us.Direccion.Municipio = reader.GetString(2);
                    Us.Direccion.Ciudad = reader.GetString(3);
                    Us.Direccion.Estado = reader.GetString(4);
                    Us.Direccion.Pais = reader.GetString(5);

                }

                return Us;
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

        #region Consultar Usuarios Todos
        public List<Entidad> ConsultarUsuarioTodo()
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            //ConexionDAOS conex = new ConexionDAOS();
            //SqlCommand command = new SqlCommand();
            //SqlDataReader reader = null;


            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[ConsultarUsuarioTodo]";
                command.CommandTimeout = 50;
                //Aqui van los parametros del store procesure
                //command.Parameters.AddWithValue("@loggin", Loggin);
                //Se indica que es un parametro de entrada
                //command.Parameters["@loggin"].Direction = ParameterDirection.Input;
                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto
                List<Entidad> ListaUs = new List<Entidad>();
                while (reader.Read())
                {
                    Entidad _usuario = FabricaEntidad.NuevaUsuario();
                    //Entidad Us = new FabricaEntidad.NuevaUsuario();
                    //Us = FabricaEntidad.NuevaUsuario();
                    (_usuario as Usuario).Login = reader.GetString(0);
                    (_usuario as Usuario).PrimerNombre = reader.GetString(1);
                    (_usuario as Usuario).SegundoNombre = reader.GetValue(2).ToString();
                    (_usuario as Usuario).PrimerApellido = reader.GetString(3);
                    (_usuario as Usuario).SegundoApellido = reader.GetValue(4).ToString();
                    (_usuario as Usuario).TipoIdentificacion = reader.GetString(5);
                    (_usuario as Usuario).Identificacion = reader.GetValue(6).ToString();
                    (_usuario as Usuario).FechaNace = reader.GetDateTime(7);
                    (_usuario as Usuario).Rol.NombreRol = reader.GetString(8);
                    (_usuario as Usuario).Sexo = reader.GetString(9);
                    (_usuario as Usuario).Foto = reader.GetValue(10).ToString();
                    (_usuario as Usuario).Estatus = reader.GetString(11).ToUpper().Contains("ACTIVO");
                    (_usuario as Usuario).Correo = reader.GetValue(12).ToString();
                    //Nuevo Id necesario para cargar comboBox
                    (_usuario as Usuario).IdUsuario = Convert.ToInt32(reader.GetValue(13));
                    (_usuario as Usuario).Direccion = TraerUsuarioDireccion((_usuario as Usuario), (_usuario as Usuario).Login).Direccion;
                    (_usuario as Usuario).Telefono = TraerUsuarioTelefono((_usuario as Usuario), (_usuario as Usuario).Login).Telefono;
                    ListaUs.Add(_usuario);
                }

                return ListaUs;
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
        #endregion Consultar Usuarios Todos

        #region Consultar Usuarios Parametrizado
        public List<Entidad> ConsultarUsuarioParametrizado(string parametro, int seleccion)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                switch (seleccion)
                {
                    case 1:
                        command.CommandText = "[dbo].[ConsultarUsuarioNombre]";
                        break;
                    case 2:
                        command.CommandText = "[dbo].[ConsultarUsuarioApellido]";
                        break;
                    case 3:
                        command.CommandText = "[dbo].[ConsultarUsuarioIdentificacion]";
                        break;
                    case 4:
                        command.CommandText = "[dbo].[ConsultarUsuarioRol]";
                        break;
                    case 5:
                        command.CommandText = "[dbo].[ConsultarUsuarioUsuario]";
                        break;
                }


                command.CommandTimeout = 50;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@parametro", parametro + "%_%");
                //Se indica que es un parametro de entrada
                command.Parameters["@parametro"].Direction = ParameterDirection.Input;
                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto
                List<Entidad> ListaUs = new List<Entidad>();
                while (reader.Read())
                {
                    /*Usuario Us = new Usuario();
                    Us.Login = reader.GetString(0);
                    Us.PrimerNombre = reader.GetString(1);
                    Us.SegundoNombre = reader.GetValue(2).ToString();
                    Us.PrimerApellido = reader.GetString(3);
                    Us.SegundoApellido = reader.GetValue(4).ToString();
                    Us.TipoIdentificacion = reader.GetString(5);
                    Us.Identificacion = reader.GetValue(6).ToString();
                    Us.FechaNace = reader.GetDateTime(7);
                    Us.Rol.NombreRol = reader.GetString(8);
                    Us.Sexo = reader.GetString(9);
                    Us.Foto = reader.GetValue(10).ToString();
                    Us.Estatus = reader.GetString(11).ToUpper().Contains("ACTIVO");
                    Us.Correo = reader.GetValue(12).ToString();
                    Us = TraerUsuarioDireccion(Us, Us.Login);
                    Us = TraerUsuarioTelefono(Us, Us.Login);
                    ListaUs.Add(Us);*/

                    Entidad _usuario = FabricaEntidad.NuevaUsuario();
                    //Entidad Us = new FabricaEntidad.NuevaUsuario();
                    //Us = FabricaEntidad.NuevaUsuario();
                    (_usuario as Usuario).Login = reader.GetString(0);
                    (_usuario as Usuario).PrimerNombre = reader.GetString(1);
                    (_usuario as Usuario).SegundoNombre = reader.GetValue(2).ToString();
                    (_usuario as Usuario).PrimerApellido = reader.GetString(3);
                    (_usuario as Usuario).SegundoApellido = reader.GetValue(4).ToString();
                    (_usuario as Usuario).TipoIdentificacion = reader.GetString(5);
                    (_usuario as Usuario).Identificacion = reader.GetValue(6).ToString();
                    (_usuario as Usuario).FechaNace = reader.GetDateTime(7);
                    (_usuario as Usuario).Rol.NombreRol = reader.GetString(8);
                    (_usuario as Usuario).Sexo = reader.GetString(9);
                    (_usuario as Usuario).Foto = reader.GetValue(10).ToString();
                    (_usuario as Usuario).Estatus = reader.GetString(11).ToUpper().Contains("ACTIVO");
                    (_usuario as Usuario).Correo = reader.GetValue(12).ToString();
                    (_usuario as Usuario).Direccion = TraerUsuarioDireccion((_usuario as Usuario), (_usuario as Usuario).Login).Direccion;
                    (_usuario as Usuario).Telefono = TraerUsuarioTelefono((_usuario as Usuario), (_usuario as Usuario).Login).Telefono;
                    ListaUs.Add(_usuario);
                }

                return ListaUs;
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
        #endregion Consultar Usuarios Parametrizado

        #region Validar datos loggin
        public Usuario ValidarDatosLoggin(string logg, string pass)
        {
            Usuario Us = new Usuario();
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[BuscarLogin]";
                command.CommandTimeout = 50;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@nombreUsuario", logg);
                command.Parameters.AddWithValue("@contraseña", pass);
                //Se indica que es un parametro de entrada
                command.Parameters["@nombreUsuario"].Direction = ParameterDirection.Input;
                command.Parameters["@contraseña"].Direction = ParameterDirection.Input;
                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto
                while (reader.Read())
                {
                    Us.Login = reader.GetString(0);
                    Us.Password = reader.GetString(1);
                    Us.Estatus = reader.GetValue(2).ToString().ToUpper().Equals("ACTIVO");



                }
                return Us;
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
        #endregion Validar datos loggin

        #region Modificar Usuario
        /*public void ModificarUsuario(Usuario usu)
        {
            Rol miRol = new Rol();
            string estado = null;
            Boolean modificar = false;
            try
            {
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ModificarUsuario]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@idRolModf", rolModificar.IdRol);
                command.Parameters["@idRolModf"].Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("@nombreRolModf", rolModificar.NombreRol);
                command.Parameters["@nombreRolModf"].Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("@descripRolModf", rolModificar.Descripcion);
                command.Parameters["@descripRolModf"].Direction = ParameterDirection.Input;

                if (rolModificar.Estado == true)
                {
                    estado = "Activo";

                }
                else
                {
                    estado = "Inactivo";
                }
                command.Parameters.AddWithValue("@estadoRolModf", estado);
                command.Parameters["@estadoRolModf"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();

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
        }*/

        public bool ModificarUsuario(Entidad usuario)
        {
            try
            {
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ModificarUsuario]";
                command.CommandTimeout = 50;

                command.Parameters.AddWithValue("@login", (usuario as Usuario).Login);
                command.Parameters.AddWithValue("@password", (usuario as Usuario).Password);
                command.Parameters.AddWithValue("@tipoCi", (usuario as Usuario).TipoIdentificacion);
                command.Parameters.AddWithValue("@cedula", (usuario as Usuario).Identificacion);
                command.Parameters.AddWithValue("@primerNombre", (usuario as Usuario).PrimerNombre);
                command.Parameters.AddWithValue("@segundoNombre", "NULL");
                command.Parameters.AddWithValue("@primerApellido", (usuario as Usuario).PrimerApellido);
                command.Parameters.AddWithValue("@segundoApellido", "NULL");
                command.Parameters.AddWithValue("@fechaNace", (usuario as Usuario).FechaNace);
                command.Parameters.AddWithValue("@fechaIngreso", (usuario as Usuario).FechaRegistro);
                command.Parameters.AddWithValue("@sexo", (usuario as Usuario).Sexo);
                command.Parameters.AddWithValue("@correo", (usuario as Usuario).Correo);
                command.Parameters.AddWithValue("@foto", "NULL");
                command.Parameters.AddWithValue("@estado", "Activo");

                command.Parameters.AddWithValue("@codigotlf", "0212");
                command.Parameters.AddWithValue("@numtelefono", (usuario as Usuario).Telefono.ElementAt(0));
                command.Parameters.AddWithValue("@tipotelefono", "Local");

                command.Parameters.AddWithValue("@ciudad", (usuario as Usuario).Direccion.Ciudad);
                command.Parameters.AddWithValue("@municipio", (usuario as Usuario).Direccion.Municipio);
                command.Parameters.AddWithValue("@calle", (usuario as Usuario).Direccion.Calle);
                command.Parameters.AddWithValue("@edificio", (usuario as Usuario).Direccion.Edificio);

                command.ExecuteNonQuery();
          
                conex.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception("Error en la conexion", e);
            }
            finally
            {
                conex.CerrarConexion();
            }

            return true;
        }
        #endregion Modificar Usuario

        #region Consultar Usuarios Por Identificador
        /*
        public Entidad ConsultarUsuarioPorIdentificador(int identificador)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            try
            {
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[ConsultarUsuarioPorIdentificador]";
                command.CommandTimeout = 50;
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Entidad _miUsuario = FabricaEntidad.NuevaUsuario();
                    (_miUsuario as Usuario).IdUsuario = Int32.Parse(reader.GetValue(0).ToString());;
                    (_miUsuario as Usuario).Identificacion = reader.GetValue(1).ToString();
                    (_miUsuario as Usuario).TipoIdentificacion = reader.GetString(2);
                    (_miUsuario as Usuario).PrimerNombre = reader.GetString(3);
                    (_miUsuario as Usuario).PrimerApellido = reader.GetString(4);
                    (_miUsuario as Usuario).SegundoApellido = reader.GetValue(5).ToString();
                    return _miUsuario;
                }
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
            return null;
        }
         
        }*/

        #endregion

        #region Agregar Usuario
        public bool AgregarUsuario(Entidad usuario)
        {

            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex2 = new ConexionDAOS();
            SqlCommand command2 = new SqlCommand();

            try
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnUricao"].ToString());
                conexion.Open();
                /*cmd = new SqlCommand("dbo.AgregarEmpleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                db.AbrirConexion();*/


                conex2.AbrirConexion();
                command2.Connection = conexion;
                command2.CommandType = System.Data.CommandType.StoredProcedure;
                command2.CommandText = "[dbo].[AgregarUsuario]";
                command2.CommandTimeout = 50;
                //Aqui van los parametros del store procesure
                //command.Parameters.AddWithValue("@loggin", Loggin);
                //Se indica que es un parametro de entrada
                //command.Parameters["@loggin"].Direction = ParameterDirection.Input;

                command2.Parameters.AddWithValue("@login", (usuario as Usuario).Login);
                command2.Parameters.AddWithValue("@password", (usuario as Usuario).Password);
                command2.Parameters.AddWithValue("@tipoCi", (usuario as Usuario).TipoIdentificacion);
                command2.Parameters.AddWithValue("@cedula", (usuario as Usuario).Identificacion);
                command2.Parameters.AddWithValue("@primerNombre", (usuario as Usuario).PrimerNombre);
                command2.Parameters.AddWithValue("@segundoNombre", "NULL");
                command2.Parameters.AddWithValue("@primerApellido", (usuario as Usuario).PrimerApellido);
                command2.Parameters.AddWithValue("@segundoApellido", "NULL");
                command2.Parameters.AddWithValue("@fechaNace", "12/12/12");
                command2.Parameters.AddWithValue("@fechaIngreso", "12/12/12");
                command2.Parameters.AddWithValue("@sexo", (usuario as Usuario).Sexo);
                command2.Parameters.AddWithValue("@correo", (usuario as Usuario).Correo);
                //cmd.Parameters.AddWithValue("@ocupacion", null);
                command2.Parameters.AddWithValue("@foto", "NULL");

                command2.Parameters.AddWithValue("@estado", "activo");
                ///command.Parameters.AddWithValue("@estado", (usuario as Usuario).Estado);


                //cmd.Parameters.AddWithValue("@sueldo", (usuario as Usuario).Sueldo);
                //cmd.Parameters.AddWithValue("@cargo", (usuario as Usuario).Especialidad);
                command2.Parameters.AddWithValue("@codigotlf", "212");
                command2.Parameters.AddWithValue("@numtelefono", (usuario as Usuario).Telefono.ElementAt(0));
                command2.Parameters.AddWithValue("@tipotelefono", "Movil");

                command2.Parameters.AddWithValue("@ciudad", "Caracas");

                // command.Parameters.AddWithValue("@ciudad", (usuario as Usuario).Direccion.Ciudad);
                command2.Parameters.AddWithValue("@municipio", (usuario as Usuario).Direccion.Municipio);
                command2.Parameters.AddWithValue("@calle", (usuario as Usuario).Direccion.Calle);
                command2.Parameters.AddWithValue("@edificio", (usuario as Usuario).Direccion.Edificio);

                command2.ExecuteNonQuery();

                //command.ExecuteNonQuery();
                /*dr = cmd.ExecuteReader();
                
                db.AbrirConexion();

                while (dr.Read())
                {
                    objetoEmpleado = new Empleado();
                    objetoEmpleado.Identificacion = dr.GetValue(0).ToString();
                    objetoEmpleado.PrimerNombre = dr.GetValue(1).ToString();
                    objetoEmpleado.PrimerApellido = dr.GetValue(2).ToString();
                    objetoEmpleado.Especialidad = dr.GetValue(3).ToString();

                    miListaEmpleado.Add(objetoEmpleado);
                }*/

                //db.CerrarConexion();
                conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                //db.CerrarConexion();
                conex.CerrarConexion();
            }

            return true;
        }
        #endregion Agregar Usuario
    }
}
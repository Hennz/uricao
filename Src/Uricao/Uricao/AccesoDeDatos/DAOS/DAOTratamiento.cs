using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using System.Data;
using System.Data.SqlClient;
using Uricao.Entidades.ETratamientos;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOTratamiento : DAOSQLServer, iDAOTratamiento
    {
        //IConexionDAOS bd = new ConexionDAOS();

        IConexionDAOS _conexion = FabricaConexion.AccesoConexion();
        SqlCommand command = new SqlCommand();

        //listo NO
        #region Agregar Tratamiento
        public bool SqlAgregarTratamiento(Entidad tratamientoPrimario)
        {
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            try
            {
                //Se Agrega el Tratamiento
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[AgregarTratamiento]";
                command.CommandTimeout = 10;


                command.Parameters.AddWithValue("@nombreTratamiento", (tratamientoPrimario as Tratamiento).Nombre);
                command.Parameters.AddWithValue("@duracionTratamiento", (tratamientoPrimario as Tratamiento).Duracion);
                command.Parameters.AddWithValue("@descripcionTratamiento", (tratamientoPrimario as Tratamiento).Descripcion);
                command.Parameters.AddWithValue("@costoTratamiento", (tratamientoPrimario as Tratamiento).Costo);
                command.Parameters.AddWithValue("@imagenTratamiento", (tratamientoPrimario as Tratamiento).Imagen);
                command.Parameters.AddWithValue("@explicacionTratamiento", (tratamientoPrimario as Tratamiento).Explicacion);
                command.Parameters.AddWithValue("@estadoTratamiento", (tratamientoPrimario as Tratamiento).Estado);

                command.Parameters["@nombreTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@duracionTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@descripcionTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@costoTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@imagenTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@explicacionTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@estadoTratamiento"].Direction = ParameterDirection.Input;


                reader = command.ExecuteReader();
                //command.ExecuteReader();
                //se lee la variable de tipo output para saber que id fue insertado en base de datos.
                //Int16 idInsertado = Convert.ToInt16(command.Parameters["@idTratamiento"].Value);
                //int idInsertado = (int)command.Parameters["@idTratamiento"].Value;

                //readers.Read();
                //int miIdTratamiento = Convert.ToInt16(readers.GetValue(0));
                reader.Close();
                return true;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw (e);
                //throw new ExcepcionTratamiento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la Busqueda", e);
            }
            finally
            {
                _conexion.CerrarConexion();
            }

        }
        #endregion Agregar Tratamiento

        #region Id Tratmiento Agregado
        public int SqlIdTratmientoNuevo()
        {
            int IdtratamientoPrimario;

            try
            {

                //Para Buscar el ID del Tratmiento nuevo
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.[IdTratamientoNuevo]";
                command.CommandTimeout = 10;

                SqlDataReader reader = null;
                reader = command.ExecuteReader();

                //Se recorre cada Fila
                reader.Read();
                //Se asigna cada atributo al objeto tratamiento
                IdtratamientoPrimario = Convert.ToInt16(reader.GetValue(0));
                reader.Close();
                return IdtratamientoPrimario;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la Busqueda", e);
            }
            finally
            {
                _conexion.CerrarConexion();
            }

        }
        #endregion

        //Listo Patron Asociado
        #region Agregar Tratamiento Asociado
        public bool SqlAgregarTratamientoAsociado(Entidad tratamientoPrimario, Entidad asociado)
        {

            try
            {
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[AgregarTratamientoAsociado]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@fkidTratamiento2", (asociado as Tratamiento).Id);
                command.Parameters.AddWithValue("@fkidTratamiento1", (tratamientoPrimario as Tratamiento).Id);
                SqlDataReader readers = command.ExecuteReader();
                readers.Close();
                return true;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion();
            }
        }
        #endregion

        //Listo REVISAR Patron Aplicado
        #region Activar/Desactivar Tratamiento
        public bool SqlActivarDesactivarTratamiento(Entidad tratamientoPrimario)
        {
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            //List<Tratamiento> miListaTratamiento = new List<Tratamiento>();

            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ActivarDesactivarTratamiento]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@idTratamiento", (tratamientoPrimario as Tratamiento).Id);
                command.Parameters.AddWithValue("@estadoTratamiento", (tratamientoPrimario as Tratamiento).Estado);

                reader = command.ExecuteReader();
                reader.Close();

                return true;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion();
            }
        }
        #endregion

        //Listo(P) Patron Aplicado
        #region Consultar Lista Tratamiento
        public List<Entidad> SqlConsultarTratamiento()
        {
            //Se instancia un objeto conexion 


            List<Entidad> milista = new List<Entidad>();
            Entidad _tratamiento;


            SqlDataReader reader = null;
            //List<Tratamiento> miListaTratamiento = new List<Tratamiento>();

            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.consultarListaTratamiento";


                //se ejecuta el metodo del store procedure que busca todos los Tratamientos del sistema
                reader = command.ExecuteReader();

                //Se recorre cada row
                while (reader.Read())
                {
                    _tratamiento = FabricaEntidad.NuevoTratamiento();
                    //Se asigna cada atributo al objeto tratamiento
                    (_tratamiento as Tratamiento).Id = Convert.ToInt16(reader.GetValue(0));
                    (_tratamiento as Tratamiento).Nombre = reader.GetValue(1).ToString();
                    (_tratamiento as Tratamiento).Duracion = Convert.ToInt16(reader.GetValue(2));
                    (_tratamiento as Tratamiento).Descripcion = reader.GetValue(3).ToString();
                    (_tratamiento as Tratamiento).Costo = Convert.ToInt16(reader.GetValue(4));
                    (_tratamiento as Tratamiento).Imagen = reader.GetValue(5).ToString();
                    (_tratamiento as Tratamiento).Explicacion = reader.GetValue(6).ToString();
                    (_tratamiento as Tratamiento).Estado = reader.GetValue(7).ToString();
                    //se inserta en la lista de tratamientos
                    milista.Add(_tratamiento);
                }
                reader.Close();
                //return miListaTratamiento;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion(); // cerramos la conexion
            }
            if (milista.Count == 0)
                return null;
            else
                return milista;



        }
        #endregion Consultar Tratamiento

        //Listo(P) Patron Aplicado
        #region Modificar Tratamiento
        public bool SqlModificarTratamiento(Entidad tratamientoPrimario)
        {
            try
            {
                _conexion.AbrirConexion(); //se abre una conexion a base de datos

                // se completa la informacion de la conexion , variables, y nombre del stored procedure.
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ModificarTratamiento]"; // StoreProcedure modificarTratamiento
                command.CommandTimeout = 10;

                //variables del stored procedure de sql server

                command.Parameters.AddWithValue("@idTratamiento", (tratamientoPrimario as Tratamiento).Id);
                command.Parameters.AddWithValue("@nombreTratamiento", (tratamientoPrimario as Tratamiento).Nombre);
                command.Parameters.AddWithValue("@duracionTratamiento", (tratamientoPrimario as Tratamiento).Duracion);
                command.Parameters.AddWithValue("@descripcionTratamiento", (tratamientoPrimario as Tratamiento).Descripcion);
                command.Parameters.AddWithValue("@costoTratamiento", (tratamientoPrimario as Tratamiento).Costo);
                command.Parameters.AddWithValue("@imagenTratamiento", (tratamientoPrimario as Tratamiento).Imagen);
                command.Parameters.AddWithValue("@explicacionTratamiento", (tratamientoPrimario as Tratamiento).Explicacion);
                command.Parameters.AddWithValue("@estadoTratamiento", (tratamientoPrimario as Tratamiento).Estado);

                command.Parameters["@idTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@nombreTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@duracionTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@descripcionTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@costoTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@imagenTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@explicacionTratamiento"].Direction = ParameterDirection.Input;
                command.Parameters["@estadoTratamiento"].Direction = ParameterDirection.Input;

                //se ejecuta el comando
                command.ExecuteReader();
                return true;

            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error con la Base de Datos, Tratamiento no Modificado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la Busqueda de los datos", e);
            }
            //se cierra la conexion independientemente de que se haya detectado o no una excepcion.
            finally
            {
                _conexion.CerrarConexion();
            }
        }
        #endregion Modificar Tratamiento

        //Listo(P) Patron Aplicado
        #region Consultar Tratamiento Asociado
        public List<Entidad> ConsultarTratamientoAsociado(int _idTratamiento)
        {
            //Se instancia un objeto conexion 
            SqlDataReader reader = null;
            List<Entidad> miListaTratamiento = new List<Entidad>();
            Entidad _tratamiento;


            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.ConsultarTratamientosAsociados";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@idTratamiento", _idTratamiento);

                //se ejecuta el metodo del store procedure que busca todos los clientes del sistema
                reader = command.ExecuteReader();

                //Se recorre cada row
                while (reader.Read())
                {
                    _tratamiento = FabricaEntidad.NuevoTratamiento();
                    //Se asigna cada atributo al objeto tratamiento
                    (_tratamiento as Tratamiento).Id = Convert.ToInt16(reader.GetValue(0));
                    (_tratamiento as Tratamiento).Nombre = reader.GetValue(1).ToString();
                    (_tratamiento as Tratamiento).Duracion = Convert.ToInt16(reader.GetValue(2));
                    (_tratamiento as Tratamiento).Descripcion = reader.GetValue(3).ToString();
                    (_tratamiento as Tratamiento).Costo = Convert.ToInt16(reader.GetValue(4));
                    (_tratamiento as Tratamiento).Imagen = reader.GetValue(5).ToString();
                    (_tratamiento as Tratamiento).Explicacion = reader.GetValue(6).ToString();
                    (_tratamiento as Tratamiento).Estado = reader.GetValue(7).ToString();
                    //se inserta el cliente en la lista de tratamientos
                    miListaTratamiento.Add(_tratamiento);
                }
                reader.Close();
                //return miListaTratamiento;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error en la conexion", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no encontrado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error", e);
            }
            finally
            {
                _conexion.CerrarConexion(); // cerramos la conexion
            }
            if (miListaTratamiento.Count == 0)
                return null;
            else
                return miListaTratamiento;
        }
        #endregion Consultar Tratamiento Asociado

        //Patron Aplicado
        #region Consultar Tratamiento No Asociado
        public List<Entidad> ConsultarTratamientoNoAsociado(int _idTratamiento)
        {
            //Se instancia un objeto conexion 
            SqlDataReader reader = null;
            List<Entidad> miListaTratamiento = new List<Entidad>();

            Entidad _tratamiento;

            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.[ConsultarTratamientosNoAsociados]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@idTratamiento", _idTratamiento);

                //se ejecuta el metodo del store procedure que busca todos los clientes del sistema
                reader = command.ExecuteReader();

                //Se recorre cada row
                while (reader.Read())
                {
                    _tratamiento = FabricaEntidad.NuevoTratamiento();
                    //Se asigna cada atributo al objeto tratamiento
                    (_tratamiento as Tratamiento).Id = Convert.ToInt16(reader.GetValue(0));
                    (_tratamiento as Tratamiento).Nombre = reader.GetValue(1).ToString();
                    //se inserta el cliente en la lista de tratamientos
                    miListaTratamiento.Add(_tratamiento);
                }
                reader.Close();
                //return miListaTratamiento;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error en la conexion", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no encontrado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error", e);
            }
            finally
            {
                _conexion.CerrarConexion(); // cerramos la conexion
            }
            if (miListaTratamiento.Count == 0)
                return null;
            else
                return miListaTratamiento;
        }
        #endregion Consultar Tratamiento No Asociado

        //Listo Patron Aplicado
        #region Consultar Parametros

        #region Consultar Tratamiento por Nombre
        //Restorna una lista por que el usuario puede ingresar una palabra del nombre
        //y dicha palabra puede existir en varios nombres de tratamientos
        public List<Entidad> SqlBuscarXNombreTramiento(string nombreTratamientoBuscar)
        {
            //Se instancia un objeto conexion 

            command = new SqlCommand();
            SqlDataReader reader = null;
            List<Entidad> miListaTratamiento = new List<Entidad>();
            Entidad _tratamiento;

            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.buscarPorNombreTratamiento";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@NombreTratamiento", nombreTratamientoBuscar);

                command.Parameters["@NombreTratamiento"].Direction = ParameterDirection.Input;
               // SqlDataReader readers = command.ExecuteReader();

                reader = command.ExecuteReader();

                //Se recorre cada Fila
                while (reader.Read())
                {
                    _tratamiento = FabricaEntidad.NuevoTratamiento();
                    //Se asigna cada atributo al objeto tratamiento
                    (_tratamiento as Tratamiento).Id = Convert.ToInt16(reader.GetValue(0));
                    (_tratamiento as Tratamiento).Nombre = reader.GetValue(1).ToString();
                    (_tratamiento as Tratamiento).Duracion = Convert.ToInt16(reader.GetValue(2));
                    (_tratamiento as Tratamiento).Descripcion = reader.GetValue(3).ToString();
                    (_tratamiento as Tratamiento).Costo = Convert.ToInt16(reader.GetValue(4));
                    (_tratamiento as Tratamiento).Imagen = reader.GetValue(5).ToString();
                    (_tratamiento as Tratamiento).Explicacion = reader.GetValue(6).ToString();
                    (_tratamiento as Tratamiento).Estado = reader.GetValue(7).ToString();

                    miListaTratamiento.Add(_tratamiento);
                }
                reader.Close();
                //return miListaTratamiento;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no econtrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                //throw e;
                throw new ExcepcionTratamiento("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion(); // cerramos la conexion
                reader.Close();
            }
            if (miListaTratamiento.Count == 0)
                return null;
            else
                return miListaTratamiento;
        }
        #endregion Consultar Tratamiento por Nombre

        //Listo Patron Aplicado
        #region Consultar Tratamiento por ID
        //Validar si no trae nada
        public Entidad SqlBuscarXIdTratamiento(int idTratamientoParametro)
        {
            //Se instancia un objeto conexion 

            command = new SqlCommand();
            SqlDataReader reader = null;
            List<Entidad> miListaTratamiento = new List<Entidad>();
            Entidad _tratamiento = FabricaEntidad.NuevoTratamiento();

            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.BuscarXIdTratamientos";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@idTratamiento", idTratamientoParametro);

                reader = command.ExecuteReader();

                //Se recorre cada Fila
                reader.Read();
                //Se asigna cada atributo al objeto tratamiento
                (_tratamiento as Tratamiento).Id = Convert.ToInt16(reader.GetValue(0));
                (_tratamiento as Tratamiento).Nombre = reader.GetValue(1).ToString();
                (_tratamiento as Tratamiento).Duracion = Convert.ToInt16(reader.GetValue(2));
                (_tratamiento as Tratamiento).Descripcion = reader.GetValue(3).ToString();
                (_tratamiento as Tratamiento).Costo = Convert.ToInt16(reader.GetValue(4));
                (_tratamiento as Tratamiento).Imagen = reader.GetValue(5).ToString();
                (_tratamiento as Tratamiento).Explicacion = reader.GetValue(6).ToString();
                (_tratamiento as Tratamiento).Estado = reader.GetValue(7).ToString();
                reader.Close();

            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no econtrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion(); // cerramos la conexion
            }
            if (_tratamiento == null)
                return null;
            else
                return _tratamiento;
        }
        #endregion

        //Listo Patron Aplicado
        #region Consultar Tratamiento por Estado
        public List<Entidad> SqlBuscarXEstadoTramiento(string estadoTratamientoBuscar)
        {
            //Se instancia un objeto conexion 

            command = new SqlCommand();
            SqlDataReader reader = null;
            List<Entidad> miListaTratamiento = new List<Entidad>();
            Entidad _tratamiento;

            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.BuscarXEstadoTratamiento";
                command.Parameters.AddWithValue("@EstadoTratamiento", estadoTratamientoBuscar);
                reader = command.ExecuteReader();

                //Se recorre cada Fila
                while (reader.Read())
                {
                    _tratamiento = FabricaEntidad.NuevoTratamiento();
                    //Se asigna cada atributo al objeto tratamiento
                    (_tratamiento as Tratamiento).Id = Convert.ToInt16(reader.GetValue(0));
                    (_tratamiento as Tratamiento).Nombre = reader.GetValue(1).ToString();
                    (_tratamiento as Tratamiento).Duracion = Convert.ToInt16(reader.GetValue(2));
                    (_tratamiento as Tratamiento).Descripcion = reader.GetValue(3).ToString();
                    (_tratamiento as Tratamiento).Costo = Convert.ToInt16(reader.GetValue(4));
                    (_tratamiento as Tratamiento).Imagen = reader.GetValue(5).ToString();
                    (_tratamiento as Tratamiento).Explicacion = reader.GetValue(6).ToString();
                    (_tratamiento as Tratamiento).Estado = reader.GetValue(7).ToString();

                    miListaTratamiento.Add(_tratamiento);
                }
                reader.Close();
                //return miListaTratamiento;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos no econtrados", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion(); // cerramos la conexion
            }
            if (miListaTratamiento.Count == 0)
                return null;
            else
                return miListaTratamiento;
        }
        #endregion


        #endregion

        //Listo Patron Aplicado
        #region Eliminar Tratamiento Asociado
        public bool SqlEliminarTratamientoAsociado(Entidad tratamientoPrimario)
        {
            SqlCommand command = new SqlCommand();
            try
            {
                _conexion.AbrirConexion(); //se abre una conexion a base de datos

                // se completa la informacion de la conexion , variables, y nombre del stored procedure.
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[BorrarTratamientoAsociado]"; // StoreProcedure EliminarTratamientoAsociado
                command.CommandTimeout = 10;

                //variables del stored procedure de sql server
                command.Parameters.AddWithValue("@idTratamiento", (tratamientoPrimario as Tratamiento).Id);
                //command.Parameters["@idTratamiento"].Direction = ParameterDirection.Input;

                //se ejecuta el comando
                command.ExecuteReader();
                return true;

            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Datos invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionTratamiento("Error con la Base de Datos, Tratamiento no Modificado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la Busqueda de los datos", e);
            }
            //se cierra la conexion independientemente de que se haya detectado o no una excepcion.
            finally
            {
                _conexion.CerrarConexion();
            }
        }
        #endregion

    }
}
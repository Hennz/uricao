using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using System.Data;
using System.Data.SqlClient;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOImplemento : DAOSQLServer, iDAOImplemento
    {
        IConexionDAOS _conexion = FabricaConexion.AccesoConexion();
        SqlCommand command = new SqlCommand();

        //Listo patron aplicado
        #region Agregar Implemento
        public bool SqlAgregarImplemento(Entidad implementoPrimario)
        {
            SqlDataReader reader = null;
            //IConexionDAOS bd;
            //SqlCommand command = new SqlCommand();
            try
            {
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[AgregarTratamientoProducto]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@fkProducto", (implementoPrimario as Implemento).IdProducto);
                command.Parameters.AddWithValue("@prioridad_trat_prod", (implementoPrimario as Implemento).Prioridad);
                command.Parameters.AddWithValue("@cantidad_trat_prod", (implementoPrimario as Implemento).Cantidad);
                command.Parameters.AddWithValue("@fkTratamiento", (implementoPrimario as Implemento).IdTratamiento);
                reader = command.ExecuteReader();
                reader.Close();

                return true;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionImplemento("Datos invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionImplemento("Error con la Base de Datos, Tratamiento no Modificado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion();
            }

        }
        #endregion Agregar Implemento
        //Listo patron aplicado
        #region Consultar Lista Implemento
        public List<Entidad> SqlConsultarImplemento(Entidad tratamientoPrimario)
        {
            //Se instancia un objeto conexion 

            SqlDataReader reader = null;
            List<Entidad> miListaImplemento = new List<Entidad>();
            Entidad implemento;



            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.BuscarTodoImplementoTratamiento";
                command.Parameters.AddWithValue("@idTratamiento", (tratamientoPrimario as Tratamiento).Id);
                command.CommandTimeout = 10;

                //se ejecuta el metodo del store procedure que busca todos los clientes del sistema
                reader = command.ExecuteReader();

                //Se recorre cada row
                while (reader.Read())
                {
                    implemento = FabricaEntidad.NuevoImplemento();
                    //Se asigna cada atributo al objeto implemento
                    (implemento as Implemento).IdProducto = Convert.ToInt16(reader.GetValue(0));
                    (implemento as Implemento).IdTratamiento = Convert.ToInt16(reader.GetValue(1));
                    (implemento as Implemento).IdImplemento = Convert.ToInt16(reader.GetValue(2));
                    (implemento as Implemento).TipoProducto = reader.GetValue(3).ToString();
                    (implemento as Implemento).Cantidad = Convert.ToInt16(reader.GetValue(4));
                    (implemento as Implemento).Prioridad = Convert.ToInt16(reader.GetValue(5));
                    //se inserta el cliente en la lista de Implementos
                    miListaImplemento.Add(implemento);
                }
                reader.Close();
                //return miListaImplemento;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionImplemento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionImplemento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la Busqueda de los datos", e);
            }
            if (miListaImplemento.Count == 0)
                return null;
            else
                return miListaImplemento;
        }
        #endregion Consultar Implemento
        //Listo patron aplicado
        #region Consultar Implemento por Nombre
        public List<Entidad> SqlBuscarXNombreImplemento(string nombreImplementoBuscar, Entidad tratamientoPrimario)
        {
            //Se instancia un objeto conexion 
            SqlDataReader reader = null;
            Entidad implemento;
            List<Entidad> miListaImplemento = new List<Entidad>();

            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.BuscarXNombreImplementoTratamiento";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@idTratamiento", (tratamientoPrimario as Tratamiento).Id);
                command.Parameters.AddWithValue("@nombreProducto", nombreImplementoBuscar);
                //SqlDataReader readers = command.ExecuteReader();

                reader = command.ExecuteReader();

                //Se recorre cada Fila
                while (reader.Read())
                {
                    implemento = FabricaEntidad.NuevoImplemento();
                    //Se asigna cada atributo al objeto implemento
                    (implemento as Implemento).IdProducto = Convert.ToInt16(reader.GetValue(0));
                    (implemento as Implemento).IdTratamiento = Convert.ToInt16(reader.GetValue(1));
                    //miImplemento.IdImplemento = Convert.ToInt16(reader.GetValue(2));
                    (implemento as Implemento).TipoProducto = reader.GetValue(3).ToString();
                    (implemento as Implemento).Cantidad = Convert.ToInt16(reader.GetValue(4));
                    (implemento as Implemento).Prioridad = Convert.ToInt16(reader.GetValue(5));
                    //se inserta el cliente en la lista de implementos
                    miListaImplemento.Add(implemento);

                    //miListaImplemento.Add(implemento);
                }
                reader.Close();
                //return miListaTratamiento;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionImplemento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Tratamiento no econtrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionImplemento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion(); // cerramos la conexion
            }
            if (miListaImplemento.Count == 0)
                return null;
            else
                return miListaImplemento;
        }
        #endregion
        //NO 
        #region Consultar Detalle Implemento
        public Implemento SqlConsultarDetalleImplemento(int _idimplemento)
        {

            SqlDataReader reader = null;
            Implemento miImplemento = new Implemento();
            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[mostrarImplemento]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@IdImplemento", _idimplemento);

                //se ejecuta el metodo del store procedure que busca todos los proyectos del sistema
                reader = command.ExecuteReader();

                //Se recorre cada row
                while (reader.Read())
                {
                    //Se asigna cada atributo al objeto implemento
                    //miImplemento.Id = Convert.ToInt16(reader.GetDecimal(0));
                    //miImplemento.Id = Convert.ToInt16(reader.GetDecimal(0));
                    //miImplemento.Nombre = reader.GetString(2);
                    //miImplemento.Duracion = Convert.ToInt16(reader.GetDecimal(3));
                    //miImplemento.Descripcion = reader.GetString(4);
                    //miImplemento.Costo = Convert.ToInt16(reader.GetDecimal(5));
                    //miImplemento.Imagen = reader.GetString(6);
                    //miImplemento.Explicacion = reader.GetString(7);
                    //se inserta el cliente en la lista de proyectos

                }

                return miImplemento;
            }
            catch (SqlException e)
            {
                throw new ExcepcionImplemento("Error en la conexion", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Los valores que devuelven la consulta son null", e);
            }
            //se cierra la conexion independientemente de que se haya detectado o no una excepcion.
            finally
            {
                _conexion.CerrarConexion();
            }

        }
        #endregion Consultar Detalle Implemento
        //Listo patron aplicado
        #region Modificar Implemento
        public bool SqlModificarImplemento(Entidad miImplemento)
        {
            //se instancia un objeto de tipo conexion y sqlCommand
            //estos se utilizan para acceder a base de datos y ejecutar el stored procedure en sql server
            //int idInsertado = 1;
            try
            {
                _conexion.AbrirConexion(); //se abre una conexion a base de datos

                // se completa la informacion de la conexion , variables, y nombre del stored procedure.
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ModificarImplemento]"; // StoreProcedure modificarImplemento
                command.CommandTimeout = 10;

                //variables del stored procedure de sql server

                command.Parameters.AddWithValue("@idtratProd", (miImplemento as Implemento).IdImplemento);
                command.Parameters.AddWithValue("@prioridad_trat_prod", (miImplemento as Implemento).Prioridad);
                command.Parameters.AddWithValue("@cantidad_trat_prod", (miImplemento as Implemento).Cantidad);

                command.Parameters["@idtratProd"].Direction = ParameterDirection.Input;
                command.Parameters["@prioridad_trat_prod"].Direction = ParameterDirection.Input;
                command.Parameters["@cantidad_trat_prod"].Direction = ParameterDirection.Input;

                //se ejecuta el comando
                command.ExecuteReader();
                return true;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionImplemento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionImplemento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la Busqueda de los datos", e);
            }
        }
        #endregion Modificar Implemento
        //Listo patron aplicado
        #region Eliminar Implemento Tratamiento
        public bool SqlEliminarImplementosAsociado(Entidad tratamientoPrimario)
        {
            try
            {
                _conexion.AbrirConexion(); //se abre una conexion a base de datos

                // se completa la informacion de la conexion , variables, y nombre del stored procedure.
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[BorrarTratamientoProducto]"; // StoreProcedure EliminarTratamientoProducto
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
                throw new ExcepcionImplemento("Datos invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionImplemento("Error con la Base de Datos, Tratamiento no Modificado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la Busqueda de los datos", e);
            }
            //se cierra la conexion independientemente de que se haya detectado o no una excepcion.
            finally
            {
                _conexion.CerrarConexion();
            }
        }
        #endregion
        //Listo patron aplicado
        #region Consultar Lista Implemento
        public List<Entidad> SqlConsultarNoImplementoTratamiento(Entidad tratamientoPrimario)
        {
            //Se instancia un objeto conexion 

            SqlDataReader reader = null;
            List<Entidad> miListaImplemento = new List<Entidad>();
            Entidad implemento;


            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                command.Connection = _conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.[BuscarProductoNoImplemento]";
                command.Parameters.AddWithValue("@idTratamiento", (tratamientoPrimario as Tratamiento).Id);
                command.CommandTimeout = 10;

                //se ejecuta el metodo del store procedure que busca todos los clientes del sistema
                reader = command.ExecuteReader();

                //Se recorre cada row
                while (reader.Read())
                {
                    implemento = FabricaEntidad.NuevoImplemento();
                    //Se asigna cada atributo al objeto implemento
                    (implemento as Implemento).IdProducto = Convert.ToInt16(reader.GetValue(0));
                    (implemento as Implemento).TipoProducto = reader.GetValue(1).ToString();
                    //se inserta el cliente en la lista de implementos
                    miListaImplemento.Add(implemento);
                }
                reader.Close();
                //return miListaImplemento;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionImplemento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionImplemento("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la Busqueda de los datos", e);
            }
            if (miListaImplemento.Count == 0)
                return null;
            else
                return miListaImplemento;
        }
        #endregion Consultar Implemento
    }

}
using System;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.Entidades.EProductosInventario;
using System.Data.SqlClient;
using Uricao.LogicaDeNegocios.Excepciones.ExcepcionesProductos;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOInventario : DAOSQLServer, iDAOInventario
    {
        IConexionDAOS db = new ConexionDAOS();

        public decimal CalcularEntrantes(Entidad producto)
        {
            decimal cantidad = 0;
            SqlDataReader tabla = ObtenerCantidadProducto((producto as Producto).Nombre);
            try
            {
                while (tabla.Read())
                {
                    if (tabla.IsDBNull(0))
                        return 0;
                    
                    cantidad = Convert.ToDecimal(tabla.GetValue(0));
                }
                db.CerrarConexion();
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionInventario("No se pudo obtener la cantidad", e);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.CerrarConexion();
            }
            return cantidad;
        }

        public int CalcularConsumos(Entidad producto)
        {
            return 0;
        }

        public SqlDataReader ObtenerCantidadProducto(String producto)
        {
            ConexionDAOS conexion = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader tabla = null;
            try
            {
                conexion.AbrirConexion();

                command.Connection = conexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[SumarCantidadProducto]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@nombreProducto", producto);

                tabla = command.ExecuteReader();
            }
            catch (SqlException e)
            {
                throw new ExcepcionInventario("Error de conexión con la base de datos", e);
            }
            catch (Exception e)
            {
                throw e;
            }
            return tabla;
        }

    }
}
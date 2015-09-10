using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.Entidades.EProductosInventario;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Uricao.LogicaDeNegocios.Excepciones.ExcepcionesProductos;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EProveedores;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.AccesoDeDatos.Conexion;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOProducto : DAOSQLServer, iDAOProducto
    {
        IConexionDAOS db = new ConexionDAOS();
        //si
        public List<Entidad> ConsultarProductos()
        {
            List<Entidad> productos = new List<Entidad>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader tabla;
            Entidad producto;
            
            try
            {
                db.AbrirConexion();
                cmd.Connection = db.ObjetoConexion();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SeleccionarTodosLosProductos";
                cmd.CommandTimeout = 10;
                tabla = cmd.ExecuteReader();
                while (tabla.Read())
                {
                    producto = FabricaEntidad.NuevoProducto();
                    (producto as Producto).Nombre = tabla.GetValue(0).ToString();
                    (producto as Producto).Tipo = tabla.GetValue(1).ToString();
                    (producto as Producto).nombreCategoria = tabla.GetValue(2).ToString();

                    productos.Add(producto);
                }
                db.CerrarConexion();
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProducto("No se pudieron cargar los productos de la base de datos", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionProducto("Error en la base de datos de Productos al consultar todos los productos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionProducto("Error en producto al consultar todos los productos",e);
            }
            finally
            {
                db.CerrarConexion();
            }
            return productos;
        }
        //si
        public List<Entidad> ConsultarProductosDetallados(Entidad productoGenerico)
        {
            
            Entidad producto;
            List<Entidad> productos = new List<Entidad>();
            SqlCommand command = new SqlCommand();
            SqlDataReader tabla = null;
            try
            {
                db.AbrirConexion();
                command.Connection = db.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[SeleccionarProductosDetallados]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@nombreProducto", (productoGenerico as Producto).Nombre);
                tabla = command.ExecuteReader();

                while (tabla.Read())
                {
                    producto = FabricaEntidad.NuevoProducto();

                    (producto as Producto).Nombre = (productoGenerico as Producto).Nombre;
                    (producto as Producto).Tipo = (productoGenerico as Producto).Tipo;
                    (producto as Producto).Categoria = (productoGenerico as Producto).Categoria;

                    (producto as Producto).Codigo = tabla.GetValue(1).ToString();
                    (producto as Producto).Calidad = tabla.GetValue(2).ToString();
                    (producto as Producto).Precio = Convert.ToDecimal(tabla.GetValue(3).ToString());
                    (producto as Producto).Marca = tabla.GetValue(4).ToString();
                    (producto as Producto).Proveedor = new Proveedor();
                    (producto as Producto).Proveedor.Nombre = tabla.GetValue(5).ToString();

                    productos.Add(producto);
                }
                db.CerrarConexion();
            }
            catch (ExcepcionProducto e)
            {
                throw e; 
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProducto("No se pudieron obtener los productos detallados", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionProducto("Error en la base de datos de productos al consultar los productos detallados",e);
            }
            catch (Exception e)
            {
                throw new ExcepcionProducto("Error en producto al consultar los productos detallados", e);
            }
            finally
            {
                db.CerrarConexion();
            }
            return productos;
        }
        //si
        public List<String> ConsultarCategorias()
        {
            List<String> categorias = new List<String>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader tabla;
            try
            {
                db.AbrirConexion();
                cmd.Connection = db.ObjetoConexion();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SeleccionarTodasLasCategorias";
                cmd.CommandTimeout = 10;
                tabla = cmd.ExecuteReader();
            
                while (tabla.Read())
                {
                    categorias.Add(tabla.GetValue(1).ToString());
                }
                db.CerrarConexion();
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProducto("No se pudieron obtener las categorias de productos", e);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.CerrarConexion();
            }
            return categorias;
        }
        //si
        public List<String> ConsultarMarcas()
        {
            List<String> marcas = new List<String>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader tabla;
            try
            {
                db.AbrirConexion();
                cmd.Connection = db.ObjetoConexion();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SeleccionarTodasLasMarcas";
                cmd.CommandTimeout = 10;
                tabla = cmd.ExecuteReader();
                while (tabla.Read())
                {
                    marcas.Add(tabla.GetValue(0).ToString());
                }
                db.CerrarConexion();
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProducto("No se pudieron obtener las marcas de productos", e);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.CerrarConexion();
            }
            return marcas;
        }
        //si
        public List<String> ConsultarMarcas(String proveedor)
        {
            List<String> marcas = new List<String>();
            SqlCommand command = new SqlCommand();
            
            try
            {
                db.AbrirConexion();

                command.Connection = db.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[SeleccionarTodasLasMarcasProveedor]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@nombreProveedor", proveedor);

                SqlDataReader tabla = command.ExecuteReader();

                while (tabla.Read())
                {
                    marcas.Add(tabla.GetValue(0).ToString());
                }
                db.CerrarConexion();
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProducto("No se pudieron obtener las marcas de productos", e);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.CerrarConexion();
            }
            return marcas;
        }
        //si
        public bool AgregarProducto(Entidad producto)
        {
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                db.AbrirConexion();
                command.Connection = db.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[AgregarProducto]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@nombreProducto", (producto as Producto).Nombre);
                command.Parameters.AddWithValue("@tipoProducto", (producto as Producto).Tipo);
                command.Parameters.AddWithValue("@categoria", (producto as Producto).Categoria);
                command.Parameters.AddWithValue("@cantidad", (producto as Producto).CantidadMinInventario);

                reader = command.ExecuteReader();
                reader.Close();
            }
            catch (SqlException e)
            {
                throw new ExcepcionProducto("Error de conexión con la base de datos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProducto("Error en la referencia producto",e);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.CerrarConexion();
            }
            return true;
        }
        //Si
        public bool AgregarDetalleProducto(Entidad producto)
        {
            SqlCommand command = new SqlCommand();
            SqlDataReader tabla = null;
            try
            {
                db.AbrirConexion();
                command.Connection = db.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[AgregarDetalleProducto]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@codigo", (producto as Producto).Codigo);
                command.Parameters.AddWithValue("@precio", (producto as Producto).Precio);
                command.Parameters.AddWithValue("@calidad", (producto as Producto).Calidad);
                command.Parameters.AddWithValue("@marca", (producto as Producto).Marca);
                command.Parameters.AddWithValue("@producto", (producto as Producto).Nombre);


                tabla = command.ExecuteReader();
                tabla.Close();
            }
            catch (SqlException e)
            {
                throw new ExcepcionProducto("Error de conexión con la base de datos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProducto("Error en la referncia",e);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.CerrarConexion();
            }
            return true;
        }
        //Si
        public bool EditarProducto(Entidad producto)
        {
            SqlCommand command = new SqlCommand();
            SqlDataReader tabla = null;
            try
            {
                db.AbrirConexion();
                command.Connection = db.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[EditarProducto]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@codigo", (producto as Producto).Codigo);
                command.Parameters.AddWithValue("@precio", (producto as Producto).Precio);
                command.Parameters.AddWithValue("@calidad", (producto as Producto).Calidad);
                command.Parameters.AddWithValue("@marca", (producto as Producto).Marca);

                tabla = command.ExecuteReader();
                tabla.Close();
            }
            catch (SqlException e)
            {
                throw new ExcepcionProducto("Error de conexión con la base de datos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProducto("Error de Referencia al editar el profucto",e);
            }
            catch (Exception e)
            {
                throw new ExcepcionProducto("Error al editar el producto",e);
            }
            finally
            {
                db.CerrarConexion();
            }
            return true;
        }
        //si
        public bool EditarProductoGenerico(Entidad producto, String nombreViejo)
        {
            SqlCommand command = new SqlCommand();
            SqlDataReader tabla = null;
            try
            {
                db.AbrirConexion();
                command.Connection = db.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[EditarProductoGenerico]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@nombreViejo", nombreViejo);
                command.Parameters.AddWithValue("@nombreNuevo", (producto as Producto).Nombre);
                command.Parameters.AddWithValue("@tipo", (producto as Producto).Tipo);
                command.Parameters.AddWithValue("@categoria", (producto as Producto).Categoria);

                tabla = command.ExecuteReader();
                tabla.Close();
            }
            catch (SqlException e)
            {
                throw new ExcepcionProducto("Error de conexión con la base de datos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProducto("Error con la referencia",e);
            }
            catch (Exception e)
            {
                throw new ExcepcionProducto("Error en Editar Producto Generico",e);
            }
            finally
            {
                db.CerrarConexion();
            }
            return true;
        }

        #region Consultar Productos realizado por el equipo de Tratamientos

        IConexionDAOS _conexion = FabricaConexion.AccesoConexion();
        SqlCommand _command = new SqlCommand();

        #region consultar todos productos
        public List<Entidad> SqlConsultarProductoImplemento()
        {

            _command = new SqlCommand();
            Entidad _producto;
            //Se instancia un objeto conexion 

            SqlDataReader reader = null;
            List<Entidad> miListaProducto = new List<Entidad>();

            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                _command.Connection = _conexion.ObjetoConexion();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "dbo.ConsultarTodosImplementosProductos";
                _command.CommandTimeout = 10;

                //se ejecuta el metodo del store procedure que busca todos los Tratamientos del sistema
                reader = _command.ExecuteReader();
                
                //Se recorre cada row
                while (reader.Read())
                {
                    _producto = FabricaEntidad.NuevoProducto() ;
                    //Se asigna cada atributo al objeto tratamiento
                    (_producto as Producto).Id = Convert.ToInt16(reader.GetValue(0));
                    (_producto as Producto).Nombre = reader.GetValue(1).ToString();
                    //se inserta en la lista de tratamientos
                    miListaProducto.Add(_producto);
                }
                reader.Close();
                //return miListaTratamiento;
            }
            catch (ArgumentException e)
            {
                throw new Exception("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new Exception("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion(); // cerramos la conexion
            }
            if (miListaProducto.Count == 0)
                return null;
            else
                return miListaProducto;
        }
        #endregion consultar todos productos

        #region Consultar los Productos que no son implemento
        public List<Entidad> SqlConsultarProductoNoImplemento(Entidad miTratamiento)
        {
            
            _command = new SqlCommand();

            //Se instancia un objeto conexion 

            SqlDataReader reader = null;
            List<Entidad> miListaProducto = new List<Entidad>();
            Entidad _producto;
            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                _command.Connection = _conexion.ObjetoConexion();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "dbo.BuscarProductoNoImplemento";
                _command.CommandTimeout = 10;


                _command.Parameters.AddWithValue("@idTratamiento", (miTratamiento as Producto).Id);
                //se ejecuta el metodo del store procedure que busca todos los Tratamientos del sistema
                reader = _command.ExecuteReader();

                //Se recorre cada row
                while (reader.Read())
                {
                    _producto = FabricaEntidad.NuevoProducto();
                    //Se asigna cada atributo al objeto tratamiento
                    (_producto as Producto).Id = Convert.ToInt16(reader.GetValue(0));
                    (_producto as Producto).Nombre = reader.GetValue(1).ToString();
                    //se inserta en la lista de tratamientos
                    miListaProducto.Add(_producto);
                }
                reader.Close();
                //return miListaTratamiento;
            }
            catch (ArgumentException e)
            {
                throw new Exception("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new Exception("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion(); // cerramos la conexion
            }
            if (miListaProducto.Count == 0)
                return null;
            else
                return miListaProducto;
        }
        #endregion Consultar los Productos que no son implemento

        #region Consultar Producto por nombre
        public List<Entidad> SqlConsultarXNombreProducto(string productoNombre )
        {
            
            _command = new SqlCommand();

            //Se instancia un objeto conexion 

            SqlDataReader reader = null;
            List<Entidad> miListaProducto = new List<Entidad>();
            Entidad _producto;

            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                _command.Connection = _conexion.ObjetoConexion();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "dbo.BuscarXNombreProducto";
                _command.CommandTimeout = 10;


                _command.Parameters.AddWithValue("@nombreProducto", productoNombre);
                //_command ejecuta el metodo del store procedure que busca todos los Tratamientos del sistema
                reader = _command.ExecuteReader();

                //Se recorre cada row
                while (reader.Read())
                {
                    _producto = FabricaEntidad.NuevoProducto(); ;
                    //Se asigna cada atributo al objeto tratamiento
                    (_producto as Producto).Id = Convert.ToInt16(reader.GetValue(0));
                    (_producto as Producto).Nombre = reader.GetValue(1).ToString();
                    //se inserta en la lista de tratamientos
                    miListaProducto.Add(_producto);
                }
                reader.Close();
                //return miListaTratamiento;
            }
            catch (ArgumentException e)
            {
                throw new Exception("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new Exception("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la Busqueda de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion(); // cerramos la conexion
            }
            if (miListaProducto.Count == 0)
                return null;
            else
                return miListaProducto;
        }
        #endregion Consultar Producto por nombre
       
        public List<Entidad> SqlTraerProductos()
        {
            //Se instancia un objeto conexion 


            List<Entidad> milista = new List<Entidad>();
            Entidad _producto;


            SqlDataReader reader = null;
            //List<Tratamiento> miListaTratamiento = new List<Tratamiento>();

            try
            {
                //Se abre la conexion a la base de datos
                _conexion.AbrirConexion();
                _command.Connection = _conexion.ObjetoConexion();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "dbo.ConsultarTodosImplementosProductos";


                //se ejecuta el metodo del store procedure que busca todos los Tratamientos del sistema
                reader = _command.ExecuteReader();

                //Se recorre cada row
                while (reader.Read())
                {
                    _producto = FabricaEntidad.NuevoProducto();
                    //Se asigna cada atributo al objeto tratamiento
                    (_producto as Producto).Id = Convert.ToInt16(reader.GetValue(0));
                    (_producto as Producto).Nombre = reader.GetValue(1).ToString();
                    //se inserta en la lista de tratamientos
                    milista.Add(_producto);
                }
                reader.Close();
                //return miListaTratamiento;
            }
            catch (ArgumentException e)
            {
                throw new Exception("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new Exception("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la Busqueda de los datos", e);
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
        #endregion


    }
}
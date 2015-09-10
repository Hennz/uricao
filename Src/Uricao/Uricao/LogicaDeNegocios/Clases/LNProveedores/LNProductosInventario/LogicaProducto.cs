using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EProductosInventario;
using Uricao.AccesoDeDatos.SqlServer;
using System.Data.SqlClient;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones.ExcepcionesProductos;

namespace Uricao.LogicaDeNegocios.Clases.LNProductosInventario
{
    public class LogicaProducto
    {
        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();
            SqlServerProducto objDataBase = new SqlServerProducto();
            try
            {
                productos = objDataBase.ConsultarProductos();
            }
            catch (ExcepcionNulo e)
            {
                System.Diagnostics.Debug.WriteLine(e.MensajeError);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return productos;
        }

        public List<Producto> ObtenerProductosDetallados(Producto productoGenerico)
        {
            List<Producto> productos = new List<Producto>();
            SqlServerProducto objDataBase = new SqlServerProducto();
            try
            {
                productos = objDataBase.ConsultarProductosDetallados(productoGenerico);
            }
            catch (ExcepcionNulo e)
            {
                System.Diagnostics.Debug.WriteLine(e.MensajeError);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return productos;

        }

        public List<string> ObtenerCategorias()
        {
            List<string> categorias = new List<string>();
            SqlServerProducto objDataBase = new SqlServerProducto();
            try
            {
                categorias = objDataBase.ConsultarCategorias();
            }
            catch (ExcepcionNulo e)
            {
                System.Diagnostics.Debug.WriteLine(e.MensajeError);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return categorias;
        }

        public List<string> ObtenerMarcas()
        {
            List<string> marcas = new List<string>();
            SqlServerProducto objDataBase = new SqlServerProducto();
            try
            {
                marcas = objDataBase.ConsultarMarcas();
            }
            catch (ExcepcionNulo e)
            {
                System.Diagnostics.Debug.WriteLine(e.MensajeError);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return marcas;
        }

        public List<string> ObtenerMarcas(string proveedor)
        {
            List<string> marcas = new List<string>();
            SqlServerProducto objDataBase = new SqlServerProducto();
            try
            {
                marcas = objDataBase.ConsultarMarcas(proveedor);
            }
            catch (ExcepcionNulo e)
            {
                System.Diagnostics.Debug.WriteLine(e.MensajeError);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return marcas;
        }

        public bool AgregarProducto(Producto producto)
        {
            SqlServerProducto objDataBase = new SqlServerProducto();
            try
            {
                //1-Agregar el producto asociado a esa categoria
                objDataBase.AgregarProducto(producto);

                //2-Agregar el detalle_producto asociado al producto y a la marca 
                objDataBase.AgregarDetalleProducto(producto);
            }
            catch (ExcepcionSql e)
            {
                System.Diagnostics.Debug.WriteLine(e.MensajeError);
                return false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public bool EditarProducto(Producto producto)
        {
            SqlServerProducto objDataBase = new SqlServerProducto();
            try
            {
                objDataBase.EditarProducto(producto);
            }
            catch (ExcepcionSql e)
            {
                System.Diagnostics.Debug.WriteLine(e.MensajeError);
                return false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public bool EditarProductoGenerico(Producto producto, string nombreViejo)
        {
            SqlServerProducto objDataBase = new SqlServerProducto();
            try
            {
                objDataBase.EditarProductoGenerico(producto, nombreViejo);
            }
            catch (ExcepcionSql e)
            {
                System.Diagnostics.Debug.WriteLine(e.MensajeError);
                return false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        #region Consultar Productos realizado por el equipo de Tratamientos
        #region Consultar Lista de Productos
        public List<Producto> CargarListaProductoImplemento()
        {
            try
            {
                List<Producto> miLista = new SqlServerProducto().SqlConsultarProductoImplemento();
                return miLista;
            }
            catch (ArgumentException e)
            {
                throw new Exception("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Productos vacios", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de los Productos", e);
            }
        }
        #endregion Consultar Lista de Productos

        #region Consultar Productos que NO son implementos
        public List<Producto> ListaProductosNoImplemento(Tratamiento miTratamiento)
        {
            try
            {
                List<Producto> miLista = new SqlServerProducto().SqlConsultarProductoNoImplemento(miTratamiento);
                return miLista;
            }
            catch (ArgumentException e)
            {
                throw new Exception("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Productos vacios", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de los Productos", e);
            }
        }
        #endregion

        #region Consultar Productos por Nombre
            public List<Producto> CargarListaProductoNombre(String productoNombre)
            {
            try
            {
                List<Producto> miLista = new SqlServerProducto().SqlConsultarXNombreProducto(productoNombre);
                return miLista;
            }
            catch (ArgumentException e)
            {
                throw new Exception("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Productos vacios", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de los Productos", e);
            }
        }
        #endregion Consultar Producot por Nombre
        #endregion
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EProductosInventario;
using Uricao.AccesoDeDatos.DAOS;
using System.Data.SqlClient;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones.ExcepcionesProductos;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Clases.LNProductosInventario
{
    public class LogicaProducto
    {
        //
        public List<Entidad> ObtenerProductos()
        {
            List<Entidad> productos = new List<Entidad>();
            DAOProducto objDataBase = new DAOProducto();
            try
            {
                productos = objDataBase.ConsultarProductos();
            }
            catch (ExcepcionProducto e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return productos;
        }
        //
        public List<Entidad> ObtenerProductosDetallados(Entidad productoGenerico)
        {
            List<Entidad> productos = new List<Entidad>();
            DAOProducto objDataBase = new DAOProducto();
            try
            {
                productos = objDataBase.ConsultarProductosDetallados(productoGenerico);
            }
            catch (ExcepcionProducto e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return productos;

        }
        //si
        public List<String> ObtenerCategorias()
        {
            List<String> categorias = new List<String>();
            DAOProducto objDataBase = new DAOProducto();
            try
            {
                categorias = objDataBase.ConsultarCategorias();
            }
            catch (ExcepcionProducto e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return categorias;
        }
        //
        public List<String> ObtenerMarcas()
        {
            List<String> marcas = new List<String>();
            DAOProducto objDataBase = new DAOProducto();
            try
            {
                marcas = objDataBase.ConsultarMarcas();
            }
            catch (ExcepcionProducto e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return marcas;
        }
        //si
        public List<String> ObtenerMarcas(String proveedor)
        {
            List<String> marcas = new List<String>();
            DAOProducto objDataBase = new DAOProducto();
            try
            {
                marcas = objDataBase.ConsultarMarcas(proveedor);
            }
            catch (ExcepcionProducto e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return marcas;
        }
        //si
        public bool AgregarProducto(Entidad producto)
        {
            DAOProducto objDataBase = new DAOProducto();
            try
            {
                //1-Agregar el producto asociado a esa categoria
                objDataBase.AgregarProducto(producto);

                //2-Agregar el detalle_producto asociado al producto y a la marca 
                objDataBase.AgregarDetalleProducto(producto);
            }
            catch (ExcepcionProducto e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public bool EditarProducto(Entidad producto)
        {
            DAOProducto objDataBase = new DAOProducto();
            try
            {
                objDataBase.EditarProducto(producto);
            }
            catch (ExcepcionProducto e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public bool EditarProductoGenerico(Entidad producto, String nombreViejo)
        {
            DAOProducto objDataBase = new DAOProducto();
            try
            {
                objDataBase.EditarProductoGenerico(producto, nombreViejo);
            }
            catch (ExcepcionProducto e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        /*

        #region Consultar Productos realizado por el equipo de Tratamientos
        #region Consultar Lista de Productos
        public List<Producto> CargarListaProductoImplemento()
        {
            try
            {
                List<Producto> miLista = new DAOProducto().SqlConsultarProductoImplemento();
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
                List<Producto> miLista = new DAOProducto().SqlConsultarProductoNoImplemento(miTratamiento);
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
                List<Producto> miLista = new DAOProducto().SqlConsultarXNombreProducto(productoNombre);
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
        #endregion*/
        
    }
         
}
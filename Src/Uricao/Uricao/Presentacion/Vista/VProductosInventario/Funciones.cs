using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Clases.LNProductosInventario;
using Uricao.Entidades.EProveedores;
using Uricao.LogicaDeNegocios.Clases.LNProveedores;

namespace Uricao.Presentacion.PaginasWeb.PProductosInventario
{
    public static class Funciones
    {   
        public static void CrearTabla(DataTable table, List<string> columnas)
        {
            foreach (string columna in columnas)
                table.Columns.Add(columna, typeof(string));
        }

        public static void LlenarCategorias(DropDownList categorias)
        {
            categorias.Items.Clear();
            List<string> listaCategorias = new List<string>();
            LogicaProducto logicaProducto = new LogicaProducto();
            listaCategorias = logicaProducto.ObtenerCategorias();
            foreach (string categoria in listaCategorias)
            {
                categorias.Items.Add(categoria);
            }
        }

        public static void LlenarTipo(DropDownList tipo)
        {
            tipo.Items.Clear();
            tipo.Items.Add("Producto Medico");
            tipo.Items.Add("Equipo Medico");
        }

        public static void LlenarCalidad(DropDownList calidad)
        {
            calidad.Items.Clear();
            calidad.Items.Add("Alta");
            calidad.Items.Add("Media");
            calidad.Items.Add("Baja");
        }

        public static void LlenarProveedores(DropDownList proveedores)
        {
            proveedores.Items.Clear();
            List<Proveedor> listaProveedores = new List<Proveedor>();
            LogicaProveedor logicaProveedor = new LogicaProveedor();
            listaProveedores = logicaProveedor.ObtenerProveedores();
            foreach (Proveedor proveedor in listaProveedores)
            {
                proveedores.Items.Add(proveedor.Nombre);
            }
        }

        public static void LlenarMarcas(DropDownList marcas)
        {
            marcas.Items.Clear();
            List<string> listaMarcas = new List<string>();
            LogicaProducto logicaProducto = new LogicaProducto();
            listaMarcas = logicaProducto.ObtenerMarcas();
            foreach (string marca in listaMarcas)
            {
                marcas.Items.Add(marca);
            }
        }

        public static Proveedor ObtenerObjetoProveedor(string proveedor)
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            LogicaProveedor logicaProveedor = new LogicaProveedor();
            listaProveedores = logicaProveedor.ObtenerProveedores();
            foreach (Proveedor proveedorObj in listaProveedores)
            {
                if (proveedorObj.Nombre == proveedor)
                {
                    return proveedorObj;
                }
            }
            return null;
        }

        public static void LlenarMarcas(DropDownList marcas, string proveedor)
        {
            marcas.Items.Clear();
            List<string> listaMarcas = new List<string>();
            LogicaProducto logicaProducto = new LogicaProducto();
            listaMarcas = logicaProducto.ObtenerMarcas(proveedor);
            foreach (string marca in listaMarcas)
            {
                marcas.Items.Add(marca);
            }
        }

        public static void LlenarNombreProductos(DropDownList productos, string categoria)
        {
            //Aquí deberia llenar los productos de la categoria que haya sido seleccionada
        }

        public static int SeleccionGrid(GridView GridConsultar)
        {
            int seleccion = GridConsultar.SelectedIndex;
            if (GridConsultar.PageIndex != 0)
            {
                int pagina = GridConsultar.PageIndex;
                GridConsultar.PageIndex = 0;
                //int filas = GridConsultar.Rows.Count;
                int filas = 8;
                seleccion = filas * pagina + seleccion;
            }
            return seleccion;
        }
    }
}
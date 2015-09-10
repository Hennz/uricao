using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CProductosInventario;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EProductosInventario;

namespace Uricao.Presentacion.Presentador.PProductosInventario
{
    public class PresentadorAgregarProducto
    {
        private IContratoAgregarProducto _vista;

        public PresentadorAgregarProducto(IContratoAgregarProducto laVista)
        {
            this._vista = laVista;
        }

        public void OnLoad()
        {
            _vista.SetDropDownListCategoria(LlenarCategorias());
            _vista.SetDropDownListProveedor(LlenarProveedores());
        }

        public DropDownList LlenarCategorias()
        {
            DropDownList combo = new DropDownList();
            try
            {
                List<String> listaCategorias = FabricaComando.CrearComandoConsultarCategoria().Ejecutar();
                for (int i = 0 ; i < listaCategorias.Count ; i++)
                {
                    combo.Items.Add(listaCategorias[i].ToString());
                }
            }
            catch (Exception e)
            {
                _vista.SetFalla(e.Message);
                combo = null;
            }
            return combo;
        }

        public DropDownList LlenarProveedores()
        {
            DropDownList combo = new DropDownList();
            try
            {
                Entidad proveedor = FabricaEntidad.NuevoProveedor();
                List<Entidad> listaProveedores = FabricaComando.CrearComandoConsultarTodosProveedores().Ejecutar();
                for (int i = 0; i < listaProveedores.Count; i++)
                {
                    proveedor = listaProveedores[i];
                    combo.Items.Add((proveedor as Proveedor).Nombre.ToString());
                }
            }
            catch (Exception e)
            {
                _vista.SetFalla(e.Message);
                combo = null;
            }
            return combo;
        }

        public void LlenarMarcas(String proveedor)
        {
            DropDownList combo = new DropDownList();
            try
            {
                String marca;
                List<String> listaMarcas = FabricaComando.CrearComandoConsultarMarcasXProveedor(proveedor).Ejecutar();
                for (int i = 0; i < listaMarcas.Count; i++)
                {
                    marca = listaMarcas[i];
                    combo.Items.Add(marca);
                }
            }
            catch (Exception e)
            {
                _vista.SetFalla(e.Message);
                combo = null;
            }
            _vista.SetDropDownListMarca(combo);
        }

        public Boolean AgregarProducto()
        {
            try
            {
                Entidad producto = FabricaEntidad.NuevoProducto();

                (producto as Producto).Codigo = _vista.GetCodigo().Text;
                (producto as Producto).Nombre = _vista.GetNombre().Text;
                (producto as Producto).Tipo = _vista.GetTipo().SelectedValue;
                (producto as Producto).Categoria = Convert.ToInt16(_vista.GetCategoria().SelectedIndex + 1);
                (producto as Producto).CantidadMinInventario = Convert.ToInt16(_vista.GetCantMinima().Text.ToString());
                (producto as Producto).Marca = _vista.GetMarca().SelectedValue.ToString();
                (producto as Producto).Calidad = _vista.GetCalidad().SelectedValue.ToString();
                (producto as Producto).Precio = Convert.ToDecimal(_vista.GetPrecio().Text.ToString());
                (producto as Producto).Inconvenientes = _vista.GetInconveniente().Text.ToString();
                //(producto as Producto).Proveedor = (proveedor as Proveedor);

                bool respuesta = FabricaComando.CrearComandoAgregarProducto(producto).Ejecutar();
                respuesta = AgregarDetalleProducto(producto);                                       
                return respuesta;

            }
            catch (Exception) { _vista.SetFalla("Error al agregar el producto"); return false; }
        }

        public Boolean AgregarDetalleProducto(Entidad producto)
        {
            try
            {
                bool respuesta = FabricaComando.CrearComandoAgregarDetalleProducto(producto).Ejecutar();

                return respuesta;

            }
            catch (Exception) { _vista.SetFalla("Error al agregar el producto"); return false; }
        }
    }
}
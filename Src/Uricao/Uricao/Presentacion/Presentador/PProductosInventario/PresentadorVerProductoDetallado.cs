using System;
using System.Collections.Generic;
using Uricao.Presentacion.Contrato.CProductosInventario;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EProveedores;

namespace Uricao.Presentacion.Presentador.PProductosInventario
{
    public class PresentadorVerProductoDetallado
    {
        private IContratoVerProductoDetallado _vista;

        public PresentadorVerProductoDetallado(IContratoVerProductoDetallado laVista)
        {
            this._vista = laVista;
        }

        public void OnLoad()
        {
            _vista.SetDropDownListCategoria(LlenarCategorias());
            _vista.SetDropDownListTipo(LlenarTipo());
            _vista.SetDropDownListProveedor(LlenarProveedores());
            _vista.SetDropDownListCalidad(LlenarCalidad());
        }

        public bool EditarProducto(Entidad producto)
        {
            bool respuesta;
            try
            {
                respuesta = FabricaComando.CrearComandoEditarProducto(producto).Ejecutar();
            }
            catch (Exception e)
            {
                _vista.SetFalla(e.Message);
                respuesta = false;
            }
            return respuesta;
        }

        public DropDownList LlenarCategorias()
        {
            DropDownList combo = new DropDownList();
            try
            {
                List<String> listaCategorias = FabricaComando.CrearComandoConsultarCategoria().Ejecutar();
                for (int i = 0; i < listaCategorias.Count; i++)
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

        public DropDownList LlenarTipo()
        {
            DropDownList combo = new DropDownList();
            combo.Items.Clear();
            combo.Items.Add("Producto Medico");
            combo.Items.Add("Equipo Medico");
            return combo;
        }

        public DropDownList LlenarCalidad()
        {
            DropDownList combo = new DropDownList();
            combo.Items.Clear();
            combo.Items.Add("Alta");
            combo.Items.Add("Media");
            combo.Items.Add("Baja");

            return combo;
        }

    }
}
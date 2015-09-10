using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CProductosInventario;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Fabricas;
using System.Data;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Excepciones.ExcepcionesProductos;

namespace Uricao.Presentacion.Presentador.PProductosInventario
{
    public class PresentadorVerProducto 
    {
        private IContratoVerProducto _vista;

        public PresentadorVerProducto(IContratoVerProducto lavista)
        {
            this._vista = lavista;
        }

        public void OnLoad()
        {
            _vista.SetCategoria(LlenarCategorias());
            _vista.SetTipo(LlenarTipo());
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

        public DropDownList LlenarTipo()
        {
            DropDownList combo = new DropDownList();

            combo.Items.Clear();
            combo.Items.Add("Producto Medico");
            combo.Items.Add("Equipo Medico");

            return combo;
        }

        public void CrearTabla(DataTable table, List<String> columnas)
        {
            foreach (String columna in columnas)
                table.Columns.Add(columna, typeof(String));
        }

        public List<Entidad> ObtenerProductosDetallados(Entidad producto)
        {
            List<Entidad> listaproducto = new List<Entidad>();
            listaproducto = FabricaComando.CrearComandoObtenerProductosDetallados(producto).Ejecutar();
            return listaproducto;
        }

        public int SeleccionGrid(GridView GridConsultar)
        {
            int seleccion = GridConsultar.SelectedIndex;
            if (GridConsultar.PageIndex != 0)
            {
                int pagina = GridConsultar.PageIndex;
                GridConsultar.PageIndex = 0;
                int filas = 8;
                seleccion = filas * pagina + seleccion;
            }
            return seleccion;
        }

        public bool EditarProductoGenerico(Entidad producto, String nombreViejo)
        {
            bool respuesta;
            try
            {
                respuesta = FabricaComando.CrearComandoEditarProductoGenerico(producto, nombreViejo).Ejecutar();
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
    }
}
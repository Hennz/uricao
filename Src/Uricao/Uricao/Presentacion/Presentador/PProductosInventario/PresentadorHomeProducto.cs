using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CProductosInventario;
using System.Data;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Presentador.PProductosInventario
{
    public class PresentadorHomeProducto
    {
        IContratoHomeProducto _vista;

        public PresentadorHomeProducto(IContratoHomeProducto lavista)
        {
            this._vista = lavista;
        }

        public DataTable CrearTabla(DataTable table, List<String> columnas)
        {
            try
            {
                foreach (String columna in columnas)
                    table.Columns.Add(columna, typeof(String));
            }
            catch (Exception e)
            {
                _vista.SetFalla(e.Message);
                
            }
            return table;
        }

        public List<Entidad> ObtenerProductos()
        {
            List<Entidad> listaProducto = new List<Entidad>();
            try
            {
                listaProducto = FabricaComando.CrearComandoObtenerProductos().Ejecutar();
            }
            catch (Exception e) { _vista.SetFalla(e.Message); }

            return listaProducto;
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

    }
}
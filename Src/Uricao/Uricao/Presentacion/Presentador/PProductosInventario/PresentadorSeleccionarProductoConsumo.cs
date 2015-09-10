using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CProductosInventario;
using System.Data;

namespace Uricao.Presentacion.Presentador.PProductosInventario
{
    public class PresentadorSeleccionarProductoConsumo
    {
        private ISeleccionarProductoConsumo _vista;

        public PresentadorSeleccionarProductoConsumo(ISeleccionarProductoConsumo laVista)
        {
            this._vista = laVista;
        }

        public DataTable cargarTabla()
        {
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Tipo", typeof(string));
                table.Columns.Add("Categoría", typeof(string));

                table.Rows.Add("Guantes de látex", "Equipo Médico", "Guantes");
                table.Rows.Add("Guantes quirúrgicos", "Equipo Médico", "Guantes");
            }
            catch (Exception e)
            {
                _vista.SetFalla(e.Message);
                table = null;
            }
                return table;
        }

    }
}
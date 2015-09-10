using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Uricao.Presentacion.PaginasWeb.PProductosInventario
{
    public partial class VerDetalleInventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTablaLotes();
            cargarTablaConsumos();
        }
        protected void GridConsultarLotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioPagina.Text = "cambio de pagina";
            cambioPagina.Visible = true;
        }
        protected void GridConsultarLotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultarLotes.PageIndex = e.NewPageIndex;
            cargarTablaLotes();
        }
        public void cargarTablaLotes()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Marca", typeof(string));
            table.Columns.Add("Fecha Ingreso", typeof(string));
            table.Columns.Add("Fecha Vencimiento", typeof(string));
            table.Columns.Add("Cantidad", typeof(string));
            table.Columns.Add("Ubicación", typeof(string));

            table.Rows.Add("GUM","2012-10-01","2014-12-21","50","A-23");
            table.Rows.Add("DentMart","2012-11-11", "2020-10-01", "30", "M-2");

            GridConsultarLotes.DataSource = table;
            GridConsultarLotes.DataBind();
        }

        protected void GridConsultarConsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioPagina.Text = "cambio de pagina";
            cambioPagina.Visible = true;
        }
        protected void GridConsultarConsumos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultarConsumos.PageIndex = e.NewPageIndex;
            cargarTablaConsumos();
        }
        public void cargarTablaConsumos()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Marca", typeof(string));
            table.Columns.Add("Fecha Consumo", typeof(string));
            table.Columns.Add("Cantidad", typeof(string));

            table.Rows.Add("GUM", "2012-11-18","2");
            table.Rows.Add("GUM", "2012-11-18", "4");
            table.Rows.Add("GUM", "2012-11-20", "5");

            GridConsultarConsumos.DataSource = table;
            GridConsultarConsumos.DataBind();
        }
    }
}
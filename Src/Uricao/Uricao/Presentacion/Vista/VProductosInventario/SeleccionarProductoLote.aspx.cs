using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Uricao.Presentacion.PaginasWeb.PProductosInventario
{
    public partial class SeleccionarProductoLote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }
        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
            cargarTabla();
        }
        public void cargarTabla()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Tipo", typeof(string));
            table.Columns.Add("Categoría", typeof(string));

            table.Rows.Add("Guantes de látex", "Equipo Médico", "Guantes");
            table.Rows.Add("Guantes quirúrgicos", "Equipo Médico", "Guantes");

            GridConsultar.DataSource = table;
            GridConsultar.DataBind();
        }
    }
}
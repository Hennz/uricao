using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{
    public partial class GenerarFacturaOperacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["la_Factura"] = null;
            Session["listado_agregado"] = null;

        }
    }
}
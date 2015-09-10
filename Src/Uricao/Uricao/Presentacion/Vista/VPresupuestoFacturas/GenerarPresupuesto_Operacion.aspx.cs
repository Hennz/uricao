using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{
    public partial class GenerarPresupuesto_Operacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["cedula"] = null;
            Session["tipoci"] = null;
            Session["observaciones"] = null;
            Session["listaTratamientosElegidos"] = null;
        }
    }
}
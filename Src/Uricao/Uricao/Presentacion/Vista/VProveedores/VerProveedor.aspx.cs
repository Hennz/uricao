using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.PaginasWeb.PProveedores
{
    public partial class VerProveedor1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarCampos();
        }

        void llenarCampos()
        {
            if (Session["P.nombre"] != null)
                TextBoxNombre.Text = Session["P.nombre"].ToString();
            if (Session["P.rif"] != null)
                TextBoxRif.Text = Session["P.rif"].ToString();
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            Session["estado"] = "EntradoEdicion";
            Response.Redirect("EditarProveedor.aspx");
        }

        protected void contactoButton_Click(object sender, EventArgs e)
        {
            Session["Posicion"] = "0";
            Response.Redirect("VerContacto.aspx");
        }
    }
}
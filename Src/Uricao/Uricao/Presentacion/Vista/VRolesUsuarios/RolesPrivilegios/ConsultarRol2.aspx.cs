using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;

namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios
{
    public partial class ConsultarRol2 : System.Web.UI.Page
    {
        //List<Rol> miLista = new List<Rol>();
        Rol miRol = new Rol();

        #region propiedades

        public TextBox ITextBoxIdRol
        {
            get { return TextIdRol; }
            set { TextIdRol = value; }

        }
        public TextBox ITextBoxNombreRol
        {
            get { return TextNombreRol; }
            set { TextNombreRol = value; }

        }
        public TextBox ITextBoxDescripRol
        {
            get { return TextDescipRol; }
            set { TextDescipRol = value; }

        }
        #endregion propiedades


        protected void Page_Load(object sender, EventArgs e)
        {
            miRol = (Rol)Session["objRol"];

            TextIdRol.Text = miRol.IdRol.ToString();
            TextNombreRol.Text = miRol.NombreRol;
            TextDescipRol.Text = miRol.Descripcion;

        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarRol.aspx");
        }
        
    }
}
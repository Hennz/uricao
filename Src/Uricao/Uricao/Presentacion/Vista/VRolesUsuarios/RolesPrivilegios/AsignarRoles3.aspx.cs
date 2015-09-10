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
    public partial class AsignarRoles3 : System.Web.UI.Page
    {
        Usuario miUsu = new Usuario();
        Rol miRol = new Rol();
        Boolean resultado = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            miUsu = (Usuario)Session["SesionUsuario"];
            miRol = (Rol)Session["sesionRol"];

            NombreRol.Text = miRol.NombreRol;
            DescripcionRol.Text = miRol.Descripcion;

            NombreUsu.Text = miUsu.PrimerNombre + miUsu.SegundoNombre;
            Apellidousu.Text = miUsu.PrimerApellido + miUsu.SegundoApellido;
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            resultado = new LogicaRol().AsignarRol(miUsu,miRol);
        }
    }
}
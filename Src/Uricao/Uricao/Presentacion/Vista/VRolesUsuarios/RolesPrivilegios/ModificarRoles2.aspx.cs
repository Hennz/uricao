using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios
{
    public partial class ModificarRoles2 : System.Web.UI.Page
    {
        //Rol miRol = new Rol();
        Entidad miRol = FabricaEntidad.NuevoRol();
        //LogicaRol logicaRol = new LogicaRol();
        DAORol ConsultaBD = new DAORol();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                miRol = (Rol)Session["objRol"];

                TextId.Text = (miRol as Rol).IdRol.ToString();
                TextNombre.Text = (miRol as Rol).NombreRol;
                TextDescrip.Text = (miRol as Rol).Descripcion;
            }

        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            //Rol modifRol = new Rol();
            bool modificar;

            (miRol as Rol).IdRol = int.Parse(TextId.Text);
            (miRol as Rol).NombreRol = TextNombre.Text;
            (miRol as Rol).Descripcion = TextDescrip.Text;

            modificar = ConsultaBD.ModificarRoles(miRol);


            if (modificar)
            {
                Exito.Visible = true;
            }
            else
            {
                falla.Visible = true;
            }
        }
    }
}
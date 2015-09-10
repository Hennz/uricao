using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios
{
    public partial class AgregarRol : System.Web.UI.Page
    {
        Entidad _nuevoRol = FabricaEntidad.NuevoRol();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            Rol nuevoRol = new Rol();
            bool agregar;
           // LogicaRol logicaRol = new LogicaRol();
            DAORol daorol = new DAORol();

            nuevoRol.NombreRol = nombreRol.Text;
            nuevoRol.Descripcion = DescripcionRol.Text;
            nuevoRol.Estado = true;

            agregar= daorol.AgregarRol(nuevoRol);

            if (nuevoRol != null)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios
{
    public partial class AgregarUsuario2 : System.Web.UI.Page
    {
        Entidad _usuario = FabricaEntidad.NuevaUsuario();
        public void llenarRoles()
        {
            Entidad _rol = FabricaEntidad.NuevoRol();
            ComboRolAgr.DataSource = (_rol as Rol).EnlistaRoles();
            ComboRolAgr.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarRoles();
            }

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            (_usuario as Usuario).PrimerNombre = Nombre1AgrTextBox.Text;
            (_usuario as Usuario).PrimerApellido = Apellido1AgrTextBox.Text;
            //(_usuario as Usuario).Identificacion = Ci1AgrTextBox.Text;
            //(_usuario as Usuario).FechaNace = fecha
            (_usuario as Usuario).Sexo = DropDownListSexoAgr.SelectedItem.Text;
            (_usuario as Usuario).FechaRegistro = DateTime.Now;
            /*(_usuario as Usuario).Pais = PaisDropDownList.SelectedItem.Text;
            (_usuario as Usuario).Estado = EstadoDropDownList.SelectedItem.Text;
            (_usuario as Usuario).Ciudad = CiudadDropDownList.SelectedItem.Text;
            (_usuario as Usuario).Municipio = Municipio.Text;
            (_usuario as Usuario).Calle = Calle.Text;
            (_usuario as Usuario).Edificio = EdifAgrTextBox.Text;
            (_usuario as Usuario).Telefono = TelfAgrTextBox.Text;
            (_usuario as Usuario).Correo = CorreoAgrTextBox.Text;*/
        }
    }
}
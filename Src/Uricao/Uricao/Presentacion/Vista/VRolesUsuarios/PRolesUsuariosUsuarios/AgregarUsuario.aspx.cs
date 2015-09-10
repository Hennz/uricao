using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.AccesoDeDatos.DAOS;

namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        Entidad _usuario = FabricaEntidad.NuevaUsuario();
        DAOUsuario logicaUsuario = new DAOUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //llenarDropDownDireccion();
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            (_usuario as Usuario).Login = NombreUsuarioTextBox.Text;
            (_usuario as Usuario).Password = PasswordTextBox.Text;
            (_usuario as Usuario).PrimerNombre = NombreAgrTextBox.Text;
            (_usuario as Usuario).PrimerApellido = ApellidoAgrTextBox.Text;
            if (VenezolanoRadioButton.Checked)
                (_usuario as Usuario).TipoIdentificacion = VenezolanoRadioButton.Text;
            else if (ExtranjeroRadioButton.Checked)
                (_usuario as Usuario).TipoIdentificacion = ExtranjeroRadioButton.Text;
            (_usuario as Usuario).Identificacion = CiAgrTextBox.Text;
            //(_usuario as Usuario).FechaNace = fecha
            (_usuario as Usuario).Sexo = DropDownListSexoAgr.SelectedItem.Text;
            //(_usuario as Usuario).FechaRegistro =
            (_usuario as Usuario).Direccion.Pais = PaisDropDownList.SelectedItem.Text;
            //(_usuario as Usuario).Direccion.Estado = EstadoDropDownList.SelectedItem.Text;
            //(_usuario as Usuario).Direccion.Ciudad = CiudadDropDownList.SelectedItem.Text;
            (_usuario as Usuario).Direccion.Municipio = Municipio.Text;
            (_usuario as Usuario).Direccion.Calle = Calle.Text;
            //if (EdifCasaDropDownList.SelectedItem.Text.Contains("Edificion"))
            (_usuario as Usuario).Direccion.Edificio = EdifAgrTextBox.Text;
            /*else if (EdifCasaDropDownList.SelectedItem.Text.Contains("Casa"))
                miDireccion.*/
                //(_usuario as Usuario).Telefono =
            (_usuario as Usuario).Correo = CorreoAgrTextBox.Text;
            //(_usuario as Usuario).Codigo = CodigoTelfTextBox.Text;
            (_usuario as Usuario).Telefono.Add(TelfAgrTextBox.Text);
            //(_usuario as Usuario).Tipo = "Local";*/
           

            logicaUsuario.AgregarUsuario((_usuario as Usuario));

            ExitoAgregar.Visible = true;
        }


        #region Llenar DropDownList Direccion
        protected void llenarDropDownDireccion()
        {
            /*LogicaUsuario miPais  = new LogicaUsuario();
            LogicaUsuario miEstado = new LogicaUsuario();
            LogicaUsuario miCiudad = new LogicaUsuario();*/

            DAODireccion miPais = new DAODireccion();
            DAODireccion miEstado = new DAODireccion();
            DAODireccion miCiudad = new DAODireccion();

            PaisDropDownList.DataSource = miPais.ListaPaises();
            PaisDropDownList.DataBind();

            EstadoDropDownList.DataSource = miEstado.ListaEstado(PaisDropDownList.SelectedItem.Text.ToString());
            EstadoDropDownList.DataBind();

            CiudadDropDownList.DataSource = miCiudad.ListaCiudades(EstadoDropDownList.SelectedItem.Text.ToString());
            CiudadDropDownList.DataBind();
        }
        #endregion Llenar DropDownList Direccion
    }
}
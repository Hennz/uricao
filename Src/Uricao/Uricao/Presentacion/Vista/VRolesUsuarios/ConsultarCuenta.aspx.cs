using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.Entidades.ERolesUsuarios;

namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios
{
    public partial class ConsultarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogicaUsuario Logica = new LogicaUsuario();
                Usuario usu = new Usuario();
                string espacio = " ", slash = "/";
                usu = (Usuario)Session["SesionUsuario"];
                this.Nombres.Text = usu.PrimerNombre += espacio += usu.SegundoNombre;
                this.Apellidos.Text = usu.PrimerApellido += espacio += usu.SegundoApellido;
                this.Identificacion.Text = usu.TipoIdentificacion.Trim() + usu.Identificacion.Trim();
                this.UsuarioT.Text = usu.Login;
                this.FechaNac.Text = usu.FechaNace.ToShortDateString();
                this.FechaIngreso.Text = usu.FechaRegistro.ToShortDateString();
                this.Sexo.Text = usu.Sexo;
                this.Rol.Text = usu.Rol.NombreRol;
                this.Correo.Text = usu.Correo;
                this.Direccion.Text = usu.Direccion.Edificio.Trim() + espacio +
                                      usu.Direccion.Calle.Trim() + espacio +
                                      usu.Direccion.Municipio.Trim() + espacio;
                this.Direccion0.Text = usu.Direccion.Estado.Trim() + espacio +
                                      usu.Direccion.Ciudad.Trim() + espacio +
                                      usu.Direccion.Pais.Trim();
                if (usu.Estatus == false)
                {
                    this.Estado.Text = "Activo";
                }
                else
                {
                    this.Estado.Text = "Desactivado";
                }
                if (usu.Telefono != null)
                {
                    foreach (string tlf in usu.Telefono)
                    {
                        this.Telefonos.Text = this.Telefonos.Text.Trim() + slash + tlf.Trim();
                    }
                }
                //thisFoto


            }
        }
    }
}
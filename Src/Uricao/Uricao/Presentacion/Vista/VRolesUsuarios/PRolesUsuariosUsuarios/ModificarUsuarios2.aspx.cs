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
    public partial class ModificarUsuarios2 : System.Web.UI.Page
    {
      private LogicaUsuario Logica = new LogicaUsuario();
       private Usuario usu = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                usu = (Usuario)Session["SesionUsuario"];
                this.Pais.DataSource = Logica.llenarComboPais();
                this.Pais.DataBind();
                string espacio = " ", slash = "/";
                //usu = Logica.DatosUsuarioInterfaz("Gustavo01");
                this.Nombre1.Text = usu.PrimerNombre;
                this.Nombre2.Text= usu.SegundoNombre;
                this.Apellido1.Text = usu.PrimerApellido;
                this.Apellido2.Text= usu.SegundoApellido;
                this.Correoo.Text = usu.Correo;
                this.Userr.Text = usu.Login;
                this.Municipio.Text = usu.Direccion.Municipio;
                this.Calle.Text = usu.Direccion.Calle;
                this.Edificio.Text = usu.Direccion.Edificio;
                
                this.Identificacon.Text = usu.Identificacion;
                
                CargarSexo(usu.Sexo);
                
                this.Rol.Text = usu.Rol.NombreRol;
                this.Correoo.Text = usu.Correo;
                /*this.Direccion.Text = usu.Direccion.Edificio.Trim() + espacio +
                                      usu.Direccion.Calle.Trim() + espacio +
                                      usu.Direccion.Municipio.Trim() + espacio;
                this.Direccion0.Text = usu.Direccion.Estado.Trim() + espacio +
                                      usu.Direccion.Ciudad.Trim() + espacio +
                                      usu.Direccion.Pais.Trim();*/
                if (usu.Estatus == false)
                {
                    this.status.Text = "Activo";
                }
                else
                {
                    this.status.Text = "Desactivado";
                }
                if (usu.Telefono != null)
                {
                    foreach (string tlf in usu.Telefono)
                    {
                        this.Telefono.Text = this.Telefono.Text.Trim() + slash + tlf.Trim();
                    }
                }
               
            }

        }
        protected void CargarSexo(string sex)
        {
            if ("masculino".Contains(sex.ToLower()))
            {
                this.Sexo.Items.Add("Masculino");
                this.Sexo.Items.Add("Femenino");
                this.Sexo.DataBind();
            }
            else
            {
                this.Sexo.Items.Add("Femenino");
                this.Sexo.Items.Add("Masculino");
                this.Sexo.DataBind();
            }

        }

        protected void Pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Estado.DataSource = Logica.llenarComboEstado(this.Pais.SelectedItem.ToString().Trim());
            this.Estado.Visible = true;

        }

        protected void Ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Ciudad.DataSource = Logica.llenarComboCiudad(this.Estado.SelectedItem.ToString().Trim());
            this.Ciudad.Visible = true;

        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            usu.PrimerNombre=this.Nombre1.Text ;
            usu.SegundoNombre=this.Nombre2.Text;
            usu.PrimerApellido=this.Apellido1.Text;
            usu.SegundoApellido=this.Apellido2.Text;
            usu.Correo=this.Correoo.Text;
             usu.Login= this.Userr.Text;
            usu.Direccion.Municipio=this.Municipio.Text;
            usu.Direccion.Calle= this.Calle.Text;
           usu.Direccion.Edificio= this.Edificio.Text;

            usu.Identificacion=this.Identificacon.Text;

            usu.Sexo = this.Sexo.SelectedItem.ToString();
            usu.Rol.NombreRol = this.Rol.SelectedItem.ToString();
            usu.Correo=this.Correoo.Text;

            usu.Direccion.Pais = this.Pais.SelectedItem.ToString();
            usu.Direccion.Estado = this.Estado.SelectedItem.ToString();
            usu.Direccion.Ciudad = this.Ciudad.SelectedItem.ToString();

            Logica.ModificarUsuario(usu);
            
        }

        
    }
}
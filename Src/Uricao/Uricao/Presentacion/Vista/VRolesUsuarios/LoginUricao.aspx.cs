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

        public partial class LoginUricao : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {

            }
            private string pass, usu, p1, p2;
            protected void onClickLoginButton(object sender, EventArgs e)
            {

                usu = nombre.Text.ToString();
                pass = Clave.Value.ToString();
                LogicaUsuario acceso = new LogicaUsuario();
                Usuario variableUs = new Usuario();
                variableUs = acceso.ValidarLoggin(usu, pass);
                p1 = variableUs.Login;
                p2 = variableUs.Password;
                if (p1 != null)
                {
                    if (p2 != null)
                    {
                        bool verdad = p1.Contains(usu);

                        if (verdad == p2.Contains(pass))
                        {
                            //redirect the user UricaoHome
                            Session["SesionUsuario"] = variableUs;
                            Response.Redirect("../Home/UricaoHome.aspx");
                        }
                        else
                        {
                            falla.Text = "Usuario o Contraseña Incorrecto";
                        }
                    }
                    else
                    {
                        falla.Text = "Usuario o Contraseña Incorrecto";
                    }
                }
                else
                {
                    falla.Text = "Usuario o Contraseña Incorrecto";
                }
            }



            protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
            {

            }
        }
    
}
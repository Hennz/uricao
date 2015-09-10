using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Presentacion.Contrato.CProveedores;
using Uricao.Presentacion.Presentador.PProveedores;

namespace Uricao.Presentacion.PaginasWeb.PProveedores
{
    public partial class AgregarContacto : System.Web.UI.Page, IContratoAgregarContacto
    {

        Entidad contacto = FabricaEntidad.NuevoContacto();
        PresentadorAgregarContacto _presentador;

        public AgregarContacto()
        {
            _presentador = new PresentadorAgregarContacto(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdProveedor"]==null)
            {
                falla.Text = "Error: no se encuentra el proveedor asociado";
                falla.Visible = true;
                Exito.Visible = false;
            }
            else if (Session["Contacto"].Equals("nuevo"))
            {
                Exito.Text = "Agregando contacto en " + Session["nombreProveedor"].ToString();
                Exito.Visible = true;
                falla.Visible = false;
            }
            else if (Session["Contacto"].Equals("Agregado"))
            {
                Exito.Text = "Contacto de " + Session["nombreProveedor"] + " Agregado con exito";
                Exito.Visible = true;
                falla.Visible = false;
            }
            else if (Session["Contacto"].Equals("noAgregado"))
            {
                falla.Text = "El contacto no se pudo agregar";
                falla.Visible = true;
                Exito.Visible = false;
            }
        }

        

        protected void llenarContacto()
        {
            (contacto as Contacto).Apellido = TextBoxApellido.Text;
            (contacto as Contacto).Nombre = TextBoxNombre.Text;
            (contacto as Contacto).Correo = TextBoxEmail.Text;
        }

        void consultarContacto()
        {
            //LogicaProveedor logicaProveedores = new LogicaProveedor();

            Entidad contactoAgregado = _presentador.consultarContacto(contacto, Convert.ToInt16(Session["IdProveedor"].ToString()));
            if ( (contactoAgregado as Contacto).Apellido !=null &&
            (contactoAgregado as Contacto).Nombre != null &&
            (contactoAgregado as Contacto).Correo != null)
            {
                Session["Contacto"] = "Agregado";
                Response.Redirect("HomeProveedores.aspx");
                
            }
            else
            {
                Session["Contacto"] = "noAgregado";
                Response.Redirect("AgregarContacto.aspx");
            }
        }

        protected void otroButton_Click(object sender, EventArgs e)
        {
            llenarContacto();
            //LogicaProveedor logicaProveedores = new LogicaProveedor();
            //logicaProveedores.agregarContacto(contacto, Convert.ToInt32(Session["IdProveedor"]));
            _presentador.AgregarContacto(Convert.ToInt16(Session["IdProveedor"].ToString()));
            consultarContacto();
        }

        public TextBox apellido() {return TextBoxApellido;}
        public TextBox nombre(){return TextBoxNombre;}
        public TextBox mail() { return TextBoxEmail; }

    }
}
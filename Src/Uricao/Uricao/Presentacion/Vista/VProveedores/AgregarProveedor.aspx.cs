using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EProveedores;
//using Uricao.LogicaDeNegocios.Clases.LNProveedores;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Presentacion.Contrato.CProveedores;
using Uricao.Presentacion.Presentador.PProveedores;

namespace Uricao.Presentacion.PaginasWeb.PProveedores
{
    public partial class AgregarProveedor : System.Web.UI.Page, IContratoAgregarProveedor
    {
        Entidad proveedor = FabricaEntidad.NuevoProveedor();
        PresentadorAgregarProveedor _presentador;
        public AgregarProveedor()
        {
            _presentador = new PresentadorAgregarProveedor(this);

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Proveedor"] != null)
            if (Session["Proveedor"].Equals("noAgregado"))
            {
                falla.Text = "El Proveedor no se pudo agregar";
                falla.Visible = true;
                Exito.Visible = false;
                Session["Proveedor"] = "";
            }
            else if (Session["Proveedor"].Equals("Agregado"))
            {
                Exito.Text = "Proveedor "+Session["nombreProveedor"]+" agregado exitosamente";
                Exito.Visible = true;
                falla.Visible = false;
                Session["Proveedor"] = "";
            }
            
        }

        /*protected void defaultButton_Click(object sender, EventArgs e)
        {

            //Se validan todos los campos
            //Funciones.validarVacios();
            //Funciones.validarNumeros(con los text box);
            llenarProveedor();
            _presentador.agregarProveedor();

            consultarProveedor(false);

        }*/

        protected void llenarProveedor()
        {

            (proveedor as Proveedor).Rif = TextBoxRif.Text;
            (proveedor as Proveedor).Nombre = TextBoxNombre.Text;
            (proveedor as Proveedor).Direccion = 1;
            //proveedor.Telefono = new List<Telefono>();
            //proveedor.Contactos = new List<Contacto>();
        
        }

        protected void ButtonContacto_Click(object sender, EventArgs e)
        {
            llenarProveedor();
            _presentador.agregarProveedor();
            consultarProveedor(true);

        }

        void consultarProveedor(bool contacto)
        {
            proveedor = _presentador.ConsultarProveedor();
            if ((proveedor as Proveedor).Nombre != null && (proveedor as Proveedor).Rif != null)
            {
                Session["Proveedor"] = "Agregado";
                Exito.Text = "Proveedor " + Session["nombreProveedor"] + " agregado exitosamente";
                Exito.Visible = true;
                falla.Visible = false;
                Session["Proveedor"] = "";
                Session["nombreProveedor"] = (proveedor as Proveedor).Nombre;
                Entidad ProveedorID = FabricaEntidad.NuevoProveedor();
                ProveedorID =_presentador.ConsultarIdProveedor();
                Session["IdProveedor"] = (ProveedorID as Proveedor).Id.ToString();
                //System.Diagnostics.Debug.WriteLine("session id proveedor["+Session["IdProveedor"]+"]\n");
                Session["Contacto"] = "nuevo";
                if(contacto) Response.Redirect("AgregarContacto.aspx");
                //else Response.Redirect("AgregarProveedor.aspx");
            }

            else
            {
                Session["Proveedor"] = "noAgregado";
                Response.Redirect("AgregarProveedor.aspx");
            }

        }
        
        public TextBox GetRif() {return TextBoxRif; }
        public TextBox GetNombre() { return TextBoxNombre;}

    }
}
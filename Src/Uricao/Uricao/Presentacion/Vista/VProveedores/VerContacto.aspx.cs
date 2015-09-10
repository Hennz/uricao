using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Presentacion.Contrato.CProveedores;
using Uricao.Presentacion.Presentador.PProveedores;

namespace Uricao.Presentacion.PaginasWeb.PProveedores
{
    public partial class VerProveedor : System.Web.UI.Page, IContratoVerContacto
    {

        Entidad contacto;
        PresentadorVerContacto _presentador;

        public VerProveedor()
        {
            _presentador = new PresentadorVerContacto(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Posicion"] != null)
                if (Session["Posicion"].Equals("0"))
                    Session["Posicion"] = "1";
                else if (Session["Posicion"].Equals("1"))
                            Session["Posicion"] = "2";

            if (Session["P.rif"] != null)
            {
                contacto = _presentador.verContacto();
                if (contacto != null)
                    llenarCampos();
            }

        }

        protected void ButtonSiguiente_Click(object sender, EventArgs e)
        {
            //Session["Posicion"] = (Convert.ToInt16(Session["Posicion"]) + 1).ToString();
            Response.Redirect("HomeProveedores.aspx");
        }

        void llenarCampos()
        {
            TextBoxNombre.Text = (contacto as Contacto).Nombre;
            TextBoxApellido.Text = (contacto as Contacto).Apellido;
            TextBoxEmail.Text = (contacto as Contacto).Correo;

        }
        public String RifP() {return Session["P.rif"].ToString();}
        public Int16 PosicionP() { return Convert.ToInt16(Session["Posicion"]); }
    }
}
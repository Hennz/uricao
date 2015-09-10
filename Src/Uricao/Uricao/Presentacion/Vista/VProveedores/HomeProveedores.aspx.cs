using System;
using System.Data;
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
    public partial class HomeProveedores : System.Web.UI.Page, IContratoHomeProveedores

    {
        List<Entidad> proveedores;
        Entidad proveedor;
        PresentadorHomeProveedores _presentador;

        public HomeProveedores()
        {
            _presentador = new PresentadorHomeProveedores(this);
        }

        //
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Cargar.nombre"] != null)
            {
                proveedores.Add(_presentador.ObtenerProvedoresXNombre());
                Session["Cargar.nombre"] = null;
            }
            else if (Session["Cargar.rif"] != null)
            {
                proveedores.Add(_presentador.ObtenerProvedoresXRif());
                Session["Cargar.rif"] = null;
            }
            else if (Session["Cargar.todos"] != null)
            {
                proveedores = _presentador.ObtenerTodosProveedores();
                Session["Cargar.todos"] = null;
            }
              
        }
 
        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Session["P.nombre"] = (proveedores[GridConsultar.SelectedIndex] as Proveedor).Nombre;
            Session["P.rif"] = (proveedores[GridConsultar.SelectedIndex] as Proveedor).Rif;
            Response.Redirect("VerProveedor.aspx");

        }
 
        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
            cargarTablaCompleta();
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            if ((TextBoxNombre.Text.Equals("")) && (TextBoxRif.Text.Equals("")))
                cargarTablaCompleta();
            else if ((!TextBoxNombre.Text.Equals("")) && (TextBoxRif.Text.Equals("")))
                cargarTablaPorNombreCompleta();
            else if ((TextBoxNombre.Text.Equals("")) && (!TextBoxRif.Text.Equals("")))
                cargarTablaPorRifCompleto();

        }
        //

        //si
        public void cargarTablaCompleta()
        {

            GridConsultar.DataSource = _presentador.cargarTabla();
            GridConsultar.DataBind();

            Session["Cargar.todos"] = "true";
        }

        //si
        public void cargarTablaPorNombreCompleta()
        {
                GridConsultar.DataSource = _presentador.cargarTablaPorNombre();
                GridConsultar.DataBind();

                Session["Cargar.nombre"] = TextBoxNombre.Text.ToString();
        }
        //si
        public void cargarTablaPorRifCompleto()
        {
                    GridConsultar.DataSource = _presentador.cargarTablaPorRif();
                    GridConsultar.DataBind();

                    Session["Cargar.rif"] = TextBoxRif.Text.ToString();

        }

        public void borrarTabla()
        {
            DataTable table = new DataTable();
            GridConsultar.DataSource = table;
            GridConsultar.DataBind();
        }

        public TextBox GetNombre() { return TextBoxNombre; }
        public TextBox GetTextBoxRif() { return TextBoxRif; }
        public String NombreP() { return Session["Cargar.nombre"].ToString(); }
        public String RifP() {return Session["Cargar.rif"].ToString();}
    }
}
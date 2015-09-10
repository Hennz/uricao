using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.Entidades.EEntidad;

namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private int seleccionCombo;
        private List<Entidad> ListaUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Exito.Visible = false;
                falla.Visible = false;
                //llenarCOmbo();
            }
            else
            {
                CargarGridView();
                GridConsultar.DataSource = null;
            }
        }

        //protected void llenarCOmbo()
        //{
        //    seleccionCombo.Items.Add("Todo");
        //    seleccionCombo.Items.Add("Nombre");
        //    seleccionCombo.Items.Add("Apellido");
        //    seleccionCombo.Items.Add("Cédula");
        //    seleccionCombo.Items.Add("Rol");
        //    seleccionCombo.Items.Add("Usuario");
        //    seleccionCombo.DataBind();
        //}

        protected void LlenarDataGridTodo()
        {
            LogicaUsuario claseLogica = new LogicaUsuario();
            ListaUsuario = claseLogica.ConsultarUsuarioTodo();
            GridConsultar.DataSource = ListaUsuario;
            //  Exito.Text = claseLogica.ConsultarUsuarioTodo()[1].PrimerNombre;
            GridConsultar.DataBind();

        }

        protected void LlenarDataGridTipo(string parametro, int seleccion)
        {
            LogicaUsuario claseLogica = new LogicaUsuario();
            //ListaUsuario = claseLogica.ConsultaUsuarioTipo(parametro, seleccion);
            GridConsultar.DataSource = ListaUsuario;
            GridConsultar.DataBind();
            // falla.Text = claseLogica.ConsultarUsuarioTodo()[1].PrimerNombre;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionCombo = ComboOpcion.SelectedIndex;

        }

        protected void CargarGridView()
        {
            // Exito.Text = TextBox1.Text.ToString();
            switch (seleccionCombo)
            {
                case 0:
                    LlenarDataGridTodo();
                    GridConsultar.Visible = true;
                    break;
                case 1:
                    LlenarDataGridTipo(TextBox2.Text.ToString(), 1);
                    GridConsultar.Visible = true;
                    break;
                case 2:
                    LlenarDataGridTipo(TextBox2.Text.ToString(), 2);
                    GridConsultar.Visible = true;
                    break;
                case 3:
                    LlenarDataGridTipo(TextBox2.Text.ToString(), 3);
                    GridConsultar.Visible = true;
                    break;
                case 4:
                    LlenarDataGridTipo(TextBox2.Text.ToString(), 4);
                    GridConsultar.Visible = true;
                    break;
                case 5:
                    LlenarDataGridTipo(TextBox2.Text.ToString(), 5);
                    GridConsultar.Visible = true;
                    break;

            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            CargarGridView();

        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
            CargarGridView();

        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccion = GridConsultar.SelectedIndex;
            Entidad miUsuario = ListaUsuario[seleccion];
            Session.Add("SesionUsuario", miUsuario);

            Response.Redirect("ConsultarUsuario2.aspx");
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Presentador.PRolesUsuarios;
using Uricao.Presentacion.Contrato.CRolesUsuarios;
using Uricao.AccesoDeDatos.DAOS;

namespace Uricao.Presentacion.Vista.VRolesUsuarios.PRolesUsuariosUsuarios
{
    public partial class ConsultarUsuarios : System.Web.UI.Page, IContratoConsultarUsuario
    {
        #region Atributos

        List<Entidad> ListaUsuarios;
        private PresentadorConsultarUsuario _presentador;
        private int seleccionCombo;
        private string _parametro;

        #endregion Atributos
       
        #region Constructor

        public ConsultarUsuarios()
        {
            _presentador = new PresentadorConsultarUsuario(this);
        }

        #endregion Constructor

        #region Propiedades

        public DropDownList DropListParametro
        {
            get { return DropDownList1; }
            set { DropDownList1 = value; }
        }

        public TextBox TextParametro
        {
            get { return TextBox1; }
            set { TextBox1 = value; }

        }

        public GridView GridConsultar1
        {
            get { return GridConsultar; }
            set { GridConsultar = value; }

        }

        #endregion Propiedades

        #region Métodos

        public void SetLabelFalla(String text)
        {
            falla.Text = text;
            Exito.Visible = false;
            falla.Visible = true;
        }

        public void SetLabelExito(String text)
        {
            Exito.Text = text;
            falla.Visible = false;
            Exito.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Exito.Visible = false;
                falla.Visible = false;
                llenarCOmbo();
                GridConsultar.Visible = false;
                /*ListaUsuarios = _presentador.CargarUsuarios("Todos",0);
                GridConsultar.Visible = true;
                GridConsultar.DataSource = ListaUsuarios;
                GridConsultar.DataBind();*/
            }
            /*else
            {
                CargarGridView();
                GridConsultar.DataSource = null;
            }*/
        }

        #endregion Metodos

        protected void llenarCOmbo()
        {
            DropDownList1.Items.Add("Todo");
            DropDownList1.Items.Add("Nombre");
            DropDownList1.Items.Add("Apellido");
            DropDownList1.Items.Add("Cédula");
            DropDownList1.Items.Add("Rol");
            DropDownList1.Items.Add("Usuario");
            DropDownList1.DataBind();
        }

       /* protected void LlenarDataGridTodo()
        {
            LogicaUsuario claseLogica = new LogicaUsuario();
            ListaUsuario = claseLogica.ConsultarUsuarioTodo();

            GridConsultar.DataSource = ListaUsuario; //_presentador.ConsultarUsuario();
          //  Exito.Text = claseLogica.ConsultarUsuarioTodo()[1].PrimerNombre;
            GridConsultar.DataBind();
            
        }

        protected void LlenarDataGridTipo(string parametro, int seleccion)
        {
            LogicaUsuario claseLogica = new LogicaUsuario();
            ListaUsuario = claseLogica.ConsultaUsuarioTipo(parametro, seleccion);
            GridConsultar.DataSource = ListaUsuario;
            GridConsultar.DataBind();
           // falla.Text = claseLogica.ConsultarUsuarioTodo()[1].PrimerNombre;

        }*/

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionCombo = DropDownList1.SelectedIndex;
            _parametro = DropDownList1.SelectedValue;
        }

       /* protected void CargarGridView()
        {
          // Exito.Text = TextBox1.Text.ToString();
            switch (DropDownList1.SelectedIndex)
            {
                case 0:
                    LlenarDataGridTodo();
                    GridConsultar.Visible = true;
                    break;
                case 1:
                    LlenarDataGridTipo(TextBox1.Text.ToString(), 1);
                    GridConsultar.Visible = true;
                    break;
                case 2:
                    LlenarDataGridTipo(TextBox1.Text.ToString(), 2);
                    GridConsultar.Visible = true;
                    break;
                case 3:
                    LlenarDataGridTipo(TextBox1.Text.ToString(), 3);
                    GridConsultar.Visible = true;
                    break;
                case 4:
                    LlenarDataGridTipo(TextBox1.Text.ToString(), 4);
                    GridConsultar.Visible = true;
                    break;
                case 5:
                    LlenarDataGridTipo(TextBox1.Text.ToString(), 5);
                    GridConsultar.Visible = true;
                    break;

            }
        }*/

        protected void Buscar_Click(object sender, EventArgs e)
        {
            if (seleccionCombo == 0)
            {
                ListaUsuarios = _presentador.CargarUsuarios(_parametro, seleccionCombo);
                GridConsultar.Visible = true;
                GridConsultar.DataSource = ListaUsuarios;
                GridConsultar.DataBind();
            }
            else
            {
                ListaUsuarios = _presentador.CargarUsuarios(_parametro, seleccionCombo);
                GridConsultar.Visible = true;
                GridConsultar.DataSource = ListaUsuarios;
                GridConsultar.DataBind();
            }
            
        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           GridConsultar.PageIndex = e.NewPageIndex;
           ListaUsuarios = _presentador.CargarUsuarios(_parametro, seleccionCombo);
           GridConsultar.Visible = true;
           GridConsultar.DataSource = ListaUsuarios;
           GridConsultar.DataBind();
        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccion = GridConsultar.SelectedIndex;
            Entidad miUsuario = ListaUsuarios[seleccion];
            Session.Add("SesionUsuario", (miUsuario as Usuario));

            Response.Redirect("ConsultarUsuario2.aspx");
        }

    }
}
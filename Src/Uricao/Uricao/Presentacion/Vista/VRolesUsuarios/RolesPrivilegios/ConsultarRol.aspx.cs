using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Contrato.CRolesUsuarios;
using Uricao.Presentacion.Presentador.PRolesUsuarios;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.DAOS;

namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios
{
    public partial class ConsultarRol : System.Web.UI.Page, IContratoConsultarRol
    {
        #region Atributos
        List<Entidad> miLista = new List<Entidad>();
        private PresentadorConsultarRol _presentador;
        DAORol ConsultaBD = new DAORol();
        #endregion Atributos

        #region Constructor
        public ConsultarRol()
        {
            _presentador = new PresentadorConsultarRol(this);
        }
        #endregion Constructor

        #region Propiedades
        
        public GridView IGridView
        {
            get { return GridConsultar; }
            set { GridConsultar = value; }

        }

        public DropDownList IDropDownList
        {
            get { return ComboOpcion; }
            set { ComboOpcion = value; }

        }

        public TextBox ITextBox
        {
            get { return textOpcion; }
            set { textOpcion = value; }

        }

        public void IFalla(String text)
        {
            falla.Text = text;
            falla.Visible = true;
        }

        public void IExito(String text)
        {
            Exito.Text = text;
        }
        #endregion Propiedades


        #region Metodos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LogicaRol logica = new LogicaRol();
                int opcion = IDropDownList.SelectedIndex;


                switch (opcion)
                {
                    case 0:
                        miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", true, opcion);
                        break;
                    case 1:
                        miLista = ConsultaBD.ConsultarRolParametrizado(int.Parse(ITextBox.Text), "", "", true, opcion);
                        break;
                    case 2:
                        miLista = ConsultaBD.ConsultarRolParametrizado(0, ITextBox.Text, "", true, opcion);
                        break;
                    case 3:
                        miLista = ConsultaBD.ConsultarRolParametrizado(0, "", ITextBox.Text, true, opcion);
                        break;
                    case 4:
                        if (ITextBox.Text.ToUpper().Equals("ACTIVO"))
                        {
                            miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", true, opcion);
                        }
                        else
                        {
                            if (ITextBox.Text.ToUpper().Equals("INACTIVO"))
                            {
                                miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", false, opcion);
                            }else
                                miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", false, opcion);
                         }
                        break;
                }
            }
        }


        protected void defaultButton_Click(object sender, EventArgs e)
        {
             _presentador.CargarGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            IGridView.PageIndex = e.NewPageIndex;
            _presentador.CargarGridView();
        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {

        try
        {

            int seleccion = IGridView.SelectedIndex;
            miLista = _presentador.CargarGridView();
            Entidad roles = miLista[seleccion];

            Session["objRol"] = roles as Rol;
            Response.Redirect("ConsultarRol2.aspx");   

            //(miRol as Rol).IdRol= GridConsultar.SelectedIndex;
            //Session["idRol"] = miRol;  
            

        }
         catch (ArgumentOutOfRangeException)
         {
             IFalla("Error de Sistema");
             IGridView.Visible = false;
         }
     }
        #endregion Metodos
    }
}
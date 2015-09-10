using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Presentador.PTratamientos;
using Uricao.Presentacion.Contrato.CTratamientos;
using Uricao.Entidades.EEntidad;


namespace Uricao.Presentacion.PaginasWeb.PTratamientos
{
    public partial class EliminarTratamiento : System.Web.UI.Page, IContratoEliminarTratamiento
    {
        #region Atributos

        private PresentadorEliminarTratamiento _presentador;

        #endregion Atributos


        #region Constructor

        public EliminarTratamiento()
        {
            _presentador = new PresentadorEliminarTratamiento(this);
        }

        #endregion Constructor

        #region Propiedades

        public TextBox CampoBusqueda
        {
            get { return Busqueda; }
            set { Busqueda = value; }
        }

        public RadioButtonList Parametro
        {
            get { return RadioButtonList1; }
        }


        public void SetLabelFalla(String text)
        {
            error.Text = text;
            error.Visible = true;
        }


        public GridView GridTratamiento
        {
            get { return GridViewTratamiento; }
            set { GridViewTratamiento = value; }

        }

 


        #endregion

        private static List<Entidad> _miLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadioButtonList1.Visible = true;
                Busqueda.Visible = true;
                Button1.Visible = true;
                //this._presentador.CargaTodos();

            }
        }



        protected void GridViewTratamiento_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Buscar")
            {

                if (this._presentador.CambiarEstadoTratamiento(Convert.ToInt32(e.CommandArgument), GridViewTratamiento.PageIndex, GridViewTratamiento.PageSize, RadioButtonList1.SelectedIndex))
                {
                    error.Text = "Operacion Realizada Exitosamente";
                    Response.Redirect("EliminarTratamiento.aspx");
                }
                else 
                {
                    Response.Redirect("EliminarTratamiento.aspx");
                    error.Text = "Operacion Fallida";
                }
                    
            }
        }

        protected void GridViewTratamiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTratamiento.PageIndex = e.NewPageIndex;
            GridViewTratamiento.DataSource = this._presentador.GetData();
            GridViewTratamiento.DataBind();
        }

        protected void gridViewTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_presentador.BuscarProyecto();
        }

        protected void DiscontinuedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //_presentador.BuscarProyecto();
        }

        protected void CambiarEstado(object sender, EventArgs e)
        {
            //_presentador.BuscarProyecto();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == -1) 
            {
                this._presentador.CargaTodos(); 
            }   //Todos
            else if (RadioButtonList1.SelectedIndex == 0) 
            {
                this._presentador.CargaId();
            }  //Id
            else if (RadioButtonList1.SelectedIndex == 1) 
            {
               this._presentador.CargaEstado();
            }  //Estado
            else if (RadioButtonList1.SelectedIndex == 2) 
            {
                this._presentador.CargaNombre();
            }  //Nombre
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Busqueda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
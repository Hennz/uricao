using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Presentacion.Presentador.PTratamientos;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Contrato.CTratamientos;

namespace Uricao.Presentacion.PaginasWeb.PTratamientos
{
    public partial class ConsultarTratamiento : System.Web.UI.Page, IContratoConsultarTratamiento
    {

        private PresentadorConsultarTratamiento _presentador;

        public ConsultarTratamiento()
        {
            _presentador = new PresentadorConsultarTratamiento(this);
        }
        
        #region Propiedades

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

        public TextBox CampoBusqueda
        {
            get { return Busqueda; }
            set { Busqueda = value; }
        }

        public RadioButtonList Parametro
        {
            get { return ParametrosBusqueda; }
        }


        #endregion Propiedades

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ParametrosBusqueda.Visible = true;
                Buscar.Visible = true;
                CampoBusqueda.Visible = true;
                #region
                /*
                List<Tratamiento> datos = GetData();

                GridViewTratamiento.DataSource = datos;
                if (datos != null)
                {
                    GridViewTratamiento.DataBind();
                }
                else { error.Text = "No se pueden mostrar los datos"; }*/
                #endregion
                //CargaTodos();
            }
        }



        protected void GridViewTratamiento_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Buscar")
            {

                Session.Add("objTratamiento", this._presentador.ConsultarTratamiento(Convert.ToInt32(e.CommandArgument), this.GridViewTratamiento.PageIndex, this.GridViewTratamiento.PageSize, ParametrosBusqueda.SelectedIndex));
                  Response.Redirect("ConsultarDetalleTratamiento.aspx");

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
            //cualquier cosa
        }

        protected void ParametrosBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cualquier cosa
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            if (ParametrosBusqueda.SelectedIndex == -1) { this._presentador.CargaTodos(); }   //Todos
            else if (ParametrosBusqueda.SelectedIndex == 0) { this._presentador.CargaId(); }  //Id
            else if (ParametrosBusqueda.SelectedIndex == 1) { this._presentador.CargaEstado(); }  //Estado
            else if (ParametrosBusqueda.SelectedIndex == 2) { this._presentador.CargaNombre(); }  //Nombre
        }
    }
}



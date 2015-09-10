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
    public partial class ModificarTratamiento : System.Web.UI.Page, IContratoModificarTratamiento
    {
         private PresentadorModificarTratamiento _presentador;

        public ModificarTratamiento()
        {
            _presentador = new PresentadorModificarTratamiento(this);
        }

        #region Propiedades

        public GridView GridTratamiento
        {
            get { return GridTratamiento; }
            set { GridTratamiento = value; }
        }

        #endregion Propiedades



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ParametrosBusqueda.Visible = false;
                Busqueda.Visible = false;
                Buscar.Visible = false;

                //List<Tratamiento> datos = GetData();

                //GridViewTratamiento.DataSource = datos;
                //if (datos != null)
                //{
                //    GridViewTratamiento.DataBind();
                //}
                //else { error.Text = "No se pueden mostrar los datos"; }
                CargaTodos();
            }
        }

        #region Cargar GridView
        protected void CargaTodos()
        {
            try
            {
                List<Entidad> datos = this._presentador.GetData();

                GridViewTratamiento.DataSource = datos;
                if (datos != null)
                {
                    GridViewTratamiento.DataBind();
                }
                else { error.Text = "No se pueden mostrar los datos"; }
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
        }
        #endregion Cargar GridView




        protected void GridViewTratamiento_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Buscar")
            {

                Session.Add("objTratamiento", this._presentador.ModificarTratamiento(Convert.ToInt32(e.CommandArgument), this.GridViewTratamiento.PageIndex, this.GridViewTratamiento.PageSize));
                Response.Redirect("ModificarTratamientoDetalle.aspx");
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

        protected void ParametrosBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            if (ParametrosBusqueda.SelectedIndex == -1) { CargaTodos(); }
        }
    }
}
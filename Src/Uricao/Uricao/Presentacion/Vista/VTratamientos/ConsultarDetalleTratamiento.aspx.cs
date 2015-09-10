using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EProductosInventario;
using Uricao.LogicaDeNegocios.Clases.LNProductosInventario;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Contrato.CTratamientos;
using Uricao.Presentacion.Presentador.PTratamientos;

namespace Uricao.Presentacion.PaginasWeb.PTratamientos
{
    public partial class ConsultarDetalleTratamiento : System.Web.UI.Page, IContratoConsultarDetalleTratamiento
    {
        //Tratamiento tratamiento = new Tratamiento();

        private Entidad _tratamiento;
        private PresentadorConsultarDetalleTratamiento _presentador;

        public ConsultarDetalleTratamiento()
        {
            _presentador = new PresentadorConsultarDetalleTratamiento(this);
        }

        
        #region Propiedades

        public TextBox Nombrep
        {
            get { return Nombrep; }
            set { Nombrep = value; }
       
        }

        public TextBox Duracionp
        {
            get { return Duracionp; }
            set { Duracionp = value; }
        
        }

         public TextBox Costop
        {
            get { return Costop; }
            set { Costop = value; }
        
        }

         public TextBox Descripcionp
         {
             get { return Descripcionp; }
             set { Descripcionp = value; }

         }
         public TextBox Explicacionp
         {
             get { return Explicacionp; }
             set { Explicacionp = value; }

         }




        #endregion Propiedades
         //PROPIEDADES 

        protected void Page_Load(object sender, EventArgs e)
        {
            _tratamiento = (Entidad)Session["objTratamiento"];
            if (_tratamiento == null)
                Response.Redirect("ConsultarTratamiento.aspx");
            //error.Text = tratamiento.Id.ToString();
            CargarDatos();
            if (!IsPostBack)
            {

                //EN EL PRESENTADOR
                List<Entidad> datos = this._presentador.GetData((_tratamiento as Tratamiento).Id);
                List<Entidad> implemento = this._presentador.GetDataImplemento(this._tratamiento);

                GridViewTratamiento.DataSource = datos;

                if (datos != null)
                {
                    GridViewTratamiento.DataBind();
                }
                else { mensajetratamiento.Text = "No posee tratamientos Asociados"; }

                GridViewProducto.DataSource = implemento;
                if (implemento != null)
                {
                    GridViewProducto.DataBind();
                }
                else { mensajeproducto.Text = "No posee Productos Asociados"; }
            }
        }
        
      
        protected void CargarDatos()
        {
            Nombre.Text = (_tratamiento as Tratamiento).Nombre;
            Duracion.Text = (_tratamiento as Tratamiento).Duracion.ToString();
            Costo.Text = (_tratamiento as Tratamiento).Costo.ToString();
            Descripcion.Text = (_tratamiento as Tratamiento).Descripcion;
            Explicacion.Text = (_tratamiento as Tratamiento).Explicacion;
        }

        protected void gridViewProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_presentador.BuscarProyecto();
        }

        

        

        protected void GridViewTratamiento_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Buscar")
            {
                    Session.Add("objTratamiento", this._presentador.ConsultarTratamiento(Convert.ToInt32(e.CommandArgument), this.GridViewTratamiento.PageIndex, 
                                this.GridViewTratamiento.PageSize, (this._tratamiento as Tratamiento).Id));

                    Response.Redirect("ConsultarDetalleTratamiento.aspx");
             }

        }

        protected void GridViewTratamiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTratamiento.PageIndex = e.NewPageIndex;
            GridViewTratamiento.DataSource = _presentador.GetData((_tratamiento as Tratamiento).Id);
            GridViewTratamiento.DataBind();
        }

        protected void gridViewTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_presentador.BuscarProyecto();
        }

        protected void GridViewProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProducto.PageIndex = e.NewPageIndex;
            GridViewProducto.DataSource = _presentador.GetDataImplemento(_tratamiento);
            GridViewProducto.DataBind();
        }

        
    }
}
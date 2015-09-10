using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Uricao.Presentacion.Contrato.CProductosInventario;
using Uricao.Presentacion.Presentador.PProductosInventario;

namespace Uricao.Presentacion.PaginasWeb.PProductosInventario
{
    public partial class SeleccionarProductoConsumo : System.Web.UI.Page, ISeleccionarProductoConsumo
    {
        PresentadorSeleccionarProductoConsumo _presentador;

        public SeleccionarProductoConsumo()
        {
            _presentador = new PresentadorSeleccionarProductoConsumo(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }
        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
            cargarTabla();
        }
        public void cargarTabla()
        {
            
            GridConsultar.DataSource = _presentador.cargarTabla();
            GridConsultar.DataBind();
        }

        #region Mensaje
        public void SetExito(String mensaje) { exito.Text = mensaje; }

        public void SetFalla(String mensaje) { falla.Text = mensaje; }
        #endregion

    }
}
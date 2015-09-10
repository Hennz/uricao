using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EProductosInventario;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Contrato.CProductosInventario;
using Uricao.Presentacion.Presentador.PProductosInventario;

namespace Uricao.Presentacion.PaginasWeb.PProductosInventario
{
    public partial class HomeProductos : System.Web.UI.Page, IContratoHomeProducto
    {
        List<Entidad> productos;
        PresentadorHomeProducto _presentador;

        public HomeProductos()
        {
            _presentador = new PresentadorHomeProducto(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            productos = _presentador.ObtenerProductos();
            if (productos!=null)
            {
                CargarTabla();
            }
        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entidad producto = productos[_presentador.SeleccionGrid(GridConsultar)];
            Session["Producto"] = producto;
            Response.Redirect("VerProducto.aspx");
        }
        
        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
            CargarTabla();
        }
        
        public void CargarTabla()
        {
            DataTable table = new DataTable();
            List<String> columnas = new List<String>() { "Nombre", "Tipo", "Categoría" };
            _presentador.CrearTabla(table, columnas);
            
            foreach (Entidad producto in productos)
            {
                table.Rows.Add((producto as Producto).Nombre, (producto as Producto).Tipo, (producto as Producto).Categoria);
            }

            GridConsultar.DataSource = table;
            GridConsultar.DataBind();
        }

        #region Mensaje
        public void SetExito(String mensaje) { exito.Text = mensaje; }

        public void SetFalla(String mensaje) { falla.Text = mensaje; }
        #endregion

    }
}
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EProductosInventario;
using Uricao.Presentacion.Contrato.CProductosInventario;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Presentador.PProductosInventario;

namespace Uricao.Presentacion.PaginasWeb.PProductosInventario
{
    public partial class HomeInventario : System.Web.UI.Page, IContratoHomeInventario
    {
        List<Entidad> productos;
        PresentadorHomeInventario _presentador;

        public HomeInventario()
        {
            _presentador = new PresentadorHomeInventario(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Por cada producto calcular cantidad al momento de cargar tabla
            productos = _presentador.ObtenerProductos();
            if (productos != null)
            {
                CargarTabla();
            }
        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
            CargarTabla();
        }
        public void CargarTabla()
        {
            //LogicaInventario logicaInventario = new LogicaInventario();
            DataTable table = new DataTable();
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Cantidad disponible", typeof(string));

            foreach (Producto producto in productos)
            {
                //table.Rows.Add(producto.Nombre,logicaInventario.CalcularDisponibles(producto).ToString());
            }

            GridConsultar.DataSource = table;
            GridConsultar.DataBind();
        }
        public void SetExito(String mensaje) { exito.Text = mensaje; }

        public void SetFalla(String mensaje) { falla.Text = mensaje; }


    }
}
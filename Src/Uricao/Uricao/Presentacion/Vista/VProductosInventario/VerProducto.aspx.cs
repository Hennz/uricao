using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class VerProducto : System.Web.UI.Page, IContratoVerProducto
    {
        private static Entidad productoGenerico;
        List<Entidad> productosDetallados;
        PresentadorVerProducto _presentador;

        public VerProducto()
        {
            _presentador = new PresentadorVerProducto(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Recibo el producto que fue seleccionado del GridView
            productoGenerico = (Producto)Session["Producto"];

            if (!IsPostBack)
            {
                _presentador.OnLoad();

                if (productoGenerico != null)
                {
                    SetNombre((productoGenerico as Producto).Nombre);
                    //TextBoxNombre.Text = productoGenerico.Nombre;
                    DropDownListTipo.SelectedValue = (productoGenerico as Producto).Tipo;
                    //DropDownListCategoria.SelectedValue = productoGenerico.Categoria;
                }
            
                //Bloqueo los elementos de la interfaz ya que es solo para consulta
                botonEditar.Text = "Editar";
                if (botonEditar.Text == "Editar")
                {
                    TextBoxNombre.Enabled = false;
                    DropDownListTipo.Enabled = false;
                    DropDownListCategoria.Enabled = false;
                }
            }

            //Lleno la tabla con los productos detallados de este producto generico
            CargarTabla(productoGenerico);
        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entidad producto = productosDetallados[_presentador.SeleccionGrid(GridConsultar)];
            Session["ProductoDetallado"] = producto;
            Response.Redirect("VerProductoDetallado.aspx");
        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
            //CargarTabla();
        }

        public void CargarTabla(Entidad productoGenerico)
        {
            productosDetallados = _presentador.ObtenerProductosDetallados(productoGenerico);
            //productosDetallados = null;

            DataTable table = new DataTable();
            List<String> columnas = new List<String>() { "Código", "Marca", "Proveedor" };
            _presentador.CrearTabla(table, columnas);

            foreach (Entidad producto in productosDetallados)
            {
                table.Rows.Add((producto as Producto).Codigo, (producto as Producto).Marca, (producto as Producto).Proveedor.Nombre);
            }

            GridConsultar.DataSource = table;
            GridConsultar.DataBind();
        }

        protected void botonEditar_Click(object sender, EventArgs e)
        {
            if (botonEditar.Text == "Editar")
            {
                TextBoxNombre.Enabled = true;
                DropDownListTipo.Enabled = true;
                DropDownListCategoria.Enabled = true;
                botonEditar.Text = "Aceptar";
                return;
            }
            if (botonEditar.Text == "Aceptar")
            {
                //Edito el objeto producto
                productoGenerico = (Producto)Session["Producto"];
                String nombreViejo = (productoGenerico as Producto).Nombre;
                (productoGenerico as Producto).Nombre = TextBoxNombre.Text;
                (productoGenerico as Producto).Tipo = DropDownListTipo.SelectedValue;
                //productoGenerico.Categoria = DropDownListCategoria.SelectedValue;
                
                //Edito el producto en BD e informo al usuario
                if (_presentador.EditarProductoGenerico(productoGenerico, nombreViejo))
                {
                    exito.Visible = true;
                    exito.Text = "Edición exitosa";
                }
                else
                {
                    falla.Visible = true;
                    falla.Text = "Edición fallida";
                }
                
                //Se bloquean los campos para consulta
                TextBoxNombre.Enabled = false;
                DropDownListTipo.Enabled = false;
                DropDownListCategoria.Enabled = false;
                botonEditar.Text = "Editar";
                return;
            }


        }
        
        public void SetExito(String mensaje) { exito.Text = mensaje; }
        public void SetFalla(String mensaje) { falla.Text = mensaje; }

        public TextBox GetNombre() { return TextBoxNombre; }
        public void SetNombre(String Nombre) { TextBoxNombre.Text = Nombre; }

        public DropDownList GetTipo() { return DropDownListTipo; }
        public void SetTipo(DropDownList combo) { DropDownListTipo = combo; }

        public DropDownList GetCategoria() { return DropDownListCategoria; }
        public void SetCategoria(DropDownList combo) { DropDownListCategoria = combo; }

    }
}
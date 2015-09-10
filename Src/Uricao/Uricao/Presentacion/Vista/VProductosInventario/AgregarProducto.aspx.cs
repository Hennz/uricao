using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EProductosInventario;
using Uricao.LogicaDeNegocios.Excepciones.ExcepcionesProductos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Presentacion.Contrato.CProductosInventario;
using Uricao.Presentacion.Presentador.PProductosInventario;

namespace Uricao.Presentacion.PaginasWeb.PProductosInventario
{
    public partial class AgregarProducto : System.Web.UI.Page, IContratoAgregarProducto
    {
        Entidad producto = FabricaEntidad.NuevoProducto();
        PresentadorAgregarProducto _presentador;

        public AgregarProducto()
        {
            _presentador = new PresentadorAgregarProducto(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.OnLoad();
            }
            if (Session["proveedor"] != null)
            {
                _presentador.LlenarMarcas((string)Session["proveedor"]);
            }
        }
        
        #region Listo
        public void SetDropDownListCategoria(DropDownList combo)
        {
            try
            {
                DropDownListCategoria.Items.Clear();
                for (int i = 0; i < combo.Items.Count; i++)
                {
                    DropDownListCategoria.Items.Add(combo.Items[i]);
                }
            }
            catch (Exception)
            {
                falla.Text = "Error en la carga de categoria";
            }
        }

        public void SetDropDownListProveedor(DropDownList combo)
        {
            try
            {
                DropDownListProveedor.Items.Clear();
                for (int i = 0; i < combo.Items.Count; i++)
                {
                    DropDownListProveedor.Items.Add(combo.Items[i]);
                }
                Session["proveedor"] = DropDownListProveedor.SelectedValue;
                
            }
            catch (Exception)
            {
                falla.Text = "Error en la carga de proveedor";
            }
        }

        public void SetDropDownListMarca(DropDownList combo)
        {
            try
            {
                DropDownListMarca.Items.Clear();
                for (int i = 0; i < combo.Items.Count; i++)
                {
                    DropDownListMarca.Items.Add(combo.Items[i]);
                }
            }
            catch (Exception)
            {
                falla.Text = "Error en la carga de categoria";
            }
        }

        #region Mensaje
        public void SetExito(String mensaje) { exito.Text = mensaje; }

        public void SetFalla(String mensaje) { falla.Text = mensaje; }
        #endregion

        #endregion

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            try
            {                
                _presentador.AgregarProducto();               
                //Response.Redirect("HomeProductos.aspx");
            }
            catch (Exception ex)
            {
                falla.Text = ex.Message;
            }
        }

        public TextBox GetNombre() { return TextBoxNombre; }
        public TextBox GetPrecio() { return TextBoxPrecio; }
        public DropDownList GetMarca() { return DropDownListMarca; }
        public DropDownList GetTipo() { return DropDownListTipo; }
        public DropDownList GetCalidad() { return DropDownListCalidad; }
        public DropDownList GetCategoria() { return DropDownListCategoria; }
        public TextBox GetCodigo() { return TextBoxCodigo; }
        public DropDownList GetProveedor() { return DropDownListProveedor; }
        public TextBox GetInconveniente() { return TextBoxInconvenientes; }
        public TextBox GetCantMinima() { return TextBoxCantidadMinima; }      

        protected void DropDownListProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["proveedor"] = DropDownListProveedor.SelectedValue;
            this.Page_Load(sender, e);
        }

        protected void DropDownListCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EProductosInventario;
using Uricao.Presentacion.Contrato.CProductosInventario;
using Uricao.Presentacion.Presentador.PProductosInventario;

namespace Uricao.Presentacion.PaginasWeb.PProductosInventario
{
    public partial class VerProductoDetallado : System.Web.UI.Page, IContratoVerProductoDetallado
    {
        Producto productoDetallado = new Producto();

        PresentadorVerProductoDetallado _presentador;

        public VerProductoDetallado()
        {
            _presentador = new PresentadorVerProductoDetallado(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Recibo el producto que fue seleccionado del GridView
            productoDetallado = (Producto)Session["ProductoDetallado"];

            if (!IsPostBack)
            {
                //Lleno los comboBox
                _presentador.OnLoad();
                //Funciones.LlenarCategorias(DropDownListCategoria);
                //Funciones.LlenarTipo(DropDownListTipo);
                //Funciones.LlenarMarcas(DropDownListMarca);
                //Funciones.LlenarCalidad(DropDownListCalidad);
                //Funciones.LlenarProveedores(DropDownListProveedor);

                if (productoDetallado != null)
                {
                    TextBoxNombre.Text = productoDetallado.Nombre;
                    DropDownListTipo.SelectedValue = productoDetallado.Tipo;
                    TextBoxCodigo.Text = productoDetallado.Codigo;
                    DropDownListCalidad.SelectedValue = productoDetallado.Calidad;
                    DropDownListProveedor.SelectedValue = productoDetallado.Proveedor.Nombre;
                    DropDownListMarca.SelectedValue = productoDetallado.Marca;
                    TextBoxPrecio.Text = Convert.ToString(productoDetallado.Precio);
                }

                #region Bloqueo los elementos de la interfaz ya que es solo para consulta
                botonEditar.Text = "Editar";
                if (botonEditar.Text == "Editar")
                {
                    TextBoxNombre.Enabled = false;
                    DropDownListTipo.Enabled = false;
                    DropDownListCategoria.Enabled = false;
                    TextBoxCodigo.Enabled = false;
                    DropDownListCalidad.Enabled = false;
                    DropDownListMarca.Enabled = false;
                    TextBoxPrecio.Enabled = false;
                    DropDownListProveedor.Enabled = false;
                }
                #endregion
            }
        }

        protected void botonEditar_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(botonEditar.Text);
            if (botonEditar.Text == "Editar")
            {
                #region Desbloqueo los elementos de la interfaz para edicion
                TextBoxNombre.Enabled = false;
                DropDownListTipo.Enabled = false;
                DropDownListCategoria.Enabled = false;
                TextBoxCodigo.Enabled = false;
                DropDownListCalidad.Enabled = true;
                DropDownListMarca.Enabled = true;
                TextBoxPrecio.Enabled = true;
                DropDownListProveedor.Enabled = true;
                botonEditar.Text = "Aceptar";
                return;
                #endregion
            }
            else
            {
                //Edito el objeto producto
                productoDetallado.Codigo = TextBoxCodigo.Text;
                productoDetallado.Calidad = DropDownListCalidad.SelectedValue;
                productoDetallado.Marca = DropDownListMarca.SelectedValue;
                productoDetallado.Precio = Convert.ToDecimal(TextBoxPrecio.Text);

                //Edito el producto en la BD e informo al usuario
                if (_presentador.EditarProducto(productoDetallado))
                {
                    exito.Visible = true;
                    exito.Text = "Edición exitosa";
                }
                else
                {
                    falla.Visible = true;
                    falla.Text = "Edición fallida";
                }

                #region Bloqueo los elementos de la interfaz para consulta
                TextBoxNombre.Enabled = false;
                DropDownListTipo.Enabled = false;
                DropDownListCategoria.Enabled = false;
                TextBoxCodigo.Enabled = false;
                DropDownListCalidad.Enabled = false;
                DropDownListMarca.Enabled = false;
                TextBoxPrecio.Enabled = false;
                botonEditar.Text = "Editar";
                return;
                #endregion
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

        public void SetDropDownListTipo(DropDownList combo)
        {
            try
            {
                DropDownListTipo.Items.Clear();
                for (int i = 0; i < combo.Items.Count; i++)
                {
                    DropDownListTipo.Items.Add(combo.Items[i]);
                }
            }
            catch (Exception)
            {
                falla.Text = "Error en la carga de categoria";
            }
        }

        public void SetDropDownListCalidad(DropDownList combo)
        {
            try
            {
                DropDownListCalidad.Items.Clear();
                for (int i = 0; i < combo.Items.Count; i++)
                {
                    DropDownListCalidad.Items.Add(combo.Items[i]);
                }
            }
            catch (Exception)
            {
                falla.Text = "Error en la carga de categoria";
            }
        }

        public void SetExito(String mensaje) { exito.Text = mensaje; }

        public void SetFalla(String mensaje) { falla.Text = mensaje; }

        #endregion

    }
}
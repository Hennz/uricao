using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.LogicaDeNegocios.Comandos.Proveedores;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Presentacion.PaginasWeb;
using System.Web.SessionState;
using Uricao.Entidades.EProveedores;
using Uricao.Presentacion.Presentador.PCuentasPorPagar;
using Uricao.LogicaDeNegocios.Comandos;

namespace Uricao.Presentacion.Presentador.PCuentasPorPagar
{

    public class PresentadorAbonarCuentasPorPagar1
    {
        #region Atributos
        private IContratoAbonarCuentasPorPagar1 _vista;
        private Comando<List<Entidad>> _listaComando;
        private List<Entidad> _milistaCpp;
        #endregion


        #region constructor
        public PresentadorAbonarCuentasPorPagar1(IContratoAbonarCuentasPorPagar1 laVista)
        {
            this._vista = laVista;
        }
        #endregion

        #region Métodos
        public void OnClick()
        {

            if ((_vista.RazonSocial.SelectedValue != "0") && (_vista.Fechai.Text == "") && (_vista.Fechaf.Text == ""))
            {
                //solo proveedor
                _listaComando = FabricaComando.CrearComandoAbonarObtenerCuentasPorPagarProveedor(_vista.RazonSocial.SelectedValue.ToString());
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTabla(_milistaCpp);
                _vista.GridView1.DataBind();
            }
            else if ((_vista.RazonSocial.SelectedValue == "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text != ""))
            {
                //solo por fechas
                _listaComando = FabricaComando.CrearComandoAbonarConsultarCuentasPorPagarFechas(_vista.Fechai.Text, _vista.Fechaf.Text);
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaFechas(_milistaCpp);
                _vista.GridView1.DataBind();
            }
            else if ((_vista.RazonSocial.SelectedValue != "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text != ""))
            {
                //todos los parametros
                _listaComando = FabricaComando.CrearComandoAbonarConsultarCuentasPorPagar(_vista.Fechai.Text, _vista.Fechaf.Text, _vista.RazonSocial.SelectedValue.ToString());
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaTodosLosParametros(_milistaCpp);
                _vista.GridView1.DataBind();

            }
            else if ((_vista.RazonSocial.SelectedValue != "0") && ((_vista.Fechai.Text != "") && (_vista.Fechaf.Text == "")) || (_vista.Fechai.Text == "") && (_vista.Fechaf.Text != ""))
            {
                //proveedor y fecha inicio
                _vista.Falla.Text = "Operacion Fallida, parámetros de busqueda incompletos";
                _vista.Falla.Visible = true;
            }
            else if ((_vista.RazonSocial.SelectedValue == "0") && (_vista.Fechai.Text == "") && (_vista.Fechaf.Text == ""))
            {
                //proveedory fecha fin
                _vista.Falla.Text = "Operacion Fallida, parámetros de busqueda incompletos";
                _vista.Falla.Visible = true;
            }
            else if ((_vista.RazonSocial.SelectedValue == "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text == ""))
            {
                //solo fecha inicio
                _vista.Falla.Text = "Operacion Fallida, parámetros de busqueda incompletos";
                _vista.Falla.Visible = true;
            }
            else if ((_vista.RazonSocial.SelectedValue == "0") && (_vista.Fechai.Text == "") && (_vista.Fechaf.Text != ""))
            {
                //solo fecha fin
                _vista.Falla.Text = "Operacion Fallida, parámetros de busqueda incompletos";
                _vista.Falla.Visible = true;
            }
        }
            public DataTable cargarTabla(List<Entidad> miLista)
        {
            DataTable miTabla = new DataTable();

            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));

            foreach (CuentaPorPagar _cuentaPorPagar in miLista)
                miTabla.Rows.Add((_cuentaPorPagar as CuentaPorPagar).IdCuentaPorPagar, (_cuentaPorPagar as CuentaPorPagar).FechaEmision, (_cuentaPorPagar as CuentaPorPagar).MontoActualDeuda);

            return miTabla;         
        }

        public DataTable cargarTablaFechas(List<Entidad> miLista)
        {
            int posicion = 0;
            DataTable miTabla = new DataTable();

            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            //miTabla.Columns.Add("Fecha Vencimiento", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));
            miTabla.Columns.Add("Razon Social", typeof(string));

            foreach (CuentaPorPagar cuenta in miLista)
            {
                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.MontoActualDeuda, cuenta.ListaProveedor.ElementAt(0).Nombre);
                posicion++;
            }

            return miTabla;
        }

        public DataTable cargarTablaTodosLosParametros(List<Entidad> miLista)
        {
            DataTable miTabla = new DataTable();

            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));
            //miTabla.Columns.Add("Razon Social", typeof(string));

            foreach (CuentaPorPagar cuenta in miLista)
                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.MontoActualDeuda);

            return miTabla;
        }

        public void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        { 
            
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = _vista.GridView1.Rows[index];
            String cuentaCodigo = Convert.ToString(row.Cells[1].Text);
            String fechaEmision = Convert.ToString(row.Cells[2].Text);
            String montoDeuda = Convert.ToString(row.Cells[3].Text);
            string proveedor;
            if (_vista.RazonSocial.SelectedValue == "0")
            {
                proveedor = Convert.ToString(row.Cells[4].Text);
                //Response.Redirect("AbonarCuentasPorPagar2.aspx?cuentaCodigo=" + cuentaCodigo +
                //  "&fechaEmision=" + fechaEmision + "&montoDeuda=" + montoDeuda + "&proveedor=" + proveedor);
                _vista.Redireccionar("AbonarCuentasPorPagar2.aspx?cuentaCodigo=" + cuentaCodigo +
                "&fechaEmision=" + fechaEmision + "&montoDeuda=" + montoDeuda + "&proveedor=" + proveedor);
            }
            else
            {
                proveedor = Convert.ToString(_vista.RazonSocial.SelectedValue.ToString());
                _vista.Redireccionar("AbonarCuentasPorPagar2.aspx?cuentaCodigo=" + cuentaCodigo +
                  "&fechaEmision=" + fechaEmision + "&montoDeuda=" + montoDeuda + "&proveedor=" + proveedor);
               /* Response.Redirect("AbonarCuentasPorPagar2.aspx?cuentaCodigo=" + cuentaCodigo +
                  "&fechaEmision=" + fechaEmision + "&montoDeuda=" + montoDeuda + "&proveedor=" + proveedor);*/
            }
        }

        public void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if ((_vista.RazonSocial.SelectedValue != "0") && (_vista.Fechai.Text == "") && (_vista.Fechaf.Text == ""))
            {
                //solo proveedor
                _vista.GridView1.PageIndex = e.NewPageIndex;
                _listaComando = FabricaComando.CrearComandoAbonarObtenerCuentasPorPagarProveedor(_vista.RazonSocial.SelectedValue.ToString());
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTabla(_milistaCpp);
                _vista.GridView1.DataBind();
            }
            else if ((_vista.RazonSocial.SelectedValue == "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text != ""))
            {
                //solo por fechas
                _vista.GridView1.PageIndex = e.NewPageIndex;
                _listaComando = FabricaComando.CrearComandoAbonarConsultarCuentasPorPagarFechas(_vista.Fechai.Text, _vista.Fechaf.Text);
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaFechas(_milistaCpp);
                _vista.GridView1.DataBind();
            }
            else if ((_vista.RazonSocial.SelectedValue != "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text != ""))
            {
                //todos los parametros
                _vista.GridView1.PageIndex = e.NewPageIndex;
                _listaComando = FabricaComando.CrearComandoAbonarConsultarCuentasPorPagar(_vista.Fechai.Text, _vista.Fechaf.Text, _vista.RazonSocial.SelectedValue.ToString());
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaTodosLosParametros(_milistaCpp);
                _vista.GridView1.DataBind();
            }

        }

        public void CargarRazonSocial()
        {
            Entidad proveedor = FabricaEntidad.NuevoProveedor();
           // _listaComando = FabricaComando.CrearComandoConsultarTodosProveedores();
            //_milistaCpp = _listaComando.Ejecutar();
            List<Entidad> listaProveedores = FabricaComando.CrearComandoConsultarTodosProveedores().Ejecutar();
            //LogicaProveedor miProveedor = new LogicaProveedor();
            //listaProveedores = miProveedor.ObtenerProveedores();
            //List<Proveedor> _milistaProv = (_milistaCpp as List<Proveedor>);

            for (int i = 0; i < listaProveedores.Count; i++)
            {
                proveedor = listaProveedores[i];
                _vista.RazonSocial.Items.Add((proveedor as Proveedor).Nombre.ToString());
            }
        }
            public void PageLoad()
        {

            _vista.Falla.Visible = false;
            _vista.Exito.Visible = false;
           // CargarRazonSocial();
        }
        #endregion


        }
    }

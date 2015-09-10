using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using System.Web.SessionState;

namespace Uricao.Presentacion.Presentador.PCuentasPorPagar
{
    public class PresentadorActivarDesactivarCuentasPorPagar1
    {
        #region atributos
        private IContratoActivarDesactivarCuentasPorPagar1 _vista;
        private Comando<List<Entidad>> _listaComando;
        private List<Entidad> _milistaCpp;
        Entidad miCuenta =FabricaEntidad.CrearCuentaPorPagar();
        private Comando<bool> _Comando;
        private bool operacionRealizada;
        #endregion


        #region Constructor
        public PresentadorActivarDesactivarCuentasPorPagar1(IContratoActivarDesactivarCuentasPorPagar1 laVista)
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
                _listaComando = FabricaComando.CrearComandoConsultarCuentasPorPagarFechasActivar(_vista.Fechai.Text, _vista.Fechaf.Text);
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaFechas(_milistaCpp);
                _vista.GridView1.DataBind();
            }
            else if ((_vista.RazonSocial.SelectedValue != "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text != ""))
            {
                //todos los parametros
                _listaComando = FabricaComando.CrearComandoConsultarCuentasPorPagarFechasProveedorActivar(_vista.Fechai.Text, _vista.Fechaf.Text, _vista.RazonSocial.SelectedValue.ToString());
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
                //proveedor y fecha fin
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
            miTabla.Columns.Add("Estatus", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));
            //GridView1.Columns[3].ControlStyle.BackColor = ConsoleColor.Gray.ToString();

            //GridView1.Columns[3].HeaderStyle.BackColor = ConsoleColor.Gray;


            foreach (CuentaPorPagar cuenta in miLista)
                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.Estatus, cuenta.MontoActualDeuda);

            return miTabla;
        }

        public DataTable cargarTablaFechas(List<Entidad> miLista)
        {
            int posicion = 0;
            DataTable miTabla = new DataTable();

            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Columns.Add("Estatus", typeof(string));
            miTabla.Columns.Add("Razon Social", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));

            foreach (CuentaPorPagar cuenta in miLista)
            {
                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.Estatus, cuenta.ListaProveedor.ElementAt(0).Nombre, cuenta.MontoActualDeuda);
                posicion++;
            }

            return miTabla;
        }

        public DataTable cargarTablaTodosLosParametros(List<Entidad> miLista)
        {
            DataTable miTabla = new DataTable();

            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Columns.Add("Estatus", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));


            foreach (CuentaPorPagar cuenta in miLista)
                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.Estatus, cuenta.MontoActualDeuda);

            return miTabla;
        }

        public void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
           bool operacionRealizada = false;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = _vista.GridView1.Rows[index];
            string cuentaCodigo = Convert.ToString(row.Cells[1].Text);
            string estatusPP = Convert.ToString(row.Cells[3].Text).TrimEnd();

            if (estatusPP.Equals("activo"))
            {
                (miCuenta as CuentaPorPagar).IdCuentaPorPagar = cuentaCodigo;
                (miCuenta as CuentaPorPagar).Estatus = "inactivo";
                //operacionRealizada = miLogica.ActivarDesactivarCpp(miCuenta);
                _Comando = FabricaComando.CrearComandoActivarDesactivarCpp(miCuenta);
                operacionRealizada = _Comando.Ejecutar();
            }
            else if (estatusPP.Equals("inactivo"))
            {
                (miCuenta as CuentaPorPagar).IdCuentaPorPagar = cuentaCodigo;
                (miCuenta as CuentaPorPagar).Estatus = "activo";
               // operacionRealizada = miLogica.ActivarDesactivarCpp(miCuenta);
                _Comando = FabricaComando.CrearComandoActivarDesactivarCpp(miCuenta);
                operacionRealizada = _Comando.Ejecutar();
            }

            if (operacionRealizada.Equals(false))
            {
                _vista.Falla.Text = "Operacion Fallida";
                _vista.Falla.Visible = true;
                _vista.Exito.Visible = false;

            }
            else if (operacionRealizada.Equals(true))
            {
                _vista.Exito.Text = "Operacion Realizada Exitosamente";
                _vista.Exito.Visible = true;
                _vista.Falla.Visible = false;

            }
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
                _listaComando = FabricaComando.CrearComandoConsultarCuentasPorPagarFechasActivar(_vista.Fechai.Text, _vista.Fechaf.Text);
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaFechas(_milistaCpp);
                _vista.GridView1.DataBind();
            }
            else if ((_vista.RazonSocial.SelectedValue != "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text != ""))
            {
                //todos los parametros
                _listaComando = FabricaComando.CrearComandoConsultarCuentasPorPagarFechasProveedorActivar(_vista.Fechai.Text, _vista.Fechaf.Text, _vista.RazonSocial.SelectedValue.ToString());
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaTodosLosParametros(_milistaCpp);
                _vista.GridView1.DataBind();

      
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
                _listaComando = FabricaComando.CrearComandoConsultarCuentasPorPagarFechasActivar(_vista.Fechai.Text, _vista.Fechaf.Text);
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaFechas(_milistaCpp);
                _vista.GridView1.DataBind();
            }
            else if ((_vista.RazonSocial.SelectedValue != "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text != ""))
            {
                //todos los parametros
                _vista.GridView1.PageIndex = e.NewPageIndex;
                _listaComando = FabricaComando.CrearComandoConsultarCuentasPorPagarFechasProveedorActivar(_vista.Fechai.Text, _vista.Fechaf.Text, _vista.RazonSocial.SelectedValue.ToString());
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaTodosLosParametros(_milistaCpp);
                _vista.GridView1.DataBind();
            }

        }

        public void PageLoad()
        {

            _vista.Falla.Visible = false;
            _vista.Exito.Visible = false;
            //CargarRazonSocial();
        }
        public void CargarRazonSocial()
        {
            _listaComando = FabricaComando.CrearComandoConsultarTodosProveedores();
            _milistaCpp = _listaComando.Ejecutar();
            //LogicaProveedor miProveedor = new LogicaProveedor();
            //listaProveedores = miProveedor.ObtenerProveedores();
            //List<Proveedor> _milistaProv = (_milistaCpp as List<Proveedor>);

            for (int i = 0; i < _milistaCpp.Count; i++)
            {
                _vista.RazonSocial.Items.Add(_milistaCpp.ElementAt(i).ToString());
            }
        }
        #endregion

    }
}
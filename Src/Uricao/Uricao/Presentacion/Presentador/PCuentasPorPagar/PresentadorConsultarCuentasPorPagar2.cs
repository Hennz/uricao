using System;
using System.Collections.Generic;
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
using Uricao.Entidades.EAbonos;

namespace Uricao.Presentacion.Presentador.PCuentasPorPagar
{
    public class PresentadorConsultarCuentasPorPagar2
    {
        private IContratoConsultarCuentasPorPagar2 _vista;


        public PresentadorConsultarCuentasPorPagar2(IContratoConsultarCuentasPorPagar2 laVista)
        {
            this._vista = laVista;
        }
        Entidad miCuenta = FabricaEntidad.CrearCuentaPorPagar();
        List<Abono> listaAbono = new List<Abono>();
        private Comando<Entidad> _listaComando;
        private Entidad _milistaCpp;
        private Comando<List<Entidad>> _listaComando1;
        private List<Entidad> _milistaCpp1;
        public void pageLoadConsultar2()
        {
            _vista.Falla.Visible = false;
            _vista.Exito.Visible = false;

            //string cuentaCodigo = Convert.ToString((Request.QueryString["cuentaCodigo"] != null) ? Request.QueryString["cuentaCodigo"] : "");
            string cuentaCodigo = _vista.Requestconsultar2("cuentaCodigo");
            //string fechaEmision = Convert.ToString((Request.QueryString["fechaEmision"] != null) ? Request.QueryString["fechaEmision"] : "");
            string fechaEmision = _vista.Requestconsultar2("fechaEmision");
            //string montoDeuda = Convert.ToString((Request.QueryString["montoDeuda"] != null) ? Request.QueryString["montoDeuda"] : "");
            string montoDeuda = _vista.Requestconsultar2("montoDeuda");
            //string proveedor = Convert.ToString((Request.QueryString["proveedor"] != null) ? Request.QueryString["proveedor"] : "");
            string proveedor = _vista.Requestconsultar2("proveedor");
            _vista.LabelcuentaCodigo.Text = cuentaCodigo;

            //mostrar el monto inicial  de la deuda:
            _vista.LabelmontoDeuda.Text = montoDeuda;

            _vista.Labelproveedor.Text = proveedor;

            Int64 cuenta = Convert.ToInt64(cuentaCodigo);

           // miCuenta = miLogicaCuentaPorPagar.llenarAbonarCpp2(proveedor, cuenta);
            _listaComando = FabricaComando.CrearComandollenarAbonarCpp2(proveedor, cuenta);
            _milistaCpp = _listaComando.Ejecutar();

            (_milistaCpp as CuentaPorPagar).MontoInicialDeuda = Convert.ToDouble(montoDeuda);

            if ((_milistaCpp as CuentaPorPagar).ListaAbono.Count() == 0)
            {
                //monto nulo:
                //_milistaCpp = miLogicaCuentaPorPagar.ConsultarCuentaPorPagarBD(cuentaCodigo);
                _listaComando = FabricaComando.CrearComandoConsultarCuentaPorPagar(cuentaCodigo);
                _milistaCpp = _listaComando.Ejecutar();
            }
            else
            {
                //si es correcta la cuanta, hay abonos:
                //resta= monto inicial deuda - suman de los abonos: ahota en el atributo .MontoActualDeuda estara la deuda de hoy.
                (_milistaCpp as CuentaPorPagar).CalcularDeudaActual((_milistaCpp as CuentaPorPagar).ListaAbono.ElementAt(0).MontoAbono);

                //resto de los labels:
                //resto de los atributos:
                _vista.LabelBanco.Text = (_milistaCpp as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).Banco.NombreBanco.ToString();
                _vista.LabelNumeroCuenta.Text = (_milistaCpp as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).NroCuentaBanco.ToString();
                //mostrar el monto actual de la deuda:
                _vista.Labeldeudafinal.Text = (_milistaCpp as CuentaPorPagar).MontoActualDeuda.ToString();
                _vista.LabeltipoPago.Text = (_milistaCpp as CuentaPorPagar).TipoPago.ToString();
            }

            //0j0 listaAbono = miLogicaAbono.llenarGridAbonos(proveedor, cuenta);
            _listaComando1 = FabricaComando.CrearComandollenarGridAbonos(proveedor, cuenta);
            _milistaCpp1 = _listaComando1.Ejecutar();
            cargarTabla(_milistaCpp1);

        }

        public void cargarTabla(List<Entidad> miLista)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Nro.Cuota", typeof(int));
            table.Columns.Add("Fecha Abono", typeof(string));
            table.Columns.Add("Abono", typeof(double));
            table.Columns.Add("Deuda Actual", typeof(double));
            int numeroCuota = 1;

            foreach (Abono abonar in miLista)
            {
                table.Rows.Add(numeroCuota, abonar.FechaAbono, abonar.MontoAbono, abonar.Deuda);
                numeroCuota++;
            }

            _vista.GridView2Abono.DataSource = table;
            _vista.GridView2Abono.DataBind();
        }

        public void GridView2Abono_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string cuentaCodigo = _vista.Requestconsultar2("cuentaCodigo");
            string fechaEmision = _vista.Requestconsultar2("fechaEmision");
            string montoDeuda = _vista.Requestconsultar2("montoDeuda");
            string proveedor = _vista.Requestconsultar2("proveedor");
            _vista.LabelcuentaCodigo.Text = cuentaCodigo;
            Int64 cuenta = Convert.ToInt64(cuentaCodigo);
            _vista.GridView2Abono.PageIndex = e.NewPageIndex;
            _listaComando1 = FabricaComando.CrearComandollenarGridAbonos(proveedor, cuenta);
            _milistaCpp1 = _listaComando1.Ejecutar();
            cargarTabla(_milistaCpp1);

        }

    }
}
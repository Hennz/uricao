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
using System.Web.SessionState;
using System.Web.Query;
using System.Web.Management;


namespace Uricao.Presentacion.Presentador.PCuentasPorPagar
{
    public class PresentadorAbonarCuentasPorPagar2
    {
         private IContratoAbonarCuentasPorPagar2 _vista;
         Entidad _miAbono = Entidades.FabricasEntidad.FabricaEntidad.CrearAbono();
         Entidad _miCuentaPP = Entidades.FabricasEntidad.FabricaEntidad.CrearCuentaPorPagar();
         List<Entidad> listaAbono = new List<Entidad>();
         private Comando<bool> _Comando;
         private bool _milistaAbonoI =false;
         private bool _milistaAbonoM=true;
         private Comando<List<Entidad>> _listaComando;
         private List<Entidad> _milistaAbono;
         private List<Entidad> _milistaCpp;
         Entidad miCuenta =FabricaEntidad.CrearCuentaPorPagar();
         private Comando<Entidad> _listaComando1;
         private Entidad _milistaCpp1;
         #region Constructor
         public PresentadorAbonarCuentasPorPagar2(IContratoAbonarCuentasPorPagar2 laVista)
        {
            this._vista = laVista;
        }
         #endregion


         #region Métodos
         public void OnClickAbonar()
         {
             double montoAbonado = Convert.ToDouble(_vista.TextBox1.Text);
             double deuda = Convert.ToDouble(_vista.Labeldeudafinal.Text);
             double montoDeudaActual = (_miAbono as Abono).ValidaMonto(montoAbonado, deuda);


             if ((Convert.ToInt32(montoDeudaActual) >= 0) && (Convert.ToInt32(montoAbonado) > 0))
             {
                 (_miAbono as Abono).Deuda = montoDeudaActual;
                 (_miAbono as Abono).FechaAbono = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
                 (_miAbono as Abono).MontoAbono = montoAbonado;

                 //fueInsertado = miLogicaAbono.agregarAbono(_miAbono, Convert.ToInt64(_vista.LabelcuentaCodigo.Text));
                 _Comando = FabricaComando.CrearComandoAgregarAbono(_miAbono, Convert.ToInt64(_vista.LabelcuentaCodigo.Text));
                 _milistaAbonoI = _Comando.Ejecutar();

                 if ((_milistaAbonoI == true) && (montoDeudaActual == 0))
                 {
                     (_miCuentaPP as CuentaPorPagar).IdCuentaPorPagar = _vista.LabelcuentaCodigo.Text;
                     (_miCuentaPP as CuentaPorPagar).Estatus = "cancelado";
                     // fueModificado = miLogicaCuentaPorPagar.CambiarEstatusCpp(_miCuentaPP);
                     _Comando = FabricaComando.CrearComandoCambiarEstatusCpp(_miCuentaPP);
                     _milistaAbonoM = _Comando.Ejecutar();
                 }
             }
             else
                 //fueInsertado = false;
                 _milistaAbonoI = false;


             if (_milistaAbonoI.Equals(false) || (_milistaAbonoM.Equals(false)))
             {
                 _vista.Falla.Text = "Operacion Fallida";
                 _vista.Falla.Visible = true;
                 _vista.Exito.Visible = false;
             }
             else if (_milistaAbonoI.Equals(true) && _milistaAbonoM.Equals(true))
             {
                 _vista.Exito.Text = "Operacion Realizada Exitosamente";
                 _vista.Exito.Visible = true;
                 _vista.Falla.Visible = false;

                 _vista.TextBox1.Text = "0";
                 _vista.Labeldeudafinal.Text = montoDeudaActual.ToString();
                 _listaComando = FabricaComando.CrearComandollenarGridAbonos(_vista.Labelproveedor.Text, Convert.ToInt64(_vista.LabelcuentaCodigo.Text));
                 _milistaAbono = _listaComando.Ejecutar();
                 //listaAbono = miLogicaAbono.llenarGridAbonos(_vista.Labelproveedor.Text, Convert.ToInt64(_vista.LabelcuentaCodigo.Text));
                 cargarTabla(_milistaAbono);
             }          
         }
         public void cargarTabla(List<Entidad> miLista)
         {
             DataTable table = new DataTable();
             table.Columns.Add("Nro.Cuota", typeof(int));
             table.Columns.Add("Fecha Abono", typeof(string));
             table.Columns.Add("Abono", typeof(double));
             table.Columns.Add("Deuda Actual", typeof(double));
             int numeroCuota = 1;

             foreach (Entidad abonar in miLista)
             {
                 table.Rows.Add(numeroCuota, (abonar as Abono).FechaAbono, (abonar as Abono).MontoAbono, (abonar as Abono).Deuda);
                 numeroCuota++;
             }

             _vista.GridView2Abono.DataSource = table;
             _vista.GridView2Abono.DataBind();
         }

         public void pageLoadAbonar2()
         {

             _vista.Falla.Visible = false;
             _vista.Exito.Visible = false;

             //string cuentaCodigo = Convert.ToString((Request.QueryString["cuentaCodigo"] != null) ? Request.QueryString["cuentaCodigo"] : "");
             string cuentaCodigo =_vista.Requestabono2("cuentaCodigo");
             //string fechaEmision = Convert.ToString((Request.QueryString["fechaEmision"] != null) ? Request.QueryString["fechaEmision"] : "");
             string fechaEmision = _vista.Requestabono2("fechaEmision");
             //string montoDeuda = Convert.ToString((Request.QueryString["montoDeuda"] != null) ? Request.QueryString["montoDeuda"] : "");
             string montoDeuda = _vista.Requestabono2("montoDeuda");
             //string proveedor = Convert.ToString((Request.QueryString["proveedor"] != null) ? Request.QueryString["proveedor"] : "");
             string proveedor = _vista.Requestabono2("proveedor");
             _vista.LabelcuentaCodigo.Text = cuentaCodigo;

             //mostrar el monto inicial  de la deuda:
             _vista.LabelmontoDeuda.Text = montoDeuda;

             _vista.Labelproveedor.Text = proveedor;

             Int64 cuenta = Convert.ToInt64(cuentaCodigo);
             //miCuenta = miLogicaCuentaPorPagar.llenarAbonarCpp2(proveedor, cuenta);
             _listaComando1 = FabricaComando.CrearComandollenarAbonarCpp2(proveedor, cuenta);
             _milistaCpp1 = _listaComando1.Ejecutar();


             (_milistaCpp1 as CuentaPorPagar).MontoInicialDeuda = Convert.ToDouble(montoDeuda);

             //resta= monto inicial deuda - suman de los abonos: ahota en el atributo .MontoActualDeuda estara la deuda de hoy.
             (_milistaCpp1 as CuentaPorPagar).CalcularDeudaActual((_milistaCpp1 as CuentaPorPagar).ListaAbono.ElementAt(0).MontoAbono);

             //resto de los labels:
             _vista.LabelBanco.Text = (_milistaCpp1 as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).Banco.NombreBanco.ToString();
             _vista.LabelNumeroCuenta.Text = (_milistaCpp1 as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).NroCuentaBanco.ToString();
             //mostrar el monto actual de la deuda:
             _vista.Labeldeudafinal.Text = (_milistaCpp1 as CuentaPorPagar).MontoActualDeuda.ToString();
             _vista.LabeltipoPago.Text = (_milistaCpp1 as CuentaPorPagar).TipoPago.ToString();

             //listaAbono = miLogicaAbono.llenarGridAbonos(proveedor, cuenta);
             _listaComando = FabricaComando.CrearComandollenarGridAbonos(proveedor, cuenta);
             _milistaCpp = _listaComando.Ejecutar();
             cargarTabla(_milistaCpp);

         }


         public void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
         {
             string cuentaCodigo = _vista.Requestabono2("cuentaCodigo");
             string fechaEmision = _vista.Requestabono2("fechaEmision");
             string montoDeuda = _vista.Requestabono2("montoDeuda");
             string proveedor = _vista.Requestabono2("proveedor");
             _vista.LabelcuentaCodigo.Text = cuentaCodigo;
             Int64 cuenta = Convert.ToInt64(cuentaCodigo);
             _vista.GridView2Abono.PageIndex = e.NewPageIndex;
             _listaComando = FabricaComando.CrearComandollenarGridAbonos(proveedor, cuenta);
             _milistaCpp = _listaComando.Ejecutar();
             cargarTabla(_milistaCpp);

         }
         #endregion
    }
}
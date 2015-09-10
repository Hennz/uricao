using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.Entidades.EBancos;
using Uricao.Entidades.EAbonos;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorPagar;
using Uricao.LogicaDeNegocios.Clases.LNAbono;
using System.Drawing;
using Uricao.Presentacion.Presentador.PCuentasPorPagar;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;



namespace Uricao.Presentacion.PaginasWeb.PCuentasPorPagar
{
    public partial class ConsultarCuentasPorPagar2 : System.Web.UI.Page, IContratoConsultarCuentasPorPagar2
    {
         private PresentadorConsultarCuentasPorPagar2 _presentador;
        public ConsultarCuentasPorPagar2()
        {
            _presentador = new PresentadorConsultarCuentasPorPagar2(this);
        }
        //Atributos:
        List<Abono> listaAbono = new List<Abono>();
        CuentaPorPagar miCuenta = new CuentaPorPagar();
        LogicaCuentaPorPagar miLogicaCuentaPorPagar = new LogicaCuentaPorPagar();
        LogicaAbono miLogicaAbono = new LogicaAbono();
        Abono miAbono = new Abono();
        //CuentaPorPagar miCuentaPP = new CuentaPorPagar();
        Banco miBanco = new Banco();
        NumeroCuentaBanco miNumeroCuentaBanco = new NumeroCuentaBanco();
        #region Contrato
        public Label LabelcuentaCodigo
        {
            get { return labelcuentaCodigo; }
            set { labelcuentaCodigo = value; }
        }

        public Label Labelproveedor
        {
            get { return labelproveedor; }
            set { labelproveedor = value; }
        }
        public GridView GridView2Abono
        {
            get { return gridView2Abono; }
            set { gridView2Abono = value; }
        }

        public Label LabelBanco
        {
            get { return labelBanco; }
            set { labelBanco = value; }
        }
        public Label LabelNumeroCuenta
        {
            get { return labelNumeroCuenta; }
            set { labelNumeroCuenta = value; }
        }

        public Label LabeltipoPago
        {
            get { return labeltipoPago; }
            set { labeltipoPago = value; }
        }
        public Label Label6
        {
            get { return label6; }
            set { label6 = value; }
        }
        public Label LabelmontoDeuda
        {
            get { return labelmontoDeuda; }
            set { labelmontoDeuda = value; }
        }
        public Label Labeldeudafinal
        {
            get { return labeldeudafinal; }
            set { labeldeudafinal = value; }
        }

        public Label Exito
        {
            get { return exito; }
            set { exito = value; }
        }

        public Label Falla
        {
            get { return falla; }
            set { falla = value; }
        }
        public string Requestconsultar2(string _ruta)
        {
            return Convert.ToString((Request.QueryString[(_ruta)] != null) ? Request.QueryString[_ruta] : "");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            _presentador.pageLoadConsultar2();

        }


        protected void GridView2Abono_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void GridView2Abono_RowCommand(Object sender, GridViewCommandEventArgs e)
        {


        }

        protected void GridView2Abono_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _presentador.GridView2Abono_PageIndexChanging(sender,e);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.Entidades.EAbonos;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorPagar;
using Uricao.LogicaDeNegocios.Clases.LNAbono;
using Uricao.Presentacion.Presentador.PCuentasPorPagar;
using Uricao.Entidades.EProveedores;
using Uricao.LogicaDeNegocios.Clases.LNProveedores;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;

namespace Uricao.Presentacion.PaginasWeb.PCuentasPorPagar
{
    public partial class AbonarCuentasPorPagar2 : System.Web.UI.Page, IContratoAbonarCuentasPorPagar2
    {
        //Atributos:
        private PresentadorAbonarCuentasPorPagar2 _presentador;
        public AbonarCuentasPorPagar2()
        {
            _presentador = new PresentadorAbonarCuentasPorPagar2(this);
        }
      

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

        public TextBox TextBox1
        {
            get { return textBox1; }
            set { textBox1 = value; }
        }
        public Label Falla
        {
            get { return falla; }
            set { falla = value; }
        }
        public Label Exito
        {
            get { return exito; }
            set { exito = value; }
        }

        public string Requestabono2(string _ruta)
        {
           return Convert.ToString((Request.QueryString[(_ruta)] !=null) ? Request.QueryString[_ruta] : "");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.pageLoadAbonar2();
                
            }


        }


        protected void GridView2Abono_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2Abono_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _presentador.GridView1_PageIndexChanging(sender, e);
        }

        

        protected void GridView2Abono_RowCommand(Object sender, GridViewCommandEventArgs e)
        {


        }


        protected void BotonAbonar_Click(object sender, EventArgs e)
        {
            _presentador.OnClickAbonar();  
        }

        protected void BotonCambiarEstado_Click(object sender, EventArgs e)
        {

        }





    }
}
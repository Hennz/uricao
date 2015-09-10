using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EPresupuestoFacturas;
using System.Data;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorCobrar;
using Uricao.Entidades.EBancos;
using Uricao.LogicaDeNegocios.Clases.LNBancos;
using Uricao.Presentacion.Contrato.CCuentasPorCobrar;
using Uricao.Presentacion.Presentador.PCuentasPorCobrar;
using System.Web.SessionState;


namespace Uricao.Presentacion.Vista.VCuentasPorCobrar
{

    public partial class ConsultarCuentaCobrar
    {
        #region Atributos

        private PresentadorConsultarCuentaCobrar _presentador;
        string _tipo;

        #endregion

        #region Constructor

        public ConsultarCuentaCobrar()
        {
            // _presentador = new PresentadorConsultarCuentaCobrar(this);
        }

        #endregion

        #region Contrato
        /*public RadioButtonList radioButtonList1 
       {
            get { return RadioButtonList1; }
            set {  RadioButtonList1=value; }
       }
       public TextBox textCedula 
       {    
           get { return TextCedula; }
           set { TextCedula=value; } 
       }
       public TextBox Datepicker 
       {    
           get { return datepicker;}
           set {  datepicker=value; } 
       }
       public TextBox Datepicker1 
       {    
           get { return datepicker1;}
           set { datepicker1 =value; } 
       }
       public Label Falla { 
           get { return falla;}
           set { falla =value; } 
       }
       public Label exito { 
           get { return Exito;}
           set {  Exito=value; } 
       }
       public HttpSessionState Sesion
       {
           get { return Session; }
       }
       public void SetLabelFalla(String text)
       {
           falla.Text = text;
           falla.Visible = true;
       }

       public void SetLabelExito(String text)
       {
           Exito.Text = text;
           Exito.Visible = true;
       }*/
        #endregion Contrato

        /*#region Metodos

        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.VistaPrincipal();
            }
        }

        public void aceptar_Click(object sender, EventArgs e)
        {

            _presentador.AceptarBoton();
            
        }

        public void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            _presentador.RadioButton();
                       
        }

        protected void TextCedula_TextChanged(object sender, EventArgs e)
        {

        }


    }
        #endregion Metodos*/

    }
}
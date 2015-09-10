using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Clases.LNAbono;

using Uricao.Presentacion.Contrato.CCuentasPorCobrar;
using Uricao.Presentacion.Presentador.PCuentasPorCobrar;
using System.Web.SessionState;

namespace Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar

{
    public partial class AgregarAbono : System.Web.UI.Page, IContratoAgregarAbono
    {

        #region Atributos

        private PresentadorAgregarAbono _presentador;
       
        #endregion

        #region Constructor

        public AgregarAbono()
        {
            _presentador = new PresentadorAgregarAbono(this);
        }

        #endregion

        #region Contrato

        public HttpSessionState Sesion
        {
            get { return Session; }
        }
        public Label label5 
        {
            get { return Label5; }
            set { Label5 = value; }
        }
        public Label label6 
        {
            get { return Label6; }
            set { Label6 = value; }
        }
        public Label label7 
        {
            get { return Label7; }
            set { Label7 = value; }
        }
        public TextBox Datepicker 
        {
            get { return datepicker; }
            set { datepicker = value; }
        }
        public TextBox monto 
        {
            get { return Monto; }
            set { Monto = value; }
        }
        public Label Falla 
        {
            get { return falla; }
            set { falla = value; }
        }

        public Label exito
        {
            get { return Exito; }
            set { Exito = value; }
        }
        

        #endregion Contrato

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                _presentador.VistaPrincipal();
            }

        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            _presentador.AccionBoton();
        }

        #endregion
    }       
       
}

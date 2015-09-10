using System;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.Presentacion.Presentador.PHistoriaPaciente;
using System.Web.SessionState;

namespace Uricao.Presentacion.Vista.VHistoriaPaciente
{
    public partial class AgregarAntecedente : System.Web.UI.Page, IContratoAgregarAntecedente
    {
        private PresentadorAgregarAntecendente _presentador;

        public AgregarAntecedente()
        {
            _presentador = new PresentadorAgregarAntecendente(this);
        }

        public void SetLabelFalla(String text)
        {
            falla.Text = text;
            falla.Visible = true;
        }

        public void SetLabelExito(String text)
        {
            Exito.Text = text;
        }

        public RadioButtonList Respuesta1
        {
            get { return RadioButtonList1; }
            set { RadioButtonList1 = value; }
        }

        public RadioButtonList Respuesta2
        {
            get { return RadioButtonList2; }
            set { RadioButtonList3 = value; }
        }

        public RadioButtonList Respuesta3
        {
            get { return RadioButtonList3; }
            set { RadioButtonList3 = value; }
        }

        public RadioButtonList Respuesta4
        {
            get { return RadioButtonList4; }
            set { RadioButtonList4 = value; }
        }

        public RadioButtonList Respuesta5
        {
            get { return RadioButtonList5; }
            set { RadioButtonList5 = value; }
        }

        public RadioButtonList Respuesta6
        {
            get { return RadioButtonList6; }
            set { RadioButtonList9 = value; }
        }

        public RadioButtonList Respuesta7
        {
            get { return RadioButtonList7; }
            set { RadioButtonList7 = value; }
        }

        public RadioButtonList Respuesta8
        {
            get { return RadioButtonList8; }
            set { RadioButtonList8 = value; }
        }

        public RadioButtonList Respuesta9
        {
            get { return RadioButtonList9; }
            set { RadioButtonList9 = value; }
        }

        public RadioButtonList Respuesta10
        {
            get { return RadioButtonList10; }
            set { RadioButtonList10 = value; }
        }

        public RadioButtonList Respuesta11
        {
            get { return RadioButtonList11; }
            set { RadioButtonList11 = value; }
        }

        public RadioButtonList Respuesta12
        {
            get { return RadioButtonList12; }
            set { RadioButtonList12 = value; }
        }

        public RadioButtonList Respuesta13
        {
            get { return RadioButtonList13; }
            set { RadioButtonList13 = value; }
        }

        public RadioButtonList Respuesta14
        {
            get { return RadioButtonList14; }
            set { RadioButtonList14 = value; }
        }

        public RadioButtonList Respuesta15
        {
            get { return RadioButtonList15; }
            set { RadioButtonList15 = value; }
        }

        public DropDownList Respuesta16
        {
            get { return DropDownList1; }
            set { DropDownList1 = value; }
        }

        public DropDownList Respuesta17
        {
            get { return DropDownList2; }
            set { DropDownList2 = value; }
        }

        public DropDownList Respuesta18
        {
            get { return DropDownList3; }
            set { DropDownList3 = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
           
        }

        public HttpSessionState Sesion
        {
            get { return Session; }
        }

        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        }        

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            falla.Visible = false;
            if (_presentador.validarDatos())
            {
                Session["listaRespuestas"] = _presentador.PasarListaRespuestas();
                Redireccionar("/Presentacion/Vista/VHistoriaPaciente/AgregarHistoriaClinica.aspx");
            }
        }
    }
}
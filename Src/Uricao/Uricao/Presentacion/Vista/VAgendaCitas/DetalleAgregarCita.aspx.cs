using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EAgendaCitas;
using Uricao.Presentacion.Contrato.CAgendaCitas;
using Uricao.Presentacion.Presentador.PAgendaCitas;

namespace Uricao.Presentacion.PaginasWeb.PAgendaCitas
{
    public partial class DetalleAgregarCita : System.Web.UI.Page, IContratoDetalleAgregarCita
    {
        #region Atributos


        private PresentadorDetalleAgregarCita _presentador;
        String _fecha;
        String _horai;
        String _horaf;
        String _nombre;
        String _apellido;
        String _tratamiento;
        String _cedulaPaciente;
        #endregion


        #region Constructor
         
        public DetalleAgregarCita()
        {
            _presentador = new PresentadorDetalleAgregarCita(this);
        }

        #endregion


        #region Propiedades
        public Label LabelNombreMedico
        {
            get { return labelNombreMedico; }
            set { labelNombreMedico = value; }
        }
        public Label LabelFechaCita
        {
            get { return labelFechaCita; }
            set { labelFechaCita = value; }
        }
        public Label LabelHoraInicio_Campo
        {
            get { return labelHoraInicio_Campo; }
            set { labelHoraInicio_Campo = value; }
        }
        public Label LabelHoraFin_Campo
        {
            get { return labelHoraInicio_Campo; }
            set { labelHoraInicio_Campo = value; }
        }
        public Label LabelNombreTratamiento
        {
            get { return labelNombreTratamiento; }
            set { labelNombreTratamiento = value; }
        }
        public TextBox ATBCiPaciente
        {
            get { return aTBCiPaciente; }
            set { aTBCiPaciente = value; }
        }
        public Label MensajeDeTransaccion
        {
            get { return mensajeDeTransaccion; }
            set { mensajeDeTransaccion = value; }
        }
        public Button ABAceptar
        {
            get { return aBAceptar; }
            set { aBAceptar = value; }
        }
        #endregion


        #region Metodos
        protected void Page_Load(object sender, EventArgs e)
        {
            _fecha = Convert.ToString(Session["fecha"]);
            _horai = Convert.ToString(Session["horai"]);
            _horaf = Convert.ToString(Session["horaf"]);
            _nombre = Convert.ToString(Session["nombre"]);
            _apellido = Convert.ToString(Session["apellido"]);
            _tratamiento = Convert.ToString(Session["tratamiento"]); labelFechaCita.Text = _fecha;

            labelNombreMedico.Text = _nombre + " " + _apellido;
            labelNombreTratamiento.Text = _tratamiento;
            labelHoraInicio_Campo.Text =_horai + ":00";
            labelHoraFin_Campo.Text = _horaf + ":00";
        }


        public void Mensaje(int valorMensaje, String mensaje)
        {
            _presentador.MensajeDeError(valorMensaje, mensaje);
        }

        
        
        protected void aBAceptar_Click(object sender, EventArgs e)
        {
            _cedulaPaciente = ATBCiPaciente.Text;
            int horainuevo = Convert.ToInt16(_horai);
            int horafnuevo = Convert.ToInt16(_horaf);

            try
            {
                DateTime fechanueva = DateTime.ParseExact(_fecha, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                Cita _cita = new Cita(fechanueva, horainuevo, horafnuevo, _nombre, _apellido, _tratamiento);

                _presentador.AgregarCita(_cita, _cedulaPaciente);
            }
            catch (FormatException ex){
                    Mensaje(0, "");
            }

        }

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EAgendaCitas;
using System.Data;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Presentador.PAgendaCitas;
using Uricao.Presentacion.Contrato.CAgendaCitas;

namespace Uricao.Presentacion.PaginasWeb.PAgendaCitas
{
    public partial class ConsultarCita : System.Web.UI.Page, IContratoConsultarCita
    {
        #region Atributos


        private PresentadorConsultarCita _presentador;

        #endregion

        #region Constructor
         
        public ConsultarCita()
        {
            _presentador = new PresentadorConsultarCita(this);
        }

        #endregion

        #region Propiedades

        public TextBox ATBNombre
        {
            get { return aTBNombre; }
            set { aTBNombre = value; }
        }

        public TextBox ATBApellido
        {
            get { return aTBApellido; }
            set { aTBApellido = value; }
        }

        public TextBox ATBFecha
        {
            get { return aTBFecha; }
            set { aTBFecha = value; }
        }

        public TextBox ATBFechaRangoInicio
        {
            get { return aTBFechaRangoInicio; }
            set { aTBFechaRangoInicio = value; }
        }

        public TextBox ATBFechaRangoFin
        {
            get { return aTBFechaRangoFin; }
            set { aTBFechaRangoFin = value; }
        }

        public GridView GridViewCitasDisponibles
        {
            get { return gridViewCitasDisponibles; }
            set { gridViewCitasDisponibles = value; }
        }

        public Label MensajeDeTransaccion
        {
            get { return mensajeDeTransaccion; }
            set { mensajeDeTransaccion = value; }
        }
        
        public TextBox ATBCiPaciente
        {
            get { return aTBCiPaciente; }
            set { aTBCiPaciente = value; }
        }

        public RadioButton ARBMedico
        {
            get { return aRBMedico;}
            set { aRBMedico = value; }
        }

        public RadioButton ARBFecha
        {
            get { return aRBFecha; }
            set { aRBFecha = value; }
        }
        public RadioButton ARBFechaRango
        {
            get { return aRBFechaRango; }
            set { aRBFechaRango = value; }
        }

        public RadioButton ARBCiPaciente
        {
            get { return aRBCiPaciente; }
            set { aRBCiPaciente = value; }
        }
       

        #endregion


        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.InicializarVista();
                aTBApellido.Enabled = false;
                aTBNombre.Enabled = false;
                aTBFechaRangoInicio.Enabled = false;
                aTBFechaRangoFin.Enabled = false;
                aTBCiPaciente.Enabled = false;
                aTBFecha.Enabled = false;
            }
        }


        protected void GridViewCitasDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridViewCitasDisponibles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }


        protected void GridViewCitasDisponibles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            String direccionRedirigir = "DetalleConsultarCita.aspx";
            String datosCita = _presentador.RowCommandGridView(e.CommandName, e.CommandArgument);
            if (datosCita != "")
            {
                char[] charsToTrim = { '&' };
                String[] datosCitaArray = datosCita.Split(charsToTrim);
                Session["fecha"] = datosCitaArray[0];
                Session["horai"] = datosCitaArray[1];
                Session["horaf"] = datosCitaArray[2];
                Session["nombre"] = datosCitaArray[3];
                Session["apellido"] = datosCitaArray[4];
                Session["tratamiento"] = datosCitaArray[5];
                Response.Redirect(direccionRedirigir);
            }

        }

        public void Mensaje(int valorMensaje, String mensaje)
        {
            _presentador.MensajeError(valorMensaje, mensaje);
        }



        protected void defaultButton_Click(object sender, EventArgs e)
        {
            _presentador.AccionBotonConsultar();
        }
        #endregion



        #region Eventos
        protected void aRBMedico_CheckedChanged(object sender, EventArgs e)
        {
            aTBFecha.Text = "";
            aTBFechaRangoInicio.Text = "";
            aTBFechaRangoFin.Text = "";
            aTBCiPaciente.Text = "";
            aTBFecha.Enabled = false;
            aTBFechaRangoInicio.Enabled = false;
            aTBFechaRangoFin.Enabled = false;
            aTBCiPaciente.Enabled = false;
            aTBApellido.Enabled = true;
            aTBNombre.Enabled = true;
            gridViewCitasDisponibles.DataSource = null;
            gridViewCitasDisponibles.DataBind();
            
            aRFVnombre.Enabled = true;
            aRFVapellido.Enabled = true;
            aRFVpaciente.Enabled = false;
            
        }

        protected void aRBFecha_CheckedChanged(object sender, EventArgs e)
        {
            aTBApellido.Text = "";
            aTBNombre.Text = "";
            aTBFechaRangoInicio.Text = "";
            aTBFechaRangoFin.Text = "";
            aTBCiPaciente.Text = "";
            aTBApellido.Enabled = false;
            aTBNombre.Enabled = false;
            aTBFechaRangoInicio.Enabled = false;
            aTBFechaRangoFin.Enabled = false;
            aTBCiPaciente.Enabled = false;
            aTBFecha.Enabled = true;
            gridViewCitasDisponibles.DataSource = null;
            gridViewCitasDisponibles.DataBind();

            aRFVnombre.Enabled = false;
            aRFVapellido.Enabled = false;
            aRFVpaciente.Enabled = false;
            
        }

        protected void aRBFechaRango_CheckedChanged(object sender, EventArgs e)
        {
            aTBApellido.Text = "";
            aTBNombre.Text = "";
            aTBFecha.Text = "";
            aTBCiPaciente.Text = "";
            aTBApellido.Enabled = false;
            aTBNombre.Enabled = false;
            aTBFecha.Enabled = false;
            aTBCiPaciente.Enabled = false;
            aTBFechaRangoInicio.Enabled = true;
            aTBFechaRangoFin.Enabled = true;
            gridViewCitasDisponibles.DataSource = null;
            gridViewCitasDisponibles.DataBind();

            aRFVnombre.Enabled = false;
            aRFVapellido.Enabled = false;
            aRFVpaciente.Enabled = false;
            
        }

        protected void aRBCiPaciente_CheckedChanged(object sender, EventArgs e)
        {
            aTBApellido.Text = "";
            aTBNombre.Text = "";
            aTBFechaRangoInicio.Text = "";
            aTBFechaRangoFin.Text = "";
            ATBFecha.Text = "";
            aTBApellido.Enabled = false;
            aTBNombre.Enabled = false;
            aTBFechaRangoInicio.Enabled = false;
            aTBFechaRangoFin.Enabled = false;
            ATBFecha.Enabled = false;
            aTBCiPaciente.Enabled = true;
            gridViewCitasDisponibles.DataSource = null;
            gridViewCitasDisponibles.DataBind();

            aRFVnombre.Enabled = false;
            aRFVapellido.Enabled = false;
            aRFVpaciente.Enabled = true;
            
        }
        #endregion


    }
}
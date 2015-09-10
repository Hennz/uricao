using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using System.Web.SessionState;
using Uricao.Presentacion.Presentador.PHistoriaPaciente;

namespace Uricao.Presentacion.Vista.VHistoriaPaciente
{
    public partial class DetalleOdontograma : System.Web.UI.Page, IContratoDetalleOdontodiagrama
    {

        private PresentadorDetalleOdontodiagrama _presentador;

        public DetalleOdontograma()
        {
             _presentador = new PresentadorDetalleOdontodiagrama(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.PintarDatos();
            }

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
        }

        public Label Medico
        {
            get { return medico; }
            set { medico = value; }
        }

        public Label Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Label Pieza
        {
            get { return pieza; }
            set { pieza = value; }
        }

        public Label Tratamiento
        {
            get { return tratamiento; }
            set { tratamiento = value; }
        }
        public Label Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        public Label Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {

        }
    }
}
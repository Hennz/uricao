using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.Presentacion.Presentador.PHistoriaPaciente;
using System.Web.SessionState;

namespace Uricao.Presentacion.Vista.VHistoriaPaciente
{
    public partial class ModificarHistoriaClinica : System.Web.UI.Page, IContratoModificarHistoriaClinica
    {
        private PresentadorModificarHistoriaClinica _presentador;
   

        public ModificarHistoriaClinica()
        {
            _presentador = new PresentadorModificarHistoriaClinica(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                _presentador.LlenarDatos();

            }
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            if (_presentador.Editar())
                modificar.Visible = true;
        }

        public DropDownList Combo
        {
            get { return ComboClientes; }
            set { ComboClientes = value; }
        }


        public TextBox Fecha
        {
            get { return date; }
            set { date = value; }
        }

        public TextBox Observacion
        {
            get { return TObservaciones; }
            set { TObservaciones = value; }
        }


        public GridView GridConsultar1
        {
            get { return GridConsultar; }
            set { GridConsultar = value; }

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

        public HttpSessionState Sesion
        {
            get { return Session; }
        }


    }
}
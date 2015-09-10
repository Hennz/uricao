using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Presentador.PAgendaCitas;
using Uricao.Presentacion.Contrato.CAgendaCitas;

namespace Uricao.Presentacion.Vista.VAgendaCitas
{
    public partial class ConfirmacionAccionCita : System.Web.UI.Page, IContratoConfirmacionAccionCita
    {

        #region Atributos

        private PresentadorConfirmacionAccionCita _presentador;
        private int _idCita;

        #endregion

        #region Constructor

        public ConfirmacionAccionCita()
        {
            _presentador = new PresentadorConfirmacionAccionCita(this);
        }

        #endregion

        #region Propiedades

        public Button Cancelar
        {
            get { return aBCancelar; }
            set { aBCancelar = value; }
        }
        public Button Aceptar
        {
            get { return aBRealizar; }
            set { aBCancelar = value; }
        }
        public Label AccionRealizar
        {
            get { return aLConfirmar; }
            set { aLConfirmar = value; }
        }


        #endregion

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {

            String _StringidCita = Convert.ToString(Session["idCita"]);
            String _StringAccion = Convert.ToString(Session["AccionConfirmarCancelar"]);
            _idCita = Convert.ToInt32(_StringidCita);

            _presentador.Accion = Convert.ToInt32(_StringAccion);
            _presentador.AccionAConfirmar();

        }

        #endregion

        protected void aBRealizar_Click(object sender, EventArgs e)
        {
            _presentador.RealizarAccion(_idCita);
        }

        protected void aBCancelar_Click(object sender, EventArgs e)
        {
            _presentador.RealizarAccion(_presentador.Accion);
        }




    }
}
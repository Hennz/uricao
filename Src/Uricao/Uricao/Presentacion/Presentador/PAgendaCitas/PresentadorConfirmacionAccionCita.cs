using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CAgendaCitas;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Fabricas;

namespace Uricao.Presentacion.Presentador.PAgendaCitas
{
    public class PresentadorConfirmacionAccionCita
    {
        #region Atributos
        private IContratoConfirmacionAccionCita _vista;
        //private Comando<List<Entidad>> _comando;
        private int _accion;
        #endregion


        #region Constructor
        public PresentadorConfirmacionAccionCita(IContratoConfirmacionAccionCita _vista)
        {
            this._vista = _vista;
        }
        #endregion

        #region Metodos
        public int Accion
        {
            get { return _accion; }
            set { _accion = value; }

        }
        public void AccionAConfirmar()
        {
            if (_accion == 1)
                _vista.AccionRealizar.Text = "Confirmar la Cita";
            else
                _vista.AccionRealizar.Text = "Cancelar la Cita";

        }

        public void RealizarAccion(int idCita)
        {
            if (_accion == 1)
            {
                ComandoConfirmarCita _comando = FabricaComando.CrearComandoConfirmarCita(idCita);
                _comando.Ejecutar();
            }
            else
            {
                ComandoCancelarCita _comando = FabricaComando.CrearComandoCancelarCita(idCita);
                _comando.Ejecutar();
            }

        }


        #endregion

    }
}
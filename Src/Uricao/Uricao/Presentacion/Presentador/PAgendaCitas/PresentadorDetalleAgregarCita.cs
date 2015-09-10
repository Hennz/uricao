using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Presentacion.Contrato.CAgendaCitas;

namespace Uricao.Presentacion.Presentador.PAgendaCitas
{
    public class PresentadorDetalleAgregarCita
    {
        #region Atributos
        private IContratoDetalleAgregarCita _vista;
        #endregion



        #region Constructor

        public PresentadorDetalleAgregarCita(IContratoDetalleAgregarCita _vista)
        {
            this._vista = _vista;
        }
        #endregion



        #region Metodos

        public void MensajeDeError(int valorMensaje, String mensaje)
        {
            if (valorMensaje == 1)
            {
                _vista.MensajeDeTransaccion.Text = "Su cita fue procesada con exito";

                _vista.MensajeDeTransaccion.Visible = true;

            }
            else
            {
                if (valorMensaje == 0)
                {
                    _vista.MensajeDeTransaccion.Text = "Su cita no pudo ser procesada." + mensaje;

                    _vista.MensajeDeTransaccion.Visible = true;
                }
            }
        }


        public String ManejoDiaFecha(DateTime _fecha)
        {
            String _diaSemana = _fecha.DayOfWeek.ToString();
            if ((_diaSemana == "Domingo") || (_diaSemana == "Sunday"))
            {
                return "Domingo";
            }
            else if ((_diaSemana == "Lunes") || (_diaSemana == "Monday"))
            {
                return "Lunes";
            }
            else if ((_diaSemana == "Martes") || (_diaSemana == "Tuesday"))
            {
                return "Martes";
            }
            else if ((_diaSemana == "Miercoles") || (_diaSemana == "Wednesday"))
            {
                return "Miercoles";
            }
            else if ((_diaSemana == "Jueves") || (_diaSemana == "Thursday"))
            {
                return "Jueves";
            }
            else if ((_diaSemana == "Viernes") || (_diaSemana == "Friday"))
            {
                return "Viernes";
            }
            else if ((_diaSemana == "Sabado") || (_diaSemana == "Saturday"))
            {
                return "Sabado";
            }
            else
            {
                return "";
            }

        }



        public void AgregarCita(Cita cita, String cedulaPaciente)
        {
            DateTime _fecha = DateTime.ParseExact(_vista.LabelFechaCita.Text, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String diaSemana = ManejoDiaFecha(_fecha);
            ComandoAgregarCita comando =  FabricaComando.CrearComandoAgregarCita(cita, cedulaPaciente, diaSemana);
            bool _resultado = comando.Ejecutar();
            if (_resultado == true)
            {
                MensajeDeError(1, "");
                _vista.ATBCiPaciente.Enabled = false;
                _vista.ABAceptar.Visible = false;
            }
            else
            {
                MensajeDeError(0, "");
            }
        }


        #endregion
    }
}
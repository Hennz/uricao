using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CAgendaCitas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Comandos.AgendaCitas;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.LogicaDeNegocios.Fabricas;

namespace Uricao.Presentacion.Presentador.PAgendaCitas
{
    public class PresentadorDetalleFinalModificarCita
    {
         #region Atributos

        private IContratoDetalleFinalModificarCita _vista;
        private String _diaSemanaFecha;
        //private Comando<List<Entidad>> _comando;
        //private List<Cita> listaCitas;
        private static List<Entidad> listaCitas;

        #endregion


        #region Constructor

        public PresentadorDetalleFinalModificarCita(IContratoDetalleFinalModificarCita _vista)
        {
            this._vista = _vista;
        }

        #endregion

        #region Metodos

        public void PublicarDatosLabels()
        {
            _vista.LabelConfirmacionCita.Text = "No Confirmada";
            _vista.LabelStatusCita.Text = "Activa";
            _vista.LabelFechaCita.Text = _vista.Fecha;
            _vista.LabelHoraCita.Text = _vista.Horai.ToString() + ":00 - " + _vista.Horaf.ToString() + ":00";
            _vista.LabelNombreMedico.Text = _vista.Nombre + " " + _vista.Apellido;
            _vista.LabelNombreTratamiento.Text = _vista.Tratamiento;
        
        }


        public void ModificarCita()
        {
            DateTime _fecha = DateTime.ParseExact(_vista.Fecha, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            _diaSemanaFecha = ManejoDiaFecha(_fecha);
            Comando<bool>  _comando = FabricaComando.CrearComandoModificarCita(Convert.ToInt32(_vista.IdCita), _fecha.ToString("yyyy-MM-dd"), _vista.Horai, _vista.Horaf, _vista.Tratamiento, _vista.Nombre, _vista.Apellido, _diaSemanaFecha);
            bool resultado = _comando.Ejecutar();
            if (resultado == true)
            {
                MensajeDeError(1, "");
            }
            else 
            {
                MensajeDeError(2, "");
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


        public void MensajeDeError(int valorMensaje, String mensaje)
        {
            if (valorMensaje == 1)
            {
                _vista.MensajeDeTransaccion.Text = "Su cita fue Modificada con exito";

                _vista.MensajeDeTransaccion.Visible = true;

            }
            else
            {
                if (valorMensaje == 2)
                {
                    _vista.MensajeDeTransaccion.Text = "No se pudo realizar la operacion" + mensaje;

                    _vista.MensajeDeTransaccion.Visible = true;
                }
            }
        }
        #endregion

    }
}
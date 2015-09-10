using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.AgendaCitas
{
    public class ComandoConsultarHorarioDisponibleMedicoFecha : Comando<int []>
    {

        #region Atributos

        private String _nombreMedico;
        private String _apellidoMedico;
        private DateTime _fecha;
        private String _tratamiento;
        private String _diaSemana;
        
        #endregion


        #region Constructor
        public ComandoConsultarHorarioDisponibleMedicoFecha()
        { 
        
        }

        public ComandoConsultarHorarioDisponibleMedicoFecha(String paramNombreMedico, String paramApellidoMedico, DateTime paramFecha, String paramTratamiento, String paramDiaSemana)
        {
            this._nombreMedico = paramNombreMedico;
            this._apellidoMedico = paramApellidoMedico;
            this._fecha = paramFecha;
            this._tratamiento = paramTratamiento;
            this._diaSemana = paramDiaSemana;
        }
        #endregion


        #region Metodos
        public override int [] Ejecutar()
        {
            int[] _horariomedico = new int[3];
            _horariomedico = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAgendaCitas().ConsultarHorarioMedicoUnaFecha(_nombreMedico, _apellidoMedico, _diaSemana, _tratamiento);
            List<Entidad> _listaCitasActuales = null;
            _listaCitasActuales = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAgendaCitas().ConsultarCitasActualesUnaFecha(_nombreMedico, _apellidoMedico, _fecha);

            int iteradorHora;
            int _horaInicioMedico;
            int _horaFinMedico;
            int _duracionTratamiento;
            iteradorHora = 0;
            _horaInicioMedico = _horariomedico[0];
            _horaFinMedico = _horariomedico[1];
            _duracionTratamiento = _horariomedico[2];
            int[] _citasLibres = new int[8];



            int j = 0;
            int _citaActual;
            int numeroCitasOcupadas = _listaCitasActuales.Count;
            bool horaOcupada;

            for (iteradorHora = _horaInicioMedico; iteradorHora < _horaFinMedico; )
            {
                horaOcupada = false;
                foreach (Entidad cita in _listaCitasActuales)
                {
                    int _horaInicioCita = (cita as Cita)._HoraInicio;
                    int _horaFinCita = (cita as Cita)._HoraFin;
                    if ((iteradorHora <= _horaInicioCita) || (iteradorHora + _duracionTratamiento <= _horaFinCita))
                    {
                        horaOcupada = true;
                    }
                }

                if (horaOcupada == false)
                {
                    _citasLibres[j] = iteradorHora;
                }
                else
                {
                    _citasLibres[j] = 0;
                }
                iteradorHora = iteradorHora + _duracionTratamiento;
                j++;
            }



            return _citasLibres;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;
namespace Uricao.LogicaDeNegocios.Comandos
{
    public class ComandoModificarCita : Comando<bool>
    {
        #region Atributos
        int _idCita; 
        String _fecha; 
        int _horaInicio; 
        int _horaFin;
        String _tratamiento;
        String _nombreMedico;
        String _apellidoMedico;
        String _diaSemana;

        #endregion

        #region constructor
        public ComandoModificarCita()
        { 
        
        }

        public ComandoModificarCita(int paramIdCita, String paramFecha, int paramHoraInicio, int paramHoraFin, String paramtratamiento, String paramNombreMedico, String paramApellidoMedico, String paramDiaSemana)
        {
            this._idCita =paramIdCita;
            this._fecha = paramFecha;
            this._horaInicio = paramHoraInicio;
            this._horaFin = paramHoraFin;
            this._tratamiento = paramtratamiento;
            this._nombreMedico = paramNombreMedico;
            this._apellidoMedico = paramApellidoMedico;
            this._diaSemana = paramDiaSemana;

        }
        #endregion

        #region Metodos
        public override bool Ejecutar()
        {
            
            bool resultado =FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAgendaCitas().ModificarCita( _idCita, _fecha, _horaInicio,  _horaFin, _tratamiento, _nombreMedico, _apellidoMedico, _diaSemana);
            return resultado;
        }
        

        #endregion

    }
}
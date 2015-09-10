using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.Entidades.ETratamientos;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos
{
    public class ComandoAgregarCita : Comando<bool>
    {
        #region Atributos
        private Cita _cita;
        private String _cedulaPaciente;
        private String _diaSemana;
        #endregion

        #region Constructor
        public ComandoAgregarCita(Cita _cita, String _cedulaPaciente, String _diaSemana)
        {
            this._cita = _cita;
            this._cedulaPaciente = _cedulaPaciente;
            this._diaSemana = _diaSemana;
        }
        #endregion


        #region Metodos
        public override bool Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAgendaCitas().AgregarCita(_cita, _cedulaPaciente, _diaSemana);
        }



        #endregion

    }
}
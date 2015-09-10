using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos
{
    public class ComandoCancelarCita : Comando<bool>
    {

        #region Atributos
        private int _idCita;
        #endregion

        #region Constructor
        public ComandoCancelarCita(int _idCita)
        {
            this._idCita = _idCita;
        }
        #endregion


        #region Metodos
        public override bool Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAgendaCitas().CancelarCita(_idCita);
        }

        #endregion
    }
}
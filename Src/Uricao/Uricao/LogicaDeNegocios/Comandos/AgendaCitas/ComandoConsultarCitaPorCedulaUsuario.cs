using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.AgendaCitas
{
    public class ComandoConsultarCitaPorCedulaUsuario : Comando<List<Entidad>>
    {
        #region Atributos
        private String _cedulaPaciente;
        #endregion

        #region Constructor
        public ComandoConsultarCitaPorCedulaUsuario(String _cedulaPaciente)
        {
            this._cedulaPaciente = _cedulaPaciente;
        }
        #endregion

        #region Metodos

        public override List<Entidad> Ejecutar()
        {
            List<Entidad> _citasPaciente = null;
            _citasPaciente = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAgendaCitas().ConsultarCitaPorCedulaUsuario(_cedulaPaciente);


            return _citasPaciente;
        }

        #endregion


    }
}
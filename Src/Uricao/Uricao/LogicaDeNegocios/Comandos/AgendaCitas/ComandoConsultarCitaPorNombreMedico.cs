using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.AgendaCitas
{
    public class ComandoConsultarCitaPorNombreMedico : Comando<List<Entidad>>
    {
        #region Atributos
        private String _nombre;
        private String _apellido;
        #endregion

        #region Constructor
        public ComandoConsultarCitaPorNombreMedico(String _nombreMedico, String _apellidoMedico)
        {
            this._nombre = _nombreMedico;
            this._apellido =  _apellidoMedico;
        }
        #endregion

        #region Metodos

        public override List<Entidad> Ejecutar()
        {
            List<Entidad> _citasPaciente = null;
            _citasPaciente = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAgendaCitas().ConsultarCitaPorNombreMedico(_nombre, _apellido);


            return _citasPaciente;
        }

        #endregion


    }
}
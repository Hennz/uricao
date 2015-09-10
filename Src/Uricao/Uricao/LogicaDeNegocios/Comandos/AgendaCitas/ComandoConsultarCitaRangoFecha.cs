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
    public class ComandoConsultarCitaRangoFecha : Comando< List<Entidad>>
    {
       #region Atributos

        private String _fechaInicio;
        private String _fechaFin;

        #endregion


        #region Constructor
        public ComandoConsultarCitaRangoFecha()
        {

        }

        public ComandoConsultarCitaRangoFecha(String paramFechaInicio, String paramFechaFin)
        {
            this._fechaInicio = paramFechaInicio;
            this._fechaFin = paramFechaFin;
        }
        #endregion


        #region Metodos
        public override List<Entidad> Ejecutar()
        {
            List<Entidad> _citasRangoFecha = null;
            _citasRangoFecha = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAgendaCitas().ConsultarCitaRangoFecha(_fechaInicio,_fechaFin);


            return _citasRangoFecha;
        }

        #endregion


    }
}
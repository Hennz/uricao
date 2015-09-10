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
    public class ComandoConsultarCitaFecha : Comando<List<Entidad>>
    {

        #region Atributos

        private String _fecha;

        #endregion


        #region Constructor
        public ComandoConsultarCitaFecha()
        {

        }

        public ComandoConsultarCitaFecha(String paramFecha)
        {
            this._fecha = paramFecha;
        }
        #endregion


        #region Metodos
        public override List<Entidad> Ejecutar()
        {
            //List<Entidad> _citasUnaFecha = null;
            //_citasUnaFecha = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAgendaCitas().ConsultarCitaUnaFecha(_fecha);

            //return _citasUnaFecha;
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAgendaCitas().ConsultarCitaUnaFecha(_fecha);
        }

        #endregion
    }
}
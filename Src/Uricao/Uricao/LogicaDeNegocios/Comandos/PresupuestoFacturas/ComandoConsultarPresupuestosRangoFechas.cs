using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoConsultarPresupuestosRangoFechas : Comando<List<Entidad>>
    {
        #region Atributos

        private string _fechaInicio;
        private string _fechaFin;

        #endregion

        #region Constructor

        public ComandoConsultarPresupuestosRangoFechas()
        {
        }

        public ComandoConsultarPresupuestosRangoFechas(string fechaInicio, string fechaFin)
        {
            this._fechaInicio = fechaInicio;
            this._fechaFin = fechaFin;
        }
        #endregion


        #region Metodos

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarPresupuestosRangoFechas(_fechaInicio, _fechaFin);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Facturas : " + "", ex);                
            }
        }

        #endregion
    }
}
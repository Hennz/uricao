using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoObtenerListaFacturaFechas : Comando<List<Entidad>>
    {

        #region Atributos

        private string _fechaInicio;
        private string _fechaFin;

        #endregion


        #region Constructor
        public ComandoObtenerListaFacturaFechas()
        {
        }

        public ComandoObtenerListaFacturaFechas(string fechaInicio, string fechaFin)
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
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarFacturasRangoFechas(_fechaInicio, _fechaFin);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Facturas : " + "", ex);                
            }
        }

        #endregion
    }
}
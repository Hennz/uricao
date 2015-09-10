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
    public class ComandoConsultarFacturasNumero : Comando<Entidad>
    {

        #region Atributos

        private int _numeroFactura;

        #endregion


        #region Constructor
        public ComandoConsultarFacturasNumero()
        {
        }

        public ComandoConsultarFacturasNumero(int numeroFactura)
        {
            this._numeroFactura = numeroFactura;
        }

        #endregion


        #region Metodos

        public override Entidad Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarFacturaNumero(_numeroFactura);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Facturas : " + "", ex);                
            }
        }

        #endregion
    }
}
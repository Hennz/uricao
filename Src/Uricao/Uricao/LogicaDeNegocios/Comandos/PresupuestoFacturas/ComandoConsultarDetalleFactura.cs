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
    public class ComandoConsultarDetalleFactura : Comando<List<Entidad>>
    {

        #region Atributos

        private int _nro_factura;

        #endregion


        #region Constructor
        public ComandoConsultarDetalleFactura()
        {
        }

        public ComandoConsultarDetalleFactura(int nro_factura)
        {
            this._nro_factura = nro_factura;
        }
        #endregion


        #region Metodos

        public override List<Entidad> Ejecutar()
        {
            try
            {                
                List<Entidad> _listaDetalle = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarDetalleFactura(_nro_factura);
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarTratamientosListaDetalle(_listaDetalle);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar el detalle de la Factura : " + "", ex);                
            }
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoConsultarDetallePresupuesto : Comando<List<Entidad>>
    {
        #region Atributos

        private int _nroPresupuesto;

        #endregion

        #region Constructor

        public ComandoConsultarDetallePresupuesto()
        {
        }

        public ComandoConsultarDetallePresupuesto(int numeroPresupuesto)
        {
            this._nroPresupuesto = numeroPresupuesto;
        }

        #endregion

        #region Metodos

        public override List<Entidad> Ejecutar()
        {
            try
            {

                //List<Detalle_Presupuesto_Factura> listaDetalle = servidorSQL.ConsultarDetallePresupuesto(nro_presupuesto);
                //return servidorSQL.ConsultarTratamientosListaDetalle(listaDetalle);

                List<Entidad> _listaDetalle = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarDetallePresupuesto(_nroPresupuesto);

                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarTratamientosListaDetalle(_listaDetalle);             

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar los datos básicos del presupuesto : " + "", ex);                
            }
        }

        #endregion
    }
}
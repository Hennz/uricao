using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;


namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoSubtotalFactura: Comando<double>
    {
                  #region Atributos
        private Factura _factura;
        #endregion

        #region Constructor
        public ComandoSubtotalFactura(  Factura factura)
        {
            this._factura = factura;
        }

        public override double Ejecutar()
        {
           //try
            //{
                double subtotal = 0.0;
                foreach (var detalle in _factura.getListado_Factura())
                {
                    subtotal = (subtotal + detalle.Total_pago_tratamiento);
                }

                return subtotal;
            //}
            //catch (ArithmeticException e)
            //{
            //    throw new ExceptionPresupuestoFactura("Error: Problemas con calculos aritmeticos", e);
            //}

            //catch (ExceptionPresupuestoFactura e)
            //{
            //    throw new ExceptionPresupuestoFactura(e.Message);
            //}
            //catch (Exception e)
            //{
            //    throw new ExceptionPresupuestoFactura(e.Message);
            //}
        }
        #endregion
    }
}
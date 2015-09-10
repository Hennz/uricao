using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;

namespace Uricao.PruebasUnitarias.PPresupuestosFacturas
{
    [TestFixture]
    public class PruebasDetalle_Presupuesto_Factura
    {
        [Test]
        public void TestEquals()
        {
            Detalle_Presupuesto_Factura detalleUno = new Detalle_Presupuesto_Factura();
            detalleUno.Cantidad = 3;
            detalleUno.Total_pago_tratamiento = 1500.0;
            Tratamiento tratamiento = new Tratamiento();
            detalleUno.El_Tratamiento = tratamiento;
            Detalle_Presupuesto_Factura detalleDos = new Detalle_Presupuesto_Factura();
            detalleDos.Cantidad = 3;
            detalleDos.Total_pago_tratamiento = 1500.0;
            detalleDos.El_Tratamiento = tratamiento;

            Assert.IsTrue(detalleUno.Equals(detalleDos));
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.Entidades.EPresupuestoFacturas;

namespace Uricao.PruebasUnitarias.PPresupuestosFacturas
{
    [TestFixture]
    public class PruebasFactura
    {
        [Test]
        public void TestEquals()
        {
            Factura facturaUno = new Factura(1, 1500.0, true, "19678162", "V", "20053319", "V", "Juan Perez", 1);
            facturaUno.Fecha_emitida = new DateTime();
            facturaUno.Listado_factura = new List<Detalle_Presupuesto_Factura>();
            
            Assert.IsTrue(facturaUno.Equals(facturaUno));            
        }

        [Test]
        public void TestAddDetalle()
        {
            Factura esperado = new Factura();
            Detalle_Presupuesto_Factura detalle = new Detalle_Presupuesto_Factura();
            detalle.El_Tratamiento = new Entidades.ETratamientos.Tratamiento();
            esperado.Listado_factura.Add(detalle);
            Factura actual = new Factura();
            actual.addDetalle(detalle);

            Assert.IsTrue(actual.Equals(esperado));
        }


    }

}
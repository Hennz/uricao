using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;
using NUnit.Framework;

namespace Uricao.PruebasUnitarias.PPresupuestosYFacturas
{
    [TestFixture]
    public class PruebasPresupuesto
    {
        [Test]
        public void TestEquals()
        {
            Presupuesto presupuestoUno = new Presupuesto(11, 1500.0, new DateTime(2012, 12, 06));
            presupuestoUno.Listado_presupuesto = new List<Detalle_Presupuesto_Factura>();
            presupuestoUno.Observaciones = "";
            Presupuesto presupuestoDos = new Presupuesto(11, 1500.0, new DateTime(2012, 12, 06));
            presupuestoDos.Listado_presupuesto = new List<Detalle_Presupuesto_Factura>();
            presupuestoDos.Observaciones = "";

            Assert.IsTrue(presupuestoUno.Equals(presupuestoDos));
        }


        [Test]
        public void TestAddDetalle()
        {
            Presupuesto esperado = new Presupuesto();
            esperado.Observaciones = "";
            Detalle_Presupuesto_Factura detalle = new Detalle_Presupuesto_Factura();
            detalle.El_Tratamiento = new Entidades.ETratamientos.Tratamiento();
            esperado.Listado_presupuesto.Add(detalle);
            Presupuesto actual = new Presupuesto();
            actual.Observaciones = "";
            actual.addDetalle(detalle);

            Assert.IsTrue(actual.Equals(esperado));
        
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using System.Data;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.ETratamientos;

namespace Uricao.PruebasUnitarias.PPresupuestosFacturas
{
    [TestFixture]
    public class PruebasLogicaFactura
    {
        /*

        [Test]
        public void TestInsertarFactura()
        {
            Factura facturaNueva = new Factura(1, 1500.0, true, "19678162", "V", "20053319", "V", "Juan Perez", 1);
            DateTime fechaNueva = Convert.ToDateTime("05/12/2012");
            facturaNueva.Fecha_emitida = fechaNueva;
            facturaNueva.Listado_factura = new List<Detalle_Presupuesto_Factura>();
            LogicaFactura logica = new LogicaFactura();

            Assert.IsTrue(logica.insertarFactura(facturaNueva));
            List<Factura> listaFacturas = logica.ObtenerListaFacturasCompleta();
            Factura facturaInsertada = null;
            foreach (Factura facturaIndex in listaFacturas)
            {
                if (facturaIndex.Nro_factura == facturaNueva.Nro_factura)
                {
                    facturaInsertada = facturaIndex;
                }
            }

            Assert.IsNotNull(facturaInsertada);
            Assert.IsTrue(facturaNueva.Equals(facturaInsertada));
        }

        [Test]
        public void TestGenerarDetalleFactura()
        {

            Factura facturaNueva = new Factura(1, 1500.0, true, "19678162", "V", "20053319", "V", "Juan Perez", 6);
            DateTime fechaNueva = Convert.ToDateTime("05/12/2012");
            facturaNueva.Fecha_emitida = fechaNueva;
            facturaNueva.Listado_factura = new List<Detalle_Presupuesto_Factura>();
            LogicaFactura logica = new LogicaFactura();
            Assert.IsTrue(logica.GenerarDetalleFactura(facturaNueva, 1));
        }


        [Test]
        public void TestCostoTodoElDetalleSinIva()
        {
            List<Detalle_Presupuesto_Factura> listaDetalle = new List<Detalle_Presupuesto_Factura>();
            Detalle_Presupuesto_Factura detalleUno = new Detalle_Presupuesto_Factura(new Entidades.ETratamientos.Tratamiento(), 300.0, 3);
            Detalle_Presupuesto_Factura detalleDos = new Detalle_Presupuesto_Factura(new Entidades.ETratamientos.Tratamiento(), 200.0, 1);
            Detalle_Presupuesto_Factura detalleTres = new Detalle_Presupuesto_Factura(new Entidades.ETratamientos.Tratamiento(), 100.0, 5);
            listaDetalle.Add(detalleUno);
            listaDetalle.Add(detalleDos);
            listaDetalle.Add(detalleTres);
            LogicaFactura logica = new LogicaFactura();

            Assert.IsNotNull(logica.CostoTodoElDetalleSinIva(listaDetalle));
            Assert.AreEqual(logica.CostoTodoElDetalleSinIva(listaDetalle), 1600.0);
            
        }


        [Test]
        public void TestObtenerListaFacturasCompleta()
        {
            LogicaFactura logica = new LogicaFactura();
            List<Factura> listaFacturas = logica.ObtenerListaFacturasCompleta();

            Assert.IsNotNull(listaFacturas);
            Assert.AreEqual(listaFacturas.Count, 10);
        }


        [Test]
        public void TestObtenerCedulaUsuarioFactura()
        {
            LogicaFactura logica = new LogicaFactura();
            String cedulaObtenida = logica.ObtenerCedulaUsuarioFactura(1);
            String cedulaEsperada = "19720330";

            Assert.IsNotNull(cedulaObtenida);
            Assert.IsTrue(cedulaObtenida.Equals(cedulaEsperada));        
        }


        [Test]
        public void TestCreateDataSetFacturas()
        {
            List<Factura> listaFacturas = new List<Factura>();
            LogicaFactura logica = new LogicaFactura();
            DataSet esperado = new DataSet();
            DataTable dt = new DataTable("FacturasClientes");
            dt.Columns.Add(new DataColumn("NumeroFactura", typeof(string)));
            dt.Columns.Add(new DataColumn("CedulaPaciente", typeof(string)));
            dt.Columns.Add(new DataColumn("FechaEmision", typeof(DateTime)));
            esperado.Tables.Add(dt);

            DataSet obtenido = logica.CreateDataSetFactura(listaFacturas);

            Assert.IsNotNull(obtenido);
            Assert.IsTrue(esperado == obtenido);
        }

        
        [Test]
        public void TestCreateDataSetTratamientosPresupuesto()
        {
            List<Detalle_Presupuesto_Factura> listaDetalle = new List<Detalle_Presupuesto_Factura>();
            LogicaFactura logica = new LogicaFactura();
            DataSet esperado = new DataSet();
            DataTable dt = new DataTable("DetalleFactura");
            dt.Columns.Add(new DataColumn("nombre_tratamiento", typeof(string)));
            dt.Columns.Add(new DataColumn("cantidad", typeof(Int32)));
            dt.Columns.Add(new DataColumn("monto", typeof(float)));
            esperado.Tables.Add(dt);

            DataSet obtenido = logica.CreateDataSetTratamientosPresupuesto(listaDetalle);

            Assert.IsNotNull(obtenido);
            Assert.IsTrue(esperado == obtenido);
        }


        [Test]
        public void TestObtenerPaisFactura()
        {
            LogicaFactura logica = new LogicaFactura();
            String esperado = "Venezuela";
            String obtenido = logica.ObtenerPaisFactura(4);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);
        }


        [Test]
        public void TestObtenerProvinciaFactura()
        {
            LogicaFactura logica = new LogicaFactura();
            String esperado = "Distrito Capital";
            String obtenido = logica.ObtenerProvinciaFactura(4);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);
        }


        [Test]
        public void TestObtenerCiudadFactura()
        {
            LogicaFactura logica = new LogicaFactura();
            String esperado = "Caracas";
            String obtenido = logica.ObtenerCiudadFactura(4);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);
        }


        [Test]
        public void TestObtenerMunicipioFactura()
        {
            LogicaFactura logica = new LogicaFactura();
            String esperado = "Chacao";
            String obtenido = logica.ObtenerMunicipioFactura(4);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);
        }



        [Test]
        public void TestObtenerCalleFactura()
        {
            LogicaFactura logica = new LogicaFactura();
            String esperado = "Sucre";
            String obtenido = logica.ObtenerCalleFactura(4);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);
        }



        [Test]
        public void TestObtenerEdificioFactura()
        {
            LogicaFactura logica = new LogicaFactura();
            String esperado = "La paz - Piso 5 Apto 5A";
            String obtenido = logica.ObtenerEdificioFactura(4);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);
        }


        [Test]
        public void TestRegresarCostoTratamiento()
        {
            LogicaFactura logica = new LogicaFactura();
            Int16 costoEsperado = 0;
            Int16 costoObtenido = logica.RegresarCostoTratamiento(1);

            Assert.AreEqual(costoEsperado, costoObtenido);
        }


        [Test]
        public void TestRegresarIdFactura()
        {
            LogicaFactura logica = new LogicaFactura();
            int esperado = 0;
            Factura nuevaFactura = new Factura();
            int obtenido = logica.RegresarIdFactura(nuevaFactura);

            Assert.AreEqual(esperado, obtenido);
        }


        [Test]
        public void TestSubTotalFactura()
        {
            LogicaFactura logica = new LogicaFactura();
            Factura factura = new Factura();

            double esperado = 0.0;
            double obtenido = logica.SubtotalFactura(factura);

            Assert.AreEqual(esperado, obtenido);
        }


        //Arreglaaar
        [Test]
        public void TestCalculoDeCostoTotalTratamiento()
        {
            List<Tratamiento> listaTratamientos = new List<Tratamiento>();
            LogicaFactura logica = new LogicaFactura();
            short costoEsperado = 0;
            short costoObtenido = logica.CalculoDeCostoTotalTratamiento(listaTratamientos, 0);

            Assert.AreEqual(costoEsperado, costoObtenido);
        }

        */
    }
}
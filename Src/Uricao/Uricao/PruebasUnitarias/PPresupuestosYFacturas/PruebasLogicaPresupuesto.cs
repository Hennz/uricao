using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using NUnit.Framework;

namespace Uricao.PruebasUnitarias.PPresupuestosFacturas
{
    [TestFixture]
    public class PruebasLogicaPresupuesto
    {
        /*
        [Test]
        public void TestRegresar_presupuesto_numero()
        {
            LogicaPresupuestos logica = new LogicaPresupuestos();
            int esperado = 0;
            int obtenido = logica.regresar_presupuesto_numero();
            Assert.AreEqual(esperado, obtenido);
        }

        [Test]
        public void TestRegresar_costo_tratamiento()
        {
            LogicaPresupuestos logica = new LogicaPresupuestos();
            double esperado = 0.0;
            double obtenido = logica.regresar_costo_tratamiento(2);
            Assert.AreEqual(esperado, obtenido);
        }

        [Test]
        public void TestCalculoDeCostoTotalTratamiento()
        {
            List<Tratamiento> listaTratamientos = new List<Tratamiento>();
            LogicaFactura logica = new LogicaFactura();
            short costoEsperado = 0;
            short costoObtenido = logica.CalculoDeCostoTotalTratamiento(listaTratamientos, 0);

            Assert.AreEqual(costoEsperado, costoObtenido);
        }

        [Test]
        public void TestCostoTodoElDetalleSinIva()
        {
            double esperado = 0.0;
            LogicaPresupuestos logica = new LogicaPresupuestos();
            List<Detalle_Presupuesto_Factura> listaDetalle = new List<Detalle_Presupuesto_Factura>();
            double obtenido = logica.CostoTodoElDetalleSinIva(listaDetalle);

            Assert.AreEqual(esperado, obtenido);
        }

        [Test]
        public void TestObtenerListaPresupuestoCompleta()
        {
            LogicaPresupuestos logica = new LogicaPresupuestos();
            List<Presupuesto> listaPresupuesto = logica.ObtenerListaPresupuestoCompleta();

            Assert.IsNotNull(listaPresupuesto);

            Assert.AreEqual(10, listaPresupuesto.Count);
        }

        [Test]
        public void TestObtenerListaPresupuestoFechas()
        {
            LogicaPresupuestos logica = new LogicaPresupuestos();
            List<Presupuesto> listaPresupuesto = logica.ObtenerListaPresupuestoFechas("12/07/2012","12/09/2012");

            Assert.IsNull(listaPresupuesto);

        }


        [Test]
        public void TestObtenerPresupuestoPorNumero()
        {
            LogicaPresupuestos logica = new LogicaPresupuestos();
            Presupuesto obtenido = logica.ObtenerPresupuestoPorNumero(1);
            Presupuesto esperado = new Presupuesto(1,2550.0,new DateTime(2012,10,27));
            esperado.Observaciones = "observacion 1";
            esperado.Listado_presupuesto = new List<Detalle_Presupuesto_Factura>();
            Assert.IsNotNull(obtenido);

            Assert.IsTrue(esperado.Equals(obtenido));
        }


        [Test]
        public void TestObtenerCedulaUsuarioPresupuesto()
        {
            LogicaPresupuestos logica = new LogicaPresupuestos();
            String cedulaObtenida = logica.ObtenerCedulaUsuarioPresupuesto(1);
            String cedulaEsperada = "19560012";

            Assert.IsNotNull(cedulaObtenida);
            Assert.IsTrue(cedulaObtenida.Equals(cedulaEsperada));       
        }


        [Test]
        public void TestCreateDataSetPresupuestoLista()
        {
            List<Presupuesto> listaPresupuestos = new List<Presupuesto>();
            LogicaPresupuestos logica = new LogicaPresupuestos();
            DataSet esperado = new DataSet();
            DataTable dt = new DataTable("PresupuestosClientes");
            dt.Columns.Add(new DataColumn("cedula_paciente", typeof(string)));
            dt.Columns.Add(new DataColumn("nro_presupuesto", typeof(string)));
            dt.Columns.Add(new DataColumn("fecha_emision", typeof(DateTime)));
            esperado.Tables.Add(dt);

            DataSet obtenido = logica.CreateDataSetPresupuesto(listaPresupuestos);

            Assert.IsNotNull(obtenido);
            Assert.IsTrue(esperado == obtenido);
        }


        [Test]
        public void TestCreateDataSetPresupuestoObjeto()
        {
            Presupuesto presupuesto = new Presupuesto();
            LogicaPresupuestos logica = new LogicaPresupuestos();
            DataSet esperado = new DataSet();
            DataTable dt = new DataTable("PresupuestosClientes");
            dt.Columns.Add(new DataColumn("cedula_paciente", typeof(string)));
            dt.Columns.Add(new DataColumn("nro_presupuesto", typeof(string)));
            dt.Columns.Add(new DataColumn("fecha_emision", typeof(DateTime)));
            esperado.Tables.Add(dt);

            DataSet obtenido = logica.CreateDataSetPresupuesto(presupuesto);

            Assert.IsNotNull(obtenido);
            Assert.IsTrue(esperado == obtenido);
        }


        [Test]
        public void TestCreateDataSetTratamientosPresupuesto()
        {
            List<Detalle_Presupuesto_Factura> listaDetalle = new List<Detalle_Presupuesto_Factura>();
            LogicaPresupuestos logica = new LogicaPresupuestos();
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
        public void TestInsertarPresupuesto()
        {
            Presupuesto nuevo = new Presupuesto(11,1500.0,new DateTime(2012,12,06));
            nuevo.Listado_presupuesto = new List<Detalle_Presupuesto_Factura>();
            LogicaPresupuestos logica = new LogicaPresupuestos();

            Assert.IsTrue(logica.insertarPresupuesto(nuevo,"19560012"));
            List<Presupuesto> listaPresupuestos = logica.ObtenerListaPresupuestoCompleta();
            Presupuesto presupuestoInsertado = null;
            foreach (Presupuesto presupuestoIndex in listaPresupuestos)
            {
                if (presupuestoIndex.Nro_presupuesto == nuevo.Nro_presupuesto)
                {
                    presupuestoInsertado = presupuestoIndex;
                }
            }

            Assert.IsNotNull(presupuestoInsertado);
            Assert.IsTrue(nuevo.Equals(presupuestoInsertado));
        }


        [Test]
        public void TestRetornarDatosUsuario()
        {
            LogicaPresupuestos logica = new LogicaPresupuestos();
            String esperado = "";
            String obtenido = logica.retornarDatosUsuario("19560012", "V");
            Assert.AreEqual(esperado, obtenido);
        }


        [Test]
        public void TestValidarUsuario()
        { 
            LogicaPresupuestos logica = new LogicaPresupuestos();
            Assert.AreEqual(true,logica.validarUsuario("19560012", "V"));
        }


        [Test]
        public void TestObtenerDetallePresupuesto()
        {
            LogicaPresupuestos logica = new LogicaPresupuestos();
            List<Detalle_Presupuesto_Factura> listaDetalle = logica.ObtenerDetallePresupuesto(1);

            Assert.IsNotNull(listaDetalle);
            Assert.IsNotEmpty(listaDetalle);
            Assert.AreEqual(3, listaDetalle.Count);
        }
    */
    }
}

        
       
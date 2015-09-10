using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;
using Uricao.AccesoDeDatos.DAOS;
using NUnit.Framework;
using Uricao.Entidades.EEntidad;

namespace Uricao.PruebasUnitarias
{
    [TestFixture]
    public class PruebasDAOSPresupuestosFacturas
    {


        [Test]
        public void TestRegresarIdFactura()
        {
            Factura factura = new Factura(1, 400.0, false, "19560012", "V", "19720330", "V", "Arleska Perez", 15);
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            int idEsperado = 1;
            int idObtenido = servidorSQL.RegresarIdFactura(factura, 4);
            Assert.AreEqual(idEsperado, idObtenido);
        }

        [Test]
        public void TestAgregarDetalleFactura()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            Factura factura = new Factura(13, 400.0, false, "2134234", "V", "19720330", "V", "Arleska Perez", 15);
            Detalle_Presupuesto_Factura detalle = new Detalle_Presupuesto_Factura(new Tratamiento(1, "Primera cita", 1, 200, "Evaluacion del Odontologo para el nuevo paciente", "El odontologo se encargar? de evaluar al paciente de manera general", "Activo"),200.0,2);
            factura.Listado_factura.Add(detalle);
            Assert.IsTrue(servidorSQL.AgregarDetalleFactura(factura, 13));
        }


        [Test]
        public void TestAgregarFactura()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            Factura factura = new Factura(13, 400.0, false, "2134234", "V", "19720330", "V", "Arleska Perez", 15);
            Detalle_Presupuesto_Factura detalle = new Detalle_Presupuesto_Factura(new Tratamiento(1, "Primera cita", 1, 200, "Evaluacion del Odontologo para el nuevo paciente", "El odontologo se encargar? de evaluar al paciente de manera general", "Activo"), 200.0, 2);
            factura.Listado_factura.Add(detalle);
            Assert.IsTrue(servidorSQL.AgregarFactura(factura, 1));
        }

        /*
        [Test]
        public void TestConsultarFacturasTodas()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            List<Entidad> listaFactura = servidorSQL.ConsultarFacturasTodas();

            Assert.IsNotNull(listaFactura);
            Assert.AreEqual(14, listaFactura.Count);

        
        }
        */

        [Test]
        public void TestConsultarCedulaFactura()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            String cedulaObtenida = servidorSQL.ConsultarCedulaFactura(1);
            String cedulaEsperada = "19720330";

            Assert.IsNotNull(cedulaObtenida);
            Assert.IsTrue(cedulaObtenida.Equals(cedulaEsperada));  
        }


        [Test]
        public void TestConsultarDireccionPaisFactura()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            
            String esperado = "Venezuela";
            String obtenido = servidorSQL.ConsultarDireccionPaisFactura(7);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);        
        }


        [Test]
        public void TestConsultarDireccionEstadoFactura()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();

            String esperado = "Distrito Capital";
            String obtenido = servidorSQL.ConsultarDireccionEstadoFactura(7);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);
        }


        [Test]
        public void TestConsultarDireccionCiudadFactura()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();

            String esperado = "Caracas";
            String obtenido = servidorSQL.ConsultarDireccionCiudadFactura(7);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);        
        }


        [Test]
        public void TestConsultarDireccionMunicipioFactura()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();

            String esperado = "Chacao";
            String obtenido = servidorSQL.ConsultarDireccionMunicipioFactura(7);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);            
        }


        [Test]
        public void TestConsultarCalleFactura()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();

            String esperado = "Chorros";
            String obtenido = servidorSQL.ConsultarDireccionCalleFactura(7);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);
        }


        [Test]
        public void TestConsultarEdificioFactura()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();

            String esperado = "Conj. Res. Los Chorros #9";
            String obtenido = servidorSQL.ConsultarDireccionEdificioFactura(7);

            Assert.IsNotNull(obtenido);
            Assert.AreEqual(esperado, obtenido);
        }


        [Test]
        public void TestConsultarPresupuestosTodas()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            List<Entidad> listaPresupuesto = servidorSQL.ConsultarPresupuestosTodos();

            Assert.IsNotNull(listaPresupuesto);
            Assert.AreEqual(10, listaPresupuesto.Count);
        }


        [Test]
        public void TestConsultarPresupuestosRangoFechas()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            List<Entidad> listaPresupuesto = servidorSQL.ConsultarPresupuestosRangoFechas("12/07/2012","12/09/2012");

            Assert.IsNotNull(listaPresupuesto);
            Assert.AreEqual(0, listaPresupuesto.Count);
        }


        [Test]
        public void TestConsultarPresupuestoXCI()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            Entidad presupuestoObtenido = servidorSQL.ConsultarPresupuestoXCI("19560012");
            Presupuesto presupuestoEsperado = new Presupuesto(1, 2550.0, new DateTime(2012, 10, 27));
            presupuestoEsperado.Observaciones = "observacion 1";
            presupuestoEsperado.Listado_presupuesto = new List<Detalle_Presupuesto_Factura>();

            Assert.IsNotNull(presupuestoObtenido);
            Assert.IsTrue(presupuestoEsperado.Equals(presupuestoObtenido));
        }



        [Test]
        public void TestConsultarPresupuestoNumero()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            Entidad presupuestoObtenido = servidorSQL.ConsultarPresupuestoNumero(1);
            Presupuesto presupuestoEsperado = new Presupuesto(1, 2550.0, new DateTime(2012, 10, 27));
            presupuestoEsperado.Observaciones = "observacion 1";
            presupuestoEsperado.Listado_presupuesto = new List<Detalle_Presupuesto_Factura>();

            Assert.IsNotNull(presupuestoObtenido);
            Assert.IsTrue(presupuestoEsperado.Equals(presupuestoObtenido));
        }


        [Test]
        public void TestConsultarCedulaPresupuesto()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            String esperada = "19560012";
            String obtenida = servidorSQL.ConsultarCedulaPresupuesto(1);

            Assert.IsNotNull(obtenida);
            Assert.AreEqual(esperada, obtenida);
        }


        [Test]
        public void TestAgregarPresupuesto()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            Presupuesto presupuesto = new Presupuesto(11, 2550.0, new DateTime(2012, 10, 27));
            presupuesto.Observaciones = "observacion 1";
            presupuesto.Listado_presupuesto = new List<Detalle_Presupuesto_Factura>();

            Assert.IsTrue(servidorSQL.AgregarPresupuesto(presupuesto,1));
        }


        [Test]
        public void TestAgregarDetallePresupuesto()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            Presupuesto presupuesto = new Presupuesto(11, 2550.0, new DateTime(2012, 10, 27));
            presupuesto.Observaciones = "observacion 1";
            presupuesto.Listado_presupuesto = new List<Detalle_Presupuesto_Factura>();
            Detalle_Presupuesto_Factura detalle = new Detalle_Presupuesto_Factura(new Tratamiento(1, "Primera cita", 1, 200, "Evaluacion del Odontologo para el nuevo paciente", "El odontologo se encargar? de evaluar al paciente de manera general", "Activo"), 200.0, 2);
            presupuesto.Listado_presupuesto.Add(detalle);

            Assert.IsTrue(servidorSQL.AgregarDetallePresupuesto(presupuesto, 1, 11));
        }


        [Test]
        public void TestRegresarIdPresupuesto()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            Presupuesto presupuesto = new Presupuesto(11, 2550.0, new DateTime(2012, 10, 27));
            presupuesto.Observaciones = "observacion 1";
            presupuesto.Listado_presupuesto = new List<Detalle_Presupuesto_Factura>();
            Detalle_Presupuesto_Factura detalle = new Detalle_Presupuesto_Factura(new Tratamiento(1, "Primera cita", 1, 200, "Evaluacion del Odontologo para el nuevo paciente", "El odontologo se encargar? de evaluar al paciente de manera general", "Activo"), 200.0, 2);
            presupuesto.Listado_presupuesto.Add(detalle);

            int esperado = 11;
            int obtenido = servidorSQL.RegresarIdPresupuesto(presupuesto, 1);
            Assert.AreEqual(esperado, obtenido);
        }



        [Test]
        public void TestRegresarCostoTratamiento()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            int esperado = 200;
            int obtenido = servidorSQL.RegresarCostoTratamiento(1);

            Assert.AreEqual(esperado, obtenido);
        }


        [Test]
        public void TestRegresarIdUsuario()
        {
            DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
            int esperado = 1;
            int obtenido = servidorSQL.RegresarIdUsuario("19560012");

            Assert.AreEqual(esperado, obtenido);
        }


        

    }
}
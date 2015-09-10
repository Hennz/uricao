using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorCobrar;
using Uricao.LogicaDeNegocios.Clases.LNAbono;
using Uricao.Entidades.EAbonos;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.AccesoDeDatos.DAOS;

namespace Uricao.PruebasUnitarias.PCuentasPorCobrar
{
    [TestFixture]
    public class PruebaDAOSCuentasPorCobrar
    {
/*
        [Test]
        public void PruebaAgregarAbono()
        {


            double montoAbono = 10;
            string fechaAbono = "12/04/2012";
            double deuda = 40;
            int nCuenta = 4;
            int nFactura = 1;

            LogicaAbono logica = new LogicaAbono();
            DAOAbono datos = new DAOAbono();
            bool agregar = logica.AgregarAbonoCC(fechaAbono, nFactura, nCuenta, montoAbono);
            Abono consultar = new Abono();
            consultar = datos.ConsultarAbono(fechaAbono, nFactura, nCuenta, montoAbono);

            Assert.IsTrue(agregar);
            Assert.AreEqual(montoAbono, consultar.MontoAbono);
            Assert.AreEqual(Convert.ToDateTime(fechaAbono).ToShortDateString(), Convert.ToDateTime(consultar.FechaAbono).ToShortDateString());
            Assert.AreEqual(deuda, consultar.Deuda);
            Assert.AreEqual(nCuenta, consultar.Cuenta);
            Assert.AreEqual(nFactura, consultar.Factura);

        }

        [Test]
        //Recordar Cambiar los Estados
        public void PruebaModificarEstadoCuenta()
        {
            string desactivado = "Desactivar";
            string porPagar = "Por Pagar";
            string desactivar2 = "Desactivar                                        ";
            string porPagar2 = "Por Pagar                                         ";
            int cuenta = 1;

            LogicaCuentaPorCobrar logica = new LogicaCuentaPorCobrar();
            DAOCuentasPorCobrar datos = new DAOCuentasPorCobrar();
            CuentaPorCobrar estadoActual = new CuentaPorCobrar();
            estadoActual = datos.consultarCuenta(cuenta);

            bool modificar = logica.ModificarEstado(cuenta, desactivado);

            CuentaPorCobrar consultar = new CuentaPorCobrar();
            consultar = datos.consultarCuenta(cuenta);

            Assert.IsTrue(modificar);
            Assert.AreEqual(porPagar2, estadoActual.Estado.ToString());
            Assert.AreEqual(desactivar2, consultar.Estado.ToString());
            Assert.AreNotEqual(estadoActual.Estado.ToString(), consultar.Estado.ToString());

        }

        [Test]
        public void PruebaCantidadAbono()
        {
            int idFactura = 1;
            int cantidadAbono = 9;


            LogicaAbono logica = new LogicaAbono();
            DAOAbono datos = new DAOAbono();
            CuentaPorCobrar estadoActual = new CuentaPorCobrar();
            int abonos = datos.CantidadAbonos(idFactura);



            Assert.AreEqual(abonos, cantidadAbono);

        }

        [Test]
        public void PruebaConsultarUsuarioCI()
        {
            string tipo = "V                                                 ";
            int idCuenta = 4;
            string cedula = "19720330";
            string nombre = "Arleska                                           ";
            string nombre2 = string.Empty;
            string apellido = "Perez                                             ";
            string apellido2 = "Velasquez                                         ";
            string estado = "Por Pagar                                         ";

            DAOCuentasPorCobrar datos = new DAOCuentasPorCobrar();
            List<CuentaPorCobrar> cuenta = new List<CuentaPorCobrar>();
            cuenta = datos.consultarUsuarioCedula(tipo, cedula);


            Assert.AreEqual(tipo, cuenta[0].TipoCedula);
            Assert.AreEqual(idCuenta, cuenta[0].Id);
            Assert.AreEqual(cedula, cuenta[0].Cedula);
            Assert.AreEqual(nombre, cuenta[0].PrimerNombre);
            Assert.AreEqual(nombre2, cuenta[0].Segundonombre);
            Assert.AreEqual(apellido, cuenta[0].Primerapellido);
            Assert.AreEqual(apellido2, cuenta[0].Segundoapellido);
            Assert.AreEqual(estado, cuenta[0].Estado);

        }

        [Test]
        public void PruebaTotalesAbonoFactura()
        {
            int idCuenta = 4;
            double totalAbonos = 1180;
            double totalFactura = 1800;



            DAOCuentasPorCobrar consultar = new DAOCuentasPorCobrar();
            Totales datos = new Totales();
            datos = consultar.consultarTotalesAbonoFactura(idCuenta);

            Assert.AreEqual(totalAbonos,datos.TotalAbono );
            Assert.AreEqual(totalFactura, datos.TotalFactura);

        }

        [Test]
        public void PruebaConsultarDetalleFactura()
        {
            int factura = 1;
            int cantidadDetalle = 1;
            double monto = 200;
            double monto2 = 250;
            double monto3 = 1300;
            string nombre = "Primera cita                                      ";
            string nombre2 = "Blanqueamiento Dental                             ";
            string nombre3 = "Exodoncia                                         ";

           
            DAOCuentasPorCobrar consultar = new DAOCuentasPorCobrar();
            List<Detalle> datos = new List<Detalle>();
            datos = consultar.consultarDetalleFactura(factura);

            Assert.AreEqual(cantidadDetalle, datos[0].CantidadDetalle);
            Assert.AreEqual(cantidadDetalle, datos[1].CantidadDetalle);
            Assert.AreEqual(cantidadDetalle, datos[2].CantidadDetalle);

            Assert.AreEqual(monto, datos[0].MontoDetalle);
            Assert.AreEqual(monto2, datos[1].MontoDetalle);
            Assert.AreEqual(monto3, datos[2].MontoDetalle);

            Assert.AreEqual(nombre, datos[0].NombreTratamiento);
            Assert.AreEqual(nombre2, datos[1].NombreTratamiento);
            Assert.AreEqual(nombre3, datos[2].NombreTratamiento);

        }

        [Test]
        public void PruebaConsultarUsuarioFechas()
        {
            string tipo = "V                                                 ";
            string fechaInicio = "01/10/2012";
            string fechaFin = "15/10/2012";
            string cedula = "19720330";
            string nombre = "Arleska                                           ";
            string nombre2 = string.Empty;
            string apellido = "Perez                                             ";
            string apellido2 = "Velasquez                                         ";
            string estado = "Por Pagar                                         ";

            DAOCuentasPorCobrar datos = new DAOCuentasPorCobrar();
            List<CuentaPorCobrar> cuenta = new List<CuentaPorCobrar>();
            cuenta = datos.consultarUsuarioFechas(fechaInicio, fechaFin);


            Assert.AreEqual(tipo, cuenta[0].TipoCedula);
            Assert.AreEqual(cedula, cuenta[0].Cedula);
            Assert.AreEqual(nombre, cuenta[0].PrimerNombre);
            Assert.AreEqual(nombre2, cuenta[0].Segundonombre);
            Assert.AreEqual(apellido, cuenta[0].Primerapellido);
            Assert.AreEqual(apellido2, cuenta[0].Segundoapellido);
            Assert.AreEqual(estado, cuenta[0].Estado);


        }

        [Test]
        public void PruebaConsultarFacturaCF()
        {
            string fechaInicio = "01/10/2012";
            string fechaFin = "15/10/2012";
            string cedula = "19720330";
            string tipo = "V                                                 ";
            double total = 410;
            int factura = 1;
            string fecha = "01/10/2012";
            double totalFactura = 400;
            double Deuda = totalFactura-total;

            DAOCuentasPorCobrar datos = new DAOCuentasPorCobrar();
            List<Ficticia> cuenta = new List<Ficticia>();
            cuenta = datos.consultarFacturaCF(fechaInicio, fechaFin,cedula,tipo);


            Assert.AreEqual(total, cuenta[0].TotalAbono);
            Assert.AreEqual(totalFactura, cuenta[0].TotalFactura);
            Assert.AreEqual(Convert.ToDateTime(fecha).ToShortDateString(), Convert.ToDateTime(cuenta[0].FechaEmitida).ToShortDateString());
            Assert.AreEqual(Deuda, cuenta[0].Deuda);
            Assert.AreEqual(factura, cuenta[0].NumeroFactura);
         

        }
        */
    }
}
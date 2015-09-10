using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorPagar;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EBancos;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EEmpleados;
using Uricao.Entidades.EAbonos;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EEntidad;

namespace Uricao.PruebasUnitarias.PCuentasPorPagar
{
     [TestFixture]
    public class PruebasLogicaCuentasPorPagar
    {
         [Test]
         public void pruebaConstructor()
         {
             Entidad _miCpp = FabricaEntidad.CrearCuentaPorPagar();
             Assert.IsNotNull(_miCpp);

         }
         [Test]
         public void pruebaConstructor1()
         {
   
             CuentaPorPagar _cpp = new CuentaPorPagar("idCuentaPorPagar","fechaEmision",10000);
             Assert.IsNotNull(_cpp);
             Assert.AreEqual("idCuentaPorPagar", _cpp.IdCuentaPorPagar);
             Assert.AreEqual("fechaEmision", _cpp.FechaEmision);
             Assert.AreEqual(10000, _cpp.MontoActualDeuda);

         }
         [Test]

         public void pruebaConstructor2()
         {
             Proveedor miProveedor = new Proveedor();
             Empleado miEmpleado = new Empleado();
             NumeroCuentaBanco numeroCuentaBanco = new NumeroCuentaBanco();
             List<Abono> listaAbono=new List<Abono>();
             CuentaPorPagar _cpp = new CuentaPorPagar("idCuentaPorPagar", "fechaEmision","fechaEmision","","","","", 10000,1,miProveedor,miEmpleado,numeroCuentaBanco,listaAbono);
             Assert.IsNotNull(_cpp);
             Assert.AreEqual("idCuentaPorPagar", _cpp.IdCuentaPorPagar);
             Assert.AreEqual("fechaEmision", _cpp.FechaEmision);
             Assert.AreEqual("fechaEmision", _cpp.FechaVencimiento);
             Assert.AreEqual("", _cpp.TipoPago);
             Assert.AreEqual("", _cpp.Estatus);
             Assert.AreEqual("", _cpp.TipoDeuda);
             Assert.AreEqual("", _cpp.Detalle);
             Assert.AreEqual(10000, _cpp.MontoInicialDeuda);
              Assert.AreEqual(1, _cpp.MontoActualDeuda);
              Assert.AreEqual(listaAbono, _cpp.ListaAbono);

         }

         /*
         [Test]
         public void TestAgregarEnBDunaCuentaPorPagar()
         {
             Proveedor miProveedor = new Proveedor();
             miProveedor.Nombre = "Hiperdental";

             NumeroCuentaBanco miCuentaBanco = new NumeroCuentaBanco();
             miCuentaBanco.NroCuentaBanco = "847384001";

             Abono miAbono = new Abono();
             List<Abono> listaAbono = new List<Abono>();
             listaAbono.Add(miAbono);

             Empleado miEmpleado = new Empleado();

             CuentaPorPagar miCuentaPP = new CuentaPorPagar("1","2009/02/02","2011/03/03","credito","activo","proveedor","detallito",222,222,miProveedor,miEmpleado,miCuentaBanco,listaAbono);
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             bool inserto = miLogica.AgregarEnBDunaCuentaPorPagar(miCuentaPP);
             Assert.IsTrue(inserto);
         }

         [Test]
         public void TestMostrarListaCuentasPorPagar()
         {
             /*string nombreProveedor = "HiperDental";
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             List<CuentaPorPagar> otraLista = miLogica.MostrarListaCuentasPorPagar(nombreProveedor);
             Assert.IsNotNull(otraLista);
         }

         [Test]
         public void TestListaCuentasPorPagarEntreFechas()
         {

             string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             List<CuentaPorPagar> miLista = miLogica.ListaCuentasPorPagarEntreFechas(fechaInicio, fechaFin);
             Assert.IsNotNull(miLista);
         }

         [Test]
         public void TestMostarCuentasPorPagarFechasProveedor()
         {
             string provedor = "HiperDental";
             string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             List<CuentaPorPagar> miLista = miLogica.MostarCuentasPorPagarFechasProveedor(provedor, fechaInicio, fechaFin);
             Assert.IsNotNull(miLista);
         }

         [Test]
         public void testConsultarCuentaPorPagarBD()
         {
             string idCuentaPorPagar = "1";
             Proveedor miProveedor = new Proveedor();
             miProveedor.Nombre = "Hiperdental";

             NumeroCuentaBanco miCuentaBanco = new NumeroCuentaBanco();
             miCuentaBanco.NroCuentaBanco = "847384001";

             Abono miAbono = new Abono();
             List<Abono> listaAbono = new List<Abono>();
             listaAbono.Add(miAbono);

             Empleado miEmpleado = new Empleado();

             CuentaPorPagar miCuentaPP = new CuentaPorPagar("1", "2009/02/02", "2011/03/03", "credito", "activo", "proveedor ", "detallazo", 222, 0, miProveedor, miEmpleado, miCuentaBanco, listaAbono);
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             CuentaPorPagar otraCuenta = new CuentaPorPagar();
             otraCuenta = miLogica.ConsultarCuentaPorPagarBD(idCuentaPorPagar);
             Assert.IsNotNull(otraCuenta);
             Assert.AreEqual(otraCuenta, miCuentaPP);
         }

         [Test]
         public void testModificarCuentaPorPagarBD()
         {
             Proveedor miProveedor = new Proveedor();
             miProveedor.Nombre = "Hiperdental";

             NumeroCuentaBanco miCuentaBanco = new NumeroCuentaBanco();
             miCuentaBanco.NroCuentaBanco = "847384001";

             Abono miAbono = new Abono();
             List<Abono> listaAbono = new List<Abono>();
             listaAbono.Add(miAbono);

             Empleado miEmpleado = new Empleado();

             CuentaPorPagar miCuentaPP = new CuentaPorPagar("1", "2009/02/02", "2011/03/03", "contado", "activo", "proveedor ", "detallito", 222, 222, miProveedor, miEmpleado, miCuentaBanco, listaAbono);
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             bool inserto = miLogica.ModificarCuentaPorPagarBD(miCuentaPP);
             Assert.IsTrue(inserto);
         }

         [Test]
         public void TestActivarDesactivarMostrarListaCuentasPorPagarProveedor()
         {
             string nombreProveedor = "HiperDental";
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             List<CuentaPorPagar> otraLista = miLogica.ActivarDesactivarObtenerCuentasPorPagarProveedor(nombreProveedor);
             Assert.IsNotNull(otraLista);
         }

         [Test]
         public void TestllenarAbonarCpp2()
         {
             string nombreProveedor = "HiperDental";
             Int64 codigoCuenta = 2;
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             CuentaPorPagar miCuentaPP = new CuentaPorPagar();
             miCuentaPP = miLogica.llenarAbonarCpp2(nombreProveedor, codigoCuenta);
             Assert.IsNotNull(miCuentaPP);
         }

         [Test]
         public void TestCambiarEstatusCPP()
         {
             Proveedor miProveedor = new Proveedor();
             miProveedor.Nombre = "Hiperdental";

             NumeroCuentaBanco miCuentaBanco = new NumeroCuentaBanco();
             miCuentaBanco.NroCuentaBanco = "847384001";

             Abono miAbono = new Abono();
             List<Abono> listaAbono = new List<Abono>();
             listaAbono.Add(miAbono);

             Empleado miEmpleado = new Empleado();

             CuentaPorPagar miCuentaPP = new CuentaPorPagar("1", "2009/02/02", "2011/03/03", "contado", "activo", "proveedor ", "detallito", 222, 222, miProveedor, miEmpleado, miCuentaBanco, listaAbono);
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             bool cambio = miLogica.CambiarEstatusCpp(miCuentaPP);
             Assert.IsTrue(cambio);
         }

         [Test]
         public void TestAbonarConsultarCuentasPorPagarFechas()
         {
            string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             List<CuentaPorPagar> miLista = miLogica.AbonarConsultarCuentasPorPagarFechas(fechaInicio, fechaFin);
             Assert.IsNotNull(miLista);

         }

         [Test]
         public void testAbonarConsultarCuentasPorPagar()
         {
             string provedor = "HiperDental";
             string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             List<CuentaPorPagar> miLista = miLogica.AbonarConsultarCuentasPorPagar(fechaInicio, fechaFin, provedor);
             Assert.IsNotNull(miLista);

         }

         [Test]
         public void TestConsultarCuentasPorPagarFechasActivar()
         {
             string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             List<CuentaPorPagar> miLista = miLogica.ConsultarCuentasPorPagarFechasActivar(fechaInicio, fechaFin);
             Assert.IsNotNull(miLista);

         }

         [Test]
         public void TestConsultarCuentasPorPagarFechasProveedorActivar()
         {
             string provedor = "HiperDental";
             string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             List<CuentaPorPagar> miLista = miLogica.ConsultarCuentasPorPagarFechasProveedorActivar(fechaInicio, fechaFin, provedor);
             Assert.IsNotNull(miLista);
         }

         [Test]
         public void TestActivarDesactivarCpp()
         {
             Proveedor miProveedor = new Proveedor();
             miProveedor.Nombre = "Hiperdental";

             NumeroCuentaBanco miCuentaBanco = new NumeroCuentaBanco();
             miCuentaBanco.NroCuentaBanco = "847384001";

             Abono miAbono = new Abono();
             List<Abono> listaAbono = new List<Abono>();
             listaAbono.Add(miAbono);

             Empleado miEmpleado = new Empleado();

             CuentaPorPagar miCuentaPP = new CuentaPorPagar("1", "2009/02/02", "2011/03/03", "contado", "activo", "proveedor ", "detallito", 222, 222, miProveedor, miEmpleado, miCuentaBanco, listaAbono);
             LogicaCuentaPorPagar miLogica = new LogicaCuentaPorPagar();
             bool Activo = miLogica.ActivarDesactivarCpp(miCuentaPP);
             Assert.IsTrue(Activo);
         }*/
    }
}
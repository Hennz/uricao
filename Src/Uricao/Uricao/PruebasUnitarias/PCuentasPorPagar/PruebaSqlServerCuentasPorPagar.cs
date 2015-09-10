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
using Uricao.Entidades.EEntidad;

namespace Uricao.PruebasUnitarias.PCuentasPorPagar
{
     [TestFixture]
    public class PruebaDAOSCuentasPorPagar
    {
         [Test]
         public void TestInsertarCuentasPorPagar()
         {
             Proveedor miProveedor = new Proveedor();
             miProveedor.Nombre = "Hiperdental";

             NumeroCuentaBanco miCuentaBanco = new NumeroCuentaBanco();
             miCuentaBanco.NroCuentaBanco = "847384001";

             Abono miAbono = new Abono();
             List<Abono> listaAbono = new List<Abono>();
             listaAbono.Add(miAbono);

             Empleado miEmpleado = new Empleado();

             CuentaPorPagar miCuentaPP = new CuentaPorPagar("1", "2009/02/02", "2011/03/03", "credito", "activo", "proveedor ", "detallito", 222, 222, miProveedor, miEmpleado, miCuentaBanco, listaAbono);
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             bool inserto = SqlCuentaPP.InsertarCuentasPorPagar(miCuentaPP);
             Assert.IsTrue(inserto);
         }

         [Test]
         public void TestObtenerTodasCuentasPorPagar()
         {
             string nombreProveedor = "HiperDental";
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
            List <Entidad> otraLista = SqlCuentaPP.MostrarListaCuentasPorPagar(nombreProveedor);
            Assert.IsNotNull(otraLista);
            
         }
         [Test]
         public void TestListaCuentasPorPagarEntreFechas()
         {
            
                 string fechaInicio= "2012/01/01";
                 string fechaFin = "2012/12/12";
                 DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
                 List<Entidad> miLista = SqlCuentaPP.ListaCuentasPorPagarEntreFechas(fechaInicio, fechaFin);
                 Assert.IsNotNull(miLista);
               
         }
         [Test]
         public void TestMostarCuentasPorPagarFechasProveedor()
         {
             string provedor = "HiperDental";
             string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             List<Entidad> miLista = SqlCuentaPP.MostarCuentasPorPagarFechasProveedor(provedor, fechaInicio, fechaFin);
             Assert.IsNotNull(miLista);
             Assert.AreEqual(miLista.Count, 2);
         }

         [Test]
         public void testConsultarCuentaPorPagar()
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

             Entidad miCuentaPP = new CuentaPorPagar("1", "2009/02/02", "2011/03/03", "credito", "activo", "proveedor ", "detallazo", 222, 0, miProveedor, miEmpleado, miCuentaBanco, listaAbono);
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             Entidad otraCuenta = new CuentaPorPagar();
             otraCuenta = SqlCuentaPP.ConsultarCuentaPorPagar(idCuentaPorPagar);
             Assert.IsNotNull(otraCuenta);
             Assert.AreEqual(otraCuenta, miCuentaPP);

         }

         [Test]
         public void testModificarCuentasPorPagar()
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
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             bool inserto = SqlCuentaPP.ModificarCuentaPorPagar(miCuentaPP);
             Assert.IsTrue(inserto);
         }

         [Test]
         public void TestActivarDesactivarMostrarListaCuentasPorPagarProveedor()
         {
             string nombreProveedor = "HiperDental";
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             List<Entidad> otraLista = SqlCuentaPP.ActivarDesactivarMostrarListaCuentasPorPagarProveedor(nombreProveedor);
             Assert.IsNotNull(otraLista);
 
         }

         [Test]
         public void TestllenarAbonarCpp2()
         {
            string nombreProveedor = "HiperDental";
            Int64 codigoCuenta = 2;
            DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
            Entidades.EEntidad.Entidad miCuentaPP = new CuentaPorPagar();
            miCuentaPP = SqlCuentaPP.llenarAbonarCpp2(nombreProveedor, codigoCuenta);
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
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             bool cambio = SqlCuentaPP.CambiarEstatusCpp(miCuentaPP);
             Assert.IsTrue(cambio);
         }
         [Test]
         public void TestAbonarConsultarCuentasPorPagarFechas()
         {
             string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             List<Entidad> miLista = SqlCuentaPP.AbonarConsultarCuentasPorPagarFechas(fechaInicio, fechaFin);
             Assert.IsNotNull(miLista);
 
         }
         [Test]
         public void testAbonarConsultarCuentasPorPagar()
         {
             string provedor = "HiperDental";
             string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             List<Entidad> miLista = SqlCuentaPP.AbonarConsultarCuentasPorPagar(fechaInicio, fechaFin, provedor);
             Assert.IsNotNull(miLista);
            
         }
         [Test]
         public void TestConsultarCuentasPorPagarFechasActivar()
         {
             string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             List<Entidad> miLista = SqlCuentaPP.ConsultarCuentasPorPagarFechasActivar(fechaInicio, fechaFin);
             Assert.IsNotNull(miLista);
 
         }
         [Test]
         public void TestConsultarCuentasPorPagarFechasProveedorActivar()
         {
             string provedor = "HiperDental";
             string fechaInicio = "2012/01/01";
             string fechaFin = "2012/12/12";
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             List<Entidad> miLista = SqlCuentaPP.ConsultarCuentasPorPagarFechasProveedorActivar(fechaInicio, fechaFin, provedor);
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
             DAOCuentasPorPagar SqlCuentaPP = new DAOCuentasPorPagar();
             bool Activo = SqlCuentaPP.ActivarDesactivarCpp(miCuentaPP);
             Assert.IsTrue(Activo);
         }
         }
    }


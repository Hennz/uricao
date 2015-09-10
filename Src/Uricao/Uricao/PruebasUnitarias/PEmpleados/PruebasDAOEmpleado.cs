using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EEmpleados;
using Uricao.Entidades.ERolesUsuarios;

namespace Uricao.PruebasUnitarias.PEmpleados
{
    [TestFixture]
    public class PruebasDAOEmpleado
    {
        [Test]
        public void PruebaAgregarEmpleado()
        {
            //-------------------------PRUEBAS------------------------------//
            //Agrega el empleado?                                           //
            //--------------------------------------------------------------//
            
            Entidad _empleado = FabricaEntidad.NuevoEmpleado();
            Entidad _direccion = FabricaEntidad.NuevaDireccion();

            Assert.IsNotNull(_empleado);

            (_empleado as Empleado).Login = "Liliana";
            (_empleado as Empleado).Password = "9898989898";
            (_empleado as Empleado).TipoIdentificacion = "V";
            (_empleado as Empleado).Identificacion = "9898989898";
            (_empleado as Empleado).PrimerNombre = "Liliana";
            (_empleado as Empleado).PrimerApellido = "Herrera";
            (_empleado as Empleado).FechaNace = new DateTime();
            (_empleado as Empleado).Sexo = "Femenino";
            (_empleado as Empleado).Correo = "micorreo@gmail.com";
            (_empleado as Empleado).Sueldo = 10000;
            (_empleado as Empleado).Estado = "Activo";

            (_direccion as Direccion).Nombre = "Esta es la direccion detallada";
            (_direccion as Direccion).Ciudad = "Caracas";

            Assert.IsTrue(FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().AgregarEmpleado(_empleado,_direccion));

        }

        [Test]
        public void PruebaConsultarEmpleadosActivos()
        {
            //-------------------------PRUEBAS------------------------------//
            //Trae realmente los activos al pedirlos?                     //
            //--------------------------------------------------------------//

            List<Entidad> _empleados = FabricaEntidad.NuevaListaEmpleados();
            string _nombreProcedimiento = "";

            //Prueba si carga lista de activos

            _nombreProcedimiento = "ListaEmpleadoActivos";
            _empleados = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().ConsultarTodosEmpleados(_nombreProcedimiento);

            Assert.IsNotNull(_empleados);
            foreach (Entidad _empleado in _empleados)
            {
                Assert.AreEqual("Activo", (_empleado as Empleado).Estado.Trim());
            }
        }

        [Test]
        public void PruebaConsultarEmpleadosInactivos()
        {
            //-------------------------PRUEBAS------------------------------//
            //Trae realmente los inactivos al pedirlos?                     //
            //--------------------------------------------------------------//

            List<Entidad> _empleados = FabricaEntidad.NuevaListaEmpleados();
            string _nombreProcedimiento = "";

            //Prueba si carga lista de inactivos

            _nombreProcedimiento = "ListaEmpleadoInactivos";
            _empleados = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().ConsultarTodosEmpleados(_nombreProcedimiento);

            Assert.IsNotNull(_empleados);
            foreach (Entidad _empleado in _empleados)
            {
                Assert.AreEqual("Inactivo", (_empleado as Empleado).Estado.Trim());
            }
        }

        [Test]
        public void PruebaActivarInactivarEmpleado()
        {
            //-------------------------PRUEBAS------------------------------//
            //Cambia el estado del empleado?                                //
            //--------------------------------------------------------------//

            Entidad _empleado = FabricaEntidad.NuevoEmpleado();

            Assert.IsNotNull(_empleado);

            (_empleado as Empleado).IdUsuario = 1;
            (_empleado as Empleado).Estado = "Inactivo";

            Assert.IsTrue(FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().CambiarEstadoEmpleado(_empleado));

            (_empleado as Empleado).Estado = "Activo";

            Assert.IsTrue(FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().CambiarEstadoEmpleado(_empleado));

        }

    }
}
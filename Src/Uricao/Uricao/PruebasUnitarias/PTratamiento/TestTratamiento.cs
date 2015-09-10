using System.Web;
using NUnit.Framework;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Clases.LNTratamientos;
using Uricao.AccesoDeDatos.DAOS;
using System;
using System.Collections.Generic;
using System.Linq;
using Uricao.LogicaDeNegocios.Clases.LNProductosInventario;

namespace TestTratamiento
{   
    [TestFixture]
    class TestTratamiento
    {
        [TestCase]
        public void ConstructorTratamientoPrueba()
        {

            String nombre = "Tratamiento de prueba";
            Int16 duracion = 2;
            Int16 costo = 300;
            String descripcion = "Descripcion de prueba";
            String explicacion = "Explicacion de prueba";
            String estado = "Inactivo";

            

            Tratamiento miTratamiento = new Tratamiento(0,nombre,duracion,costo,descripcion,explicacion,estado);


            String nombreEsperado = "Tratamiento de prueba";
            String descripcionEsperado = "Descripcion de prueba";
            String explicacionEsperado = "Explicacion de prueba";
            String estadoEsperado = "Inactivo";

            Assert.IsNotNull(miTratamiento);
            //probando gets
            Assert.AreEqual(miTratamiento.Nombre, nombreEsperado);
            Assert.AreEqual(miTratamiento.Duracion, 2);
            Assert.AreEqual(miTratamiento.Costo, 300);
            Assert.AreEqual(miTratamiento.Descripcion, descripcionEsperado);
            Assert.AreEqual(miTratamiento.Explicacion,explicacionEsperado);
            Assert.AreEqual(miTratamiento.Estado, estadoEsperado);


            //probando sets
            miTratamiento.Nombre = "Tratamiento de prueba2";
            miTratamiento.Duracion = 20;
            miTratamiento.Costo = 3000;
            miTratamiento.Descripcion = "Descripcion de prueba2";
            miTratamiento.Explicacion = "Explicacion de prueba2";
            miTratamiento.Estado = "Activo";

            Assert.AreEqual(miTratamiento.Nombre, "Tratamiento de prueba2");
            Assert.AreEqual(miTratamiento.Duracion, 20);
            Assert.AreEqual(miTratamiento.Costo, 3000);
            Assert.AreEqual(miTratamiento.Descripcion, "Descripcion de prueba2");
            Assert.AreEqual(miTratamiento.Explicacion, "Explicacion de prueba2");
            Assert.AreEqual(miTratamiento.Estado, "Activo");
        }

        [TestCase]

        public void CambiarEstadoPrueba()
        {
            String nombre = "Tratamiento de prueba";
            Int16 duracion = 2;
            Int16 costo = 300;
            String descripcion = "Descripcion de prueba";
            String explicacion = "Explicacion de prueba";
            String estado = "Inactivo";            

            Tratamiento miTratamiento = new Tratamiento(0, nombre, duracion, costo, descripcion, explicacion, estado);

            Tratamiento x = new Tratamiento();
            x.CambiarEstado(miTratamiento);

            Assert.AreNotEqual(estado, miTratamiento.Estado);



        }
        
    }
}

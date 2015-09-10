using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EProductosInventario;

namespace Uricao.PruebasUnitarias.PTratamiento
{
    [TestFixture]
    public class PruebaDAOImplemento
    {
        [Test]
        public void ConstructorImplementoPrueba()
        {
            DAOImplemento prueba = new DAOImplemento();
            Entidad implemento = FabricaEntidad.NuevoImplemento();

            (implemento as Implemento).IdTratamiento = 1;
            (implemento as Implemento).IdProducto = 1;
            (implemento as Implemento).Prioridad = 2;
           
            (implemento as Implemento).Cantidad = 3;



            //Assert.IsNotNull(prueba.SqlAgregarImplemento(implemento));
            //Assert.IsTrue(prueba.SqlAgregarImplemento(implemento));

         


            String tipoProductoEsperado = "PruebaImplemento";


            Assert.IsNotNull(implemento);
            //probando gets
            Assert.AreEqual((implemento as Implemento).IdTratamiento, 1);
            Assert.AreEqual((implemento as Implemento).IdProducto, 1);
            Assert.AreEqual((implemento as Implemento).Prioridad, 2);
            Assert.AreEqual((implemento as Implemento).Cantidad, 3);
            
          
            //

            (implemento as Implemento).IdTratamiento = 10;
            (implemento as Implemento).IdProducto = 10;
            (implemento as Implemento).Prioridad = 20;

            (implemento as Implemento).Cantidad = 30;

            tipoProductoEsperado = "PruebaImplemento2";

            Assert.AreEqual((implemento as Implemento).IdTratamiento, 10);
            Assert.AreEqual((implemento as Implemento).IdProducto, 10);
            Assert.AreEqual((implemento as Implemento).Prioridad, 20);
            Assert.AreEqual((implemento as Implemento).Cantidad, 30);
 
        }

        #region sqlAgregarImplementoTest
        [Test]
        public void sqlAgregarImplementoTest()
        {

            try
            {
                DAOImplemento prueba = new DAOImplemento();
                Entidad implemento = FabricaEntidad.NuevoImplemento();

                (implemento as Implemento).IdImplemento = 1;
                (implemento as Implemento).IdProducto = 1;
                (implemento as Implemento).Prioridad  = 1;
                (implemento as Implemento).TipoProducto  = "Tratamiento de prueba";
                (implemento as Implemento).Cantidad  = 2;

                List<Entidad> lista = new List<Entidad>();
                bool ImplementoAgregado = false;

                Assert.IsNotNull(prueba.SqlAgregarImplemento(implemento));

               
                DAOImplemento serverImplemento = new DAOImplemento();
                ImplementoAgregado = serverImplemento.SqlAgregarImplemento(implemento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(prueba.SqlAgregarImplemento(implemento));


                //Assert para que los string no esten vacios
                Assert.IsNotEmpty((implemento as Implemento).TipoProducto);

                Assert.IsTrue(ImplementoAgregado);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion

        #region sqlConsultarListaImplementos Test
        [Test]
        public void SqlConsultarListaImplementosTest()
        {

            try
            {
                DAOTratamiento prueba = new DAOTratamiento();
                Entidad tratamiento = FabricaEntidad.NuevoTratamiento();

               

                (tratamiento as Tratamiento).Id = 1;
                (tratamiento as Tratamiento).Nombre  = "Tratamiento de prueba";
                (tratamiento as Tratamiento).Duracion  = 2;
                (tratamiento as Tratamiento).Costo  = 300;
                (tratamiento as Tratamiento).Descripcion  = "Descripcion de prueba";
                (tratamiento as Tratamiento).Explicacion  = "Explicacion de prueba";
                (tratamiento as Tratamiento).Estado  = "Inactivo";
                (tratamiento as Tratamiento).Imagen = "Imagen";

                List<Entidad> _lista = new List<Entidad>();


                Assert.IsNotNull(prueba.SqlAgregarTratamiento(tratamiento));

                (tratamiento as Tratamiento).Imagen = "Imagen";

                DAOImplemento ServerImplemento = new DAOImplemento();
                _lista = ServerImplemento.SqlConsultarImplemento(tratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(prueba.SqlAgregarTratamiento(tratamiento));

                Assert.AreEqual(300, (tratamiento as Tratamiento).Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);
                Assert.IsNotEmpty(_lista);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion

        #region ConsultarXNombreImplementoTest
        [Test]
        public void ConsultarXNombreImplementoTest()
        {
            try
            {
                DAOTratamiento prueba = new DAOTratamiento();
                Entidad tratamiento = FabricaEntidad.NuevoTratamiento();

                (tratamiento as Tratamiento).Id = 1;
                (tratamiento as Tratamiento).Nombre = "Tratamiento de prueba";
                (tratamiento as Tratamiento).Duracion = 2;
                (tratamiento as Tratamiento).Costo = 300;
                (tratamiento as Tratamiento).Descripcion = "Descripcion de prueba";
                (tratamiento as Tratamiento).Explicacion = "Explicacion de prueba";
                (tratamiento as Tratamiento).Estado = "Inactivo";
                (tratamiento as Tratamiento).Imagen = "Imagen";

                List<Entidad> _lista = new List<Entidad>();
   

                String nombreImplemento = "Resina";
                DAOImplemento serverImplemento = new DAOImplemento();
                _lista = serverImplemento.SqlBuscarXNombreImplemento(nombreImplemento, tratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(nombreImplemento);


                //Assert para que los string no esten vacios
                //Assert.IsNotEmpty(_lista);


            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }

        }
        #endregion

        //#region SqlConsultarDetalleImplementoTest
        //[Test]
        //public void SqlConsultarDetalleImplementoTest()
        //{

        //    Int16 id1 = 1;
        //    DAOImplemento serverImplemento = new DAOImplemento();
        //    Implemento miImplemento = serverImplemento.SqlConsultarDetalleImplemento(id1);

        //    //Assert que comprueba que el objeto exista.
        //    Assert.IsNotNull(miImplemento);


        //}
        //#endregion

        #region sqlModificarImplementoTest
        [Test]
        public void sqlModificarImplementoTest()
        {

            DAOImplemento prueba = new DAOImplemento();
            Entidad implemento = FabricaEntidad.NuevoImplemento();

            (implemento as Implemento).IdTratamiento = 1;
            (implemento as Implemento).IdProducto = 1;
            (implemento as Implemento).Prioridad = 1;
            (implemento as Implemento).TipoProducto = "Tratamiento de prueba";
            (implemento as Implemento).Cantidad = 2;

            List<Entidad> lista = new List<Entidad>(); ;
            bool ImplementoAgregado = false;

            Assert.IsNotNull(prueba.SqlAgregarImplemento(implemento));

            DAOImplemento serverImplemento = new DAOImplemento();
            ImplementoAgregado = serverImplemento.SqlModificarImplemento(implemento);

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(implemento);


            //Assert para que los string no esten vacios
            Assert.IsNotEmpty((implemento as Implemento).TipoProducto);

            Assert.IsTrue(ImplementoAgregado);

        }
        #endregion

        #region sqlEliminarImplementoAsociadoTest
        [Test]
        public void sqlEliminarTratamientoAsociadoTest()
        {
            DAOTratamiento prueba1 = new DAOTratamiento();
            Entidad tratamiento = FabricaEntidad.NuevoTratamiento();



            (tratamiento as Tratamiento).Id = 2;
            (tratamiento as Tratamiento).Nombre = "Tratamiento de prueba";
            (tratamiento as Tratamiento).Duracion = 2;
            (tratamiento as Tratamiento).Costo = 300;
            (tratamiento as Tratamiento).Descripcion = "Descripcion de prueba";
            (tratamiento as Tratamiento).Explicacion = "Explicacion de prueba";
            (tratamiento as Tratamiento).Estado = "Inactivo";
            (tratamiento as Tratamiento).Imagen = "Imagen";

            
   

            DAOImplemento serverImplemento = new DAOImplemento();
            bool prueba = serverImplemento.SqlEliminarImplementosAsociado(tratamiento);

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(tratamiento);

            //Assert para que los string no esten vacios
            Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);
            Assert.IsNotNull(prueba);

        }
        #endregion


        #region sqlConsultarNoImplementoTratamiento Test
        [Test]
        public void sqlConsultarNoImplementoTratamientoTEst()
        {

            try
            {
                DAOTratamiento prueba1 = new DAOTratamiento();
                Entidad tratamiento = FabricaEntidad.NuevoTratamiento();



                (tratamiento as Tratamiento).Id = 1;
                (tratamiento as Tratamiento).Nombre = "Tratamiento de prueba";
                (tratamiento as Tratamiento).Duracion = 2;
                (tratamiento as Tratamiento).Costo = 300;
                (tratamiento as Tratamiento).Descripcion = "Descripcion de prueba";
                (tratamiento as Tratamiento).Explicacion = "Explicacion de prueba";
                (tratamiento as Tratamiento).Estado = "Inactivo";
                (tratamiento as Tratamiento).Imagen = "Imagen";

                Assert.IsNotNull(prueba1.SqlAgregarTratamiento(tratamiento));

                List<Entidad> listaImplemento = new List<Entidad>();

                 (tratamiento as Tratamiento).Imagen = "Imagen";
                DAOImplemento serverImplemento = new DAOImplemento();
                listaImplemento = serverImplemento.SqlConsultarNoImplementoTratamiento(tratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(tratamiento);

                Assert.AreEqual(300, (tratamiento as Tratamiento).Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);
                Assert.IsNotEmpty(listaImplemento);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion

    }
}
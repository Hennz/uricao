using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.ETratamientos;


namespace Uricao.PruebasUnitarias.PTratamiento
{
    [TestFixture]
    public class PruebaDAOTratamiento
    {

        [Test]
        public void ConstructorTratamientoPrueba()
        {
            DAOTratamiento prueba = new DAOTratamiento();
            Entidad tratamiento = FabricaEntidad.NuevoTratamiento();

            (tratamiento as Tratamiento).Nombre = "Tratamiento de prueba";
            (tratamiento as Tratamiento).Duracion = 2;
            (tratamiento as Tratamiento).Costo = 300;
            (tratamiento as Tratamiento).Descripcion = "Descripcion de prueba";
            (tratamiento as Tratamiento).Explicacion = "Explicacion de prueba";
            (tratamiento as Tratamiento).Estado = "Inactivo";
            (tratamiento as Tratamiento).Imagen = "Imagen";

            Assert.IsNotNull(prueba.SqlAgregarTratamiento(tratamiento));
            Assert.IsTrue(prueba.SqlAgregarTratamiento(tratamiento));


            String nombreEsperado = "Tratamiento de prueba";
            String descripcionEsperado = "Descripcion de prueba";
            String explicacionEsperado = "Explicacion de prueba";
            String estadoEsperado = "Inactivo";

            Assert.IsNotNull(tratamiento);
            //probando gets
            Assert.AreEqual((tratamiento as Tratamiento).Nombre, nombreEsperado);
            Assert.AreEqual((tratamiento as Tratamiento).Duracion, 2);
            Assert.AreEqual((tratamiento as Tratamiento).Costo, 300);
            Assert.AreEqual((tratamiento as Tratamiento).Descripcion, descripcionEsperado);
            Assert.AreEqual((tratamiento as Tratamiento).Explicacion, explicacionEsperado);
            Assert.AreEqual((tratamiento as Tratamiento).Estado, estadoEsperado);


            //probando sets
            (tratamiento as Tratamiento).Nombre = "Tratamiento de prueba2";
            (tratamiento as Tratamiento).Duracion = 20;
            (tratamiento as Tratamiento).Costo = 3000;
            (tratamiento as Tratamiento).Descripcion = "Descripcion de prueba2";
            (tratamiento as Tratamiento).Explicacion = "Explicacion de prueba2";
            (tratamiento as Tratamiento).Estado = "Activo";
            (tratamiento as Tratamiento).Imagen = "Imagen";

            Assert.AreEqual((tratamiento as Tratamiento).Nombre, "Tratamiento de prueba2");
            Assert.AreEqual((tratamiento as Tratamiento).Duracion, 20);
            Assert.AreEqual((tratamiento as Tratamiento).Costo, 3000);
            Assert.AreEqual((tratamiento as Tratamiento).Descripcion, "Descripcion de prueba2");
            Assert.AreEqual((tratamiento as Tratamiento).Explicacion, "Explicacion de prueba2");
            Assert.AreEqual((tratamiento as Tratamiento).Estado, "Activo");
        }




        [Test]

        public void CambiarEstadoPrueba()
        {
            DAOTratamiento prueba = new DAOTratamiento();
            Entidad tratamiento = FabricaEntidad.NuevoTratamiento();

            (tratamiento as Tratamiento).Nombre = "Tratamiento de prueba";
            (tratamiento as Tratamiento).Duracion = 2;
            (tratamiento as Tratamiento).Costo = 300;
            (tratamiento as Tratamiento).Descripcion = "Descripcion de prueba";
            (tratamiento as Tratamiento).Explicacion = "Explicacion de prueba";
            (tratamiento as Tratamiento).Estado = "Inactivo";
            (tratamiento as Tratamiento).Imagen = "Imagen";
          

           Entidad x = FabricaEntidad.NuevoTratamiento();
            (x as Tratamiento).CambiarEstado(tratamiento);

            Assert.IsNotNull(prueba.SqlActivarDesactivarTratamiento(tratamiento));
            Assert.IsTrue(prueba.SqlActivarDesactivarTratamiento(tratamiento));
            Assert.AreNotEqual((x as Tratamiento).Estado, (tratamiento as Tratamiento).Estado);
           


        }

        #region sqlAgregarTratamientoTest
        [Test]
        public void SqlAgregarTratamientoTest()
        {

            try
            {
                DAOTratamiento prueba = new DAOTratamiento();
                Entidad tratamiento = FabricaEntidad.NuevoTratamiento();

                (tratamiento as Tratamiento).Nombre = "Tratamiento de prueba";
                (tratamiento as Tratamiento).Duracion = 2;
                (tratamiento as Tratamiento).Costo = 300;
                (tratamiento as Tratamiento).Descripcion = "Descripcion de prueba";
                (tratamiento as Tratamiento).Explicacion = "Explicacion de prueba";
                (tratamiento as Tratamiento).Estado = "Inactivo";
                (tratamiento as Tratamiento).Imagen = "Imagen";

                Assert.IsNotNull(prueba.SqlAgregarTratamiento(tratamiento));
                Assert.IsTrue(prueba.SqlAgregarTratamiento(tratamiento));

              
                bool tratamientoInsertado = false;

                DAOTratamiento serverTratamiento = new DAOTratamiento();
                tratamientoInsertado = serverTratamiento.SqlAgregarTratamiento(tratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(tratamiento);

                Assert.AreEqual(300, (tratamiento as Tratamiento).Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);
                Assert.IsTrue(tratamientoInsertado);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion
        //li
        #region sqlAgregarTratamientoAsociadoTest
        [Test]
        public void SqlAgregarTratamientoAsociadoTest()
        {
            try
            {
                //Objeto 1
                DAOTratamiento prueba = new DAOTratamiento();
                Entidad tratamiento = FabricaEntidad.NuevoTratamiento();

                (tratamiento as Tratamiento).Id = 1;
                (tratamiento as Tratamiento).Nombre = "Tratamiento de prueba 1";
                (tratamiento as Tratamiento).Duracion = 2;
                (tratamiento as Tratamiento).Costo = 300;
                (tratamiento as Tratamiento).Descripcion = "Descripcion de prueba";
                (tratamiento as Tratamiento).Explicacion = "Explicacion de prueba";
                (tratamiento as Tratamiento).Estado = "Inactivo";
                (tratamiento as Tratamiento).Imagen = "Imagen";

                //Objeto 2

                Entidad tratamiento1 = FabricaEntidad.NuevoTratamiento();
                (tratamiento1 as Tratamiento).Id = 2;
                (tratamiento1 as Tratamiento).Nombre = "Tratamiento de prueba 2";
                (tratamiento1 as Tratamiento).Duracion = 2;
                (tratamiento1 as Tratamiento).Costo = 300;
                (tratamiento1 as Tratamiento).Descripcion = "Descripcion de prueba";
                (tratamiento1 as Tratamiento).Explicacion = "Explicacion de prueba";
                (tratamiento1 as Tratamiento).Estado = "Inactivo";
                (tratamiento1 as Tratamiento).Imagen = "Imagen";
             
                bool tratamientoAsociado = false;

                Assert.IsNotNull(prueba.SqlAgregarTratamiento(tratamiento));
                Assert.IsTrue(prueba.SqlAgregarTratamiento(tratamiento));
                Assert.IsNotNull(prueba.SqlAgregarTratamiento(tratamiento1));
                Assert.IsTrue(prueba.SqlAgregarTratamiento(tratamiento1));


                DAOTratamiento serverTratamiento = new DAOTratamiento();
                tratamientoAsociado = serverTratamiento.SqlAgregarTratamientoAsociado(tratamiento, tratamiento1);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(tratamiento);
                Assert.IsNotNull(tratamiento1);

                Assert.AreEqual(300, (tratamiento as Tratamiento).Costo);

                //Assert para que los string no esten vacios
                Assert.Less(0, (tratamiento as Tratamiento).Id);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);

                Assert.Less(0, (tratamiento1 as Tratamiento).Id);
                Assert.IsNotEmpty((tratamiento1 as Tratamiento).Nombre);
                Assert.IsNotEmpty((tratamiento1 as Tratamiento).Descripcion);
                Assert.IsNotEmpty((tratamiento1 as Tratamiento).Explicacion);
                Assert.IsNotEmpty((tratamiento1 as Tratamiento).Estado);

                Assert.IsTrue(tratamientoAsociado);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion
        //Li
        #region sqlActivar/DesactivarTratamientoTest
        [Test]
        public void SqlActicarDesactivarTratamientoTest()
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

                bool tratamientoInsertado = false;

                Assert.IsNotNull(prueba.SqlActivarDesactivarTratamiento(tratamiento));
                Assert.IsTrue(prueba.SqlActivarDesactivarTratamiento(tratamiento));

                DAOTratamiento serverTratamiento = new DAOTratamiento();
                tratamientoInsertado = serverTratamiento.SqlActivarDesactivarTratamiento(tratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(tratamiento);

                Assert.AreEqual(300, (tratamiento as Tratamiento).Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);
                Assert.IsTrue(tratamientoInsertado);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }


        }
        #endregion

        //Lista
        #region sqlConsultarListaTratamientoTest
        [Test]
        public void sqlConsultarTratamientoTest()
        {
            //LogicaTratamiento miTratamiento = new LogicaTratamiento(0,_Nombre,_Duracion,_Costo,_Descripcion,_Explicacion,_Estado); 
            DAOTratamiento serverTratamiento = new DAOTratamiento();

            List<Entidad> listaTratamiento = new List<Entidad>();
            listaTratamiento = serverTratamiento.SqlConsultarTratamiento();

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(listaTratamiento);

            //Assert que comprueba que el tratamiento no tenga campos vacios donde es obligatorio
            Assert.IsNotEmpty(listaTratamiento);
        }
        #endregion

        #region sqlModificarTratamientoTest
        [Test]
        public void sqlModificarTratamientoTest()
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

            Assert.IsNotNull(prueba.SqlAgregarTratamiento(tratamiento));
            Assert.IsTrue(prueba.SqlAgregarTratamiento(tratamiento));


            DAOTratamiento serverTratamiento = new DAOTratamiento();
            bool prueba1 = serverTratamiento.SqlModificarTratamiento(tratamiento);

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(tratamiento);

            //Assert para que los string no esten vacios
            Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);
            Assert.IsNotNull(prueba1);

        }
        #endregion

        #region sqlConsultarTratamientoAsociado Test
        [Test]
        public void SqlConsultarTratamientoAsociadoTest()
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

                Assert.IsNotNull(prueba.SqlAgregarTratamiento(tratamiento));
                Assert.IsTrue(prueba.SqlAgregarTratamiento(tratamiento));


       
                List<Entidad> listaTratamiento = new List<Entidad>();

                DAOTratamiento serverTratamiento = new DAOTratamiento();
                listaTratamiento = serverTratamiento.ConsultarTratamientoAsociado((tratamiento as Tratamiento).Id);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(tratamiento);

                Assert.AreEqual(300, (tratamiento as Tratamiento).Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);
                Assert.IsNotEmpty(listaTratamiento);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion

        #region ConsultarTratamientoNoAsociadoTest
        [Test]
        public void SqlConsultarTratamientoNoAsociadoTest()
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

                Assert.IsNotNull(prueba.SqlAgregarTratamiento(tratamiento));
                Assert.IsTrue(prueba.SqlAgregarTratamiento(tratamiento));

                List<Entidad> listaTratamiento = new List<Entidad>();

                DAOTratamiento serverTratamiento = new DAOTratamiento();
                listaTratamiento = serverTratamiento.ConsultarTratamientoNoAsociado((tratamiento as Tratamiento).Id);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(tratamiento);

                Assert.AreEqual(300, (tratamiento as Tratamiento).Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
                Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);
                Assert.IsNotEmpty(listaTratamiento);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion

        #region ConsultarXNombreTratamientoTest
        [Test]
        public void ConsultarXNombreTratamientoTest()
        {
            try
            {
                List<Entidad> listaTratamiento = new List<Entidad>();
                String nombreTratamiento = "Primera";
                DAOTratamiento serverTratamiento = new DAOTratamiento();
                listaTratamiento = serverTratamiento.SqlBuscarXNombreTramiento(nombreTratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(nombreTratamiento);


                //Assert para que los string no esten vacios
                //Assert.IsNotEmpty(listaTratamiento);


            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }

        }
        #endregion

        #region SqlBuscarXIdTratamientoTest
        [Test]
        public void sqlBuscarXIdTratamientoTest()
        {

            Int16 id1 = 1;
            DAOTratamiento serverTratamiento = new DAOTratamiento();
            Entidad tratamiento = FabricaEntidad.NuevoTratamiento();
            tratamiento = serverTratamiento.SqlBuscarXIdTratamiento(id1);

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(tratamiento);

            //Assert para que los string no esten vacios
            Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);

        }
        #endregion

        #region ConsultarXEstadoTratamientoTest
        [Test]
        public void ConsultarXEstadoTratamientoTest()
        {
            try
            {
                List<Entidad> listaTratamiento = new List<Entidad>();
                String EstadoTratamiento = "Activo";
                DAOTratamiento serverTratamiento = new DAOTratamiento();
                listaTratamiento = serverTratamiento.SqlBuscarXEstadoTramiento(EstadoTratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(EstadoTratamiento);


                //Assert para que los string no esten vacios
                Assert.IsNotEmpty(listaTratamiento);


            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }

        }
        #endregion

        #region sqlEliminarTratamientoAsociadoTest
        [Test]
        public void sqlEliminarTratamientoAsociadoTest()
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

            Assert.IsNotNull(prueba.SqlEliminarTratamientoAsociado(tratamiento));
            Assert.IsTrue(prueba.SqlEliminarTratamientoAsociado(tratamiento));

      
            DAOTratamiento serverTratamiento = new DAOTratamiento();
            bool prueba1 = serverTratamiento.SqlEliminarTratamientoAsociado(tratamiento);

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(tratamiento);

            //Assert para que los string no esten vacios
            Assert.IsNotEmpty((tratamiento as Tratamiento).Nombre);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Descripcion);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Explicacion);
            Assert.IsNotEmpty((tratamiento as Tratamiento).Estado);
            Assert.IsNotNull(prueba1);

        }
        #endregion

        
    }
 }

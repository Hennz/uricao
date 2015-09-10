using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.Entidades.ETratamientos;
//using Uricao.LogicaDeNegocios.Clases.LNTratamientos;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using System.Data;
using System.Data.SqlClient;

namespace TestTratamiento
{
    [TestFixture]
    public class TestDAOSTratamiento
    {
        #region sqlAgregarTratamientoTest
        [TestCase]
        public void SqlAgregarTratamientoTest()
        {

            try
            {
                String nombre = "Tratamiento de prueba";
                Int16 duracion = 2;
                Int16 costo = 300;
                String descripcion = "Descripcion de prueba";
                String explicacion = "Explicacion de prueba";
                String estado = "Inactivo";
                bool tratamientoInsertado = false;

                Tratamiento miTratamiento = new Tratamiento(0, nombre, duracion, costo, descripcion, explicacion, estado);
                miTratamiento.Imagen="Imagen";
                DAOTratamiento serverTratamiento = new DAOTratamiento();
                tratamientoInsertado = serverTratamiento.SqlAgregarTratamiento(miTratamiento);                              

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(miTratamiento); 

                Assert.AreEqual(costo, miTratamiento.Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty(miTratamiento.Nombre);
                Assert.IsNotEmpty(miTratamiento.Descripcion);
                Assert.IsNotEmpty(miTratamiento.Explicacion);
                Assert.IsNotEmpty(miTratamiento.Estado);
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
        [TestCase]
        public void SqlAgregarTratamientoAsociadoTest()
        {
            try
            {
                //Objeto 1
                Int16 id1 = 1;
                String nombre = "Tratamiento de prueba 1";
                Int16 duracion = 2;
                Int16 costo = 300;
                String descripcion = "Descripcion de prueba";
                String explicacion = "Explicacion de prueba";
                String estado = "Inactivo";
                //Objeto 2
                Int16 id2 = 2;
                String nombre2 = "Tratamiento de prueba 2";
                Int16 duracion2 = 2;
                Int16 costo2 = 300;
                String descripcion2 = "Descripcion de prueba";
                String explicacion2 = "Explicacion de prueba";
                String estado2 = "Inactivo";
                bool tratamientoAsociado = false;

                Tratamiento miTratamiento = new Tratamiento(id1, nombre, duracion, costo, descripcion, explicacion, estado);

                Tratamiento miTratamiento2 = new Tratamiento(id2, nombre2, duracion2, costo2, descripcion2, explicacion2, estado2);
                DAOTratamiento serverTratamiento = new DAOTratamiento();
                tratamientoAsociado = serverTratamiento.SqlAgregarTratamientoAsociado(miTratamiento, miTratamiento2);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(miTratamiento);
                Assert.IsNotNull(miTratamiento2);

                Assert.AreEqual(costo, miTratamiento.Costo);

                //Assert para que los string no esten vacios
                Assert.Less(0,miTratamiento.Id);
                Assert.IsNotEmpty(miTratamiento.Nombre);
                Assert.IsNotEmpty(miTratamiento.Descripcion);
                Assert.IsNotEmpty(miTratamiento.Explicacion);
                Assert.IsNotEmpty(miTratamiento.Estado);

                Assert.Less(0, miTratamiento2.Id);
                Assert.IsNotEmpty(miTratamiento2.Nombre);
                Assert.IsNotEmpty(miTratamiento2.Descripcion);
                Assert.IsNotEmpty(miTratamiento2.Explicacion);
                Assert.IsNotEmpty(miTratamiento2.Estado);

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
        [TestCase]
        public void SqlActicarDesactivarTratamientoTest()
        {

            try
            {

                Int16 id1 = 1;
                String nombre = "Tratamiento de prueba";
                Int16 duracion = 2;
                Int16 costo = 300;
                String descripcion = "Descripcion de prueba";
                String explicacion = "Explicacion de prueba";
                String estado = "Inactivo";
                bool tratamientoInsertado = false;

                Tratamiento miTratamiento = new Tratamiento(id1, nombre, duracion, costo, descripcion, explicacion, estado);
                miTratamiento.Imagen = "Imagen";
                DAOTratamiento serverTratamiento = new DAOTratamiento();
                tratamientoInsertado = serverTratamiento.SqlActivarDesactivarTratamiento(miTratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(miTratamiento);

                Assert.AreEqual(costo, miTratamiento.Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty(miTratamiento.Nombre);
                Assert.IsNotEmpty(miTratamiento.Descripcion);
                Assert.IsNotEmpty(miTratamiento.Explicacion);
                Assert.IsNotEmpty(miTratamiento.Estado);
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
        [TestCase]
        public void sqlConsultarTratamientoTest()
        {
            //LogicaTratamiento miTratamiento = new LogicaTratamiento(0,_Nombre,_Duracion,_Costo,_Descripcion,_Explicacion,_Estado); 
            DAOTratamiento serverTratamiento = new DAOTratamiento();
            
            List<Tratamiento> listaTratamiento;
            listaTratamiento = serverTratamiento.SqlConsultarTratamiento();

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(listaTratamiento);
          
            //Assert que comprueba que el tratamiento no tenga campos vacios donde es obligatorio
            Assert.IsNotEmpty(listaTratamiento);
        }
        #endregion

        #region sqlModificarTratamientoTest
        [TestCase]
        public void sqlModificarTratamientoTest()
        {

            Int16 id1 = 1;
            String _Nombre = "Tratamiento de prueba";
            Int16 _Duracion = 2;
            Int16 _Costo = 300;
            String _Descripcion = "Descripcion de prueba";
            String _Explicacion = "Explicacion de prueba";
            String _Estado = "Inactivo";

            Tratamiento miTratamiento = new Tratamiento(id1, _Nombre, _Duracion, _Costo, _Descripcion, _Explicacion, _Estado);
            DAOTratamiento serverTratamiento = new DAOTratamiento();
            bool prueba = serverTratamiento.SqlModificarTratamiento(miTratamiento);

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(miTratamiento);

            //Assert para que los string no esten vacios
            Assert.IsNotEmpty(miTratamiento.Nombre);
            Assert.IsNotEmpty(miTratamiento.Descripcion);
            Assert.IsNotEmpty(miTratamiento.Explicacion);
            Assert.IsNotEmpty(miTratamiento.Estado);
            Assert.IsNotNull(prueba);

        }
        #endregion

        #region sqlConsultarTratamientoAsociado Test
        [TestCase]
        public void SqlConsultarTratamientoAsociadoTest()
        {

            try
            {

                Int16 id1 = 1;
                String nombre = "Tratamiento de prueba";
                Int16 duracion = 2;
                Int16 costo = 300;
                String descripcion = "Descripcion de prueba";
                String explicacion = "Explicacion de prueba";
                String estado = "Inactivo";
                List<Tratamiento> listaTratamiento;

                Tratamiento miTratamiento = new Tratamiento(id1, nombre, duracion, costo, descripcion, explicacion, estado);
                miTratamiento.Imagen = "Imagen";
                DAOTratamiento serverTratamiento = new DAOTratamiento();
                listaTratamiento = serverTratamiento.ConsultarTratamientoAsociado(miTratamiento.Id);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(miTratamiento);

                Assert.AreEqual(costo, miTratamiento.Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty(miTratamiento.Nombre);
                Assert.IsNotEmpty(miTratamiento.Descripcion);
                Assert.IsNotEmpty(miTratamiento.Explicacion);
                Assert.IsNotEmpty(miTratamiento.Estado); 
                Assert.IsNotEmpty(listaTratamiento);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion

        #region ConsultarTratamientoNoAsociadoTest
        [TestCase]
        public void SqlConsultarTratamientoNoAsociadoTest()
        {

            try
            {

                Int16 id1 = 1;
                String nombre = "Tratamiento de prueba";
                Int16 duracion = 2;
                Int16 costo = 300;
                String descripcion = "Descripcion de prueba";
                String explicacion = "Explicacion de prueba";
                String estado = "Inactivo";
                List<Tratamiento> listaTratamiento;

                Tratamiento miTratamiento = new Tratamiento(id1, nombre, duracion, costo, descripcion, explicacion, estado);
                miTratamiento.Imagen = "Imagen";
                DAOTratamiento serverTratamiento = new DAOTratamiento();
                listaTratamiento = serverTratamiento.ConsultarTratamientoNoAsociado(miTratamiento.Id);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(miTratamiento);

                Assert.AreEqual(costo, miTratamiento.Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty(miTratamiento.Nombre);
                Assert.IsNotEmpty(miTratamiento.Descripcion);
                Assert.IsNotEmpty(miTratamiento.Explicacion);
                Assert.IsNotEmpty(miTratamiento.Estado);
                Assert.IsNotEmpty(listaTratamiento);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion

        #region ConsultarXNombreTratamientoTest
        public void ConsultarXNombreTratamientoTest()
        {
            try
            {
                List<Tratamiento> listaTratamiento;
                String nombreTratamiento="Primera";
                DAOTratamiento serverTratamiento = new DAOTratamiento();
                listaTratamiento = serverTratamiento.SqlBuscarXNombreTramiento(nombreTratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(nombreTratamiento);


                //Assert para que los string no esten vacios
                Assert.IsNotEmpty(listaTratamiento);


            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
            
        }
        #endregion

        #region SqlBuscarXIdTratamientoTest
        [TestCase]
        public void sqlBuscarXIdTratamientoTest()
        {

            Int16 id1 = 1;
            DAOTratamiento serverTratamiento = new DAOTratamiento();
            Tratamiento miTratamiento = serverTratamiento.SqlBuscarXIdTratamiento(id1);

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(miTratamiento);

            //Assert para que los string no esten vacios
            Assert.IsNotEmpty(miTratamiento.Nombre);
            Assert.IsNotEmpty(miTratamiento.Descripcion);
            Assert.IsNotEmpty(miTratamiento.Explicacion);
            Assert.IsNotEmpty(miTratamiento.Estado);

        }
        #endregion

        #region ConsultarXEstadoTratamientoTest
        public void ConsultarXEstadoTratamientoTest()
        {
            try
            {
                List<Tratamiento> listaTratamiento;
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
        [TestCase]
        public void sqlEliminarTratamientoAsociadoTest()
        {

            Int16 id1 = 1;
            String _Nombre = "Tratamiento de prueba";
            Int16 _Duracion = 2;
            Int16 _Costo = 300;
            String _Descripcion = "Descripcion de prueba";
            String _Explicacion = "Explicacion de prueba";
            String _Estado = "Inactivo";

            Tratamiento miTratamiento = new Tratamiento(id1, _Nombre, _Duracion, _Costo, _Descripcion, _Explicacion, _Estado);
            DAOTratamiento serverTratamiento = new DAOTratamiento();
            bool prueba = serverTratamiento.SqlEliminarTratamientoAsociado(miTratamiento);

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(miTratamiento);

            //Assert para que los string no esten vacios
            Assert.IsNotEmpty(miTratamiento.Nombre);
            Assert.IsNotEmpty(miTratamiento.Descripcion);
            Assert.IsNotEmpty(miTratamiento.Explicacion);
            Assert.IsNotEmpty(miTratamiento.Estado);
            Assert.IsNotNull(prueba);

        }
        #endregion


    }
}
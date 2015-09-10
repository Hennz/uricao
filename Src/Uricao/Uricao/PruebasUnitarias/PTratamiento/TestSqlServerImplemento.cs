using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Clases.LNTratamientos;
using Uricao.Entidades.EProductosInventario;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using System.Data;
using System.Data.SqlClient;

namespace TestTratamiento
{
    [TestFixture]
    public class TestDAOSImplemento
    {
        #region sqlAgregarImplementoTest
        [TestCase]
        public void sqlAgregarImplementoTest()
        {

            try
            {   
                Int16 id = 1;
                Int16 idP=1;
                Int16 prioridad = 1;
                String tipo = "Tratamiento de prueba";
                Int16 cantidad = 2;
                List<Producto> lista = null;
                bool ImplementoAgregado = false;

                Implemento miImplemento = new Implemento (id, idP, prioridad,tipo,cantidad,lista);
                DAOImplemento serverImplemento = new DAOImplemento();
                ImplementoAgregado = serverImplemento.SqlAgregarImplemento(miImplemento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(miImplemento);


                //Assert para que los string no esten vacios
                Assert.IsNotEmpty(miImplemento.TipoProducto);

                Assert.IsTrue(ImplementoAgregado);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion

        #region sqlConsultarListaImplementos Test
        [TestCase]
        public void SqlConsultarListaImplementosTest()
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
                List<Implemento> lista;

                Tratamiento miTratamiento = new Tratamiento(id1, nombre, duracion, costo, descripcion, explicacion, estado);
                miTratamiento.Imagen = "Imagen";
                DAOImplemento ServerImplemento = new DAOImplemento();
                lista = ServerImplemento.SqlConsultarImplemento(miTratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(miTratamiento);

                Assert.AreEqual(costo, miTratamiento.Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty(miTratamiento.Nombre);
                Assert.IsNotEmpty(miTratamiento.Descripcion);
                Assert.IsNotEmpty(miTratamiento.Explicacion);
                Assert.IsNotEmpty(miTratamiento.Estado);
                Assert.IsNotEmpty(lista);

            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }
        }
        #endregion

        #region ConsultarXNombreImplementoTest
        public void ConsultarXNombreImplementoTest()
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
                List<Implemento> lista;

                Tratamiento miTratamiento = new Tratamiento(id1, nombre, duracion, costo, descripcion, explicacion, estado);
                miTratamiento.Imagen = "Imagen";

                String nombreImplemento = "Resina";
                DAOImplemento serverImplemento = new DAOImplemento();
                lista = serverImplemento.SqlBuscarXNombreImplemento(nombreImplemento,miTratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(nombreImplemento);


                //Assert para que los string no esten vacios
                Assert.IsNotEmpty(lista);


            }
            catch (NullReferenceException e)
            {
                throw new Exception("no hay objeto", e);
            }

        }
        #endregion

        #region SqlConsultarDetalleImplementoTest
        [TestCase]
        public void SqlConsultarDetalleImplementoTest()
        {

            Int16 id1 = 1;
            DAOImplemento serverImplemento = new DAOImplemento();
            Implemento miImplemento = serverImplemento.SqlConsultarDetalleImplemento(id1);

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(miImplemento);


        }
        #endregion

        #region sqlModificarImplementoTest
        [TestCase]
        public void sqlModificarImplementoTest()
        {

            Int16 id = 1;
            Int16 idP = 1;
            Int16 prioridad = 1;
            String tipo = "Tratamiento de prueba";
            Int16 cantidad = 2;
            List<Producto> lista = null;
            bool ImplementoAgregado = false;

            Implemento miImplemento = new Implemento(id, idP, prioridad, tipo, cantidad, lista);
            DAOImplemento serverImplemento = new DAOImplemento();
            ImplementoAgregado = serverImplemento.SqlModificarImplemento(miImplemento);

            //Assert que comprueba que el objeto exista.
            Assert.IsNotNull(miImplemento);


            //Assert para que los string no esten vacios
            Assert.IsNotEmpty(miImplemento.TipoProducto);

            Assert.IsTrue(ImplementoAgregado);

        }
        #endregion

        #region sqlEliminarImplementoAsociadoTest
        [TestCase]
        public void sqlEliminarTratamientoAsociadoTest()
        {

            Int16 id1 = 2;
            String _Nombre = "Tratamiento de prueba";
            Int16 _Duracion = 2;
            Int16 _Costo = 300;
            String _Descripcion = "Descripcion de prueba";
            String _Explicacion = "Explicacion de prueba";
            String _Estado = "Inactivo";

            Tratamiento miTratamiento = new Tratamiento(id1, _Nombre, _Duracion, _Costo, _Descripcion, _Explicacion, _Estado);
            DAOImplemento serverImplemento = new DAOImplemento();
            bool prueba = serverImplemento.SqlEliminarImplementosAsociado(miTratamiento);

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


        #region sqlConsultarNoImplementoTratamiento Test
        [TestCase]
        public void sqlConsultarNoImplementoTratamientoTEst()
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
                List<Implemento> listaImplemento;

                Tratamiento miTratamiento = new Tratamiento(id1, nombre, duracion, costo, descripcion, explicacion, estado);
                miTratamiento.Imagen = "Imagen";
                DAOImplemento serverImplemento = new DAOImplemento();
                listaImplemento = serverImplemento.SqlConsultarNoImplementoTratamiento(miTratamiento);

                //Assert que comprueba que el objeto exista.
                Assert.IsNotNull(miTratamiento);

                Assert.AreEqual(costo, miTratamiento.Costo);

                //Assert para que los string no esten vacios
                Assert.IsNotEmpty(miTratamiento.Nombre);
                Assert.IsNotEmpty(miTratamiento.Descripcion);
                Assert.IsNotEmpty(miTratamiento.Explicacion);
                Assert.IsNotEmpty(miTratamiento.Estado);
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
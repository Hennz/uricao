using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using System.Data.SqlClient;
using System.Configuration;

namespace Uricao.PruebasUnitarias
{
    [TestFixture]
    public class PruebaConexion
    {

            [Test]
            public void PruebaAbrirConexionPrueba()
            {
                IConexionDAOS bd = new ConexionDAOS();
                SqlConnection conexion = new SqlConnection();
                String esperado = "Open";
                
                bd.AbrirConexion();
                Assert.AreEqual(esperado, bd.ObjetoConexion().State.ToString());
                
            }

            [Test]
            public void CerrarConexionPrueba()
            {
                IConexionDAOS bd = new ConexionDAOS();
                String esperado = "Closed";
                bd.AbrirConexion();              
                bd.CerrarConexion();
                Assert.AreEqual(esperado, bd.ObjetoConexion().State.ToString());

            }

            [Test]
            public void ObjetoConexionPrueba()
            {
                IConexionDAOS bd = new ConexionDAOS();
                Assert.Null(bd.ObjetoConexion());
            }
    }
}
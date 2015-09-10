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
    public class TestImplemento
    {
        [TestCase]
        public void ConstructorImplementoPrueba()
        {

            Int16 idTratamiento = 1;
            Int16 idProducto = 1;
            Int16 prioridad = 2;
            String tipoProducto = "PruebaImplemento";
            Int16 cantidad = 3;

            Implemento miImplemento = new Implemento(idTratamiento,idProducto,prioridad,tipoProducto,cantidad,null);

            
            String tipoProductoEsperado = "PruebaImplemento";


            Assert.IsNotNull(miImplemento);
            //probando gets
            Assert.AreEqual(miImplemento.IdTratamiento, 1);
            Assert.AreEqual(miImplemento.IdProducto, 1);
            Assert.AreEqual(miImplemento.Prioridad, 2);
            Assert.AreEqual(miImplemento.Cantidad, 3);
            Assert.IsNotNullOrEmpty(miImplemento.TipoProducto);
            Assert.LessOrEqual(tipoProductoEsperado, miImplemento.TipoProducto);
            //

            miImplemento.IdTratamiento = 10;
            miImplemento.IdProducto = 10;
            miImplemento.Prioridad = 20;
            miImplemento.TipoProducto = "PruebaImplemento2";
            miImplemento.Cantidad = 30;

            tipoProductoEsperado = "PruebaImplemento2";

            Assert.AreEqual(miImplemento.IdTratamiento, 10);
            Assert.AreEqual(miImplemento.IdProducto, 10);
            Assert.AreEqual(miImplemento.Prioridad, 20);
            Assert.AreEqual(miImplemento.Cantidad, 30);
            Assert.IsNotNullOrEmpty(miImplemento.TipoProducto);
            Assert.LessOrEqual(tipoProductoEsperado, miImplemento.TipoProducto);
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.Entidades.EProductosInventario;
using Uricao.LogicaDeNegocios.Clases.LNProductosInventario;

namespace Uricao.PruebasUnitarias.PProductosInventario
{
    [TestFixture]
    public class PruebasProducto
    {
        [Test]
        public void PruebaAgregarProducto()
        {
            Producto producto = new Producto();
            producto.Codigo = "11";
            producto.Nombre = "Producto prueba";
            producto.Tipo = "Producto medico";
            producto.Categoria = "Guantes";
            producto.Calidad = "Media";
            producto.Precio = Convert.ToDecimal(12);
            producto.Marca = "GUM";

            LogicaProducto logicaProducto = new LogicaProducto();
            
            Assert.IsNotNull(producto);
            Assert.IsTrue(logicaProducto.AgregarProducto(producto)); 
        }

        [Test]
        public void PruebaEditarProducto()
        {

            //Creo un producto con un codigo existente en la BD
            Producto producto = new Producto();
            producto.Codigo = "123221";
            producto.Nombre = "Guantes latex";
            producto.Tipo = "Producto medico";
            producto.Categoria = "Guantes";
            producto.Calidad = "Baja";
            producto.Precio = Convert.ToDecimal(12000);
            producto.Marca = "GUM";

            LogicaProducto logicaProducto = new LogicaProducto();

            Assert.IsNotNull(producto);
            Assert.IsTrue(logicaProducto.EditarProducto(producto));
        }

        [Test]
        public void PruebaEditarProductoGenerico()
        {
            string nombre = "Guantes latex";
            //Edito un producto generico de la BD
            Producto producto = new Producto();
            producto.Nombre = "Guantes de latex";
            producto.Tipo = "Producto medico";
            producto.Categoria = "Guantes";

            LogicaProducto logicaProducto = new LogicaProducto();

            Assert.IsNotNull(producto);
            Assert.IsTrue(logicaProducto.EditarProductoGenerico(producto,nombre));
        }
    }
}
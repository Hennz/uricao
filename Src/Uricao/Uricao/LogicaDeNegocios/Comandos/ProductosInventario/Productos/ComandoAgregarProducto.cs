using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EProveedores;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EProductosInventario;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.ProductosInventario.Productos
{
    public class ComandoAgregarProducto : Comando<Boolean>
    {
        private Entidad Producto;

        public ComandoAgregarProducto(Entidad producto)
        {
            this.Producto = producto;
        }

        public override Boolean Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProducto().AgregarProducto(Producto);
        }
    }
}
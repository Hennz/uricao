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
    public class ComandoEditarProducto : Comando<Boolean>
    {
        private Entidad producto;

        public ComandoEditarProducto(Entidad Producto)
        {
            this.producto=Producto;
        }

        public override bool Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProducto().EditarProducto(producto);
        }
    }
}

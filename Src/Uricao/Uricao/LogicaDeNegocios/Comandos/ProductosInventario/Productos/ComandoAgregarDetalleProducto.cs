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
    public class ComandoAgregarDetalleProducto : Comando<Boolean>
    {
        private Entidad Producto;

        public ComandoAgregarDetalleProducto(Entidad producto)
        {
            this.Producto = producto;
        }

        public override Boolean Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProducto().AgregarDetalleProducto(Producto);
        }
    }
}
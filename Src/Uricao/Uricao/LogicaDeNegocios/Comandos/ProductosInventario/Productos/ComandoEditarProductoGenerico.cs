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
    public class ComandoEditarProductoGenerico : Comando<Boolean>
    {
        private Entidad producto;
        private String nombreViejo;

        public ComandoEditarProductoGenerico(Entidad Producto, String nombreViejo)
        {
            this.producto = Producto;
            this.nombreViejo = nombreViejo;
        }

        public override bool Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProducto().EditarProductoGenerico(producto, nombreViejo);
        }
    }
}
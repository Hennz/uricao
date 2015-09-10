using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.ProductosInventario.Productos
{
    public class ComandoObtenerMarcasXProveedor : Comando<List<String>>
    {
        private String Proveedor;
        public ComandoObtenerMarcasXProveedor(String proveedor)
        {
            this.Proveedor = proveedor;
        }

        public override List<String> Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProducto().ConsultarMarcas(Proveedor);
        }
    }
}
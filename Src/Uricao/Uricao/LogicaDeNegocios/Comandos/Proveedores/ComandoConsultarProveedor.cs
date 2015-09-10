using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.Proveedores
{
    public class ComandoConsultarProveedor : Comando<Entidad>
    {
        private static Entidad proveedor;
        private String rif;
        private String nombre;
        private Int16 direccion;

        public ComandoConsultarProveedor(String rif, String nombre, Int16 direccion)
        {
            this.rif = rif;
            this.nombre = nombre;
            this.direccion = direccion;
            proveedor = FabricaEntidad.NuevoProveedor();
            (proveedor as Proveedor).Rif = rif;
            (proveedor as Proveedor).Nombre = nombre;
            (proveedor as Proveedor).Direccion = direccion;
        }

        public override Entidad Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProveedor().consultarProveedor(proveedor);
        }
    }
}
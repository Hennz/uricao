using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EProveedores;

namespace Uricao.LogicaDeNegocios.Comandos.Proveedores
{
    public class ComandoModificarProveedor : Comando<Boolean>
    {
        private Int16 id;
        private String rif;
        private String nombre;
        private Int16 direccion;
        private static Entidad proveedor;

        public ComandoModificarProveedor(Int16 id,String rif, String nombre, Int16 direccion)
        {
            this.id = id;
            this.rif = rif;
            this.nombre = nombre;
            this.direccion = direccion;
            proveedor = FabricaEntidad.NuevoProveedor();

            (proveedor as Proveedor).Rif = rif;
            (proveedor as Proveedor).Nombre = nombre;
            (proveedor as Proveedor).Direccion = direccion;
        }

        public override Boolean Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProveedor().ModificarProveedor(proveedor,id);
        }
    }
}
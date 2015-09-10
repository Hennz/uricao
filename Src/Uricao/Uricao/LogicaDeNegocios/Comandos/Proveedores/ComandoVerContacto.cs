using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.Proveedores
{
    public class ComandoVerContacto : Comando<Entidad>
    {
        private String rif;
        private Int16 posicion;
        public ComandoVerContacto(String rif, Int16 posicion)
        {
            this.rif = rif;
            this.posicion = posicion;
        }
        public override Entidad Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProveedor().buscarContactoConFK(rif,posicion);
        }
    }
}
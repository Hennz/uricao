using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.Proveedores
{
    public class ComandoConsultarProveedoresPorNombre : Comando<Entidad>
    {
        private String _nombre;
        public ComandoConsultarProveedoresPorNombre(String nombre)
        {
           this._nombre = nombre;
        }

        public override Entidad Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProveedor().buscarProveedorPorNombre(_nombre);
        }

    }
}
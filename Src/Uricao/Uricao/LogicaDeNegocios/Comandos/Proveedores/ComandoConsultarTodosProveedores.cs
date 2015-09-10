using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.Proveedores
{
    public class ComandoConsultarTodosProveedores : Comando<List<Entidad>>
    {
        public ComandoConsultarTodosProveedores()
        {

        }

        public override List<Entidad> Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProveedor().consultarProveedores();
        }
    }
}
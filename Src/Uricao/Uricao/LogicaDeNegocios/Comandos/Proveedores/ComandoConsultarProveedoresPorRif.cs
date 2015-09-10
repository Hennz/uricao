using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.Proveedores
{
    public class ComandoConsultarProveedoresPorRif : Comando<Entidad>
    {
        private String _rif;

        public ComandoConsultarProveedoresPorRif(String rif)
        {
            this._rif = rif;
        }
        public override Entidad Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProveedor().buscarProveedorPorRif(_rif);
        }
    }
}
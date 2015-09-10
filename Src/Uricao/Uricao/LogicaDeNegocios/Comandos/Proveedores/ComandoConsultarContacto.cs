using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.Proveedores
{
    public class ComandoConsultarContacto: Comando<Entidad>
    {
        private static Entidad contacto;
        private Int16 id;
        public ComandoConsultarContacto(Entidad _contacto,Int16 id)
        {
            this.id = id;
            contacto = FabricaEntidad.NuevoContacto();
            contacto = _contacto;
        }

        public override Entidad Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProveedor().consultarContacto(contacto,id);
        }
    }
}
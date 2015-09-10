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
    public class ComandoAgregarContacto : Comando<Boolean>
    {
        private String nombre;
        private String apellido;
        private String correo;
        private Int16 idProveedor;
        private static Entidad contacto;

        public ComandoAgregarContacto(String nombre, String apellido,String correo, Int16 id)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.idProveedor = id;
            contacto = FabricaEntidad.NuevoContacto();

            (contacto as Contacto).Nombre = nombre;
            (contacto as Contacto).Apellido = apellido;
            (contacto as Contacto).Correo = correo;
        }

        public override bool Ejecutar()
        {            
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProveedor().AgregarContacto(contacto, idProveedor);
        }
    }
}
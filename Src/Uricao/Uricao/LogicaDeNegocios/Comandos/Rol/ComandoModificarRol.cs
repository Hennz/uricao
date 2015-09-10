using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.Rol
{
    public class ComandoModificarRol : Comando<bool>
    {
        /*String _nombre;
        String _descripcion;
        Boolean _estado;
        int _idRol;*/

        private Entidad _rol;

        public ComandoModificarRol(Entidad rol)
        {
            /*this._idRol = idRol;
            this._nombre = nombreRol;
            this._descripcion = descripcionRol;
            this._estado = estado;*/
            this._rol = rol;
        }

        public override bool Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAORol().ModificarRoles(_rol);
        }
    }
}
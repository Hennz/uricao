using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;



namespace Uricao.LogicaDeNegocios.Comandos.Rol
{
    public class ComandoConsultarRol : Comando<List<Entidad>>
    {
        String _nombre;
        String _descripcion;
        Boolean _estado;
        int _idRol;

        public ComandoConsultarRol(int idRol, String nombreRol, String descripcionRol, Boolean estado)
        {
            this._idRol = idRol;
            this._nombre = nombreRol;
            this._descripcion = descripcionRol;
            this._estado = estado;
        }
        public override List<Entidad> Ejecutar()
        {            
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAORol().ConsultarRolTodo(_idRol, _nombre, _descripcion, _estado);
        }
    }
}




    

    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;


namespace Uricao.AccesoDeDatos.IDAOS
    //aqui -listo - no estaba
{
    public interface iDAORol : iDAO
    {
        List<Entidad> ConsultarRolTodo(int idRol, String nombreRol, String descripcionRol, Boolean estadoRol);

        bool AgregarRol(Entidad rol);
        bool ModificarRoles(Entidad _rol);
    }
}







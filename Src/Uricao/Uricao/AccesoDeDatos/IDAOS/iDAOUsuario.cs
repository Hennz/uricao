using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOUsuario : iDAO
    {
        List<Entidad> ConsultarUsuarioTodo();

        List<Entidad> ConsultarUsuarioParametrizado(string parametro, int seleccion);

        bool AgregarUsuario(Entidad usuario);

        bool ModificarUsuario(Entidad usuario);
    }
}
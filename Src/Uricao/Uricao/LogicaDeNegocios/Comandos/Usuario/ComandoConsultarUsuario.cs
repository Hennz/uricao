using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.Usuario
{
    public class ComandoConsultarUsuario : Comando<List<Entidad>>
    {
        public ComandoConsultarUsuario()
        {

        }

        public override List<Entidad> Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOUsuario().ConsultarUsuarioTodo();
        }
    }
}
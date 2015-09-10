using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.Usuario
{
    public class ComandoAgregarUsuario : Comando<bool>
    {
        Entidad _usuario = FabricaEntidad.NuevaUsuario();

        public ComandoAgregarUsuario(Entidad usuario)
        {
            _usuario = usuario;
        }

        public override bool Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOUsuario().AgregarUsuario(_usuario);
        }
    }
}
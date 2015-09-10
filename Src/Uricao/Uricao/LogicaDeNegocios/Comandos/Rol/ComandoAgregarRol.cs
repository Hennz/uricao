using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.Rol
{
    public class ComandoAgregarRol : Comando<bool>

    {

        Entidad _rol = FabricaEntidad.NuevoRol();

         public ComandoAgregarRol(Entidad rol)
        {
            _rol = rol;
        }

         public override bool Ejecutar()
         {
             return FabricaDAO.CrearFabricaDeDAO(1).CrearDAORol().AgregarRol(_rol);
         }
    }
}
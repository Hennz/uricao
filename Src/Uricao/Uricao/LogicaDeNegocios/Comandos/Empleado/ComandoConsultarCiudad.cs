using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.Empleado
{
    public class ComandoConsultarCiudad : Comando<List<Entidad>>
    {
        Entidad _estado;

        public ComandoConsultarCiudad(Entidad _estado)
        {
            this._estado = _estado;
        }

        public override List<Entidad> Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().ConsultarCiudad(_estado);
        }
    }
}
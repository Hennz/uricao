using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.Empleado
{
    public class ComandoConsultarEstado : Comando<List<Entidad>>
    {
        Entidad _pais;

        public ComandoConsultarEstado(Entidad _pais)
        {
            this._pais = _pais;
        }

        public override List<Entidad> Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().ConsultarEstado(_pais);
        }
    }
}
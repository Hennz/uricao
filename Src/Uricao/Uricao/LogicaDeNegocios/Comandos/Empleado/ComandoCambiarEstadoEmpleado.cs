using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Comandos.Empleado
{
    public class ComandoCambiarEstadoEmpleado : Comando<bool>
    {
        private Entidad _empleado;
        private string _estado;

        public ComandoCambiarEstadoEmpleado(Entidad _empleado)
        {
            this._empleado = _empleado;
        }

        public override bool Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().CambiarEstadoEmpleado(_empleado);
            }
            catch (ExcepcionEmpleado e)
            {
                throw new ExcepcionEmpleado("No se pudo cambiar el estado del empleado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error Desconocido", e);
            }
        }
    }
}
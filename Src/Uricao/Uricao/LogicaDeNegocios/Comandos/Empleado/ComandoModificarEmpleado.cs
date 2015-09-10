using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Comandos.Empleado
{
    public class ComandoModificarEmpleado : Comando<bool>
    {
        private Entidad _empleado;
        private Entidad _direccion;

        public ComandoModificarEmpleado(Entidad empleado, Entidad direccion)
        {
            this._empleado = empleado;
            this._direccion = direccion;
        }

        public override bool Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().ModificarEmpleado(_empleado, _direccion);
            }
            catch (ExcepcionEmpleado e)
            {
                throw new ExcepcionEmpleado("No se pudo modificar el empleado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error Desconocido", e);
            }
        }

    }
}
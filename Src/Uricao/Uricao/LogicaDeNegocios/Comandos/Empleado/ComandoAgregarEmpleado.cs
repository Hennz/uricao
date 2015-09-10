using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Comandos.Empleado
{
    public class ComandoAgregarEmpleado : Comando<bool>
    {
        private Entidad empleado;
        private Entidad direccion;

        public ComandoAgregarEmpleado(Entidad empleado, Entidad direccion)
        {
            this.empleado = empleado;
            this.direccion = direccion;
        }

        public override bool Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().AgregarEmpleado(empleado, direccion);
            }
            catch (ExcepcionEmpleado e)
            {
                throw new ExcepcionEmpleado("No se pudo agregar el empleado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error Desconocido", e);
            }
        }

    }
}
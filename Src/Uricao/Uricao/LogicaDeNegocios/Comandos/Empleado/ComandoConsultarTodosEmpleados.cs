using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Comandos.Empleado
{
    public class ComandoConsultarTodosEmpleados : Comando<List<Entidad>>
    {
        string nombreProcedimiento;

        public ComandoConsultarTodosEmpleados(string nombreProcedimiento)
        {
            this.nombreProcedimiento = nombreProcedimiento;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEmpleado().ConsultarTodosEmpleados(nombreProcedimiento);
            }
            catch (ExcepcionEmpleado e)
            {
                throw new ExcepcionEmpleado("No se pudo consultar a los empleados", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionEmpleado("Error Desconocido", e);
            }
        
        }
    }
}
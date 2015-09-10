using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOEmpleado : iDAO
    {
        List<Entidad> ConsultarTodosEmpleados(string nombreProcedimiento);
        List<Entidad> ConsultarPais();
        List<Entidad> ConsultarEstado(Entidad _pais);
        List<Entidad> ConsultarCiudad(Entidad _estado);
        bool CambiarEstadoEmpleado(Entidad _empleado);
        bool AgregarEmpleado(Entidad empleado, Entidad direccion);
        bool ModificarEmpleado(Entidad empleado, Entidad direccion);
    }
}
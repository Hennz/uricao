using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Presentacion.PaginasWeb.PTrabajadoresEmpleados;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EEmpleados
{
    public class Empleado : Usuario
    {
        private float sueldo;
        private string especialidad;

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public float Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }
    }
}
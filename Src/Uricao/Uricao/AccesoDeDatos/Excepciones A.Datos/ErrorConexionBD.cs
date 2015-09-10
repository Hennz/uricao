using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.AccesoDeDatos.Excepciones_A.Datos
{
    public class ErrorConexionBD : Exception
    {

        public ErrorConexionBD()
        {

        }


        public string MensajeError()
        {
            return "Error al realizar la conexion con la base de datos";
        }

    }
}
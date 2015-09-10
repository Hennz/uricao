using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones
{
    public class ExcepcionEmpleado : Exception
    {
        string mensaje;

        public ExcepcionEmpleado()
        {
            mensaje=null;
        }

        public ExcepcionEmpleado(string mensaje) : base(mensaje) 
        {
            this.mensaje = mensaje;
        }

        public ExcepcionEmpleado(string mensaje, Exception e): base(mensaje)
        {
            this.mensaje = mensaje;
        }

        public string MensajeError
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

    }
}
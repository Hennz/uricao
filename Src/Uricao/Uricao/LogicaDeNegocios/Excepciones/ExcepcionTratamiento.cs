using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones
{
    public class ExcepcionTratamiento : Exception
    {
        String mensaje;

        public ExcepcionTratamiento()
        {
            
        }

        public ExcepcionTratamiento (string message) : base(message) 
        {
            this.mensaje = message;
        }

        public ExcepcionTratamiento(string message, Exception excpecionSistema)
            : base(message)
        {
            this.mensaje = message;
        }

        public String MensajeError
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones
{
    public class ExcepcionImplemento : Exception
    {
        String mensaje;

        public ExcepcionImplemento()
        {
            
        }

        public ExcepcionImplemento (string message) : base(message) 
        {
            this.mensaje = message;
        }

        public ExcepcionImplemento(string message, Exception excpecionSistema)
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
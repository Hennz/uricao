using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones
{
    public class ExcepcionRoles: Exception
    {
        String mensaje;

        public ExcepcionRoles()
        {
            
        }

        public ExcepcionRoles (string message) : base(message) 
        {
            this.mensaje = message;
        }

        public ExcepcionRoles(string message, Exception excpecionSistema)
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
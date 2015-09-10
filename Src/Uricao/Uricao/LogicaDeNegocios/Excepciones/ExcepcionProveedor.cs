using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones
{
    public class ExcepcionProveedor : Exception
    {
        String mensaje;

        public ExcepcionProveedor()
        {
            
        }

        public ExcepcionProveedor (string message) : base(message) 
        {
            this.mensaje = message;
        }

        public ExcepcionProveedor (string message, Exception excpecionSistema)
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
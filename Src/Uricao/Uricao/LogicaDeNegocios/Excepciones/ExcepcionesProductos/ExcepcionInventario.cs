using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones.ExcepcionesProductos
{
    public class ExcepcionInventario : Exception
    {
         String mensaje;

        public ExcepcionInventario()
        {
            
        }

        public ExcepcionInventario (string message) : base(message) 
        {
            this.mensaje = message;
        }

        public ExcepcionInventario(string message, Exception excpecionSistema)
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
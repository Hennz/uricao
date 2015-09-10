using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones.ExcepcionesProductos
{
    public class ExcepcionProducto : Exception
    {
        String mensaje;

        public ExcepcionProducto()
        {
            
        }

        public ExcepcionProducto (string message) : base(message) 
        {
            this.mensaje = message;
        }

        public ExcepcionProducto(string message, Exception excpecionSistema)
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
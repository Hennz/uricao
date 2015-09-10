using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones
{
    public class ExceptionPresupuestoFactura : Exception
    {
// Exceptions para: DAOSPresupuestoFactura
          String mensaje;
        public ExceptionPresupuestoFactura()
        {
        
        }

        public ExceptionPresupuestoFactura (string message) : base(message)
        {
            this.mensaje =message;
        }

        public ExceptionPresupuestoFactura(string message, Exception excepcionSistema) : base(message)
        {
            this.mensaje =message;
        }
       
        public String MensajeError
        {
            get { return mensaje; }
            set { mensaje = value; }
        }



    }
}
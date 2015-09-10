using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones.ExcepcionesPresupuestoFactura
{
    public class ExcepcionPresupuestoFacturaVista : Exception
    {
        String mensaje;
        public ExcepcionPresupuestoFacturaVista()
        {

        }

        public ExcepcionPresupuestoFacturaVista(string message)
            : base(message)
        {
            this.mensaje = message;
        }

        public ExcepcionPresupuestoFacturaVista(string message, Exception excepcionSistema)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones
{
    public class ExcepcionCuentaPorPagar: Exception
    {
        private String mensajeError;
       
        
        public ExcepcionCuentaPorPagar() 
        {
            
        }

        public ExcepcionCuentaPorPagar (string message) : base(message) 
        {
            this.mensajeError = message;
        }

        public ExcepcionCuentaPorPagar(string message, Exception excpecionSistema)
            : base(message)
        {
            this.mensajeError = message;
        }

        public String MensajeError
        {
            get { return mensajeError; }
            set { mensajeError = value; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones
{
    public class ExceptionCuentaPorPagar: Exception
    {
        private String mensajeError;
       
        
        public ExceptionCuentaPorPagar() 
        {
            
        }

        public ExceptionCuentaPorPagar (string message) : base(message) 
        {
            this.mensajeError = message;
        }

        public ExceptionCuentaPorPagar(string message, Exception excpecionSistema)
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
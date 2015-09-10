using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones
{
    public class ExcepcionCita :Exception
    {
        private String mensajeError;
       
        
        public ExcepcionCita() 
        {
            
        }

        public ExcepcionCita (string message) : base(message) 
        {
            this.mensajeError = message;
        }

        public ExcepcionCita(string message, Exception excpecionSistema)
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
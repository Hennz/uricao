using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.AccesoDeDatos.Excepciones_A.Datos
{
    public class ExcepcionDAOHistoriaClinica: Exception
    {
        private string mensajeError;

        public ExcepcionDAOHistoriaClinica()
        {
        }

         public ExcepcionDAOHistoriaClinica(string message)
            : base(message)
        {
            this.mensajeError = message;
        }

         public ExcepcionDAOHistoriaClinica(string message, Exception excepcionSistema)
            : base(message)
        {
            this.mensajeError = message;
        }

        public string MensajeError
        {
            get { return mensajeError; }
            set { mensajeError = value; }
        }
    }
}
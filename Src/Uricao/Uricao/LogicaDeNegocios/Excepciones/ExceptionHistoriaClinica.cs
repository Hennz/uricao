using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones
{
    public class ExceptionHistoriaClinica : Exception
    {

        private string mensajeError;


        public ExceptionHistoriaClinica()
        {

        }

        public ExceptionHistoriaClinica(string message)
            : base(message)
        {
            this.mensajeError = message;
        }

        public ExceptionHistoriaClinica(string message, Exception excepcionSistema)
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
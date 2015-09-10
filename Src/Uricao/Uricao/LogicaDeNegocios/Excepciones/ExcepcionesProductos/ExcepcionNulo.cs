using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.LogicaDeNegocios.Excepciones.ExcepcionesProductos
{
    public class ExcepcionNulo : Exception
    {
        private string mensajeError;

        public ExcepcionNulo(string mensajeError, Exception e) : base(mensajeError)
        {
            this.mensajeError = mensajeError;
        }

        /*-----Propiedad-----*/

        public string MensajeError
        {
            get { return mensajeError; }
            set { mensajeError = value; }
        }
    }
}
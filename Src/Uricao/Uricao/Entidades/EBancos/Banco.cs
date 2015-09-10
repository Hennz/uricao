using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Uricao.Entidades.EBancos
{
    public class Banco
    {

        #region atributos

        private string nombreBanco;
        private string rif;

        private List<NumeroCuentaBanco> miNumeroCuentaBanco;
        

        #endregion atributos

        #region Gets y Sets

        public string NombreBanco
        {
            get { return nombreBanco; }
            set { nombreBanco = value; }
        }

        public string Rif
        {
            get { return rif; }
            set { rif = value; }
        }

        public List<NumeroCuentaBanco> MiNumeroCuentaBanco
        {
            get { return miNumeroCuentaBanco; }
            set { miNumeroCuentaBanco = value; }
        }

        #endregion Gets y Sets

        #region Constructores

        public Banco()
        {
            this.MiNumeroCuentaBanco = new List<NumeroCuentaBanco>();

        }


        /// <summary>
        /// constructor requerido para el funcionamiento de cuentas por pagar, modulo 7
        /// </summary>
        public Banco (string nombreBanco, string rif, List<NumeroCuentaBanco> miNumeroCuentaBanco)
        {
            this.nombreBanco = nombreBanco;
            this.rif = rif;

            this.miNumeroCuentaBanco = new List<NumeroCuentaBanco>();
            this.miNumeroCuentaBanco = miNumeroCuentaBanco;

        }


        #endregion Constructores

        

    }
}
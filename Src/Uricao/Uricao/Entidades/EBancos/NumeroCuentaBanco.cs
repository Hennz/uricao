using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using System.Configuration;
using Uricao.AccesoDeDatos.DAOS;

using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EEmpleados;
using Uricao.Entidades.ECuentasPorPagar;

namespace Uricao.Entidades.EBancos
{
    public class NumeroCuentaBanco
    {
        #region Atributos

        private string idNumeroCuentaBanco;        
        private Banco miBanco= new Banco();
        private string nomBanco;
        private Boolean estado;
        
        //atributos cuentas por pagar
        private string nroCuentaBanco;
        private string tipoCuentaBanco;

        //Cuentas Por Pagar:
        private List<CuentaPorPagar> listaCuentasPorPagar;

        #endregion Atributos

        #region constructores


        public NumeroCuentaBanco()
        {
            //atributos Listas
            this.miBanco = new Banco();
            this.listaCuentasPorPagar = new List<CuentaPorPagar>();

        }


        /// <summary>
        /// Constructor con todos los atributos. Requerido por el equipo 7 (gestion de cuentas por pagar).
        /// </summary>
        /// <param name="idNumeroCuentaBanco"></param>
        /// <param name="nroCuentaBanco"></param>
        /// <param name="miBanco"></param>
        /// <param name="tipoCuentaBanco"></param>
        /// <param name="listaCuentasPorPagar"></param>
        public NumeroCuentaBanco(string idNumeroCuentaBanco, string nroCuentaBanco, Banco miBanco, string tipoCuentaBanco, List<CuentaPorPagar> listaCuentasPorPagar)
        {
            this.idNumeroCuentaBanco = idNumeroCuentaBanco;
            this.nroCuentaBanco = nroCuentaBanco;
            this.tipoCuentaBanco = tipoCuentaBanco;

            //atributos Listas:
            this.listaCuentasPorPagar = new List<CuentaPorPagar>();
            this.listaCuentasPorPagar = listaCuentasPorPagar;

            this.miBanco = new Banco();
            this.miBanco = miBanco;            
        }


        #endregion constructores


        #region Encapsulamiento de Atributos

        /// <summary>
        /// Metodos Getters y Setters.
        /// </summary>

        public string IdNumeroCuentaBanco
        {
            get { return idNumeroCuentaBanco; }
            set { idNumeroCuentaBanco = value; }
        }

        public string NroCuentaBanco
        {
            get { return nroCuentaBanco; }
            set { nroCuentaBanco = value; }
        }

        public Banco Banco
        {
            get { return miBanco; }
            set { miBanco = value; }
        }

        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        //Cuentas Por Pagar:
        public string TipoCuentaBanco
        {
            get { return tipoCuentaBanco; }
            set { tipoCuentaBanco = value; }
        }

        public List<CuentaPorPagar> ListaCuentasPorPagar
        {
            get { return listaCuentasPorPagar; }
            set { listaCuentasPorPagar = value; }
        }

        public string NomBanco
        {
            get { return nomBanco; }
            set { nomBanco = value; }
        }
        #endregion

        #region Metodo Equals
        
        #endregion Metodo Equals

        #region Metodos
        public List<NumeroCuentaBanco> listaCuentaPorBanco(string NombreBancoSeleccionado)
        {
            List<NumeroCuentaBanco> Cuenta = new List<NumeroCuentaBanco>();
            DAOCuentaBancaria cuentasBancarias = new DAOCuentaBancaria();
            Cuenta = cuentasBancarias.ListaCuentaBancarias(NombreBancoSeleccionado);
            return Cuenta;
        }

        public List<NumeroCuentaBanco> listaTipoDeCuentas(string NombreTipoDeCuentaSeleccionado)
        {
            List<NumeroCuentaBanco> TipoCuenta = new List<NumeroCuentaBanco>();
            DAOCuentaBancaria tiposCuentasBancarias = new DAOCuentaBancaria();
            TipoCuenta = tiposCuentasBancarias.ListaCuentaBancarias(NombreTipoDeCuentaSeleccionado);
            return TipoCuenta;
        }


        #endregion Metodos

    }
}
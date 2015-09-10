using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.Entidades.EEntidad;


namespace Uricao.Entidades.EAbonos
{
    public class Abono:Entidad
    {

        #region Atributos

        private string _idAbono;
        private string _fechaAbono;
        private double _montoAbono;
        private double _deuda;
        private int _factura;
        private int _cuenta;


        //Equipo#7 no entiende  el significado de este atributo, por favor que el Equipo 6 de Cuentas por cobrar les explique:
        private double deuda;

        #endregion Atributos


        #region constructores

        public Abono()
        {
        }

        /// <summary>
        /// Constructor usado para el GridView de DetalleAbonos dentro de Consultar (ultima pag).
        /// </summary>
        /// <param name="numeroCuota"></param>
        /// <param name="nombre"></param>
        public Abono(string idAbono, string fechaAbono, double montoAbono, double deuda)
        {
            this._idAbono = idAbono;
            this._fechaAbono = fechaAbono;
            this._montoAbono = montoAbono;
            this._deuda = deuda;
        }

        #endregion constructores


        #region Encapsulamiento de atributos (Getters y Setters)

        public string IdAbono
        {
            get { return _idAbono; }
            set { _idAbono = value; }
        }



        public int Factura
        {
            get { return _factura; }
            set { _factura = value; }
        }
        public int Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        public string FechaAbono
        {
            get { return _fechaAbono; }
            set { _fechaAbono = value; }
        }

        public double MontoAbono
        {
            get { return _montoAbono; }
            set { _montoAbono = value; }
        }

        public double Deuda
        {
            get { return _deuda; }
            set { _deuda = value; }
        }

        #endregion Encapsulamiento de atributos (Getters y Setters)


        #region Metodo Equals

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Abono miAbono = (Abono)obj;

            //Listas de este objeto:
            //retorna si es igual al pasado por parametro, o no:

            /*
            return (this.banco == miCuentaPorPagar.Banco) && (this.detalle == miCuentaPorPagar.Detalle) && (this.estatus == miCuentaPorPagar.Estatus) && (this.fechaEmision == miCuentaPorPagar.FechaEmision) && (this.fechaVencimiento == miCuentaPorPagar.FechaVencimiento) && (this.idCuentaBancaria == miCuentaPorPagar.IdCuentaBancaria) && (this.idCuentaPorPagar == miCuentaPorPagar.IdCuentaPorPagar) && (this.montoActualDeuda == miCuentaPorPagar.MontoActualDeuda) && (this.montoInicialDeuda == miCuentaPorPagar.MontoInicialDeuda) && (this.numeroCuentaBancaria == miCuentaPorPagar.NumeroCuentaBancaria) && (this.tipoCuentaBancaria == miCuentaPorPagar.TipoCuentaBancaria) && (this.tipoDeuda == miCuentaPorPagar.TipoDeuda) && (this.tipoPago == miCuentaPorPagar.TipoPago) 
                && (this.Equals(miCuentaPorPagar))
            ;
             * 
             */

            return true;   //BORARR AL IMPLEMENMTAR DE VERDAD
        }


        #endregion Metodo Equals


        #region Metodos Para: CuentasPorPagar

        #region Metodo Validar Monto Abono

        public double ValidaMonto(double montoAbonado, double deuda)
        {
            return deuda - montoAbonado;
        }

        #endregion








        #endregion Metodos Para: CuentasPorPagar


        #region Metodos Para: CuentasPorCobrar

        #endregion Metodos Para: CuentasPorCobrar


    }
}
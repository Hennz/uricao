using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using System.Configuration;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EBancos;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EEmpleados;
using Uricao.Entidades.EAbonos;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.ECuentasPorPagar
{
    public class CuentaPorPagar: Entidad
    {
        #region Atributos

        private string idCuentaPorPagar;
                 
        private List<Proveedor> listaProveedor;
        private List<Empleado> listaEmpleado;
        private List<NumeroCuentaBanco> listaNumeroCuentaBanco;
        private List<Abono> listaAbono;

      
        //atributos banco: sOLO EN CASO DE MANEJAR LOS ATRIBUTOS EN ESTA CLASE... QUITAR AL ENTREGAR:
        //private string banco;
        //private string idCuentaBancaria;
        //private string numeroCuentaBancaria;
        //private string tipoCuentaBancaria;

        //atributos cuentas por pagar
        private string fechaEmision;
        private string fechaVencimiento;
        private string tipoPago;
        private string estatus;
        private string tipoDeuda;
        private string detalle;
        private double montoInicialDeuda;
        private double montoActualDeuda;
        
        //Eliminar, poner en la clase de logica de cuentas por pagar:
        //private DAOCuentasPorPagar DAOSDatosCuentasPP = new DAOCuentasPorPagar();

        #endregion Atributos


        #region Constructores

        public CuentaPorPagar()
        {
            //atributos Listas:
            this.ListaProveedor = new List<Proveedor>();
            this.listaEmpleado = new List<Empleado>();
            this.ListaNumeroCuentaBanco = new List<NumeroCuentaBanco>();
            this.listaAbono = new List<Abono>();
        }


        /// <summary>
        /// Constructor usado para el GridView de DetalleAbonos dentro de Consultar (ultima pag).
        /// </summary>
        /// <param name="numeroCuota"></param>
        /// <param name="nombre"></param>
        public CuentaPorPagar (string idCuentaPorPagar, string fechaEmision, double montoActualDeuda)
        {
            //falta el de proveedor o razon social
            this.idCuentaPorPagar = idCuentaPorPagar;
            this.fechaEmision = fechaEmision;
            this.montoActualDeuda = montoActualDeuda;

        }


        /// <summary>
        /// Constructor completo para Insertar Cuentas Por Pagar (AgregarCuentasPorPagar1.apsx).
        /// </summary>
        /// <param name="idCuentaPorPagar"></param>
        /// <param name="fechaEmision"></param>
        /// <param name="montoActualDeuda"></param>
        public CuentaPorPagar(string idCuentaPorPagar, string fechaEmision, string fechaVencimiento, string tipoPago, string estatus, string tipoDeuda, string detalle, double montoInicialDeuda, double montoActualDeuda, Proveedor miProveedor, Empleado miEmpleado, NumeroCuentaBanco numeroCuentaBanco, List<Abono> listaAbono)
        {
            //atributos Listas:
           
            //Proveedor o razon social: proveedor + otro proveedor con nombre = Nomina:
            this.ListaProveedor = new List<Proveedor>();
            this.ListaProveedor.Add(miProveedor);

            //no es usado si se itenta agregar pagos a nominas completas de empleados:
            this.listaEmpleado = new List<Empleado>();
            this.ListaEmpleado.Add(miEmpleado);

            this.ListaNumeroCuentaBanco = new List<NumeroCuentaBanco>();
            this.ListaNumeroCuentaBanco.Add(numeroCuentaBanco);

            //this.ListaBanco = new List<Banco>();
            this.listaAbono = new List<Abono>();
            this.ListaAbono = listaAbono;

            //resto de los atributos:
            this.idCuentaPorPagar = idCuentaPorPagar;
            this.fechaEmision = fechaEmision;
            this.fechaVencimiento = fechaVencimiento;
            this.tipoPago = tipoPago;
            this.estatus = estatus;
            this.tipoDeuda = tipoDeuda;
            this.detalle = detalle;
            this.montoInicialDeuda = montoInicialDeuda;
            this.montoActualDeuda = montoActualDeuda;
        }






        #endregion Constructores


        #region Encapsulamiento de Atributos

        /// <summary>
        /// Metodos Getters y Setters.
        /// </summary>

        public string IdCuentaPorPagar
        {
            get { return idCuentaPorPagar; }
            set { idCuentaPorPagar = value; }
        }

        public string FechaEmision
        {
            get { return fechaEmision; }
            set { fechaEmision = value; }
        }

        public string FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }

        public string TipoPago
        {
            get { return tipoPago; }
            set { tipoPago = value; }
        }

        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }

        public string TipoDeuda
        {
            get { return tipoDeuda; }
            set { tipoDeuda = value; }
        }

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        public double MontoInicialDeuda
        {
            get { return montoInicialDeuda; }
            set { montoInicialDeuda = value; }
        }

        public double MontoActualDeuda
        {
            get { return montoActualDeuda; }
            set { montoActualDeuda = value; }
        }

        public List<Proveedor> ListaProveedor
        {
            get { return listaProveedor; }
            set { listaProveedor = value; }
        }

        public List<Empleado> ListaEmpleado
        {
            get { return listaEmpleado; }
            set { listaEmpleado = value; }
        }

        public List<NumeroCuentaBanco> ListaNumeroCuentaBanco
        {
            get { return listaNumeroCuentaBanco; }
            set { listaNumeroCuentaBanco = value; }
        }

        public List<Abono> ListaAbono
        {
            get { return listaAbono; }
            set { listaAbono = value; }
        }

        #endregion Encapsulamiento de Atributos


        #region Metodo Equals

        /*
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            CuentaPorPagar miCuentaPorPagar = (CuentaPorPagar)obj;

            //Listas de este objeto:
            //retorna si es igual al pasado por parametro, o no:

            return (this.banco == miCuentaPorPagar.Banco) && (this.detalle == miCuentaPorPagar.Detalle) && (this.estatus == miCuentaPorPagar.Estatus) && (this.fechaEmision == miCuentaPorPagar.FechaEmision) && (this.fechaVencimiento == miCuentaPorPagar.FechaVencimiento) && (this.idCuentaBancaria == miCuentaPorPagar.IdCuentaBancaria) && (this.idCuentaPorPagar == miCuentaPorPagar.IdCuentaPorPagar) && (this.montoActualDeuda == miCuentaPorPagar.MontoActualDeuda) && (this.montoInicialDeuda == miCuentaPorPagar.MontoInicialDeuda) && (this.numeroCuentaBancaria == miCuentaPorPagar.NumeroCuentaBancaria) && (this.tipoCuentaBancaria == miCuentaPorPagar.TipoCuentaBancaria) && (this.tipoDeuda == miCuentaPorPagar.TipoDeuda) && (this.tipoPago == miCuentaPorPagar.TipoPago)
                && (this.Equals(miCuentaPorPagar))
            ;
        }
        
        */

        #endregion Metodo Equals


        #region Metodos

        /// <summary>
        /// Consultar cuentas dado el nombre del proveedor:
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns></returns>
        /*public List<CuentaPorPagar> ConsultarCuentasPorPagarProveedor(string proveedor)
        {
            try
            {
                return DAOSDatosCuentasPP.MostrarListaCuentasPorPagar(proveedor);
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }*/

        //consultar las cuentas dado unas fechas y el proveedor
        /*public List<CuentaPorPagar> ConsultarCuentasPorPagarProveedorFechas(string proveedor, string fechaInicio, string fechaFin)
        {
            try
            {
                return DAOSDatosCuentasPP.MostarCuentasPorPagarFechasProveedor(proveedor, fechaInicio, fechaFin);
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }*/
        //metodo que trae todas las cuentas dado un rango de fechas
      /*  public List<Entidad> ConsultarCuentasPorPagarFechas(string fechaInicio, string fechaFin)
        {
            try
            {
                return DAOSDatosCuentasPP.ListaCuentasPorPagarEntreFechas(fechaInicio, fechaFin);
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }
        // Metodo que trae las cuentas por pagar dado todos los filtros (incluyendo tipoDeuda)
        public List<CuentaPorPagar> ConsultarCuentasTodosFiltros(string proveedor, string fechaInicio, string fechaFin, string tipoDeuda)
        {
            try
            {
                return DAOSDatosCuentasPP.ListaCuentasPorPagarTodosFiltros(proveedor, fechaInicio, fechaFin, tipoDeuda);
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }*/

        public void CalcularDeudaActual(double abono)
        {
            this.montoActualDeuda = this.montoInicialDeuda - abono;
        }


        /// <summary>
        /// valida que un tipo double sea mayor que cero.
        /// </summary>
        /// <param name="abono"></param>
        /// <returns></returns>
        public bool ValidarMontoMayorQueCero(double abono)
        {
            return (((int) abono) > 0);
        }


        /// <summary>
        /// valida que una fecha sea mayor o igual a otra
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public bool ValidarFechaInicioMayorOigualQueFechaFin(DateTime fechaInicio, DateTime fechaFin)
        {
            int intervaloFechasValidadas = ( fechaInicio.Date.CompareTo(fechaFin.Date) );
            //fechaInicio.Date.Equals(fechaFin.Date) && 
            return (intervaloFechasValidadas <= 0);
        }

        #endregion Metodos

    }
}
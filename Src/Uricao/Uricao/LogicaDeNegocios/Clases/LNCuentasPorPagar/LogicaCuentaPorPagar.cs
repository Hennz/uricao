using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EAbonos;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.AccesoDeDatos.DAOS;


namespace Uricao.LogicaDeNegocios.Clases.LNCuentasPorPagar
{
    public class LogicaCuentaPorPagar
    {
        /*
        #region Atributos

        //Atributos para mostrar GridViews:

        //1-    GridView: Consultar o Modificar Cuenta por Pagar:
        private string codigo;
        private string fecha;
        private string razonSocialEmpresa;
        private double monto;
        private double saldoDeuda;

        //private string nombreCuentaPorPagar;


        //2-    GridView: Abonos o Giros realizados
        //private string codigo;
        //private string fecha;
        //private double monto;
        //private double saldoDeuda;


        /// <summary>
        /// Lista de Cuenta por Pagar para usar y cargar en GridViews de CONSULTAR-MODIFICAR.
        /// </summary>
        private List<CuentaPorPagar> listaCuentaPorPagar = new List<CuentaPorPagar>();

        /// <summary>
        /// Lista de Banco para usar y cargar en elementos de la GUI (ComboBoxes, Gridviews, etc).
        /// </summary>
        //private List<Banco> listaBanco = new List<Banco>();

        /// <summary>
        /// Lista de CuentaBancaria para usar y cargar en elementos de la GUI (ComboBoxes, Gridviews, etc).
        /// </summary>
        //private List<CuentaBancaria> listaCuentaBancaria = new List<CuentaBancaria>();

        /// <summary>
        /// Lista de Proveedores para usar y cargar en elementos de la GUI (ComboBoxes, Gridviews, etc).
        /// </summary>
        //private List<Proveedor> listaProveedor = new List<Proveedor>();

        /// <summary>
        /// Lista de Usuario (Empleado) para usar y cargar en elementos de la GUI (ComboBoxes, Gridviews, etc).
        /// </summary>
        //private List<Usuario> misUsuario = new List<Usuario>();


        #endregion Atributos


        #region Constructores

        public LogicaCuentaPorPagar()
        {
        }


        #endregion Constructores

        #region Getters y Setters

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string RazonSocialEmpresa
        {
            get { return razonSocialEmpresa; }
            set { razonSocialEmpresa = value; }
        }

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public double SaldoDeuda
        {
            get { return saldoDeuda; }
            set { saldoDeuda = value; }
        }


        /// <summary>
        /// Gets, Sets: LISTAS A MANEJAR EN LA GUI:
        /// </summary>

        public List<CuentaPorPagar> ListaCuentaPorPagar
        {
            get { return listaCuentaPorPagar; }
            set { listaCuentaPorPagar = value; }
        }


        #endregion Getters y Setters


        #region Metodo Equals

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            LogicaCuentaPorPagar miLogicaCuentaPorPagar = (LogicaCuentaPorPagar)obj;

            //Listas de este objeto:
            //retorna si es igual al pasado por parametro, o no:

            return (this.codigo == miLogicaCuentaPorPagar.codigo) && (this.fecha == miLogicaCuentaPorPagar.fecha) && (this.razonSocialEmpresa == miLogicaCuentaPorPagar.razonSocialEmpresa)
                && (this.Equals(miLogicaCuentaPorPagar.ListaCuentaPorPagar))
            ;
        }


        #endregion Metodo Equals


        #region Metodos LOGICA


        public bool AgregarEnBDunaCuentaPorPagar(CuentaPorPagar miCuentaPorPagar)
        {
            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miDAOSCuentasPorPagar = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para INSERTAR en la BD las CuentasPorPagar:
            bool fueInsertado = miDAOSCuentasPorPagar.InsertarCuentasPorPagar(miCuentaPorPagar);

            //Retorna la variable boolena de confirmacion del exito de la insercion:
            return fueInsertado;
        }



        public List<CuentaPorPagar> ObtenerTodasCuentasPorPagar()
        {
            List<CuentaPorPagar> miListaCuentaPorPagar = new List<CuentaPorPagar>();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            //DaoCuentaPorPagar objDataBase = new DaoCuentaPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
            //miListaCuentaPorPagar = objDataBase.consultarTodasCuentasPorPagarConStoredProcedure(fechaIni, fechaFin, ...); //ESTO DENTRO LLEVA UN "TRY-CATCH".

            ////CABLE DE GUI: Usando datos inventados que simulan la Extraccion de los mismos, desde la BD:

            for (int i = 1; i <= 9; i++)
            {
                CuentaPorPagar dato = new CuentaPorPagar("id cuenta", "CuentasPorPagar" + i, (double)i);
                miListaCuentaPorPagar.Add(dato);
            }

            ////CABLE DE GUI: Usando datos inventados que simulan la Extraccion de los mismos, desde la BD:



            return miListaCuentaPorPagar;
        }


        //VA ASI:  public List<Abono> ObtenerAbonosDeCuentaPorPagar(string idCuentaPorPagar)
        public List<Abono> ObtenerAbonosDeCuentaPorPagar()
        {
            List<Abono> miListaAbonos = new List<Abono>();

            //Creo el objeto de ACCESO A BD de Abono:
            //DaoAbono objDataBase = new DaoAbono();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
            //miListaAbonos = objDataBase.consultarAbonosDeCuentaPorPagarConStoredProcedure(idCuentaPorPagar,  ...); //ESTO DENTRO LLEVA UN "TRY-CATCH".

            ////CABLE DE GUI: Usando datos inventados que simulan la Extraccion de los mismos, desde la BD:

            for (int i = 1; i <= 9; i++)
            {
                Abono dato = new Abono(i.ToString(), "Abono ", (double)i, (double)i);
                miListaAbonos.Add(dato);
            }

            ////CABLE DE GUI: Usando datos inventados que simulan la Extraccion de los mismos, desde la BD:

            return miListaAbonos;
        }


       /* public List<CuentaPorPagar> ActivarDesactivarObtenerCuentasPorPagarProveedor(string nombreProveedor)
        {
            List<CuentaPorPagar> miListaCuentaPorPagar = new List<CuentaPorPagar>();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
            miListaCuentaPorPagar = miCuentaPorPagarBd.ActivarDesactivarMostrarListaCuentasPorPagarProveedor(nombreProveedor);

            return miListaCuentaPorPagar;
        }*/


        /*public List<CuentaPorPagar> AbonarObtenerCuentasPorPagarProveedor(string nombreProveedor)
        {
            List<CuentaPorPagar> miListaCuentaPorPagar = new List<CuentaPorPagar>();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
            miListaCuentaPorPagar = miCuentaPorPagarBd.MostrarListaCuentasPorPagar(nombreProveedor);

            return miListaCuentaPorPagar;
        }*/

        /*public CuentaPorPagar llenarAbonarCpp2(string nombreProveedor, Int64 codigoCuenta)
        {
            CuentaPorPagar cuenta = new CuentaPorPagar();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
            cuenta = miCuentaPorPagarBd.llenarAbonarCpp2(nombreProveedor, codigoCuenta);

            return cuenta;
        }


        public CuentaPorPagar ConsultarCuentaPorPagarBD(string idCuentaPorPagar)
        {
            CuentaPorPagar miCuentaPorPagar = new CuentaPorPagar();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD la CuentasPorPagar
            //miCuentaPorPagar = miCuentaPorPagarBd.ConsultarCuentaPorPagar(idCuentaPorPagar);

            return miCuentaPorPagar;
        }


        public bool ModificarCuentaPorPagarBD(CuentaPorPagar miCuentaPorPagar)
        {
            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD la CuentasPorPagar
            bool fueModificado = miCuentaPorPagarBd.ModificarCuentaPorPagar(miCuentaPorPagar);

            return fueModificado;
        }



        #region Abonar


        public bool CambiarEstatusCpp(CuentaPorPagar miCuentaPorPagar)
        {
            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miDAOSCuentasPorPagar = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para INSERTAR en la BD las CuentasPorPagar:
            bool fueInsertado = miDAOSCuentasPorPagar.CambiarEstatusCpp(miCuentaPorPagar);

            //Retorna la variable boolena de confirmacion del exito de la insercion:
            return fueInsertado;
        }

        /*public List<CuentaPorPagar> AbonarConsultarCuentasPorPagarFechas(string fechaInicio, string fechaFin)
        {
            List<CuentaPorPagar> miListaCuentaPorPagar = new List<CuentaPorPagar>();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
            miListaCuentaPorPagar = miCuentaPorPagarBd.AbonarConsultarCuentasPorPagarFechas(fechaInicio, fechaFin);

            return miListaCuentaPorPagar;
        }*/

       /* public List<CuentaPorPagar> AbonarConsultarCuentasPorPagar(string fechaInicio, string fechaFin, string proveedor)
        {
            List<CuentaPorPagar> miListaCuentaPorPagar = new List<CuentaPorPagar>();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
            miListaCuentaPorPagar = miCuentaPorPagarBd.AbonarConsultarCuentasPorPagar(fechaInicio, fechaFin, proveedor);

            return miListaCuentaPorPagar;
        }


        #endregion Abonar

        /* public List<CuentaPorPagar> ConsultarCuentasPorPagarFechasActivar(string fechai, string fechaf)
        {
            List<CuentaPorPagar> miListaCuentaPorPagar = new List<CuentaPorPagar>();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
            miListaCuentaPorPagar = miCuentaPorPagarBd.ConsultarCuentasPorPagarFechasActivar(fechai,fechaf);
            return miListaCuentaPorPagar;
        }*/

       /* public List<CuentaPorPagar> ConsultarCuentasPorPagarFechasProveedorActivar(string fechai, string fechaf, string proveedor)
        {
            List<CuentaPorPagar> miListaCuentaPorPagar = new List<CuentaPorPagar>();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
            miListaCuentaPorPagar = miCuentaPorPagarBd.ConsultarCuentasPorPagarFechasProveedorActivar(fechai, fechaf, proveedor);
            return miListaCuentaPorPagar;
        }

        /// <summary>
        /// Metodo booleano para 
        /// activar y desactivar una 
        /// Cuenta por Pagar
        /// </summary>
        /// <param name="miCuentaPorPagar"></param>
        /// <returns></returns>
        public bool ActivarDesactivarCpp(CuentaPorPagar miCuentaPorPagar)
        {
            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miDAOSCuentasPorPagar = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para INSERTAR en la BD las CuentasPorPagar:
            bool fueInsertado = miDAOSCuentasPorPagar.ActivarDesactivarCpp(miCuentaPorPagar);

            //Retorna la variable boolena de confirmacion del exito de la insercion:
            return fueInsertado;
        }

        /*public List<CuentaPorPagar> MostrarListaCuentasPorPagar(string proveedor)
        {
            List<CuentaPorPagar> miListaCuentaPorPagar = new List<CuentaPorPagar>();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
            miListaCuentaPorPagar = miCuentaPorPagarBd.MostrarListaCuentasPorPagar(proveedor);
            return miListaCuentaPorPagar;
        }

        public List<CuentaPorPagar> ListaCuentasPorPagarEntreFechas(string fechai,string fechaf)
        {
            List<CuentaPorPagar> miListaCuentaPorPagar = new List<CuentaPorPagar>();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
           // miListaCuentaPorPagar = miCuentaPorPagarBd.ListaCuentasPorPagarEntreFechas(fechai, fechaf);
            return miListaCuentaPorPagar;
        }

        public List<CuentaPorPagar> MostarCuentasPorPagarFechasProveedor(string proveedor,string fechai, string fechaf)
        {
            List<CuentaPorPagar> miListaCuentaPorPagar = new List<CuentaPorPagar>();

            //Creo el objeto de ACCESO A BD de CuentaPorPagar:
            DAOCuentasPorPagar miCuentaPorPagarBd = new DAOCuentasPorPagar();

            //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
          //  miListaCuentaPorPagar = miCuentaPorPagarBd.MostarCuentasPorPagarFechasProveedor(proveedor, fechai, fechaf);
            return miListaCuentaPorPagar;
        }


        #endregion Metodos LOGICA*/

    }

}
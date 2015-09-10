using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EBancos;


namespace Uricao.LogicaDeNegocios.Clases.LNBancos
{
    public class LogicaBanco
    {
        public List<string> EnlistaBancos()
        {
            List<string> listaBancos = new List<string>();
            DAOBanco Conexion = new DAOBanco();
            try
            {
                
                listaBancos = Conexion.ListaBancoCliente();
               
            }
            catch (Exception)
            {

               // throw;
            }
            return listaBancos;
        }

        public List<string> EnlistaTipoCuenta()
        {

            DAOBanco Conexion = new DAOBanco();
            List<string> listaTipoCuentas = new List<string>();
            try
            {

                listaTipoCuentas = Conexion.ListaTipoCuentas();
       
            }
            catch (Exception)
            {

               // throw;
            }
            return listaTipoCuentas;
        }
        public List<NumeroCuentaBanco> llenarDataGridBancos(string nombreBancoSeleccionado)
        {
            List<NumeroCuentaBanco> listaNumeroCuenta = new List<NumeroCuentaBanco>();
            NumeroCuentaBanco nroCuenta = new NumeroCuentaBanco();
            listaNumeroCuenta = nroCuenta.listaCuentaPorBanco(nombreBancoSeleccionado);
            // Metodo de Entidades para llenar la lista
            return listaNumeroCuenta;
        }

        public List<NumeroCuentaBanco> llenarDataGridTipoCuenta(string nombreTipoCuentaSeleccionado)
        {
            List<NumeroCuentaBanco> listaTiposCuentas = new List<NumeroCuentaBanco>();
            DAOCuentaBancaria bdCuenta = new DAOCuentaBancaria();
            listaTiposCuentas = bdCuenta.ListaConsultaTipoCuenta(nombreTipoCuentaSeleccionado);
            // Metodo de Entidades para llenar la lista
            return listaTiposCuentas;
        }

        public List<NumeroCuentaBanco> llenarDataGridInfoCuentas()
        {
            List<NumeroCuentaBanco> listaInfoCuentas = new List<NumeroCuentaBanco>();
            DAOCuentaBancaria bdCuenta = new DAOCuentaBancaria();
            listaInfoCuentas = bdCuenta.ListaConsultaCuentasBancarias();
            // Metodo de Entidades para llenar la lista
            return listaInfoCuentas;
        }

        public Boolean agregarBanco(string nombreBanco, string numeroCuenta, string tipoCuenta, int tipoAgregacion)
        {
            DAOBanco bdAgregar = new DAOBanco();
            return bdAgregar.AgregarBancoBD(nombreBanco, numeroCuenta, tipoCuenta, tipoAgregacion);
        }



        #region MostrarBancoProveedores parametro Proveedor (usado por: Equipo 7)

        /// <summary>
        /// Metodo Requerido por el grupo 7. Cuentas Por pagar.
        /// Invoca a (en la Clase SqlSeverBanco.cs):
        /// public List<Banco> ListaBancoProveedores(string nombreProveedor)
        /// </summary>
        /// <returns>
        /// ""Nombre banco"", dado el ""nombre proveedor"" como entrada.
        /// </returns>
        public List<Banco> MostrarListadoBancoPorProveedores(string nombreProveedor)
        {
            List<Banco> listaBancos = new List<Banco>();
            DAOBanco objDataBase = new DAOBanco();
            //Invocar  al metodo que lo saca desde la Bd:
            listaBancos = objDataBase.ListaBancoProveedores(nombreProveedor);
            return listaBancos;
        }

        #endregion MostrarBancoProveedores parametro Proveedor (usado por: Equipo 7)


        #region MostrarCuentaProveedores parametro Proveedor y Banco (usado por: Equipo 7)

        /// <summary>
        /// Metodo Requerido por el grupo 7. Cuentas Por pagar.
        /// Invoca a (en la Clase SqlSeverBanco.cs):
        ///public List<NumeroCuentaBanco> ListaNumeroCuentaBancariaProveedores(string nombreProveedor, string nombreBanco)
        /// </summary>
        /// <returns>
        /// ""Numero Cuenta Bancaria"", dados: [""nombre proveedor"", ""Nombre banco""] como entrada.
        /// </returns>
        public List<NumeroCuentaBanco> MostrarListaNumeroCuentaBancariaProveedores(string nombreProveedor, string nombreBanco)
        {
            List<NumeroCuentaBanco> listaNumerosCuentaBanco = new List<NumeroCuentaBanco>();
            DAOBanco objDataBase = new DAOBanco();
            //Invocar  al metodo que lo saca desde la Bd:
            listaNumerosCuentaBanco = objDataBase.ListaNumeroCuentaBancariaProveedores(nombreProveedor, nombreBanco);
            return listaNumerosCuentaBanco;
        }


        #endregion MostrarCuentaProveedores parametro Proveedor y Banco (usado por: Equipo 7)
    }
}
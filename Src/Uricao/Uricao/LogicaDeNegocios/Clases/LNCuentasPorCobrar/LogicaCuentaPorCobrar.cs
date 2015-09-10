using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.EAbonos;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Uricao.Entidades.EEntidad;


namespace Uricao.LogicaDeNegocios.Clases.LNCuentasPorCobrar
{
    public class LogicaCuentaPorCobrar
    {
        public CuentaPorCobrar _cuenta = new CuentaPorCobrar();
        public List<CuentaPorCobrar> _listaCuentas = new List<CuentaPorCobrar>();


        public LogicaCuentaPorCobrar() { }


        /*      public bool AgregarCuentaCobrar()
              {
                  return false;
              }*/


        /*       public bool ValidarEstado(int idCuenta, string estadoNuevo)
               {
                   Totales total = new Totales();
                   DAOCuentasPorCobrar objDataBase = new DAOCuentasPorCobrar();
                   total = objDataBase.consultarTotalesAbonoFactura(idCuenta) as Totales;


                       if (total.TotalFactura - total.TotalAbono > 0)
                       {
                           if (estadoNuevo.Equals("Desactivar") || estadoNuevo.Equals("Por Pagar"))
                           {
                               return true;
                           }
                           else
                           {
                               return false;
                           }

                       }
                       else
                       {
                           if (estadoNuevo.Equals("Pagada"))
                           {
                               return true;
                           }
                           else
                           {
                               return false;
                           }

                       }
               }
       */

        /*   public bool ModificarEstado(int idCuenta, string estadoNuevo)
           {
               bool valEstado = ValidarEstado(idCuenta, estadoNuevo);
               if (valEstado)
               {
                   bool estado;
                   DAOCuentasPorCobrar objDataBase = new DAOCuentasPorCobrar();
                   estado = objDataBase.ModificarEstado(idCuenta, estadoNuevo);
                   if (estado)
                   {
                       return true;
                   }
                   else
                   {
                       return false;
                   }
               }
               else 
               {
                   return false;
               }

            
           }

           */

        /* public double CalcularDeudaTotal()
         {
             return 0.0;
         }
         */

        /* public List<CuentaPorCobrar> ConsultarCuentaPorFecha()
         {
             return null;
         }/*

         /*public List<Entidad> ObtenerCuentas()
         {
             List<Entidad> miLista = new List<Entidad>();
             DAOCuentasPorCobrar objDataBase = new DAOCuentasPorCobrar();

             miLista = objDataBase.consultarCuentaCobrarConStoredProcedure();
             return miLista;
         }*/

        /*public List<Entidad> consultarDetalleFactura(int factura)
        {
            List<Entidad> miLista = new List<Entidad>();
            DAOCuentasPorCobrar objDataBase = new DAOCuentasPorCobrar();

            miLista = objDataBase.consultarDetalleFactura(factura);
            return miLista;
        }*/

        /*public List<Entidad> ObtenerUsuarioCedula(string tipo,string cedula)
        {
            List<Entidad> miLista = new List<Entidad>();
            DAOCuentasPorCobrar objDataBase = new DAOCuentasPorCobrar();

            miLista = objDataBase.consultarUsuarioCedula(tipo,cedula);
            return miLista;
            //detalle
        }*/

        /*public List<Entidad> ObtenerUsuarioFechas(string fechainicio, string fechafin)
        {
            //cuentaspor cobrar
            List<Entidad> miLista = new List<Entidad>();
            DAOCuentasPorCobrar objDataBase = new DAOCuentasPorCobrar();

            miLista = objDataBase.consultarUsuarioFechas(fechainicio, fechafin);
            return miLista;
        }*/

        /*  public List<Entidad> ObtenerFacturaCF(string cedula,string tipo,string fechainicio, string fechafin)
          {
              //ficticia
              List<Entidad> miLista = new List<Entidad>();
              DAOCuentasPorCobrar objDataBase = new DAOCuentasPorCobrar();

              miLista = objDataBase.consultarFacturaCF(fechainicio, fechafin,cedula,tipo);
              return miLista;
          }
          */
        /* public List<Entidad> ObtenerFacturaCedula(string cedula, string tipo)
         {
             //fictia 
             List<Entidad> miLista = new List<Entidad>();
             DAOCuentasPorCobrar objDataBase = new DAOCuentasPorCobrar();

             miLista = objDataBase.consultarFacturaCedula(cedula,tipo);
             return miLista;
         }*/

        /*public List<Entidad> BuscarAbonos(int idfactura)
        {
            //Abono
            List<Entidad> miLista = new List<Entidad>();
            DAOCuentasPorCobrar objDataBase = new DAOCuentasPorCobrar();

            miLista = objDataBase.BuscarAbonos(idfactura);
            return miLista;
        }
        */



        /*   public List<CuentaPorCobrar> ConsultarCuentaPorCedula()
           {
               return null;
           }

           public List<CuentaPorCobrar> ConsultarCuentaCedulaFechas()
           {
               return null;
           }*/

    }
}

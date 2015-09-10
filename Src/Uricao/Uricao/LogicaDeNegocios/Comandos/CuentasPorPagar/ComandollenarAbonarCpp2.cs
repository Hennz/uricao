using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.CuentasPorPagar
{
    public class ComandollenarAbonarCpp2: Comando<Entidad>
    {
        private string _nombreProveedor;
        private Int64 _codigoCuenta;
        public ComandollenarAbonarCpp2(string nombreProveedor, Int64 codigoCuenta)
        {
            this._nombreProveedor = nombreProveedor;
            this._codigoCuenta = codigoCuenta;
        }

         public override Entidad Ejecutar()
         {
             try
             {
                 return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorPagar().llenarAbonarCpp2(_nombreProveedor, _codigoCuenta);

             }
             catch (Exception ex)
             {
                 throw new Exception("No se logro consultar las Cuentas Por Pagar : " + "", ex);
             }
         }
    }
}
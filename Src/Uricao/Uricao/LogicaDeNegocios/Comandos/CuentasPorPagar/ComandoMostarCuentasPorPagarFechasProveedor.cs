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
    public class ComandoMostarCuentasPorPagarFechasProveedor : Comando<List<Entidad>>
    {

        private string _fechaInicio;
        private string _fechaFin;
        private string _proveedor;
         public ComandoMostarCuentasPorPagarFechasProveedor()
        {
        }

         public ComandoMostarCuentasPorPagarFechasProveedor(string fechaInicio, string fechaFin, string proveedor)
        {
            this._fechaInicio = fechaInicio;
            this._fechaFin = fechaFin;
            this._proveedor = proveedor;
        }

         public override List<Entidad> Ejecutar()
         {
             try
             {
                 return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorPagar().MostarCuentasPorPagarFechasProveedor(_fechaInicio, _fechaFin, _proveedor);

             }
             catch (Exception ex)
             {
                 throw new Exception("No se logro consultar las Cuentas Por Pagar : " + "", ex);
             }
         }
    }
}
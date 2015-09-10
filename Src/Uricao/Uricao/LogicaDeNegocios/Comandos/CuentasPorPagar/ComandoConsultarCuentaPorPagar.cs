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
    public class ComandoConsultarCuentaPorPagar : Comando<Entidad>
    {
        private string _idCuentaPorPagar;

        public ComandoConsultarCuentaPorPagar(string idCuentaPorPagar)
        {
            this._idCuentaPorPagar = idCuentaPorPagar;
         
        }

         public override Entidad Ejecutar()
         {
             try
             {
                 return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorPagar().ConsultarCuentaPorPagar(_idCuentaPorPagar);

             }
             catch (Exception ex)
             {
                 throw new Exception("No se logro consultar las Cuentas Por Pagar : " + "", ex);
             }
         }
    }
}
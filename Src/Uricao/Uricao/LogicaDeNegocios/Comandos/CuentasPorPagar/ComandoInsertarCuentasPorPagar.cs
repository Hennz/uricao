using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.FabricasEntidad;


namespace Uricao.LogicaDeNegocios.Comandos.CuentasPorPagar
{
    public class ComandoInsertarCuentasPorPagar : Comando<bool>
    {
         private Entidad _miCuentaPorPagar;
         public ComandoInsertarCuentasPorPagar()
        {
        }

         public ComandoInsertarCuentasPorPagar(Entidad miCuentaPorPagar)
        {

            this._miCuentaPorPagar = miCuentaPorPagar;
        }

         public override bool Ejecutar()
         {
             try
             {
                 return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorPagar().InsertarCuentasPorPagar(_miCuentaPorPagar);

             }
             catch (Exception ex)
             {
                 throw new Exception("No se logro consultar las Cuentas Por Pagar : " + "", ex);
             }
         }
    }
}
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
    public class ComandoListaCuentasPorPagarEntreFechas: Comando<List<Entidad>>
    {

        private string _fechaInicio;
        private string _fechaFin;
         public ComandoListaCuentasPorPagarEntreFechas()
        {
        }

         public ComandoListaCuentasPorPagarEntreFechas(string fechaInicio, string fechaFin)
        {
            this._fechaInicio = fechaInicio;
            this._fechaFin = fechaFin;
        }

         public override List<Entidad> Ejecutar()
         {
             try
             {
                 return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorPagar().ListaCuentasPorPagarEntreFechas(_fechaInicio, _fechaFin);

             }
             catch (Exception ex)
             {
                 throw new Exception("No se logro consultar las Cuentas Por Pagar : " + "", ex);
             }
         }
    }
}
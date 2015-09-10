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
    public class ComandoAbonarObtenerCuentasPorPagarProveedor : Comando<List<Entidad>>
    {
        private string _nombreProveedor;
        public ComandoAbonarObtenerCuentasPorPagarProveedor()
        {
        }

        public ComandoAbonarObtenerCuentasPorPagarProveedor(string nombreProveedor)
        {
            this._nombreProveedor = nombreProveedor;
        }




        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorPagar().ActivarDesactivarMostrarListaCuentasPorPagarProveedor(_nombreProveedor);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Cuentas Por Pagar : " + "", ex);
            }
        }
    }
}
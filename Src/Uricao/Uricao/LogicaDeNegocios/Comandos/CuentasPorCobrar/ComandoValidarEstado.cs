using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.AccesoDeDatos.DAOS;
namespace Uricao.LogicaDeNegocios.Comandos.CuentasPorCobrar
{
    public class ComandoValidarEstado : Comando<bool>
    {
        #region Atributos
        private int _idCuenta;
        private string _estadoNuevo;
        #endregion Atributos
        #region Constructor
        public ComandoValidarEstado(int idCuenta, string estadoNuevo)
        {
            this._estadoNuevo = estadoNuevo;
            this._idCuenta = idCuenta;
        }
        #endregion Constructor
        #region Metodo
        public override bool Ejecutar()
        {
            Totales total = FabricaEntidad.NuevosTotales();
            
            total = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorCobrar().consultarTotalesAbonoFactura(_idCuenta) as Totales;
                


            if (total.TotalFactura - total.TotalAbono > 0)
            {
                if (_estadoNuevo.Equals("Desactivar") || _estadoNuevo.Equals("Por Pagar"))
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
                if (_estadoNuevo.Equals("Pagada"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        #endregion Metodos
    }
}
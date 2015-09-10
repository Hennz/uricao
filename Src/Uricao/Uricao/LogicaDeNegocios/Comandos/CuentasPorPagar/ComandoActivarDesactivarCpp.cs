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
    public class ComandoActivarDesactivarCpp : Comando<bool>
    {
        private Int64 _idCuentaPP;
        private Entidad _miCuentaPP;
        #region Constructor
        public ComandoActivarDesactivarCpp()
        {
        }

        public ComandoActivarDesactivarCpp(Entidad miCuentaPP)
        {
            this._miCuentaPP = miCuentaPP;
        }
        #endregion

        #region Metodos

        public override bool Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorPagar().ActivarDesactivarCpp(_miCuentaPP);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Facturas : " + "", ex);
            }
        }

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAbonos;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.Abono
{
    public class ComandollenarGridAbonos:Comando<List<Entidad>>
    {
        private Int64 _idCuentaPP;
        private string _nombreProveedor;
        #region Constructor
        public ComandollenarGridAbonos()
        {
        }

        public ComandollenarGridAbonos(string nombreProveedor, Int64 idCuentaPP)
        {
            this._nombreProveedor = nombreProveedor;
            this._idCuentaPP = idCuentaPP;
        }
        #endregion

        #region Metodos

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAbono().llenarGridAbonos(_nombreProveedor,_idCuentaPP);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Facturas : " + "", ex);
            }
        }

        #endregion
    }
}
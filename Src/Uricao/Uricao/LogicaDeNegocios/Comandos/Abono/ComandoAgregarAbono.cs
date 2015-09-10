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
    public class ComandoAgregarAbono: Comando<bool>
    {
        private Int64 _idCuentaPP;
        private Entidad _miAbono;
        #region Constructor
        public ComandoAgregarAbono()
        {
        }

        public ComandoAgregarAbono(Entidad miAbono, Int64 idCuentaPP)
        {
            this._miAbono = miAbono;
            this._idCuentaPP = idCuentaPP;
        }
        #endregion

        #region Metodos

        public override bool Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAbono().agregarAbono(_miAbono,_idCuentaPP);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Facturas : " + "", ex);
            }
        }

        #endregion

    }
}
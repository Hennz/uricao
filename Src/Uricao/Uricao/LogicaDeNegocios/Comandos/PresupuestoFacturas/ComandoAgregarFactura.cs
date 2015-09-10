using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoAgregarFactura : Comando<bool>
    {
          #region Atributos
        private Factura _factura;
        private int _idPaciente;
        #endregion

        #region Constructor
        public ComandoAgregarFactura(Factura _factura, int _idPaciente)
        {
            this._factura = _factura;
            this._idPaciente = _idPaciente;
        }
        #endregion


        #region Metodos
        public override bool Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().AgregarFactura(_factura, _idPaciente);
        }

        #endregion
    }
}
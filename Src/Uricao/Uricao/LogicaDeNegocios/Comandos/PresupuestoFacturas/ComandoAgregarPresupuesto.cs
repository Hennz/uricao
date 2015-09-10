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
    public class ComandoAgregarPresupuesto : Comando<bool>
    {
        #region Atributos

        private Entidad _elPresupuesto;
        private int _idUsuario;

        #endregion

        #region Constructor

        public ComandoAgregarPresupuesto(Entidad _elPresupuesto, int _idUsuario)
        {
            this._elPresupuesto = _elPresupuesto;
            this._idUsuario = _idUsuario;
        }

        #endregion

        #region Metodos

        public override bool Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().AgregarPresupuesto(_elPresupuesto, _idUsuario);
        }

        #endregion
    }
}
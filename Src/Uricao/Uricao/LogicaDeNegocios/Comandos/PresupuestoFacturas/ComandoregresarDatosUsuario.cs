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
    public class ComandoregresarDatosUsuario : Comando<String>
    {
        #region Atributos

        private String _cedulaUsuario;
        private String _tipoCi;

        #endregion

        #region Constructor

        public ComandoregresarDatosUsuario(String _cedulaUsuario, String _tipoCi)
        {
            this._cedulaUsuario = _cedulaUsuario;
            this._tipoCi = _tipoCi;
        }

        #endregion

        #region Metodos

        public override String Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().regresarDatosUsuario(_cedulaUsuario, _tipoCi);
        }

        #endregion
    }
}
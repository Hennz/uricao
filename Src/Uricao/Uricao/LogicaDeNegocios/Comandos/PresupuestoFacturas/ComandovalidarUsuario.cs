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
    public class ComandovalidarUsuario : Comando<bool>
    {
        #region Atributos

        private string _cedulaUsuario;
        private string _tipoCedula;

        #endregion

        #region Constructor

        public ComandovalidarUsuario()
        {
        }

        public ComandovalidarUsuario(string _cedulaUsuario, string _tipoCedula)
        {
            this._cedulaUsuario = _cedulaUsuario;
            this._tipoCedula = _tipoCedula;
        }

        #endregion

        #region Metodos

        public override bool Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().validarUsuario(_cedulaUsuario, _tipoCedula);
            }
            catch (Exception ex)
            {
                throw new Exception("No se logro validar los datos del paciente : " + "", ex);                
            }
        }

        #endregion
    }
}
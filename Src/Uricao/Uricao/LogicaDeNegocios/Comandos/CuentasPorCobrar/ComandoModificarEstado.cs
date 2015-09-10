using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.LogicaDeNegocios.Fabricas;
namespace Uricao.LogicaDeNegocios.Comandos.CuentasPorCobrar
{
    public class ComandoModificarEstado: Comando<bool>
    {
        #region Atributos
        public int _idCuenta;
        public string _estadoNuevo;
        #endregion Atributos
        #region Constructor
        public ComandoModificarEstado(int idCuenta, string estadoNuevo)
        {
            this._estadoNuevo=estadoNuevo;
            this._idCuenta=idCuenta;
        }

        #endregion Constructor
        #region Metodos
        public override bool Ejecutar(){
            bool valEstado = FabricaComando.CrearComandoValidarEstado(_idCuenta, _estadoNuevo).Ejecutar();
            if (valEstado)
            {
                bool estado;
                estado = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorCobrar().ModificarEstado(_idCuenta, _estadoNuevo);
                if (estado)
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
                return false;
            }

        }
        #endregion Metodos
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.AccesoDeDatos.DAOS;

namespace Uricao.LogicaDeNegocios.Comandos.CuentasPorCobrar
{
    public class ComandoObtenerUsuarioCedula: Comando<List<Entidad>>
    {
        #region Atributos
        public string _tipo;
        public string _cedula;
        #endregion Atributos
        #region Constructor
        public ComandoObtenerUsuarioCedula(string tipo, string cedula)
        {
            this._cedula = cedula;
            this._tipo = tipo;
        }
        #endregion Constructor
        #region Metodos
        public override List<Entidad> Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorCobrar().consultarUsuarioCedula(_tipo,_cedula);
            //detalle

        }

        #endregion Metodos
    }
}
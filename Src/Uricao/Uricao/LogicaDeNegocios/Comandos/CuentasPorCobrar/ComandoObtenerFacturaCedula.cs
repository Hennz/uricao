using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.AccesoDeDatos.DAOS;
namespace Uricao.LogicaDeNegocios.Comandos.CuentasPorCobrar
{
    public class ComandoObtenerFacturaCedula: Comando< List<Entidad>>
    {
        #region Atributos
        public string _cedula;
        public string _tipo;
        #endregion Atributos
        #region Constructor
        public ComandoObtenerFacturaCedula(string cedula, string tipo)
        {
            this._cedula=cedula;
            this._tipo=tipo;
        }
        #endregion Constructor
        #region Metodos
        public override List<Entidad> Ejecutar()
        {
            //fictia 
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorCobrar().consultarFacturaCedula(_cedula,_tipo);
        }

        #endregion Metodos
    }
}
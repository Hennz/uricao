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
    public class ComandoObtenerUsuarioFechas: Comando<List<Entidad>>
    {
        #region Atributos
        private string _fechainicio;
        private string _fechafin;
        #endregion Atributos
        #region Constructor
        public ComandoObtenerUsuarioFechas(string fechainicio, string fechafin)
        {
            this._fechafin = fechafin;
            this._fechainicio = fechainicio;
        }
        #endregion Constructor
        #region Metodos
        public override List<Entidad> Ejecutar()
        {
            //cuentaspor cobrar
            
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorCobrar().consultarUsuarioFechas(_fechainicio, _fechafin);
            
        }

        #endregion Metodos
    }
}
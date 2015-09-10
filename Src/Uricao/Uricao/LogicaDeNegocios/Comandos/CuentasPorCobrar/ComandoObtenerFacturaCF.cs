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
    public class ComandoObtenerFacturaCF: Comando<List<Entidad>>
    {
        #region Atributos
        public string _cedula;
        public string _tipo; 
        public string _fechainicio;
        public string _fechafin;
        #endregion Atributos
        #region Constructor
        public ComandoObtenerFacturaCF (string cedula,string tipo,string fechainicio, string fechafin)
        {
            this._cedula=cedula;
            this._fechafin=fechafin;
            this._fechainicio=fechainicio;
            this._tipo=tipo;
        }
        #endregion Constructor
        #region Metodos
        public override List<Entidad> Ejecutar()
        {
            //ficticia
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorCobrar().consultarFacturaCF(_fechainicio, _fechafin, _cedula, _tipo);
        }
        
        #endregion Metodos
    }
}
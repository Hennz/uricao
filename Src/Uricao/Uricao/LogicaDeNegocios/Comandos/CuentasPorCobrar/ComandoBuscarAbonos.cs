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
    public class ComandoBuscarAbonos: Comando< List<Entidad>>
    {
        #region Atributos
        public int _idfactura;
        #endregion Atributos
        #region Constructor
        public ComandoBuscarAbonos(int idfactura)
        {
            this._idfactura = idfactura;
        }

        #endregion Constructor
        #region Metodos
        public override List<Entidad> Ejecutar()
        {
            //Abono
            
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorCobrar().BuscarAbonos(_idfactura);
        }
        #endregion Metodos
    }
}
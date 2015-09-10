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
    public class ComandoconsultarDetalleFactura:Comando<List<Entidad>>
    {
        #region Atributos
        public int _factura;
        #endregion Atributos
        #region Constructor
        public ComandoconsultarDetalleFactura(int factura)
        {
            this._factura=factura;
        }
        #endregion Constructor
        #region Metodos
        public override List<Entidad> Ejecutar()
        {
            //factura
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOCuentasPorCobrar().consultarDetalleFactura(_factura);
        }
        #endregion Metodos
    }
}
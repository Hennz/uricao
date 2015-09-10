using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoConsultarTratamientoXId : Comando<Entidad>
    {

        #region Atributos

        private int _idTratamientoParametro;

        #endregion


        #region Constructor
        public ComandoConsultarTratamientoXId()
        {
        }

        public ComandoConsultarTratamientoXId(int idTratamientoParametro)
        {
            this._idTratamientoParametro = idTratamientoParametro;
        }

        #endregion


        #region Metodos

        public override Entidad Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().SqlBuscarXIdTratamiento(_idTratamientoParametro);
                
            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Facturas : " + "", ex);                
            }
        }

        #endregion
    }
}
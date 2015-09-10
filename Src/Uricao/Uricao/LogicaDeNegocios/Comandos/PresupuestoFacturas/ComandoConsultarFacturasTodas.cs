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
    public class ComandoConsultarFacturasTodas : Comando<List<Entidad>>
    {

        #region Atributos

        #endregion


        #region Constructor
        public ComandoConsultarFacturasTodas()
        {
        }

        #endregion


        #region Metodos

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarFacturasTodas();

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Facturas : " + "", ex);                
            }
        }

        #endregion
    }
}
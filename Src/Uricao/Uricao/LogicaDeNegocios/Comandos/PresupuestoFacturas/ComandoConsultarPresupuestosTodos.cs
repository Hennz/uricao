using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoConsultarPresupuestosTodos : Comando<List<Entidad>>
    {

        #region Constructor

        public ComandoConsultarPresupuestosTodos()
        {
        }

        #endregion

        #region Metodos

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarPresupuestosTodos();

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar los Presupuestos : " + "", ex);                
            }
        }

        #endregion
    }
}
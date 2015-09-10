using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoRegresarListadoXNombre : Comando<List<Entidad>>
    {
        #region Atributos

        private string _nombreTratamiento;
      

        #endregion

          #region Constructor
        public ComandoRegresarListadoXNombre()
        {
        }

        public ComandoRegresarListadoXNombre(String nombreTratamiento)
        {
            this._nombreTratamiento = nombreTratamiento;
            
        }
        #endregion

        #region Metodos

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().SqlBuscarXNombreTramiento(_nombreTratamiento);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Facturas : " + "", ex);
            }
        }

        #endregion
    }
}
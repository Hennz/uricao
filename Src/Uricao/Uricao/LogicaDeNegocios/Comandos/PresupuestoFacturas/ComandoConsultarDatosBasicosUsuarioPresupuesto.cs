using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoConsultarDatosBasicosUsuarioPresupuesto : Comando<Entidad>
    {
      
        #region Atributos

        private int _nroPresupuesto;

        #endregion

        #region Constructor

        public ComandoConsultarDatosBasicosUsuarioPresupuesto()
        {
        }

        public ComandoConsultarDatosBasicosUsuarioPresupuesto(int numeroPresupuesto)
        {
            this._nroPresupuesto = numeroPresupuesto;
        }

        #endregion

        #region Metodos

        public override Entidad Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarDatosBasicosUsuarioPresupuesto(_nroPresupuesto);
            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar los datos básicos del presupuesto : " + "", ex);                
            }
        }

        #endregion
    }
}
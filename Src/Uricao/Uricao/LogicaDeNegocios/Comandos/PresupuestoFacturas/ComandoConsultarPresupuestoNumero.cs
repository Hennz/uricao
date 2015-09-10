using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoConsultarPresupuestoNumero : Comando<Entidad>
    {
        #region Atributos

        private int _nroPresupuesto;

        #endregion

        #region Constructor

        public ComandoConsultarPresupuestoNumero()
        {
        }

        public ComandoConsultarPresupuestoNumero(int nroPresupuesto)
        {
            this._nroPresupuesto = nroPresupuesto;
        }

        #endregion

        #region Metodos

        public override Entidad Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarPresupuestoNumero(_nroPresupuesto);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar la cédula del paciente que solicito el presupuesto : " + "", ex);                
            }
        }

        #endregion
    }
}
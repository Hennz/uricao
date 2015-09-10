using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoConsultarCedulaFactura : Comando<String>
    {

        #region Atributos

        private int _nroFactura;

        #endregion

        #region Constructor

        public ComandoConsultarCedulaFactura()
        {
        }

        public ComandoConsultarCedulaFactura(int nroFactura)
        {
            this._nroFactura = nroFactura;
        }

        #endregion

        #region Metodos

        public override String Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarCedulaFactura(_nroFactura);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar la cédula del paciente que solicito el presupuesto : " + "", ex);                
            }
        }

        #endregion
    }
}
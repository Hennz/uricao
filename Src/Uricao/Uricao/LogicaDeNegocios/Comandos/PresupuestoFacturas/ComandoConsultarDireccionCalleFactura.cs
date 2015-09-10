using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoConsultarDireccionCalleFactura : Comando<String>
    {

        #region Atributos

        private int _idDireccion;

        #endregion

        #region Constructor

        public ComandoConsultarDireccionCalleFactura()
        {
        }

        public ComandoConsultarDireccionCalleFactura(int idDireccion)
        {
            this._idDireccion = idDireccion;
        }

        #endregion

        #region Metodos

        public override String Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarDireccionCalleFactura(_idDireccion);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar la direccion de habitacion del titular de la factura: " + "", ex);                
            }
        }

        #endregion
    }
}
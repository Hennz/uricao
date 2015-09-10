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
    public class ComandoObtenerFacturaXCI : Comando<List<Entidad>>
    {

        #region Atributos

        private String _ciUsuario;

        #endregion


        #region Constructor
        public ComandoObtenerFacturaXCI()
        {
        }

        public ComandoObtenerFacturaXCI(String _ciUsuario)
        {
            this._ciUsuario = _ciUsuario;
        }

        #endregion


        #region Metodos

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarFacturaXCI(_ciUsuario);
                
            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar las Facturas : " + "", ex);                
            }
        }

        #endregion
    }
}
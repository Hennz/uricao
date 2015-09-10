using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoConsultarPresupuestoXCI : Comando<Entidad>
    {
        #region Atributos

        private String _cedulaIdentidad;

        #endregion

        #region Constructor

        public ComandoConsultarPresupuestoXCI()
        {
        }

        public ComandoConsultarPresupuestoXCI(String cedulaIdentidad)
        {
            this._cedulaIdentidad = cedulaIdentidad;
        }

        #endregion

        #region Metodos

        public override Entidad Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().ConsultarPresupuestoXCI(_cedulaIdentidad);

            }
            catch (Exception ex)
            {
                throw new Exception("No se logro consultar la cédula del paciente que solicito el presupuesto : " + "", ex);                
            }
        }

        #endregion
    }
}
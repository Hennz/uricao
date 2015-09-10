using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CProductosInventario;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;

namespace Uricao.Presentacion.Presentador.PProductosInventario
{
    public class PresentadorHomeInventario
    {
        private IContratoHomeInventario _vista;

        public PresentadorHomeInventario(IContratoHomeInventario laVista)
        {
            this._vista = laVista;
        }

        public void OnLoad()
        {

        }

        public List<Entidad> ObtenerProductos()
        {
            List<Entidad> producto;
            try
            {
                producto = FabricaComando.CrearComandoObtenerProductos().Ejecutar();
            }
            catch (Exception e)
            {
                _vista.SetFalla(e.Message);
                producto = null;
            }
            return producto;

        }
    }
}
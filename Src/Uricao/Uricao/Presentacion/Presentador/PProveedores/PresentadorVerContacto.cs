using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CProductosInventario;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EProductosInventario;
using System.Data;
using Uricao.Presentacion.Contrato.CProveedores;


namespace Uricao.Presentacion.Presentador.PProveedores
{
    public class PresentadorVerContacto
    {
        Entidad contacto= FabricaEntidad.NuevoContacto();
        private IContratoVerContacto _vista;

        public PresentadorVerContacto(IContratoVerContacto lavista)
        {
            this._vista = lavista;
        }

        public Entidad verContacto()
        {
            String rif = _vista.RifP();
            Int16 posicion = _vista.PosicionP();
            contacto = FabricaComando.CrearComandoVerContacto(rif,posicion).Ejecutar();
            return contacto;
        }

    }
}
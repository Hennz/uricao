using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EProveedores;
using Uricao.LogicaDeNegocios.Clases.LNProveedores;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Presentacion.Contrato.CProveedores;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Fabricas;

namespace Uricao.Presentacion.Presentador.PProveedores
{
    public class PresentadorAgregarProveedor
    {
        Entidad proveedor = FabricaEntidad.NuevoProveedor();
        private IContratoAgregarProveedor _vista;

        public PresentadorAgregarProveedor(IContratoAgregarProveedor lavista)
        {
            this._vista = lavista;
        }

        public void agregarProveedor()
        {
           Boolean proveedorBool= FabricaComando.CrearComandoAgregarProveedor(_vista.GetRif().Text,_vista.GetNombre().Text, 1).Ejecutar();
        }

        public Entidad ConsultarProveedor()
        {
            return proveedor= FabricaComando.CrearComandoConsultarProveedor(_vista.GetRif().Text,_vista.GetNombre().Text, 1).Ejecutar();
        }

        public Entidad ConsultarIdProveedor()
        {
            return proveedor = FabricaComando.CrearComandoConsultarIdProveedor(_vista.GetRif().Text, _vista.GetNombre().Text, 1).Ejecutar();   
        }

    }
}
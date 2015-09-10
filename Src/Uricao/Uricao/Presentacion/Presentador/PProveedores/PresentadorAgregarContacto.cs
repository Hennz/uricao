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
    public class PresentadorAgregarContacto
    {
        Entidad contacto = FabricaEntidad.NuevoContacto();
        private IContratoAgregarContacto _vista;
        public PresentadorAgregarContacto(IContratoAgregarContacto lavista)
        {
            this._vista = lavista;
        }

        public Entidad consultarContacto(Entidad ContactoR, Int16 id)
        {
            return FabricaComando.CrearComandoConsultarContacto(ContactoR, id).Ejecutar();
        }

        public void AgregarContacto(Int16 id)
        {
            Boolean retorno= FabricaComando.CrearComandoAgregarContacto(_vista.nombre().Text,_vista.apellido().Text,_vista.mail().Text,id).Ejecutar();
                
        }

    }
}
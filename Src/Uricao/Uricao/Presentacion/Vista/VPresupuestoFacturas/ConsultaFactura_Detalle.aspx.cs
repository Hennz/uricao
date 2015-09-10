using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.SessionState;

using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Presentacion.Presentador.PPresupuestoFacturas;

namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{
    public partial class ConsultaFactura_Detalle : System.Web.UI.Page, IContratoConsultaFactura_Detalle
    {
        #region Atributos

        private PresentadorConsultaFactura_Detalle _presentador;
        
        #endregion

        #region Constructor

        public ConsultaFactura_Detalle()
        {
            _presentador = new PresentadorConsultaFactura_Detalle(this);
        }

        #endregion

        #region Contrato

        public Label ALNombre_Persona_campo
        {
            get { return aLNombre_Persona_campo; }
            set { aLNombre_Persona_campo = value; }
        }

        public Label ALIdentificacion
        {
            get { return aLIdentificacion; }
            set { aLIdentificacion = value; }
        }

        public Label ALEstado_campo
        {
            get { return aLEstado_campo; }
            set { aLEstado_campo = value; }
        }

        public Label ALCiudad_campo
        {
            get { return aLCiudad_campo; }
            set { aLCiudad_campo = value; }
        }

        public Label ALMunicipio_campo
        {
            get { return aLMunicipio_campo; }
            set { aLMunicipio_campo = value; }
        }

        public Label ALCalle_campo
        {
            get { return aLCalle_campo; }
            set { aLCalle_campo = value; }
        }

        public Label ALEdificio_campo
        {
            get { return aLEdificio_campo; }
            set { aLEdificio_campo = value; }
        }

        public GridView GridViewDetalle
        {
            get { return gridViewDetalle; }
            set { gridViewDetalle = value; }
        }

        public Label ALSubtotal
        {
            get { return aLSubtotal; }
            set { aLSubtotal = value; }
        }

        public Label ALIVA
        {
            get { return aLIVA; }
            set { aLIVA = value; }
        }

        public Label ALTotal
        {
            get { return aLTotal; }
            set { aLTotal = value; }
        }

        public HttpSessionState Sesion
        {
            get { return Session; }
        }

        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        }        


        #endregion


        #region Métodos

        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener la variable de sesion (el objeto factura)
            _presentador.PintarFactura_Detalle();
        }

        #endregion
    }
}
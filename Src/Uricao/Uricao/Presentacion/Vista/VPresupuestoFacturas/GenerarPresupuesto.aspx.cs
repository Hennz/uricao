using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.Presentacion.Presentador.PPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Excepciones;
using System.Web.SessionState;

namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{
    
    public partial class GenerarPresupuesto : System.Web.UI.Page, IContratoGenerarPresupuesto
    {

        #region Atributos

        private PresentadorGenerarPresupuesto _presentador;

        #endregion

        #region Constructor

        public GenerarPresupuesto()
        {
            _presentador = new PresentadorGenerarPresupuesto(this);
        }

        #endregion

        #region Contrato

        public TextBox ATCI_Persona
        {
            get { return aTCI_Persona; }
            set { aTCI_Persona = value; }
        }

        public TextBox ATObservaciones
        {
            get { return aTObservaciones; }
            set { aTObservaciones = value; }
        }

        public Label ALValidarUsuario
        {
            get { return aLValidarUsuario; }
            set { aLValidarUsuario = value; }
        }

        public Label AlCampoObligatorio
        {
            get { return alCampoObligatorio; }
            set { alCampoObligatorio = value; }
        }

        public DropDownList DDLTipoCi
        {
            get { return dDLTipoCi; }
            set { dDLTipoCi = value; }
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
            _presentador.PageLoad(sender,e);
        }
              
        protected void aBBotonContinuar_click(object sender, EventArgs e)
        {
            _presentador.BotonAceptar(sender,e);
        }

        #endregion

    }
}
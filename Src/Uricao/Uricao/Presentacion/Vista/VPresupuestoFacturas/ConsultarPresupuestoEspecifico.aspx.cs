using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ERolesUsuarios;
using System.Web.SessionState;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Presentacion.Presentador.PPresupuestoFacturas;

namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{
    public partial class ConsultarPresupuestoEspecifico : System.Web.UI.Page, IContratoConsultarPresupuestoEspecifico
    {

        #region Atributos

        private PresentadorConsultarPresupuestoEspecifico _presentador;

        #endregion

        #region Constructor

        public ConsultarPresupuestoEspecifico()
        {
            _presentador = new PresentadorConsultarPresupuestoEspecifico(this);
        }

        #endregion

        #region Contrato

        public Label ALNumeroPresupuesto
        {
            get { return aLNumeroPresupuesto; }
            set { aLNumeroPresupuesto = value; }
        }

        public Label ALFechaPresupuesto
        {
            get { return aLFechaPresupuesto; }
            set { aLFechaPresupuesto = value; }
        }

        public Label ALNombre
        {
            get { return aLNombre; }
            set { aLNombre = value; }
        }

        public Label ALCedula
        {
            get { return aLCedula; }
            set { aLCedula = value; }
        }

        public GridView GridViewDetalle
        {
            get { return gridViewDetalle; }
            set { GridViewDetalle = value; }
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

        public Label ALObservaciones
        {
            get { return aLObservaciones; }
            set { aLObservaciones = value; }
        }

        public HttpSessionState Sesion
        {
            get { return Session; }
        }

        #endregion

        #region Métodos

        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.pageLoad(sender,e);
        }

        #endregion
    }
}
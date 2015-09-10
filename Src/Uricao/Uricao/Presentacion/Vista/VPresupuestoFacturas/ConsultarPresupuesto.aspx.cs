using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using System.Data;
using System.Web.SessionState;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Presentacion.Presentador.PPresupuestoFacturas;

namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{
    public partial class ConsultarPresupuesto : System.Web.UI.Page, IContratoConsultarPresupuesto
    {

        #region Atributos

        private PresentadorConsultarPresupuesto _presentador;

        #endregion

        #region Constructor

        public ConsultarPresupuesto()
        {
            _presentador = new PresentadorConsultarPresupuesto(this);
        }

        #endregion

        #region Contrato

        public RadioButton ARDFechas
        {
            get { return aRDFechas; }
            set { aRDFechas = value; }
        }

        public TextBox ATRangoInicio
        {
            get { return aTRangoInicio; }
            set { aTRangoInicio = value; }
        }

        public TextBox ATRangoFinal
        {
            get { return aTRangoFinal; }
            set { aTRangoFinal = value; }
        }

        public RadioButton ARDCi
        {
            get { return aRDCi; }
            set { aRDCi = value; }
        }

        public DropDownList DropDownListCedula
        {
            get { return dropDownListCedula; }
            set { dropDownListCedula = value; }
        }

        public RadioButton ARDNumero
        {
            get { return aRDNumero; }
            set { aRDNumero = value; }
        }

        public DropDownList DropDownListNumeroPresupuesto
        {
            get { return dropDownListNumeroPresupuesto; }
            set { dropDownListNumeroPresupuesto = value; }
        }

        public RadioButton ARDTodos
        {
            get { return aRDTodos; }
            set { aRDTodos = value; }
        }

        public GridView GridViewPresupuesto
        {
            get { return gridViewPresupuesto; }
            set { gridViewPresupuesto = value; }
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
            if (!IsPostBack)
            {
                _presentador.PageLoadCamposVacios(sender, e);
                _presentador.LlenarGridViewVacio();
            }
            _presentador.Page_Load(sender,e);
        }

        protected void aBBotonBuscar_Click(object sender, EventArgs e)
        {
            _presentador.Boton_Aceptar();
        }

        protected void PresupuestosRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("BotonTablaClick"))
            {
                _presentador.PresupuestosRowCommand(sender, e);
            }
        }

        protected void gridViewPresupuesto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _presentador.PresupuestoPageChaging(sender,e);
        }

        protected void aRDTodos_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.ARDTodosSeleccionado();
        }

        protected void aRDNumero_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.ARDNumeroSeleccionado();
        }

        protected void aRDCi_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.ARDCiSeleccionado();
        }

        protected void aRDFechas_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.ARDFechasSeleccionado();
        }

        #endregion
    }
}
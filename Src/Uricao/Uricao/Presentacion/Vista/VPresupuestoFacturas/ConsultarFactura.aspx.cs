using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;

using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Presentacion.Presentador.PPresupuestoFacturas;

namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{

    public partial class ConsultarFactura : System.Web.UI.Page, IContratoConsultarFactura
    {

        #region Atributos

        private PresentadorConsultarFactura _presentador;
        //Para decidir si va a buscar CON o SIN validacion:
        private bool _buscarYvalidar;


        #endregion

        #region Constructor

        public ConsultarFactura()
        {
            _presentador = new PresentadorConsultarFactura(this);
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

        public DropDownList DropDownListNumeroFactura
        {
            get { return dropDownListNumeroFactura; }
            set { dropDownListNumeroFactura = value; }
        }

        public RadioButton ARDTodos
        {
            get { return aRDTodos; }
            set { aRDTodos = value; }
        }

        public GridView GridViewFactura
        {
            get { return gridViewFactura; }
            set { gridViewFactura = value; }
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

                //1- Mensajes de exito--fracaso:
                falla.Visible = false;
                exito.Visible = false;

                //2- Validaciones de SI EL ROL del SISTEMA ES EL ADECUADO PARA ENTRAR ACA!!! (proporcionados por: Equipo ROLES Y USUSARIOS)


                //3- Cargo desde la BD los DropDownlist:
                //CARGAR EL DROPDOWN: CON ID_USUARIO:
                _presentador.CargarIdUsuario();
                //CARGAR EL DROPDOWN: CON ID_FACTURAS:
                _presentador.CargarFacturas();

            }
            else
            {
                //Invoca a la ""busqueda"", para el caso ""sin validacion"".
                _buscarYvalidar = false;

                ABBotonBuscar_Click(sender, e);

                //validar a la proxima invocacion:
                _buscarYvalidar = true;
            }
        }


        #region Metodo BuscarFactura


        protected void ABBotonBuscar_Click(object sender, EventArgs e)
        {
            _presentador.ABBotonBuscar_Click(sender, e, _buscarYvalidar);
        }

        #endregion Metodo BuscarFactura


        #region Metodos RadioButtons

        protected void ARDTodos_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.ARDTodos_CheckedChanged(sender, e);
        }

        protected void ARDNumero_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.ARDNumero_CheckedChanged(sender, e);
        }

        protected void ARDCi_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.ARDCi_CheckedChanged(sender, e);
        }

        protected void ARDFechas_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.ARDFechas_CheckedChanged(sender, e);
        }


        #endregion Metodos RadioButtons


        #region Metodos GridView

        protected void GridViewFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presentador.GridViewFactura_SelectedIndexChanged(sender, e);
        }

        protected void GridViewFactura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _presentador.GridViewFactura_PageIndexChanging(sender, e);
        }


        /// <summary>
        /// Para pasar a la siguiente pagina; pasando la seleccion del usuario en el GridViewFactura (el objeto (entidad) "Factura" que esta en Sesion)
        /// a esa pagina siguiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewFactura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("BotonTablaClick"))
            {
                _presentador.RedireccionarAConsultaFactura_Detalle_conListaFacturas_GridViewRowCommand(sender, e);
            }
        }


        #endregion Metodos GridView

        #endregion




    }
}
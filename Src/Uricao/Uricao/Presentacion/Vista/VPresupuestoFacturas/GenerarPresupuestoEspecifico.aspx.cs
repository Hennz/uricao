using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.Presentacion.Presentador.PPresupuestoFacturas;
using System.Web.SessionState;
using Uricao.Entidades.EEntidad;

namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{
    public partial class GenerarPresupuestoEspecifico : System.Web.UI.Page, IContratoGenerarPresupuestoEspecifico
    {
        #region Atributos

        private PresentadorGenerarPresupuestoEspecifico _presentador;
        private List<Tratamiento> listaTratamientos;
        private string cedula;
        private string observaciones;
        private string tipoCi;
        private Presupuesto presupuesto = new Presupuesto();
        private LogicaPresupuestos logica;
        private const double iva=0.12;
        
        #endregion

        #region Constructor

        public GenerarPresupuestoEspecifico()
        {
            _presentador = new PresentadorGenerarPresupuestoEspecifico(this);
        }

        #endregion

        #region Contrato

        public Label ALPresupuesto
        {
            get { return aLPresupuesto; }
            set { aLPresupuesto = value; }
        }

        public Label ALNumeroPresupuesto
        {
            get { return aLNumeroPresupuesto; }
            set { aLNumeroPresupuesto = value; }
        }
        public Label ALFechaPresupuessto
        {
            get { return aLFechaPresupuessto; }
            set { aLFechaPresupuessto = value; }
        }

        public Label ALNombre
        {
            get { return aLNombre; }
            set { aLNombre = value; }
        }

        public Label ALtipoCi
        {
            get { return aLtipoCi; }
            set { aLtipoCi= value; }
        }

        public Label ALCedula
        {
            get { return aLCedula; }
            set { aLCedula = value; }
        }

        public GridView AGVDetalle
        {
            get { return aGVDetalle; }
            set { aGVDetalle = value; }
        }

        public Label ALSubtotal
        {
            get { return aLSubtotal; }
            set { aLSubtotal = value; }
        }

        public Label ALIVA
        {
            get { return aLIVA; }
            set { ALIVA = value; }
        }

        public Label ALTotal
        {
            get { return aLTotal; }
            set { aLTotal = value; }
        }

        public Label LObservaciones
        {
            get { return lObservaciones; }
            set { lObservaciones = value; }
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

        #region Métodos Pagina

        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.Page_Load(sender, e);
        }

        protected void aBBotonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.BotonAceptar_Click(sender,e);
        }

        #endregion

        #region Métodos

        protected void llenar_datos()
        {
            _presentador.llenar_datos();
        }

        protected void SubTotal()
        {
            _presentador.SubTotal();
        }

        protected void ObtenerCostosDeTratamientosElegidos()
        {
            _presentador.ObtenerCostosDeTratamientosElegidos();
        }

        protected void llenarListaDetalle()
        {
            _presentador.llenarListaDetalle();
        }

        #endregion

    }
}
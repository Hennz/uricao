using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;
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
    public partial class GenerarPresupuesto_Detalle : System.Web.UI.Page, IContratoGenerarPresupuesto_Detalle
    {
        #region Atributos

        private PresentadorGenerarPresupuesto_Detalle _presentador;
        private List<Tratamiento> listaTratamientoBuscar = new List<Tratamiento>();
        private List<Tratamiento> listaTratamientoElegidos = new List<Tratamiento>();
        private int posicion_grid_view;
        private string cedula;
        private string observaciones;
        private string tipoCi;

        #endregion

        #region Constructor

        public GenerarPresupuesto_Detalle()
        {
            _presentador = new PresentadorGenerarPresupuesto_Detalle(this);
        }

        #endregion

        #region Contrato

        public Label ALAviso
        {
            get { return aLAviso; }
            set { aLAviso = value; }
        }

        public Label ALAvisoAgregado
        {
            get { return aLAvisoAgregado; }
            set { aLAvisoAgregado = value; }
        }

        public RadioButton ARBNombre
        {
            get { return aRBNombre; }
            set { aRBNombre = value; }
        }

        public RadioButton ARBTodos
        {
            get { return aRBTodos; }
            set { aRBTodos = value; }
        }

        public DropDownList DropDownListTratamiento
        {
            get { return dropDownListTratamiento; }
            set { dropDownListTratamiento = value; }
        }

        public GridView AGTratamiento
        {
            get { return aGTratamiento; }
            set { aGTratamiento = value; }
        }

        public Button ABBotonContinuar
        {
            get { return aBBotonContinuar; }
            set { aBBotonContinuar = value; }
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

        #region Métodos Página

        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.PageLoad(sender,e);
        }

        protected void aBBuscar_Click(object sender, EventArgs e)
        {
            _presentador.BotonBuscar(sender, e);
        }

        protected void aRBNombre_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.aRBNombre_CheckedChanged();
        }

        protected void aRBTodos_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.aRBTodos_CheckedChanged();
        }

        protected void aBBotonContinuar_Click(object sender, EventArgs e)
        {
            _presentador.BotonContinuar_Click(sender,e);
        }

        protected void aGTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presentador.aGTratamiento_SelectedIndexChanged(sender,e);
        }

        protected void aGTratamiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Agregar_Tratamiento")
                _presentador.aGTratamiento_RowCommand(sender,e);
        }

        #endregion

       #region Métodos
        
        //metodo que llena listaTratamientoElegidos.
        protected bool ValidarTratamientoExistente(short idTratamiento)
        {
            return _presentador.ValidarTratamientoExistente(idTratamiento);
        }

        protected void AgregarTratamientoExistente(Entidad elNuevoTratamiento)
        {
            _presentador.AgregarTratamientoExistente(elNuevoTratamiento);
        }
        
       #endregion
               
    }
}
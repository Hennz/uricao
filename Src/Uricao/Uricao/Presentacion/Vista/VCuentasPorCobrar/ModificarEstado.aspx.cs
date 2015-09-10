using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EPresupuestoFacturas;
using System.Data;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorCobrar;
using Uricao.Entidades.EBancos;
using Uricao.LogicaDeNegocios.Clases.LNBancos;
using Uricao.Presentacion.Contrato.CCuentasPorCobrar;
using Uricao.Presentacion.Presentador.PCuentasPorCobrar;
using System.Web.SessionState;


namespace Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar
{
    
        public partial class ModificarEstado: System.Web.UI.Page
        {
        
        #region Atributos
        private string _cedula;
        private string _tipo;

        private string _fechaInicio;
        private string _fechaFin;

        private List<CuentaPorCobrar> _usuario;
        private List<Ficticia> _ficticio;
        private int _index = 0;
        private double _total;
        private PresentadorModificarEstado _presentador;
        
        #endregion

        #region Constructor
             
        public ModificarEstado()
        {
           // _presentador = new PresentadorModificarEstado(this);
        }

        #endregion

        #region Contrato
        public HttpSessionState Sesion 
        {
           get { return Session; }
        }
        
        public Label labelCedula 
        { 
            get { return LabelCedula; }
            set { LabelCedula = value; }
        } 
        public Label labelNombre 
        { 
            get { return LabelNombre; }
            set { LabelNombre = value; }
        } 
        public Label labelApellidos 
        { 
            get { return LabelApellidos; }
            set { LabelApellidos = value; }
        } 
        public Label Estado 
        { 
            get { return estado; }
            set { estado = value; }
        } 
        public DropDownList EstadoNuevo 
        { 
            get { return estadoNuevo; }
            set { estadoNuevo = value; }
        } 
        public Label Total 
        { 
            get { return total; }
            set { total = value; }
        } 
        public Label Falla 
        { 
            get { return falla; }
            set { falla = value; }
        } 
        public Label exito 
        { 
            get { return Exito; }
            set { Exito = value; }
        } 
        public GridView gridConsultar 
        { 
            get { return GridConsultar; }
            set { GridConsultar = value; }
        } 
        #endregion


        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {

            _presentador.VistaPrincipal();
        }


        protected void defaultButton_Click(object sender, EventArgs e)
        {
            //_presentador.AccionBoton();
        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   _presentador.GridConsultarSelected();
        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           // _presentador.GridConsultarSelectedChanging();

        }

        #endregion

        }
        
    }
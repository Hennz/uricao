using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EAbonos;
using System.Data;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorCobrar;
using Uricao.Entidades.EBancos;
using Uricao.LogicaDeNegocios.Clases.LNBancos;
using Uricao.Presentacion.Contrato.CCuentasPorCobrar;
using Uricao.Presentacion.Presentador.PCuentasPorCobrar;
using System.Web.SessionState;

namespace Uricao.Presentacion.Vista.VCuentasPorCobrar
{
    public partial class DetalleFactura
    {/*
        #region Atributos

        private int _numero;
        private List<Abono> _abono;
        private List<Detalle> _detalle;
        private PresentadorDetalleFactura _presentador;

        #endregion

        #region Constructor

        public DetalleFactura()
        {
           // _presentador = new PresentadorDetalleFactura(this);
        }

        #endregion

        #region Contrato

        public HttpSessionState Sesion {
            get { return Session; }
        }
        public Label label8 {
            get { return Label8; }
            set { Label8 = value; }
        }
        public Label label10 {
            get { return Label10; }
            set { Label10 = value; }
        }
        public Label label13 {
            get { return Label13; }
            set { Label13 = value; }
        }
        public Label label7 {
            get { return Label7; }
            set { Label7 = value; }
        }
        public Label Falla {
            get { return falla; }
            set { falla = value; }
        }
        public Label exito {
            get { return Exito; }
            set { Exito = value; }
        }
        public GridView gridConsultar {
            get { return GridConsultar; }
            set { GridConsultar = value; }
        }
        public GridView gridConsultar2 {
            get { return GridConsultar2; }
            set { GridConsultar2 = value; }
        }

        #endregion Contrato

        #region Metodos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.VistaPrincipal();
            }
        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
            _presentador.cargarDetalle();

        }

        protected void GridConsultar2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridConsultar2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar2.PageIndex = e.NewPageIndex;
            _presentador.cargarAbonos();
        }
    }
        #endregion*/
    }
}


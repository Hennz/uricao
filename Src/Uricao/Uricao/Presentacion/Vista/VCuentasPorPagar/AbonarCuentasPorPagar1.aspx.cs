using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorPagar;
using Uricao.Entidades.EProveedores;
using Uricao.LogicaDeNegocios.Clases.LNProveedores;
using System.Data;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;
using Uricao.Presentacion.Presentador.PCuentasPorPagar;


namespace Uricao.Presentacion.PaginasWeb.PCuentasPorPagar
{
    public partial class AbonarCuentasPorPagar1 : System.Web.UI.Page, IContratoAbonarCuentasPorPagar1
    {
        private PresentadorAbonarCuentasPorPagar1 _presentador;
        public AbonarCuentasPorPagar1()
        {
            _presentador = new PresentadorAbonarCuentasPorPagar1(this);
        }
        //Atributos:


        #region Contrato
        public TextBox Fechaf
        {
            get { return fechaf; }
            set { fechaf = value; }
        }

        public TextBox Fechai
        {
            get { return fechai; }
            set { fechai = value; }
        }
        public GridView GridView1
        {
            get { return gridView1; }
            set { gridView1 = value; }
        }

        public DropDownList RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }
        public Label Falla
        {
            get { return falla; }
            set { falla = value; }
        }

        public Label Exito
        {
            get { return exito; }
            set { exito = value; }
        }

        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //1- Mensajes de exito--fracaso:
                _presentador.PageLoad();
            }

        }


        protected void BotonAceptar_Click(object sender, EventArgs e)
        {

            Page.Validate();

            if (Page.IsValid)
            {
                _presentador.OnClick();

            }

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _presentador.GridView1_PageIndexChanging(sender, e);
        }


        protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BotonAceptar")
            {
                _presentador.GridView1_RowCommand(sender, e);
                
            }
        }

     



    }
}
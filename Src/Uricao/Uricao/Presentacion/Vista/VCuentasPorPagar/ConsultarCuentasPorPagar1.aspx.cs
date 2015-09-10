using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorPagar;
using Uricao.LogicaDeNegocios.Clases.LNProveedores;
using Uricao.Entidades.EProveedores;
using System.Data;
using System.Drawing;
using Uricao.Entidades.EAbonos;
using Uricao.LogicaDeNegocios.Clases.LNAbono;
using Uricao.Presentacion.Presentador.PCuentasPorPagar;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;
namespace Uricao.Presentacion.PaginasWeb.PCuentasPorPagar
{
    public partial class ConsultarCuentasPorPagar1 : System.Web.UI.Page, IContratoConsultarCuentasPorPagar1
    {
        private PresentadorConsultarCuentasPorPagar1 _presentador;
        public ConsultarCuentasPorPagar1()
        {
            _presentador = new PresentadorConsultarCuentasPorPagar1(this);
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
            get { return falla ; }
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
                _presentador.PageLoad();
        }


        protected void BotonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.OnClickConsultarCuentaPorPagar();

        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _presentador.GridView1_PageIndexChanging(sender,e);

        }


        protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BotonAceptar")
            {
                _presentador.GridView1_RowCommandConsultarCuentaPorPagar(sender,e);
            
            }
        }


    }
}
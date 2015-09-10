using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorCobrar;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.LogicaDeNegocios.Clases.LNBancos;


namespace Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar
{
    public partial class DetalleCuentaCobrar : System.Web.UI.Page
    {
        private string _fechaInicio;
        private string _fechaFin;
        private  List<CuentaPorCobrar> _usuario;
        private  int _index = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cambioPagina.Visible = false;
            LogicaCuentaPorCobrar logica = new LogicaCuentaPorCobrar();
            this._fechaInicio = (string)Session["FechaInicio"];
            this._fechaFin = (string)Session["FechaFin"];
            //this.cambioPagina.Text = this._fechaInicio+ " " + this._fechaFin;
            //_usuario = logica.ObtenerUsuarioFechas(this._fechaInicio, this._fechaFin);

            if (_usuario.Count == 0)
            {
                falla.Text = "NO SE ENCONTRARON FACTURAS POR PAGAR";
                falla.Visible = true;
            }
            cargarTabla();
            
            

        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (this.GridConsultar.PageSize == 1)
                _index = 0;
           else
                _index = (this.GridConsultar.PageIndex) * this.GridConsultar.PageSize;
        


            
            //click a la lupa
            Session["Cedula"] = _usuario[GridConsultar.SelectedIndex + _index].Cedula;
            Session["TipoUser"] = _usuario[GridConsultar.SelectedIndex + _index].TipoCedula;

            this.cambioPagina.Visible = false;
            Response.Redirect("ModificarEstado2.aspx");

        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            GridConsultar.PageIndex = e.NewPageIndex;
            cargarTabla();
        }

        public void cargarTabla()
        {
            DataTable table = new DataTable();


            table.Columns.Add("Cedula", typeof(string));
            table.Columns.Add("Nombres", typeof(string));
            table.Columns.Add("Apellidos", typeof(string));
            table.Columns.Add("Estado Cuenta", typeof(string));

            foreach (CuentaPorCobrar elusuario in _usuario)
            {
                table.Rows.Add(elusuario.TipoCedula+"-"+elusuario.Cedula,elusuario.PrimerNombre+" "+elusuario.Segundonombre,elusuario.Primerapellido+" "+ elusuario.Segundoapellido,elusuario.Estado);

            }


            GridConsultar.DataSource = table;
            GridConsultar.DataBind(); 
            

        }


    }
}
       

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

namespace Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar
{
    public partial class DetalleFactura2 : System.Web.UI.Page
    {

        LogicaCuentaPorCobrar logica = new LogicaCuentaPorCobrar();

        private int _numero;
        private List<Abono> _abono;
        private List<Detalle> _detalle;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.falla.Visible = false;
            this.Exito.Visible = false;
            _numero = Convert.ToInt32(Session["Factura"]);

          //  _abono = logica.BuscarAbonos(this._numero);
            //_detalle = logica.consultarDetalleFactura(this._numero);
            Session["NumFactura"] = _numero;
            Session["NumCuenta"] = Session["NoCuenta"];

            if (_detalle.Count == 0)
            {
                this.Exito.Text = "LA FACTURA NO POSEE DETALLES";
                this.Exito.Visible = true;
            }

            if (_abono.Count == 0)
            {
                this.Exito.Text = "EL USUARIO NO POSEE ABONOS";
                this.Exito.Visible = true;
            }
            cargarAbonos();
            cargarDatos();
            cargarDetalle();

        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
            cargarDetalle();
        }

        protected void GridConsultar2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridConsultar2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar2.PageIndex = e.NewPageIndex;
            cargarAbonos();

        }

        

        public void cargarAbonos()
        {
            DataTable table = new DataTable();
           

            table.Columns.Add("Monto Abonado", typeof(string));
            table.Columns.Add("Deuda", typeof(string));
            table.Columns.Add("Fecha", typeof(string));
           
            foreach (Abono elabono in _abono)
            {
                table.Rows.Add(elabono.MontoAbono, elabono.Deuda, Convert.ToDateTime(elabono.FechaAbono).ToShortDateString());
            }

            
            GridConsultar2.DataSource = table;
            GridConsultar2.DataBind();
        
        }


        public void cargarDetalle()
        {
            DataTable table = new DataTable();


            table.Columns.Add("Cantidad", typeof(string));
            table.Columns.Add("Concepto", typeof(string));
            table.Columns.Add("Monto", typeof(string));

            foreach (Detalle elabono in _detalle)
            {
                table.Rows.Add(elabono.CantidadDetalle,elabono.NombreTratamiento,elabono.MontoDetalle);
            }


            GridConsultar.DataSource = table;
            GridConsultar.DataBind();

        }



        public void cargarDatos()
        {
            this.Label8.Text = (string)Session["CedulaD"];
            this.Label10.Text = (string)Session["Nombres"];
            this.Label13.Text = (string)Session["Apellidos"];
            this.Label7.Text = (string)Session["Factura"];

        }
    }
    }


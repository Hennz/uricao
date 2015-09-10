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

namespace Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar
{
    
        public partial class ModificarEstado2: System.Web.UI.Page
    {
       private string _cedula;
       private string _tipo;
       private int _index = 0;
       private double _total;

       private List<CuentaPorCobrar> _usuario;
       private List<Ficticia> _ficticio;
   
        
            

        protected void Page_Load(object sender, EventArgs e)
        {

            falla.Visible = false;
            Exito.Visible = false;
           
            LogicaCuentaPorCobrar logica = new LogicaCuentaPorCobrar();

            this._cedula = (string)Session["Cedula"];
            this._tipo = (string)Session["TipoUser"];


           
            //   _usuario = logica.ObtenerUsuarioCedula(_tipo, _cedula);

              // _ficticio = logica.ObtenerFacturaCedula(_cedula, _tipo);

               if (_usuario.Count == 0)
               {
                   this.falla.Text = "NO SE ENCONTRO EL USUARIO";
                   this.falla.Visible = true;
               }

               if ((_ficticio.Count == 0) && (_usuario.Count != 0))
               {
                   this.Exito.Text = "EL USUARIO NO POSEE FACTURAS POR PAGAR";
                   this.Exito.Visible = true;
               }

          

            cargarFicticio();
            cargarDatos();

        }


        protected void defaultButton_Click(object sender, EventArgs e)
        {
            LogicaCuentaPorCobrar logica = new LogicaCuentaPorCobrar();


            /*if (logica.ValidarEstado( this._usuario[0].Id, this.estadoNuevo.SelectedItem.Value))
            {
                if (logica.ModificarEstado(this._usuario[0].Id, this.estadoNuevo.SelectedItem.Value))
                {

                    Exito.Text = "Operacion Realizada Exitosamente";
                    Exito.Visible = true;

                }
                else
                {
                    falla.Text = "Error Al Modificar en la Base de Datos";
                    falla.Visible = true;
                    Exito.Text = string.Empty;
                }

            }
            else
            {
                falla.Text = "Estado Invalido";
                falla.Visible = true;
                Exito.Text = string.Empty;
            }
            */
        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.GridConsultar.PageSize == 1)
                _index = 0;
            else
                _index = (this.GridConsultar.PageIndex) * this.GridConsultar.PageSize;

            Session["Factura"] = this._ficticio[GridConsultar.SelectedIndex + _index].NumeroFactura.ToString();
            Session["CedulaD"] = this.LabelCedula.Text;
            Session["Nombres"] = this.LabelNombre.Text;
            Session["Apellidos"] = this.LabelApellidos.Text;
            Session["NoCuenta"] = this._usuario[GridConsultar.SelectedIndex + _index].Id;
          Response.Redirect("DetalleFactura2.aspx");
            
        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            GridConsultar.PageIndex = e.NewPageIndex;
            cargarFicticio();
        }



        public void cargarFicticio()
        {
            DataTable table = new DataTable();
           

            table.Columns.Add("Numero Factura", typeof(string));
            table.Columns.Add("Fecha Emision", typeof(string));
            table.Columns.Add("Monto Total", typeof(string));
            table.Columns.Add("Total Abonado", typeof(string));
            table.Columns.Add("Saldo Deudor", typeof(string));
           
            foreach (Ficticia lafactura in _ficticio)
            {

                table.Rows.Add(lafactura.NumeroFactura, lafactura.FechaEmitida.ToShortDateString(), lafactura.TotalFactura + " BsF", lafactura.TotalAbono + " BsF", lafactura.Deuda + " BsF");
                this._total = this._total + lafactura.TotalFactura;
            }

            
            GridConsultar.DataSource = table;
            GridConsultar.DataBind();
        
        }
/*
        public void cargarTabla()
        {
            DataTable table = new DataTable();


            table.Columns.Add("Numero Factura", typeof(string));
            table.Columns.Add("Fecha Emision", typeof(string));
            table.Columns.Add("Monto Total", typeof(string));


            foreach (Factura lafactura in _factura)
            {
                table.Rows.Add(lafactura.getNro_Factura(),lafactura.getFecha_Emitida(),lafactura.getTotal_Factura());
                this._numerofactura[i] = lafactura.getNro_Factura();
                i++;
            }


            GridConsultar.DataSource = table;
            GridConsultar.DataBind();
            i = 0;
        }
           
        

            */

        public void cargarDatos()
        {
            foreach (CuentaPorCobrar cuenta in _usuario)
            {
                this.LabelCedula.Text = cuenta.TipoCedula+"-"+cuenta.Cedula;
                this.LabelNombre.Text = cuenta.PrimerNombre + cuenta.Segundonombre;
                this.LabelApellidos.Text = cuenta.Primerapellido + cuenta.Segundoapellido;
                this.estado.Text = cuenta.Estado;
                this.total.Text = this._total.ToString()+ " BsF";

            }
        }
    }
}
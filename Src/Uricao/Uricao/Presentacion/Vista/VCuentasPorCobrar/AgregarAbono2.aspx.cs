
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Clases.LNAbono;

namespace Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar
{
    public partial class AgregarAbono2 : System.Web.UI.Page
    {
        private int _cuenta;
        private int _factura;

        protected void Page_Load(object sender, EventArgs e)
        {/*
            this.Label5.Text = (string)Session["Nombres"] + (string)Session["Apellidos"];
            this.Label6.Text = Session["NumFactura"].ToString();
            falla.Visible = false;
            Exito.Visible = false;
            Monto.Style["text-align"] = "center";
            datepicker.Style["text-align"] = "center";
            //Evento para validar que solamente se ingresen numeros en el Textbox
            Monto.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            this._cuenta = Convert.ToInt32(Session["NumCuenta"]);
            this._factura = Convert.ToInt32(Session["NumFactura"]);

        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            LogicaAbono validar = new LogicaAbono();

            if (this.datepicker.Text.Equals(string.Empty) && this.Monto.Text.Equals(string.Empty))
            {
                falla.Text = "Error: Ingresar al menos un Parametro para la Busqueda";
                falla.Visible = true;
            }
            else if (this.datepicker.Text.Equals(string.Empty) && !this.Monto.Text.Equals(string.Empty))
            {
                falla.Text = "Error: Debe Ingresar un Fecha";
                falla.Visible = true;
            }
            else if (!this.datepicker.Text.Equals(string.Empty) && this.Monto.Text.Equals(string.Empty))
            {
                falla.Text = "Error: Debe Ingresar un Monto";
                falla.Visible = true;
            }
            else if (Convert.ToDouble(this.Monto.Text) < 0)
            {
                falla.Text = "Monto Negativo";
                falla.Visible = true;
            }
            else if (validar.ValidarMonto(Convert.ToInt32(this.Label6.Text), Convert.ToDouble(this.Monto.Text)))
            {
                LogicaAbono logica = new LogicaAbono();

               /* if (logica.AgregarAbonoCC(this.datepicker.Text, this._factura, this._cuenta, Convert.ToDouble(this.Monto.Text)))
                {
                    Exito.Text = "Operacion Realizada Exitosamente";
                    Exito.Visible = true;
                    falla.Text = "";
                }
                else
                {
                    falla.Text = "Operacion Fallida";
                    falla.Visible = true;
                }

            }
            else
            {
                falla.Text = "Monto Excede la Deuda Actual";
                falla.Visible = true;
            }
        }*/
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Clases.LNBancos;
using Uricao.Entidades.EBancos;


namespace Uricao.Presentacion.PaginasWeb.PBancos
{
    
    public partial class EditarBanco : System.Web.UI.Page
        
    {
        private int seleccionRadioButton;
      //  List<NumeroCuentaBanco> listaInfoCuentas;
        
        protected void Page_Load(object sender, EventArgs e)
        {
           // LogicaBanco datoCuenta = new LogicaBanco();
           // listaInfoCuentas = datoCuenta.llenarDataGridBancos(comboBoxBanco.SelectedItem.ToString());

            if (!IsPostBack)
            {
                llenarComboBoxDeBancos();
                llenarComboBoxDeTipoCuentas();
               
            }
        }

        protected void llenarComboBoxDeTipoCuentas()
        {
            LogicaBanco tiposDeCuentas = new LogicaBanco();
            this.DropDownListTipoCuenta.DataSource = tiposDeCuentas.EnlistaTipoCuenta();
            this.DropDownListTipoCuenta.DataBind();
        }

        protected void llenarComboBoxDeBancos()
        {
            LogicaBanco bancos = new LogicaBanco();
            this.comboBoxBanco.DataSource = bancos.EnlistaBancos();
            this.comboBoxBanco.DataBind();
        }

        

    

        protected void defaultButton_Click(object sender, EventArgs e)
        {

            switch (seleccionRadioButton)
            {
                case 1:
                    //El codigo para llenar el datagrid con la consulta por bancos
                    LogicaBanco nombreBancos = new LogicaBanco();
                    this.GridViewConsultarBanco.DataSource = null;
                    this.GridViewConsultarBanco.DataSource = nombreBancos.llenarDataGridBancos(comboBoxBanco.SelectedItem.ToString());
                    this.GridViewConsultarBanco.DataBind();
                    this.GridViewConsultarBanco.Visible = true;
                    break;

                case 2:
                    //El codigo para llenar el datagrid con la consulta por numero de cuentas
                    this.GridViewConsultarBanco.DataSource = null;
                    LogicaBanco nombreTipoCuenta = new LogicaBanco();
                    this.GridViewConsultarBanco.DataSource = nombreTipoCuenta.llenarDataGridTipoCuenta(DropDownListTipoCuenta.SelectedItem.ToString());
                    this.GridViewConsultarBanco.DataBind();
                    this.GridViewConsultarBanco.Visible = true;
                    break;

                case 3:
                    //El codigo para llenar el datagrid con toda la info de la bd de las cuentas
                    LogicaBanco infoBanco = new LogicaBanco();
                    this.GridViewConsultarBanco.DataSource = null;
                    this.GridViewConsultarBanco.DataSource = infoBanco.llenarDataGridInfoCuentas();
                    this.GridViewConsultarBanco.DataBind();
                    this.GridViewConsultarBanco.Visible = true;
                    break;
            }
            
        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxBanco.SelectedIndex = this.comboBoxBanco.SelectedIndex;
          
        }

        protected void GridViewConsultarBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  int seleccion = GridViewConsultarBanco.SelectedIndex;
           // LogicaBanco bancos = listaInfoCuentas[seleccion];
         //   Session["identificacion"] = bancos;

            //Response.Redirect("DetalleBanco.aspx");
        }     

        /* protected void GridViewConsultarBanco_PageIndexChanging(object sender, GridViewPageEventArgs e)
         {
             GridViewConsultarBanco.PageIndex = e.NewPageIndex;
             llenarGridView();
         }*/
        protected void RadioButtonBanco_CheckedChanged1(object sender, EventArgs e)
        {
            seleccionRadioButton = 1;
        }

        protected void RadioButtonTipoCuenta_CheckedChanged(object sender, EventArgs e)
        {
            seleccionRadioButton = 2;
        }

        protected void RadioButtonConsultaCompleta_CheckedChanged(object sender, EventArgs e)
        {
            seleccionRadioButton = 3;
        }
    }
}
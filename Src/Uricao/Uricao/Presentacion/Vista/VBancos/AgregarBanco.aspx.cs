using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Clases.LNBancos;

namespace Uricao.Presentacion.PaginasWeb.PBancos
{
    public partial class AgregarBanco : System.Web.UI.Page
    {
        object fe;
        EventArgs er;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fe = sender;
                er = e;
                llenarComboBoxDeBancos();
                }
        }

        protected void llenarComboBoxDeBancos()
        {
            LogicaBanco bancos = new LogicaBanco();
            this.DropDownListBancos.DataSource = bancos.EnlistaBancos();
            this.DropDownListBancos.DataBind();
            this.DropDownListBancos.Items.Add("Otro");
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            if (TextBoxNuevoBanco.Visible == true)
            {
                string nombreBanco = TextBoxNuevoBanco.Text.ToString();
                string numeroCuenta = TextBoxNumCuenta.Text.ToString();
                string tipoCuenta = DropDownListTipoCuenta.SelectedItem.ToString();
                
                LogicaBanco agregacionBanco = new LogicaBanco();
                Boolean Flag = agregacionBanco.agregarBanco(nombreBanco, numeroCuenta, tipoCuenta, 1);

                if (Flag != false)
                {
                    Exito.Visible = true;
                    llenarComboBoxDeBancos();
                }
                else
                {
                    falla.Visible = true;
                }

            }
            else
            {
                string nombreBanco = DropDownListBancos.SelectedItem.ToString();
                string numeroCuenta = TextBoxNumCuenta.Text.ToString();
                string tipoCuenta = DropDownListTipoCuenta.SelectedItem.ToString();

                LogicaBanco agregacionBanco = new LogicaBanco();
                Boolean Flag = agregacionBanco.agregarBanco(nombreBanco, numeroCuenta, tipoCuenta,2);

                if (Flag != false)
                {
                    Exito.Visible = true;
                    llenarComboBoxDeBancos();
                }
                else
                {
                    falla.Visible = true;
                }
            }

        }

        protected void DropDownListBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DropDownListBancos.SelectedItem.ToString();
            int longitud=DropDownListBancos.Items.Count - 1;
            if (DropDownListBancos.SelectedIndex == longitud)
            {
                this.TextBoxNuevoBanco.Visible = true;
                
            }
            else
            {
                this.TextBoxNuevoBanco.Visible = false;
                this.Page_Load(fe, er);  
            }
            
        }
    }
}
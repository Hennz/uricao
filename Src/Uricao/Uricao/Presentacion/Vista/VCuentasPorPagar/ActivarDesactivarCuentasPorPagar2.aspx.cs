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
using System.Drawing;
using Uricao.Entidades.EAbonos;
using Uricao.LogicaDeNegocios.Clases.LNAbono;
using Uricao.Presentacion.Presentador.PCuentasPorPagar;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;

namespace Uricao.Presentacion.PaginasWeb.PCuentasPorPagar
{
    public partial class ActivarDesactivarCuentasPorPagar2 : System.Web.UI.Page,IContratoActivarDesactivarCuentasPorPagar2
    {
        private PresentadorActivarDesactivarCuentasPorPagar2 _presentador;
        public ActivarDesactivarCuentasPorPagar2()
        {
            _presentador = new PresentadorActivarDesactivarCuentasPorPagar2(this);
        }
        


        protected void GridView2Abono_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2Abono_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }


        protected void GridView2Abono_RowCommand(Object sender, GridViewCommandEventArgs e)
        {


        }


        protected void BotonAbonar_Click(object sender, EventArgs e)
        {
           
        }

        protected void DropDownListNuevoEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BotonAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void BotonCancelar_Click(object sender, EventArgs e)
        {

        }





    }
}
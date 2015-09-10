using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;


namespace Uricao.Presentacion.Contrato.CCuentasPorCobrar
{
   public interface IContratoConsultarCuentaCobrar
    {
        HttpSessionState Sesion { get; }
        RadioButtonList radioButtonList1 { get; set; }
        TextBox textCedula { get; set; }
        TextBox Datepicker { get; set; }
        TextBox Datepicker1 { get; set; }
        Label Falla { get; set; }
        Label exito { get; set; }

        void SetLabelFalla(String text);
        void SetLabelExito(String text);
    }
}

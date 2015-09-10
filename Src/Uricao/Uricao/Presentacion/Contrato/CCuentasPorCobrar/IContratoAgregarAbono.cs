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
   public interface IContratoAgregarAbono
    {
       HttpSessionState Sesion { get; }
        Label label5 { get; set; }
        Label label6 { get; set; }
        Label label7 { get; set; }
        TextBox Datepicker { get; set; }
        TextBox monto { get; set; }
        Label Falla { get; set; }
        Label exito { get; set; }
    }
}

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
    public interface IContratoAgregarAbono2
    {
        HttpSessionState Sesion { get; }
        Label Label5 { get; set; }
        Label Label6 { get; set; }
        Label Label7 { get; set; }
        TextBox datepicker { get; set; }
        TextBox Monto { get; set; }
        Label falla { get; set; }
        Label Exito { get; set; }
    }
}

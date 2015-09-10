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
   public interface IContratoDetalleFactura2
    {
       HttpSessionState Sesion { get; }
        Label Label8 { get; set; }
        Label Label10 { get; set; }
        Label Label13 { get; set; }
        Label Label7 { get; set; }
        Label falla { get; set; }
        Label Exito { get; set; }
        GridView GridConsultar { get; set; }
        GridView GridConsultar2 { get; set; }
    }
}

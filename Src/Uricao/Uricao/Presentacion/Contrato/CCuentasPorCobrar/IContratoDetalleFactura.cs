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
   public interface IContratoDetalleFactura
    {
       HttpSessionState Sesion { get; }
        Label label8 { get; set; }
        Label label10 { get; set; }
        Label label13 { get; set; }
        Label label7 { get; set; }
        Label Falla { get; set; }
        Label exito { get; set; }
        GridView gridConsultar { get; set; }
        GridView gridConsultar2 { get; set; }
    }
}

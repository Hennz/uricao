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
   public interface IContratoDetalleCuentaPorCobrar
    {
       HttpSessionState Sesion { get; }
        GridView GridConsultar { get; set; }
    }
}

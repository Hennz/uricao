using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CPresupuestoFacturas
{
    public interface IContratoGenerarPresupuesto_Detalle_completo
    {
        Label ALNumeroPresupuesto { get; set; }
        Label ALFechaPresupuessto { get; set; }
        Label ALNombre { get; set; }
        GridView AGPresupuesto { get; set; }
        Label ALSubtotal { get; set; }
        Label ALIVA { get; set; }
        Label ALTotal { get; set; }
        Label lObservaciones { get; set; }
        Button ABBotonContinuar { get; set; }
        HttpSessionState Sesion { get; }
        void Redireccionar(string _ruta);
    }
}

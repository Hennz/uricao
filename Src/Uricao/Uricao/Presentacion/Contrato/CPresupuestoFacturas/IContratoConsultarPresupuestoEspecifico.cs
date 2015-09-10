using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.Data;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CPresupuestoFacturas
{
    public interface IContratoConsultarPresupuestoEspecifico
    {
        Label ALNumeroPresupuesto { get; set; }
        Label ALFechaPresupuesto { get; set; }
        Label ALNombre { get; set; }
        Label ALCedula { get; set; }
        GridView GridViewDetalle { get; set; }
        Label ALSubtotal { get; set; }
        Label ALIVA { get; set; }
        Label ALTotal { get; set; }
        Label ALObservaciones { get; set; }
        HttpSessionState Sesion { get; }
    }
}

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
    public interface IContratoGenerarPresupuestoEspecifico
    {
        Label ALPresupuesto { get; set; }
        Label ALNumeroPresupuesto { get; set; }
        Label ALFechaPresupuessto { get; set; }
        Label ALNombre { get; set; }
        Label ALtipoCi { get; set; }
        Label ALCedula { get; set; }
        GridView AGVDetalle { get; set; }
        Label ALSubtotal { get; set; }
        Label ALIVA { get; set; }
        Label ALTotal { get; set; }
        Label LObservaciones { get; set; }
        HttpSessionState Sesion { get; }
        void Redireccionar(string _ruta);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.SessionState;
namespace Uricao.Presentacion.Contrato.CPresupuestoFacturas
{
    public interface IContratoGenerarFacturaDetalleCompleto
    {
        Label Label4 { get; set; }
        Label ALFechafactura { get; set; }
        Label Label1 { get; set; }
        Label ALNombre { get; set; }
        Label ALci { get; set; }
        Label ALCIRIF { get; set; }
        GridView AGTratamiento { get; set; }
        Label ALSubtotal { get; set; }
        Label ALIVA { get; set; }
        Label ALTotal { get; set; }

        HttpSessionState Sesion { get; }
    }
}
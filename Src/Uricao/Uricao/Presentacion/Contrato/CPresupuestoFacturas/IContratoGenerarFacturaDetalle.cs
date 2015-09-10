using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CPresupuestoFacturas
{
    public interface IContratoGenerarFacturaDetalle
    {
        Label ALAviso { get; set; }
        Label ALAvisoAgregado { get; set; }
        Label Label2 { get; set; }
        RadioButton ARBNombre { get; set; }
        RadioButton ARBTodos { get; set; }
        Label Label3 { get; set; }
        DropDownList DropDownListTratamiento { get; set; }
        GridView AGTratamiento { get; set; }
        Label ALMensaje_Error { get; set; }
    }
}
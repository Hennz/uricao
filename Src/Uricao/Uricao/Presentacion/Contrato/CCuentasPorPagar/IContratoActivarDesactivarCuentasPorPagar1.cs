using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CCuentasPorPagar
{
    public interface IContratoActivarDesactivarCuentasPorPagar1
    {
        TextBox Fechai { get; set; }
        TextBox Fechaf { get; set; }
        GridView GridView1 { get; set; }
        DropDownList RazonSocial { get; set; }
        Label Falla { get; set; }
        Label Exito { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CCuentasPorPagar
{
    public interface IContratoConsultarCuentasPorPagar2
    {
      
        GridView GridView2Abono { get; set; }
        Label LabelcuentaCodigo { get; set; }
        Label Labelproveedor { get; set; }
        Label LabelBanco { get; set; }
        Label LabelNumeroCuenta { get; set; }
        Label LabeltipoPago { get; set; }
        Label Label6 { get; set; }
        Label LabelmontoDeuda { get; set; }
        Label Labeldeudafinal { get; set; }
        Label Falla { get; set; }
        Label Exito { get; set; }
        string Requestconsultar2(string _ruta);
    }
}
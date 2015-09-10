using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CCuentasPorPagar
{
    public interface IContratoModificarCuentasPorPagar2
    {
        Label LabelcuentaCodigo { get; set; }
        Label LabelRazon { get; set; }
        DropDownList DropDownListRazon { get; set; }
        Label LabelBanco { get; set; }
        DropDownList DropDownListBanco { get; set; }
        Label LabelCuentaBancaria { get; set; }
        DropDownList DropDownListCuentaBancaria { get; set; }
        Label LabelTipoPago { get; set; }
        DropDownList DropDownListTipoPago { get; set; }
        TextBox FechaEmision { get; set; }
        TextBox TextBox1 { get; set; }
        TextBox FechaVencimiento { get; set; }
        TextBox TextBox3DetalleDeuda { get; set; }
        Label Falla { get; set; }
        Label Exito { get; set; }
        CompareValidator ValidatorCompareDoubleTypeMonto { get; set; }
        RegularExpressionValidator RegularExpressionValidatorFechaVencimiento { get; set; }
        RegularExpressionValidator RegularExpressionValidatorFechaEmision { get; set; }
        string Requestconsultar2(string _ruta);
    }
}
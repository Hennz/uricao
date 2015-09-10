using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CCuentasPorPagar
{
    public interface IContratoAgregarCuentasPorPagar1
    {
        TextBox TextBox1FechaEmision { get; set; }
        TextBox TextBox2FechaVencimiento { get; set; }
        TextBox TextBox2Monto { get; set; }
        TextBox TextBox3DetalleDeuda { get; set; }
        DropDownList DropDownList5 { get; set; }
        DropDownList DropDownList4 { get; set; }
        DropDownList DropDownList3 { get; set; }
        DropDownList DropDownList6 { get; set; }
        Label Falla { get; set; }
        Label Exito { get; set; }
        CompareValidator ValidatorCompareDoubleTypeMonto { get; set; }
        RegularExpressionValidator RegularExpressionValidatorFechaVencimiento { get; set; }
        RegularExpressionValidator RegularExpressionValidatorFechaEmision { get; set; }
     

        void Redireccionar(string _ruta);
        

    }
}
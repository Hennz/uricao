using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CCuentasPorPagar
{
    public interface IContratoModificarCuentasPorPagar1
    {
        TextBox Algo { get; set; }
        TextBox TextBox1 { get; set; }
        GridView GridView1 { get; set; }
        DropDownList DropDownList2 { get; set; }
        Label Falla { get; set; }
        Label Exito { get; set; }
        void Redireccionar(string _ruta);
    }
}
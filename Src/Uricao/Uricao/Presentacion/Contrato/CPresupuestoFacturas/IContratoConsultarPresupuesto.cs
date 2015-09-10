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
    public interface IContratoConsultarPresupuesto
    {
        RadioButton ARDFechas { get; set; }
        TextBox ATRangoInicio { get; set; }
        TextBox ATRangoFinal { get; set; }
        RadioButton ARDCi { get; set; }
        DropDownList DropDownListCedula { get; set; }
        RadioButton ARDNumero { get; set; }
        DropDownList DropDownListNumeroPresupuesto { get; set; }
        RadioButton ARDTodos { get; set; }
        GridView GridViewPresupuesto { get; set; }
        HttpSessionState Sesion { get; }
        void Redireccionar(string _ruta);
    }
}

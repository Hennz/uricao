using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CHistoriaPaciente
{
    public interface IContratoAgregarHistoriaClinica
    {
        DropDownList Combo { get; set; }
        GridView GridConsultar1 { get; set; }
        TextBox Fecha { get; set; }
        TextBox Observacion { get; set; }
        HttpSessionState Sesion { get; }
        void SetLabelFalla(String text);
        void SetLabelExito(String text);
    }
}

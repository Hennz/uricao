using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CHistoriaPaciente
{
    public interface IContratoModificarHistoriaClinica
    {
        GridView GridConsultar1 { get; set; }
        DropDownList Combo { get; set; }
        TextBox Fecha { get; set; }
        TextBox Observacion { get; set; }
        HttpSessionState Sesion { get; }
        void SetLabelFalla(String text);
        void SetLabelExito(String text);
    }
}
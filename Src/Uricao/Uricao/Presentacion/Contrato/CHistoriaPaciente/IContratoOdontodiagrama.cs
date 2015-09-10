using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CHistoriaPaciente
{
    public interface IContratoOdontodiagrama
    {
        GridView GridConsultar1 { get; set; }
        HttpSessionState Sesion { get; }
        DropDownList Medico { get; set; }
        DropDownList Diagnostico { get; set; }
        DropDownList Tratamiento { get; set; }
        DropDownList Rango1 { get; set; }
        DropDownList Rango2 { get; set; }
        TextBox Fecha { get; set; }
        TextBox Observacion { get; set; }
        void SetLabelFalla(String text);
        void SetLabelExito(String text);
    }
}
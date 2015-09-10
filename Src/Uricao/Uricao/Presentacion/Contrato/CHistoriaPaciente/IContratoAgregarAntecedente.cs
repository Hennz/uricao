using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CHistoriaPaciente
{
    public interface IContratoAgregarAntecedente
    {
        void SetLabelFalla(String text);
        void SetLabelExito(String text);

        RadioButtonList Respuesta1  { get; set; }
        RadioButtonList Respuesta2  { get; set; }
        RadioButtonList Respuesta3  { get; set; }
        RadioButtonList Respuesta4  { get; set; }
        RadioButtonList Respuesta5  { get; set; }
        RadioButtonList Respuesta6  { get; set; }
        RadioButtonList Respuesta7  { get; set; }
        RadioButtonList Respuesta8  { get; set; }
        RadioButtonList Respuesta9  { get; set; }
        RadioButtonList Respuesta10 { get; set; }
        RadioButtonList Respuesta11 { get; set; }
        RadioButtonList Respuesta12 { get; set; }
        RadioButtonList Respuesta13 { get; set; }
        RadioButtonList Respuesta14 { get; set; }
        RadioButtonList Respuesta15 { get; set; }

        DropDownList Respuesta16 { get; set; }
        DropDownList Respuesta17 { get; set; }
        DropDownList Respuesta18 { get; set; }

        HttpSessionState Sesion { get; }

    }
}

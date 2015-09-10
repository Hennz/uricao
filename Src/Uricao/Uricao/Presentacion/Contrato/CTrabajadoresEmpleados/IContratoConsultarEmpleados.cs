using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CTrabajadoresEmpleados
{
    public interface IContratoConsultarEmpleados
    {
        Label _LabelExito { get; set; }
        Label _LabelFalla { get; set; }

        GridView GridConsultar { get; set; }
        CheckBox _CheckInactivos { get; set; }
        TextBox _TextCedula { get; set; }
        TextBox _TextNombre { get; set; }
        TextBox _TextApellido { get; set; }
        DropDownList _DropDownCargo { get; set; }
       
        //RadioButton radio { get; set; }
        //TextBox TextBox { get; set; }
        //RadioButtonList RadioButtonList { get; }
        //HyperLink Link { get; }
        //void SetLabelFalla(String text);
        //void SetLabelExito(String text);
    }
}
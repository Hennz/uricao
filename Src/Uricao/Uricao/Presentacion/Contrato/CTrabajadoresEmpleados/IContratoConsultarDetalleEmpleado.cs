using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CTrabajadoresEmpleados
{
    public interface IContratoConsultarDetalleEmpleado
    {
        TextBox _TextNombre { get; set; }
        TextBox _TextApellido { get; set; }
        TextBox _TextCedula { get; set; }
        TextBox _TextFecha { get; set; }
        TextBox _TextTelefono { get; set; }
        TextBox _TextCorreo { get; set; }
        TextBox _TextSueldo { get; set; }
        TextBox _TextDireccion { get; set; }

        DropDownList _DropDownSexo { get; set; }
        DropDownList _DropDownCargo { get; set; }
        DropDownList _DropDownPais { get; set; }
        DropDownList _DropDownEstado { get; set; }
        DropDownList _DropDownCiudad { get; set; }

        Button _BotonEditar { get; set; }
        Button _BotonDesactivar { get; set; }

        Label _LabelExito { get; set; }
        Label _LabelFalla { get; set; }
    }
}
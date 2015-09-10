using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CTrabajadoresEmpleados
{
    public interface IContratoAgregarEmpleado
    {
        Label _ExitoAgregar { get; set; }
        Label _fallaAgregar { get; set; }

        TextBox _TextNombre { get; set; }
        TextBox _TextCedula { get; set; }
        TextBox _TextApellido { get; set; }
        TextBox _TextFecha { get; set; }
        TextBox _TextTelefono { get; set; }
        TextBox _TextCorreo { get; set; }
        TextBox _TextSueldo { get; set; }
        TextBox _TextDireccion { get; set; }
        
        DropDownList _DropDownListSexo { get; set; }
        DropDownList _DropDownListCargo { get; set; }
        DropDownList _DropDownListPais { get; set; }
        DropDownList _DropDownListEstado { get; set; }
        DropDownList _DropDownListCiudad { get; set; }
   
    }
}
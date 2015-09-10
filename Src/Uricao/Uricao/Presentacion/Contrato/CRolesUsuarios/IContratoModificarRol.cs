using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CRolesUsuarios
{
    public interface IContratoModificarRol
    {
        GridView IModGridView { get; set; }
        DropDownList IModDropDownList { get; set; }
        TextBox IModTextBox { get; set; }
        void IModFalla(String text);
        void IModExito(String text);
    }
}
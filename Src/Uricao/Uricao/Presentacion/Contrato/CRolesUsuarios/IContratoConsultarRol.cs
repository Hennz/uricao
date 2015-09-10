using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CRolesUsuarios
{
    public interface IContratoConsultarRol
    {
        GridView IGridView { get; set; }
        DropDownList IDropDownList { get; set; }
        TextBox ITextBox { get; set; } 
        void IFalla(String text);
        void IExito(String text);
        //void info(String text);
        //void error(String text); 
    }
}
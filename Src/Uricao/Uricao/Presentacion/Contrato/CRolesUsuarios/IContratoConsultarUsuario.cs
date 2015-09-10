using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CRolesUsuarios
{
    public interface IContratoConsultarUsuario
    {
        GridView GridConsultar1 { get; set; }
        DropDownList DropListParametro { get; set; }
        TextBox TextParametro { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CCuentasPorCobrar
{
   public interface IContratoModificarEstado
    {
       HttpSessionState Sesion { get; }
        Label LabelCedula { get; set; }
        Label LabelNombre { get; set; }
        Label LabelApellidos { get; set; }
        Label estado { get; set; }
        DropDownList estadoNuevo { get; set; }
        Label total { get; set; }
        Label falla { get; set; }
        Label Exito { get; set; }
        GridView GridConsultar { get; set; }
    }
}

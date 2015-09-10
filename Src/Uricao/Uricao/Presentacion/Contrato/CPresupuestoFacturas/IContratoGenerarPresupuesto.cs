using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CPresupuestoFacturas
{
    public interface IContratoGenerarPresupuesto
    {
        TextBox ATCI_Persona { get; set; }
        TextBox ATObservaciones { get; set; }
        Label ALValidarUsuario { get; set; }
        Label AlCampoObligatorio { get; set; }
        DropDownList DDLTipoCi { get; set; }
        HttpSessionState Sesion { get; }
        void Redireccionar(string _ruta);
    }
}

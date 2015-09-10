using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CHistoriaPaciente
{
    public interface IContratoDetalleOdontodiagrama
    {
        Label Medico{ get; set; }
        Label Fecha{ get; set; }
        Label Pieza{ get; set; }
        Label Tratamiento{ get; set; }
        Label Diagnostico{ get; set; }
        Label Observaciones { get; set; }
        HttpSessionState Sesion { get; }
        void SetLabelFalla(String text);
        void SetLabelExito(String text);
    }
}
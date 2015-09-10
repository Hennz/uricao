using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CAgendaCitas
{
    public interface IContratoDetalleAgregarCita
    {
        Label LabelNombreMedico { get; set; }
        Label LabelFechaCita { get; set; }
        Label LabelHoraInicio_Campo { get; set; }
        Label LabelHoraFin_Campo { get; set; }
        Label LabelNombreTratamiento { get; set; }
        TextBox ATBCiPaciente { get; set; }
        Label MensajeDeTransaccion { get; set; }
        Button ABAceptar { get; set; }
    }
}
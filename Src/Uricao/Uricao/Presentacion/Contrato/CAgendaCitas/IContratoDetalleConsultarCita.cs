using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CAgendaCitas
{
    public interface IContratoDetalleConsultarCita
    {
        Label LabelNombreMedico { get; set; }
        Label LabelFechaCita { get; set; }
        Label LabelHoraCitaInicio { get; set; }
        Label LabelHoraCitaFin{ get; set; }
        Label LabelNombreTratamiento { get; set; }
        Label LabelConfirmacionCita { get; set; }
        Label LabelStatuscita { get; set; }
    }
}
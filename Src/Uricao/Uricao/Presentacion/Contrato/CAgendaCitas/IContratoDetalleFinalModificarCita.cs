using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Uricao.Presentacion.Contrato.CAgendaCitas
{
    public interface IContratoDetalleFinalModificarCita
    {
        String IdCita { get; set; }
        String Fecha { get; set; }
        int Horai { get; set; }
        int Horaf { get; set; }
        String Nombre { get; set; }
        String Apellido { get; set; }
        String Tratamiento { get; set; }
        Label LabelNombreMedico { get; set; }
        Label LabelFechaCita { get; set; }
        Label LabelHoraCita { get; set; }
        Label LabelNombreTratamiento { get; set; }
        Label LabelConfirmacionCita { get; set; }
        Label LabelStatusCita { get; set; }
        Label MensajeDeTransaccion { get; set; }
       
    }
}
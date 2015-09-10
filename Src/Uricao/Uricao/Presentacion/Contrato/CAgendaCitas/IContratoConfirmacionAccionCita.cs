using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CAgendaCitas
{
    public interface IContratoConfirmacionAccionCita
    {
        Label AccionRealizar{ get; set; }
        Button Aceptar { get; set; }
        Button Cancelar { get; set; }

    }
}

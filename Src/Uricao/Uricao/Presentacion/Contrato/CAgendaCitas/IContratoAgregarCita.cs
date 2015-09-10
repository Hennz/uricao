using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CAgendaCitas
{
    public interface IContratoAgregarCita
    {

        GridView GridViewCitasDisponibles { get; set; }
        TextBox ATBNombre { get; set; }
        TextBox ATBApellido { get; set; }
        TextBox ATBFecha { get; set; }
        DropDownList ADDTratamiento { get; set; }
        Label MensajeDeTransaccion { get; set; }
    }
}
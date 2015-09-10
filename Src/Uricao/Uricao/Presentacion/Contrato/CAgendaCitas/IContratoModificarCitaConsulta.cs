using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EEntidad;

namespace Uricao.Presentacion.Contrato.CAgendaCitas
{
    public interface IContratoModificarCitaConsulta
    {

        GridView GridViewCitasDisponibles { get; set; }
        TextBox ATBNombre { get; set; }
        TextBox ATBApellido { get; set; }
        TextBox ATBFecha { get; set; }
        TextBox ATBFechaRangoInicio { get; set; }
        TextBox ATBFechaRangoFin { get; set; }
        Label MensajeDeTransaccion { get; set; }
        TextBox ATBCiPaciente { get; set; }
        RadioButton ARBMedico { get; set; }
        RadioButton ARBFecha{ get; set; }
        RadioButton ARBFechaRango { get; set; }
        RadioButton ARBCiPaciente { get; set; }
    }
}
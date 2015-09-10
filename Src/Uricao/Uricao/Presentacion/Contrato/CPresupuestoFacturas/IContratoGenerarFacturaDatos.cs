using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CPresupuestoFacturas
{
    public interface IContratoGenerarFacturaDatos
    {
        Label Falla { get; set; }
        Label Exito { get; set; }
        Label ALNombre_Persona { get; set; }
        DropDownList ADNombre_Persona { get; set; }
        Label ALCIPaciente { get; set; }
        DropDownList ADPaciente { get; set; }
        Label ALFormatoCI { get; set; }
        Label ALCIPacienteError { get; set; }
        Label ALNombreRazonError { get; set; }
        HttpSessionState Sesion { get; }

        void Redireccionar(string _ruta);
    }
}
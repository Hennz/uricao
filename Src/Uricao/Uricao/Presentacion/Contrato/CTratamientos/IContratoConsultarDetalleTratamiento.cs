using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Uricao.Entidades.EEntidad;

namespace Uricao.Presentacion.Contrato.CTratamientos
{
    public interface IContratoConsultarDetalleTratamiento
    {
        TextBox Nombrep { get; set; }
        TextBox Duracionp { get; set; }
        TextBox Costop { get; set; }
        TextBox Descripcionp { get; set; }
        TextBox Explicacionp { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Uricao.Entidades.EEntidad;

namespace Uricao.Presentacion.Contrato.CHistoriaPaciente
{
    public interface IContratoConsultarHistoriaClinica
    {

        GridView GridConsultar1 { get; set; }
        TextBox TextBox {get; set;}
        RadioButtonList RadioButtonList { get; }
        HyperLink Link {get;}
        void SetLabelFalla(String text);
        void SetLabelExito(String text);
    }
}
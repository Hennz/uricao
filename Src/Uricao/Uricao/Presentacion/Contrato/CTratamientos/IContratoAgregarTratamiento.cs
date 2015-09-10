using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Uricao.Entidades.EEntidad;

namespace Uricao.Presentacion.Contrato.CTratamientos
{
    public interface IContratoAgregarTratamiento
    {
        TextBox Nombrep { get; set; }
        TextBox Duracionp { get; set; }
        TextBox Costop { get; set; }
        TextBox Descripcionp { get; set; }
        TextBox Explicacionp { get; set; }
        ListBox TratamientosSinAsociar { get; set; }
        ListBox TratamientoAsociados { get; set; }
        ListBox ProductosSinAsociar { get; set; }
        ListBox ProductosAsociados { get; set; }
        TextBox CantidadP { get; set; }
        DropDownList PrioridadP { get; set; }
        Label Cont1 { get; set; }
        void SetLabelFalla(string text);
        //Button AgregarProducto { get; set; }
        //Button EliminarProducto { get; set; }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Web.SessionState;


namespace Uricao.Presentacion.Contrato.CPresupuestoFacturas
{
    public interface IContratoConsultarFactura
    {
        RadioButton ARDFechas { get; set; }
        TextBox ATRangoInicio { get; set; }
        TextBox ATRangoFinal { get; set; }
        RadioButton ARDCi { get; set; }
        DropDownList DropDownListCedula { get; set; }
        RadioButton ARDNumero { get; set; }
        DropDownList DropDownListNumeroFactura { get; set; }
        RadioButton ARDTodos { get; set; }
        GridView GridViewFactura { get; set; }

        /// <summary>
        /// Obtiene el objeto sesion que se distribuye en todas las vistas
        /// </summary>
        HttpSessionState Sesion { get; }

        void Redireccionar(string _ruta);
    }
}

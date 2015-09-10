using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CPresupuestoFacturas
{
    public interface IContratoGenerarPresupuesto_Detalle
    {
        Label ALAviso { get; set; }
        Label ALAvisoAgregado { get; set; }
        RadioButton ARBNombre { get; set; }
        RadioButton ARBTodos { get; set; }
        DropDownList DropDownListTratamiento { get; set; }
        GridView AGTratamiento { get; set; }
        //GridView ADFCantidad { get; set; }
        Button ABBotonContinuar { get; set; }
        HttpSessionState Sesion { get; }
        void Redireccionar(string _ruta);
    }
}

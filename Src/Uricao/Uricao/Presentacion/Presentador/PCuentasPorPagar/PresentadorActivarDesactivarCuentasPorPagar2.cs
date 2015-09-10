using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;

namespace Uricao.Presentacion.Presentador.PCuentasPorPagar
{
    public class PresentadorActivarDesactivarCuentasPorPagar2
    {
         private IContratoActivarDesactivarCuentasPorPagar2 _vista;



         public PresentadorActivarDesactivarCuentasPorPagar2(IContratoActivarDesactivarCuentasPorPagar2 laVista)
        {
            this._vista = laVista;
        }
    }
}
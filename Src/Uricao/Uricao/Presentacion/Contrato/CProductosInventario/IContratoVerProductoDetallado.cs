using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CProductosInventario
{
    public interface IContratoVerProductoDetallado
    {
        void SetExito(String mensaje);
        void SetFalla(String mensaje);
        void SetDropDownListCategoria(DropDownList combo);
        void SetDropDownListProveedor(DropDownList combo);
        void SetDropDownListMarca(DropDownList combo);
        void SetDropDownListTipo(DropDownList combo);
        void SetDropDownListCalidad(DropDownList combo);
        
    }
}
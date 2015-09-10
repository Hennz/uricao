using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CProductosInventario
{
    public interface IContratoAgregarProducto
    {
        void SetDropDownListCategoria(DropDownList combo);
        void SetExito(String mensaje);
        void SetFalla(String mensaje);
        void SetDropDownListProveedor(DropDownList combo);
        void SetDropDownListMarca(DropDownList combo);
        TextBox GetNombre();
        TextBox GetPrecio();
        DropDownList GetMarca();
        DropDownList GetTipo();
        DropDownList GetCalidad();
        DropDownList GetCategoria();
        TextBox GetCodigo();
        DropDownList GetProveedor();
        TextBox GetInconveniente();
        TextBox GetCantMinima();
    }
}
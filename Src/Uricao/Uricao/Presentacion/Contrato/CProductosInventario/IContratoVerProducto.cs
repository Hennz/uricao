using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CProductosInventario
{
    public interface IContratoVerProducto
    {
        void SetExito(String mensaje);
        void SetFalla(String mensaje);
        TextBox GetNombre();
        void SetNombre(String Nombre);
        DropDownList GetTipo();
        void SetTipo(DropDownList combo);
        DropDownList GetCategoria();
        void SetCategoria(DropDownList combo);
    }
}
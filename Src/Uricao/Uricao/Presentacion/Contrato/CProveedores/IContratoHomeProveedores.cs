using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EProveedores;
using Uricao.LogicaDeNegocios.Clases.LNProveedores;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.Presentacion.Contrato.CProveedores
{
    public interface IContratoHomeProveedores
    {


        TextBox GetNombre();
        TextBox GetTextBoxRif();
        String NombreP();
        String RifP();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.Presentacion.Contrato.CProductosInventario
{
    public interface IContratoHomeInventario
    {
        void SetExito(String mensaje);
        void SetFalla(String mensaje);
    }
}
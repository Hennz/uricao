using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Data;
using System.Web.SessionState;

namespace Uricao.Presentacion.Contrato.CPresupuestoFacturas
{
    public interface IContratoConsultaFactura_Detalle
    {
        Label ALNombre_Persona_campo { get; set; }
        Label ALIdentificacion { get; set; }
        Label ALEstado_campo { get; set; }
        Label ALCiudad_campo { get; set; }
        Label ALMunicipio_campo { get; set; }
        Label ALCalle_campo { get; set; }
        Label ALEdificio_campo { get; set; }
        GridView GridViewDetalle { get; set; }
        Label ALSubtotal { get; set; }
        Label ALIVA { get; set; }
        Label ALTotal { get; set; }

        /// <summary>
        /// Obtiene el objeto sesion que se distribuye en todas las vistas
        /// </summary>
        HttpSessionState Sesion { get; }

        void Redireccionar(string _ruta);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Contrato.CHistoriaPaciente
{
    public interface IContratoDetalleHistoriaClinica
    {
        HttpSessionState Sesion { get; }
        Label Nombre { get; set; }
        Label Fecha { get; set; }
        Label Edad { get; set; }
        Label Sexo { get; set; }
        Label Ide { get; set; }
        Label Direccion { get; set; }
        Label Nace { get; set; }
        Label Telefono { get; set; }
        Label Obs { get; set; }
        Label P1 { get; set; }
        Label P2 { get; set; }
        Label P3 { get; set; }
        Label P4 { get; set; }
        Label P5 { get; set; }
        Label P6 { get; set; }
        Label P7 { get; set; }
        Label P8{ get; set; }
        Label P9 { get; set; }
        Label P10 { get; set; }
        Label P11 { get; set; }
        Label P12 { get; set; }
        Label P13 { get; set; }
        Label P14 { get; set; }
        Label P15 { get; set; }
        Label P16 { get; set; }
        Label P17 { get; set; }
        Label P18 { get; set; }
        void SetLabelFalla(String text);
        void SetLabelExito(String text); 
    }
}
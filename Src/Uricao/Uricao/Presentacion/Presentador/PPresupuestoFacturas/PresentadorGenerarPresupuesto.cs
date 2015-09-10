using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;

namespace Uricao.Presentacion.Presentador.PPresupuestoFacturas
{
    public class PresentadorGenerarPresupuesto
    {
        #region Atributos

        private IContratoGenerarPresupuesto _vista;
        private Comando<List<Entidad>> _miComandoFactura;
        private Comando<Entidad> _miComandoPresupuestoEntidad;
        private Comando<bool> _usuarioValido;
        private bool _usuarioValidoRespuesta;

        #endregion

        #region Constructor

        public PresentadorGenerarPresupuesto(IContratoGenerarPresupuesto vista)
        {
            this._vista = vista;
        }

        #endregion

        #region Métodos

        public void PageLoad(object sender, EventArgs e)
        {
            _vista.Sesion["cedula"] = null;
            _vista.Sesion["tipoci"] = null;
            _vista.Sesion["observaciones"] = null;
            _vista.Sesion["listaTratamientosElegidos"] = null;
        }

        public void BotonAceptar(object sender, EventArgs e)
        {
            _usuarioValido = FabricaComando.CrearComandovalidarUsuario(_vista.ATCI_Persona.Text,_vista.DDLTipoCi.Text);
            _usuarioValidoRespuesta = _usuarioValido.Ejecutar();
            if (_usuarioValidoRespuesta == true)
            {
                _vista.Sesion["cedula"] = _vista.ATCI_Persona.Text;
                _vista.Sesion["observaciones"] = _vista.ATObservaciones.Text;
                _vista.Sesion["tipoci"] = _vista.DDLTipoCi.SelectedItem.Value;
                _vista.AlCampoObligatorio.Visible = false;
                _vista.ALValidarUsuario.Visible = false;
                _vista.Redireccionar("GenerarPresupuesto_Detalle.aspx");
            }

            else
            {
                _vista.ALValidarUsuario.Text = "Usuario Invalido";
                _vista.ALValidarUsuario.Visible = true;
                _vista.ATCI_Persona.Focus();
                _vista.ATCI_Persona.Text = String.Empty;
            }
        }

        #endregion
    }
}
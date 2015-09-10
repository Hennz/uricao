using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Uricao.Presentacion.Contrato.CCuentasPorCobrar;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Comandos.CuentasPorCobrar;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Clases.LNAbono;
using Uricao.LogicaDeNegocios;

namespace Uricao.Presentacion.Presentador.PCuentasPorCobrar
{
    public class PresentadorAgregarAbono
    {
        #region Atributos

        private IContratoAgregarAbono _vista;
        private Comando<List<Entidad>> _comando;
        private int _numero;
        private int _factura;
        private int _cuenta;

        #endregion

        #region Constructor

        public PresentadorAgregarAbono(IContratoAgregarAbono _vista)
        {
            this._vista = _vista;
        }

        #endregion

        #region Metodos

        public void VistaPrincipal()
        {
            _vista.label5.Text = (string)_vista.Sesion["Nombres"] + (string)_vista.Sesion["Apellidos"];
            _vista.label6.Text = _vista.Sesion["NumFactura"].ToString();
            _vista.Falla.Visible = false;
            _vista.exito.Visible = false;
            _vista.monto.Style["text-align"] = "center";
            _vista.Datepicker.Style["text-align"] = "center";
            //Evento para validar que solamente se ingresen numeros en el Textbox
            _vista.monto.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            _cuenta = Convert.ToInt32(_vista.Sesion["NumCuenta"]);
            _factura = Convert.ToInt32(_vista.Sesion["NumFactura"]);

        }



        public void AccionBoton()
        {
            LogicaAbono validar = new LogicaAbono();

            if (_vista.Datepicker.Text.Equals(string.Empty) && _vista.monto.Text.Equals(string.Empty))
            {
                _vista.Falla.Text = "Error: Ingresar al menos un Parametro para la Busqueda";
                _vista.Falla.Visible = true;
            }
            else if (_vista.Datepicker.Text.Equals(string.Empty) && !_vista.monto.Text.Equals(string.Empty))
            {
                _vista.Falla.Text = "Error: Debe Ingresar un Fecha";
                _vista.Falla.Visible = true;
            }
            else if (!_vista.Datepicker.Text.Equals(string.Empty) && _vista.monto.Text.Equals(string.Empty))
            {
                _vista.Falla.Text = "Error: Debe Ingresar un Monto";
                _vista.Falla.Visible = true;
            }
            else if (Convert.ToDouble(_vista.monto.Text) < 0)
            {
                _vista.Falla.Text = "Monto Negativo";
                _vista.Falla.Visible = true;
            }
            else if (validar.ValidarMonto(Convert.ToInt32(_vista.label6.Text), Convert.ToDouble(_vista.monto.Text)))
            {
                LogicaAbono logica = new LogicaAbono();
/*
                if (AgregarAbonoCC(_vista.Datepicker.Text, this._factura, this._cuenta, Convert.ToDouble(_vista.monto.Text)))
                {
                    _vista.exito.Text = "Operacion Realizada Exitosamente";
                    _vista.exito.Visible = true;
                    _vista.Falla.Text = "";
                }
                else
                {
                    _vista.Falla.Text = "Operacion Fallida";
                    _vista.Falla.Visible = true;
                }
                */
            }
            else
            {
                _vista.Falla.Text = "Monto Excede la Deuda Actual";
                _vista.Falla.Visible = true;
            }
        }


        #endregion
    }
}
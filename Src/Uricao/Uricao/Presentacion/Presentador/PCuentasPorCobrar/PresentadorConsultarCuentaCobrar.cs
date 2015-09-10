using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Uricao.Presentacion.Contrato.CCuentasPorCobrar;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Comandos.CuentasPorCobrar;
using Uricao.Entidades.EEntidad;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Presentador.PCuentasPorCobrar
{
    public class PresentadorConsultarCuentaCobrar
    {
        #region Atributos

        string _tipo;
        private IContratoConsultarCuentaCobrar _vista;
        private Comando<List<Entidad>> _comando;

        #endregion

        #region Constructor

        public PresentadorConsultarCuentaCobrar(IContratoConsultarCuentaCobrar vista)
        {
            this._vista = vista;
        }

        #endregion

        #region Metodos

        public void VistaPrincipal()
        {
            _vista.exito.Visible = false;
            _vista.Falla.Visible = false;
            _vista.textCedula.Style["text-align"] = "center";
            _vista.Datepicker.Style["text-align"] = "center";
            _vista.Datepicker1.Style["text-align"] = "center";
            //Evento para validar que solamente se ingresen numeros en el Textbox
            _vista.textCedula.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        }

        public void AceptarBoton()
        {
            if (_vista.textCedula.Text.Equals(string.Empty) && (!_vista.Datepicker.Text.Equals(string.Empty) && !_vista.Datepicker1.Text.Equals(string.Empty)))
            {
                _vista.Sesion["Cedula"] = _vista.textCedula.Text;
                _vista.Sesion["FechaInicio"] = _vista.Datepicker.Text;
                _vista.Sesion["FechaFin"] = _vista.Datepicker1.Text;
               // //Response.Redirect("DetalleCuentaCobrar.aspx");
            }
            else if (!_vista.textCedula.Text.Equals(string.Empty) && (!_vista.Datepicker.Text.Equals(string.Empty) && !_vista.Datepicker1.Text.Equals(string.Empty)))
            {
                _vista.Sesion["Cedula"] = _vista.textCedula.Text;
                _vista.Sesion["FechaInicio"] = _vista.Datepicker.Text;
                _vista.Sesion["FechaFin"] = _vista.Datepicker1.Text;
              //  //Response.Redirect("ModificarEstado.aspx");
            }
            else if (!_vista.textCedula.Text.Equals(string.Empty) && (_vista.Datepicker.Text.Equals(string.Empty) && _vista.Datepicker1.Text.Equals(string.Empty)))
            {
                _vista.Sesion["Cedula"] = _vista.textCedula.Text;
                _vista.Sesion["FechaInicio"] = null;
                _vista.Sesion["FechaFin"] = null;
                //Response.Redirect("ModificarEstado.aspx");
            }
            else if (_vista.textCedula.Text.Equals(string.Empty) && (_vista.Datepicker.Text.Equals(string.Empty) && _vista.Datepicker1.Text.Equals(string.Empty)))
            {
                _vista.Falla.Text = "Error: Ingresar al menos un Parametro para la Busqueda";
                _vista.Falla.Visible = true;

            }
            else if (_vista.textCedula.Text.Equals(string.Empty) && (_vista.Datepicker.Text.Equals(string.Empty) || _vista.Datepicker1.Text.Equals(string.Empty)))
            {
                _vista.Falla.Text = "Error: Falta Ingresar una Fecha";
                _vista.Falla.Visible = true;
            }
            else if (_vista.textCedula.Text.Length != 0 && (_vista.Datepicker.Text.Equals(string.Empty) || _vista.Datepicker1.Text.Equals(string.Empty)))
            {
                _vista.Falla.Text = "Error2: Falta Ingresar una Fecha";
                _vista.Falla.Visible = true;
            }
        }

        public void RadioButton()
        {

         //   _tipo = _vista.RadioButtonList1.SelectedValue.ToString();
           // _vista.Sesion["TipoUser"] = _tipo; 
        }


        #endregion


    }
}
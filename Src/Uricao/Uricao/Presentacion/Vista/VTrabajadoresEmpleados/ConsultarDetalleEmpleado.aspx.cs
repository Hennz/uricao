using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CTrabajadoresEmpleados;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Presentador.PTrabajadoresEmpleados;

namespace Uricao.Presentacion.Vista.VTrabajadoresEmpleados
{
    public partial class ConsultarDetalleEmpleado : System.Web.UI.Page, IContratoConsultarDetalleEmpleado
    {
        #region Definicion
        private PresentadorConsultarDetalleEmpleado _presentador;

        public ConsultarDetalleEmpleado()
        {
            _presentador = new PresentadorConsultarDetalleEmpleado(this);
        }
        #endregion

        #region Gets y Sets

        public TextBox _TextNombre
        {
            get { return TextNombre; }
            set { TextNombre = value; }
        }

        public TextBox _TextApellido
        {
            get { return TextApellido; }
            set { TextApellido = value; }
        }

        public TextBox _TextCedula
        {
            get { return TextCedula; }
            set { TextCedula = value; }
        }

        public TextBox _TextFecha
        {
            get { return TextFecha; }
            set { TextFecha = value; }
        }

        public TextBox _TextTelefono
        {
            get { return TextTelefono; }
            set { TextTelefono = value; }
        }

        public TextBox _TextCorreo
        {
            get { return TextCorreo; }
            set { TextCorreo = value; }
        }

        public TextBox _TextSueldo
        {
            get { return TextSueldo; }
            set { TextSueldo = value; }
        }

        public TextBox _TextDireccion
        {
            get { return TextDireccion; }
            set { TextDireccion = value; }
        }

        public DropDownList _DropDownSexo
        {
            get { return DropDownSexo; }
            set { DropDownSexo = value; }
        }

        public DropDownList _DropDownCargo
        {
            get { return DropDownCargo; }
            set { DropDownCargo = value; }
        }

        public DropDownList _DropDownPais
        {
            get { return DropDownPais; }
            set { DropDownPais = value; }
        }

        public DropDownList _DropDownEstado
        {
            get { return DropDownEstado; }
            set { DropDownEstado = value; }
        }

        public DropDownList _DropDownCiudad
        {
            get { return DropDownCiudad; }
            set { DropDownCiudad = value; }
        }

        public Button _BotonEditar
        {
            get { return BotonEditar; }
            set { BotonEditar = value; }
        }

        public Button _BotonDesactivar
        {
            get { return BotonDesactivar; }
            set { BotonDesactivar = value; }
        }

        public Label _LabelExito
        {
            get { return LabelExito; }
            set { LabelExito = value; }
        }

        public Label _LabelFalla
        {
            get { return LabelFalla; }
            set { LabelFalla = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.LlenarComboPais();
                _presentador.SetearDireccionEmpleado();
                _presentador.CargarDetalle();
                _presentador.HabilitarComponentes("Editar", false);
            }
        }

        protected void BotonDesactivar_Click(object sender, EventArgs e)
        {
            _presentador.CambiarEstado();
            _presentador.SetearBotonActivarDesactivar();
        }

        protected void BotonEditar_Click(object sender, EventArgs e)
        {
            _presentador.AccionBotonEditar();
        }

        protected void DropDownPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Se disparo el evento de PAIS");
            _presentador.LlenarComboEstado();
        }

        protected void DropDownEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Se disparo el evento de ESTADO");
            _presentador.LlenarComboCiudad();
        }
    }
}
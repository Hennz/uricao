using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EEmpleados;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Presentacion.Contrato.CTrabajadoresEmpleados;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Presentador.PTrabajadoresEmpleados;

namespace Uricao.Presentacion.PaginasWeb.PTrabajadoresEmpleados
{
    public partial class AgregarEmpleado : System.Web.UI.Page, IContratoAgregarEmpleado
    {

         #region Definicion
        private PresentadorAgregarEmpleado _presentador;
        private List<Entidad> _empleados;

        public AgregarEmpleado()
        {
            _presentador = new PresentadorAgregarEmpleado(this);
        }
        #endregion

         #region Gets y Sets

        public Label _fallaAgregar
        {
            get { return fallaAgregar; }
            set { fallaAgregar = value; }
        }
        public Label _ExitoAgregar
        {
            get { return ExitoAgregar; }
            set { ExitoAgregar = value; }
        }

        public TextBox _TextCedula
        {
            get { return TextCedula; }
            set { TextCedula = value; }
        }
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


        public DropDownList _DropDownListSexo
        {
            get { return DropDownListSexo; }
            set { DropDownListSexo = value; }
        }
        public DropDownList _DropDownListCargo
        {
            get { return DropDownListCargo; }
            set { DropDownListCargo = value; }
        }
        public DropDownList _DropDownListPais
        {
            get { return DropDownListPais; }
            set { DropDownListPais = value; }
        }
        public DropDownList _DropDownListEstado
        {
            get { return DropDownListEstado; }
            set { DropDownListEstado = value; }
        }
        public DropDownList _DropDownListCiudad
        {
            get { return DropDownListCiudad; }
            set { DropDownListCiudad = value; }
        }




        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.LlenarComboPais();
            }
        }
      
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            _presentador.CargarEmpleado();
        }

        protected void DropDownListPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presentador.LlenarComboEstado();
        }

        protected void DropDownListEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presentador.LlenarComboCiudad();
        }


    }
}
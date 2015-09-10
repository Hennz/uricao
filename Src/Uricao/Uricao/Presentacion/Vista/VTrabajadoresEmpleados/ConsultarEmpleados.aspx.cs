using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EEmpleados;
using Uricao.Presentacion.Contrato.CTrabajadoresEmpleados;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Presentador.PTrabajadoresEmpleados;
using System.Data;

namespace Uricao.Presentacion.PaginasWeb.PTrabajadoresEmpleados
{
    public partial class ConsultarEmpleados : System.Web.UI.Page, IContratoConsultarEmpleados
    {
        #region Definicion
        private PresentadorConsultarEmpleados _presentador;
        private List<Entidad> _empleados;

        public ConsultarEmpleados()
        {
            _presentador = new PresentadorConsultarEmpleados(this);
        }
        #endregion

        #region Gets y Sets
        public GridView GridConsultar
        {
            get { return gridConsultar; }
            set { gridConsultar = value; }
        }

        public CheckBox _CheckInactivos
        {
            get { return CheckInactivos; }
            set { CheckInactivos = value; }
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

        public DropDownList _DropDownCargo
        {
            get { return DropDownCargo; }
            set { DropDownCargo = value; }
        }

        public Label _LabelExito
        {
            get { return ExitoAgregar; }
            set { ExitoAgregar = value; }
        }

        public Label _LabelFalla
        {
            get { return fallaAgregar; }
            set { fallaAgregar = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridConsultar_SelectIndexChanged(object sender, EventArgs e)
        {
            _presentador.CargarDetalle();
        }

        protected void gridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _presentador.CambiarPagina(e);
        }

        protected void BotonBuscar_Click(object sender, EventArgs e)
        {
            _presentador.RevisarFiltros();
        }

    }
}
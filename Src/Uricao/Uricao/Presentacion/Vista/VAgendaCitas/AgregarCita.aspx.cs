using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EAgendaCitas;
using System.Data;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorPagar;
using Uricao.LogicaDeNegocios.Clases.LNProveedores;
//using Uricao.LogicaDeNegocios.Clases.LNTratamientos;
using Uricao.Presentacion.Presentador.PAgendaCitas;
using Uricao.Presentacion.Contrato.CAgendaCitas;

namespace Uricao.Presentacion.PaginasWeb.PAgendaCitas
{
    public partial class AgregarCita : System.Web.UI.Page, IContratoAgregarCita
    {
        //Tratamiento:

        #region Atributos


        private PresentadorAgregarCita _presentador;

        #endregion


        #region Constructor
         
        public AgregarCita()
        {
            _presentador = new PresentadorAgregarCita(this);
        }

        #endregion


        #region Propiedades

        public TextBox ATBNombre
        {
            get { return aTBNombre; }
            set { aTBNombre = value; }
        }

        public TextBox ATBApellido
        {
            get { return aTBApellido; }
            set { aTBApellido = value; }
        }

        public TextBox ATBFecha
        {
            get { return aTBFecha; }
            set { aTBFecha = value; }
        }

        public DropDownList ADDTratamiento
        {
            get { return aDDTratamiento; }
            set { aDDTratamiento = value; }
        }

        public GridView GridViewCitasDisponibles
        {
            get { return gridViewCitasDisponibles; }
            set { gridViewCitasDisponibles = value; }
        }

        public Label MensajeDeTransaccion
        {
            get { return mensajeDeTransaccion; }
            set { mensajeDeTransaccion = value; }
        }

        #endregion


        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.InicializarVista();
            }
        }


       


        protected void GridViewCitasDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridViewCitasDisponibles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        protected void GridViewCitasDisponibles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            String direccionRedirigir = "DetalleAgregarCita.aspx";
            String datosCita = _presentador.RowCommandGridView(e.CommandName, e.CommandArgument);
            if (datosCita != "")
            {
                char[] charsToTrim = { '&' };
                String[] datosCitaArray = datosCita.Split(charsToTrim);
                Session["fecha"] = datosCitaArray[0];
                Session["horai"] = datosCitaArray[1];
                Session["horaf"] = datosCitaArray[2];
                Session["nombre"] = datosCitaArray[3];
                Session["apellido"] = datosCitaArray[4];
                Session["tratamiento"] = datosCitaArray[5];
                Response.Redirect(direccionRedirigir);
            }
        }


        public void Mensaje(int valorMensaje, String mensaje)
        {
            _presentador.MensajeError(valorMensaje,mensaje);
        }

        

        protected void defaultButton_Click(object sender, EventArgs e)
        {

            _presentador.AccionBotonVerDisponibilidad();
        }
        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Presentacion.Presentador.PPresupuestoFacturas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EEntidad;
using System.Web.SessionState;



namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{
    public partial class GenerarFacturaDatos : System.Web.UI.Page, IContratoGenerarFacturaDatos
    {

        private PresentadorGenerarFacturaDatos _presentador;

        
        #region Constructor

        public GenerarFacturaDatos()
        {
            _presentador = new PresentadorGenerarFacturaDatos(this);
        }

        #endregion

        #region contrato
        public Label Falla
        {
            get { return falla; }
            set { falla = value; }
        }

        public Label Exito
        {
            get { return exito; }
            set { exito = value; }
        }

        public Label ALNombre_Persona
        {
            get { return aLNombre_Persona; }
            set { aLNombre_Persona = value; }
        }

        public DropDownList ADNombre_Persona
        {
            get { return aDNombre_Persona; }
            set { aDNombre_Persona = value; }
        }

        public Label ALCIPaciente
        {
            get { return aLCIPaciente; }
            set { aLCIPaciente = value; }
        }

        public DropDownList ADPaciente
        {
            get { return aDPaciente; }
            set { aDPaciente = value; }
        }
        public Label ALFormatoCI
        {
            get { return aLFormatoCI; }
            set { ALFormatoCI = value; }
        }
        public Label ALCIPacienteError
        {
            get { return aLCIPacienteError; }
            set { aLCIPacienteError = value; }
        }
        public Label ALNombreRazonError
        {
            get { return aLNombreRazonError; }
            set { aLNombreRazonError = value; }
        }
        public HttpSessionState Sesion
        {
            get { return Session; }
        }
        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        } 
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["la_Factura"] = null;
            Session["listado_agregado"] = null;

            if (!IsPostBack)
            {
                //1- Mensajes de exito--fracaso:
                falla.Visible = false;
                exito.Visible = false;

                //2- Validaciones de SI EL ROL del SISTEMA ES EL ADECUADO PARA ENTRAR ACA!!!

                //3- Cargo desde la BD los campos textBox y DropDownlist:
                //DROPDOWNLIST usuario que paga la factura (cedula + nombre):
                _presentador.CargarIdUsuario(aDNombre_Persona);

                //DROPDOWNLIST paciente de la consulta, dentro de la factura (cedula + nombre):
               _presentador.CargarIdUsuario(aDPaciente);

            }

        }


        protected string[] agarrarValoresCamposDropDowns()
        {
            return _presentador.AgarrarValoresCamposDropDowns();

        }





        protected Factura agarrarValoresCampos()
        {

            return _presentador.AgarrarValoresCampos();
        }


        #region Validacion si los datos fueron introducidos
        protected Boolean datosFueronIntroducidos()
        {
            return _presentador.DatosFueronIntroducidos();
        }
        #endregion




        protected void aBBotonContinuar_Click(object sender, EventArgs e)
        {

            _presentador.aBBotonContinuar_Click(sender, e);
       

        }



      


    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.Presentacion.Presentador.PHistoriaPaciente;
using System.Web.SessionState;

namespace Uricao.Presentacion.Vista.VHistoriaPaciente
{
    public partial class AgregarHistoriaClinica : System.Web.UI.Page, IContratoAgregarHistoriaClinica
    {
        private PresentadorAgregarHistoriaClinica _presentador;

        public AgregarHistoriaClinica()
        {
          _presentador = new PresentadorAgregarHistoriaClinica(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            _presentador.CargarComboClientes();
            }
        }

        public DropDownList Combo
        {
            get { return ComboClientes; }
            set { ComboClientes = value; }
        }

        public TextBox Fecha
        {
            get { return date; }
            set { date = value; }
        }

        public TextBox Observacion
        {
            get { return TObservaciones; }
            set { TObservaciones = value; }
        }


        public void SetLabelFalla(String text)
        {
            falla.Text = text;
            falla.Visible = true;
        }

        public GridView GridConsultar1
        {
            get { return GridConsultar; }
            set { GridConsultar = value; }

        }

        public void SetLabelExito(String text)
        {
            Exito.Text = text;
            Exito.Visible = true;
        }

        public HttpSessionState Sesion
        {
            get { return Session; }
        }


        protected void defaultButton_Click(object sender, EventArgs e)
        {
            falla.Visible = false;
            Exito.Visible = false;
            if (_presentador.Agregar())
                agregar.Visible = true;
            //if (_presentador.agregarHistoriaClinica())
                //Redireccionar("/Presentacion/Vista/VHistoriaPaciente/AgregarAntecedente.aspx");
        }

        public void Redireccionar(string _ruta)
        {
            //Response.Redirect(_ruta);
            Response.AddHeader("REFRESH", "5;URL="+_ruta);
        }        

        protected void ComboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        /*
        private void pintarGrid()
        {
            List<Entidad> listaHistoriaClinica;
            listaHistoriaClinica = FabricaComando.CrearComandoConsultarHistoriaClinica("", "", "", (historia as HistoriaClinica).NumeroHistoria).Ejecutar();

            if (!(listaHistoriaClinica.Count == 0))
            {
                //Instanciamos el DataTable para que sea el surtidor de datos para el GridView

                DataTable _tabla = new DataTable();

                //Agregamos la columnas que vamos a setear.


                _tabla.Columns.Add("Historia", typeof(string));
                _tabla.Columns.Add("Fecha", typeof(string));
                _tabla.Columns.Add("Observacion", typeof(string));
                _tabla.Columns.Add("Estado", typeof(string));


                foreach (Entidad _historiaClinica in listaHistoriaClinica)

                    _tabla.Rows.Add((_historiaClinica as HistoriaClinica).NumeroHistoria,
                    (_historiaClinica as HistoriaClinica).FechaIngreso.ToString("dd-MM-yyyy"),
                     (_historiaClinica as HistoriaClinica).Observacion,
                    (_historiaClinica as HistoriaClinica).Estado);


                _vista.GridConsultar1.DataSource = _tabla;
                _vista.GridConsultar1.DataBind();
            }
        }
        */
    }
}
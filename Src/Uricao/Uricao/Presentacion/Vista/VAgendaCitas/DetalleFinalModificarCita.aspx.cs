using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EAgendaCitas;
using Uricao.Presentacion.Contrato.CAgendaCitas;
using Uricao.Presentacion.Presentador.PAgendaCitas;

namespace Uricao.Presentacion.PaginasWeb.PAgendaCitas
{
    public partial class DetalleFinalModificarCita : System.Web.UI.Page, IContratoDetalleFinalModificarCita
    {

        #region Atributos
        private String idCita;
        private String fecha;
        private int horai;
        private int horaf;
        private String nombre;
        private String apellido;
        private String tratamiento;
        private PresentadorDetalleFinalModificarCita _presentador;
        #endregion


        #region Constructor
        public DetalleFinalModificarCita()
        {
            _presentador = new PresentadorDetalleFinalModificarCita(this);
        }

        #endregion



        #region Propiedades

        public String IdCita
        {
            get { return idCita; }
            set { idCita = value; }
        }

        public String Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int Horai
        {
            get { return horai; }
            set { horai = value; }
        }

        public int Horaf
        {
            get { return horaf; }
            set { horaf = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public String Tratamiento
        {
            get { return tratamiento; }
            set { tratamiento = value; }
        }

        public Label LabelNombreMedico
        {
            get{ return labelNombreMedico; }
            set { labelNombreMedico = value; } 
        }

        public Label LabelFechaCita
        {
            get { return labelFechaCita; }
            set { labelFechaCita = value; }
        }

        public Label LabelHoraCita
        {
            get { return labelHoraCita; }
            set { labelHoraCita = value; }
        }

        public Label LabelNombreTratamiento
        {
            get { return labelNombreTratamiento; }
            set { labelNombreTratamiento = value; }
        }

        public Label LabelConfirmacionCita
        {
            get { return labelConfirmacionCita; }
            set { labelConfirmacionCita = value; }
        }

        public Label LabelStatusCita
        {
            get { return labelStatuscita; }
            set { labelStatuscita = value; }
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

            fecha = Convert.ToString(Session["fecha"]);
            horai = Convert.ToInt32(Convert.ToString(Session["horai"]));
            horaf = Convert.ToInt32(Convert.ToString(Session["horaf"]));
            nombre = Convert.ToString(Session["nombre"]);
            apellido = Convert.ToString(Session["apellido"]);
            tratamiento = Convert.ToString(Session["tratamiento"]);
            idCita = Convert.ToString(Session["idCita"]);
            int _idnuevo = Convert.ToInt16(idCita);
            //int _idnuevo = 15;

            _presentador.PublicarDatosLabels();
            _presentador.ModificarCita();
            

            //labelConfirmacionCita.Text = "No Confirmada";
            //labelStatuscita.Text = "Activa";
            //labelFechaCita.Text = fecha;
            //labelHoraCita.Text = horai + ":00" + " a " + horaf + ":00";
            //labelNombreMedico.Text = nombre + " " + apellido;
            //labelNombreTratamiento.Text = tratamiento;
           // Labelidcita.Text = (String)Session["idcita"];
        }
      

        protected void Button3_Click(object sender, EventArgs e)
        {
            //String fecha = Convert.ToString((Request.QueryString["fecha"] != null) ? Request.QueryString["fecha"] : "");
            //String horai = Convert.ToString((Request.QueryString["horai"] != null) ? Request.QueryString["horai"] : "");
            //String nombre = Convert.ToString((Request.QueryString["nombre"] != null) ? Request.QueryString["nombre"] : "");
            //String apellido = Convert.ToString((Request.QueryString["apellido"] != null) ? Request.QueryString["apellido"] : "");
            //String tratamiento = Convert.ToString((Request.QueryString["tratamiento"] != null) ? Request.QueryString["tratamiento"] : "");
            //Response.Redirect("DetalleCambiosModificarCita.aspx?fecha=" + fecha +
            //"&horai=" + horai + "&nombre=" + nombre + "&apellido=" + apellido + "&tratamiento=" + tratamiento);
        }

        #endregion
    }
}
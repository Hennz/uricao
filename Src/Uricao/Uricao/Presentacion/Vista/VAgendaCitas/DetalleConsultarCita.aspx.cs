using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EAgendaCitas;


namespace Uricao.Presentacion.PaginasWeb.PAgendaCitas
{
    public partial class DetalleConsultarCita : System.Web.UI.Page
    {
        private String idCita;

        protected void Page_Load(object sender, EventArgs e)
        {

           
            String fecha = Convert.ToString(Session["fecha"]);
            String horai = Convert.ToString(Session["horai"]);
            String horaf = Convert.ToString(Session["horaf"]);
            String nombre = Convert.ToString(Session["nombre"]);
            String apellido = Convert.ToString(Session["apellido"]);
            String tratamiento = Convert.ToString(Session["tratamiento"]);
            //idCita = Convert.ToString(Session["idCita"]);
            //int _idnuevo = Convert.ToInt16(idCita);
            //int _idnuevo = Convert.ToInt16(id);
            //int _idnuevo = 15;
            //LogicaCita miLogicoCita = new LogicaCita();
            //Cita _misCitas = miLogicoCita.DetalleCita(_idnuevo);                       
            //LabelConfirmacionCita.Text = _misCitas._Confirmacion;
            //LabelStatuscita.Text = _misCitas._Status;
            LabelFechaCita.Text = fecha;
            LabelHoraCita.Text = horai + ":00" + " a " + horaf + ":00";
            LabelNombreMedico.Text = nombre + " " + apellido;
            LabelNombreTratamiento.Text = tratamiento;
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
    }
}
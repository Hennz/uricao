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
    public partial class DetalleModificarCita : System.Web.UI.Page
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
            String confirmacion = Convert.ToString(Session["confirmacion"]);
            String status = Convert.ToString(Session["status"]);
            idCita = Convert.ToString(Session["idCita"]);
            int _idnuevo = Convert.ToInt16(idCita);
            //int _idnuevo = Convert.ToInt16(id);
            //int _idnuevo = 15;
            //LogicaCita miLogicoCita = new LogicaCita();
            //Cita _misCitas = miLogicoCita.DetalleCita(_idnuevo);
            LabelConfirmacionCita.Text = confirmacion;
            LabelStatuscita.Text = "Activa";
            LabelFechaCita.Text = fecha;
            LabelHoraCita.Text = horai + ":00" + " a " + horaf + ":00";
            LabelNombreMedico.Text = nombre + " " + apellido;
            LabelNombreTratamiento.Text = tratamiento;

        }


        public void Mensaje(int valorMensaje, String mensaje)
        {
            if (valorMensaje == 1)
            {
                MensajeDeTransaccion.Text = "Su cita fue confirmada con exito";

                MensajeDeTransaccion.Visible = true;

            }
            else
            {
                if (valorMensaje == 2)
                {
                    MensajeDeTransaccion.Text = "Su cita fue cancelada con exito" + mensaje;

                    MensajeDeTransaccion.Visible = true;
                }
            }
        }

        protected void aBConfirmar_Click(object sender, EventArgs e)
        {

            String direccionRedirigir = "ConfirmacionAccionCita.aspx";
            Session["idCita"] = Convert.ToInt32(idCita);
            Session["AccionConfirmarCancelar"] = "1";
            Response.Redirect(direccionRedirigir);
        }

        protected void aBCancelar_Click(object sender, EventArgs e)
        {
            String direccionRedirigir = "ConfirmacionAccionCita.aspx";
            Session["idCita"] = Convert.ToInt32(idCita);
            Session["AccionConfirmarCancelar"] = "2";
            Response.Redirect(direccionRedirigir);
        }

        protected void aBModificarDetalles_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleCambiosModificarCita.aspx");
        }
    }
}
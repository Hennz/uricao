using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EAgendaCitas;

namespace Uricao.Presentacion.PaginasWeb.PAgendaCitas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            String fecha = Convert.ToString((Request.QueryString["fecha"] != null) ? Request.QueryString["fecha"] : "");
            String horai = Convert.ToString((Request.QueryString["horai"] != null) ? Request.QueryString["horai"] : "");
            String horaf = Convert.ToString((Request.QueryString["horaf"] != null) ? Request.QueryString["horaf"] : "");
            String nombre = Convert.ToString((Request.QueryString["nombre"] != null) ? Request.QueryString["nombre"] : "");
            String apellido = Convert.ToString((Request.QueryString["apellido"] != null) ? Request.QueryString["apellido"] : "");
            String tratamiento = Convert.ToString((Request.QueryString["tratamiento"] != null) ? Request.QueryString["tratamiento"] : "");

           

            LabelFechaCita.Text = fecha;
           
            LabelNombreMedico.Text = nombre+" "+apellido;
            LabelNombreTratamiento.Text = tratamiento;
            Label2.Text = horai + ":00";
            Label4.Text = horaf + ":00";
           

        }

        public void Mensaje(int valorMensaje, String mensaje)
        {
            if (valorMensaje == 1)
            {
                MensajeDeTransaccion.Text = "Su cita fue modificada con exito";

                MensajeDeTransaccion.Visible = true;

            }
            else
            {
                if (valorMensaje == 0)
                {
                    MensajeDeTransaccion.Text = "Su cita no pudo ser modificada" + mensaje;

                    MensajeDeTransaccion.Visible = true;
                }
            }
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {            
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Presentador.PHistoriaPaciente;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using System.Web.SessionState;

namespace Uricao.Presentacion.Vista.VHistoriaPaciente
{
    public partial class Odontograma : System.Web.UI.Page, IContratoOdontodiagrama
    {
        private PresentadorOdontodiagrama _presentador;

        public  Odontograma()
        {
        _presentador = new PresentadorOdontodiagrama(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.CargarGrid();
            }
            
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            
            _presentador.agregar();

        }

        protected void GridConsultar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            String[] estado = { "" };
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                estado = DataBinder.Eval(e.Row.DataItem, "Estado").ToString().Split(' ');
               /* if (estado[0].Equals("activo"))
                {
                    e.Row.ForeColor = System.Drawing.Color.WhiteSmoke;
                    e.Row.BackColor = System.Drawing.Color.Navy;
                    e.Row.Font.Bold = true;
                }
                else
                {*/
                    if (estado[0].Equals("inactivo"))
                    {
                        e.Row.ForeColor = System.Drawing.Color.CornflowerBlue;
                        e.Row.BackColor = System.Drawing.Color.LightGray;
                        e.Row.Font.Bold = false;
                    }
               // }
            }
        }

        protected void GridConsultar_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "CambiarEstado")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);

                    GridViewRow row = GridConsultar.Rows[index];
                    String[] estado = { "" };
                    estado = row.Cells[9].Text.ToString().Split(' ');
                    int idSecuencia = Convert.ToInt32(row.Cells[3].Text);
                    
                    if (_presentador.SeActivoDesactivo(idSecuencia, estado[0]))
                        SetLabelExito("Se cambio el estado con exito");
                    else
                        SetLabelFalla("No se pudo cambiar estado");

                }
                catch (Exception)
                {
                    SetLabelFalla("No se pudo cambiar estado");
                }
            }
            else if (e.CommandName == "Detalle")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridConsultar.Rows[index];
                String[] estado = { "" };
                estado = row.Cells[9].Text.ToString().Split(' ');
                if (estado[0].Equals("activo"))
                {
                    int idSecuencia = Convert.ToInt32(row.Cells[3].Text);
                    String tratamiento = row.Cells[7].Text;

                    Session["Secuencia"] = _presentador.SeConsultoDetalle(idSecuencia);
                    Session["Tratamiento"] = _presentador.ElTratamiento(tratamiento);
                    Redireccionar("/Presentacion/Vista/VHistoriaPaciente/DetalleOdontograma.aspx");
                }
                else
                    SetLabelFalla("Debe de estar activo para esta accion");
            }

            else if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridConsultar.Rows[index];
                String[] estado = { "" };
                estado = row.Cells[9].Text.ToString().Split(' ');
                if (estado[0].Equals("activo"))
                {
                    int idSecuencia = Convert.ToInt32(row.Cells[3].Text);
                    _presentador.modificar(idSecuencia);
                }
                else
                    SetLabelFalla("Debe de estar activo para esta accion");
            }
        }

        public GridView GridConsultar1
        {
            get { return GridConsultar; }
            set { GridConsultar = value; }

        }

        public void SetLabelFalla(String text)
        {
            falla.Text = text;
            Exito.Visible = false;
            falla.Visible = true;
        }

        public void SetLabelExito(String text)
        {
            Exito.Text = text;
            falla.Visible = false;
            Exito.Visible = true;
        }

        public HttpSessionState Sesion
        {
            get { return Session; }
        }

            
        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
                _presentador.CargarGrid();
        }

        public DropDownList Medico
        {
            get { return medico; }
            set { medico = value; }
        }

        public DropDownList Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        public DropDownList Tratamiento
        {
            get { return tratamiento; }
            set { tratamiento = value; }
        }

        public DropDownList Rango1
        {
            get { return rango1; }
            set { rango1= value; }
        }

        public DropDownList Rango2
        {
            get { return rango2; }
            set { rango2 = value; }
        }


        public TextBox Fecha
        {
            get { return date; }
            set { date = value; }
        }

        public TextBox Observacion
        {
            get { return observaciones; }
            set { observaciones = value; }
        }


    }
}
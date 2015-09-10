using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.Presentacion.Presentador.PHistoriaPaciente;

namespace Uricao.Presentacion.Vista.VHistoriaPaciente
{
    public partial class ConsultarHistoriaClinica : System.Web.UI.Page, IContratoConsultarHistoriaClinica
    {
        #region Atributos

        private PresentadorConsultarHistoriaClinica _presentador;


        #endregion Atributos

        #region Constructor

        public ConsultarHistoriaClinica()
        {
            _presentador = new PresentadorConsultarHistoriaClinica(this);
        }

        #endregion Constructor

        #region Propiedades

        public GridView GridConsultar1
        {
            get { return GridConsultar; }
            set { GridConsultar = value; }

        }

        public TextBox TextBox
        {
            get { return Busqueda; }
            set { Busqueda = value; }

        }

        public HyperLink Link
        {
            get { return agregar; }
        }
        public RadioButtonList RadioButtonList
        {
            get { return RadioButtonList1; }
        }

        #endregion

        #region Métodos


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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void GridConsultar_SelectIndexChange(object sender, EventArgs e)
        {/*
   
            int seleccion = (GridConsultar.PageIndex * 5) + GridConsultar.SelectedIndex;
            Entidad historia = listaHistoriaClinica[seleccion];

            Session["idUsuario"] = historia as HistoriaClinica;*/

        }

        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        }

        #endregion Métodos

        protected void Button1_Click(object sender, EventArgs e)
        {
            falla.Visible = false;
            Exito.Visible = false;
            agregar.Visible = false;
            if (_presentador.ValidarDatos())
                _presentador.PintarConsultaHistoriaClinica();
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
                    int index =Convert.ToInt32(e.CommandArgument);

                    GridViewRow row = GridConsultar.Rows[index];
                    String[] estado = { "" };
                    estado = row.Cells[8].Text.ToString().Split(' ');
                    int idHistoria = Convert.ToInt32(row.Cells[3].Text);

                    if (_presentador.SeActivoDesactivo(idHistoria, estado[0]))
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
                estado = row.Cells[8].Text.ToString().Split(' ');
                if (estado[0].Equals("activo"))
                {
                    int idHistoria = Convert.ToInt32(row.Cells[3].Text);

                    Session["Historia"] = _presentador.SeConsultoDetalle(idHistoria);
                    Redireccionar("/Presentacion/Vista/VHistoriaPaciente/DetalleHistoriaClinica.aspx");
                }
                else
                    SetLabelFalla("Debe de estar activo para esta accion");
            }

            else if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridConsultar.Rows[index];
                String[] estado = { "" };
                estado = row.Cells[8].Text.ToString().Split(' ');
                if (estado[0].Equals("activo"))
                {
                    int idHistoria = Convert.ToInt32(row.Cells[3].Text);

                    Session["Historia"] = _presentador.SeConsultoDetalle(idHistoria);
                    Redireccionar("/Presentacion/Vista/VHistoriaPaciente/ModificarHistoriaClinica.aspx");
                }
                else
                    SetLabelFalla("Debe de estar activo para esta accion");
            }
            else if (e.CommandName == "Odontograma")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridConsultar.Rows[index];
                String[] estado = { "" };
                estado = row.Cells[8].Text.ToString().Split(' ');
                if (estado[0].Equals("activo"))
                {
                    int idHistoria = Convert.ToInt32(row.Cells[3].Text);

                    Session["Historia"] = _presentador.SeConsultoDetalle(idHistoria);
                    Redireccionar("/Presentacion/Vista/VHistoriaPaciente/Odontograma.aspx");
                }
                else
                    SetLabelFalla("Debe de estar activo para esta accion");
            }

        }

        protected void GridConsultar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultar.PageIndex = e.NewPageIndex;
            if (_presentador.ValidarDatos())
            _presentador.PintarConsultaHistoriaClinica();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (RadioButtonList.SelectedItem.Text == "Todo")
            { falla.Visible = true;
            falla.Text = "!algo0";}
                // Busqueda.Visible= false;
             
            if (RadioButtonList.Items[4].Selected == true)
            {
                Busqueda.Visible = false;
            }
            else
            {
                Busqueda.Visible = true;
            }
            Response.Redirect(Request.RawUrl);*/
        }
     

    }
}
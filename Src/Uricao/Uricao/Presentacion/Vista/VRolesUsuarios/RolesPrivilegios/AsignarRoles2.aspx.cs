using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.AccesoDeDatos.DAOS;

namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios
{
    public partial class AsignrRoles2 : System.Web.UI.Page
    {
        List<Entidad> miLista = new List<Entidad>();
        DAORol ConsultaBD = new DAORol();

        protected void Page_Load(object sender, EventArgs e)
        {
            //LogicaRol logica = new LogicaRol();
            int opcion = ComboOpcion.SelectedIndex;
            

            switch (opcion)
            {
                case 0:
                    miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", true, opcion);
                    break;
                case 1:
                    miLista = ConsultaBD.ConsultarRolParametrizado(int.Parse(textOpcion.Text), "", "", true, opcion);
                    break;
                case 2:
                    miLista = ConsultaBD.ConsultarRolParametrizado(0, textOpcion.Text, "", true, opcion);
                    break;
                case 3:
                    miLista = ConsultaBD.ConsultarRolParametrizado(0, "", textOpcion.Text, true, opcion);
                    break;
                case 4:
                    if (textOpcion.Text.ToUpper().Equals("ACTIVO"))
                    {
                        miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", true, opcion);
                    }
                    else
                    {
                        miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", false, opcion);
                    }
                    break;
            }
        }
        protected void CargarGridView()
        {
            //LogicaRol logica = new LogicaRol();
            int opcion = ComboOpcion.SelectedIndex;
           
            switch (opcion)
            {
                case 0:
                    miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", true, opcion);
                    GridConsultarRol.DataSource = miLista;
                    GridConsultarRol.DataBind();
                    GridConsultarRol.Visible = true;
                    break;
                case 1:
                    miLista = ConsultaBD.ConsultarRolParametrizado(int.Parse(textOpcion.Text), "", "", true, opcion);
                    GridConsultarRol.DataSource = miLista;
                    GridConsultarRol.DataBind();
                    GridConsultarRol.Visible = true;
                    break;
                case 2:
                    miLista = ConsultaBD.ConsultarRolParametrizado(0, textOpcion.Text, "", true, opcion);
                    GridConsultarRol.DataSource = miLista;
                    GridConsultarRol.DataBind();
                    GridConsultarRol.Visible = true;
                    break;
                case 3:
                    miLista = ConsultaBD.ConsultarRolParametrizado(0, "", textOpcion.Text, true, opcion);
                    GridConsultarRol.DataSource = miLista;
                    GridConsultarRol.DataBind();
                    GridConsultarRol.Visible = true;
                    break;
                case 4:
                    if (textOpcion.Text.ToUpper().Equals("ACTIVO"))
                    {
                        miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", true, opcion);
                        GridConsultarRol.DataSource = miLista;
                        GridConsultarRol.DataBind();
                        GridConsultarRol.Visible = true;
                    }
                    else
                    {
                        miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", false, opcion);
                        GridConsultarRol.DataSource = miLista;
                        GridConsultarRol.DataBind();
                        GridConsultarRol.Visible = true;
                    }
                    break;
            }
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            CargarGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridConsultarRol_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridConsultarRol.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        protected void GridConsultarRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccion = GridConsultarRol.SelectedIndex;
            Entidad miRol = miLista[seleccion];
            //Session["idRol"] = miRol;
            Session.Add("sesionRol", miRol);

            Response.Redirect("AsignarRoles3.aspx");
        }
    }
}
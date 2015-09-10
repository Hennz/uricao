using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.Presentacion.Contrato.CRolesUsuarios;
using Uricao.Presentacion.Presentador.PRolesUsuarios;
using Uricao.AccesoDeDatos.DAOS;

namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios
{
    public partial class ModificarRoles : System.Web.UI.Page, IContratoModificarRol
    {
        #region Atributos

        private PresentadorModificarRol _presentadorM;
        List<Entidad> miLista = new List<Entidad>();
        DAORol ConsultaBD = new DAORol();
        
        #endregion Atributos


        #region Constructores

        public ModificarRoles()
        {
            _presentadorM = new PresentadorModificarRol(this);
        }

        #endregion

        #region Propiedades
        public GridView IModGridView
        {
            get { return GridModificar; }
            set { GridModificar = value; }

        }

        public DropDownList IModDropDownList
        {
            get { return ComboOpcion; }
            set { ComboOpcion = value; }

        }

        public TextBox IModTextBox
        {
            get { return textOpcion; }
            set { textOpcion = value; }

        }

        public void IModFalla(String text)
        {
            falla.Text = text;
            falla.Visible = true;
        }

        public void IModExito(String text)
        {
            Exito.Text = text;
        }
        #endregion Propiedades

        #region Metodos
        protected void Page_Load(object sender, EventArgs e)
        {
            //_presentadorM.CargarDropDownList();

        
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


        
        #endregion Metodos

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            _presentadorM.CargarGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridModificar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            IModGridView.PageIndex = e.NewPageIndex;
            _presentadorM.CargarGridView();
        }

        protected void GridModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccion = GridModificar.SelectedIndex;
            Entidad miRol = miLista[seleccion];
            //Session["idRol"] = miRol;
            Session.Add("objRol", miRol);

            Response.Redirect("ModificarRoles2.aspx");

            try
            {

                int seleccionM = IModGridView.SelectedIndex;
                miLista = _presentadorM.CargarGridView();
                Entidad roles = miLista[seleccionM];

                Session["objRol"] = roles as Rol;
                Response.Redirect("ModificarRoles2.aspx");


            }
            catch (ArgumentOutOfRangeException)
            {
                IModFalla("Error de Sistema");
                IModGridView.Visible = false;
            }




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _presentadorM.CargarGridView();
        }
    }
}
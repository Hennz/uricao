using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Presentacion.Presentador.PRolesUsuarios;
using Uricao.Presentacion.Contrato.CRolesUsuarios;
using Uricao.Presentacion.Vista.VRolesUsuarios.RolesPrivilegios;
using Uricao.AccesoDeDatos.IDAOS;

namespace Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios
{
    public partial class Activar_DesactivarRoles : System.Web.UI.Page, IContratoActivarInactivarRoles
    {
        #region Atributos

        List<Entidad> roles = new List<Entidad>();
        private PresentadorActivarInactivarRoles _presentador;
        DAORol ConsultaBD = new DAORol();

        #endregion Atributos

        #region Propiedades

        public GridView RolesGridView
        {
            get { return GridConsultar; }
            set { GridConsultar = value; }
        }

        public Label Exito1
        {
            get { return Exito; }
            set { Exito = value; }

        }

        public Label Falla1
        {
            get { return falla; }
            set { falla = value; }
        }

        #endregion Propiedades

        protected void Page_Load(object sender, EventArgs e)
        {
            {
                _presentador.CargarGridView();
            }
        }

        protected void GridConsultar_PageIndexChanging(object sender, EventArgs e)
        {

        }

        protected void GridConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
           
        }
    }
}
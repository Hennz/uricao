using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Uricao.LogicaDeNegocios.Clases.LNProveedores;
using Uricao.Entidades.EProveedores;

namespace Uricao.Presentacion.PaginasWeb.PProveedores
{
    public partial class EditarProveedor : System.Web.UI.Page
    {

        
       // LogicaProveedor Logica = new LogicaProveedor();
        //LogicaProveedor Logica2 = new LogicaProveedor();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if( Session["estado"] != null)
                if (Session["estado"].Equals("EntradoEdicion"))
                {
                    llenarCampos();
                    Session["estado"] = "CamposLlenados";
                }

        }
        void llenarCampos()
        {
            if (Session["P.nombre"] != null)
            {
                TextBoxNombre.Text = Session["P.nombre"].ToString();
            }
            if (Session["P.rif"] != null)
            {
          //      Session["ID"] = (Logica.consultarIdProveedor(Logica2.ObtenerProveedoresPorRif(Session["P.rif"].ToString()))).ToString();
                TextBoxRif.Text = Session["P.rif"].ToString();
            }
                
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            if ((Session["P.nombre"] != null) && (Session["ID"] != null))
            {
                Proveedor proveedor = new Proveedor();
                //              proveedor = Logica.ObtenerProveedoresPorRif((Session["P.rif"].ToString()));
                proveedor.Nombre = TextBoxNombre.Text;
                proveedor.Rif = TextBoxRif.Text;
                System.Diagnostics.Debug.WriteLine("combobox:" + estadoNuevo.Text);
                proveedor.Estado = estadoNuevo.Text;
            }


            //            Logica.ModificarProveedor(proveedor, Session["ID"].ToString());
            /* if (//Logica2.consultarIdProveedor(proveedor).ToString().Equals(Session["ID"].ToString()))
             {
                 Exito.Text = "" + proveedor.Nombre + " modificado exitosamente";
                 Exito.Visible = true;
                 falla.Visible = false;
             }
             else
             {
                 falla.Text = proveedor.Nombre + " no se pudo modificar";
                 Exito.Visible = false;
                 falla.Visible = true;
             }
         }
         else
         {
             falla.Text = "Error en la modificacion";
             Exito.Visible = false;
             falla.Visible = true;
         }*/


        }
        

        protected void estadoNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
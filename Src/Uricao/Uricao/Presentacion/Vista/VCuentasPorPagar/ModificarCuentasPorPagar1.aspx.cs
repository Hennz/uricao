using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ECuentasPorPagar;
using System.Data;

using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EBancos;
using System.Drawing;
using Uricao.Presentacion.Presentador.PCuentasPorPagar;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;
using Uricao.Entidades.EEntidad;

namespace Uricao.Presentacion.PaginasWeb.PCuentasPorPagar
{
    public partial class ModificarCuentasPorPagar1 : System.Web.UI.Page, IContratoModificarCuentasPorPagar1
    {
         private PresentadorModificarCuentasPorPagar1 _presentador;
         public ModificarCuentasPorPagar1()
        {
            _presentador = new PresentadorModificarCuentasPorPagar1(this);
        }

         #region Contrato
         public TextBox Algo
         {
             get { return algo; }
             set { algo = value; }
         }

         public TextBox TextBox1
         {
             get { return textBox1; }
             set { textBox1 = value; }
         }
         public GridView GridView1
         {
             get { return gridView1; }
             set { gridView1 = value; }
         }

         public DropDownList DropDownList2
         {
             get { return dropDownList2; }
             set { dropDownList2 = value; }
         }

         public Label Falla
         {
             get { return falla; }
             set { falla = value; }
         }

         public Label Exito
         {
             get { return exito; }
             set { exito = value; }
         }
         public void Redireccionar(string _ruta)
         {
             Response.Redirect(_ruta);
         }
         #endregion

         //Atributos:
  
     
        List<NumeroCuentaBanco> listaNumeroCuentaBanco = new List<NumeroCuentaBanco>();


        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                _presentador.PageLoad();
            }
            
        }


        /// <summary>
        /// Llenado del Dropdownlist de RAZON SOCIAL.
        /// </summary>


        protected List<CuentaPorPagar> GetData()
        {
            List<CuentaPorPagar> datos = new List<CuentaPorPagar>();

            for (int i = 1; i <= 9; i++)
            {
                CuentaPorPagar dato = new CuentaPorPagar("CuentasPorPagar" + i, "CuentasPorPagar" + i, i);
                datos.Add(dato);
            }
            return datos;
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            
           if (e.CommandName == "Consultar")
            {
                _presentador.GridView1_RowCommand(sender, e);


            }

        }

      
        protected void defaultButton_Click(object sender, EventArgs e)
        {
            _presentador.OnClickModificarCuentaPorPagar();
            /*
            //variable para validar la coherencia de las dos fechas.
            bool fechasValidas = false;
            bool fechasNoEscritas = true;

            Page.Validate();

            if (Page.IsValid)
            {
                //Texto de Error:
                Exito.Text = "Operacion Realizada Exitosamente";
                falla.Text = "Operacion Fallida";

                //1- Se recoge la data de cada campo de la gui en el objeto  de cuentas por pagar:
                //Fila 1: Fechas:
                miCuentaPorPagarAagregar.FechaEmision = algo.Text;
                miCuentaPorPagarAagregar.FechaVencimiento = _vista.TextBox1.Text;

                //Fila 2 y 3: dropdownlists:
                //DropDownList3: razonsocial/empresa:
                Proveedor miProveedor = new Proveedor();
                miProveedor.Nombre = DropDownList2.SelectedItem.Text.ToString();
                //agrego a la lista el proveedor elegido por el usuario (razon social):
                miCuentaPorPagarAagregar.ListaProveedor.Add(miProveedor);


                //valida fechaini <= fechafin
                //Si las fechas fueron escritas:
                fechasNoEscritas = ((algo.Text == "") && (_vista.TextBox1.Text == ""));

                if (!fechasNoEscritas && (!((algo.Text == "") || (_vista.TextBox1.Text == ""))))
                {
                    fechasValidas = miCuentaPorPagarAagregar.ValidarFechaInicioMayorOigualQueFechaFin(Convert.ToDateTime(miCuentaPorPagarAagregar.FechaEmision).Date, Convert.ToDateTime(miCuentaPorPagarAagregar.FechaVencimiento).Date);

                }

                // si escogio solo razon social
                if (fechasNoEscritas && (DropDownList2.SelectedValue != "0"))
                {
                    falla.Visible = false;
                    Exito.Visible = true;
                    gridView1.DataSource = cargarTabla();
                    gridView1.DataBind();
                }
                //si escogio  solo fechas
                else if ((!fechasNoEscritas) && (DropDownList2.SelectedItem.Value == "0"))
                {
                    //Validar el rango de fechas:
                    if (fechasValidas)
                    {
                        //fechas correctas: dibujar el gridview.
                        falla.Visible = false;
                        Exito.Visible = true;
                        gridView1.DataSource = _presentador.cargarTablaFechas();
                        gridView1.DataBind();

                    }
                    else
                    {
                        Exito.Visible = false;
                        //fechaFinal > fechaInicial
                        falla.Text = "Operacion Fallida: Fecha de Emisión es mayor que la Fecha de Vencimiento.";
                        falla.Visible = true;
                    }
                }
                // si escogio fechas y razon social
                else if ((!fechasNoEscritas) && (DropDownList2.SelectedItem.Value != "0"))
                {

                    //Validar el rango de fechas:
                    if (fechasValidas)
                    {

                        falla.Visible = false;
                        Exito.Visible = true;
                        //fechas correctas: dibujar el gridview.
                        gridView1.DataSource = cargarTablaFechasProveedor();
                        gridView1.DataBind();

                    }
                    else
                    {
                        Exito.Visible = true;
                        //fechaFinal > fechaInicial
                        falla.Text = "Operacion Fallida: Fecha de Emisión es mayor que la Fecha de Vencimiento.";
                        falla.Visible = true;
                    }

                }
                    //si no  llena los campos de fecha
                else if ((DropDownList2.SelectedValue != "0") && ((algo.Text != "") && (_vista.TextBox1.Text == "")) || (algo.Text == "") && (_vista.TextBox1.Text != ""))
                {
                    Exito.Visible = false;
                    falla.Text = "Operacion Fallida: Parámetros de busqueda incompletos";
                    falla.Visible = true;
                }
                else if ((DropDownList2.SelectedValue == "0") && (algo.Text == "") && (_vista.TextBox1.Text == ""))
                {
                    Exito.Visible = false;
                    falla.Text = "Operacion Fallida: Parámetros de busqueda incompletos";
                    falla.Visible = true;
                }
                else
                {
                    Exito.Visible = false;
                    falla.Text = "Operacion Fallida: Parámetros de busqueda incompletos";
                    falla.Visible = true;

                }
            }*/
        }



        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Presentacion.Presentador.PPresupuestoFacturas;


namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{
    public partial class GenerarFacturaDetalle : System.Web.UI.Page, IContratoGenerarFacturaDetalle
    {
        #region atributos
        private PresentadorGenerarFacturaDetalle _presentador;
        private Factura la_factura;
        private List<Tratamiento> listado_buscado = new List<Tratamiento>();
        private List<Tratamiento> listado_agregado;
       // LogicaTratamiento miLogicaTratamiento = new LogicaTratamiento();
        private int posicion_grid_view;
        #endregion

        #region Constructor

        public GenerarFacturaDetalle()
        {
            _presentador = new PresentadorGenerarFacturaDetalle(this);
        }

        #endregion

        #region contrato
        public Label ALAviso
        {
            get { return aLAviso; }
            set { aLAviso = value; }
        }

        public Label ALAvisoAgregado
        {
            get { return aLAvisoAgregado; }
            set { aLAvisoAgregado = value; }
        }

        public Label Label2
        {
            get { return label2; }
            set { label2 = value; }
        }
        public RadioButton ARBNombre
        {
            get { return aRBNombre; }
            set { aRBNombre = value; }
        }

        public RadioButton ARBTodos
        {
            get { return aRBTodos; }
            set { aRBTodos = value; }
        }

        public Label Label3
        {
            get { return label3; }
            set { label3 = value; }
        }

        public DropDownList DropDownListTratamiento
        {
            get { return dropDownListTratamiento; }
            set { dropDownListTratamiento = value; }

        }

        public GridView AGTratamiento
        {
            get { return aGTratamiento; }
            set { aGTratamiento = value; }
        }

        public Label ALMensaje_Error
        {
            get { return aLMensaje_Error; }
            set { aLMensaje_Error = value; }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            /* codigo para recibir un objeto proveniente de la pagina anterior para desarrollar, se encuentra explicado en el
             * generarFactura_Datos.apsx.cs*/

            la_factura = (Factura)(Session["la_Factura"]);
            listado_agregado = (List<Tratamiento>)(Session["listado_agregado"]);

            if (!IsPostBack)
            {
                try
                {
                    if (listado_agregado.Count == 0)
                    {
                        aBBotonContinuar.Enabled = false;
                    }
                    else
                    {
                        aBBotonContinuar.Enabled = true;
                    }

                }
                catch (NullReferenceException ee)
                {
                    aBBotonContinuar.Enabled = false;
                }
                catch (Exception ee)
                {
                    aLMensaje_Error.Enabled = true;
                    aLMensaje_Error.Text = ee.Message;
                }
            }




        }

        protected bool ValidarTratamientoExistente(short idTratamiento)
        {
            return _presentador.ValidarTratamientoExistente(idTratamiento);
        }


        protected void AgregarTratamientoExistente(Tratamiento elNuevoTratamiento)
        {
            _presentador.AgregarTratamientoExistente(elNuevoTratamiento);
        }


        protected void BuscarXTodos()
        {

            _presentador.BuscarXTodos();
        }



        protected void BuscarXNombre()
        {
            _presentador.BuscarXNombre();
        }

        protected void aBBuscar_Click(object sender, EventArgs e)
        {


            _presentador.BotonBuscar_Click();

        }



        protected List<Entidad> GetDataTodos()
        {
            return _presentador.GetDataTodos();

        }

      

        protected List<Entidad> GetDataNombre()
        {
            return _presentador.GetDataNombre();

        }

        protected void aBBotonContinuar_Click(object sender, EventArgs e)
        {

            Session["Listado_Tratamientos"] = listado_agregado;
            Session["la_Factura"] = la_factura;
            Response.Redirect("GenerarFacturaDetalleCompleto.aspx");
        }

        protected void aGTratamiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Agregar_Tratamiento")
            {

                try
                {

                    posicion_grid_view = Convert.ToInt32(e.CommandArgument);

                    DropDownList ddl = (DropDownList)aGTratamiento.Rows[posicion_grid_view].Cells[3].FindControl("aDFCantidad");
                    int valor_cantirad = 0;

                    if (ddl.SelectedValue.Equals("x1"))
                    {
                        valor_cantirad = 1;

                    }
                    else
                    {
                        if (ddl.SelectedValue.Equals("x2"))
                        {
                            valor_cantirad = 2;
                        }
                        else
                        {
                            valor_cantirad = 3;
                        }
                    }

                    if (listado_agregado == null)
                    {
                        //si entra por primera vez entonces que lo inicialice

                        listado_agregado = new List<Tratamiento>();
                    }



                   // if (ValidarTratamientoExistente(short.Parse(aGTratamiento.Rows[posicion_grid_view].Cells[1].Text)))
                    //{
                    //    AgregarTratamientoExistente(new Tratamiento(
                    //    short.Parse(aGTratamiento.Rows[posicion_grid_view].Cells[1].Text),
                    //    aGTratamiento.Rows[posicion_grid_view].Cells[2].Text,
                    //    (short)valor_cantirad, 0, null, null, "Inactivo"));



                    //}

                    //else
                    //{
                        listado_agregado.Add(new Tratamiento(
                        short.Parse(aGTratamiento.Rows[posicion_grid_view].Cells[1].Text),
                        aGTratamiento.Rows[posicion_grid_view].Cells[2].Text,
                        (short)valor_cantirad, 0, null, null, "Inactivo"));



                    //}
                    aBBotonContinuar.Enabled = true;

                    aLAvisoAgregado.Visible = true;

                    /* debido a que tratamiento no tiene un atributo de cantidad, nosotros para metodos practicos, vamos a agregar un elemento
                    cantidad en el atributo duracion*/
                    Session["listado_agregado"] = listado_agregado;
                    /* el principal problema que hay utilizando el rowcommand, que las variables de la clases y las locales, se vuelven 
                     a instanciar como si tuvieras volviendo a entrar a la ventana, es por eso que tengo que enviar el session a cada rato 
                     para poder guardar el listado de cada uno de los tratamientos que voy agregar
                     */




                }
                catch (Exception ex)
                {

                    //error.Text = "Error" + ex.Message;

                }
            }
        }

        protected void aGTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["listado_agregado"] = listado_agregado;
            Session["la_Factura"] = la_factura;

        }



        protected void aRBNombre_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.aRBNombre_CheckedChanged(sender, e);

        }

        protected void aRBTodos_CheckedChanged(object sender, EventArgs e)
        {
            _presentador.aRBTodos_CheckedChanged(sender, e);


        }







    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EProductosInventario;
using Uricao.LogicaDeNegocios.Clases.LNProductosInventario;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Contrato.CTratamientos;
using Uricao.Presentacion.Presentador.PTratamientos;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;


namespace Uricao.Presentacion.PaginasWeb.PTratamientos
{
    public partial class AgregarTratamiento : System.Web.UI.Page, IContratoAgregarTratamiento
    {

        #region Atributos

        private PresentadorAgregarTratamiento _presentador;
        private int conta = 1;

        //private List<Entidad> _tratamientoSinAsociar;  //sin asociar
        //private List<Entidad> _tratamientosAsociados; //asociados
        //private List<Entidad> _productoSinAsociar; 
        //private List<Entidad> _productosAsociados; 
        //private List<Entidad> _implementosAsociados; 


        #endregion

        #region Propiedades

        public void SetLabelFalla(String text)
        {
            error.Text = text;
            error.Visible = true;
        }



        public Label Cont1
        {
            get { return cont; }
            set { cont = value; }
        }
        public TextBox Nombrep
        {
            get { return NombreTratamiento; }
            set { NombreTratamiento = value; }
        }

        public TextBox Duracionp
        {
            get { return Duracion; }
            set { Duracion = value; }
        }

        public TextBox Costop
        {
            get { return Costo; }
            set { Costo = value; }
        }

        public TextBox Descripcionp
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public TextBox Explicacionp
        {
            get { return Explicacion; }
            set { Explicacion = value; }
        }

        public ListBox TratamientosSinAsociar
        {
            get { return this.TratamientoSAsociado; }
            set { this.TratamientoSAsociado = value; }
        }

        public ListBox TratamientoAsociados
        {
            get { return this.TratamientoAsociado; }
            set { this.TratamientoAsociado = value; }
        }

        public ListBox ProductosSinAsociar
        {
            get { return ProductoSAsociado; }
            set { ProductoSAsociado = value; }
        }

        public ListBox ProductosAsociados
        {
            get { return this.ProductoAsociado; }
            set { this.ProductoAsociado = value; }
        }

        public TextBox CantidadP
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        public DropDownList PrioridadP
        {
            get { return Prioridad; }
            set { Prioridad = value; }
        }





        #endregion

        #region Constructor
        public AgregarTratamiento()
        {
            this._presentador = new PresentadorAgregarTratamiento(this);
            //this.Cont1.Text="Primera";

        }

        #endregion Constuctor


        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                MostrarDiv();
                conta = 1;
                if (this.Cont1.Text.Equals("Primera"))
                {


                    this._presentador.GetDataProducto();
                    this._presentador.GetDataTratamiento();
                    this.Cont1.Text = "+Segunda";
                    Session["Presentador"] = this._presentador;
                    this._presentador.CargarListaProductoSAsociar(this._presentador.ProductoSinAsociar);
                    this._presentador.CargarListaTratamientoSAsociar(this._presentador.TratamientoSinAsociar);
                    // this.SetLabelFalla(this._presentador.ProductoSinAsociar.Count.ToString());
                }
                else
                {
                    //this.ProductosSinAsociar.Items.Clear();
                    this._presentador = (PresentadorAgregarTratamiento)Session["Presentador"];
                    this._presentador.CargarListaProductoSAsociar(this._presentador.ProductoSinAsociar);
                    this._presentador.CargarListaProductoAsociados(this._presentador.ProductosAsociados);
                    this._presentador.CargarListaTratamientoSAsociar(this._presentador.TratamientoSinAsociar);

                }






                /* if ((this._presentador.Contador > 0))
                   {
                       //this.ProductosSinAsociar = new ListBox();
                       //this.TratamientosSinAsociar = new ListBox();

                       this._presentador = (PresentadorAgregarTratamiento) Session["Presentador"] ;

                       for (int i = 0; i <= this.ProductosSinAsociar.Rows; i++)
                           this._presentador.ProductoSinAsociar.RemoveAt(i);

                       this._presentador.CargarListaProductoSAsociar(this._presentador.ProductoSinAsociar);

                   }
                   else 
                   {
                       this._presentador.Contador = this._presentador.Contador +1;
                       Session["Presentador"] = this._presentador;
                            

                           this._presentador.CargarListaProductoSAsociar(this._presentador.GetDataProducto());
                            

                           this._presentador.CargarListaTratamientoSAsociar(this._presentador.GetDataTratamiento());

                                

                   }

                 error.Text = (this._presentador.Contador ).ToString();*/


            }

            catch (ExcepcionTratamiento ex)
            {
                error.Text = ex.Message;
            }
            catch (NullReferenceException ex)
            {
                error.Text = ex.Message;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }

        }

        //CARGAR DIV
        protected void OcultarDiv()
        {
            datosImplemento.Visible = false;
            Cantidad.Text = "1";
            Prioridad.SelectedIndex = 1;
        }
        //
        protected void MostrarDiv()
        {
            //datosImplemento.Visible = true;
            Cantidad.Text = "1";
            Prioridad.SelectedIndex = 0;
        }

        protected void TratamientoSAsociado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AgregarTratamientoAsociado_Click(object sender, EventArgs e)
        {

            if (conta == 1)
            {
                Session["IndexT"] = this.TratamientosSinAsociar.SelectedIndex;
                this.SetLabelFalla("1" + (this._presentador.TratamientoSinAsociar[((int)Session["IndexT"])] as Tratamiento).Nombre);
                this._presentador.AgregarTratamientos((int)Session["IndexT"]);
                Session["Presentador"] = this._presentador;
                conta++;
            }

        }
        //
        protected void EliminarTratamientoAsociado_Click(object sender, EventArgs e)
        {

            Session["IndexE"] = this.TratamientosSinAsociar.SelectedIndex;
            this.SetLabelFalla((this._presentador.TratamientosAsociados[((int)Session["IndexE"])] as Tratamiento).Nombre);
            this._presentador.EliminarTratamientoAsociado((int)Session["IndexE"]);
            Session["Presentador"] = this._presentador;

        }
        //
        protected void Agregar_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {

            this._presentador.Agregar();
            Response.Redirect("ConsultarTratamiento.aspx");
            
        }
        //listo
        protected void AgregarProducto_Click(object sender, EventArgs e)
        {
            Session["IndexA"] = this.ProductosSinAsociar.SelectedIndex;
            this.SetLabelFalla("1" + (this._presentador.ProductoSinAsociar[((int)Session["IndexA"])] as Producto).Nombre);
            this._presentador.AgregarProducto((int)Session["IndexA"]);
            Session["Presentador"] = this._presentador;
            MostrarDiv();

        }
        //listo
        protected void EliminarProducto_Click(object sender, EventArgs e)
        {
            Session["IndexP"] = this.ProductosAsociados.SelectedIndex;
            this.SetLabelFalla((this._presentador.ProductosAsociados[((int)Session["IndexP"])] as Producto).Nombre);
            this._presentador.EliminarProductoAsociado((int)Session["IndexP"]);
            Session["Presentador"] = this._presentador;
        }
        //
        protected void ProductoAsociado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EliminarProducto.Visible = true;
        }
        //
        protected void ProductoSAsociado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MostrarDiv();
            //AgregarProducto.Visible = true;
        }


    }
}
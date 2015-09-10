using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CTratamientos;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.LogicaDeNegocios.Excepciones;
using System.Web.UI.WebControls;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EProductosInventario;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.Presentacion.Presentador.PTratamientos
{
    public class PresentadorAgregarTratamiento
    {
        #region Atributos

        private IContratoAgregarTratamiento _vista;

        private List<Entidad> _tratamientoSinAsociar;  //sin asociar
        private List<Entidad> _tratamientosAsociados; //asociados


        private List<Entidad> _productoSinAsociar;
        private List<Entidad> _productosAsociados;
        private List<Entidad> _implementosAsociados;
        Entidad tratamiento = FabricaEntidad.NuevoTratamiento();
        Entidad producto = FabricaEntidad.NuevoProducto();
        Entidad _Implemento = FabricaEntidad.NuevoImplemento();

        public List<Entidad> TratamientosAsociados
        {
            get { return _tratamientosAsociados; }
            set { _tratamientosAsociados = value; }
        }

        public List<Entidad> TratamientoSinAsociar
        {
            get { return _tratamientoSinAsociar; }
            set { _tratamientoSinAsociar = value; }
        }

        public List<Entidad> ProductoSinAsociar
        {
            get { return _productoSinAsociar; }
            set { _productoSinAsociar = value; }
        }

        public List<Entidad> ProductosAsociados
        {
            get { return _productosAsociados; }
            set { _productosAsociados = value; }
        }

        public List<Entidad> ImplementosAsociados
        {
            get { return _implementosAsociados; }
            set { _implementosAsociados = value; }
        }

        #endregion Atributos


        #region Constructor

        public PresentadorAgregarTratamiento(IContratoAgregarTratamiento vista)
        {
            this._vista = vista;
            this._implementosAsociados = new List<Entidad>();
            this._productosAsociados = new List<Entidad>();
            this._tratamientosAsociados = new List<Entidad>();
            this._productoSinAsociar = new List<Entidad>();
            this._tratamientoSinAsociar = new List<Entidad>();

        }
        #endregion Constructor


        #region metodos


        public IContratoAgregarTratamiento Vista
        {
            get { return _vista; }
            set { _vista = value; }
        }

        public List<Entidad> GetDataTratamiento()
        {

            try
            {
                this._tratamientoSinAsociar = null;
                this._tratamientoSinAsociar = FabricaComando.CrearComandoConsultarTratamiento().Ejecutar();
            }

            catch (Exception e)
            {
                this._tratamientoSinAsociar = null;
                this._vista.SetLabelFalla(e.Message + "Error cargando tratamientos");
            }
            return this._tratamientoSinAsociar;

        }

        public List<Entidad> GetDataProducto()
        {

            try
            {
                this._productoSinAsociar = null;
                this._productoSinAsociar = FabricaComando.CrearComandoCargarListaProductoImplemento().Ejecutar();
            }
            catch (Exception e)
            {
                this._productoSinAsociar = null;
                this._vista.SetLabelFalla(e.Message + "Error cargando productos ");
            }
            return this._productoSinAsociar;

        }

        public void CargarListaTratamientoSAsociar(List<Entidad> datos)
        {
            //  this._vista.TratamientosSinAsociar = new ListBox();
            try
            {

                for (int i = 0; i < datos.Count(); i++)
                {
                    this._vista.TratamientosSinAsociar.Items.Add((datos[i] as Tratamiento).Nombre);
                }


            }
            catch (Exception ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Error Agregando Tratamientos");
            }


        }  //LISTO

        public void CargarListaProductoSAsociar(List<Entidad> datos)
        {
            this._vista.ProductosSinAsociar.Items.Clear();
            try
            {
                for (int i = 0; i < datos.Count(); i++)
                {
                    this._vista.ProductosSinAsociar.Items.Add((datos[i] as Producto).Nombre);
                }
            }
            catch (Exception ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Error Agregando Productos");
            }

        }

        public void CargarListaProductoAsociados(List<Entidad> datos)
        {
            this._vista.ProductosSinAsociar.Items.Clear();
            try
            {
                for (int i = 0; i < datos.Count(); i++)
                {
                    this._vista.ProductosAsociados.Items.Add((datos[i] as Producto).Nombre);
                }
            }
            catch (Exception ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Error Agregando Productos");
            }

        }

        public void AgregarTratamientos(int index)
        {
            //POSIBLE ERROR

            try
            {
                if (index != -1)
                {
                    //this._vista.SetLabelFalla((this._tratamientoSinAsociar[index] as Tratamiento).Nombre);

                    tratamiento = this._tratamientoSinAsociar[index];    //guardo el objeto seleccionado

                    this._tratamientosAsociados.Add(tratamiento);                                      //agrego el objeto a la lista sin asociar

                    this._tratamientoSinAsociar.Remove(tratamiento);                                  //quito el objeto de la lista de los asociados

                    this._vista.TratamientoAsociados.Items.Add((tratamiento as Tratamiento).Nombre);      //agrego el nombre del tratamiento de la otra lista

                    this._vista.TratamientosSinAsociar.Items.Remove((tratamiento as Tratamiento).Nombre);       //quito el tratamiento de la lista

                    //CargarListaTratamientoSAsociar(this.TratamientoSinAsociar);

                    tratamiento = null;                                                         //limpio el objeto auxiliar de tratamiento
                }
                else { this._vista.SetLabelFalla("Debe seleccionar un item de la lista"); }
            }
            catch (ExcepcionTratamiento ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Error  Tratamientos");
            }
            catch (NullReferenceException)
            {
                this._vista.SetLabelFalla("NULL");
            }
            catch (IndexOutOfRangeException)
            {
                this._vista.SetLabelFalla("Fuera de rango");
            }
            catch (Exception)
            {
                this._vista.SetLabelFalla("Otra");
            }

        }

        public void EliminarTratamientoAsociado(int index)
        {

            try
            {
                if (index != -1)
                {
                    tratamiento = this._tratamientosAsociados[index];  //guardo el objeto seleccionado

                    this._tratamientoSinAsociar.Add(tratamiento);                                 //agrego el objeto a la lista sin asociar
                    this._tratamientosAsociados.Remove(tratamiento);                               //quito el objeto de la lista de los asociados

                    this._vista.TratamientosSinAsociar.Items.Add((tratamiento as Tratamiento).Nombre);  //agrego el nombre del tratamiento de la otra lista

                    this._vista.TratamientoAsociados.Items.Remove((tratamiento as Tratamiento).Nombre);     //quito el tratamiento de la lista
                    tratamiento = null;                                                     //limpio el objeto auxiliar de tratamiento
                }
                else { this._vista.SetLabelFalla("Debe seleccionar un item de la lista"); }
            }
            catch (ExcepcionTratamiento ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Error  Tratamientos");
            }
            catch (NullReferenceException ex)
            {
                this._vista.SetLabelFalla(ex.Message + "NULL Tratamientos");
            }
            catch (IndexOutOfRangeException ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Fuera de rango Tratamientos");
            }
            catch (Exception ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Otro Tratamientos");
            }
        }

        public void AgregarProducto(int index)
        {
            //this._vista.SetLabelFalla(index.ToString());
            try
            {
                if (index != -1)
                {
                    //this._vista.ProductosAsociados.Items.Add("karen");

                    //this._vista._ProductoSinAsociar = this.GetDataProducto();

                    this._vista.SetLabelFalla((this._productoSinAsociar[index] as Producto).Nombre);
                    //error.Text = "";

                    producto = this._productoSinAsociar[index];         //guardo el objeto seleccionado

                    this._productosAsociados.Add(producto);                                        //agrego el objeto a la lista sin asociar
                    this._productoSinAsociar.Remove(producto);                                    //quito el objeto de la lista de los asociados

                    _Implemento = FabricaEntidad.NuevoImplementoCompleto(0, (producto as Producto).Id, 1,
                                                    (producto as Producto).Nombre, Convert.ToInt16(this._vista.CantidadP.Text), null);

                    this._implementosAsociados.Add(_Implemento);

                    this._vista.ProductosAsociados.Items.Add((producto as Producto).Nombre);        //agrego el nombre del tratamiento de la otra lista

                    this._vista.ProductosSinAsociar.Items.Remove((producto as Producto).Nombre);

                    //CargarListaProductoSAsociar(this._productoSinAsociar);         //quito el tratamiento de la lista
                    producto = null;                                                        //limpio el objeto auxiliar de tratamiento

                }
                else { this._vista.SetLabelFalla("Debe seleccionar un item de la lista"); }
            }
            catch (ExcepcionTratamiento ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Error  Producto");
            }
            catch (NullReferenceException ex)
            {
                this._vista.SetLabelFalla(ex.Message + "NULL Producto");
            }
            catch (IndexOutOfRangeException ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Fuera de rango Producto");
            }
            catch (Exception ex)
            {
                this._vista.SetLabelFalla(this._vista.ProductosSinAsociar.SelectedIndex.ToString() + "Otro Producto");
            }

        }

        public void EliminarProductoAsociado(int index)
        {

            try
            {
                if (index != -1)
                {
                    // error.Text = "";
                    producto = this._productosAsociados[index];  //guardo el objeto seleccionado
                    this._productoSinAsociar.Add(producto);                                 //agrego el objeto a la lista sin asociar
                    this._productosAsociados.Remove(producto);                               //quito el objeto de la lista de los asociados
                    this._implementosAsociados.Remove(producto);
                    this._vista.ProductosSinAsociar.Items.Add((producto as Producto).Nombre);  //agrego el nombre del tratamiento de la otra lista
                    this._vista.ProductosAsociados.Items.Remove((producto as Producto).Nombre);     //quito el tratamiento de la lista
                    producto = null;                                                     //limpio el objeto auxiliar de tratamiento
                }
                else { this._vista.SetLabelFalla("Debe seleccionar un item de la lista"); }
            }
            catch (ExcepcionTratamiento ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Error  Producto");
            }
            catch (NullReferenceException ex)
            {
                this._vista.SetLabelFalla(ex.Message + "NULL Producto");
            }
            catch (IndexOutOfRangeException ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Fuera de rango Producto");
            }
            catch (Exception ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Otro Producto");
            }
        }

        public void Agregar()
        {
            Entidad tratamiento1;
            try
            {
                if ((FabricaComando.CrearComandoValidarNumero(this._vista.Duracionp.Text).Ejecutar()) &&
                    (FabricaComando.CrearComandoValidarNumero(this._vista.Costop.Text).Ejecutar()) &&
                    (FabricaComando.CrearComandoValidaString(this._vista.Nombrep.Text).Ejecutar()) &&
                    (this._vista.Descripcionp.Text == String.Empty) && (this._vista.Explicacionp.Text == String.Empty))
                {
                    tratamiento1 = FabricaEntidad.NuevoTratamientoCompleto(0, this._vista.Nombrep.Text, Convert.ToInt16(this._vista.Duracionp.Text), Convert.ToInt16(this._vista.Costop.Text),
                                               this._vista.Descripcionp.Text, this._vista.Explicacionp.Text, "Activo");
                    //LogicaTratamiento logicatratamiento = new LogicaTratamiento();
                    // tratamiento1 = FabricaEntidad.NuevoTratamientoCompleto(0, "karen", 12, 23,
                    //  "asdfasdf", "sdafasdfasd", "Activo");
                    bool agrego = FabricaComando.CrearComandoAgregarTratamiento(tratamiento1, this._implementosAsociados, this._tratamientosAsociados).Ejecutar();

                }
                else { this._vista.SetLabelFalla("Debe seleccionar un item de la lista"); }
            }
            catch (ExcepcionTratamiento ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Error  Agregar");
            }
            catch (NullReferenceException ex)
            {
                this._vista.SetLabelFalla(ex.Message + "NULL Agregar");
            }
            catch (IndexOutOfRangeException ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Fuera de rango Agregar");
            }
            catch (Exception ex)
            {
                this._vista.SetLabelFalla(ex.Message + "Otro Agregar");
            }
        }


        #endregion metodos



    }
}
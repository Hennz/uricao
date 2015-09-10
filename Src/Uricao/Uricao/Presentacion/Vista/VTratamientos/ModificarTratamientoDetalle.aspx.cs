using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EProductosInventario;
using Uricao.LogicaDeNegocios.Clases.LNTratamientos;
using Uricao.LogicaDeNegocios.Clases.LNProductosInventario;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.Presentacion.PaginasWeb.PTratamientos
{
    public partial class ModificarTratamientoDetalle : System.Web.UI.Page
    {
        private static Tratamiento tratamiento = new Tratamiento();
        private static List<Tratamiento> _TratamientoAsociado = new List<Tratamiento>();
        private static List<Tratamiento> _TratamientoSAsociado = new List<Tratamiento>();

        private static Producto producto = new Producto();
        private static List<Producto> _ProductoAsociado = new List<Producto>();
        private static List<Producto> _ProductoSAsociado = new List<Producto>();

        private static Implemento _Implemento = new Implemento();
        private static List<Implemento> _ImplementoAsociado = new List<Implemento>();
        private static List<Implemento> _ImplementoSAsociado = new List<Implemento>();

        protected void Page_Load(object sender, EventArgs e)
        {
            tratamiento = (Tratamiento)Session["objTratamiento"];
            if (tratamiento == null)
                Response.Redirect("ModificarTratamiento.aspx");
            //error.Text = tratamiento.Id.ToString();
            if (!IsPostBack)
            {
                try
                {
                    CargarDatos();
                    MostrarDiv();
                    _TratamientoSAsociado = GetDataTratamiento();
                    CargarListaTratamientoSAsociar(_TratamientoSAsociado);

                    _TratamientoAsociado = GetDataTratamientoAsociado();
                    CargarListaTratamientoAsociar(_TratamientoAsociado);

                    _ImplementoSAsociado = GetDataProductoNoImplemento();
                    CargarListaProductoSAsociar(_ImplementoSAsociado);

                    _ImplementoAsociado = GetDataImplemento();
                    CargarListaProductoAsociar(_ImplementoAsociado);
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
        }
        //

        protected void CargarDatos()
        {
            NombreTratamiento.Text = tratamiento.Nombre;
            Duracion.Text = tratamiento.Duracion.ToString();
            Costo.Text = tratamiento.Costo.ToString();
            Descripcion.Text = tratamiento.Descripcion;
            Explicacion.Text = tratamiento.Explicacion;
        }

        protected void OcultarDiv()
        {
            datosImplemento.Visible = false;
            Cantidad.Text = "1";
            Prioridad.SelectedIndex = 1;
        }
        //
        protected void MostrarDiv()
        {
            datosImplemento.Visible = true;
            Cantidad.Text = "1";
            Prioridad.SelectedIndex = 0;
        }
        //
        #region Consultar Listas
        protected List<Tratamiento> GetDataTratamiento()
        {
            List<Tratamiento> datos;
            try
            {
                datos = new LogicaTratamiento().ConsultarTratamientoNoAsociado(tratamiento.Id);
            }
            catch (Exception e)
            {
                datos = null;
                error.Text = e.Message;
            }
            return datos;

        }

        protected List<Tratamiento> GetDataTratamientoAsociado()
        {
            List<Tratamiento> datos;
            try
            {
                datos = new LogicaTratamiento().ConsultarTratamientoAsociado(tratamiento.Id);
            }
            catch (Exception e)
            {
                datos = null;
                error.Text = e.Message;
            }
            return datos;

        }
        // 
        protected List<Implemento> GetDataProductoNoImplemento()
        {
            List<Implemento> datos;
            try
            {
                //datos = null;
                datos = new LogicaImplemento().CargarListaProductoNoImplemento(tratamiento);
            }
            catch (Exception e)
            {
                datos = null;
                error.Text = e.Message;
            }
            return datos;

        }
        //
        protected List<Implemento> GetDataImplemento()
        {
            List<Implemento> datos;
            try
            {
                datos = new LogicaImplemento().ConsultarImplemento(tratamiento);
            }
            catch (Exception e)
            {
                datos = null;
                error.Text = e.Message;
            }
            return datos;

        }
        #endregion

        #region Cargar las listas
        protected void CargarListaTratamientoSAsociar(List<Tratamiento> datos)
        {
            try
            {
                for (int i = 0; i < datos.Count(); i++)
                {
                    TratamientoSAsociado.Items.Add(datos[i].Nombre);
                }
            }
            catch (ExcepcionTratamiento ex)
            {
                error.Text = ex.Message;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }

        }

        protected void CargarListaTratamientoAsociar(List<Tratamiento> datos)
        {
            try
            {
                for (int i = 0; i < datos.Count(); i++)
                {
                    TratamientoAsociado.Items.Add(datos[i].Nombre);
                }
            }
            catch (ExcepcionTratamiento ex)
            {
                error.Text = ex.Message;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }

        }
        //
        protected void CargarListaProductoSAsociar(List<Implemento> datos)
        {
            try
            {
                for (int i = 0; i < datos.Count(); i++)
                {
                    ProductoSAsociado.Items.Add(datos[i].TipoProducto);
                }
            }
            catch (ExcepcionTratamiento ex)
            {
                error.Text = ex.Message;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }

        }
        //
        protected void CargarListaProductoAsociar(List<Implemento> datos)
        {
            try
            {
                for (int i = 0; i < datos.Count(); i++)
                {
                    ProductoAsociado.Items.Add(datos[i].TipoProducto);
                }
            }
            catch (ExcepcionTratamiento ex)
            {
                error.Text = ex.Message;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }

        }
        #endregion

        protected void TratamientoSAsociado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //
        protected void AgregarTratamientoAsociado_Click(object sender, EventArgs e)
        {
            try
            {
                if (TratamientoSAsociado.SelectedIndex != -1)
                {
                    tratamiento = _TratamientoSAsociado[TratamientoSAsociado.SelectedIndex];    //guardo el objeto seleccionado
                    _TratamientoAsociado.Add(tratamiento);                                      //agrego el objeto a la lista sin asociar
                    _TratamientoSAsociado.Remove(tratamiento);                                  //quito el objeto de la lista de los asociados
                    TratamientoAsociado.Items.Add(TratamientoSAsociado.SelectedItem.Text);      //agrego el nombre del tratamiento de la otra lista
                    TratamientoSAsociado.Items.Remove(TratamientoSAsociado.SelectedItem);       //quito el tratamiento de la lista
                    tratamiento = null;                                                         //limpio el objeto auxiliar de tratamiento
                }
                else { error.Text = "Debe seleccionar un item de la lista Sin Asociar"; }
            }
            catch (ExcepcionTratamiento ex)
            {
                error.Text = ex.Message;
            }
            catch (NullReferenceException)
            {
                error.Text = "Lista de tratamientos vacia";
            }
            catch (IndexOutOfRangeException)
            {
                error.Text = "Se paso de la lista";
            }
            catch (Exception)
            {
                error.Text = "Error";
            }
        }
        //
        protected void EliminarTratamientoAsociado_Click(object sender, EventArgs e)
        {
            try
            {
                if (TratamientoAsociado.SelectedIndex != -1)
                {
                    tratamiento = _TratamientoAsociado[TratamientoAsociado.SelectedIndex];  //guardo el objeto seleccionado
                    _TratamientoSAsociado.Add(tratamiento);                                 //agrego el objeto a la lista sin asociar
                    _TratamientoAsociado.Remove(tratamiento);                               //quito el objeto de la lista de los asociados
                    TratamientoSAsociado.Items.Add(TratamientoAsociado.SelectedItem.Text);  //agrego el nombre del tratamiento de la otra lista
                    TratamientoAsociado.Items.Remove(TratamientoAsociado.SelectedItem);     //quito el tratamiento de la lista
                    tratamiento = null;                                                     //limpio el objeto auxiliar de tratamiento
                }
                else { error.Text = "Debe seleccionar un item de la lista Sin Asociar"; }
            }
            catch (NullReferenceException ex)
            {
                error.Text = ex.Message;
            }
            catch (IndexOutOfRangeException ex)
            {
                error.Text = ex.Message;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
        }
        //
        protected void Agregar_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            try
            {
                tratamiento = new Tratamiento(0, NombreTratamiento.Text, Convert.ToInt16(Duracion.Text), Convert.ToInt16(Costo.Text),
                                                Descripcion.Text, Explicacion.Text, "Activo"); tratamiento.Imagen = "No contiene imagen";
                LogicaTratamiento logicatratamiento = new LogicaTratamiento();
                logicatratamiento.AgregarTratamiento(tratamiento, _ImplementoAsociado, _TratamientoAsociado);
                Response.Redirect("HomeTratamiento.aspx");
            }
            catch (NullReferenceException ex)
            {
                error.Text = ex.Message;
            }
            catch (IndexOutOfRangeException ex)
            {
                error.Text = ex.Message;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
        }
        //listo
        protected void AgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductoSAsociado.SelectedIndex != -1)
                {
                    error.Text = "";
                     _Implemento=_ImplementoSAsociado[ProductoSAsociado.SelectedIndex];         //guardo el objeto seleccionado
                    _ImplementoAsociado.Add(_Implemento);                                        //agrego el objeto a la lista sin asociar
                    _ImplementoSAsociado.Remove(_Implemento);                                    //quito el objeto de la lista de los asociados

                    //_Implemento = new Implemento(0, producto.Id, Convert.ToInt16(Prioridad.SelectedIndex + 1),producto.Nombre, Convert.ToInt16(Cantidad.Text), null);
                    
                    //_ImplementoAsociado.Add(_Implemento);

                    ProductoAsociado.Items.Add(ProductoSAsociado.SelectedItem.Text);        //agrego el nombre del tratamiento de la otra lista
                    ProductoSAsociado.Items.Remove(ProductoSAsociado.SelectedItem);         //quito el tratamiento de la lista
                    _Implemento = null;                                                        //limpio el objeto auxiliar de tratamiento
                    MostrarDiv();
                }
                else { error.Text = "Debe seleccionar un item de la lista Sin Asociar"; }

            }
            catch (ExcepcionTratamiento ex)
            {
                error.Text = ex.Message;
            }
            catch (NullReferenceException ex)
            {
                error.Text = ex.Message;
            }
            catch (IndexOutOfRangeException ex)
            {
                error.Text = ex.Message;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
        }
        //listo
        protected void EliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductoAsociado.SelectedIndex != -1)
                {
                    error.Text = "";
                    producto = _ProductoAsociado[ProductoAsociado.SelectedIndex];  //guardo el objeto seleccionado
                    _ProductoSAsociado.Add(producto);                                 //agrego el objeto a la lista sin asociar
                    _ProductoAsociado.Remove(producto);                               //quito el objeto de la lista de los asociados
                    _ImplementoAsociado.RemoveAt(ProductoAsociado.SelectedIndex);
                    ProductoSAsociado.Items.Add(ProductoAsociado.SelectedItem.Text);  //agrego el nombre del tratamiento de la otra lista
                    ProductoAsociado.Items.Remove(ProductoAsociado.SelectedItem);     //quito el tratamiento de la lista
                    producto = null;                                                     //limpio el objeto auxiliar de tratamiento
                }
                else { error.Text = "Debe seleccionar un item de la lista Asociados"; }
            }
            catch (ExcepcionTratamiento ex)
            {
                error.Text = ex.Message;
            }
            catch (NullReferenceException ex)
            {
                error.Text = ex.Message;
            }
            catch (IndexOutOfRangeException ex)
            {
                error.Text = ex.Message;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
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
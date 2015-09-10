using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Comandos.CTratamientos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;

namespace Uricao.Presentacion.Presentador.PPresupuestoFacturas
{
    public class PresentadorGenerarFacturaDetalle
    {
        #region Atributos

        private IContratoGenerarFacturaDetalle _vista;
        private PresentadorGenerarFacturaDetalle _presentador;
        private Factura la_factura;
        private List<Entidad> listado_buscado = new List<Entidad>();
        private List<Tratamiento> listado_agregado;
       // LogicaTratamiento miLogicaTratamiento = new LogicaTratamiento();
        private int posicion_grid_view;
        private Comando<List<Entidad>> _miComandoFactura;
        private Comando<List<Entidad>> _miComandoTratamiento;
        private List<Entidad> _miListaFacturas;
        private List<Entidad> _miListaTratamientos;
         private List<Entidad> listaUsuario;

        #endregion

        #region Constructor

        public PresentadorGenerarFacturaDetalle(IContratoGenerarFacturaDetalle vista)
        {
            this._vista = vista;
        }

        #endregion

        #region Métodos

        public bool ValidarTratamientoExistente(short idTratamiento)
        {
            foreach (Tratamiento elTratamientoLista in listado_agregado)
            {
                if (elTratamientoLista.Id == idTratamiento)
                {
                    return true;
                }
            }
            return false;
        }

        public void AgregarTratamientoExistente(Tratamiento elNuevoTratamiento)
        {
            foreach (Tratamiento elTratamientoLista in listado_agregado)
            {
                if (elTratamientoLista.Id == elNuevoTratamiento.Id)
                {
                    elTratamientoLista.Duracion =
                        (short)(elTratamientoLista.Duracion + elNuevoTratamiento.Duracion);


                }
            }

        }
      

        public void BuscarXTodos()
        {

           // listado_buscado = GetDataTodos();
            _miListaTratamientos = GetDataTodos();
           
           // for (int i = 0; i < _miListaTratamientos.Count(); i++)
            //{
                _vista.AGTratamiento.DataSource = _miListaTratamientos;

            //}
            if (_miListaTratamientos != null)
            {
                _vista.AGTratamiento.DataBind();
            }
            else
            {
                //aTBTratamiento.Text = "";
                //mostrar error porque no se muestra
            }
        }

        public void BuscarXNombre()
        {
            listado_buscado = GetDataNombre();
            _vista.AGTratamiento.DataSource = listado_buscado;
            if (listado_buscado != null)
            {
                _vista.AGTratamiento.DataBind();
            }
            else
            {
                _vista.ALAviso.Visible = true;
            }
        }


        public void BotonBuscar_Click()
        {

            _vista.ALMensaje_Error.Visible = false;
            _vista.ALAviso.Visible = false;
            _vista.ALAvisoAgregado.Visible = false;
            //if (ValidarCamposVentana())
            // {



            if (_vista.ARBNombre.Checked)
            {
                BuscarXNombre();
            }
            else
            {
                if (_vista.ARBTodos.Checked)
                {
                    BuscarXTodos();

                }
                else
                {
                    _vista.ALMensaje_Error.Text = "Error, Tiene Seleccionar una Opcion Para Poder Buscar";
                    _vista.ALMensaje_Error.Visible = true;
                }
            }
        }

        public List<Entidad> GetDataTodos()
        {
            List<Entidad> datos;
            try
            {
                _miComandoTratamiento =FabricaComando.CrearComandoConsultarTratamiento();
                datos = _miComandoTratamiento.Ejecutar();
                //new LogicaTratamiento().ConsultarTratamiento()
            }
            catch (Exception e)
            {
                datos = null;
                //error.Text = e.Message;
            }
            return datos;

        }

      

        public List<Entidad> GetDataNombre()
        {
            List<Entidad> datos;
            try
            {
                _miComandoFactura = FabricaComando.CrearComandoRegresarListadoXNombre(_vista.DropDownListTratamiento.Text);
                datos = _miComandoFactura.Ejecutar();
                //datos = new LogicaFactura().RegresarListadoXNombre(_vista.DropDownListTratamiento.Text);
            }
            catch (Exception e)
            {
                datos = null;
                //error.Text = e.Message;
            }
            return datos;

        }

        public void aRBNombre_CheckedChanged(object sender, EventArgs e)
        {
            _vista.ALMensaje_Error.Visible = false;
            _vista.ALAvisoAgregado.Visible = false;
            _vista.ALAviso.Visible = false;
            _vista.DropDownListTratamiento.Visible = true;
            _vista.Label3.Visible = true;

            _miComandoTratamiento = FabricaComando.CrearComandoConsultarTratamiento();
            _miListaTratamientos = _miComandoTratamiento.Ejecutar();
            //listado_buscado = miLogicaTratamiento.ConsultarTratamiento();

            for (int i = 0; i < _miListaTratamientos.Count; i++)
            {
                _vista.DropDownListTratamiento.Items.Add((_miListaTratamientos.ElementAt(i)as Tratamiento).Nombre.ToString());
            }


        }

        public void aRBTodos_CheckedChanged(object sender, EventArgs e)
        {
            _vista.ALMensaje_Error.Visible = false;
            _vista.ALAvisoAgregado.Visible = false;
            _vista.ALAviso.Visible = false;
            _vista.DropDownListTratamiento.Visible = false;
            _vista.Label3.Visible = false;



        }


        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;

namespace Uricao.Presentacion.Presentador.PPresupuestoFacturas
{
    public class PresentadorGenerarPresupuesto_Detalle
    {
        #region Atributos

        private IContratoGenerarPresupuesto_Detalle _vista;
        private Comando<List<Entidad>> _miComandoFactura;
        private Comando<Entidad> _miComandoPresupuestoEntidad;
        private Comando<bool> _usuarioValido;

        private List<Entidad> listaTratamientoElegidos = new List<Entidad>();

        private Comando<List<Entidad>> _miComandoTratamiento;
        private List<Entidad> _miListaTratamiento;
        private List<Entidad> _miListaTratamientoMetodos;
        private List<Entidad> _miListaTratamientoBuscar;

        private bool _usuarioValidoRespuesta;
        private string cedula;
        private string observaciones;
        private string tipoCi;
        private int posicion_grid_view;

        #endregion

        #region Constructor

        public PresentadorGenerarPresupuesto_Detalle(IContratoGenerarPresupuesto_Detalle vista)
        {
            this._vista = vista;
        }

        #endregion

        #region Métodos de la Página

        public void PageLoad(object sender, EventArgs e)
        {
            cedula = (string)_vista.Sesion["cedula"];
            observaciones = (string)_vista.Sesion["observaciones"];
            tipoCi = (string)_vista.Sesion["tipoci"];
            listaTratamientoElegidos = (List<Entidad>)(_vista.Sesion["listaTratamientosElegidos"]);
        }

        public void BotonBuscar(object sender, EventArgs e)
        {
            if (_vista.ARBNombre.Checked)
                BuscarXNombre();
            else
            {
                if (_vista.ARBTodos.Checked)
                    BuscarXTodos();
            }
        }

        public void aRBNombre_CheckedChanged()
        {
            _vista.ALAvisoAgregado.Visible = false;
            _vista.ALAviso.Visible = false;
            _vista.DropDownListTratamiento.Visible = true;

            _miComandoTratamiento = FabricaComando.CrearComandoConsultarTratamiento();
            _miListaTratamiento = _miComandoTratamiento.Ejecutar();

            for (int i = 0; i < _miListaTratamiento.Count; i++)
            {
                _vista.DropDownListTratamiento.Items.Add((_miListaTratamiento.ElementAt(i) as Tratamiento).Nombre.ToString());
            }
        }

        public void aRBTodos_CheckedChanged()
        {
            _vista.ALAvisoAgregado.Visible = false;
            _vista.ALAviso.Visible = false;
            _vista.DropDownListTratamiento.Visible = false;
            //_vista.a aBBotonContinuar.Enabled = true;
            //_vista.Label3.Visible = false;
        }

        public void BotonContinuar_Click(object sender, EventArgs e)
        {
            _vista.Sesion["cedula"] = cedula;
            _vista.Sesion["observaciones"] = observaciones;
            _vista.Sesion["listaTratamientosElegidos"] = listaTratamientoElegidos;
            _vista.Sesion["tipoci"] = tipoCi;
            _vista.Redireccionar("GenerarPresupuestoEspecifico.aspx");
        }

        public void aGTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            _vista.Sesion["listaTratamientosElegidos"] = listaTratamientoElegidos;
            _vista.Sesion["cedula"] = cedula;
            _vista.Sesion["observaciones"] = observaciones;
            _vista.Sesion["tipoci"] = tipoCi;
        }

        public void aGTratamiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
                {
                    posicion_grid_view = Convert.ToInt32(e.CommandArgument);
                    //para llenar la cantidad del combobox
                    DropDownList ddl = (DropDownList)_vista.AGTratamiento.Rows[posicion_grid_view].Cells[3].FindControl("aDFCantidad");
                    int valor_cantidad = 0;

                    if (ddl.SelectedValue.Equals("x1"))
                        valor_cantidad = 1;
                    else if (ddl.SelectedValue.Equals("x2"))
                        valor_cantidad = 2;
                    else
                        valor_cantidad = 3;

                    if (listaTratamientoElegidos == null)
                    {
                        //Si entra por primera vez entonces inicializa la lista de tratamientos elegidos
                        listaTratamientoElegidos = new List<Entidad>();
                        _vista.ABBotonContinuar.Enabled = true;
                        _vista.ABBotonContinuar.Visible = true;
                    }

                    if (ValidarTratamientoExistente(short.Parse(_vista.AGTratamiento.Rows[posicion_grid_view].Cells[1].Text)))
                    {
                        AgregarTratamientoExistente(new Tratamiento(
                        short.Parse(_vista.AGTratamiento.Rows[posicion_grid_view].Cells[1].Text),
                        _vista.AGTratamiento.Rows[posicion_grid_view].Cells[2].Text,
                        (short)valor_cantidad, 0, null, null, "Inactivo"));
                    }

                    else
                    {
                        listaTratamientoElegidos.Add(new Tratamiento(
                        short.Parse(_vista.AGTratamiento.Rows[posicion_grid_view].Cells[1].Text),
                        _vista.AGTratamiento.Rows[posicion_grid_view].Cells[2].Text,
                        (short)valor_cantidad, 0, null, null, "Inactivo"));

                    }

                    _vista.ALAvisoAgregado.Visible = true;
                    _vista.Sesion["listaTratamientosElegidos"] = listaTratamientoElegidos;
                    // Usamos un Session para agregar cada tratamiento que entra a un listado, ya que Rowcommand genera un problema, las variables de la clases y las locales se vuelva a instanciar
                }

                catch (Exception ex)
                {

                }
        }

        #endregion

        #region Métodos

        public void BuscarXTodos()
        {
            _vista.ALAvisoAgregado.Visible = false;
            _miListaTratamientoBuscar = GetDataTodos();
            _vista.AGTratamiento.DataSource = _miListaTratamientoBuscar;
            if (_miListaTratamientoBuscar != null)
            {
                _vista.AGTratamiento.DataBind();
                _vista.ALAviso.Visible = false;
            }
            else
                _vista.ALAviso.Visible = true;
        }

        public void BuscarXNombre()
        {
            _vista.ALAvisoAgregado.Visible = false;
            listaTratamientoElegidos = GetDataNombre();
            _vista.AGTratamiento.DataSource = listaTratamientoElegidos;
            if (listaTratamientoElegidos != null)
            {
                _vista.AGTratamiento.DataBind();
                _vista.ALAviso.Visible = false;
            }
            else
                _vista.ALAviso.Visible = true;
        }

        //Retorna la data de toda la lista de tratamientos
        public List<Entidad> GetDataTodos()
        {
            try
            {
                _miComandoTratamiento = FabricaComando.CrearComandoConsultarTratamiento();
                _miListaTratamientoMetodos = _miComandoTratamiento.Ejecutar();
            }
            catch (Exception e)
            {
                _miListaTratamientoMetodos = null;
            }
            return _miListaTratamientoMetodos;
        }

        //Retorna la data de la lista de tratamientos por Nombre
        public List<Entidad> GetDataNombre()
        {
            try
            {
                String espaciosBlanco = _vista.DropDownListTratamiento.Text.Trim();
                _miComandoTratamiento = FabricaComando.CrearomandoConsultarXNombreTratamiento(espaciosBlanco);
                _miListaTratamientoMetodos = _miComandoTratamiento.Ejecutar();
            }
            catch (Exception e)
            {
                _miListaTratamientoMetodos = null;
            }
            return _miListaTratamientoMetodos;
        }

        //metodo que llena listaTratamientoElegidos.
        public bool ValidarTratamientoExistente(short idTratamiento)
        {
            foreach (Entidad elTratamientoLista in listaTratamientoElegidos)
            {
                if ((elTratamientoLista as Tratamiento).Id == idTratamiento)
                {
                    return true;
                }
            }
            return false;
        }

        public void AgregarTratamientoExistente(Entidad elNuevoTratamiento)
        {
            foreach (Tratamiento elTratamientoLista in listaTratamientoElegidos)
            {
                if (elTratamientoLista.Id == (elNuevoTratamiento as Tratamiento).Id)
                {
                    elTratamientoLista.Duracion =
                        (short)(elTratamientoLista.Duracion + (elNuevoTratamiento as Tratamiento).Duracion);
                }
            }
        }

        #endregion
    }
}
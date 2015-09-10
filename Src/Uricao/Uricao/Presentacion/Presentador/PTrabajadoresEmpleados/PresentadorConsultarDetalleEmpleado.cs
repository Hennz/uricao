using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CTrabajadoresEmpleados;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEmpleados;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.Presentacion.Presentador.PTrabajadoresEmpleados
{
    public class PresentadorConsultarDetalleEmpleado
    {
        #region Definicion
        private IContratoConsultarDetalleEmpleado _vista;
        private Comando<bool> _comando;
        private Entidad _empleado;
        private Entidad _direccion;

        public PresentadorConsultarDetalleEmpleado(IContratoConsultarDetalleEmpleado _vista)
        {
            this._vista = _vista;
        }
        #endregion

        #region Metodos de Ver Detalle
        public void CargarDetalle()
        {
            _empleado = (HttpContext.Current.Session["Empleado"] as Entidad);

            _vista._TextNombre.Text     = (_empleado as Empleado).PrimerNombre;
            _vista._TextApellido.Text   = (_empleado as Empleado).PrimerApellido;
            //_vista._TIPOIDENTIFICACION     = (_empleado as Empleado).TipoIdentificacion;
            _vista._TextCedula.Text     = (_empleado as Empleado).Identificacion;
            _vista._TextCorreo.Text     = (_empleado as Empleado).Correo;
            _vista._TextDireccion.Text = (_empleado as Empleado).Direccion.Nombre;
            _vista._TextFecha.Text = (_empleado as Empleado).FechaNace.ToString(); //(_empleado as Empleado).FechaNace.Year + "-" + (_empleado as Empleado).FechaNace.Month + "-" + (_empleado as Empleado).FechaNace.Day;
            _vista._TextSueldo.Text     = (_empleado as Empleado).Sueldo.ToString();
            //_vista._TextTelefono.Text   = (_empleado as Empleado).Telefono;


            //Seteo el texto del boton para activar/desactivar
            SetearBotonActivarDesactivar();
        }

        public void SetearBotonActivarDesactivar()
        {
            if ((_empleado as Empleado).Estado.Trim().Equals("Activo"))
                _vista._BotonDesactivar.Text = "Desactivar";
            if ((_empleado as Empleado).Estado.Trim().Equals("Inactivo"))
                _vista._BotonDesactivar.Text = "Activar";
        }
        #endregion

        #region Metodos de Desactivar
        public bool CambiarEstado()
        {
            bool respuesta = false;
            try
            {
               
                _empleado = (HttpContext.Current.Session["Empleado"] as Entidad);

                //Seteo la variable Estado del Empleado

                string textBoton = _vista._BotonDesactivar.Text;
                if (textBoton.Equals("Activar"))
                    (_empleado as Empleado).Estado = "Activo";
                if (textBoton.Equals("Desactivar"))
                    (_empleado as Empleado).Estado = "Inactivo";

                //Se cambia el estado del empleado

                _comando = FabricaComando.CrearComandoCambiarEstadoEmpleado(_empleado);
                respuesta = _comando.Ejecutar();

                if (respuesta)
                {
                    if (textBoton.Equals("Activar"))
                    {
                        _vista._BotonDesactivar.Text = "Desactivar";
                        _vista._LabelExito.Text = "Operación exitosa. El empleado ahora está activo.";
                    }
                    if (textBoton.Equals("Desactivar"))
                    {
                        _vista._BotonDesactivar.Text = "Activar";
                        _vista._LabelExito.Text = "Operación exitosa. El empleado ahora está inactivo.";
                    }
                    _vista._LabelExito.Visible = true;
                }
                _vista._LabelFalla.Text = "Operación fallida. No se cambió el estado del empleado.";
            }
            catch (ExcepcionEmpleado e)
            {
                _vista._LabelFalla.Text = "Operacion fallida. " + e.MensajeError;
                _vista._LabelFalla.Visible = true;
            }
            catch (Exception e)
            {
                _vista._LabelFalla.Text = "Operacion fallida. " + e.Message;
                _vista._LabelFalla.Visible = true;
            }
            return respuesta;
        }
        #endregion

        #region Metodos de Editar
        public void AccionBotonEditar()
        {

            try{

            if (_vista._BotonEditar.Text.Equals("Editar"))
            {
                HabilitarComponentes("Aceptar",true);
                return;
            }
            if (_vista._BotonEditar.Text.Equals("Aceptar"))
            {


                HabilitarComponentes("Editar", false);
                //Aqui hacer la llamada a las validaciones de los campos ingresados

                _empleado = (HttpContext.Current.Session["Empleado"] as Entidad);


                _direccion = FabricaEntidad.NuevaDireccion();
                (_direccion as Direccion).Nombre = _vista._TextDireccion.Text;
                (_direccion as Direccion).Ciudad = _vista._DropDownCiudad.SelectedValue;

                (_empleado as Empleado).PrimerNombre = _vista._TextNombre.Text;
                (_empleado as Empleado).PrimerApellido = _vista._TextApellido.Text;
                string TipoIdentificacion = "V";
                (_empleado as Empleado).Identificacion = _vista._TextCedula.Text;
                (_empleado as Empleado).TipoIdentificacion = TipoIdentificacion;
                (_empleado as Empleado).FechaNace = Convert.ToDateTime(_vista._TextFecha.Text);
                (_empleado as Empleado).Telefono.Clear();
                (_empleado as Empleado).Telefono.Add(_vista._TextTelefono.Text);
                (_empleado as Empleado).Correo = _vista._TextCorreo.Text;
                (_empleado as Empleado).Sueldo = float.Parse(_vista._TextSueldo.Text);

                switch (_vista._DropDownSexo.SelectedIndex)
                {
                    case 0: { (_empleado as Empleado).Sexo = "Masculino"; } break;
                    case 1: { (_empleado as Empleado).Sexo = "Femenino"; } break;
                }

                switch (_vista._DropDownCargo.SelectedIndex)
                {
                    case 0: { (_empleado as Empleado).Especialidad = "Administrador de Empresa"; } break;
                    case 1: { (_empleado as Empleado).Especialidad = "Personal Odontologico"; } break;
                    case 2: { (_empleado as Empleado).Especialidad = "Personal Odontologico"; } break;
                    case 3: { (_empleado as Empleado).Especialidad = "Secretaria"; } break;
                }


                _comando = FabricaComando.CrearComandoAgregarEmpleado(_empleado, _direccion);


                _comando.Ejecutar();


            }
            }
            catch (ExcepcionEmpleado e)
            {
                _vista._LabelFalla.Text = "Operacion fallida. " + e.MensajeError;
                _vista._LabelFalla.Visible = true;
            }
            catch (Exception e)
            {
                _vista._LabelFalla.Text = "Operacion fallida. " + e.Message;
                _vista._LabelFalla.Visible = true;
            }
        }

        public void HabilitarComponentes(string textoBoton, bool habilitar)
        {
            _vista._BotonEditar.Text = textoBoton;

            _vista._DropDownCargo.Enabled = habilitar;
            _vista._DropDownCiudad.Enabled = habilitar;
            _vista._DropDownEstado.Enabled = habilitar;
            _vista._DropDownPais.Enabled = habilitar;
            _vista._DropDownSexo.Enabled = habilitar;
            _vista._TextApellido.Enabled = habilitar;
            _vista._TextCedula.Enabled = habilitar;
            _vista._TextCorreo.Enabled = habilitar;
            _vista._TextDireccion.Enabled = habilitar;
            _vista._TextFecha.Enabled = habilitar;
            _vista._TextNombre.Enabled = habilitar;
            _vista._TextSueldo.Enabled = habilitar;
            _vista._TextTelefono.Enabled = habilitar;
        }
        #endregion

        #region Metodos de Direccion
        public void LlenarComboPais()
        {
            _vista._DropDownPais.Items.Clear();
            _vista._DropDownPais.Items.Add("Seleccione el país");

            Comando<List<Entidad>> _comando = FabricaComando.CrearComandoConsultarPais();
            List<Entidad> _paises = _comando.Ejecutar();

            foreach (Entidad _pais in _paises)
            {
                _vista._DropDownPais.Items.Add((_pais as Direccion).Pais);
            }
        }

        public void LlenarComboEstado()
        {
            _vista._DropDownEstado.Items.Clear();
            _vista._DropDownCiudad.Items.Clear();
            _vista._DropDownEstado.Items.Add("Seleccione el estado");

            Entidad _pais = FabricaEntidad.NuevaDireccion();
            (_pais as Direccion).Pais = _vista._DropDownPais.SelectedValue;

            Comando<List<Entidad>> _comando = FabricaComando.CrearComandoConsultarEstado(_pais);
            List<Entidad> _estados = _comando.Ejecutar();

            foreach (Entidad _estado in _estados)
            {
                _vista._DropDownEstado.Items.Add((_estado as Direccion).Estado);
            }
        }

        public void LlenarComboCiudad()
        {

            _vista._DropDownCiudad.Items.Clear();
            _vista._DropDownCiudad.Items.Add("Seleccione la ciudad");

            Entidad _estado = FabricaEntidad.NuevaDireccion();
            (_estado as Direccion).Estado = _vista._DropDownEstado.SelectedValue;

            Comando<List<Entidad>> _comando = FabricaComando.CrearComandoConsultarCiudad(_estado);
            List<Entidad> _ciudades = _comando.Ejecutar();

            foreach (Entidad _ciudad in _ciudades)
            {
                _vista._DropDownCiudad.Items.Add((_ciudad as Direccion).Ciudad);
            }
        }

        public void SetearDireccionEmpleado()
        {
            _empleado = (HttpContext.Current.Session["Empleado"] as Entidad);

            _vista._DropDownPais.SelectedValue = (_empleado as Empleado).Direccion.Fk_dir.Fk_dir.Fk_dir.Pais;
            LlenarComboEstado();
            _vista._DropDownEstado.SelectedValue = (_empleado as Empleado).Direccion.Fk_dir.Fk_dir.Estado;
            LlenarComboCiudad();
            _vista._DropDownCiudad.SelectedValue = (_empleado as Empleado).Direccion.Fk_dir.Ciudad;

        }

        #endregion
    }
}
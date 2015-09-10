using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CTrabajadoresEmpleados;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Comandos;
using System.Web.UI.WebControls;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EEmpleados;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.Presentacion.Presentador.PTrabajadoresEmpleados
{
    public class PresentadorAgregarEmpleado
    {

        #region Definicion
        private IContratoAgregarEmpleado _vista;
        private Comando<bool> _comando;
        private Entidad _empleado;
        private Entidad _direccion;
    

        public PresentadorAgregarEmpleado(IContratoAgregarEmpleado _vista)
        {
            this._vista = _vista;
        }
        #endregion

        public void CargarEmpleado()
        {
            try
            {
            _direccion = FabricaEntidad.NuevaDireccion();
            (_direccion as Direccion).Nombre = _vista._TextDireccion.Text;
            (_direccion as Direccion).Ciudad = _vista._DropDownListCiudad.SelectedValue;

            _empleado = FabricaEntidad.NuevoEmpleado();
            (_empleado as Empleado).PrimerNombre = _vista._TextNombre.Text;
            (_empleado as Empleado).PrimerApellido = _vista._TextApellido.Text;
            string TipoIdentificacion = "V";
            (_empleado as Empleado).Identificacion = _vista._TextCedula.Text;
            (_empleado as Empleado).TipoIdentificacion = TipoIdentificacion;
            (_empleado as Empleado).FechaNace = Convert.ToDateTime(_vista._TextFecha.Text);
            (_empleado as Empleado).Telefono.Add(_vista._TextTelefono.Text);      
            (_empleado as Empleado).Correo = _vista._TextCorreo.Text;
            (_empleado as Empleado).Sueldo = float.Parse(_vista._TextSueldo.Text);

            switch (_vista._DropDownListSexo.SelectedIndex)
            {
                case 0: { (_empleado as Empleado).Sexo = "Masculino"; } break;
                case 1: { (_empleado as Empleado).Sexo = "Femenino"; } break;
            }

            switch (_vista._DropDownListCargo.SelectedIndex)
            {
                    case 0: {(_empleado as Empleado).Especialidad = "Administrador de Empresa"; } break;
                    case 1: {(_empleado as Empleado).Especialidad = "Personal Odontologico"; } break;
                    case 2: {(_empleado as Empleado).Especialidad = "Personal Odontologico"; } break;
                    case 3: { (_empleado as Empleado).Especialidad = "Secretaria"; } break;
            }


            _comando = FabricaComando.CrearComandoAgregarEmpleado(_empleado,_direccion);

            
                _comando.Ejecutar();
            }
            catch (ExcepcionEmpleado e)
            {
                _vista._fallaAgregar.Text = "Operacion fallida. "+e.MensajeError;
                _vista._fallaAgregar.Visible = true;
            }
            catch (Exception e)
            {
                _vista._fallaAgregar.Text = "Operacion fallida. " + e.Message;
                _vista._fallaAgregar.Visible = true;
            }
        }

        #region Metodos de Direccion
        public void LlenarComboPais()
        {
            _vista._DropDownListPais.Items.Clear();
            _vista._DropDownListPais.Items.Add("Seleccione el país");

            Comando<List<Entidad>> _comando = FabricaComando.CrearComandoConsultarPais();
            List<Entidad> _paises = _comando.Ejecutar();

            foreach (Entidad _pais in _paises)
            {
                _vista._DropDownListPais.Items.Add((_pais as Direccion).Pais);
            }
        }

        public void LlenarComboEstado()
        {
            _vista._DropDownListEstado.Items.Clear();
            _vista._DropDownListCiudad.Items.Clear();
            _vista._DropDownListEstado.Items.Add("Seleccione el estado");
            System.Diagnostics.Debug.Write("esto deberia aparecer");

            Entidad _pais = FabricaEntidad.NuevaDireccion();
            (_pais as Direccion).Pais = _vista._DropDownListPais.SelectedValue;
           
            Comando<List<Entidad>> _comando = FabricaComando.CrearComandoConsultarEstado(_pais);
            List<Entidad> _estados = _comando.Ejecutar();

            foreach (Entidad _estado in _estados)
            {
                _vista._DropDownListEstado.Items.Add((_estado as Direccion).Estado);
           }
        }

        public void LlenarComboCiudad()
        {

            _vista._DropDownListCiudad.Items.Clear();
            _vista._DropDownListCiudad.Items.Add("Seleccione la ciudad");

            Entidad _estado = FabricaEntidad.NuevaDireccion();
            (_estado as Direccion).Estado = _vista._DropDownListEstado.SelectedValue;
          
            Comando<List<Entidad>> _comando = FabricaComando.CrearComandoConsultarCiudad(_estado);
            List<Entidad> _ciudades = _comando.Ejecutar();

            foreach (Entidad _ciudad in _ciudades)
            {
                _vista._DropDownListCiudad.Items.Add((_ciudad as Direccion).Ciudad);
            }
        }

        #endregion

    }
}
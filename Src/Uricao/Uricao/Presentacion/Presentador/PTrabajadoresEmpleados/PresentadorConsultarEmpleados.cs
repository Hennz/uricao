using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CTrabajadoresEmpleados;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using System.Data;
using Uricao.Entidades.EEmpleados;
using System.Web.UI.WebControls;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.Presentacion.Presentador.PTrabajadoresEmpleados
{
    public class PresentadorConsultarEmpleados
    {
        #region Definicion
        private IContratoConsultarEmpleados _vista;
        private Comando<List<Entidad>> _comando;
        private List<Entidad> _empleados;

        public PresentadorConsultarEmpleados(IContratoConsultarEmpleados _vista)
        {
            this._vista = _vista;
        }
        #endregion

        #region Métodos

        public void PintarConsultaEmpleados()
        {
            DataTable _tabla = new DataTable();
            //if (ValidarDatos())
            {
                _empleados = (HttpContext.Current.Session["Empleados"] as List<Entidad>);

                if (_empleados.Count != 0)
                {   List<string> nombreColumnas = new List<string> { "Cédula", "Nombre", "Apellido", "Cargo" };
                    CrearTabla(_tabla, nombreColumnas);

                    foreach (Entidad _empleado in _empleados)
                    {
                        _tabla.Rows.Add(
                        (_empleado as Empleado).TipoIdentificacion + "-" + (_empleado as Empleado).Identificacion,
                        (_empleado as Empleado).PrimerNombre,
                        (_empleado as Empleado).PrimerApellido,
                        (_empleado as Empleado).Especialidad
                        );
                    }  
                }
                //Esto es importante, sino, se carga vacio el datagrid
                _vista.GridConsultar.AutoGenerateColumns = true;
                _vista.GridConsultar.DataSource = _tabla;
                _vista.GridConsultar.DataBind();
            }
        }

        public List<Entidad> ListarEmpleados(string nombreProcedimiento)
        {
            _comando = FabricaComando.CrearComandoConsultarTodosEmpleados(nombreProcedimiento);
            _empleados = _comando.Ejecutar();

            return _empleados;
        }
    

        #endregion Métodos.

        public void CargarTabla()
        {
            DataTable _tabla = new DataTable();
            List<string> columnas = new List<string>() { "Cédula", "Nombre", "Apellido", "Cargo" };
            CrearTabla(_tabla, columnas);
            _empleados = (HttpContext.Current.Session["Empleados"] as List<Entidad>);
            foreach (Entidad _empleado in _empleados)
            {
                _tabla.Rows.Add(
                        (_empleado as Empleado).TipoIdentificacion + "-" + (_empleado as Empleado).Identificacion,
                        (_empleado as Empleado).PrimerNombre,
                        (_empleado as Empleado).PrimerApellido,
                        (_empleado as Empleado).Especialidad
                        );
            }

            _vista.GridConsultar.DataSource = _tabla;
            _vista.GridConsultar.DataBind();
        }

        public void CargarDetalle()
        {
			_empleados = (HttpContext.Current.Session["Empleados"] as List<Entidad>);
            Entidad _empleado = _empleados[SeleccionGrid(_vista.GridConsultar)];

            HttpContext.Current.Session["Empleado"] = _empleado;
            HttpContext.Current.Response.Redirect("ConsultarDetalleEmpleado.aspx"); 
        }
		
		#region Filtros de Empleados
        public void RevisarFiltros()
        {
            try
            {
                //Aqui recorrer la lista completa de empleados, y pintar una lista filtrada, sin perder la original.
                //Primero: Escoger cual sera la lista original de empleados.

                //Si esta el check de ver inactivos la lista original será la del procedimiento ListaEmpleadosTodos
                if (_vista._CheckInactivos.Checked)
                {
                    _empleados = ListarEmpleados("ListaEmpleadoInactivos");
                }
                //Sino, ListaEmpleadosActivos.
                else
                {
                    _empleados = ListarEmpleados("ListaEmpleadoActivos");
                }
                HttpContext.Current.Session["Empleados"] = _empleados;

                //Filtrar por cedula

                string cedula = _vista._TextCedula.Text;
                if (cedula != "")
                {
                    FiltrarPorCedula(cedula);
                }

                //Filtrar por cargo

                if (_vista._DropDownCargo.SelectedIndex != 0)
                {
                    FiltrarPorCargo(_vista._DropDownCargo.SelectedValue);
                }

                //Filtra por nombre

                string nombre = _vista._TextNombre.Text;
                if (nombre != "")
                {
                    FiltrarPorNombre(nombre);
                }

                //Filtra por apellido

                string apellido = _vista._TextApellido.Text;
                if (apellido != "")
                {
                    FiltrarPorApellido(apellido);
                }


                //Pintar la tabla filtrada con los registros que pasaron el filtro
                PintarConsultaEmpleados();

                _empleados = (HttpContext.Current.Session["Empleados"] as List<Entidad>);
                if (_empleados.Count == 0)
                {
                    _vista._LabelFalla.Text = "No hay coincidencias";
                    _vista._LabelFalla.Visible = true;
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

        public void FiltrarPorCedula(string cedula)
        {
            List<Entidad> _empleadosConFiltro = FabricaEntidad.NuevaListaEmpleados();
            _empleados = (HttpContext.Current.Session["Empleados"] as List<Entidad>);

            foreach (Entidad _empleado in _empleados)
            {
                if ((_empleado as Empleado).Identificacion.Contains(cedula))
                {
                    _empleadosConFiltro.Add(_empleado);
                }
            }
            _empleados = _empleadosConFiltro;

            HttpContext.Current.Session["Empleados"] = _empleados;
        }

        public void FiltrarPorNombre(string nombre)
        {
            List<Entidad> _empleadosConFiltro = FabricaEntidad.NuevaListaEmpleados();
            _empleados = (HttpContext.Current.Session["Empleados"] as List<Entidad>);

            foreach (Entidad _empleado in _empleados)
            {
                if ((_empleado as Empleado).PrimerNombre.Trim().Contains(nombre))
                {
                    _empleadosConFiltro.Add(_empleado);
                }
            }
            _empleados = _empleadosConFiltro;

            HttpContext.Current.Session["Empleados"] = _empleados;
        }

        public void FiltrarPorApellido(string apellido)
        {
            List<Entidad> _empleadosConFiltro = FabricaEntidad.NuevaListaEmpleados();
            _empleados = (HttpContext.Current.Session["Empleados"] as List<Entidad>);

            foreach (Entidad _empleado in _empleados)
            {
                if ((_empleado as Empleado).PrimerApellido.Trim().Contains(apellido))
                {
                    _empleadosConFiltro.Add(_empleado);
                }
            }
            _empleados = _empleadosConFiltro;

            HttpContext.Current.Session["Empleados"] = _empleados;
        }

        public void FiltrarPorCargo(string cargo)
        {
            List<Entidad> _empleadosConFiltro = FabricaEntidad.NuevaListaEmpleados();
            _empleados = (HttpContext.Current.Session["Empleados"] as List<Entidad>);

            foreach (Entidad _empleado in _empleados)
            {
                if ((_empleado as Empleado).Especialidad.Trim().Contains(cargo))
                {
                    _empleadosConFiltro.Add(_empleado);
                }
            }

            _empleados = _empleadosConFiltro;

            HttpContext.Current.Session["Empleados"] = _empleados;
        }
        #endregion

        #region MetodosBasicos
        public int SeleccionGrid(GridView GridConsultar)
        {
            int seleccion = GridConsultar.SelectedIndex;
            if (GridConsultar.PageIndex != 0)
            {
                int pagina = GridConsultar.PageIndex;
                GridConsultar.PageIndex = 0;
                //int filas = GridConsultar.Rows.Count;
                int filas = 8;
                seleccion = filas * pagina + seleccion;
            }
            return seleccion;
        }

        public void CambiarPagina(GridViewPageEventArgs e)
        {
            _vista.GridConsultar.PageIndex = e.NewPageIndex;
            CargarTabla();
        }

        public void CrearTabla(DataTable table, List<string> columnas)
        {
            foreach (string columna in columnas)
                table.Columns.Add(columna, typeof(string));
        }

        #endregion

    }
}
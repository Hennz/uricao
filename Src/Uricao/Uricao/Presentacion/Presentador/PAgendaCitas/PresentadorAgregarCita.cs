using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Uricao.Presentacion.Contrato.CAgendaCitas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Comandos.AgendaCitas;
using Uricao.LogicaDeNegocios.Comandos.CTratamientos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Fabricas;

namespace Uricao.Presentacion.Presentador.PAgendaCitas
{
    public class PresentadorAgregarCita
    {

        #region Atributos

        private IContratoAgregarCita _vista;
        private Comando<List<Entidad>> _comando;
        private List<Entidad> listaTratamiento;


        #endregion


        #region Constructor

        public PresentadorAgregarCita(IContratoAgregarCita _vista)
        {
            this._vista = _vista;
        }

        #endregion


        #region Metodos
        public void InicializarVista()
        {
            _vista.ATBNombre.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            _vista.ATBApellido.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            _vista.ATBFecha.Attributes.Add("onkeypress", "javascript:return ValidNum2(event);");

            CargarListaTratamientos();
            CargarTratamientoDropDownList();
        }


        public void CargarListaTratamientos()
        {
////////////////////////////////////////////////////////// Cambiar este comando al que permite buscar por estado de tratamiento/////////////////////////////
            Comando<List<Entidad>> _comandoTratamiento = FabricaComando.CrearComandoConsultarTratamiento();
            listaTratamiento = _comandoTratamiento.Ejecutar();        
        }


        public void CargarTratamientoDropDownList()
        {
            for (int i = 0; i < listaTratamiento.Count; i++)
            {
                _vista.ADDTratamiento.Items.Add((listaTratamiento.ElementAt(i) as Tratamiento).Nombre.ToString());
            }
        }


        public void MensajeError(int valorMensaje, String mensaje)
        {
            if (valorMensaje == 1)
            {
                _vista.MensajeDeTransaccion.Text = "No hay citas para esa fecha con esos datos";

                _vista.MensajeDeTransaccion.Visible = true;

            }
            else
            {
                if (valorMensaje == 0)
                {
                    _vista.MensajeDeTransaccion.Text = "Existen campos vacios" + mensaje;

                    _vista.MensajeDeTransaccion.Visible = true;
                }
                if (valorMensaje == 3)
                {
                    _vista.MensajeDeTransaccion.Text = "No deben ser fechas pasadas" + mensaje;

                    _vista.MensajeDeTransaccion.Visible = true;
                }
                if (valorMensaje == 4)
                {
                    _vista.MensajeDeTransaccion.Text = "La fecha introducida es invalida. Debe tener el formato dd/mm/yyyy." + mensaje;

                    _vista.MensajeDeTransaccion.Visible = true;                
                }
            }
        }


        public void AccionBotonVerDisponibilidad()
        {
            _vista.MensajeDeTransaccion.Visible = false;
            String _nombreMedico = _vista.ATBNombre.Text;
            String _apellidoMedico = _vista.ATBApellido.Text;
            String _tratamiento = _vista.ADDTratamiento.SelectedItem.Text;
            
            DateTime Hoy = new DateTime();
            Hoy = DateTime.Today;

            if ((_nombreMedico == "") && (_apellidoMedico == "") && (_vista.ATBFecha.Text == "") && (_tratamiento == "Seleccione la opcion"))
            {
                MensajeError(0, "");
            }
            if ((_nombreMedico != "") && (_apellidoMedico != "") && (_vista.ATBFecha.Text != "") && (_tratamiento != "Seleccione la opcion"))
            {
                String _fechaString = (_vista.ATBFecha.Text);
                try
                {
                    DateTime _fecha1 = DateTime.ParseExact(_fechaString, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    String _diaSemana = ManejoDiaFecha(_fecha1);
                    if (_fecha1 >= Hoy)
                    {
                        Comando<int[]> comandoCitas = FabricaComando.CrearComandoHorarioDisponibleMedicoFecha(_nombreMedico, _apellidoMedico, _fecha1, _tratamiento, _diaSemana);
                        int [] _citasDisponibles = comandoCitas.Ejecutar();
                        if (_citasDisponibles != null)
                        {
                            if (_citasDisponibles.Length > 0)
                            {
                                _vista.GridViewCitasDisponibles.PageSize = _citasDisponibles.Length;
                            }
                        }
                        _vista.GridViewCitasDisponibles.DataSource = CargarDataTableCitas(_citasDisponibles);
                        _vista.GridViewCitasDisponibles.DataBind();
                    if (_vista.GridViewCitasDisponibles.Rows.Count == 0)
                    {

                        MensajeError(1, "");
                    }
                    }
                    else
                    {
                        MensajeError(3, "");
                    }
                }
                catch (FormatException ex)
                {
                    MensajeError(4, "");
                }
                
                
            }

        }


        public String ManejoDiaFecha(DateTime _fecha)
        {
            String _diaSemana = _fecha.DayOfWeek.ToString();        
            if((_diaSemana == "Domingo") || (_diaSemana == "Sunday"))
            {
                return "Domingo";
            }
            else if ((_diaSemana == "Lunes") || (_diaSemana == "Monday"))
            {
                return "Lunes";
            }
            else if ((_diaSemana == "Martes") || (_diaSemana == "Tuesday"))
            {
                return "Martes";
            }
            else if ((_diaSemana == "Miercoles") || (_diaSemana == "Wednesday"))
            {
                return "Miercoles";
            }
            else if ((_diaSemana == "Jueves") || (_diaSemana == "Thursday"))
            {
                return "Jueves";
            }
            else if ((_diaSemana == "Viernes") || (_diaSemana == "Friday"))
            {
                return "Viernes";
            }
            else if ((_diaSemana == "Sabado") || (_diaSemana == "Saturday"))
            {
                return "Sabado";
            }
            else
            {
                return "";
            }

        }



        public DataTable CargarDataTableCitas(int [] _citasDisponibles)
        {

            DataTable miTabla = new DataTable();
            if (_citasDisponibles.Length > 0)
            {
                String _nombreMedico = _vista.ATBNombre.Text;
                String _apellidoMedico = _vista.ATBApellido.Text;
                String _tratamiento = _vista.ADDTratamiento.SelectedItem.Text;
                DateTime _fecha = DateTime.ParseExact(_vista.ATBFecha.Text, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                CargarListaTratamientos();
                int _duracionTratamiento = (listaTratamiento.ElementAt(_vista.ADDTratamiento.SelectedIndex-1) as Tratamiento).Duracion;

                miTabla.Columns.Add("Fecha", typeof(string));
                miTabla.Columns.Add("Hora Inicio", typeof(string));
                miTabla.Columns.Add("Hora fin", typeof(string));
                miTabla.Columns.Add("Nombre medico", typeof(string));
                miTabla.Columns.Add("Apellido medico", typeof(string));
                miTabla.Columns.Add("Tratamiento", typeof(string));



                    for (int u = 0; u < _citasDisponibles.Length; u++)
                    {

                        if (_citasDisponibles[u] != 0)
                        {
                            miTabla.Rows.Add(String.Format("{0:dd/MM/yyyy}", _fecha), _citasDisponibles[u] + ":OO", (_citasDisponibles[u] + _duracionTratamiento) + ":OO", _nombreMedico, _apellidoMedico, _tratamiento);
                        }
                    }
            }

            return miTabla;
        }




        public String RowCommandGridView(String comando, object indiceFila)
        {
            int index = Convert.ToInt32(indiceFila);
            if (comando == "Agregar")
            {
                GridViewRow row = _vista.GridViewCitasDisponibles.Rows[index];
                
                    String fecha = Convert.ToString(row.Cells[1].Text);
                    String horai = Convert.ToString(row.Cells[2].Text);
                    String horaf = Convert.ToString(row.Cells[3].Text);
                    String nombre = Convert.ToString(row.Cells[4].Text);
                    String apellido = Convert.ToString(row.Cells[5].Text);
                    String tratamiento = Convert.ToString(row.Cells[6].Text);
                    DateTime _fechaDT = DateTime.ParseExact(fecha, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                
                if (_fechaDT >= DateTime.Today)
                {
                    //listaCitas = new List<Entidad>();
                    //listaCitas.CargarListaCitasOpcion();

                    char[] charsToTrim = { '*', ' ', '\'', 'O', ':' };
                    char[] charsToTrim1 = { '*', ' ', '\'', ':' };
                    tratamiento = tratamiento.Trim(charsToTrim1);
                    nombre = nombre.Trim(charsToTrim1);
                    apellido = apellido.Trim(charsToTrim1);
                    horai = horai.Trim(charsToTrim);
                    horaf = horaf.Trim(charsToTrim);

                    return fecha + "&" + horai + "&" + horaf + "&" + nombre + "&" + apellido + "&" + tratamiento;
                }
                else
                {
                    MensajeError(3, "");
                }
            }

            return "";
        }


        #endregion

    }
}
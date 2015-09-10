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
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.LogicaDeNegocios.Fabricas;

namespace Uricao.Presentacion.Presentador.PAgendaCitas
{
    public class PresentadorConsultarCita
    {

        #region Atributos

        private IContratoConsultarCita _vista;
        //private Comando<List<Entidad>> _comando;
        private List<Entidad> listaCitas;
       // private List<Entidad> listaCitasPrueba;


        #endregion


        #region Constructor

        public PresentadorConsultarCita(IContratoConsultarCita _vista)
        {
            this._vista = _vista;
        }

        #endregion

        #region Métodos

        // Metodo que es llamado en el Page Load
        public void InicializarVista()
        {
            _vista.ATBNombre.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            _vista.ATBApellido.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            _vista.ATBFecha.Attributes.Add("onkeypress", "javascript:return ValidNum2(event);");
            _vista.ATBFechaRangoInicio.Attributes.Add("onkeypress", "javascript:return ValidNum2(event);");
            _vista.ATBFechaRangoFin.Attributes.Add("onkeypress", "javascript:return ValidNum2(event);");
            _vista.ATBCiPaciente.Attributes.Add("onkeypress", "javascript:return ValidNum2(event);");
            listaCitas = new List<Entidad>();
         }




        //Método para la selección de una fila del GrindView 
        public String RowCommandGridView(String comando, object indiceFila)
        {

            if (comando == "Consultar")
            {
                listaCitas = new List<Entidad>();
                int index = Convert.ToInt32(indiceFila);
                AccionBotonConsultar();

                GridViewRow row = _vista.GridViewCitasDisponibles.Rows[index];

                String fecha = Convert.ToString(row.Cells[1].Text);
                String horai = Convert.ToString(row.Cells[2].Text);
                String horaf = Convert.ToString(row.Cells[3].Text);
                String nombre = Convert.ToString(row.Cells[4].Text);
                String apellido = Convert.ToString(row.Cells[5].Text);
                String tratamiento = Convert.ToString(row.Cells[6].Text);

                char[] charsToTrim = { '*', ' ', '\'', 'O', ':' };
                char[] charsToTrim1 = { '*', ' ', '\'', ':' };
                tratamiento = tratamiento.Trim(charsToTrim1);
                nombre = nombre.Trim(charsToTrim1);
                apellido = apellido.Trim(charsToTrim1);
                horai = horai.Trim(charsToTrim);
                horaf = horaf.Trim(charsToTrim);
               // String idcita = (listaCitas.ElementAt(index) as Cita)._Id.ToString();
                return fecha + "&" + horai + "&" + horaf + "&" + nombre + "&" + apellido + "&" + tratamiento; // +"&" + idcita;
            }
            return "";
        }

        //Método que muestra diferentes mensajes de error segun el tipo de error.
        public void MensajeError(int valorMensaje, String mensaje)
        {
            if (valorMensaje == 1)
            {
                _vista.MensajeDeTransaccion.Text = "No hay citas con los datos ingresados";
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


        //Método que crea los comandos de consulta dependiendo de la opcion seleccionada.
        public void AccionBotonConsultar()
        {
            _vista.MensajeDeTransaccion.Visible = false;
            if ((_vista.ARBMedico.Checked == true) || (_vista.ARBFecha.Checked == true) || (_vista.ARBFechaRango.Checked == true) || (_vista.ARBCiPaciente.Checked == true))
            {
                if (_vista.ARBMedico.Checked == true)
                {
                    String _nombreMedico = _vista.ATBNombre.Text;
                    String _apellidoMedico = _vista.ATBApellido.Text;
                    ComandoConsultarCitaPorNombreMedico _comando = FabricaComando.CrearComandoConsultarCitaPorNombreMedico(_nombreMedico, _apellidoMedico);
                    listaCitas = _comando.Ejecutar();
                    if (listaCitas == null)
                    {
                        MensajeError(1, "");
                    }
                    else
                    {
                        if (listaCitas.Count == 0)
                        {
                            MensajeError(1, "");
                        }
                    }
                    if (listaCitas != null)
                    {
                        if (listaCitas.Count > 0)
                        {
                            _vista.GridViewCitasDisponibles.PageSize = listaCitas.Count;
                        }
                    }
                    _vista.GridViewCitasDisponibles.DataSource = CargarDataTableCitas();
                    _vista.GridViewCitasDisponibles.DataBind();
                }
                if (_vista.ARBFecha.Checked == true)
                {
                    String _fechaString = _vista.ATBFecha.Text;
                    try
                    {
                        DateTime _fecha = DateTime.ParseExact(_fechaString, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        ComandoConsultarCitaFecha _comando = FabricaComando.CrearComandoConsultarCitaFecha(_fecha.ToString("yyyy-MM-dd"));
                        listaCitas = _comando.Ejecutar();
                        if (listaCitas == null)
                        {
                                MensajeError(1, "");
                        }
                        else
                        {
                            if (listaCitas.Count == 0)
                            {
                                MensajeError(1, "");
                            } 
                        }

                        if (listaCitas != null)
                        {
                            if (listaCitas.Count > 0)
                            {
                                _vista.GridViewCitasDisponibles.PageSize = listaCitas.Count;
                            }
                        }
                        _vista.GridViewCitasDisponibles.DataSource = CargarDataTableCitas();
                        _vista.GridViewCitasDisponibles.DataBind();
                    }
                    catch (FormatException ex)
                    {
                        MensajeError(4, "");
                    }
                }

                if (_vista.ARBFechaRango.Checked == true)
                {
                    String _fechaInicioString = _vista.ATBFechaRangoInicio.Text;
                    String _fechaFinString =_vista.ATBFechaRangoFin.Text;
                    try
                    {
                        DateTime _fechaInicio = DateTime.ParseExact(_fechaInicioString, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime _fechaFin = DateTime.ParseExact(_fechaFinString, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        ComandoConsultarCitaRangoFecha _comando = FabricaComando.CrearComandoConsultarCitaRangoFecha(_fechaInicio.ToString("yyyy-MM-dd"), _fechaFin.ToString("yyyy-MM-dd"));
                        listaCitas = _comando.Ejecutar();
                        if (listaCitas == null)
                        {
                            MensajeError(1, "");
                        }
                        else
                        {
                            if (listaCitas.Count == 0)
                            {
                                MensajeError(1, "");
                            }
                        }

                        if (listaCitas != null)
                        {
                            if (listaCitas.Count > 0)
                            {
                                _vista.GridViewCitasDisponibles.PageSize = listaCitas.Count;
                            }
                        }
                        _vista.GridViewCitasDisponibles.DataSource = CargarDataTableCitas();
                        _vista.GridViewCitasDisponibles.DataBind();
                    }
                    catch (FormatException ex)
                    {
                        MensajeError(4, "");
                    }
                } 
               
                if (_vista.ARBCiPaciente.Checked == true)
                {
                    String _cedulaPaciente = _vista.ATBCiPaciente.Text;
                    ComandoConsultarCitaPorCedulaUsuario _comando = FabricaComando.CrearComandoConsultarCitaPorCedulaUsuario(_cedulaPaciente);
                    listaCitas = _comando.Ejecutar();
                    if (listaCitas == null)
                    {
                        MensajeError(1, "");
                    }
                    else
                    {
                        if (listaCitas.Count == 0)
                        {
                            MensajeError(1, "");
                        }
                    }

                    if (listaCitas != null)
                    {
                        if (listaCitas.Count > 0)
                        {
                            _vista.GridViewCitasDisponibles.PageSize = listaCitas.Count;
                        }
                    }
                    _vista.GridViewCitasDisponibles.DataSource = CargarDataTableCitas();
                    _vista.GridViewCitasDisponibles.DataBind();
                }
            }
        }


        //Método que carga la lista de citas en el GrindView
        public DataTable CargarDataTableCitas()
        {

            DataTable miTabla = new DataTable();
            if (listaCitas != null)
            {
                String _nombreMedico = _vista.ATBNombre.Text;
                String _apellidoMedico = _vista.ATBApellido.Text;
                miTabla.Columns.Add("Fecha", typeof(string));
                miTabla.Columns.Add("Hora Inicio", typeof(string));
                miTabla.Columns.Add("Hora fin", typeof(string));
                miTabla.Columns.Add("Nombre medico", typeof(string));
                miTabla.Columns.Add("Apellido medico", typeof(string));
                miTabla.Columns.Add("Tratamiento", typeof(string));
                foreach (Entidad _Cita in listaCitas)
                {
                    miTabla.Rows.Add(String.Format("{0:dd/MM/yyyy}", (_Cita as Cita)._Fecha),
                        (_Cita as Cita)._HoraInicio + ":OO",
                        ((_Cita as Cita)._HoraFin) + ":OO",
                        (_Cita as Cita)._NombreMedico,
                        (_Cita as Cita)._ApellidoMedico,
                        (_Cita as Cita)._Tratamiento);
                }
            }

            return miTabla;
        }

        #endregion
    }
}
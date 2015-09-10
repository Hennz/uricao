using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using System.Data;
using Uricao.Entidades.EHistoriaPaciente;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.ERolesUsuarios;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Presentador.PHistoriaPaciente
{
    public class PresentadorOdontodiagrama
    {
        private IContratoOdontodiagrama _vista;
        private Entidad historia;
        private List<Entidad> listaSecuencia;
        Entidad secuencia;
        Entidad tratamiento;
        Entidad doctor;

        public PresentadorOdontodiagrama(IContratoOdontodiagrama _vista)
        {
            this._vista = _vista;
            listaSecuencia = new List<Entidad>();
            secuencia = FabricaEntidad.NuevoDetalleSecuencia();
            tratamiento = FabricaEntidad.NuevoTratamiento();
            doctor = FabricaEntidad.NuevaUsuario();
        }

        public void CargarGrid()
        {
            historia = (Entidad)_vista.Sesion["Historia"];
            if (historia != null)
            {
                pintarGrid((historia as HistoriaClinica).NumeroHistoria);
                CargarCombos();
                llenarPiezas();
            }
            else
                _vista.SetLabelFalla("No se han pasado datos");

        }


        public void CargarCombos()
        {
            _vista.Tratamiento.Items.Add("Ninguno");
            _vista.Medico.Items.Add("Ninguno");
            List<Entidad> listaTratamiento = FabricaComando.CrearComandoConsultarTratamiento().Ejecutar();
            List<Entidad> listaDoctores = FabricaComando.CrearComandoConsultarUsuario().Ejecutar();

            if (!(listaTratamiento.Count == 0))
            {
                foreach (Entidad _tratamiento in listaTratamiento)
                {
                    ListItem item = new ListItem();
                    item.Text = (_tratamiento as Tratamiento).Nombre;
                    item.Value = (_tratamiento as Tratamiento).Id.ToString();
                    _vista.Tratamiento.Items.Add(item);

                    /*_vista.Combo.Items.Add((_elCliente as Usuario).Identificacion + " "
                                        + (_elCliente as Usuario).PrimerNombre + " " + (_elCliente as Usuario).PrimerApellido);*/
                }

                foreach (Entidad _doctor in listaDoctores)
                {
                   
                    ListItem item = new ListItem();
                    item.Text ="Doctor"+" "+ (_doctor as Usuario).PrimerNombre + " " + (_doctor as Usuario).SegundoApellido;
                    item.Value = (_doctor as Usuario).IdUsuario.ToString();
                    _vista.Medico.Items.Add(item);

                    /*_vista.Combo.Items.Add((_elCliente as Usuario).Identificacion + " "
                                        + (_elCliente as Usuario).PrimerNombre + " " + (_elCliente as Usuario).PrimerApellido);*/
                }
            }
        }

        public void llenarPiezas()
        {
           
            for (int i = 18; i > 10; i--)
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();

                _vista.Rango1.Items.Add(item);
                _vista.Rango2.Items.Add(item);
                // item.Value = ((_elCliente as Usuario).IdUsuario).ToString();
            }
            for (int i = 21; i < 29; i++)
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();
                _vista.Rango1.Items.Add(item);
                _vista.Rango2.Items.Add(item);
                // item.Value = ((_elCliente as Usuario).IdUsuario).ToString();
            }
            for (int i = 49; i > 40; i--)
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();
                _vista.Rango1.Items.Add(item);
                _vista.Rango2.Items.Add(item);
                // item.Value = ((_elCliente as Usuario).IdUsuario).ToString();
            }
            for (int i = 31; i < 39; i++)
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();
                _vista.Rango1.Items.Add(item);
                _vista.Rango2.Items.Add(item);
                // item.Value = ((_elCliente as Usuario).IdUsuario).ToString();
            }
        }

        public bool SeActivoDesactivo(int idSecuencia, String estado)
        {
            bool flag = FabricaComando.CrearComandoActivarDesactivarSecuencia(idSecuencia, estado).Ejecutar();
            if (flag)
            {
                CargarGrid();
            }
            return flag;
        }

        public void agregar()
        {
           if (validarDatos())
           {
               if (validarFecha())
               {
                   historia = (Entidad)_vista.Sesion["Historia"];

                   int desde = Convert.ToInt32(_vista.Rango1.SelectedValue);
                   int hasta = Convert.ToInt32(_vista.Rango2.SelectedValue);
                   if (hasta == 0)
                       hasta = desde;

                   for (int i = desde; i <= hasta; i++)
                   {
                       Entidad secuencia = FabricaEntidad.NuevoDetalleSecuencia();
                       Entidad tratamiento = FabricaEntidad.NuevoTratamiento();
                       Entidad doctor = FabricaEntidad.NuevaUsuario();

                       (doctor as Usuario).IdUsuario = Convert.ToInt32(_vista.Medico.SelectedItem.Value); ;
                       (tratamiento as Tratamiento).Id = Convert.ToInt16(_vista.Tratamiento.SelectedItem.Value);
                       (secuencia as DetalleSecuencia).Observacion = _vista.Observacion.Text;
                       (secuencia as DetalleSecuencia).Tratamiento = (tratamiento as Tratamiento);
                       (secuencia as DetalleSecuencia).Odontologo = (doctor as Usuario);
                       (secuencia as DetalleSecuencia).Fecha = DateTime.ParseExact(_vista.Fecha.Text, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                       (secuencia as DetalleSecuencia).Pieza = i.ToString();
                       (secuencia as DetalleSecuencia).Diagnostico = _vista.Diagnostico.SelectedItem.Text;
                       (secuencia as DetalleSecuencia).Estado = "activo";


                       listaSecuencia.Add(secuencia);
                   }

                   if (FabricaComando.CrearComandoAgregarSecuencia(listaSecuencia, (historia as HistoriaClinica).NumeroHistoria).Ejecutar())
                   {
                       _vista.SetLabelExito("Secuencia agregada con exito");
                       CargarGrid();
                   }
                   else
                   {
                       _vista.SetLabelFalla("No se pudo agregar");
                   }
               }
               else
               {
                   _vista.SetLabelFalla("Fecha no puede ser menor que la actual");
               }
             }
           else
           {
               _vista.SetLabelFalla("Porfavor indique los campos");
           }   

            
        }

        public bool validarFecha()
        {
            DateTime fecha = new DateTime();
            bool flag = true;
            try
            {
                fecha = DateTime.ParseExact(_vista.Fecha.Text, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (fecha < DateTime.Now.Date)
                {
                    flag = false;
                }
            }
            catch (Exception e)
            {
                _vista.SetLabelFalla("Indique fecha: " + e.Message);
                flag = false;
            }
            return flag;
        }

        public Entidad SeConsultoDetalle(int idSecuencia)
        {
            return FabricaComando.CrearComandoConsultarSecuenciaXid(idSecuencia).Ejecutar();
        }

        public void modificar(int idSecuencia)
        {
            if (validarDatos())
            {
                if (validarFecha())
                {

                    (doctor as Usuario).IdUsuario = 1;
                    (tratamiento as Tratamiento).Id = Convert.ToInt16(_vista.Tratamiento.SelectedItem.Value);
                    (secuencia as DetalleSecuencia).IdSecuencia = idSecuencia;
                    (secuencia as DetalleSecuencia).Observacion = _vista.Observacion.Text;
                    (secuencia as DetalleSecuencia).Tratamiento = (tratamiento as Tratamiento);
                    (secuencia as DetalleSecuencia).Odontologo = (doctor as Usuario);
                    (secuencia as DetalleSecuencia).Fecha = DateTime.ParseExact(_vista.Fecha.Text, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    (secuencia as DetalleSecuencia).Pieza = _vista.Rango1.SelectedItem.Value;
                    (secuencia as DetalleSecuencia).Diagnostico = _vista.Diagnostico.SelectedItem.Text;
                    (secuencia as DetalleSecuencia).Estado = "activo";

                    listaSecuencia.Add(secuencia);

                    if (FabricaComando.CrearComandoModificarSecuencia(listaSecuencia).Ejecutar())
                    {
                        _vista.SetLabelExito("Secuencia Modificada con exito");
                        CargarGrid();
                    }
                    else
                    {
                        _vista.SetLabelFalla("No se pudo modificar");
                    }
                }
                else
                {
                    _vista.SetLabelFalla("Fecha no puede ser menor que la actual");
                }
            }
            else
            {
                _vista.SetLabelFalla("Porfavor indique los campos");
            }   
        }

        public bool validarDatos()
        {
            bool flag = true;
            if (_vista.Fecha.Equals("") || _vista.Observacion.Text.Equals("") || _vista.Rango1.SelectedIndex == 0
               || _vista.Medico.SelectedIndex == 0 || _vista.Tratamiento.SelectedIndex == 0 || _vista.Diagnostico.SelectedIndex == 0)
            {
                flag = false;
            }

            return flag;
        }

        private void pintarGrid(int Historia)
        {
            listaSecuencia = FabricaComando.CrearComandoConsultarSecuencia(Historia).Ejecutar();

            if (!(listaSecuencia.Count == 0))
            {
                //Instanciamos el DataTable para que sea el surtidor de datos para el GridView

                DataTable _tabla = new DataTable();

                //Agregamos la columnas que vamos a setear.


                _tabla.Columns.Add("Secuencia", typeof(string));
                _tabla.Columns.Add("Fecha", typeof(string));
                _tabla.Columns.Add("Pieza", typeof(string));
                _tabla.Columns.Add("Diagnostico", typeof(string));
                _tabla.Columns.Add("Tratamiento", typeof(string));
                _tabla.Columns.Add("Doctor", typeof(string));
                _tabla.Columns.Add("Estado", typeof(string));


                foreach (Entidad secuencia in listaSecuencia)
                {
                    Entidad tratamiento = FabricaEntidad.NuevoTratamiento();
                    tratamiento = FabricaComando.CrearComandoConsultarXIdTratamiento((secuencia as DetalleSecuencia).Tratamiento.Id).Ejecutar();

                    _tabla.Rows.Add((secuencia as DetalleSecuencia).IdSecuencia,
                    (secuencia as DetalleSecuencia).Fecha.ToString("dd-MM-yyyy"),
                     (secuencia as DetalleSecuencia).Pieza,
                     (secuencia as DetalleSecuencia).Diagnostico,
                    (tratamiento as Tratamiento).Nombre,
                     (secuencia as DetalleSecuencia).Odontologo.IdUsuario,
                     (secuencia as DetalleSecuencia).Estado);

                }
                _vista.GridConsultar1.DataSource = _tabla;
                _vista.GridConsultar1.DataBind();
            }
        }

        public Entidad ElTratamiento(String nombre)
        {
            return FabricaComando.CrearomandoConsultarXNombreTratamiento(nombre).Ejecutar()[0];
        }

    }
}
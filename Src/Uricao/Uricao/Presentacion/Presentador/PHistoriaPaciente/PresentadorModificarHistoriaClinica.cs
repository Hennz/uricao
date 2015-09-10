using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using System.Web.UI.WebControls;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EHistoriaPaciente;
using System.Data;

namespace Uricao.Presentacion.Presentador.PHistoriaPaciente
{
    public class PresentadorModificarHistoriaClinica
    {
        private IContratoModificarHistoriaClinica _vista;
        private Entidad historia;
        private List<Entidad> listaClientes;

        public PresentadorModificarHistoriaClinica(IContratoModificarHistoriaClinica _vista)
        {
            this._vista = _vista;
        }

        public void CargarComboClientes()
        {
            _vista.Combo.Items.Add("<--Seleccione-->");
            listaClientes = FabricaComando.CrearComandoConsultarUsuario().Ejecutar();

            if (!(listaClientes.Count == 0))
            {
                foreach (Entidad _elCliente in listaClientes)
                {
                    ListItem item = new ListItem();
                    item.Text = (_elCliente as Usuario).Identificacion + " "
                                                 + (_elCliente as Usuario).PrimerNombre + " " + (_elCliente as Usuario).PrimerApellido;
                    item.Value = ((_elCliente as Usuario).IdUsuario).ToString();
                    _vista.Combo.Items.Add(item);
                }
        
                _vista.Combo.Items.FindByValue((historia as HistoriaClinica).Paciente.IdUsuario.ToString()).Selected = true;
                _vista.Combo.Enabled = false;
             
            }

        }

        public void LlenarDatos()
        {
            historia = (Entidad)_vista.Sesion["Historia"];
            if (historia != null)
            {
                CargarComboClientes();
                _vista.Fecha.Text = (historia as HistoriaClinica).FechaIngreso.ToShortDateString();
                _vista.Observacion.Text = (historia as HistoriaClinica).Observacion;
            }
            else
                _vista.SetLabelFalla("No se han pasado datos");

        }

        public bool Editar()
        {
            bool flag = false;
            if (validarDatos())
            {
                historia = (Entidad)_vista.Sesion["Historia"];
               (historia as HistoriaClinica).FechaIngreso = DateTime.ParseExact(_vista.Fecha.Text, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
               (historia as HistoriaClinica).Observacion = _vista.Observacion.Text;
               if (FabricaComando.CrearComandoModificarHistoriaClinica((historia as HistoriaClinica)).Ejecutar())
               {
                   _vista.SetLabelExito("Se logro modificar");
                   flag = true;
                   pintarGrid();
               }
               else
                   _vista.SetLabelFalla("No se pudo modificar");
            }
            else
                _vista.SetLabelFalla("Debe llenar todos los datos");

            return flag;
        }

        private void pintarGrid()
        {
            List<Entidad> listaHistoriaClinica;
            listaHistoriaClinica = FabricaComando.CrearComandoConsultarHistoriaClinica("", "", "", (historia as HistoriaClinica).NumeroHistoria).Ejecutar();

            if (!(listaHistoriaClinica.Count == 0))
            {
                //Instanciamos el DataTable para que sea el surtidor de datos para el GridView

                DataTable _tabla = new DataTable();

                //Agregamos la columnas que vamos a setear.


                _tabla.Columns.Add("Historia", typeof(string));
                _tabla.Columns.Add("Fecha", typeof(string));
                _tabla.Columns.Add("Observacion", typeof(string));
                _tabla.Columns.Add("Estado", typeof(string));


                foreach (Entidad _historiaClinica in listaHistoriaClinica)

                    _tabla.Rows.Add((_historiaClinica as HistoriaClinica).NumeroHistoria,
                    (_historiaClinica as HistoriaClinica).FechaIngreso.ToString("dd-MM-yyyy"),
                     (_historiaClinica as HistoriaClinica).Observacion,
                    (_historiaClinica as HistoriaClinica).Estado);


                _vista.GridConsultar1.DataSource = _tabla;
                _vista.GridConsultar1.DataBind();
            }
        }
        public bool validarDatos()
        {
            bool flag = true;
            if (_vista.Fecha.Equals("") || _vista.Observacion.Text.Equals("") || _vista.Combo.SelectedIndex == 0)
            {
                flag = false;
            }
            return flag;
        }

    }
    
}
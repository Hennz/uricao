// File: PresentadorAgregarHistoriaClinica.cs Company: La Cruz 
// Copyright (c) 01-08-2013 All Right Reserved
// author: Enrique La Cruz
using System.Collections.Generic;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.ERolesUsuarios;
using System.Web.UI.WebControls;
using System;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EHistoriaPaciente;
using System.Data;


namespace Uricao.Presentacion.Presentador.PHistoriaPaciente
{
    public class PresentadorAgregarHistoriaClinica
    {
        private IContratoAgregarHistoriaClinica _vista;
        //private Comando<List<Entidad>> _comando;
        private Comando<bool> _comando;
        private List<Entidad> listaClientes;
        private List<Entidad> listaHistoriaClinica;

        public PresentadorAgregarHistoriaClinica(IContratoAgregarHistoriaClinica _vista)
        {
            this._vista = _vista;
        }

        public void CargarComboClientes()
        {
            _vista.Combo.Items.Add("<--Seleccione-->");
            listaClientes = FabricaComando.CrearComandoConsultarUsuario().Ejecutar();

            if (!(listaClientes.Count == 0))
            {
                foreach(Entidad _elCliente in listaClientes)
                {
                    ListItem item = new ListItem();
                    item.Text  = (_elCliente as Usuario).Identificacion + " "
                                                 + (_elCliente as Usuario).PrimerNombre + " " + (_elCliente as Usuario).PrimerApellido;
                    item.Value = ((_elCliente as Usuario).IdUsuario).ToString();
                    _vista.Combo.Items.Add(item);

                    /*_vista.Combo.Items.Add((_elCliente as Usuario).Identificacion + " "
                                        + (_elCliente as Usuario).PrimerNombre + " " + (_elCliente as Usuario).PrimerApellido);*/
                }
 
            }
        }

        public bool agregarHistoriaClinica()
        {
            bool flag = false;
            if (validarDatos())
            {
                if (validarFecha())
                {

                    Entidad historiaClinica = FabricaEntidad.NuevaHistoria();
                    Entidad Paciente = FabricaEntidad.NuevoCliente();

                    (Paciente as Cliente).IdUsuario = Convert.ToInt32(_vista.Combo.SelectedItem.Value);
                    (historiaClinica as HistoriaClinica).FechaIngreso = DateTime.ParseExact(_vista.Fecha.Text, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    (historiaClinica as HistoriaClinica).Paciente = (Paciente as Cliente);
                    (historiaClinica as HistoriaClinica).Observacion = _vista.Observacion.Text;
                    (historiaClinica as HistoriaClinica).Estado = "activo";

                    if (validarCliente())
                    {
                        _comando = FabricaComando.CrearComandoAgregarHistoriaClinica(historiaClinica);

                        if (_comando.Ejecutar())
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        _vista.SetLabelFalla("Usuario ya posee una historia");
                    }
                }
                else
                _vista.SetLabelFalla("Fecha no puede ser menor que la actual");

            }
            else
            {
                _vista.SetLabelFalla("Porfavor indique todos los campos");
            }
            return flag;
        }

        public bool Agregar()
        {
            bool flag = false;

            if (agregarHistoriaClinica())
            {
                List<String> respuestas = (List<String>)_vista.Sesion["listaRespuestas"];
                if(respuestas!=null)
                _comando = FabricaComando.CrearComandoAgregarAntecedente(respuestas,0);
                else
                    _vista.SetLabelFalla("Solo se agrego la historia");

                if (_comando.Ejecutar())
                {
                    flag = true;
                    DesabilitarCampos();
                    _vista.SetLabelExito("Se agrego con exito");
                    pintarGrid();
                }
                else
                {
                    _vista.SetLabelFalla("No se pudo agregar");
                }
            }
            return flag;
        }

        public bool validarDatos()
        {
            bool flag = true;
            if(_vista.Fecha.Text.Equals("") || _vista.Observacion.Text.Equals("") || _vista.Combo.SelectedIndex == 0)
            {

                flag = false;
            }

            return flag;
        }

        public bool validarCliente()
        {
            bool flag = false;
             String[] cadena = _vista.Combo.SelectedItem.Text.Split(' ');
             String cedulaValor = cadena[0]; ;
             String nombreValor = cadena[1];
             String apellidoValor = cadena[2];
             int idHistoriaValor = 0;

             listaHistoriaClinica = FabricaComando.CrearComandoConsultarHistoriaClinica(nombreValor, apellidoValor, cedulaValor, idHistoriaValor).Ejecutar();
             if (listaHistoriaClinica.Count == 0)
                 flag = true;

             return flag;
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
                _vista.SetLabelFalla("Campo invalido: " + e.Message);
            }
            return flag;
        }

        private void DesabilitarCampos()
        {
            _vista.Combo.Enabled = false;
            _vista.Fecha.Enabled = false;
            _vista.Observacion.Enabled = false;
        }

        private void pintarGrid()
        {
            List<Entidad> listaHistoriaClinica;
            int pos = FabricaComando.CrearComandoBuscarUltimaHistoria().Ejecutar();
            listaHistoriaClinica = FabricaComando.CrearComandoConsultarHistoriaClinica("", "", "",pos).Ejecutar();

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
    }



}
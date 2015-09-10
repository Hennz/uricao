// File: PresentadorConsultarHistoriaClinica.cs Company: La Cruz 
// Copyright (c) 01-06-2013 All Right Reserved
// author: Enrique La Cruz
using System;
using System.Collections.Generic;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.Entidades.EHistoriaPaciente;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using System.Data;
using Uricao.LogicaDeNegocios.Fabricas;
using System.Text.RegularExpressions;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.Presentacion.Presentador.PHistoriaPaciente
{
    public class PresentadorConsultarHistoriaClinica
    {
              
        #region Atributos.

        private IContratoConsultarHistoriaClinica _vista;
        private List<Entidad> listaHistoriaClinica;
        private string nombreValor;
        private string apellidoValor;
        private string cedulaValor;
        private int idHistoriaValor;

        private bool todos;
        
        #endregion Atributos.

        #region Constructor.

        public PresentadorConsultarHistoriaClinica(IContratoConsultarHistoriaClinica _vista)
        {
            this.nombreValor   = "";
            this.apellidoValor = "";
            this.cedulaValor   = "";
            this.idHistoriaValor = 0;
            this.todos = false;
            this._vista = _vista;
        }

        #endregion Constructor.

        #region Métodos.

        /// <summary>
        /// Dado el id de un proyecto se consultará contra la base de datos, y este procedimiento
        /// imprimira dicho resultado en el formulario ConsultarProyecto.aspx
        /// </summary>
        /// <param name="_idProyecto">id del proyecto seleccionado desde el gridview de ListarProyecto.aspx</param>

        public void PintarConsultaHistoriaClinica()
        {
              //Retornamos el comando desde la fabrica
            if (todos)

                listaHistoriaClinica = FabricaComando.CrearComandoConsultarTodasHistoriaClinica().Ejecutar();
            else
                listaHistoriaClinica = FabricaComando.CrearComandoConsultarHistoriaClinica(nombreValor, apellidoValor, cedulaValor, idHistoriaValor).Ejecutar();

                if (!(listaHistoriaClinica.Count == 0))
                {
                    //Instanciamos el DataTable para que sea el surtidor de datos para el GridView

                    DataTable _tabla = new DataTable();

                    //Agregamos la columnas que vamos a setear.


                    _tabla.Columns.Add("Historia", typeof(string));
                    _tabla.Columns.Add("Nombre", typeof(string));
                    _tabla.Columns.Add("Apellido", typeof(string));
                    _tabla.Columns.Add("Identificacion", typeof(string));
                    _tabla.Columns.Add("Fecha", typeof(string));
                    _tabla.Columns.Add("Estado", typeof(string));


                    foreach (Entidad _historiaClinica in listaHistoriaClinica)

                        _tabla.Rows.Add((_historiaClinica as HistoriaClinica).NumeroHistoria,
                        (_historiaClinica as HistoriaClinica).Paciente.PrimerNombre,
                        (_historiaClinica as HistoriaClinica).Paciente.PrimerApellido,
                        (_historiaClinica as HistoriaClinica).Paciente.Identificacion,
                        (_historiaClinica as HistoriaClinica).FechaIngreso.ToString("dd-MM-yyyy"),
                        (_historiaClinica as HistoriaClinica).Estado);


                    _vista.GridConsultar1.DataSource = _tabla;
                    _vista.GridConsultar1.DataBind();
                }
                else
                {
                    _vista.Link.Visible = true;
                }
                  
        }

        public bool ValidarDatos()
        {
            bool flag = false; 
          
                if (_vista.RadioButtonList.SelectedItem != null)
                {
                    String campo = _vista.TextBox.Text;  
                     int valor = Convert.ToInt32(_vista.RadioButtonList.SelectedValue);

                    if (!campo.Equals(""))
                    {
                        if (campo.Length <= 50)
                        {                         
                            switch (valor)
                            {
                                case 1:
                                    nombreValor = campo;
                                    flag = true;
                                    break;
                                case 2:
                                    apellidoValor = campo;
                                    flag = true;
                                    break;
                                case 3:
                                        try
                                        {
                                            int cedula = Convert.ToInt32(campo);
                                            this.cedulaValor = campo;
                                            flag = true;
                                        }
                                        catch (FormatException)
                                        {
                                            _vista.SetLabelFalla("Introduzca cedula valida");
                                        }
                                    break;
                                case 4:
                                    try
                                    {
                                        this.idHistoriaValor = Convert.ToInt32(campo);
                                        flag = true;
                                    }
                                    catch (FormatException)
                                    {
                                        _vista.SetLabelFalla("Introduzca id valida");
                                    }
                                    break;

                                default: break;
                            }
                        }//fin if 
                        else
                        {
                            _vista.SetLabelFalla("No puede ser mayor de 50 caracteres");
                        }
                    }//fin if campo vacio
                    else if (valor == 5)
                    {

                        todos = true;
                        flag = true;
                    }
                    else
                    {
                        _vista.SetLabelFalla("Introduzca un valor en el campo");
                    }
                }//fin if radio buttons
                else
                {
                    _vista.SetLabelFalla("Debe seleccionar una opcion");
                }//fin else
           
            return flag;
        }

        public bool SeActivoDesactivo(int idHistoria,String estado)
        {
            this.idHistoriaValor = idHistoria;
            bool flag =FabricaComando.CrearComandoActivarDesactivarHistoriaClinica(idHistoriaValor,estado).Ejecutar();
            if (flag)
            {
                int valor = Convert.ToInt32(_vista.RadioButtonList.SelectedValue);
                if (valor == 5)
                   todos = true;
                PintarConsultaHistoriaClinica();
            }
            return flag;
        }

        public Entidad SeConsultoDetalle(int idHistoria)
        {
            this.idHistoriaValor = idHistoria;
            return FabricaComando.CrearComandoConsultarHistoriaClinica(nombreValor, apellidoValor, cedulaValor, idHistoriaValor).Ejecutar()[0];
        }

        public string CedulaValor
        {
            get { return cedulaValor; }
            set { cedulaValor = value; }
        }
        public int IdHistoriaValor
        {
            get { return idHistoriaValor; }
            set { idHistoriaValor = value; }
        }

/*
        public List<Entidad> ListarHistorias()
        {

            _comando = FabricaComando.CrearComandoConsultarHistoriaClinica(nombreValor, apellidoValor, cedulaValor, idHistoriaValor);


            listaHistoriaClinica = _comando.Ejecutar();

            return listaHistoriaClinica;

        }*/

        #endregion Métodos.

    }
}
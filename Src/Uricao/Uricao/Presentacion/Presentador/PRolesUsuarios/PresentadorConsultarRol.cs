using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Presentacion.Contrato.CRolesUsuarios;
using Uricao.Presentacion.Presentador.PRolesUsuarios;
using System.Text.RegularExpressions;
using Uricao.AccesoDeDatos.DAOS;


namespace Uricao.Presentacion.Presentador.PRolesUsuarios
{
    public class PresentadorConsultarRol
    {
        #region Atributos
        private IContratoConsultarRol _vista;
        List<Entidad> miLista = new List<Entidad>();
        DAORol ConsultaBD = new DAORol();

        #endregion Atributos
        
        #region Constructor

        public PresentadorConsultarRol(IContratoConsultarRol _vista)
        {
            this._vista = _vista;
        }
        #endregion Constructor

        #region Metodos

        private bool IsNumeric(string valor)
        {
            try
            {
                double x = Convert.ToDouble(valor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Entidad> CargarGridView()
        {
            //LogicaRol logica = new LogicaRol();
            int opcion = _vista.IDropDownList.SelectedIndex;

            switch (opcion)
            {

                case 0:
                    try
                    {
                        miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", true, opcion);
                        _vista.IGridView.DataSource = miLista;
                        _vista.IGridView.DataBind();
                        _vista.IGridView.Visible = true;

                        if (miLista != null)
                        {
                           _vista.IExito("Consulta Exitosa");
                        }
                        else
                        {
                            _vista.IFalla("No existen roles en la BD; basados en los datos que introdujo");
                            _vista.IGridView.Visible = false;
                        }

                    }
                    catch (ExcepcionRoles e)
                    {
                        throw new ExcepcionRoles("Error General", e);
                        _vista.IGridView.Visible = false;
                    }

                    break;
                case 1:

                    //si los valores ingresados no son numericos muestro mensaje de error.
                    try
                    {
                        //textOpcion.Enabled = true;
                        if (_vista.ITextBox.Text.Length != 0)
                        {
                            if (IsNumeric(_vista.ITextBox.Text))
                            {
                                miLista = ConsultaBD.ConsultarRolParametrizado(int.Parse(_vista.ITextBox.Text), "", "", true, opcion);

                                if ((int.Parse(_vista.ITextBox.Text) <= miLista.Capacity + 2))
                                {
                                    _vista.IGridView.DataSource = miLista;
                                    _vista.IGridView.DataBind();
                                    _vista.IGridView.Visible = true;

                                    _vista.IExito("Consulta Exitosa");
                                }
                            }
                            else
                            {
                                _vista.IFalla("Error: Verifique el valor introducido: Debe introducir unicamente numeros");
                                _vista.IGridView.Visible = false;
                            }
                        }
                        else
                            _vista.IFalla("Error: El Campo de texto no debe estar vacio.");
                    }
                    catch (ExcepcionRoles)
                    {
                        _vista.IFalla("Valor introducido no es valido");
                        _vista.IGridView.Visible = false;
                    }
                    catch (NullReferenceException)
                    {
                        _vista.IFalla("El valor introducido no corresponde a ningun ID de Roles en la BD");
                        _vista.IGridView.Visible = false;
                    }
                    break;
                case 2:
                    try
                    {
                        //textOpcion.Enabled = true;
                        if (_vista.ITextBox.Text.Length != 0)
                        {

                            if (!IsNumeric(_vista.ITextBox.Text))
                            {
                                miLista = ConsultaBD.ConsultarRolParametrizado(0, _vista.ITextBox.Text, "", true, opcion);
                                _vista.IGridView.DataSource = miLista;
                                _vista.IGridView.DataBind();
                                _vista.IGridView.Visible = true;

                                if (miLista != null)
                                {
                                    _vista.IExito("Consulta Exitosa");

                                }
                                else
                                {
                                    _vista.IFalla("No existen roles en la BD; basados en los datos que introdujo");
                                    _vista.IGridView.Visible = false;
                                }
                            }
                            else
                            {
                                _vista.IFalla("Error: Verifique el valor introducido: Debe introducir unicamente letras.");
                                _vista.IGridView.Visible = false;
                            }
                        }else
                            _vista.IFalla("Error: El Campo de texto no debe estar vacio.");
                    }
                    catch (NullReferenceException)
                    {
                        _vista.IFalla("El valor introducido no corresponde a ningun NombreRol de la BD");
                        _vista.IGridView.Visible = false;
                    }

                    break;
                case 3:
                    try
                    {
                        if (_vista.ITextBox.Text.Length != 0)
                        {
                            if (!IsNumeric(_vista.ITextBox.Text))
                            {

                                miLista = ConsultaBD.ConsultarRolParametrizado(0, "", _vista.ITextBox.Text, true, opcion);
                                _vista.IGridView.DataSource = miLista;
                                _vista.IGridView.DataBind();
                                _vista.IGridView.Visible = true;

                                if (miLista != null)
                                {
                                    _vista.IExito("Consulta Exitosa");
                                }
                                else
                                {
                                    _vista.IFalla("No existen roles en la BD; basados en los datos que introdujo");
                                    _vista.IGridView.Visible = false;
                                }
                            }
                            else
                            {
                                _vista.IFalla("Error: Verifique el valor introducido: Debe introducir unicamente letras");
                                _vista.IGridView.Visible = false;
                            }
                        }
                        else
                            _vista.IFalla("Error: El Campo de texto no debe estar vacio.");
                    }
                    catch (NullReferenceException)
                    {
                        _vista.IFalla("El valor introducido no corresponde a ninguna DescripcionRol de la BD");
                        _vista.IGridView.Visible = false;
                    }
                    break;
                case 4:
                    try
                    {
                        if (_vista.ITextBox.Text.Length != 0)
                        {

                        if (!IsNumeric(_vista.ITextBox.Text))
                        {

                            if (_vista.ITextBox.Text.ToUpper().Equals("ACTIVO"))
                            {
                                miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", true, opcion);
                                _vista.IGridView.DataSource = miLista;
                                _vista.IGridView.DataBind();
                                _vista.IGridView.Visible = true;
                            }
                            else
                            {
                                if (_vista.ITextBox.Text.ToUpper().Equals("INACTIVO"))
                                {
                                    miLista = ConsultaBD.ConsultarRolParametrizado(0, "", "", false, opcion);
                                    _vista.IGridView.DataSource = miLista;
                                    _vista.IGridView.DataBind();
                                    _vista.IGridView.Visible = true;
                                }
                                else
                                {
                                    /*miLista = logica.ConsultarRolParametrizado(0, "", "", false, opcion);
                                    _vista.IGridView.DataSource = miLista;
                                    _vista.IGridView.DataBind();
                                    _vista.IGridView.Visible = false;*/

                                    _vista.IFalla("Dato introducido invalido. Debe colocar: activo o inactivo");
                                    _vista.IGridView.Visible = false;
                                }

                            }

                            if (miLista != null)
                            {
                                _vista.IExito("Consulta Exitosa");
                            }
                            else
                            {
                                _vista.IFalla("No existen roles en la BD; basados en los datos que introdujo");
                                _vista.IGridView.Visible = false;
                            }
                        }
                        else
                        {
                            _vista.IFalla("Error: Verifique el valor introducido: Debe introducir unicamente letras");
                            _vista.IGridView.Visible = false;
                        }
                        }
                        else
                            _vista.IFalla("Error: El Campo de texto no debe estar vacio.");
                    }
                    catch (NullReferenceException)
                    {
                        _vista.IFalla("El valor introducido no corresponde a ningun EstadoRol de la BD");
                        _vista.IGridView.Visible = false;
                    }
                    break;

            }
            return miLista;
        } 

        #endregion Metodos

    }
}
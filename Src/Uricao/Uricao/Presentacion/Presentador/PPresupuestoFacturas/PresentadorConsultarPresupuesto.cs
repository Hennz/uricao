using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI.WebControls;

using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.ERolesUsuarios;


// mientras tanto, falta cargar el id del usuario
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;


namespace Uricao.Presentacion.Presentador.PPresupuestoFacturas
{
    public class PresentadorConsultarPresupuesto
    {
        #region Atributos

        private IContratoConsultarPresupuesto _vista;
        private Comando<List<Entidad>> _miComandoPresupuesto;
        private Comando<Entidad> _miComandoPresupuestoEntidad;
        private List<Entidad> _miListaPresupuestos;
        private Entidad _miPresupuesto;
        private Comando<String> _miCedulaPresupuesto;
        private String _cedula;


        #endregion

        #region Constructor

        public PresentadorConsultarPresupuesto (IContratoConsultarPresupuesto vista)
        {
            this._vista = vista;
        }

        #endregion

        #region DropDowns

        /// <summary>
        /// Método que llena combobox con
        /// los presupuestos
        /// </summary>
        public void CargarPresupuestos()
        {
            _miComandoPresupuesto = FabricaComando.CrearComandoConsultarPresupuestosTodos();
            _miListaPresupuestos = _miComandoPresupuesto.Ejecutar();

            for (int i = 0; i < _miListaPresupuestos.Count; i++)
                _vista.DropDownListNumeroPresupuesto.Items.Add((_miListaPresupuestos.ElementAt(i) as Presupuesto).Nro_presupuesto.ToString());
        }

        public void CargarIdUsuario()
        {

            _miComandoPresupuesto = FabricaComando.CrearComandoConsultarUsuario();
            _miListaPresupuestos = _miComandoPresupuesto.Ejecutar();

            for (int i = 0; i < _miListaPresupuestos.Count; i++)
                _vista.DropDownListCedula.Items.Add((_miListaPresupuestos.ElementAt(i) as Usuario).Identificacion + "  " + (_miListaPresupuestos.ElementAt(i) as Usuario).PrimerNombre
                + (_miListaPresupuestos.ElementAt(i) as Usuario).SegundoNombre + (_miListaPresupuestos.ElementAt(i) as Usuario).PrimerApellido + (_miListaPresupuestos.ElementAt(i) as Usuario).SegundoApellido);
        }

        #endregion

        #region Métodos

        /// <summary>
        /// valida que una fecha sea mayor o igual a otra
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public bool ValidarFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            int intervaloFechasValidadas = (fechaInicio.Date.CompareTo(fechaFin.Date));
            return (intervaloFechasValidadas <= 0);
        }

        public void LlenarGridViewListadoPresupuestosTodos()
        {
            _miComandoPresupuesto = FabricaComando.CrearComandoConsultarPresupuestosTodos();
            _miListaPresupuestos = _miComandoPresupuesto.Ejecutar();

            if (_miListaPresupuestos != null)
            {
                _vista.GridViewPresupuesto.DataSource = cargarTabla(_miListaPresupuestos);
                _vista.GridViewPresupuesto.DataBind();

            }
        }

        public void LlenarGridViewListadoPresupuestosFechas(String fechaInicio, String fechaFin)
        {
            _miComandoPresupuesto = FabricaComando.CrearComandoConsultarPresupuestosRangoFechas(fechaInicio,fechaFin);
            _miListaPresupuestos = _miComandoPresupuesto.Ejecutar();

            if (_miListaPresupuestos != null)
            {
                _vista.GridViewPresupuesto.DataSource = cargarTabla(_miListaPresupuestos);
                _vista.GridViewPresupuesto.DataBind();
            }
        }

        public void LlenarGridViewListadoPresupuestosPorNumero(int numeroPresupuesto)
        {
            _miComandoPresupuestoEntidad = FabricaComando.CrearComandoConsultarPresupuestoNumero(numeroPresupuesto);
            _miPresupuesto = _miComandoPresupuestoEntidad.Ejecutar();

            if (_miPresupuesto != null)
            {
                _miListaPresupuestos = new List<Entidad>();
                _miListaPresupuestos.Add(_miPresupuesto);

                _vista.GridViewPresupuesto.DataSource = cargarTabla(_miListaPresupuestos);
                _vista.GridViewPresupuesto.DataBind();
            }
        }

        public void LlenarGridViewListadoPresupuestosPorCedula(String numeroCedula)
        {
            char espacio = ' ';
            string[] cedula = numeroCedula.Split(espacio);
            _miComandoPresupuestoEntidad = FabricaComando.CrearComandoConsultarPresupuestoXCI(cedula[0]);
            _miPresupuesto = _miComandoPresupuestoEntidad.Ejecutar();

            if (_miPresupuesto != null)
            {
                _miListaPresupuestos = new List<Entidad>();
                _miListaPresupuestos.Add(_miPresupuesto);

                _vista.GridViewPresupuesto.DataSource = cargarTabla(_miListaPresupuestos);
                _vista.GridViewPresupuesto.DataBind();
            }
        }

        public void LlenarGridViewVacio()
        {
            _vista.GridViewPresupuesto.DataSource = cargarTablaVacia();
            _vista.GridViewPresupuesto.DataBind();
        }

        /// <summary>
        /// Método cargar tabla de las busquedas
        /// </summary>
        /// <param name="miLista"></param>
        /// <returns></returns>
        public DataTable cargarTabla(List<Entidad> miLista)
        {
            DataTable miTabla = new DataTable();
            miTabla.Columns.Add("Cedula Paciente", typeof(string));
            miTabla.Columns.Add("Numero Presupuesto", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));

            foreach (Presupuesto cuenta in miLista)
            {
                _miCedulaPresupuesto = FabricaComando.CrearComandoConsultarCedulaPresupuesto(cuenta.Nro_presupuesto);
                _cedula = _miCedulaPresupuesto.Ejecutar();

                miTabla.Rows.Add(_cedula, cuenta.Nro_presupuesto, String.Format("{0:dd/MM/yyyy}", cuenta.Fecha_emision));
            }

            return miTabla;
        }

        /// <summary>
        /// Método cargar tabla de las busquedas
        /// al inicio vacia o cuando se seleccione
        /// otro radio button para que los viejos
        /// datos se borren
        /// </summary>
        /// <param name="miLista"></param>
        /// <returns></returns>
        public DataTable cargarTablaVacia()
        {
            DataTable miTabla = new DataTable();
            miTabla.Columns.Add("Cedula Paciente", typeof(string));
            miTabla.Columns.Add("Numero Presupuesto", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Rows.Add("----", "----", "----");

            return miTabla;
        }

        #endregion

        #region Métodos Página

        public void PageLoadCamposVacios(object sender, EventArgs e)
        {
            _vista.ATRangoInicio.Enabled = false;
            _vista.ATRangoFinal.Enabled = false;
            _vista.ATRangoInicio.Text = "";
            _vista.ATRangoFinal.Text = "";
            _vista.DropDownListNumeroPresupuesto.Enabled = false;
            _vista.DropDownListCedula.Enabled = false;
        }

        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (_vista.ARDTodos.Checked == true)
                {
                    //Se selecciono realizar busqueda por todos los parámetros

                    LlenarGridViewListadoPresupuestosTodos();
                }

                else if (_vista.ARDFechas.Checked == true)
                {
                    //Se selecciono solo fechas
                    string fechaInicio;
                    string fechaFin;
                    fechaInicio = _vista.ATRangoInicio.Text;
                    fechaFin = _vista.ATRangoFinal.Text;

                    if (ValidarFechas(Convert.ToDateTime(fechaInicio).Date, Convert.ToDateTime(fechaFin).Date) == true)
                        LlenarGridViewListadoPresupuestosFechas(fechaInicio, fechaFin);

                }

                else if ((_vista.ARDCi.Checked == true))
                {
                    ////Se selecciono cédula de identidad

                    CargarIdUsuario();
                    String numeroCedula = _vista.DropDownListCedula.SelectedValue.ToString();

                    LlenarGridViewListadoPresupuestosPorCedula(numeroCedula);
                }

                else if ((_vista.ARDNumero.Checked == true))
                {
                    ////Se selecciono número de presupuesto
                    CargarPresupuestos();

                    int numeroPresupuesto = Convert.ToInt32(_vista.DropDownListNumeroPresupuesto.SelectedValue.ToString());
                    LlenarGridViewListadoPresupuestosPorNumero(numeroPresupuesto);
                }
            }
            catch (Exception ee)
            {

            }
        }

        public void Boton_Aceptar()
        {
            try
            {
                if (_vista.ARDTodos.Checked == true)
                {
                    //Se selecciono realizar busqueda por todos los parámetros

                    LlenarGridViewListadoPresupuestosTodos();
                }

                else if ((_vista.ARDFechas.Checked == true) && (_vista.ATRangoInicio.Text.Equals("") == false) && (_vista.ATRangoFinal.Text.Equals("") == false))
                {
                    //Se selecciono solo fechas
                    string fechaInicio;
                    string fechaFin;
                    fechaInicio = _vista.ATRangoInicio.Text;
                    fechaFin = _vista.ATRangoFinal.Text;

                    if (ValidarFechas(Convert.ToDateTime(fechaInicio).Date, Convert.ToDateTime(fechaFin).Date) == true)
                        LlenarGridViewListadoPresupuestosFechas(fechaInicio, fechaFin);

                }
                else if ((_vista.ARDCi.Checked == true) && (_vista.DropDownListCedula.SelectedValue != "0"))
                {
                    ////Se selecciono número de presupuesto
                    CargarIdUsuario();
                    String numeroCedula = _vista.DropDownListCedula.SelectedValue.ToString();

                    LlenarGridViewListadoPresupuestosPorCedula(numeroCedula);

                }
                else if ((_vista.ARDNumero.Checked == true) && (_vista.DropDownListNumeroPresupuesto.SelectedValue != "0"))
                {
                    ////Se selecciono número de presupuesto
                    CargarPresupuestos();

                    int numeroPresupuesto = Convert.ToInt32(_vista.DropDownListNumeroPresupuesto.SelectedValue.ToString());
                    LlenarGridViewListadoPresupuestosPorNumero(numeroPresupuesto);
                }
            }
            catch (Exception ee)
            {

            }
        }

        public void PresupuestosRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                _vista.Sesion["presupuesto"] = _miListaPresupuestos[Convert.ToInt32(e.CommandArgument.ToString())];
                _vista.Redireccionar("ConsultarPresupuestoEspecifico.aspx");
            }
            catch
            {

            }
        }

        public void PresupuestoPageChaging(object sender, GridViewPageEventArgs e)
        {
            _vista.GridViewPresupuesto.PageIndex = e.NewPageIndex;
            _vista.GridViewPresupuesto.DataBind();
        }

        public void ARDTodosSeleccionado()
        {
            _vista.ATRangoInicio.Enabled = false;
            _vista.ATRangoFinal.Enabled = false;
            _vista.ATRangoInicio.Text = "";
            _vista.ATRangoFinal.Text = "";
            _vista.DropDownListNumeroPresupuesto.Enabled = false;
            _vista.DropDownListCedula.Enabled = false;
        }

        public void ARDNumeroSeleccionado()
        {
            _vista.ATRangoInicio.Enabled = false;
            _vista.ATRangoFinal.Enabled = false;
            _vista.ATRangoInicio.Text = "";
            _vista.ATRangoFinal.Text = "";
            _vista.DropDownListCedula.Enabled = false;
            _vista.DropDownListNumeroPresupuesto.Enabled = true;
            CargarPresupuestos();
            LlenarGridViewVacio();
        }

        public void ARDCiSeleccionado()
        {
            _vista.ATRangoInicio.Enabled = false;
            _vista.ATRangoFinal.Enabled = false;
            _vista.DropDownListNumeroPresupuesto.Enabled = false;
            _vista.DropDownListCedula.Enabled = true;
            _vista.ATRangoInicio.Text = "";
            _vista.ATRangoFinal.Text = "";
            CargarIdUsuario();
            LlenarGridViewVacio();
        }

        public void ARDFechasSeleccionado()
        {
            _vista.ATRangoInicio.Enabled = true;
            _vista.ATRangoFinal.Enabled = true;
            _vista.DropDownListNumeroPresupuesto.Enabled = false;
            _vista.DropDownListCedula.Enabled = false;
            LlenarGridViewVacio();
        }

        #endregion
    }
}
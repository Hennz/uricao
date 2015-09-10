using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.SessionState;

using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;

using Uricao.LogicaDeNegocios.Fabricas;

using Uricao.LogicaDeNegocios.Comandos;


namespace Uricao.Presentacion.Presentador.PPresupuestoFacturas
{
    public class PresentadorConsultarFactura
    {
        #region Atributos

        private IContratoConsultarFactura _vista;

        private Comando<List<Entidad>> _miComandoFactura;
        private Comando<Entidad> _miComandoFacturaEntidad;
        private Comando<List<Entidad>> _miComandoUsuario;
        private Comando<String> _miComandoFacturaCedulaUsu;

        //Atributo que contendra la lista de Facturas, a pasar a la siguiente pagina: (por Session)
        private List<Entidad> _miListaFacturas;

        private Entidad _miFactura;
        private List<Entidad> _miListaUsuario;
        
        #endregion

        #region Constructor

        public PresentadorConsultarFactura (IContratoConsultarFactura vista)
        {
            this._vista = vista;
        }

        #endregion


        #region Encapsulacion (Gets, Sets)


        public List<Entidad> MiListaFacturas
        {
            get { return this._miListaFacturas; }
            set { this._miListaFacturas = value; }
        }


        #endregion Encapsulacion (Gets, Sets)


        #region Métodos


        #region Llenado GridView

        public void LlenarGridViewListadoFacturasFechas(string fechaInicio, string fechaFin)
        {

            if (ValidarFechas(Convert.ToDateTime(fechaInicio).Date, Convert.ToDateTime(fechaFin).Date) == true)
            {
                _miComandoFactura = FabricaComando.CrearComandoObtenerListaFacturaFechas(fechaInicio, fechaFin);
                _miListaFacturas = _miComandoFactura.Ejecutar();

                if (_miListaFacturas != null)
                {
                    _vista.GridViewFactura.DataSource = CargarTabla(_miListaFacturas);
                    _vista.GridViewFactura.DataBind();                    
                }
            }
        }


        public void LlenarGridViewListadoFacturasPorCedulaUsuario()
        {

            char espacio = ' ';
            string[] cedula = _vista.DropDownListCedula.SelectedValue.ToString().Split(espacio);

            _miComandoFactura = FabricaComando.CrearComandoObtenerFacturaXCI(cedula[0]);
            _miListaFacturas = _miComandoFactura.Ejecutar();

            if (_miListaFacturas != null)
            {
                _vista.GridViewFactura.DataSource = CargarTabla(_miListaFacturas);
                _vista.GridViewFactura.DataBind();
            }
        }


        public void LlenarGridViewListadoFacturasTodas()
        {            
            _miComandoFactura = FabricaComando.CrearComandoConsultarFacturasTodas();
            _miListaFacturas = _miComandoFactura.Ejecutar();

            if (_miListaFacturas != null)
            {
                _vista.GridViewFactura.DataSource = CargarTabla(_miListaFacturas);
                _vista.GridViewFactura.DataBind();
            }            
        }


        public void LlenarGridViewListadoFacturasNumero(int numeroFactura)
        {
            _miComandoFacturaEntidad = FabricaComando.CrearComandoConsultarFacturasNumero(numeroFactura);

            _miFactura = _miComandoFacturaEntidad.Ejecutar();

            if (_miFactura != null)
            {
                _miListaFacturas = new List<Entidad>();
                _miListaFacturas.Add(_miFactura);

                _vista.GridViewFactura.DataSource = CargarTabla(_miListaFacturas);
                _vista.GridViewFactura.DataBind();
            }
        }


        #endregion Llenado GridView


        #region DropDowns
        /// <summary>
        /// Método que llena combobox con
        /// id FACTURA.
        /// </summary>

        public void CargarFacturas()
        {
            
            _miComandoFactura = FabricaComando.CrearComandoConsultarFacturasTodas();
            _miListaFacturas = _miComandoFactura.Ejecutar();

            for (int i = 0; i < _miListaFacturas.Count; i++)
                _vista.DropDownListNumeroFactura.Items.Add((_miListaFacturas.ElementAt(i) as Factura).Nro_factura.ToString());
                                
        }


        /// <summary>
        /// Método que llena combobox con
        /// id usuario mas el nombre
        /// </summary>
        public void CargarIdUsuario()
        {
            _miComandoUsuario = FabricaComando.CrearComandoConsultarUsuario();
            _miListaUsuario = _miComandoUsuario.Ejecutar();

            for (int i = 0; i <  _miListaUsuario.Count; i++)
                _vista.DropDownListCedula.Items.Add((_miListaUsuario.ElementAt(i) as Usuario).Identificacion + "  " + (_miListaUsuario.ElementAt(i) as Usuario).PrimerNombre
                + (_miListaUsuario.ElementAt(i) as Usuario).SegundoNombre + (_miListaUsuario.ElementAt(i) as Usuario).PrimerApellido + (_miListaUsuario.ElementAt(i) as Usuario).SegundoApellido);
        }


        #endregion


        #region Cargar facturas en la tabla del GridView

        /// <summary>
        /// Método cargar tabla de las busquedas
        /// </summary>
        /// <param name="miLista"></param>
        /// <returns></returns>
        public DataTable CargarTabla(List<Entidad> miLista)
        {
            DataTable miTabla = new DataTable();

            miTabla.Columns.Add("Numero Factura", typeof(string));
            miTabla.Columns.Add("Cedula Paciente", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));

            foreach (Entidad _factura in miLista)
            {
                //Crear el comando que ejecutara la busqueda de la CEDULA DE ID ususario, dado el NUMERO FACTURA:
                _miComandoFacturaCedulaUsu = FabricaComando.CrearComandoConsultarCedulaFactura((_factura as Factura).Nro_factura);

                //Ejecutar el comando y almacenar la cedula de identidad que devuelve:
                String cedulaUsuario = _miComandoFacturaCedulaUsu.Ejecutar();

                miTabla.Rows.Add((_factura as Factura).Nro_factura, cedulaUsuario, String.Format("{0:dd/MM/yyyy}", (_factura as Factura).Fecha_emitida));
            }

            return miTabla;
        }


        #endregion Cargar facturas en la tabla del GridView


        #region Metodos GridViews


        public void GridViewFactura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                _vista.GridViewFactura.PageIndex = e.NewPageIndex;
            }
            catch (Exception ee)
            {
            }
        }


        public void GridViewFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _vista.GridViewFactura.PageIndex = _vista.GridViewFactura.PageIndex + 1;
            }
            catch (Exception ee)
            {
            }
        }


        #endregion Metodos GridViews


        #region Metodos RadioButtons

        public void ARDTodos_CheckedChanged(object sender, EventArgs e)
        {
            _vista.ATRangoInicio.Enabled = false;
            _vista.ATRangoFinal.Enabled = false;
            _vista.DropDownListNumeroFactura.Enabled = false;
            _vista.DropDownListCedula.Enabled = false;
            _vista.DropDownListNumeroFactura.Text = "0";
            _vista.DropDownListCedula.Text = "0";
            _vista.ATRangoInicio.Text = "";
            _vista.ATRangoFinal.Text = "";
        }

        public void ARDNumero_CheckedChanged(object sender, EventArgs e)
        {
            _vista.ATRangoInicio.Enabled = false;
            _vista.ATRangoFinal.Enabled = false;
            _vista.ATRangoInicio.Text = "";
            _vista.ATRangoFinal.Text = "";
            _vista.DropDownListCedula.Enabled = false;
            _vista.DropDownListCedula.Text = "0";
            _vista.DropDownListNumeroFactura.Enabled = true;
        }

        public void ARDCi_CheckedChanged(object sender, EventArgs e)
        {
            _vista.ATRangoInicio.Enabled = false;
            _vista.ATRangoFinal.Enabled = false;
            _vista.DropDownListNumeroFactura.Enabled = false;
            _vista.DropDownListNumeroFactura.Text = "0";
            _vista.DropDownListCedula.Enabled = true;
            _vista.ATRangoInicio.Text = "";
            _vista.ATRangoFinal.Text = "";

        }

        public void ARDFechas_CheckedChanged(object sender, EventArgs e)
        {
            _vista.ATRangoInicio.Enabled = true;
            _vista.ATRangoFinal.Enabled = true;
            _vista.DropDownListNumeroFactura.Enabled = false;
            _vista.DropDownListCedula.Enabled = false;
            _vista.DropDownListCedula.SelectedValue = "0";
            _vista.DropDownListNumeroFactura.Text = "0";
        }

        #endregion Metodos RadioButtons


        #region Metodo Buscar Facturas


        public void ABBotonBuscar_Click(object sender, EventArgs e, bool conValidacion)
        {
            try
            {
                //Este caso cubre la "busqueda con validaciones", se invoca cada vez que se decide buscar (al hacer click sobre el boton "BUSCAR" de la GUI:

                if (conValidacion)
                {
                    if (_vista.ARDTodos.Checked == true)
                    {
                        //Se selecciono realizar busqueda por todos los parámetros:
                        LlenarGridViewListadoFacturasTodas();
                    }

                    else if ((_vista.ARDFechas.Checked == true) && (_vista.ATRangoInicio.Text.Equals("") == false) && (_vista.ATRangoFinal.Text.Equals("") == false))
                    {
                        //Se selecciono solo fechas
                        string fechaInicio;
                        string fechaFin;
                        fechaInicio = _vista.ATRangoInicio.Text;
                        fechaFin = _vista.ATRangoFinal.Text;

                        try
                        {
                            LlenarGridViewListadoFacturasFechas(fechaInicio, fechaFin);
                        }
                        catch (FormatException ex)
                        {
                        }
                    }
                    else if ((_vista.ARDCi.Checked == true) && (_vista.DropDownListCedula.SelectedValue != "0"))
                    {
                        //Se selecciono cédula de identidad
                        //Pintar el gridview de facturas, para este caso (dado el ci usuario):
                        LlenarGridViewListadoFacturasPorCedulaUsuario();

                    }
                    else if ((_vista.ARDNumero.Checked == true) && (_vista.DropDownListNumeroFactura.SelectedValue != "0"))
                    {
                        //Se selecciono número de factura:
                        int numeroFactura = Convert.ToInt32(_vista.DropDownListNumeroFactura.SelectedValue.ToString());
                        //Pintar el gridview de facturas, para este caso (dado el numero factura):
                        LlenarGridViewListadoFacturasNumero(numeroFactura);
                    }

                    //End if (conValidacion)
                }
                else
                {
                    //conValidacion = false:
                    //Este caso cubre la "busqueda sin validaciones", se invoca cada vez que re-carga la pagina en el "PageLoad": para poder volver a cargar los datos y pasarlos a la pagina siguiente (Re-direccionar)

                    if (_vista.ARDTodos.Checked == true)
                    {
                        //Se selecciono realizar busqueda por todos los parámetros:
                        LlenarGridViewListadoFacturasTodas();

                    }
                    else if (_vista.ARDFechas.Checked == true)
                    {
                        //Se selecciono solo fechas
                        string fechaInicio;
                        string fechaFin;
                        fechaInicio = _vista.ATRangoInicio.Text;
                        fechaFin = _vista.ATRangoFinal.Text;

                        try
                        {
                            LlenarGridViewListadoFacturasFechas(fechaInicio, fechaFin);
                        }
                        catch (FormatException ex)
                        {
                        }
                    }
                    else if (_vista.ARDCi.Checked == true)
                    {
                        //Se selecciono cédula de identidad:
                        //Pintar el gridview de facturas, para este caso (dado el ci usuario):
                        LlenarGridViewListadoFacturasPorCedulaUsuario();

                    }

                    else if (_vista.ARDNumero.Checked == true)
                    {
                        //Se selecciono número de presupuesto:
                        int numeroFactura = Convert.ToInt32(_vista.DropDownListNumeroFactura.SelectedValue.ToString());
                        //Pintar el gridview de facturas, para este caso (dado el numero factura):
                        LlenarGridViewListadoFacturasNumero(numeroFactura);
                    }

                }//end else del if (conValidacion)

            }
            catch (Exception ee)
            {
                // mensaje error
            }
        }


        #endregion Metodo Buscar Facturas


        #region Redireccionar a la pagina siguiente y manejo de "Session"

        /// <summary>
        /// Para pasar a la siguiente pagina (Redireccionar); pasando la seleccion del usuario en el GridViewFactura (el objeto (entidad) "Factura" que esta en Sesion)
        /// a esa pagina siguiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RedireccionarAConsultaFactura_Detalle_conListaFacturas_GridViewRowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Pasar la lista de facturas al objeto Session:
            _vista.Sesion["factura"] = _miListaFacturas[Convert.ToInt32(e.CommandArgument.ToString())];
            
            //ENTREGA2 (sin patrones) SE USABA ASI:    Session["factura"] = _presentador.MiListaFacturas[Convert.ToInt32(e.CommandArgument.ToString())];
            _vista.Redireccionar("ConsultaFactura_Detalle.aspx");
            
        }

        #endregion Redireccionar a la pagina siguiente y manejo de "Session"


        #region Validaciones

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
        

        #endregion Validaciones


        #endregion


    }
}
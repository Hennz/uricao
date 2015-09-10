using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EBancos;

namespace Uricao.Presentacion.Presentador.PCuentasPorPagar
{
    public class PresentadorModificarCuentasPorPagar1
    {
        private IContratoModificarCuentasPorPagar1 _vista;
        private Comando<List<Entidad>> _listaComando;
        Entidad miCuentaPorPagarAagregar = FabricaEntidad.CrearCuentaPorPagar();
        private List<Entidad> _milistaCpp;
    
        public PresentadorModificarCuentasPorPagar1(IContratoModificarCuentasPorPagar1 laVista)
        {
            this._vista = laVista;
        }

        public void OnClickModificarCuentaPorPagar()
        {
            //Texto de Error:
            _vista.Exito.Text = "Operacion Realizada Exitosamente";
            _vista.Falla.Text = "Operacion Fallida";
            bool fechasValidas = false;
            bool fechasNoEscritas = true;

            //1- Se recoge la data de cada campo de la gui en el objeto  de cuentas por pagar:
            //Fila 1: Fechas:
            (miCuentaPorPagarAagregar as CuentaPorPagar).FechaEmision = _vista.Algo.Text;
            (miCuentaPorPagarAagregar as CuentaPorPagar).FechaVencimiento = _vista.TextBox1.Text;

            //Fila 2 y 3: dropdownlists:
            //DropDownList3: razonsocial/empresa:
            Proveedor miProveedor = new Proveedor();
            miProveedor.Nombre = _vista.DropDownList2.SelectedItem.Text.ToString();
            //agrego a la lista el proveedor elegido por el usuario (razon social):
            (miCuentaPorPagarAagregar as CuentaPorPagar).ListaProveedor.Add(miProveedor);


            //valida fechaini <= fechafin
            //Si las fechas fueron escritas:
            fechasNoEscritas = ((_vista.Algo.Text == "") && (_vista.TextBox1.Text == ""));

            if (!fechasNoEscritas && (!((_vista.Algo.Text == "") || (_vista.TextBox1.Text == ""))))
            {
                fechasValidas = ValidarFechaInicioMayorOigualQueFechaFin(Convert.ToDateTime((miCuentaPorPagarAagregar as CuentaPorPagar).FechaEmision).Date, Convert.ToDateTime((miCuentaPorPagarAagregar as CuentaPorPagar).FechaVencimiento).Date);
                
            }

            // si escogio solo razon social
            if (fechasNoEscritas && (_vista.DropDownList2.SelectedValue != "0"))
            {
                _vista.Falla.Visible = false;
                _vista.Exito.Visible = true;
                _vista.GridView1.DataSource = cargarTabla();
                _vista.GridView1.DataBind();
            }
            //si escogio  solo fechas
            else if ((!fechasNoEscritas) && (_vista.DropDownList2.SelectedItem.Value == "0"))
            {
                //Validar el rango de fechas:
                if (fechasValidas)
                {
                    //fechas correctas: dibujar el gridview.
                    _vista.Falla.Visible = false;
                    _vista.Exito.Visible = true;
                    _vista.GridView1.DataSource = cargarTablaFechas();
                    _vista.GridView1.DataBind();

                }
                else
                {
                    _vista.Exito.Visible = false;
                    //fechaFinal > fechaInicial
                    _vista.Falla.Text = "Operacion Fallida: Fecha de Emisión es mayor que la Fecha de Vencimiento.";
                    _vista.Falla.Visible = true;
                }
            }
            // si escogio fechas y razon social
            else if ((!fechasNoEscritas) && (_vista.DropDownList2.SelectedItem.Value != "0"))
            {

                //Validar el rango de fechas:
                if (fechasValidas)
                {

                    _vista.Falla.Visible = false;
                    _vista.Exito.Visible = true;
                    //fechas correctas: dibujar el gridview.
                    _vista.GridView1.DataSource = cargarTablaFechasProveedor();
                    _vista.GridView1.DataBind();

                }
                else
                {
                    _vista.Exito.Visible = true;
                    //fechaFinal > fechaInicial
                    _vista.Falla.Text = "Operacion Fallida: Fecha de Emisión es mayor que la Fecha de Vencimiento.";
                    _vista.Falla.Visible = true;
                }

            }
            //si no  llena los campos de fecha
            else if ((_vista.DropDownList2.SelectedValue != "0") && ((_vista.Algo.Text != "") && (_vista.TextBox1.Text == "")) || (_vista.Algo.Text == "") && (_vista.TextBox1.Text != ""))
            {
                _vista.Exito.Visible = false;
                _vista.Falla.Text = "Operacion Fallida: Parámetros de busqueda incompletos";
                _vista.Falla.Visible = true;
            }
            else if ((_vista.DropDownList2.SelectedValue == "0") && (_vista.Algo.Text == "") && (_vista.TextBox1.Text == ""))
            {
                _vista.Exito.Visible = false;
                _vista.Falla.Text = "Operacion Fallida: Parámetros de busqueda incompletos";
                _vista.Falla.Visible = true;
            }
            else
            {
                _vista.Exito.Visible = false;
                _vista.Falla.Text = "Operacion Fallida: Parámetros de busqueda incompletos";
                _vista.Falla.Visible = true;

            }
        
        }

         public DataTable cargarTabla()
        {
            DataTable miTabla = new DataTable();
            String _cliente = _vista.DropDownList2.SelectedItem.Text.ToString();
           // List<CuentaPorPagar> miLista = new DAOCuentasPorPagar().MostrarListaCuentasPorPagar(_cliente);
            _listaComando = FabricaComando.CrearComandoMostrarListaCuentasPorPagar(_cliente);
            _milistaCpp = _listaComando.Ejecutar();
            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));



            foreach (CuentaPorPagar cuenta in _milistaCpp)
            {

                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.MontoActualDeuda);
            }

            return miTabla;
        }

       

        public bool ValidarFechaInicioMayorOigualQueFechaFin(DateTime fechaInicio, DateTime fechaFin)
        {
            int intervaloFechasValidadas = (fechaInicio.Date.CompareTo(fechaFin.Date));
            //fechaInicio.Date.Equals(fechaFin.Date) && 
            return (intervaloFechasValidadas <= 0);
        }

        public DataTable cargarTablaFechasProveedor()
        {
            DataTable miTabla = new DataTable();
            String _razonSocial = _vista.DropDownList2.SelectedItem.Text.ToString();
            string _FechaInicio = _vista.Algo.Text;
            string _FechaFin = _vista.TextBox1.Text;
            //List<CuentaPorPagar> miLista = new DAOCuentasPorPagar().MostarCuentasPorPagarFechasProveedor(_razonSocial,_FechaInicio,_FechaFin);
            _listaComando = FabricaComando.CrearComandoMostarCuentasPorPagarFechasProveedor(_razonSocial, _FechaInicio, _FechaFin);
            _milistaCpp = _listaComando.Ejecutar();
            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));
           // miTabla.Columns.Add("Razon Social", typeof(string));



            foreach (CuentaPorPagar cuenta in _milistaCpp)
            {

                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.MontoActualDeuda) ;
            }

            return miTabla;
        }
        public DataTable cargarTablaFechas()
        {
            DataTable miTabla = new DataTable();
            string _FechaInicio = _vista.Algo.Text;
            string _FechaFin = _vista.TextBox1.Text;
            
            //List<Entidad> miLista = FabricaComando.CrearComandoConsultarEntreFechas(_FechaInicio, _FechaFin);
            _listaComando = FabricaComando.CrearComandoConsultarEntreFechas(_FechaInicio, _FechaFin);
            _milistaCpp = _listaComando.Ejecutar();
            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));
            miTabla.Columns.Add("Razon Social", typeof(string));



            foreach (CuentaPorPagar cuenta in _milistaCpp)
            {

                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.MontoActualDeuda, cuenta.ListaProveedor.ElementAt(0).Nombre);
            }

            return miTabla;
        }
        public void CargarRazonSocial()
        {
            Entidad proveedor = FabricaEntidad.NuevoProveedor();
            // _listaComando = FabricaComando.CrearComandoConsultarTodosProveedores();
            //_milistaCpp = _listaComando.Ejecutar();
            List<Entidad> listaProveedores = FabricaComando.CrearComandoConsultarTodosProveedores().Ejecutar();
            //LogicaProveedor miProveedor = new LogicaProveedor();
            //listaProveedores = miProveedor.ObtenerProveedores();
            //List<Proveedor> _milistaProv = (_milistaCpp as List<Proveedor>);

            for (int i = 0; i < listaProveedores.Count; i++)
            {
                proveedor = listaProveedores[i];
                _vista.DropDownList2.Items.Add((proveedor as Proveedor).Nombre.ToString());
            }
        }
        public void PageLoad()
        {

            _vista.Falla.Visible = false;
            _vista.Exito.Visible = false;
           // CargarRazonSocial();
        }

        public void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = _vista.GridView1.Rows[index];
            String codigo = Convert.ToString(row.Cells[1].Text);
            String fechaE = String.Format("{0:yyyy/MM/dd}", Convert.ToString(row.Cells[2].Text));
            String monto = Convert.ToString(row.Cells[3].Text);
            String proveedor = Convert.ToString(_vista.DropDownList2.SelectedValue.ToString());
            if (_vista.DropDownList2.SelectedValue == "0")
            {
                proveedor = Convert.ToString(row.Cells[4].Text);
            }
            _vista.Redireccionar("ModificarCuentasPorPagar2.aspx?codigo=" + codigo +
              "&fechaE=" + fechaE + "&monto=" + monto + "&Proveedor=" + proveedor);

            
            }

        }
    }

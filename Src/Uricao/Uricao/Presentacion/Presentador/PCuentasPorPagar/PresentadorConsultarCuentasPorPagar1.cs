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

namespace Uricao.Presentacion.Presentador.PCuentasPorPagar
{
    public class PresentadorConsultarCuentasPorPagar1
    {
        private IContratoConsultarCuentasPorPagar1 _vista;
        private Comando<List<Entidad>> _listaComando;
        private List<Entidad> _milistaCpp;

        public PresentadorConsultarCuentasPorPagar1(IContratoConsultarCuentasPorPagar1 laVista)
        {
            this._vista = laVista;
        }


         #region Métodos
        public void OnClickConsultarCuentaPorPagar()
        {
            // LogicaCuentaPorPagar miLogicaCuentaPorPagar = new LogicaCuentaPorPagar();

             bool fechasValidas = false;
             bool fechasNoEscritas = true;
             Entidad miCuentaPorPagar = Entidades.FabricasEntidad.FabricaEntidad.CrearCuentaPorPagar();
             (miCuentaPorPagar as CuentaPorPagar).FechaEmision = _vista.Fechai.Text;
             (miCuentaPorPagar as CuentaPorPagar).FechaVencimiento = _vista.Fechaf.Text;

             //valida fechaini <= fechafin
             //Si las fechas fueron escritas:
             fechasNoEscritas = ((_vista.Fechai.Text == "") && (_vista.Fechaf.Text == ""));

             if (!fechasNoEscritas && (!((_vista.Fechai.Text == "") || (_vista.Fechai.Text == ""))))
             {
                 fechasValidas = ValidarFechaInicioMayorOigualQueFechaFin(Convert.ToDateTime((miCuentaPorPagar as CuentaPorPagar).FechaEmision).Date, Convert.ToDateTime((miCuentaPorPagar as CuentaPorPagar).FechaVencimiento).Date);

             }

             //Validaciones FINALES DE INTEGRIDAD DE LOS DATOS (Justo antes de insertar)
             //[//0.1- Validar: FECHA1 <= FECHA2:] + decision si es contra proveedor:

             if (fechasNoEscritas && (_vista.RazonSocial.SelectedValue != "0"))
             {
                 //solo proveedor
                 //listaCuentasPorPagar = miLogicaCuentaPorPagar.MostrarListaCuentasPorPagar(_vista.RazonSocial.SelectedValue.ToString());
                 //listaCuentasPorPagar = miLogicaCuentaPorPagar.AbonarObtenerCuentasPorPagarProveedor(razonSocial.SelectedValue.ToString());
                 _listaComando = FabricaComando.CrearComandoMostrarListaCuentasPorPagar(_vista.RazonSocial.SelectedValue.ToString());
                 _milistaCpp = _listaComando.Ejecutar();
                 _vista.GridView1.DataSource = cargarTabla(_milistaCpp);
                 _vista.GridView1.DataBind();
             }
             else if ((!fechasNoEscritas) && (_vista.RazonSocial.SelectedItem.Value == "0"))
             {
                 //solo por fechas

                 //Validar el rango de fechas:
                 if (fechasValidas)
                 {
                     //fechas correctas: dibujar el gridview.
                     _vista.Falla.Visible = false;
                     _vista.Exito.Visible = true;

                   // listaCuentasPorPagar = miLogicaCuentaPorPagar.ListaCuentasPorPagarEntreFechas(_vista.Fechai.Text, _vista.Fechaf.Text);
                    //_vista.GridView1.DataSource = cargarTablaFechas(listaCuentasPorPagar);

                     _listaComando = FabricaComando.CrearComandoListaCuentasPorPagarEntreFechas(_vista.Fechai.Text, _vista.Fechaf.Text);
                     _milistaCpp = _listaComando.Ejecutar();
                     _vista.GridView1.DataSource = cargarTablaFechas(_milistaCpp);
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
             else if ((_vista.RazonSocial.SelectedValue != "0") && (!fechasNoEscritas))
             {

                 //Validar el rango de fechas:
                 if (fechasValidas)
                 {

                     _vista.Falla.Visible = false;
                     _vista.Exito.Visible = true;

                     //todos los parametros
                   //  listaCuentasPorPagar = miLogicaCuentaPorPagar.MostarCuentasPorPagarFechasProveedor(_vista.RazonSocial.SelectedValue.ToString(), _vista.Fechai.Text, _vista.Fechaf.Text);
                    // _vista.GridView1.DataSource = cargarTablaTodosLosParametros(listaCuentasPorPagar);
                     _listaComando = FabricaComando.CrearComandoMostarCuentasPorPagarFechasProveedor(_vista.RazonSocial.SelectedValue.ToString(), _vista.Fechai.Text, _vista.Fechaf.Text);
                     _milistaCpp = _listaComando.Ejecutar();
                     _vista.GridView1.DataSource = cargarTablaTodosLosParametros(_milistaCpp);
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
             else if ((_vista.RazonSocial.SelectedValue != "0") && ((_vista.Fechai.Text != "") && (_vista.Fechaf.Text == "")) || (_vista.Fechai.Text == "") && (_vista.Fechaf.Text != ""))
             {
                 //proveedor y fecha inicio
                 _vista.Falla.Text = "Operacion Fallida, parámetros de busqueda incompletos";
                 _vista.Falla.Visible = true;
             }
             else if ((_vista.RazonSocial.SelectedValue == "0") && (_vista.Fechai.Text == "") && (_vista.Fechaf.Text == ""))
             {
                 //proveedory fecha fin
                 _vista.Falla.Text = "Operacion Fallida: Parámetros de busqueda incompletos";
                 _vista.Falla.Visible = true;
             }
             else if ((_vista.RazonSocial.SelectedValue == "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text == ""))
             {
                 //solo fecha inicio
                 _vista.Falla.Text = "Operacion Fallida: Parámetros de busqueda incompletos";
                 _vista.Falla.Visible = true;
             }
             else if ((_vista.RazonSocial.SelectedValue == "0") && (_vista.Fechai.Text == "") && (_vista.Fechaf.Text != ""))
             {
                 //solo fecha fin
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


        public void GridView1_RowCommandConsultarCuentaPorPagar(Object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = _vista.GridView1.Rows[index];
            String cuentaCodigo = Convert.ToString(row.Cells[1].Text);
            String fechaEmision = Convert.ToString(row.Cells[2].Text);
            String montoDeuda = Convert.ToString(row.Cells[3].Text);
            string proveedor;
            if (_vista.RazonSocial.SelectedValue == "0")
            {
                proveedor = Convert.ToString(row.Cells[4].Text);
                _vista.Redireccionar("ConsultarCuentasPorPagar2.aspx?cuentaCodigo=" + cuentaCodigo +
                  "&fechaEmision=" + fechaEmision + "&montoDeuda=" + montoDeuda + "&proveedor=" + proveedor);
            }
            else
            {
                proveedor = Convert.ToString(_vista.RazonSocial.SelectedValue.ToString());

                _vista.Redireccionar("ConsultarCuentasPorPagar2.aspx?cuentaCodigo=" + cuentaCodigo +
                  "&fechaEmision=" + fechaEmision + "&montoDeuda=" + montoDeuda + "&proveedor=" + proveedor);
            }
        }

        public DataTable cargarTabla(List<Entidad> miLista)
        {
            DataTable miTabla = new DataTable();

            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));

            foreach (CuentaPorPagar cuenta in miLista)
                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.MontoActualDeuda);

            return miTabla;
        }

        public DataTable cargarTablaFechas(List<Entidad> miLista)
        {
            int posicion = 0;
            DataTable miTabla = new DataTable();

            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));
            miTabla.Columns.Add("Razon Social", typeof(string));

            foreach (CuentaPorPagar cuenta in miLista)
            {
                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.MontoActualDeuda, cuenta.ListaProveedor.ElementAt(0).Nombre);
                posicion++;
            }

            return miTabla;
        }

        public DataTable cargarTablaTodosLosParametros(List<Entidad> miLista)
        {
            DataTable miTabla = new DataTable();

            miTabla.Columns.Add("Cuenta Codigo", typeof(string));
            miTabla.Columns.Add("Fecha Emision", typeof(string));
            miTabla.Columns.Add("Monto", typeof(double));
            //miTabla.Columns.Add("Razon Social", typeof(string));

            foreach (CuentaPorPagar cuenta in miLista)
                miTabla.Rows.Add(cuenta.IdCuentaPorPagar, cuenta.FechaEmision, cuenta.MontoActualDeuda);

            return miTabla;
        }

        public bool ValidarFechaInicioMayorOigualQueFechaFin(DateTime fechaInicio, DateTime fechaFin)
        {
            int intervaloFechasValidadas = (fechaInicio.Date.CompareTo(fechaFin.Date));
            //fechaInicio.Date.Equals(fechaFin.Date) && 
            return (intervaloFechasValidadas <= 0);
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
                _vista.RazonSocial.Items.Add((proveedor as Proveedor).Nombre.ToString());
            }
        }
        public void PageLoad()
        {

            _vista.Falla.Visible = false;
            _vista.Exito.Visible = false;
           // CargarRazonSocial();
        }

        public void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if ((_vista.RazonSocial.SelectedValue != "0") && (_vista.Fechai.Text == "") && (_vista.Fechaf.Text == ""))
            {
                //solo proveedor
                _vista.GridView1.PageIndex = e.NewPageIndex;
                _listaComando = FabricaComando.CrearComandoAbonarObtenerCuentasPorPagarProveedor(_vista.RazonSocial.SelectedValue.ToString());
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTabla(_milistaCpp);
                _vista.GridView1.DataBind();
            }
            else if ((_vista.RazonSocial.SelectedValue == "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text != ""))
            {
                //solo por fechas
                _vista.GridView1.PageIndex = e.NewPageIndex;
                _listaComando = FabricaComando.CrearComandoAbonarConsultarCuentasPorPagarFechas(_vista.Fechai.Text, _vista.Fechaf.Text);
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaFechas(_milistaCpp);
                _vista.GridView1.DataBind();
            }
            else if ((_vista.RazonSocial.SelectedValue != "0") && (_vista.Fechai.Text != "") && (_vista.Fechaf.Text != ""))
            {
                //todos los parametros
                _vista.GridView1.PageIndex = e.NewPageIndex;
                _listaComando = FabricaComando.CrearComandoAbonarConsultarCuentasPorPagar(_vista.Fechai.Text, _vista.Fechaf.Text, _vista.RazonSocial.SelectedValue.ToString());
                _milistaCpp = _listaComando.Ejecutar();
                _vista.GridView1.DataSource = cargarTablaTodosLosParametros(_milistaCpp);
                _vista.GridView1.DataBind();
            }

        }

         #endregion

    }
}
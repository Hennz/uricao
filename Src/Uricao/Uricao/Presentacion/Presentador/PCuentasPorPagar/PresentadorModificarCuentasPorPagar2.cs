using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
    public class PresentadorModificarCuentasPorPagar2
    {
         private IContratoModificarCuentasPorPagar2 _vista;
         private Comando<bool> _listaComando;
         private bool _milistaCpp;
         Entidad miCuentaPorPagarAagregar = FabricaEntidad.CrearCuentaPorPagar();
         private Comando<Entidad> _listaComando2;
         private Entidad _milistaCpp2;
         bool fechasValidas = false;
         bool montoValido = false;
         bool modificacionExitosaCPP = false;


         public PresentadorModificarCuentasPorPagar2(IContratoModificarCuentasPorPagar2 laVista)
        {
            this._vista = laVista;
        }

         public void PageLoad2() {
             _vista.Falla.Visible = false;
             _vista.Exito.Visible = false;

             //Buscar segun parametros de la GUI(fechas, etc...) la Cuenta Por Pagar:
             //Esta variable viene desde la BD, desde la PAGINA GUI (LUPA) ANTERIOR:
             //retorno de la sumatoria de abonos para la deuda actual:::::::::::.
             //listaAbono = miLogicaCuentaPorPagar.ObtenerAbonosDeCuentaPorPagar();
             //string codigo = Convert.ToString((Request.QueryString["codigo"] != null) ? Request.QueryString["codigo"] : "");
             string codigo = _vista.Requestconsultar2("codigo");
            // string fechaE = Convert.ToString((Request.QueryString["fechaE"] != null) ? Request.QueryString["fechaE"] : "");
             string fechaE = _vista.Requestconsultar2("fechaE");
             //string monto = Convert.ToString((Request.QueryString["monto"] != null) ? Request.QueryString["monto"] : "");
             string monto = _vista.Requestconsultar2("monto");
            // string proveedor = Convert.ToString((Request.QueryString["proveedor"] != null) ? Request.QueryString["proveedor"] : "");
             string proveedor = _vista.Requestconsultar2("proveedor");

             //Lleno el objeto cuenta por paga para mostrar por pantalla, y poder modificarlo:
             //miCuentaPorPagar = miLogicaCuentaPorPagar.ConsultarCuentaPorPagarBD(codigo);
             _listaComando2 = FabricaComando.CrearComandoConsultarCuentaPorPagar(codigo);
             _milistaCpp2 = _listaComando2.Ejecutar();
             _vista.LabelcuentaCodigo.Text = codigo;
             _vista.TextBox1.Text = monto;
             _vista.FechaEmision.Text = fechaE;

             //Detalle de lacuenta por pagar:
             _vista.TextBox3DetalleDeuda.Text = (miCuentaPorPagarAagregar as CuentaPorPagar).Detalle;

             Int64 IDcuenta = Convert.ToInt64(codigo);

             //carga de los dropdowns:
             //ojo: debo pararme primero en cada dorp en el valor de LA CUENTA POR PAGAR!!!!
             // LabelRazon.Text = proveedor;
             //CargarRazonSocial();

            // _vista.LabelBanco.Text = (miCuentaPorPagarAagregar as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).Banco.NombreBanco;
             //CargarBancosDadoProveedor(proveedor);

            // _vista.LabelCuentaBancaria.Text = (miCuentaPorPagarAagregar as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).NroCuentaBanco;
             //drop de nuero cuebta banco:

             _vista.LabelTipoPago.Text = (miCuentaPorPagarAagregar as CuentaPorPagar).TipoPago;
             _vista.FechaVencimiento.Text = String.Format("{0:yyyy/MM/dd}", Convert.ToDateTime((miCuentaPorPagarAagregar as CuentaPorPagar).FechaVencimiento).Date);

             //SETTEO de los DropDownLists previamente..
             //// dropdownlist de banco
             //if (miCuentaPorPagar.ListaNumeroCuentaBanco.ElementAt(0).Banco.NombreBanco == "Mercantil")
             //{
             //   DropDownListBanco.SelectedIndex = 0;
             //};

             //if (miCuentaPorPagar.ListaNumeroCuentaBanco.ElementAt(0).Banco.NombreBanco == "Banesco")
             //{
             //    DropDownListBanco.SelectedIndex = 1;
             //}
             //if (miCuentaPorPagar.ListaNumeroCuentaBanco.ElementAt(0).Banco.NombreBanco == "Venezuela")
             //{
             //    DropDownListBanco.SelectedIndex = 2;
             //}
             //if (miCuentaPorPagar.ListaNumeroCuentaBanco.ElementAt(0).Banco.NombreBanco == "BBVA")
             //{
             //    DropDownListBanco.SelectedIndex = 3;
             //}
             //if (miCuentaPorPagar.ListaNumeroCuentaBanco.ElementAt(0).Banco.NombreBanco == "Caroni")
             //{
             //    DropDownListBanco.SelectedIndex = 4;
             //}
             //if (miCuentaPorPagar.ListaNumeroCuentaBanco.ElementAt(0).Banco.NombreBanco == "Caribe")
             //{
             //    DropDownListBanco.SelectedIndex = 5;
             //}
         
         
         }
         public void OnClickModificar2CuentaPorPagar() {


             //1- Se recoge la data de cada campo de la gui en el objeto  de cuentas por pagar:
             //id de la cuenta por pagar:
             (miCuentaPorPagarAagregar as CuentaPorPagar).IdCuentaPorPagar = _vista.LabelcuentaCodigo.Text;

             //Convert.ToDateTime(miCuentaPorPagarAagregar.FechaEmision).Date

             //Fila 1: Fechas:
             (miCuentaPorPagarAagregar as CuentaPorPagar).FechaEmision = _vista.FechaEmision.Text;
             (miCuentaPorPagarAagregar as CuentaPorPagar).FechaVencimiento = _vista.FechaVencimiento.Text;

             //Fila 2 y 3: dropdownlists:
             //DropDownList3: razonsocial/empresa:
             Proveedor miProveedor = new Proveedor();
             miProveedor.Nombre = _vista.DropDownListRazon.SelectedItem.Text.ToString();
             //agrego a la lista el proveedor elegido por el usuario (razon social):
             (miCuentaPorPagarAagregar as CuentaPorPagar).ListaProveedor.Add(miProveedor);

             //DropDownList5: numero Cuenta bancaria:
             NumeroCuentaBanco miNumeroCuentaBanco = new NumeroCuentaBanco();
             miNumeroCuentaBanco.NroCuentaBanco = _vista.DropDownListCuentaBancaria.SelectedItem.Text.ToString();
             //agrego a la lista general:
             (miCuentaPorPagarAagregar as CuentaPorPagar).ListaNumeroCuentaBanco.Add(miNumeroCuentaBanco);

             //DropDownList4: banco
             Banco miBanco = new Banco();
             miBanco.NombreBanco = _vista.DropDownListBanco.SelectedItem.Text.ToString();
             //agrego a la lista (banco):
             (miCuentaPorPagarAagregar as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).Banco = miBanco;

             //DropDownList6: tipo de pago.
             (miCuentaPorPagarAagregar as CuentaPorPagar).TipoPago = _vista.DropDownListTipoPago.SelectedItem.Text.ToString();

             //FILA 4: Monto deuda:
             (miCuentaPorPagarAagregar as CuentaPorPagar).MontoInicialDeuda = Convert.ToDouble(_vista.TextBox1.Text);

             //Validaciones FINALES DE INTEGRIDAD DE LOS DATOS (Justo antes de insertar)
             //[//0.2- Validar: (int)monto > 0], [//0.1- Validar: FECHA1 <= FECHA2:] + decision si es contra proveedor:

             //valida fechaini <= fechafin
             fechasValidas = (miCuentaPorPagarAagregar as CuentaPorPagar).ValidarFechaInicioMayorOigualQueFechaFin(Convert.ToDateTime((miCuentaPorPagarAagregar as CuentaPorPagar).FechaEmision).Date, Convert.ToDateTime((miCuentaPorPagarAagregar as CuentaPorPagar).FechaVencimiento).Date);

             //validar monto como un int mayor que cero (el hecho de ser DOUBLE ya fue validado en la GUI con la etiqueta VALIDATOR):
             montoValido = (miCuentaPorPagarAagregar as CuentaPorPagar).ValidarMontoMayorQueCero((miCuentaPorPagarAagregar as CuentaPorPagar).MontoInicialDeuda);


             //Fila 5: detalle.
             (miCuentaPorPagarAagregar as CuentaPorPagar).Detalle = _vista.TextBox3DetalleDeuda.Text;

             string tipoDeudaEmpleado = "nomina";
             string tipoDeudaProveedor = "proveedor";

             //Si es contra empleados (nomina) o proveedores: la deuda
             if (fechasValidas && (miCuentaPorPagarAagregar as CuentaPorPagar).ListaProveedor.ElementAt(0).Nombre.Equals(tipoDeudaEmpleado) && montoValido)
             {
                 //caso: nomina
                 (miCuentaPorPagarAagregar as CuentaPorPagar).TipoDeuda = tipoDeudaEmpleado;
                 //2- Modificar la Cuenta Por Pagar en la BD:
                // modificacionExitosaCPP = miLogicaCuentaPorPagar.ModificarCuentaPorPagarBD((miCuentaPorPagarAagregar as CuentaPorPagar));
                 _listaComando = FabricaComando.CrearComandoModificarCuentaPorPagar(miCuentaPorPagarAagregar);
                 _milistaCpp = _listaComando.Ejecutar();
                 modificacionExitosaCPP=_milistaCpp;

             }
             else if (fechasValidas && !(miCuentaPorPagarAagregar as CuentaPorPagar).ListaProveedor.ElementAt(0).Nombre.Equals(tipoDeudaEmpleado) && montoValido)
             {
                 //caso: proveedor
                 (miCuentaPorPagarAagregar as CuentaPorPagar).TipoDeuda = tipoDeudaProveedor;
                 //2- Modificar la Cuenta Por Pagar en la BD:
                 //modificacionExitosaCPP = miLogicaCuentaPorPagar.ModificarCuentaPorPagarBD((miCuentaPorPagarAagregar as CuentaPorPagar));
                 _listaComando = FabricaComando.CrearComandoModificarCuentaPorPagar(miCuentaPorPagarAagregar);
                 _milistaCpp = _listaComando.Ejecutar();
                 modificacionExitosaCPP=_milistaCpp;
             }
             else
             {
                 //Si las dos fechas son invalidas (Emision mayor que la de vencimiento)
                 if (!fechasValidas)
                 {
                     _vista.Falla.Text = _vista.Falla.Text + ": Fecha de Emisión es mayor que la Fecha de Vencimiento.";
                 }
                 //Si las dos fechas son invalidas (Emision mayor que la de vencimiento)
                 if (!montoValido)
                 {
                     _vista.Falla.Text = _vista.Falla.Text + ": El Monto Total (BsF) debe ser mayor que cero.";
                 }


                 _vista.Falla.Visible = true;
             }


             //3- Terminada la modoificacion, chequea y decir por pantalla si fue un exito o un fracaso:

             _vista.Exito.Text = "Operacion Realizada Exitosamente";
             _vista.Falla.Text = "Operacion Fallida";

             //si fue un fallo:
             if (!modificacionExitosaCPP)
             {
                 _vista.Exito.Visible = false;
                 //Exito.Text = "";
                 //falla.Text = "Operacion Fallida";
                 _vista.Falla.Visible = true;
                 //Validador del Monto:
                 _vista.ValidatorCompareDoubleTypeMonto.Visible = false;
                 //Validador de Fecha Emision: haciendolo invisible
                 _vista.RegularExpressionValidatorFechaEmision.Visible = false;
                 //Validador de Fecha Vencimiento: haciendolo invisible
                 _vista.RegularExpressionValidatorFechaVencimiento.Visible = false;

             }
             else
             {
                 //si fue un exito:
                 _vista.Falla.Visible = false;
                 //Exito.Text = "Operacion Realizada Exitosamente";
                 _vista.Exito.Visible = true;
                 //falla.Text = "";
             }
         
         
         }

         public bool ValidarFechaInicioMayorOigualQueFechaFin(DateTime fechaInicio, DateTime fechaFin)
         {
             int intervaloFechasValidadas = (fechaInicio.Date.CompareTo(fechaFin.Date));
             //fechaInicio.Date.Equals(fechaFin.Date) && 
             return (intervaloFechasValidadas <= 0);
         }

    }
}
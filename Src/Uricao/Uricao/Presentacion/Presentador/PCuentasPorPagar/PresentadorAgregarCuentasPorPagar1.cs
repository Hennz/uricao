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
    public class PresentadorAgregarCuentasPorPagar1
    {
         private IContratoAgregarCuentasPorPagar1 _vista;
         Entidad miCuentaPorPagarAagregar = FabricaEntidad.CrearCuentaPorPagar();
         bool insercionExitosaCPP = false;
         private Comando<bool> _listaComando;
         private bool _milistaCpp;

         public PresentadorAgregarCuentasPorPagar1(IContratoAgregarCuentasPorPagar1 laVista)
        {
            this._vista = laVista;
        }
        #region Métodos
         public void OnClickAgregarCuentaPorPagar()
         {
          
                 //1- Se recoge la data de cada campo de la gui en el objeto  de cuentas por pagar:
                 //Fila 1: Fechas:

                 (miCuentaPorPagarAagregar as CuentaPorPagar).FechaEmision = _vista.TextBox1FechaEmision.Text;
                 (miCuentaPorPagarAagregar as CuentaPorPagar).FechaVencimiento = _vista.TextBox2FechaVencimiento.Text;

                 //FILA 4: Monto deuda:
                 (miCuentaPorPagarAagregar as CuentaPorPagar).MontoInicialDeuda = Convert.ToDouble(_vista.TextBox2Monto.Text);
                 (miCuentaPorPagarAagregar as CuentaPorPagar).MontoActualDeuda = (miCuentaPorPagarAagregar as CuentaPorPagar).MontoInicialDeuda;

                 //Fila 2 y 3: dropdownlists:
                 //DropDownList3: razonsocial/empresa:
                 Proveedor miProveedor = new Proveedor();
                 miProveedor.Nombre = _vista.DropDownList3.SelectedItem.Text.ToString();
                 //agrego a la lista el proveedor elegido por el usuario (razon social):
                 (miCuentaPorPagarAagregar as CuentaPorPagar).ListaProveedor.Add(miProveedor);

                 //DropDownList5: numero Cuenta bancaria:
                 NumeroCuentaBanco miNumeroCuentaBanco = new NumeroCuentaBanco();
                 miNumeroCuentaBanco.NroCuentaBanco = _vista.DropDownList5.SelectedItem.Text.ToString();
                 //agrego a la lista general:
                 (miCuentaPorPagarAagregar as CuentaPorPagar).ListaNumeroCuentaBanco.Add(miNumeroCuentaBanco);

                 //DropDownList4: banco
                 Banco miBanco = new Banco();
                 miBanco.NombreBanco = _vista.DropDownList4.SelectedItem.Text.ToString();
                 //agrego a la lista (banco):
                 (miCuentaPorPagarAagregar as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).Banco = miBanco;

                 //DropDownList6: tipo de pago.
                 (miCuentaPorPagarAagregar as CuentaPorPagar).TipoPago = _vista.DropDownList6.SelectedItem.Text.ToString();


                 //Fila 5: detalle.
                 (miCuentaPorPagarAagregar as CuentaPorPagar).Detalle = _vista.TextBox3DetalleDeuda.Text;

                 //Atributos adicionales a llenar: 
                 //(a) EstatusPP:
                 string estatusPP = "activo";
                 (miCuentaPorPagarAagregar as CuentaPorPagar).Estatus = estatusPP;

                 string tipoDeudaEmpleado = "nomina";
                 string tipoDeudaProveedor = "proveedor";

                 //Texto de Error:
                 _vista.Exito.Text = "Operacion Realizada Exitosamente";
                 _vista.Falla.Text = "Operacion Fallida";

                 //Validaciones FINALES DE INTEGRIDAD DE LOS DATOS (Justo antes de insertar)
                 //[//0.2- Validar: (int)monto > 0], [//0.1- Validar: FECHA1 <= FECHA2:] + decision si es contra proveedor:

                 //valida fechaini <= fechafin
                 bool fechasValidas = ValidarFechaInicioMayorOigualQueFechaFin(Convert.ToDateTime((miCuentaPorPagarAagregar as CuentaPorPagar).FechaEmision).Date, Convert.ToDateTime((miCuentaPorPagarAagregar as CuentaPorPagar).FechaVencimiento).Date);

                 //validar monto como un int mayor que cero (el hecho de ser DOUBLE ya fue validado en la GUI con la etiqueta VALIDATOR):
                 bool montoValido = ValidarMontoMayorQueCero((miCuentaPorPagarAagregar as CuentaPorPagar).MontoInicialDeuda);

                 //Si es contra empleados (nomina) o proveedores: la deuda
                 if (fechasValidas && (miCuentaPorPagarAagregar as CuentaPorPagar).ListaProveedor.ElementAt(0).Nombre.Equals(tipoDeudaEmpleado) && montoValido)
                 {
                     //caso: Nomina
                     (miCuentaPorPagarAagregar as CuentaPorPagar).TipoDeuda = tipoDeudaEmpleado;

                     //2- Insertar la Cuenta Por Pagar en la BD:
                     // aqui insercionExitosaCPP = miLogicaDeCuentaPorPagar.AgregarEnBDunaCuentaPorPagar(miCuentaPorPagarAagregar);
                     _listaComando = FabricaComando.CrearComandoInsertarCuentasPorPagar(miCuentaPorPagarAagregar);
                      _milistaCpp = _listaComando.Ejecutar();
                      insercionExitosaCPP = _milistaCpp;

                      //_vista.GridView1.DataSource = cargarTabla(_milistaCpp);
                      //_vista.GridView1.DataBind();
                 }
                 else if (fechasValidas && !(miCuentaPorPagarAagregar as CuentaPorPagar).ListaProveedor.ElementAt(0).Nombre.Equals(tipoDeudaEmpleado) && montoValido)
                 {
                     //caso: proveedor
                     (miCuentaPorPagarAagregar as CuentaPorPagar).TipoDeuda = tipoDeudaProveedor;
                     //2- Insertar la Cuenta Por Pagar en la BD:
                     //insercionExitosaCPP = miLogicaDeCuentaPorPagar.AgregarEnBDunaCuentaPorPagar(miCuentaPorPagarAagregar);
                     _listaComando = FabricaComando.CrearComandoInsertarCuentasPorPagar(miCuentaPorPagarAagregar);
                     _milistaCpp = _listaComando.Ejecutar();
                     insercionExitosaCPP = _milistaCpp;
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
                     insercionExitosaCPP = false;
                 }


                 //3- Terminada la insercion, chequea y decir por pantalla si fue un exito o un fracaso:

                 //si fue un fallo:
                 if (!insercionExitosaCPP)
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

         /// <summary>
         /// Llenado del Dropdownlist de RAZON SOCIAL.
         /// </summary>
       

         public bool ValidarFechaInicioMayorOigualQueFechaFin(DateTime fechaInicio, DateTime fechaFin)
         {
             int intervaloFechasValidadas = (fechaInicio.Date.CompareTo(fechaFin.Date));
             //fechaInicio.Date.Equals(fechaFin.Date) && 
             return (intervaloFechasValidadas <= 0);
         }
         public bool ValidarMontoMayorQueCero(double abono)
         {
             return (((int)abono) > 0);
         }

         public void PageLoad()
         {

             _vista.Falla.Visible = false;
             _vista.Exito.Visible = false;
             CargarRazonSocial();
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
                 _vista.DropDownList3.Items.Add((proveedor as Proveedor).Nombre.ToString());
             }
         }
        
        #endregion





    }
}
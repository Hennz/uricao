using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Uricao.Entidades.ECuentasPorPagar;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EBancos;
using Uricao.Entidades.EAbonos;

using Uricao.LogicaDeNegocios.Clases.LNCuentasPorPagar;
using Uricao.LogicaDeNegocios.Clases.LNProveedores;
using Uricao.LogicaDeNegocios.Clases.LNBancos;
using System.Drawing;
using Uricao.Presentacion.Presentador.PCuentasPorPagar;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;

namespace Uricao.Presentacion.PaginasWeb.PCuentasPorPagar
{
   
        public partial class ModificarCuentasPorPagar2 : System.Web.UI.Page, IContratoModificarCuentasPorPagar2
        {

         private PresentadorModificarCuentasPorPagar2 _presentador;
         public ModificarCuentasPorPagar2()
        {
            _presentador = new PresentadorModificarCuentasPorPagar2(this);
        }
        //Atributos:
        LogicaCuentaPorPagar miLogicaCuentaPorPagar = new LogicaCuentaPorPagar();
        CuentaPorPagar miCuentaPorPagar = new CuentaPorPagar();
        Abono miAbono = new Abono();

        //Proveedor:
        LogicaProveedor miLogicaProveedor = new LogicaProveedor();
        List<Proveedor> listaProveedor = new List<Proveedor>();
        //Banco:
        LogicaBanco miLogicaBanco = new LogicaBanco();
        List<Banco> listaBanco = new List<Banco>();
        //Cuenta bancaria:
        //LogicaBanco miLogicaBanco = new LogicaBanco();
        List<NumeroCuentaBanco> listaNumeroCuentaBanco = new List<NumeroCuentaBanco>();


        #region Contrato
        public Label LabelcuentaCodigo
        {
            get { return labelcuentaCodigo; }
            set { labelcuentaCodigo = value; }
        }

        public Label LabelRazon
        {
            get { return labelRazon; }
            set { labelRazon = value; }
        }
        public DropDownList DropDownListRazon
        {
            get { return dropDownListRazon; }
            set { dropDownListRazon = value; }
        }

        public Label LabelBanco
        {
            get { return labelBanco; }
            set { labelBanco = value; }
        }

        public DropDownList DropDownListBanco
        {
            get { return dropDownListBanco; }
            set { dropDownListBanco = value; }
        }
        public Label LabelCuentaBancaria
        {
            get { return labelCuentaBancaria; }
            set { labelCuentaBancaria = value; }
        }

        public DropDownList DropDownListCuentaBancaria
        {
            get { return dropDownListCuentaBancaria; }
            set { dropDownListCuentaBancaria = value; }
        }
        public Label LabelTipoPago
        {
            get { return labelTipoPago; }
            set { labelTipoPago = value; }
        }

        public DropDownList DropDownListTipoPago
        {
            get { return dropDownListTipoPago; }
            set { dropDownListTipoPago = value; }
        }

        public TextBox TextBox1
        {
            get { return textBox1; }
            set { textBox1 = value; }
        }

        public TextBox FechaEmision
        {
            get { return fechaEmision; }
            set { fechaEmision = value; }
        }

        public TextBox FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }
        public TextBox TextBox3DetalleDeuda
        {
            get { return textBox3DetalleDeuda; }
            set { textBox3DetalleDeuda = value; }
        }
        public Label Falla
        {
            get { return falla; }
            set { falla = value; }
        }

        public Label Exito
        {
            get { return exito; }
            set { exito = value; }
        }
        public CompareValidator ValidatorCompareDoubleTypeMonto
        {
            get { return validatorCompareDoubleTypeMonto; }
            set { validatorCompareDoubleTypeMonto = value; }
        }

        public RegularExpressionValidator RegularExpressionValidatorFechaVencimiento
        {
            get { return regularExpressionValidatorFechaVen; }
            set { regularExpressionValidatorFechaVen = value; }
        }
        public RegularExpressionValidator RegularExpressionValidatorFechaEmision
        {
            get { return regularExpressionValidatorFechaEmision; }
            set { regularExpressionValidatorFechaEmision = value; }
        }
        public string Requestconsultar2(string _ruta)
        {
            return Convert.ToString((Request.QueryString[(_ruta)] != null) ? Request.QueryString[_ruta] : "");
        }
      
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.PageLoad2();
            
            if (!IsPostBack)
            {
                 _presentador.PageLoad2();
               /* falla.Visible = false;
                Exito.Visible = false;

                //Buscar segun parametros de la GUI(fechas, etc...) la Cuenta Por Pagar:
                //Esta variable viene desde la BD, desde la PAGINA GUI (LUPA) ANTERIOR:
                //retorno de la sumatoria de abonos para la deuda actual:::::::::::.
                //listaAbono = miLogicaCuentaPorPagar.ObtenerAbonosDeCuentaPorPagar();
                string codigo = Convert.ToString((Request.QueryString["codigo"] != null) ? Request.QueryString["codigo"] : "");
                string fechaE = Convert.ToString((Request.QueryString["fechaE"] != null) ? Request.QueryString["fechaE"] : "");
                string monto = Convert.ToString((Request.QueryString["monto"] != null) ? Request.QueryString["monto"] : "");
                string proveedor = Convert.ToString((Request.QueryString["proveedor"] != null) ? Request.QueryString["proveedor"] : "");

                //Lleno el objeto cuenta por paga para mostrar por pantalla, y poder modificarlo:
                miCuentaPorPagar = miLogicaCuentaPorPagar.ConsultarCuentaPorPagarBD(codigo);

                LabelcuentaCodigo.Text = codigo;
                TextBox1.Text = monto;
                fechaEmision.Text = fechaE;

                //Detalle de lacuenta por pagar:
                TextBox3DetalleDeuda.Text = miCuentaPorPagar.Detalle;

                Int64 IDcuenta = Convert.ToInt64(codigo);

                //carga de los dropdowns:
                //ojo: debo pararme primero en cada dorp en el valor de LA CUENTA POR PAGAR!!!!
               // LabelRazon.Text = proveedor;
                //CargarRazonSocial();

              //  LabelBanco.Text = miCuentaPorPagar.ListaNumeroCuentaBanco.ElementAt(0).Banco.NombreBanco;
               // CargarBancosDadoProveedor(proveedor);

               // LabelCuentaBancaria.Text = miCuentaPorPagar.ListaNumeroCuentaBanco.ElementAt(0).NroCuentaBanco;
                //drop de nuero cuebta banco:

               // LabelTipoPago.Text = miCuentaPorPagar.TipoPago;
               // FechaVencimiento.Text = String.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(miCuentaPorPagar.FechaVencimiento).Date);

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
                //}*/


            }
        }

        protected void BotonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.OnClickModificar2CuentaPorPagar();
            /*
            bool fechasValidas = false;
            bool montoValido = false;

            //0- VALIDACIONES (1- QUE TODOS ESTEN LLENOS; 2- QUE SUS VALORES INDIVIDUALES SEAN VALIDOS; 3- QUE LOS VALORES DE TODOS SUMADOS SEAN COHERENTES)
            Page.Validate();
            if (Page.IsValid)
            {
                //1- Se recoge la data de cada campo de la gui en el objeto  de cuentas por pagar:
                //id de la cuenta por pagar:
                miCuentaPorPagar.IdCuentaPorPagar = LabelcuentaCodigo.Text;

                //Convert.ToDateTime(miCuentaPorPagarAagregar.FechaEmision).Date

                //Fila 1: Fechas:
                miCuentaPorPagar.FechaEmision = FechaEmision.Text;
                miCuentaPorPagar.FechaVencimiento = FechaVencimiento.Text;

                //Fila 2 y 3: dropdownlists:
                //DropDownList3: razonsocial/empresa:
                Proveedor miProveedor = new Proveedor();
                miProveedor.Nombre = DropDownListRazon.SelectedItem.Text.ToString();
                //agrego a la lista el proveedor elegido por el usuario (razon social):
                miCuentaPorPagar.ListaProveedor.Add(miProveedor);

                //DropDownList5: numero Cuenta bancaria:
                NumeroCuentaBanco miNumeroCuentaBanco = new NumeroCuentaBanco();
                miNumeroCuentaBanco.NroCuentaBanco = DropDownListCuentaBancaria.SelectedItem.Text.ToString();
                //agrego a la lista general:
                miCuentaPorPagar.ListaNumeroCuentaBanco.Add(miNumeroCuentaBanco);

                //DropDownList4: banco
                Banco miBanco = new Banco();
                miBanco.NombreBanco = DropDownListBanco.SelectedItem.Text.ToString();
                //agrego a la lista (banco):
                miCuentaPorPagar.ListaNumeroCuentaBanco.ElementAt(0).Banco = miBanco;

                //DropDownList6: tipo de pago.
                miCuentaPorPagar.TipoPago = DropDownListTipoPago.SelectedItem.Text.ToString();

                //FILA 4: Monto deuda:
                miCuentaPorPagar.MontoInicialDeuda = Convert.ToDouble(TextBox1.Text);

                //Validaciones FINALES DE INTEGRIDAD DE LOS DATOS (Justo antes de insertar)
                //[//0.2- Validar: (int)monto > 0], [//0.1- Validar: FECHA1 <= FECHA2:] + decision si es contra proveedor:

                //valida fechaini <= fechafin
                fechasValidas = miCuentaPorPagar.ValidarFechaInicioMayorOigualQueFechaFin(Convert.ToDateTime(miCuentaPorPagar.FechaEmision).Date, Convert.ToDateTime(miCuentaPorPagar.FechaVencimiento).Date);

                //validar monto como un int mayor que cero (el hecho de ser DOUBLE ya fue validado en la GUI con la etiqueta VALIDATOR):
                montoValido = miCuentaPorPagar.ValidarMontoMayorQueCero(this.miCuentaPorPagar.MontoInicialDeuda);


                //Fila 5: detalle.
                miCuentaPorPagar.Detalle = TextBox3DetalleDeuda.Text;

                string tipoDeudaEmpleado = "nomina";
                string tipoDeudaProveedor = "proveedor";

                //Si es contra empleados (nomina) o proveedores: la deuda
                if (fechasValidas && miCuentaPorPagar.ListaProveedor.ElementAt(0).Nombre.Equals(tipoDeudaEmpleado) && montoValido)
                {
                    //caso: nomina
                    miCuentaPorPagar.TipoDeuda = tipoDeudaEmpleado;
                    //2- Modificar la Cuenta Por Pagar en la BD:
                    modificacionExitosaCPP = miLogicaCuentaPorPagar.ModificarCuentaPorPagarBD(miCuentaPorPagar);


                }
                else if (fechasValidas && !miCuentaPorPagar.ListaProveedor.ElementAt(0).Nombre.Equals(tipoDeudaEmpleado) && montoValido)
                {
                    //caso: proveedor
                    miCuentaPorPagar.TipoDeuda = tipoDeudaProveedor;
                    //2- Modificar la Cuenta Por Pagar en la BD:
                    modificacionExitosaCPP = miLogicaCuentaPorPagar.ModificarCuentaPorPagarBD(miCuentaPorPagar);

                }
                else
                {
                    //Si las dos fechas son invalidas (Emision mayor que la de vencimiento)
                    if (!fechasValidas)
                    {
                        falla.Text = falla.Text + ": Fecha de Emisión es mayor que la Fecha de Vencimiento.";
                    }
                    //Si las dos fechas son invalidas (Emision mayor que la de vencimiento)
                    if (!montoValido)
                    {
                        falla.Text = falla.Text + ": El Monto Total (BsF) debe ser mayor que cero.";
                    }


                    falla.Visible = true;
                }


                //3- Terminada la modoificacion, chequea y decir por pantalla si fue un exito o un fracaso:

                Exito.Text = "Operacion Realizada Exitosamente";
                falla.Text = "Operacion Fallida";

                //si fue un fallo:
                if (!modificacionExitosaCPP)
                {
                    Exito.Visible = false;
                    //Exito.Text = "";
                    //falla.Text = "Operacion Fallida";
                    falla.Visible = true;
                    //Validador del Monto:
                    validatorCompareDoubleTypeMonto.Visible = false;
                    //Validador de Fecha Emision: haciendolo invisible
                    RegularExpressionValidatorFechaEmision.Visible = false;
                    //Validador de Fecha Vencimiento: haciendolo invisible
                    RegularExpressionValidatorFechaVen.Visible = false;

                }
                else
                {
                    //si fue un exito:
                    falla.Visible = false;
                    //Exito.Text = "Operacion Realizada Exitosamente";
                    Exito.Visible = true;
                    //falla.Text = "";
                }
            }*/
        }


        protected void DropDownListRazon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DESELCCIONAR (limpiar) LOS DEMAS DROPDOWNLISTS QUE VAN MAS ABAJO EN LA JERARQUIA:
            //Dropdownlist de bancos:
            DropDownListBanco.Items.Clear();
            ListItem registroLista4 = new ListItem("-- Selecciona --", "0");
            DropDownListBanco.Items.Add(registroLista4);

            //Dropdownlist de nuero cuenta bancaria:
            DropDownListCuentaBancaria.Items.Clear();
            ListItem registroLista5 = new ListItem("-- Selecciona --", "0");
            DropDownListCuentaBancaria.Items.Add(registroLista5);

            //3- Cargo desde la BD los campos textBox y DropDownlist: Bancos, CuentaBancaria, TipoPago, ETC..:
            //DROPDOWNLIST BANCO dado el Proveedor (nomina empleado + proveedores):
            CargarBancosDadoProveedor(DropDownListRazon.SelectedItem.Text.ToString());
        }

        protected void DropDownListBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dropdownlist de nuero cuenta bancaria:
            DropDownListCuentaBancaria.Items.Clear();
            ListItem registroLista5 = new ListItem("-- Selecciona --", "0");
            DropDownListCuentaBancaria.Items.Add(registroLista5);

            //3- Cargo desde la BD los campos textBox y DropDownlist: Bancos, CuentaBancaria, TipoPago, ETC..:
            //DROPDOWNLIST ""NUMERO CUENTA"", DADO EL BANCO Y dado el Proveedor (nomina empleado + proveedores):
            CargarNumeroCuentaBancariaDadoProveedor(DropDownListRazon.SelectedItem.Text.ToString(), DropDownListBanco.SelectedItem.Text.ToString());

        }

        protected void DropDownListCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void DropDownListTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Llenado del Dropdownlist de RAZON SOCIAL.
        /// </summary>
        public void CargarRazonSocial()
        {
            //PROVEEDORES:
            /*
            listaProveedor = miLogicaProveedor.ObtenerProveedores();

            for (int i = 0; i < listaProveedor.Count; i++)
            {
                DropDownListRazon.Items.Add(listaProveedor.ElementAt(i).Nombre.ToString());
            }*/

            //NOMINA EMPLEADOS:
            //Proveedor miNomina = new Proveedor();
            //miNomina.Nombre = "nomina";
            //DropDownListRazon.Items.Add(miNomina.Nombre.ToString());

        }


        /// <summary>
        /// Llenado del Dropdownlist de Bancos.
        /// Entrada: Proveeedor (dado por el anterior Dropdownlist).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CargarBancosDadoProveedor(string nombreProveedor)
        {
           /* listaBanco = miLogicaBanco.MostrarListadoBancoPorProveedores(nombreProveedor);

            for (int i = 0; i < listaBanco.Count; i++)
            {
                DropDownListBanco.Items.Add(listaBanco.ElementAt(i).NombreBanco.ToString());
            }*/
        }

        /// <summary>
        /// Cargar el dropdownlist de NUMERO CUENTA BANCARIA.
        /// (dados:  nombre proveedor + )
        /// </summary>
        /// <param name="nombreProveedor"></param>
        /// <param name="?"></param>
        public void CargarNumeroCuentaBancariaDadoProveedor(string nombreProveedor, string nombreBanco)
        {
           
            /*listaNumeroCuentaBanco = miLogicaBanco.MostrarListaNumeroCuentaBancariaProveedores(nombreProveedor, nombreBanco);

            for (int i = 0; i < listaNumeroCuentaBanco.Count; i++)
            {
                DropDownListCuentaBancaria.Items.Add(listaNumeroCuentaBanco.ElementAt(i).NroCuentaBanco.ToString());
            }*/
        }



    }
}
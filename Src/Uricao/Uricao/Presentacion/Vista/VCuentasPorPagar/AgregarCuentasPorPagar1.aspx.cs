using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EBancos;
using Uricao.LogicaDeNegocios.Clases.LNCuentasPorPagar;
using Uricao.LogicaDeNegocios.Clases.LNProveedores;
using Uricao.LogicaDeNegocios.Clases.LNBancos;
using System.Data;
using System.Drawing;
using Uricao.Entidades.EAbonos;
using Uricao.LogicaDeNegocios.Clases.LNAbono;
using Uricao.Presentacion.Presentador.PCuentasPorPagar;
using Uricao.Presentacion.Contrato.CCuentasPorPagar;

namespace Uricao.Presentacion.PaginasWeb.PCuentasPorPagar
{
    public partial class AgregarCuentasPorPagar1 : System.Web.UI.Page, IContratoAgregarCuentasPorPagar1
    {
        private PresentadorAgregarCuentasPorPagar1 _presentador;
        public AgregarCuentasPorPagar1()
        {
            _presentador = new PresentadorAgregarCuentasPorPagar1(this);
        }
        //Atributos:
        LogicaCuentaPorPagar miLogicaDeCuentaPorPagar = new LogicaCuentaPorPagar();
        CuentaPorPagar miCuentaPorPagarAagregar = new CuentaPorPagar();
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
        public TextBox TextBox1FechaEmision
        {
            get { return textBox1FechaEmision; }
            set { textBox1FechaEmision = value; }
        }

        public TextBox TextBox2FechaVencimiento
        {
            get { return textBox2FechaVencimiento; }
            set { textBox2FechaVencimiento = value; }
        }

        public TextBox TextBox2Monto
        {
            get { return textBox2Monto; }
            set { textBox2Monto = value; }
        }
        public TextBox TextBox3DetalleDeuda
        {
            get { return textBox3DetalleDeuda; }
            set { textBox3DetalleDeuda = value; }
        }

        public DropDownList DropDownList5
        {
            get { return dropDownList5; }
            set { dropDownList5 = value; }
        }
        public DropDownList DropDownList6
        {
            get { return dropDownList6; }
            set { dropDownList6 = value; }
        }
        public DropDownList DropDownList3
        {
            get { return dropDownList3; }
            set { dropDownList3 = value; }
        }
        public DropDownList DropDownList4
        {
            get { return dropDownList4; }
            set { dropDownList4 = value; }
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
            get { return regularExpressionValidatorFechaVencimiento; }
            set { regularExpressionValidatorFechaVencimiento = value; }
        }
        public RegularExpressionValidator RegularExpressionValidatorFechaEmision
        {
            get { return regularExpressionValidatorFechaEmision; }
            set { regularExpressionValidatorFechaEmision = value; }
        }
       

        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.PageLoad();

            }
        }





        protected void BotonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.OnClickAgregarCuentaPorPagar();
            //0- VALIDACIONES (1- QUE TODOS ESTEN LLENOS; 2- QUE SUS VALORES INDIVIDUALES SEAN VALIDOS; 3- QUE LOS VALORES DE TODOS SUMADOS SEAN COHERENTES)

            ////////////////////
            //Validar la pagina
            ////////////////////
         /*   Page.Validate();

            if (Page.IsValid)
            {
                //1- Se recoge la data de cada campo de la gui en el objeto  de cuentas por pagar:
                //Fila 1: Fechas:
                miCuentaPorPagarAagregar.FechaEmision = TextBox1FechaEmision.Text;
                miCuentaPorPagarAagregar.FechaVencimiento = TextBox2FechaVencimiento.Text;

                //FILA 4: Monto deuda:
                miCuentaPorPagarAagregar.MontoInicialDeuda = Convert.ToDouble(TextBox2Monto.Text);
                miCuentaPorPagarAagregar.MontoActualDeuda = miCuentaPorPagarAagregar.MontoInicialDeuda;

                //Fila 2 y 3: dropdownlists:
                //DropDownList3: razonsocial/empresa:
                Proveedor miProveedor = new Proveedor();
                miProveedor.Nombre = DropDownList3.SelectedItem.Text.ToString();
                //agrego a la lista el proveedor elegido por el usuario (razon social):
                miCuentaPorPagarAagregar.ListaProveedor.Add(miProveedor);

                //DropDownList5: numero Cuenta bancaria:
                NumeroCuentaBanco miNumeroCuentaBanco = new NumeroCuentaBanco();
                miNumeroCuentaBanco.NroCuentaBanco = DropDownList5.SelectedItem.Text.ToString();
                //agrego a la lista general:
                miCuentaPorPagarAagregar.ListaNumeroCuentaBanco.Add(miNumeroCuentaBanco);

                //DropDownList4: banco
                Banco miBanco = new Banco();
                miBanco.NombreBanco = DropDownList4.SelectedItem.Text.ToString();
                //agrego a la lista (banco):
                miCuentaPorPagarAagregar.ListaNumeroCuentaBanco.ElementAt(0).Banco = miBanco;

                //DropDownList6: tipo de pago.
                miCuentaPorPagarAagregar.TipoPago = DropDownList6.SelectedItem.Text.ToString();


                //Fila 5: detalle.
                miCuentaPorPagarAagregar.Detalle = TextBox3DetalleDeuda.Text;

                //Atributos adicionales a llenar: 
                //(a) EstatusPP:
                string estatusPP = "activo";
                miCuentaPorPagarAagregar.Estatus = estatusPP;

                string tipoDeudaEmpleado = "nomina";
                string tipoDeudaProveedor = "proveedor";

                //Texto de Error:
                Exito.Text = "Operacion Realizada Exitosamente";
                falla.Text = "Operacion Fallida";

                //Validaciones FINALES DE INTEGRIDAD DE LOS DATOS (Justo antes de insertar)
                //[//0.2- Validar: (int)monto > 0], [//0.1- Validar: FECHA1 <= FECHA2:] + decision si es contra proveedor:

                //valida fechaini <= fechafin
                bool fechasValidas = miCuentaPorPagarAagregar.ValidarFechaInicioMayorOigualQueFechaFin(Convert.ToDateTime(miCuentaPorPagarAagregar.FechaEmision).Date, Convert.ToDateTime(miCuentaPorPagarAagregar.FechaVencimiento).Date);

                //validar monto como un int mayor que cero (el hecho de ser DOUBLE ya fue validado en la GUI con la etiqueta VALIDATOR):
                bool montoValido = miCuentaPorPagarAagregar.ValidarMontoMayorQueCero(this.miCuentaPorPagarAagregar.MontoInicialDeuda);

                //Si es contra empleados (nomina) o proveedores: la deuda
                if (fechasValidas && miCuentaPorPagarAagregar.ListaProveedor.ElementAt(0).Nombre.Equals(tipoDeudaEmpleado) && montoValido)
                {
                    //caso: Nomina
                    miCuentaPorPagarAagregar.TipoDeuda = tipoDeudaEmpleado;

                    //2- Insertar la Cuenta Por Pagar en la BD:
                    insercionExitosaCPP = miLogicaDeCuentaPorPagar.AgregarEnBDunaCuentaPorPagar(miCuentaPorPagarAagregar);

                }
                else if (fechasValidas && !miCuentaPorPagarAagregar.ListaProveedor.ElementAt(0).Nombre.Equals(tipoDeudaEmpleado) && montoValido)
                {
                    //caso: proveedor
                    miCuentaPorPagarAagregar.TipoDeuda = tipoDeudaProveedor;
                    //2- Insertar la Cuenta Por Pagar en la BD:
                    insercionExitosaCPP = miLogicaDeCuentaPorPagar.AgregarEnBDunaCuentaPorPagar(miCuentaPorPagarAagregar);
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
                    insercionExitosaCPP = false;
                }


                //3- Terminada la insercion, chequea y decir por pantalla si fue un exito o un fracaso:

                //si fue un fallo:
                if (!insercionExitosaCPP)
                {
                    Exito.Visible = false;
                    //Exito.Text = "";
                    //falla.Text = "Operacion Fallida";
                    falla.Visible = true;
                    //Validador del Monto:
                    validatorCompareDoubleTypeMonto.Visible = false;
                    //Validador de Fecha Emision: haciendolo invisible
                    regularExpressionValidatorFechaEmision.Visible = false;
                    //Validador de Fecha Vencimiento: haciendolo invisible
                    regularExpressionValidatorFechaVencimiento.Visible = false;

                }
                else
                {
                    //si fue un exito:
                    falla.Visible = false;
                    //Exito.Text = "Operacion Realizada Exitosamente";
                    Exito.Visible = true;
                    //falla.Text = "";
                }

            }//End page.isvalid
            */
        }


        /// <summary>
        /// Llenado del Dropdownlist de RAZON SOCIAL.
        /// </summary>
        public void CargarRazonSocial()
        {
            //PROVEEDORES:

          //listaProveedor = miLogicaProveedor.ObtenerProveedores();

            for (int i = 0; i < listaProveedor.Count; i++)
            {
                DropDownList3.Items.Add(listaProveedor.ElementAt(i).Nombre.ToString());
            }

            //NOMINA EMPLEADOS:
            //Proveedor miNomina = new Proveedor();
            //miNomina.Nombre = "nomina";
            //DropDownList3.Items.Add(miNomina.Nombre.ToString());



        }

        /// <summary>
        /// Dropdownlist de razon social.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DESELCCIONAR (limpiar) LOS DEMAS DROPDOWNLISTS QUE VAN MAS ABAJO EN LA JERARQUIA:
            //Dropdownlist de bancos:
            DropDownList4.Items.Clear();
            ListItem registroLista4 = new ListItem("-- Selecciona --", "0");
            DropDownList4.Items.Add(registroLista4);

            //Dropdownlist de nuero cuenta bancaria:
            DropDownList5.Items.Clear();
            ListItem registroLista5 = new ListItem("-- Selecciona --", "0");
            DropDownList5.Items.Add(registroLista5);

            //3- Cargo desde la BD los campos textBox y DropDownlist: Bancos, CuentaBancaria, TipoPago, ETC..:
            //DROPDOWNLIST BANCO dado el Proveedor (nomina empleado + proveedores):
            CargarBancosDadoProveedor(DropDownList3.SelectedItem.Text.ToString());
        }


        /// <summary>
        /// Llenado del Dropdownlist de Bancos.
        /// Entrada: Proveeedor (dado por el anterior Dropdownlist).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CargarBancosDadoProveedor(string nombreProveedor)
        {
            //listaBanco = miLogicaBanco.MostrarListadoBancoPorProveedores(nombreProveedor);

            for (int i = 0; i < listaBanco.Count; i++)
            {
                DropDownList4.Items.Add(listaBanco.ElementAt(i).NombreBanco.ToString());
            }
        }


        /// <summary>
        /// Dropdownlist de banco, dado el proveedor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dropdownlist de nuero cuenta bancaria:
            DropDownList5.Items.Clear();
            ListItem registroLista5 = new ListItem("-- Selecciona --", "0");
            DropDownList5.Items.Add(registroLista5);

            //3- Cargo desde la BD los campos textBox y DropDownlist: Bancos, CuentaBancaria, TipoPago, ETC..:
            //DROPDOWNLIST ""NUMERO CUENTA"", DADO EL BANCO Y dado el Proveedor (nomina empleado + proveedores):
            CargarNumeroCuentaBancariaDadoProveedor(DropDownList3.SelectedItem.Text.ToString(), DropDownList4.SelectedItem.Text.ToString());
        }


        /// <summary>
        /// Cargar el dropdownlist de NUMERO CUENTA BANCARIA. 
        /// (dados:  nombre proveedor + )
        /// </summary>
        /// <param name="nombreProveedor"></param>
        /// <param name="?"></param>
        public void CargarNumeroCuentaBancariaDadoProveedor(string nombreProveedor, string nombreBanco)
        {
           // listaNumeroCuentaBanco = miLogicaBanco.MostrarListaNumeroCuentaBancariaProveedores(nombreProveedor, nombreBanco);

            for (int i = 0; i < listaNumeroCuentaBanco.Count; i++)
            {
                DropDownList5.Items.Add(listaNumeroCuentaBanco.ElementAt(i).NroCuentaBanco.ToString());
            }
        }

        /// <summary>
        /// Dropdowlist cambiado, de NUMERO CUENTA BANCARIA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
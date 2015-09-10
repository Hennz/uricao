using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;

namespace Uricao.Presentacion.Presentador.PPresupuestoFacturas
{
    public class PresentadorGenerarPresupuestoEspecifico
    {
        #region Atributos

        private IContratoGenerarPresupuestoEspecifico _vista;
        private List<Entidad> listaTratamientos;
        private string cedula;
        private string observaciones;
        private string tipoCi;
        private Presupuesto presupuesto = new Presupuesto();
        private const double iva = 0.12;

        private List<Tratamiento> _listaTrata = new List<Tratamiento>();
        private List<Tratamiento> _listaTrataCasteo = new List<Tratamiento>();

        private bool _miComandoPresupuesto;
        private Comando<bool> _miComando;

        private Comando<int> _miComandoCedula;
        private int _miCedula;

        private Entidad _miEntidad;

        private Entidad _miEntidadTratamiento;

        private Comando<Entidad> a;

        private Comando<int> miComandoSubTotal;

        private Comando<String> _miComandoDatos;

        #endregion

        #region Constructor

        public PresentadorGenerarPresupuestoEspecifico(IContratoGenerarPresupuestoEspecifico vista)
        {
            this._vista = vista;
        }

        #endregion

        #region Métodos Pagina

        public void Page_Load(object sender, EventArgs e)
        {
            cedula = (string)_vista.Sesion["cedula"];
            tipoCi = (string)_vista.Sesion["tipoci"];
            observaciones = (string)_vista.Sesion["observaciones"];
            listaTratamientos = (List<Entidad>)_vista.Sesion["listaTratamientosElegidos"];

            ObtenerCostosDeTratamientosElegidos(); //Busca los costos de cada uno de los tratamientos elegidos en la ventana anterior

            llenar_datos(); //procedimiento que llena los datos de la ventana
            _vista.AGVDetalle.DataSource = listaTratamientos;
            
            if (listaTratamientos != null)
            {
                _vista.AGVDetalle.DataBind();
            }

            presupuesto.Fecha_emision = System.DateTime.Now;
            presupuesto.Observaciones = observaciones;

            llenarListaDetalle(); //Procedimiento que llena el GridView con el detalle del presupuesto
            SubTotal(); //Calculo del total del presupuesto
        }

        public void BotonAceptar_Click(object sender, EventArgs e)
        {
            _miComandoCedula = FabricaComando.CrearComandoRegresarIdUsuario(cedula);
            _miCedula = _miComandoCedula.Ejecutar();

            _miComando = FabricaComando.CrearComandoAgregarPresupuesto(presupuesto,_miCedula);
            _miComandoPresupuesto = _miComando.Ejecutar();

            if (_miComandoPresupuesto)
            {
                _vista.Sesion["el_presupuesto"] = presupuesto;
                _vista.Redireccionar("GenerarPresupuesto_Operacion.aspx");
            }
        }

        #endregion

        #region

        public void llenar_datos()
        {
            _vista.LObservaciones.Text = observaciones;
            _vista.ALtipoCi.Text = tipoCi;
            _vista.ALCedula.Text = Convert.ToString(cedula);
            _miComandoDatos = FabricaComando.CrearComandoregresarDatosUsuario(cedula, tipoCi);
            _vista.ALNombre.Text = _miComandoDatos.Ejecutar();
            _vista.ALFechaPresupuessto.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void SubTotal()
        {
            for (int i = 0; i < listaTratamientos.Count; i++)
            {
               _listaTrataCasteo.Add(listaTratamientos[i] as Tratamiento);
            }

            miComandoSubTotal = FabricaComando.CrearComandoSubtotalPresupuesto(_listaTrataCasteo);
            int subTotal = miComandoSubTotal.Ejecutar();
            presupuesto.Total_presupuesto = (subTotal + (subTotal * iva));
            _vista.ALSubtotal.Text = "" + subTotal;
            _vista.ALIVA.Text = "" + (subTotal * iva);
            _vista.ALTotal.Text = "" + presupuesto.Total_presupuesto;
        }

        public void ObtenerCostosDeTratamientosElegidos()
        {

            for (int i = 0; i < listaTratamientos.Count; i++)
            {
               _listaTrata.Add(listaTratamientos[i] as Tratamiento);
            }

            for (int i = 0; i < listaTratamientos.Count; i++)
            {
                _miComandoCedula = FabricaComando.CrearComandoRegresarCostoTratamiento((listaTratamientos[i] as Tratamiento).Id,_listaTrata,i);
                int devolvio = _miComandoCedula.Ejecutar();

                (listaTratamientos[i] as Tratamiento).Costo = (short)devolvio;
            }
        }

        public void llenarListaDetalle()
        {
            listaTratamientos = _vista.Sesion["listaTratamientosElegidos"] as List<Entidad>;
            foreach (Tratamiento tratamiento in listaTratamientos)
            {
                Detalle_Presupuesto_Factura milista = new Detalle_Presupuesto_Factura(tratamiento,tratamiento.Costo,tratamiento.Duracion);
                ////aLNumeroPresupuesto.Text = aLNumeroPresupuesto.Text + " " + tratamiento.Duracion + " ";
                milista.Cantidad = tratamiento.Duracion;
                presupuesto.addDetalle(milista);
            }
        }

        #endregion
    }
}
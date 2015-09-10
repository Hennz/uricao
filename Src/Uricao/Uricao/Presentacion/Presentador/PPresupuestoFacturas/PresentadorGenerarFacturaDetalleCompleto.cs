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
    public class PresentadorGenerarFacturaDetalleCompleto
    {

        #region Atributos

        private IContratoGenerarFacturaDetalleCompleto _vista;
        public List<Tratamiento> listaTratamientos;
        public Factura laFactura;
        private Comando<double> _miComando;
       

        #endregion

        #region Constructor

        public PresentadorGenerarFacturaDetalleCompleto(IContratoGenerarFacturaDetalleCompleto vista)
        {
            this._vista = vista;
        }

        #endregion

        #region Métodos
        public void LlenarListaDetalle()
        {
            listaTratamientos = _vista.Sesion["listado_agregado"] as List<Tratamiento>;
            foreach (Tratamiento tratamiento in listaTratamientos)
            {
                Detalle_Presupuesto_Factura detalle = new Detalle_Presupuesto_Factura(tratamiento, tratamiento.Costo, tratamiento.Duracion);

                detalle.Cantidad = tratamiento.Duracion;
                laFactura.addDetalle(detalle);


            }
        }

        public void SubTotal()
        {
            _miComando = FabricaComando.CrearComandoSubtotalFactura(laFactura);
            double subTotal = _miComando.Ejecutar();
            laFactura.setTotal_Factura(subTotal + (subTotal * 0.12));
            _vista.ALSubtotal.Text = "" + subTotal;
            _vista.ALIVA.Text = "" + (subTotal * 0.12);
            _vista.ALTotal.Text = "" + laFactura.getTotal_Factura();


        }

        public void LlenarDatos()
        {
            laFactura = _vista.Sesion["la_Factura"] as Factura;
            _vista.ALNombre.Text = laFactura.getNombre_Razon();
            _vista.ALFechafactura.Text = laFactura.getFecha_Emitida().ToString("dd/MM/yyyy");
            _vista.ALCIRIF.Text = laFactura.TipoIdentRazon + laFactura.getCedula_Razon();
            //aLDireccion.Text = la_factura.get

        }

        public void LlenarTabla()
        {
            listaTratamientos = _vista.Sesion["listado_agregado"] as List<Tratamiento>;
            _vista.AGTratamiento.DataSource = listaTratamientos;
            if (listaTratamientos != null)
            {
                _vista.AGTratamiento.DataBind();
            }
            else
            {
                //aTBTratamiento.Text = "";
                //mostrar error porque no se muestra
            }
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;

namespace Uricao.Presentacion.Presentador.PPresupuestoFacturas
{
    public class PresentadorConsultaFactura_Detalle
    {
        #region Atributos

        private IContratoConsultaFactura_Detalle _vista;

        //Atributo que contendra la Factura, recibir desde la pagina anterior: (por Session)
        private Entidad _miFactura;

        private Comando<String> _miComandoFactura;
        private Comando<Double> _miComandoFacturaSubTotal;
        private Comando<List<Entidad>> _miComandoListaFacturaEntidad;

        List<Entidad> _listaDetalle;

        #endregion

        #region Constructor

        public PresentadorConsultaFactura_Detalle (IContratoConsultaFactura_Detalle vista)
        {
            this._vista = vista;
        }

        #endregion


        #region Métodos


        public void PintarFactura_Detalle()
        {
            //Recuperar la Factura, recibir desde la pagina anterior: (por Session)
            _miFactura = (_vista.Sesion["factura"] as Factura);
            //OJO:  asi se hace sin patrones: Factura factura = (Factura)Session["factura"];

            if (_miFactura != null)
            {
                _vista.ALNombre_Persona_campo.Text = (_miFactura as Factura).Nombre_razon;
                _vista.ALIdentificacion.Text = (_miFactura as Factura).Cedula_razon;
                
                _miComandoFactura = FabricaComando.CrearComandoConsultarDireccionEstadoFactura((_miFactura as Factura).Id_direccion);
                _vista.ALEstado_campo.Text = _miComandoFactura.Ejecutar();

                _miComandoFactura = FabricaComando.CrearComandoConsultarDireccionCiudadFactura((_miFactura as Factura).Id_direccion);
                _vista.ALCiudad_campo.Text = _miComandoFactura.Ejecutar();

                _miComandoFactura = FabricaComando.CrearComandoConsultarDireccionMunicipioFactura((_miFactura as Factura).Id_direccion);
                _vista.ALMunicipio_campo.Text = _miComandoFactura.Ejecutar();

                _miComandoFactura = FabricaComando.CrearComandoConsultarDireccionCalleFactura((_miFactura as Factura).Id_direccion);
                _vista.ALCalle_campo.Text = _miComandoFactura.Ejecutar();

                _miComandoFactura = FabricaComando.CrearComandoConsultarDireccionEdificioFactura((_miFactura as Factura).Id_direccion);
                _vista.ALEdificio_campo.Text = _miComandoFactura.Ejecutar();

                _miComandoListaFacturaEntidad = FabricaComando.CrearComandoConsultarDetalleFactura((_miFactura as Factura).Nro_factura);
                _listaDetalle = _miComandoListaFacturaEntidad.Ejecutar();


                if ((_listaDetalle.Count > 0) || (_listaDetalle != null))
                {

                    _vista.ALIVA.Text = _listaDetalle.Count.ToString();

                    /*
                    _miComandoFacturaSubTotal = FabricaComando.CrearComandoSubtotalFactura(_listaDetalle.ElementAt(0) as Factura);
                    Double subTotal = _miComandoFacturaSubTotal.Ejecutar();
                    */

                    Double subTotal = CostoTodoElDetalleSinIva(_listaDetalle);

                    Double iva = 0.12 * subTotal;
                    Double montoTotal = subTotal + iva;

                    //aqui se pasan los datos a los TextBoxes:
                    _vista.ALSubtotal.Text = subTotal.ToString();
                    _vista.ALIVA.Text = iva.ToString();
                    _vista.ALTotal.Text = montoTotal.ToString();

                    //aqui se cargan los datos en el gridview:
                    _vista.GridViewDetalle.DataSource = cargarTabla(_listaDetalle);
                    _vista.GridViewDetalle.DataBind();
                }
            }            
        }



        #region Cargar facturas en un DataTable

        /// <summary>
        /// Método cargar tabla de con los
        /// detalles de la factura (clase dominio: Detalle_Presupuesto_Factura)
        /// </summary>
        /// <param name="miLista" que sera casteado al tipo: List<Detalle_Presupuesto_Factura></param>
        /// <returns></returns>
        public DataTable cargarTabla(List<Entidad> miLista)
        {
            DataTable miTabla = new DataTable();

            miTabla.Columns.Add("Concepto", typeof(string));
            miTabla.Columns.Add("Cantidad", typeof(string));
            miTabla.Columns.Add("Monto", typeof(string));

            foreach (Detalle_Presupuesto_Factura detalle in miLista)
                miTabla.Rows.Add(detalle.El_Tratamiento.Nombre, detalle.Cantidad, detalle.Total_pago_tratamiento);

            return miTabla;
        }


        #endregion Cargar facturas en un DataTable


        #region Calculos de Consultar Factura

        //public Double CostoTodoElDetalleSinIva(List<Detalle_Presupuesto_Factura> listaDetalle)
        public Double CostoTodoElDetalleSinIva(List<Entidad> _listaDetalle)
        {
            try
            {
                Double costo = 0.0;

                //Detalle_Presupuesto_Factura
                foreach (Detalle_Presupuesto_Factura detalle in _listaDetalle)
                {
                    costo = costo + detalle.Total_pago_tratamiento * detalle.Cantidad;
                }
                return costo;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        #endregion Calculos de Consultar Factura


        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.Presentacion.Presentador.PPresupuestoFacturas
{
    public class PresentadorConsultarPresupuestoEspecifico
    {
        #region Atributos

        private IContratoConsultarPresupuestoEspecifico _vista;
        private Comando<List<Entidad>> _miComandoPresupuesto;
        private Comando<List<Entidad>> _miComandoPresupuestoEntidad;
        private Comando<List<Entidad>> _miComandoDetallePresupuesto;

        private Comando<Entidad> _miComandoUsuarioEntidad;

        private List<Entidad> _miListaPresupuestos;
        private List<Entidad> _miListaDetallePresupuestos;
        private Entidad _miPresupuesto;
        private Entidad _miUsuario;
        private Comando<String> _miCedulaPresupuesto;
        private String _cedula;

        #endregion

        #region Constructor

        public PresentadorConsultarPresupuestoEspecifico (IContratoConsultarPresupuestoEspecifico vista)
        {
            this._vista = vista;
        }

        #endregion

        #region Métodos Página

        public void pageLoad(object sender, EventArgs e)
        {
            Presupuesto presupuesto = this._vista.Sesion["presupuesto"] as Presupuesto;
            if (presupuesto != null)
            {
                _vista.ALFechaPresupuesto.Text = presupuesto.Fecha_emision.ToString("dd/MM/yyyy");
                _vista.ALNumeroPresupuesto.Text = presupuesto.Nro_presupuesto.ToString();
                _vista.ALObservaciones.Text = presupuesto.Observaciones;

                _miComandoUsuarioEntidad = FabricaComando.CrearComandoConsultarDatosBasicosUsuarioPresupuesto(presupuesto.Nro_presupuesto);
                _miUsuario = _miComandoUsuarioEntidad.Ejecutar();

                _vista.ALCedula.Text = (_miUsuario as Usuario).TipoIdentificacion + "-" + (_miUsuario as Usuario).Identificacion;
                _vista.ALNombre.Text = (_miUsuario as Usuario).PrimerNombre + " " + (_miUsuario as Usuario).PrimerApellido + " " + (_miUsuario as Usuario).SegundoApellido;

                _miComandoDetallePresupuesto = FabricaComando.CrearComandoConsultarDetallePresupuesto(presupuesto.Nro_presupuesto);
                _miListaDetallePresupuestos = _miComandoDetallePresupuesto.Ejecutar();
                

                if (_miListaDetallePresupuestos != null)
                    LlenarGridViewLlenarDetalle(_miListaDetallePresupuestos);
            }
        }

        #endregion

        #region Métodos

        public Double CostoTodoElDetalleSinIva(List<Entidad> listaDetalle)
        {
            try
            {
                Double costo = 0.0;
                foreach (Detalle_Presupuesto_Factura detalle in listaDetalle)
                {
                    costo = costo + detalle.Total_pago_tratamiento;
                }
                return costo;
            }
            catch (ArithmeticException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con calculos aritmeticos", e);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        public void LlenarGridViewLlenarDetalle(List<Entidad> listaDetalle)
        {
            _vista.ALIVA.Text = listaDetalle.Count.ToString();
            Double subTotal = CostoTodoElDetalleSinIva(listaDetalle);
            Double iva = 0.12 * subTotal;
            Double montoTotal = subTotal + iva;
            _vista.ALSubtotal.Text = subTotal.ToString();
            _vista.ALIVA.Text = iva.ToString();
            _vista.ALTotal.Text = montoTotal.ToString();

            _vista.GridViewDetalle.DataSource = CargarTabla(listaDetalle);
            _vista.GridViewDetalle.DataBind();
        }

        /// <summary>
        /// Método para cargar la tabla
        /// con el detalle de los presupuestos
        /// y el motivo del usuario
        /// </summary>
        /// <param name="miLista"></param>
        /// <returns></returns>
        public DataTable CargarTabla(List<Entidad> miListaDetalle)
        {
            DataTable miTabla = new DataTable();
            miTabla.Columns.Add("Nombre Tratamiento", typeof(string));
            miTabla.Columns.Add("Cantidad", typeof(int));
            miTabla.Columns.Add("Monto", typeof(float));

            foreach (Detalle_Presupuesto_Factura detalle in miListaDetalle)
                miTabla.Rows.Add(detalle.El_Tratamiento.Nombre, detalle.Cantidad, detalle.Total_pago_tratamiento);

            return miTabla;
        }

        #endregion

    }
}
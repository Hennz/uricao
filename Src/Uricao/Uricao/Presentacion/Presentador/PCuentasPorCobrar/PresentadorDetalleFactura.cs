using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CCuentasPorCobrar;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Comandos.CuentasPorCobrar;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAbonos;


namespace Uricao.Presentacion.Presentador.PCuentasPorCobrar
{
    public class PresentadorDetalleFactura
    {
        #region Atributos

        private IContratoDetalleFactura _vista;
        private Comando<List<Entidad>> _comando;
        private int _numero;
        private List<Abono> _abono;
        private List<Detalle> _detalle;

        #endregion

        #region Constructor

        public PresentadorDetalleFactura(IContratoDetalleFactura _vista)
        {
            this._vista = _vista;
        }

        #endregion

        #region Metodos

        //LogicaCuentaPorCobrar logica = new LogicaCuentaPorCobrar();

        public void VistaPrincipal()
        {

            //_vista.falla.Visible = false;
            // _vista.Exito.Visible = false;
            /* _numero = Convert.ToInt32(Session["Factura"]);

             _abono = logica.BuscarAbonos(this._numero);
             _detalle = logica.consultarDetalleFactura(this._numero);
             Session["NumFactura"] = _numero;
             Session["NumCuenta"] = Session["NoCuenta"];

             if (_detalle.Count == 0)
             {
                 _vista.Exito.Text = "LA FACTURA NO POSEE DETALLES";
                 _vista.Exito.Visible = true;
             }

             if (_abono.Count == 0)
             {
                 _vista.Exito.Text = "EL USUARIO NO POSEE ABONOS";
                 _vista.Exito.Visible = true;
             }


             cargarAbonos();
             cargarDatos();
             cargarDetalle();


         }

         public void cargarAbonos()
         {
             DataTable table = new DataTable();


             table.Columns.Add("Monto Abonado", typeof(string));
             table.Columns.Add("Deuda", typeof(string));
             table.Columns.Add("Fecha", typeof(string));

             foreach (Abono elabono in _abono)
             {
                 table.Rows.Add(elabono.MontoAbono, elabono.Deuda, Convert.ToDateTime(elabono.FechaAbono).ToShortDateString());
             }


             _vista.GridConsultar2.DataSource = table;
             _vista.GridConsultar2.DataBind();

         }

         public void cargarDatos()
         {
             _vista.Label8.Text = (string)Session["CedulaD"];
             _vista.Label10.Text = (string)Session["Nombres"];
             _vista.Label13.Text = (string)Session["Apellidos"];
             _vista.Label7.Text = (string)Session["Factura"];

         }

         public void cargarDetalle()
         {
             DataTable table = new DataTable();


             table.Columns.Add("Cantidad", typeof(string));
             table.Columns.Add("Concepto", typeof(string));
             table.Columns.Add("Monto", typeof(string));

             foreach (Detalle elabono in _detalle)
             {
                 table.Rows.Add(elabono.CantidadDetalle, elabono.NombreTratamiento, elabono.MontoDetalle);
             }


             _vista.GridConsultar.DataSource = table;
             _vista.GridConsultar.DataBind();

         }*/


        #endregion
        }
    }
}
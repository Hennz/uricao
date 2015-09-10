using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CCuentasPorCobrar;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Comandos.CuentasPorCobrar;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.LogicaDeNegocios.Fabricas;


namespace Uricao.Presentacion.Presentador.PCuentasPorCobrar
{
    public class PresentadorModificarEstado
    {
        #region Atributos

        private IContratoModificarEstado _vista;
        private Comando<List<Entidad>> _comando;
        private string _cedula;
        private string _tipo;

        private string _fechaInicio;
        private string _fechaFin;

        private List<Entidad> _usuario;
        private List<Ficticia> _ficticio;
        private int _index = 0;
        private double _total;

        #endregion


        #region Constructor

        public PresentadorModificarEstado(IContratoModificarEstado vista)
        {
            this._vista = vista;
        }

        #endregion


        #region Metodos

        public void VistaPrincipal()
        {
            /*   _vista.falla.Visible = false;
               _vista.Exito.Visible = false;

               //LogicaCuentaPorCobrar logica = new LogicaCuentaPorCobrar();

               this._cedula = (string)_vista.Session["Cedula"];
               this._tipo = (string)Session["TipoUser"];

               if ((Session["FechaInicio"] == null) || (Session["FechaFin"] == null))
               {
                   _vista._fechaInicio = string.Empty;
                   _vista._fechaFin = string.Empty;
               }
               else
               {
                   _vista._fechaInicio = (string)Session["FechaInicio"];
                   _vista._fechaFin = (string)Session["FechaFin"];
               }


               if (_vista._fechaInicio.Equals(string.Empty) && _vista._fechaFin.Equals(string.Empty)) //NO SIRVE ESTA VALIDACION
               {
                   _usuario = FabricaComando.CrearComandoObtenerUsuarioCedula(_tipo, _cedula).Ejecutar();

                   _ficticio = logica.ObtenerFacturaCedula(_cedula, _tipo);



               }
               else
               {

                   _usuario = logica.ObtenerUsuarioCedula(_tipo, _cedula);
                   _ficticio = logica.ObtenerFacturaCF(_cedula, _tipo, _fechaInicio, _fechaFin);
               }

               if (_usuario.Count == 0)
               {
                   _vista.falla.Text = "NO SE ENCONTRO EL USUARIO";
                   _vista.falla.Visible = true;
               }

               if ((_ficticio.Count == 0) && (_usuario.Count != 0))
               {
                   _vista.Exito.Text = "EL USUARIO NO POSEE FACTURAS POR PAGAR";
                   _vista.Exito.Visible = true;
               }

               cargarFicticio();
               cargarDatos();

           }

           public void AccionBoton()
           {
               LogicaCuentaPorCobrar logica = new LogicaCuentaPorCobrar();

               string estadoNew = _vista.estadoNuevo.SelectedItem.Value;
               string estadoActual = _vista._usuario[0].Estado;

               System.Diagnostics.Debug.WriteLine(estadoActual);

               if (estadoActual.Equals(estadoNew))
               {

                   _vista.falla.Text = "Seleccione un Estado Diferente";
                   _vista.falla.Visible = true;
                   _vista.Exito.Text = string.Empty;
               }
               else
               {
                   if (logica.ValidarEstado(_vista._usuario[0].Id, _vista.estadoNuevo.SelectedItem.Value))
                   {
                       if (logica.ModificarEstado(_vista._usuario[0].Id, _vista.estadoNuevo.SelectedItem.Value))
                       {

                           _vista.Exito.Text = "Operacion Realizada Exitosamente";
                           _vista.Exito.Visible = true;
                           _vista.estado.Text = _vista.estadoNuevo.SelectedItem.Value;

                       }
                       else
                       {
                           _vista.falla.Text = "Error Al Modificar en la Base de Datos";
                           _vista.falla.Visible = true;
                           _vista.Exito.Text = string.Empty;
                       }

                   }
                   else
                   {
                       _vista.falla.Text = "Estado Invalido";
                       _vista.falla.Visible = true;
                       _vista.Exito.Text = string.Empty;
                   }

               }

           }

           public void GridConsultarSelected()
           {
               if (_vista.GridConsultar.PageSize == 1)
               {
                   _index = 0;
               }
               else
               {
                   _index = (_vista.GridConsultar.PageIndex) * _vista.GridConsultar.PageSize;
               }

               Session["Factura"] = _vista._ficticio[GridConsultar.SelectedIndex + _index].NumeroFactura.ToString();
               Session["CedulaD"] = _vista.LabelCedula.Text;
               Session["Nombres"] = _vista.LabelNombre.Text;
               Session["Apellidos"] = _vista.LabelApellidos.Text;
               Session["NoCuenta"] = _vista._usuario[0].Id;
               Response.Redirect("DetalleFactura.aspx");
            

           }

           public void cargarFicticio()
           {
               DataTable table = new DataTable();


               table.Columns.Add("Numero Factura", typeof(string));
               table.Columns.Add("Fecha Emision", typeof(string));
               table.Columns.Add("Monto Total", typeof(string));
               table.Columns.Add("Total Abonado", typeof(string));
               table.Columns.Add("Saldo Deudor", typeof(string));

               foreach (Ficticia lafactura in _ficticio)
               {





                   table.Rows.Add(lafactura.NumeroFactura, lafactura.FechaEmitida.ToShortDateString(), lafactura.TotalFactura + " BsF", lafactura.TotalAbono + " BsF", lafactura.Deuda + " BsF");
                   _vista._total = _vista._total + lafactura.TotalFactura;
               }


               _vista.GridConsultar.DataSource = table;
               _vista.GridConsultar.DataBind();

           }
           /*
                   public void cargarTabla()
                   {
                       DataTable table = new DataTable();


                       table.Columns.Add("Numero Factura", typeof(string));
                       table.Columns.Add("Fecha Emision", typeof(string));
                       table.Columns.Add("Monto Total", typeof(string));


                       foreach (Factura lafactura in _factura)
                       {
                           table.Rows.Add(lafactura.getNro_Factura(),lafactura.getFecha_Emitida(),lafactura.getTotal_Factura());
                           this._numerofactura[i] = lafactura.getNro_Factura();
                           i++;
                       }


                       GridConsultar.DataSource = table;
                       GridConsultar.DataBind();
                       i = 0;
                   }
           
        

                    

           public void cargarDatos()
           {
               foreach (CuentaPorCobrar cuenta in _usuario)
               {
                   _vista.LabelCedula.Text = cuenta.TipoCedula + "-" + cuenta.Cedula;
                   _vista.LabelNombre.Text = cuenta.PrimerNombre + cuenta.Segundonombre;
                   _vista.LabelApellidos.Text = cuenta.Primerapellido + cuenta.Segundoapellido;
                   _vista.estado.Text = cuenta.Estado;
                   _vista.total.Text = this._total.ToString() + " BsF"; ;
               }
           }

           public void GridConsultarSelectedChanging()
           {
               _vista.GridConsultar.PageIndex = e.NewPageIndex;
               cargarFicticio();
           }

            */
        #endregion
        }
    }
}

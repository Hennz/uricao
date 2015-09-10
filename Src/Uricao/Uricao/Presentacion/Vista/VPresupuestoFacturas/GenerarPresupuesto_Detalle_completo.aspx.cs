using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Presentacion.Presentador.PPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.AccesoDeDatos.DAOS;
using System.Web.SessionState;

namespace Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas
{
    public partial class GenerarPresupuesto_Detalle_completo : System.Web.UI.Page
    {
        //    #region Atributos

        //    public List<Tratamiento> listaTratamientos;
        //    public Factura laFactura;
        //    public LogicaFactura logicaDeFacutra;
        //    private PresentadorGenerarFacturaDetalleCompleto _presentador;
        //    private Entidad _miFactura;
        //    private Comando<bool> _miComandoFacturaEntidad;
        //    DAOPresupuestoFactura manejador;

        //    #endregion

        //    # region Contrato

        //    public Label ALNumeroPresupuesto
        //    {
        //        get { return aLNumeroPresupuesto; }
        //        set { aLNumeroPresupuesto = value; }
        //    }

        //    public Label ALFechaPresupuessto //fecha factura
        //    {
        //        get { return aLFechaPresupuessto; }
        //        set { aLFechaPresupuessto = value; }
        //    }
        //    public Label ALNombre
        //    {
        //        get { return aLNombre; }
        //        set { aLNombre = value; }
        //    }

        //    public GridView AGPresupuesto
        //    {
        //        get { return aGPresupuesto; }
        //        set { aGPresupuesto = value; }
        //    }

        //    public Label ALSubtotal
        //    {
        //        get { return aLSubtotal; }
        //        set { aLSubtotal = value; }
        //    }

        //    public Label ALIVA
        //    {
        //        get { return aLIVA; }
        //        set { aLIVA = value; }
        //    }

        //    public Label ALTotal
        //    {
        //        get { return aLTotal; }
        //        set { aLTotal = value; }
        //    }

        //    public Label LObservaciones
        //    {
        //        get { return lObservaciones; }
        //        set { lObservaciones = value; }
        //    }

        //    public HttpSessionState Sesion
        //    {
        //        get { return Session; }
        //    }

        //    public void Redireccionar(string _ruta)
        //    {
        //        Response.Redirect(_ruta);
        //    }

        //    #endregion

        //    #region Métodos

        //    protected void Page_Load(object sender, EventArgs e)
        //    {

        //        laFactura = (Factura)(Session["la_Factura"]);
        //        listaTratamientos = (List<Tratamiento>)(Session["listado_agregado"]);
        //        LlenarDatos();

        //        for (int i = 0; i < listaTratamientos.Count; i++)
        //        {
        //            logicaDeFacutra = new LogicaFactura();
        //            listaTratamientos[i].Costo = logicaDeFacutra.CalculoDeCostoTotalTratamiento(listaTratamientos, i);

        //        }

        //        if (!IsPostBack)
        //        {
        //            LlenarListaDetalle();
        //            SubTotal();

        //        }
        //        LlenarTabla();

        //    }

        //    protected void LlenarListaDetalle()
        //    {
        //        _presentador.LlenarListaDetalle();
        //    }
        //    protected void SubTotal()
        //    {
        //        _presentador.SubTotal();


        //    }
        //    protected void LlenarDatos()
        //    {
        //        _presentador.LlenarDatos();

        //    }
        //    protected void LlenarTabla()
        //    {
        //        _presentador.LlenarTabla();
        //    }

        //    protected void aBBotonAceptar_Click(object sender, EventArgs e)
        //    {
        //        manejador = new DAOPresupuestoFactura();
        //        //debo implementar comando de RegresarIdUsuario
        //        int idUsuario = manejador.RegresarIdUsuario(laFactura.getCedula_Paciente());

        //        _miComandoFacturaEntidad = FabricaComando.CrearComandoAgregarFactura(laFactura, idUsuario);
        //        bool _resultado = _miComandoFacturaEntidad.Ejecutar(); ;

        //        if (_resultado)
        //        {
        //            Response.Redirect("GenerarFacturaOperacion.aspx");
        //        }
        //    }

        //    #endregion
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ETratamientos;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOPresupuestoFactura : iDAO
    {

        #region Consultar Facturas


        #region Code Behind de: ConsultarFactura.aspx

        /// <summary>
        /// Declaracion del método ConsultarFacturasRangoFechas
        /// </summary>
        /// <param name="_entidad"></param>
        /// <param name="_usuario"></param>
        /// <returns></returns>       
        List<Entidad> ConsultarFacturasRangoFechas(String fechaInicio, String fechaFin);

        List<Entidad> ConsultarFacturasTodas();

        Entidad ConsultarFacturaNumero(int nro_factura);


        #endregion Code Behind de: ConsultarFactura.aspx


        #region Code Behind de: ConsultaFactura_Detalle.aspx


        String ConsultarDireccionEstadoFactura(int idDireccion);
        
        String ConsultarDireccionCiudadFactura(int idDireccion);

        String ConsultarDireccionMunicipioFactura(int idDireccion);

        String ConsultarDireccionCalleFactura(int idDireccion);

        String ConsultarDireccionEdificioFactura(int idDireccion);

        List<Entidad> ConsultarDetalleFactura(int nro_factura);

        List<Entidad> ConsultarTratamientosListaDetalle(List<Entidad> listaDetalle);

        #endregion Code Behind de: ConsultaFactura_Detalle.aspx


        #region Metodos provenientes de: LogicaFactura.cs y DAOPresupuestoFactura

        /// <summary>
        /// Metodo para trabajar segun la clase dominio: TRATAMIENTO.
        /// Consulta y devuelve los datos de un TRATAMIENTO (busca segun: String idTratamiento).
        /// </summary>
        /// <param name="nombreTratamiento"></param>
        /// <returns></returns>
        Entidad SqlBuscarXIdTratamiento(int idTratamientoParametro);
        
        /// <summary>
        /// Metodo para buscar una Factura.
        /// Consulta y devuelve factura, dada la cedula de identidad del usuario que la paga (String CI).
        /// </summary>
        /// <param name="nombreTratamiento"></param>
        /// <returns></returns>
        List<Entidad> ConsultarFacturaXCI(String CI);

        /// <summary>
        /// Metodo para buscar una: cedula de identidad, dado el: numero de la factura de esa persona.
        /// </summary>
        /// <param name="nombreTratamiento"></param>
        /// <returns></returns>
        String ConsultarCedulaFactura(int nro_factura);


        #endregion Metodos provenientes de: LogicaFactura.cs y DAOPresupuestoFactura

        #endregion Consultar Facturas


        #region Consultar Presupuesto

        List<Entidad> ConsultarPresupuestosTodos();

        String ConsultarCedulaPresupuesto(int nro_presupuesto);

        List<Entidad> ConsultarPresupuestosRangoFechas(String fechaInicio, String fechaFin);

        Entidad ConsultarPresupuestoNumero(int nro_presupuesto);

        Entidad ConsultarPresupuestoXCI(String CI);

        #endregion

        #region Consultar Presupuesto Especifico

        Entidad ConsultarDatosBasicosUsuarioPresupuesto(int nro_presupuesto);

        List<Entidad> ConsultarDetallePresupuesto(int nro_presupuesto);

        #endregion

        #region Generar Facturas

        List<Entidad> SqlBuscarXNombreTramiento(string nombreTratamientoBuscar);
        bool AgregarFactura(Factura la_factura, int id_paciente);
        Int16 RegresarCostoTratamiento(int id_tratamiento);
        int RegresarIdDireccionDeUsuario(int idUsuario);
        int RegresarIdUsuario(string cedula);
        #endregion

        #region Generar Presupuestos

        bool validarUsuario(string cedulaUsuario, string tipoCi);

        bool AgregarPresupuesto(Entidad elPresupuesto, int idUsuario);

        string regresarDatosUsuario(string cedulaUsuario, string tipoCi);

        #endregion

    }
}
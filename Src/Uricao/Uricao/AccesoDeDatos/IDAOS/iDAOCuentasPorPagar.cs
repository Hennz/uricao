using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ECuentasPorPagar;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOCuentasPorPagar : iDAO
    {
        List<Entidad> ListaCuentasPorPagarEntreFechas(string fechaInicio, string fechaFin);
        Entidad ConsultarCuentaPorPagar(string idCuentaPorPagar);
        List<Entidad> MostrarListaCuentasPorPagar(string nombreProveedor);
        List<Entidad> AbonarConsultarCuentasPorPagarFechas(string fechaInicio, string fechaFin);
        List<Entidad> AbonarConsultarCuentasPorPagar(string fechaInicio, string fechaFin, string proveedor);
        bool CambiarEstatusCpp(Entidad miCuenta);
        List<Entidad> ActivarDesactivarMostrarListaCuentasPorPagarProveedor(string nombreProveedor);
        List<Entidad> ConsultarCuentasPorPagarFechasActivar(string fechai, string fechaf);
        bool ActivarDesactivarCpp(Entidad miCuenta);
        List<Entidad> ConsultarCuentasPorPagarFechasProveedorActivar(string fechai, string fechaf, string proveedor);
        List<Entidad> MostarCuentasPorPagarFechasProveedor(string fechai, string fechaf, string proveedor);
        bool InsertarCuentasPorPagar(Entidad miCuentaPorPagar);
        bool ModificarCuentaPorPagar(Entidad cuentaPP);
        Entidad llenarAbonarCpp2(string nombreProveedor, Int64 codigoCuenta);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.Entidades.EAbonos;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.EEntidad;
namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOCuentasPorCobrar : iDAO
    {
        List<Entidad> consultarUsuarioCedula(string tipo, string cedula);
        List<Entidad> BuscarAbonos(int idfactura);
        List<Entidad> consultarFacturaCF(string fechainicio, string fechafin, string cedula, string tipo);
        Entidad consultarCuenta(int idCuenta);
        List<Entidad> consultarFacturaCedula(string cedula, string tipo);
        List<Entidad> consultarUsuarioFechas(string fechainicio, string fechafin);
        List<Entidad> consultarCuentaCobrarConStoredProcedure();
        List<Entidad> consultarDetalleFactura(int factura);
        Entidad consultarTotalesAbonoFactura(int cuenta);
        bool ModificarEstado(int idCuenta, string estado);


    }
}
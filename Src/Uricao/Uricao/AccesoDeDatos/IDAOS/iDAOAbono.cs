using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.Entidades.EAbonos;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOAbono : iDAO
    {

        bool AgregarPrimerAbono(Entidad _abono);
        bool AgregarAbonoCC(Entidad _abono);
        Entidad ConsultarAbono(Entidad _abono);
        double ConsultarDeuda(int idFactura);
        int CantidadAbonos(int idFactura);
        bool agregarAbono(Entidad miAbono, Int64 idCuentaPP);
        List<Entidad> llenarGridAbonos(string nombreProveedor, Int64 codigoCuenta);

    }
}
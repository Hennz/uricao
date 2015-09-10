using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.AccesoDeDatos.DAOS;

namespace Uricao.AccesoDeDatos.FabricaDAOS
{
    public class FabricaDAOSQLSERVER : FabricaDAO
    {
        private static FabricaDAO fabricaDAOSQLServer;

        private FabricaDAOSQLSERVER()
        { }

        public static FabricaDAO getInstacia()
        {
            if (fabricaDAOSQLServer == null)
            {
                fabricaDAOSQLServer = new FabricaDAOSQLSERVER();
            }
            return fabricaDAOSQLServer;
        }

        public override iDAOHistoriaClinica CrearDAOHistoriaClinica()
        {
            return new DAOHistoriaClinica();
        
        }

        public override iDAOAgendaCitas CrearDAOAgendaCitas()
        {
            return new DAOAgendaCitas();

        }

        public override iDAOUsuario CrearDAOUsuario()
        {
            return new DAOUsuario();

        }

        public override iDAORol CrearDAORol()
        {
            return new DAORol();

        }

        #region PresupuestoFacturas

        public override iDAOPresupuestoFactura CrearDAOPresupuestoFactura()
        {
            return new DAOPresupuestoFactura();
        }

        #endregion PresupuestoFacturas
        #region Cuentas por Cobrar
        public override iDAOCuentasPorCobrar CrearDAOCuentasPorCobrar()
        {
            return new DAOCuentasPorCobrar();
        }
        #endregion Cuentas por Cobrar
        #region CuentasPorPagar

        public override iDAOCuentasPorPagar CrearDAOCuentasPorPagar()
        {
            return new DAOCuentasPorPagar();
        }

        #endregion CuentasPorPagar

        #region Abono

        public override iDAOAbono CrearDAOAbono()
        {
            return new DAOAbono();
        }

        #endregion Abono

        #region ProductosInventario

        public override iDAOProducto CrearDAOProducto()
        {
            return new DAOProducto();
        }

        public override iDAOInventario CrearDAOInventario()
        {
            return new DAOInventario();
        }

        #endregion 

        #region Proveedor

        public override iDAOProveedor CrearDAOProveedor()
        {
            return new DAOProveedor();
        }

        #endregion

        #region Empleado

        public override iDAOEmpleado CrearDAOEmpleado()
        {
            return new DAOEmpleado();
        }

        #endregion Empleado

        #region Tratamiento

        public override iDAOTratamiento CrearDAOTratamiento()
        {
            return new DAOTratamiento();
        }

        public override iDAOImplemento CrearDAOImplemento()
        {
            return new DAOImplemento();
        }


        #endregion Tratamiento
    
    }
}
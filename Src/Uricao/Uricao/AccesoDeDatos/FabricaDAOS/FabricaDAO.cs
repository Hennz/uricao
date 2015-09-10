using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.IDAOS;


namespace Uricao.AccesoDeDatos.FabricaDAOS
{
    public abstract class FabricaDAO 
    {
         public FabricaDAO()
        { }

        public static FabricaDAO CrearFabricaDeDAO(int tipoFabrica)
        {
            switch (tipoFabrica)
            {
                case 1:
                    return FabricaDAOSQLSERVER.getInstacia();
                case 2:
                    //return FabricaDAOOracle.getInstancia();
                default:
                    return null;
            }

        }
        
       
        

        #region Abono
        public abstract iDAOAbono CrearDAOAbono();
        #endregion

        #region Agenda Citas
        public abstract iDAOAgendaCitas CrearDAOAgendaCitas();
        #endregion

        #region Bancos

        #endregion

        #region Cuentas Por Cobrar
        public abstract iDAOCuentasPorCobrar CrearDAOCuentasPorCobrar();
        #endregion

        #region Cuentas Por Pagar
        
        public abstract iDAOCuentasPorPagar CrearDAOCuentasPorPagar();
        #endregion

        #region Empleados

        public abstract iDAOEmpleado CrearDAOEmpleado();

        #endregion

        #region Historia Paciente
       
        public abstract iDAOHistoriaClinica CrearDAOHistoriaClinica();

        #endregion

        #region Presupuesto Facturas

        public abstract iDAOPresupuestoFactura CrearDAOPresupuestoFactura();

        #endregion

        #region Productos Inventario

        public abstract iDAOProducto CrearDAOProducto();
        public abstract iDAOInventario CrearDAOInventario();

        #endregion

        #region Proveedores

        public abstract iDAOProveedor CrearDAOProveedor();

        #endregion

        #region Roles Usuarios

        public abstract iDAOUsuario CrearDAOUsuario();

        public abstract iDAORol CrearDAORol();

        #endregion

        #region Tratamientos

        public abstract iDAOTratamiento CrearDAOTratamiento();
        public abstract iDAOImplemento CrearDAOImplemento();


        #endregion
    }

    



}

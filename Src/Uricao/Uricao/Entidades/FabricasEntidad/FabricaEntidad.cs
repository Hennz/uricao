using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EBancos;
using Uricao.Entidades.EHistoriaPaciente;
using Uricao.Entidades.EAgendaCitas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.Entidades.EAbonos;
using Uricao.Entidades.EProductosInventario;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EEmpleados;
using Uricao.Entidades.ECuentasPorCobrar;
namespace Uricao.Entidades.FabricasEntidad
{
    public class FabricaEntidad
    {
        #region Bancos
        
        #endregion

        #region Abono
        public static Entidad CrearAbono()
        {
            return new Abono();
        }
        #endregion

        #region Agenda Citas
        public static Cita NuevaCita() 
        {
            return new Cita();
        }
        #endregion

        #region Cuentas Por Cobrar
        public static CuentaPorCobrar NuevaCuentaPorCobrar()
        {
            return new CuentaPorCobrar();
        }
        public static Detalle NuevoDetalle()
        {
            return new Detalle();
        }
        public static Ficticia NuevaFicticia()
        {
            return new Ficticia();
        }
        public static Totales NuevosTotales()
        {
            return new Totales();
        }
        #endregion

        #region Cuentas Por Pagar
        public static Entidad CrearCuentaPorPagar()
        {
            return new CuentaPorPagar();
        }
        #endregion

        #region Empleados

        public static Entidad NuevoEmpleado()
        {
            Empleado _empleado = new Empleado();
            List<string> lista = new List<string>();
            _empleado.Telefono = lista;
            return _empleado;
        }

        public static Entidad NuevaDireccion()
        {
            return new Direccion();
        }

		public static Entidad NuevaDireccion(string tipo)
        {
            Direccion detalle = new Direccion();
            Direccion ciudad = new Direccion();
            Direccion estado = new Direccion();
            Direccion pais = new Direccion();

            if (tipo.Equals("Detalle"))
            {
                detalle.Fk_dir = ciudad;
                ciudad.Fk_dir = estado;
                estado.Fk_dir = pais; 
            }
            return detalle;
        }

        public static List<Entidad> NuevaListaEmpleados()
        {
            return new List<Entidad>();
        }
		
        #endregion

        #region Historia Paciente


        public static Entidad NuevaHistoria()
        {
            return new HistoriaClinica();
        }
        public static Entidad NuevoDetalleSecuencia()
        {
            return new DetalleSecuencia();
        }

        public static Entidad NuevoAntecedente()
        {
            return new Antecedente();
        }
            
        #endregion

        #region Presupuesto Facturas

        public static Entidad CrearFactura()
        {
            return new Factura();
        }

        public static Entidad CrearDetalle_Presupuesto_Factura()
        {
            return new Detalle_Presupuesto_Factura();
        }

        public static Entidad CrearPresupuesto()
        {
            return new Presupuesto();
        }


        #endregion

        #region Productos Inventario
        public static Entidad NuevoProducto()
        {
            return new Producto();
        }

        public static Entidad NuevoLote()
        {
            return new Lote();
        }

        public static Entidad NuevoConsumo()
        {
            return new Consumo();
        }
        #endregion

        #region Proveedores

        public static Entidad NuevoProveedor()
        {
            return new Proveedor();
        }

        public static Entidad NuevoProveedor(String Rif, String Nombre, Int16 Direccion, String Estado)
        {
            return new Proveedor(Rif, Nombre, Direccion, Estado);
        }
        public static Entidad NuevoContacto()
        {
            return new Contacto();
        }

        public static Entidad NuevoTelefono()
        {
            return new Telefono();
        }
        #endregion

        #region Roles Usuarios
       
        public static Entidad NuevaUsuario()
        {
            return new Usuario();
        }

        public static Entidad NuevoRol()
        {
            return new Rol();
        }

        public static Usuario NuevoCliente()
        {
            return new Cliente();
        }
        #endregion

        #region Tratamientos

        public static Entidad NuevoTratamiento()
        {
            return new Tratamiento();
        }

        public static Entidad NuevoImplemento()
        {
            return new Implemento();
        }


        public static Entidad NuevoImplementoCompleto(Int16 idTratamiento, Int16 idProducto, Int16 prioridad, 
                                                       String tipoProducto, Int16 cantidad, List<Producto> productoAsociado)
        {
            return new Implemento(idTratamiento, idProducto,prioridad, tipoProducto, cantidad, productoAsociado);
        }

        public static Entidad NuevoTratamientoCompleto(Int16 Id, String Nombre, Int16 Duracion, Int16 Costo,
                                                        String Descripcion, String Explicacion, String Estado) 
        {

            return new Tratamiento(Id, Nombre, Duracion, Costo, Descripcion, Explicacion, Estado);
        }

        #endregion

   
    }
}
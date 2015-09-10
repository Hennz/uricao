using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Comandos.AgendaCitas;
using Uricao.LogicaDeNegocios.Comandos.Usuario;
using Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas;
using Uricao.LogicaDeNegocios.Comandos.CuentasPorPagar;
using Uricao.LogicaDeNegocios.Comandos.Abono;
using Uricao.LogicaDeNegocios.Comandos.HistoriaClinica;
using Uricao.Entidades.EProveedores;
using Uricao.LogicaDeNegocios.Comandos.ProductosInventario.Productos;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Comandos.Empleado;
using Uricao.LogicaDeNegocios.Comandos.Rol;
using Uricao.LogicaDeNegocios.Comandos.Proveedores;
using Uricao.LogicaDeNegocios.Comandos.Implementos;
using Uricao.LogicaDeNegocios.Comandos.CTratamientos;
using Uricao.LogicaDeNegocios.Comandos.CuentasPorCobrar;



namespace Uricao.LogicaDeNegocios.Fabricas
{
    public class FabricaComando
    {

        #region Abono

        #endregion

        #region Agenda Citas
        
        public static ComandoAgregarCita CrearComandoAgregarCita(Cita _cita, String _cedulaPaciente, String _diaSemana)
        {
            return new ComandoAgregarCita(_cita, _cedulaPaciente, _diaSemana);
        }
        
        public static ComandoConsultarListaTratamientos CrearComandoConsultarListaTratamientos()
        {
            return new ComandoConsultarListaTratamientos();
        }

        public static ComandoCancelarCita CrearComandoCancelarCita(int idCita)
        {
            return new ComandoCancelarCita(idCita);
        }

        public static ComandoConfirmarCita CrearComandoConfirmarCita(int idCita)
        {
            return new ComandoConfirmarCita(idCita);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarCita()
        {
            return new ComandoConsultarCita();
        }

        public static Comando<bool> CrearComandoModificarCita(int idCita, String fecha, int horaInicio, int horaFin, String tratamiento, String nombreMedico, String apellidoMedico, String diaSemana)
        {
            return new ComandoModificarCita(idCita, fecha, horaInicio, horaFin, tratamiento, nombreMedico, apellidoMedico, diaSemana);
        }

        public static Comando<int[]> CrearComandoHorarioDisponibleMedicoFecha(String _nombreMedico, String _apellidoMedico, DateTime _fecha, String _tratamiento, String _diaSemana)
        {
            return new ComandoConsultarHorarioDisponibleMedicoFecha(_nombreMedico, _apellidoMedico, _fecha, _tratamiento, _diaSemana);
        }

        public static ComandoConsultarCitaFecha CrearComandoConsultarCitaFecha(String _fecha)
        {
            return new ComandoConsultarCitaFecha(_fecha);
        }

        public static ComandoConsultarCitaRangoFecha CrearComandoConsultarCitaRangoFecha(String _fechaInicio, String _fechaFin)
        {
            return new ComandoConsultarCitaRangoFecha(_fechaInicio, _fechaFin);
        }

        public static ComandoConsultarCitaPorCedulaUsuario CrearComandoConsultarCitaPorCedulaUsuario(String _cedulaPaciente)
        {
            return new ComandoConsultarCitaPorCedulaUsuario(_cedulaPaciente);
        }

        public static ComandoConsultarCitaPorNombreMedico CrearComandoConsultarCitaPorNombreMedico(String _nombre, String _apellido)
        {
            return new ComandoConsultarCitaPorNombreMedico(_nombre, _apellido);
        }
        #endregion

        #region Bancos

        #endregion

        #region Cuentas Por Cobrar
        public static Comando<bool> CrearComandoValidarEstado(int idCuenta, string estadoNuevo)
        {
            return new ComandoValidarEstado(idCuenta, estadoNuevo);
        }
        public static Comando<List<Entidad>> CrearComandoBuscarAbonos(int idfactura)
        {
            return new ComandoBuscarAbonos(idfactura);
        }
        public static Comando<double> CrearComandoCalcularDeudaTotal()
        {
            return new ComandoCalcularDeudaTotal();
        }
        public static Comando<List<Entidad>> CrearComandoconsultarDetalleFactura(int factura)
        {
            return new ComandoconsultarDetalleFactura(factura);
        }
        public static Comando<bool> CrearComandoModificarEstado(int idCuenta, string estadoNuevo)
        {
            return new ComandoModificarEstado(idCuenta, estadoNuevo);
        }
        public static Comando<List<Entidad>> CrearComandoObtenerCuentas()
        {
            return new ComandoObtenerCuentas();
        }
        public static Comando<List<Entidad>> CrearComandoObtenerFacturaCedula(string cedula, string tipo)
        {
            return new ComandoObtenerFacturaCedula(cedula, tipo);
        }
        public static Comando<List<Entidad>> CrearComandoObtenerFacturaCF(string cedula, string tipo, string fechainicio, string fechafin)
        {
            return new ComandoObtenerFacturaCF(cedula, tipo, fechainicio, fechafin);
        }
        public static Comando<List<Entidad>> CrearComandoObtenerUsuarioCedula(string tipo, string cedula)
        {
            return new ComandoObtenerUsuarioCedula(tipo, cedula);
        }
        public static Comando<List<Entidad>> CrearComandoObtenerUsuarioFechas(string fechainicio, string fechafin)
        {
            return new ComandoObtenerUsuarioFechas(fechainicio, fechafin);
        }



        #endregion

        #region Cuentas Por Pagar
        public static Comando<bool> CrearComandoAgregarAbono(Entidad abono, Int64 monto)
        {
            return new ComandoAgregarAbono(abono, monto);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarEntreFechas(string fechaInicio, string fechaFin)
        {
            return new ComandoConsultarEntreFechas(fechaInicio, fechaFin);
        }

        public static Comando<List<Entidad>> CrearComandoAbonarObtenerCuentasPorPagarProveedor(string proveedor)
        {
            return new ComandoAbonarObtenerCuentasPorPagarProveedor(proveedor);
        }
        public static Comando<List<Entidad>> CrearComandoAbonarConsultarCuentasPorPagarFechas(string fechaInicio, string fechaFin)
        {
            return new ComandoAbonarConsultarCuentasPorPagarFechas(fechaInicio, fechaFin);
        }

        public static Comando<List<Entidad>> CrearComandoAbonarConsultarCuentasPorPagar(string fechaInicio, string fechaFin, string proveedor)
        {
            return new ComandoAbonarConsultarCuentasPorPagar(fechaInicio, fechaFin, proveedor);
        }

        public static Comando<bool> CrearComandoCambiarEstatusCpp(Entidad CuentaPP)
        {
            return new ComandoCambiarEstatusCpp(CuentaPP);
        }
        public static Comando<List<Entidad>> CrearComandollenarGridAbonos(string abono, Int64 monto)
        {
            return new ComandollenarGridAbonos(abono, monto);
        }

        public static Comando<List<Entidad>> CrearComandoActivarDesactivarObtenerCuentasPorPagarProveedor(string proveedor)
        {
            return new ComandoActivarDesactivarObtenerCuentasPorPagarProveedor(proveedor);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarCuentasPorPagarFechasActivar(string fechaInicio, string fechaFin)
        {
            return new ComandoConsultarCuentasPorPagarFechasActivar(fechaInicio, fechaFin);
        }

        public static Comando<bool> CrearComandoActivarDesactivarCpp(Entidad CuentaPP)
        {
            return new ComandoActivarDesactivarCpp(CuentaPP);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarCuentasPorPagarFechasProveedorActivar(string fechaInicio, string fechaFin, string proveedor)
        {
            return new ComandoConsultarCuentasPorPagarFechasProveedorActivar(fechaInicio, fechaFin, proveedor);
        }

        public static Comando<List<Entidad>> CrearComandoMostrarListaCuentasPorPagar(string proveedor)
        {
            return new ComandoMostrarListaCuentasPorPagar(proveedor);
        }

        public static Comando<List<Entidad>> CrearComandoListaCuentasPorPagarEntreFechas(string fechaInicio, string fechaFin)
        {
            return new ComandoListaCuentasPorPagarEntreFechas(fechaInicio, fechaFin);
        }

        public static Comando<List<Entidad>> CrearComandoMostarCuentasPorPagarFechasProveedor(string fechaInicio, string fechaFin, string proveedor)
        {
            return new ComandoMostarCuentasPorPagarFechasProveedor(fechaInicio, fechaFin, proveedor);
        }
        public static Comando<bool> CrearComandoInsertarCuentasPorPagar(Entidad miCuentaPorPagar)
        {
            return new ComandoInsertarCuentasPorPagar(miCuentaPorPagar);
        }
        public static Comando<Entidad> CrearComandollenarAbonarCpp2(string nombreProveedor, Int64 codigoCuenta)
        {
            return new ComandollenarAbonarCpp2(nombreProveedor, codigoCuenta);
        }

        public static Comando<Entidad> CrearComandoConsultarCuentaPorPagar(string idCuentaPorPagar)
        {
            return new ComandoConsultarCuentaPorPagar(idCuentaPorPagar);
        }
        public static Comando<bool> CrearComandoModificarCuentaPorPagar(Entidad miCuentaPorPagar)
        {
            return new ComandoModificarCuentaPorPagar(miCuentaPorPagar);
        }

        #endregion

        #region Empleados

        public static Comando<List<Entidad>> CrearComandoConsultarTodosEmpleados(string nombreProcedimiento)
        {
            return new ComandoConsultarTodosEmpleados(nombreProcedimiento);
        }
        public static Comando<bool> CrearComandoAgregarEmpleado(Entidad empleado, Entidad direccion)
        {
            return new ComandoModificarEmpleado(empleado, direccion);
        }

        public static Comando<bool> CrearComandoModificarEmpleado(Entidad empleado, Entidad direccion)
        {
            return new ComandoModificarEmpleado(empleado, direccion);
        }

        public static Comando<bool> CrearComandoCambiarEstadoEmpleado(Entidad _empleado)
        {
            return new ComandoCambiarEstadoEmpleado(_empleado);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarPais()
        {
            return new ComandoConsultarPais();
        }

        public static Comando<List<Entidad>> CrearComandoConsultarEstado(Entidad _pais)
        {
            return new ComandoConsultarEstado(_pais);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarCiudad(Entidad _estado)
        {
            return new ComandoConsultarCiudad(_estado);
        }
        #endregion

        #region Historia Paciente

        public static Comando<List<Entidad>> CrearComandoConsultarTodasHistoriaClinica()
        {
            return new ComandoConsultarTodasHistoriaClinica();
        }

        public static Comando<List<Entidad>> CrearComandoConsultarHistoriaClinica(String nombre, String apellido, String cedula, int idHistoria)
        {
            return new ComandoConsultarHistoriaClinica(nombre, apellido, cedula, idHistoria);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarSecuencia(int idSecuencia)
        {
            return new ComandoConsultarSecuencia(idSecuencia);
        }

        public static Comando<bool> CrearComandoAgregarHistoriaClinica(Entidad historiaClinica)
        {
            return new ComandoAgregarHistoriaClinica(historiaClinica);
        }

        public static Comando<bool> CrearComandoAgregarAntecedente(List<String> _Respuestas, int _idHistoriaClinica)
        {
            return new ComandoAgregarAntecedente(_Respuestas, _idHistoriaClinica);
        }

        public static Comando<bool> CrearComandoAgregarSecuencia(List<Entidad> secuencias, int idDiente)
        {
            return new ComandoAgregarSecuencia(secuencias, idDiente);
        }

        public static Comando<bool> CrearComandoActivarDesactivarHistoriaClinica(int idHistoriaClinica, String estado)
        {
            return new ComandoActivarDesactivarHistoriaClinica(idHistoriaClinica, estado);
        }

        public static Comando<List<Entidad>> crearComandoConsultarAntecedente(int idHistoriaClinica)
        {
            return new ComandoConsultarAntecedente(idHistoriaClinica);
        }

        public static Comando<bool> CrearComandoModificarHistoriaClinica(Entidad historiaClinica)
        {
            return new ComandoModificarHistoriaClinica(historiaClinica);
        }

        public static Comando<bool> CrearComandoModificarAntecedente(List<Entidad> _respuestas)
        {
            return new ComandoModificarAntecedente(_respuestas);
        }


        public static Comando<bool> CrearComandoModificarSecuencia(List<Entidad> _secuencia)
        {
            return new ComandoModificarSecuencia(_secuencia);
        }

        public static Comando<bool> CrearComandoActivarDesactivarSecuencia(int Secuencia, String estado)
        {
            return new ComandoActivarDesactivarSecuencia(Secuencia, estado);
        }

        public static Comando<int> CrearComandoBuscarUltimaHistoria()
        {
            return new ComandoBuscarUltimaHistoria();
        }

        public static Comando<Entidad> CrearComandoConsultarSecuenciaXid(int _secuencia)
        {
            return new ComandoConsultarSecuenciaXid(_secuencia);
        }

        #endregion

        #region Presupuesto Facturas


        #region Consultar Factura 1

        public static Comando<List<Entidad>> CrearComandoObtenerListaFacturaFechas(string fechaInicio, string fechaFin)
        {
            return new ComandoObtenerListaFacturaFechas(fechaInicio, fechaFin);
        }


        public static Comando<List<Entidad>> CrearComandoConsultarFacturasTodas()
        {
            return new ComandoConsultarFacturasTodas();
        }


        public static Comando<Entidad> CrearComandoConsultarFacturasNumero(int numeroFactura)
        {
            return new ComandoConsultarFacturasNumero(numeroFactura);
        }

        public static Comando<List<Entidad>> CrearComandoObtenerFacturaXCI(String ciUsuario)
        {
            return new ComandoObtenerFacturaXCI(ciUsuario);
        }

        public static Comando<String> CrearComandoConsultarCedulaFactura(int nro_factura)
        {
            return new ComandoConsultarCedulaFactura(nro_factura);
        }


        #endregion Consultar Factura 1


        #region Consultar Factura_Detalle 2


        public static Comando<String> CrearComandoConsultarDireccionEstadoFactura(int idDireccion)
        {
            return new ComandoConsultarDireccionEstadoFactura(idDireccion);

        }

        public static Comando<String> CrearComandoConsultarDireccionCiudadFactura(int idDireccion)
        {
            return new ComandoConsultarDireccionCiudadFactura(idDireccion);

        }

        public static Comando<String> CrearComandoConsultarDireccionMunicipioFactura(int idDireccion)
        {
            return new ComandoConsultarDireccionMunicipioFactura(idDireccion);
        }

        public static Comando<String> CrearComandoConsultarDireccionCalleFactura(int idDireccion)
        {
            return new ComandoConsultarDireccionCalleFactura(idDireccion);
        }

        public static Comando<String> CrearComandoConsultarDireccionEdificioFactura(int idDireccion)
        {
            return new ComandoConsultarDireccionEdificioFactura(idDireccion);
        }


        //public static Comando<List<Detalle_Presupuesto_Factura>> ConsultarDetalleFactura(int nro_factura)
        public static Comando<List<Entidad>> CrearComandoConsultarDetalleFactura(int nro_factura)
        {
            return new ComandoConsultarDetalleFactura(nro_factura);
        }


        #endregion Consultar Factura_Detalle 2



        #region Consultar Presupuestos

        public static Comando<List<Entidad>> CrearComandoConsultarPresupuestosTodos()
        {
            return new ComandoConsultarPresupuestosTodos();
        }

        public static Comando<String> CrearComandoConsultarCedulaPresupuesto(int nro_presupuesto)
        {
            return new ComandoConsultarCedulaPresupuesto(nro_presupuesto);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarPresupuestosRangoFechas(String fechaInicio, String fechaFin)
        {
            return new ComandoConsultarPresupuestosRangoFechas(fechaInicio, fechaFin);
        }

        public static Comando<Entidad> CrearComandoConsultarPresupuestoNumero(int nro_presupuesto)
        {
            return new ComandoConsultarPresupuestoNumero(nro_presupuesto);
        }

        public static Comando<Entidad> CrearComandoConsultarPresupuestoXCI(String CI)
        {
            return new ComandoConsultarPresupuestoXCI(CI);
        }

        #endregion

        #region GenerarFactura_Detalle

        public static Comando<Entidad> CrearComandoConsultarFacturaXIdTratamiento(int idTratamientoParametro)
        {
            return new ComandoConsultarTratamientoXId(idTratamientoParametro);
        }

        #endregion GenerarFactura_Detalle

        #region Consultar Presupuesto Especifico

        public static Comando<Entidad> CrearComandoConsultarDatosBasicosUsuarioPresupuesto(int nro_presupuesto)
        {
            return new ComandoConsultarDatosBasicosUsuarioPresupuesto(nro_presupuesto);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarDetallePresupuesto(int nro_presupuesto)
        {
            return new ComandoConsultarDetallePresupuesto(nro_presupuesto);
        }
        
        #endregion

        #region Generar Factura
        public static Comando<List<Entidad>> CrearComandoRegresarListadoXNombre(String nombreTratamiento)
        {
            return new ComandoRegresarListadoXNombre(nombreTratamiento);
        }
        public static Comando<bool> CrearComandoAgregarFactura(Factura la_factura, int id_paciente)
        {
            return new ComandoAgregarFactura(la_factura, id_paciente);
        }

        public static Comando<double> CrearComandoSubtotalFactura(Factura la_factura)
        {
            return new ComandoSubtotalFactura(la_factura);
        }

        public static Comando<int> CrearComandoRegresarCostoTratamiento(int id_tratamiento, List<Tratamiento> listado_tratamiento, int posicion)
        {
            return new ComandoRegresarCostoTratamiento(id_tratamiento, listado_tratamiento, posicion);
        }
        public static Comando<int> CrearComandoRegresaIdDireccionUsuario(int idUsuario)
        {
            return new ComandoRegresaIdDireccionUsuario(idUsuario);
        }
        public static Comando<int> CrearComandoRegresarIdUsuario(String cedula)
        {
            return new ComandoRegresarIdUsuario(cedula);
        }
        #endregion

        #region Generar Presupuesto
        
        public static Comando<bool> CrearComandovalidarUsuario(string cedulaUsuario, string tipoCi)
        {
            return new ComandovalidarUsuario(cedulaUsuario,tipoCi);
        }

        public static Comando<bool> CrearComandoAgregarPresupuesto(Entidad elPresupuesto, int idUsuario)
        {
            return new ComandoAgregarPresupuesto(elPresupuesto, idUsuario);
        }

        public static Comando<int> CrearComandoSubtotalPresupuesto(List<Tratamiento> listaTratamiento)
        {
            return new ComandoSubtotalPresupuesto(listaTratamiento);
        }

        public static Comando<String> CrearComandoregresarDatosUsuario(String cedulaUsuario, String tipoCi)
        {
            return new ComandoregresarDatosUsuario(cedulaUsuario, tipoCi);
        }

        
        
        #endregion

        #endregion

        #region Productos Inventario
        public static Comando<Boolean> CrearComandoAgregarProducto(Entidad producto)
        {
            return new ComandoAgregarProducto(producto);
        }

        public static Comando<List<String>> CrearComandoConsultarCategoria()
        {
            return new ComandoConsultarCategoria();
        }

        public static Comando<List<String>> CrearComandoConsultarMarcasXProveedor(String proveedor)
        {
            return new ComandoObtenerMarcasXProveedor(proveedor);
        }

        public static Comando<Boolean> CrearComandoAgregarDetalleProducto(Entidad producto)
        {
            return new ComandoAgregarDetalleProducto(producto);
        }
        public static Comando<List<Entidad>> CrearComandoObtenerProductos()
        {
            return new ComandoObtenerProductos();
        }

        public static Comando<List<Entidad>> CrearComandoObtenerProductosDetallados(Entidad Producto)
        {
            return new ComandoObtenerProductosDetallados(Producto);
        }

        public static Comando<Boolean> CrearComandoEditarProducto(Entidad Producto)
        {
            return new ComandoEditarProducto(Producto);
        }

        public static Comando<Boolean> CrearComandoEditarProductoGenerico(Entidad Producto, String NombreViejo)
        {
            return new ComandoEditarProductoGenerico(Producto, NombreViejo);
        }

        #endregion

        #region Proveedores
        public static Comando<List<Entidad>> CrearComandoConsultarTodosProveedores()
        {
            return new ComandoConsultarTodosProveedores();
        }

        public static Comando<Boolean> CrearComandoAgregarContacto(String nombre, String apellido, String correo, Int16 id)
        {
            return new ComandoAgregarContacto(nombre, apellido, correo, id);
        }

        public static Comando<Boolean> CrearComandoAgregarProveedor(String rif, String nombre, Int16 direccion)
        {
            return new ComandoAgregarProveedor(rif, nombre, direccion);
        }

        public static Comando<Entidad> CrearComandoConsultarIdProveedor(String rif, String nombre, Int16 direccion)
        {
            return new ComandoConsultarIdProveedor(rif, nombre, direccion);
        }

        public static Comando<Entidad> CrearComandoConsultarContacto(Entidad _contacto, Int16 id)
        {
            return new ComandoConsultarContacto(_contacto, id);
        }

        public static Comando<Entidad> CrearComandoConsultarProveedor(String rif, String nombre, Int16 direccion)
        {
            return new ComandoConsultarProveedor(rif, nombre, direccion);
        }

        public static Comando<Entidad> CrearComandoConsultarProveedoresPorNombre(String nombre)
        {
            return new ComandoConsultarProveedoresPorNombre(nombre);
        }

        public static Comando<Entidad> CrearComandoConsultarProveedoresPorRif(String rif)
        {
            return new ComandoConsultarProveedoresPorRif(rif);
        }

        public static Comando<Boolean> CrearComandoModificarProveedor(Int16 id, String rif, String nombre, Int16 direccion)
        {
            return new ComandoModificarProveedor(id, rif, nombre, direccion);
        }

        public static Comando<Entidad> CrearComandoVerContacto(String rif, Int16 posicion)
        {
            return new ComandoVerContacto(rif, posicion);
        }

        #endregion

        #region Roles Usuarios
        public static Comando<List<Entidad>> CrearComandoConsultarUsuario()
        {
            return new ComandoConsultarUsuario();
        }

        //public static Comando<List<Entidad>> CrearComandoConsultarUsuarioParametrizado(string parametro, int seleccion)
        //{
        //    return new ComandoConsultarUsuarioParametrizado(parametro, seleccion);
        //}

        public static Comando<bool> CrearComandoAgregarUsuario(Entidad usuario)
        {
            return new ComandoAgregarUsuario(usuario);
        }

        public static Comando<bool> CrearComandoModificarUsuario(Entidad usuario)
        {
            return new ComandoModificarUsuario(usuario);
        }
      

        public static Comando<List<Entidad>> CrearComandoConsultarRol(int idRol, String nombreRol, String descripcionRol, Boolean estadoRol)
        {
            return new ComandoConsultarRol(idRol, nombreRol, descripcionRol, estadoRol);
        }
        public static Comando<bool> CrearComandoModificarRol(Entidad rol)
        {
            return new ComandoModificarRol(rol);
        }
		
        #endregion


        #region Tratamientos


        #region Implementos

        //AGREGAR IMPLEMENTO
        public static Comando<bool> CrearComandoAgregarImplemento(List<Entidad> implemento)
        {
            return new ComandoAgregarImplemento(implemento);
        }


        //CONSULTAR LISTA IMPLEMENTO
        public static Comando<List<Entidad>> CrearComandoConsultarListaImplementos(Entidad miTratamiento)
        {
            return new ComandoConsultarListaImplementos(miTratamiento);
        }

        //ELIMINAR TRATAMIENTO IMPLEMENTO
        public static Comando<bool> CrearComandoEliminarTratamientoImplementos(Entidad miTratamiento)
        {
            return new ComandoEliminarTratamientoImplementos(miTratamiento);
        }

        //CONSULTAR IMPLEMENTO POR NOMBRE
        public static Comando<List<Entidad>> CrearComandoConsultarImplementoPorNombre(string nombre, Entidad miTratamiento)
        {
            return new ComandoConsultarImplementoPorNombre(nombre, miTratamiento);
        }

        //CARGARL LISTA PRODUCTO NO IMPLEMENTO

        public static Comando<List<Entidad>> CrearComandoCargarListaProductoNoImplemento(Entidad miTratamiento)
        {
            return new ComandoCargarListaProductoNoImplemento(miTratamiento);
        }


        //NO ESTA HECHO EL COMANDO BUSCAR PRODUCTOS, DEPENDEMOS DE PRODUCTO


        #endregion

        #region Tratamiento

        public static Comando<Entidad> CrearComandoConsultarXIdTratamiento(int idTratamiento)
        {
            return new ComandoConsultarXIdTratamiento(idTratamiento);
        }


        public static Comando<List<Entidad>> CrearComandoConsultarTratamientoAsociado(int idprimario)
        {
            return new ComandoConsultarTratamientoAsociado(idprimario);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarTratamiento()
        {
            return new ComandoConsultarTratamiento();
        }

        public static Comando<List<Entidad>> CrearomandoConsultarXNombreTratamiento(string nombreTratamiento)
        {
            return new ComandoConsultarXNombreTratamiento(nombreTratamiento);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarXEstatusTratamiento(string estatusTratamientoBuscar)
        {
            return new ComandoConsultarXEstatusTratamiento(estatusTratamientoBuscar);
        }

        public static Comando<bool> CrearComandoEliminarTratamientoAsociado(Entidad tratamientoPrimario)
        {
            return new ComandoEliminarTratamientoAsociado(tratamientoPrimario);
        }

        public static Comando<int> CrearComandoConsultarTratamientoEspecificoHistoriaClinica(string nombre)
        {
            return new ComandoConsultarTratamientoEspecificoHistoriaClinica(nombre);
        }

        public static Comando<bool> CrearComandoEliminarTratamiento(Entidad tratamientoPrimario)
        {
            return new ComandoEliminarTratamiento(tratamientoPrimario);
        }

        public static Comando<bool> CrearComandoValidaString(string cadena)
        {
            return new ComandoValidaString(cadena);
        }

        public static Comando<List<Entidad>> CrearComandoConsultarTratamientoNoAsociado(int idTratamiento)
        {
            return new ComandoConsultarTratamientoNoAsociado(idTratamiento);
        }


        public static Comando<bool> CrearComandoValidarNumero(string numberText)
        {
            return new ComandoValidarNumero(numberText);
        }

        public static Comando<bool> CrearComandoAgregarTratamiento(Entidad tratamientoPrimario,
                                                                   List<Entidad> listaImplementos, List<Entidad> listaTratamiento)
        {
            return new ComandoAgregarTratamiento(tratamientoPrimario, listaImplementos, listaTratamiento);
        }

        public static Comando<bool> CrearComandoAgregarTratamientoAsociado(Entidad tratamientoPrimario, List<Entidad> listaTratamiento)
        {
            return new ComandoAgregarTratamientoAsociado(tratamientoPrimario, listaTratamiento);
        }
        #endregion

        #region Productos

        public static Comando<List<Entidad>> CrearComandoCargarListaProductoImplemento()
        {
            return new ComandoCargarListaProductoImplemento();
        }

        public static Comando<List<Entidad>> CrearComandoCargarListaProductosNoImplemento(Entidad tratamiento)
        {
            return new ComandoListaProductosNoImplemento(tratamiento);
        }

        public static Comando<List<Entidad>> CrearComandoCargarListaProductoNombre(string nombre)
        {
            return new ComandoCargarListaProductoNombre(nombre);
        }


        #endregion
        #endregion
    }
}
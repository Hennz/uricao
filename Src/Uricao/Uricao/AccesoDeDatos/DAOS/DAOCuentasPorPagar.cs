using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;

using Uricao.Entidades.ECuentasPorPagar;
using Uricao.Entidades.EBancos;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EAbonos;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOCuentasPorPagar : DAOSQLServer, iDAOCuentasPorPagar
    {
        private Entidad _cuentaPorPagar = FabricaEntidad.CrearCuentaPorPagar();
        #region Constructores

        /// <summary>
        /// Constructor vacio por defecto.
        /// </summary>
        public DAOCuentasPorPagar()
        {
        }


        #endregion Constructores


        #region Agregar CuentasPorPagar

        /// <summary>
        /// Este metodo se encarga de insertar una nueva Cuenta Por Pagar en la base de datos.
        /// </summary>
        public bool InsertarCuentasPorPagar(Entidad miCuentaPorPagar)
        {
            // Se Instancia un objeto conexion y otro Sqlcommand para la BD:
            ConexionDAOS miConexion = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            //SqlDataReader reader = null;
            List<Entidad> listaCuentasPorPagar = new List<Entidad>();

            //Variable de control del exito de la Insercion:
            bool fueInsertado = false;

            try
            {
                //Se abre la conexion a la base de datos:
                miConexion.AbrirConexion();
                command.Connection = miConexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Aqui debo poner el nombre del storeProcedure..:
                command.CommandText = "[dbo].[InsertarCuentaPorPagar]";
                command.CommandTimeout = 10;

                // Variables a insertar, pasando al Stored Procedure de sql server
                command.Parameters.AddWithValue("@nroCtaBancaria_entra",( miCuentaPorPagar as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).NroCuentaBanco);
                command.Parameters.AddWithValue("@fechaEmisionPP", (miCuentaPorPagar as CuentaPorPagar).FechaEmision);
                command.Parameters.AddWithValue("@fechaVencimientoPP", (miCuentaPorPagar as CuentaPorPagar).FechaVencimiento);
                command.Parameters.AddWithValue("@tipoPagoPP", (miCuentaPorPagar as CuentaPorPagar).TipoPago);
                command.Parameters.AddWithValue("@estatusPP", (miCuentaPorPagar as CuentaPorPagar).Estatus);
                command.Parameters.AddWithValue("@tipoDeudaPP", (miCuentaPorPagar as CuentaPorPagar).TipoDeuda);
                command.Parameters.AddWithValue("@detallePP", (miCuentaPorPagar as CuentaPorPagar).Detalle);
                command.Parameters.AddWithValue("@montoPP", (miCuentaPorPagar as CuentaPorPagar).MontoInicialDeuda);

                //Se indica LA DIRECCION de ENTRADA o SALIDA de los Parametros:
                //Son de ENTRADA, por ser un INSERT:

                command.Parameters["@nroCtaBancaria_entra"].Direction = ParameterDirection.Input;
                command.Parameters["@fechaEmisionPP"].Direction = ParameterDirection.Input;
                command.Parameters["@fechaVencimientoPP"].Direction = ParameterDirection.Input;
                command.Parameters["@tipoPagoPP"].Direction = ParameterDirection.Input;
                command.Parameters["@estatusPP"].Direction = ParameterDirection.Input;
                command.Parameters["@tipoDeudaPP"].Direction = ParameterDirection.Input;
                command.Parameters["@detallePP"].Direction = ParameterDirection.Input;
                command.Parameters["@montoPP"].Direction = ParameterDirection.Input;

                //Se ejecuta la insercion de la Cuenta Por Pagar:
                command.ExecuteReader();

            }
            catch (SqlException)
            {
                fueInsertado = false;
                throw new Exception("Error en la conexion a la Base de Datos al Insertar una Cuenta Por Pagar");
            }
            finally
            {
                miConexion.CerrarConexion();
                fueInsertado = true;

            }

            return fueInsertado;
        }

        #endregion Agregar CuentasPorPagar


        #region MostrarListaCuentasPorPagar por Proveedor

        public List<Entidad> MostrarListaCuentasPorPagar(string nombreProveedor)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                List<Entidad> listaCuentasPorPagar = new List<Entidad>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[ConsultarCuentasPorPagaProveedor]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@proveedor", nombreProveedor);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@proveedor"].Direction = ParameterDirection.Input;

                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto de tipo cuentaPorPagar
                    while (reader.Read())
                    {

                        _cuentaPorPagar = FabricaEntidad.CrearCuentaPorPagar();
                        (_cuentaPorPagar as CuentaPorPagar).IdCuentaPorPagar = Convert.ToString(reader.GetInt64(0));
                        (_cuentaPorPagar as CuentaPorPagar).FechaEmision = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(1));

                        (_cuentaPorPagar as CuentaPorPagar).MontoActualDeuda = Convert.ToDouble(reader.GetFloat(2));


                        //Lleno la lista de cuentas por pagar 
                        listaCuentasPorPagar.Add(_cuentaPorPagar);

                    }

                }
                catch (SqlException)
                {
                    throw new Exception();
                }

                finally
                {
                    reader.Close();
                    conex.CerrarConexion();
                }

                return listaCuentasPorPagar;
            }
        }
        #endregion MostrarListadoCuentasPorPagar por Proveedor





        #region ListaCuentasPorPagar entre fechas
        public List<Entidad> ListaCuentasPorPagarEntreFechas(string fechaInicio, string fechaFin)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                //DateTime fechaI = Convert.ToDateTime(fechaInicio);
                //DateTime fechaF = Convert.ToDateTime(fechaFin);

                string fechaI = fechaInicio;
                string fechaF = fechaFin;

                List<Entidad> listaCuentasPorPagar = new List<Entidad>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[ConsultarCuentasPorPagarFechas]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@fechaInicio", fechaI);
                    command.Parameters.AddWithValue("@fechaFin", fechaF);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@fechaInicio"].Direction = ParameterDirection.Input;
                    command.Parameters["@fechaFin"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto de tipo cuentaPorPagar
                    while (reader.Read())
                    {
                        _cuentaPorPagar = FabricaEntidad.CrearCuentaPorPagar();
                        /// pendiente de PROVEEDOR
                        (_cuentaPorPagar as CuentaPorPagar).IdCuentaPorPagar = Convert.ToString(reader.GetInt64(0));
                        (_cuentaPorPagar as CuentaPorPagar).FechaEmision = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(1));
                        // cuentaPP.FechaVencimiento = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(2));
                        (_cuentaPorPagar as CuentaPorPagar).MontoActualDeuda = Convert.ToDouble(reader.GetFloat(2));
                        Proveedor miproveedor = new Proveedor();
                        miproveedor.Nombre = reader.GetString(3);
                        (_cuentaPorPagar as CuentaPorPagar).ListaProveedor.Add(miproveedor);

                        //Lleno la lista de cuentas por pagar 
                        listaCuentasPorPagar.Add(_cuentaPorPagar);

                    }
                }
                catch (SqlException)
                {
                    throw new Exception();
                }

                finally
                {
                    if (reader != null)
                        reader.Close();
                    conex.CerrarConexion();
                }

                return listaCuentasPorPagar;
            }
        }
        #endregion MostrarListadoCuentasPorPagar entre fechas


        #region MostrarListadoCuentasPoPagarProveedorFechas
        public List<Entidad> MostarCuentasPorPagarFechasProveedor(string Proveedor, string fechaInicio, string fechaFin)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                //DateTime fechaI = Convert.ToDateTime(fechaInicio).Date;
                //DateTime fechaF = Convert.ToDateTime(fechaFin).Date;

                string fechaI = fechaInicio;
                string fechaF = fechaFin;

                List<Entidad> listaCuentasPorPagar = new List<Entidad>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[ConsultarCuentasPorPagarFechasProveedor]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@Proveedor", Proveedor);
                    command.Parameters.AddWithValue("@fechaInicio", fechaI);
                    command.Parameters.AddWithValue("@fechaFin", fechaF);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@Proveedor"].Direction = ParameterDirection.Input;
                    command.Parameters["@fechaInicio"].Direction = ParameterDirection.Input;
                    command.Parameters["@fechaFin"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto de tipo cuentaPorPagar
                    while (reader.Read())
                    {

                        _cuentaPorPagar = FabricaEntidad.CrearCuentaPorPagar();
                        (_cuentaPorPagar as CuentaPorPagar).IdCuentaPorPagar = Convert.ToString(reader.GetInt64(0));
                        (_cuentaPorPagar as CuentaPorPagar).FechaEmision = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(1));

                        //cuentaPP.FechaVencimiento = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(2));
                        (_cuentaPorPagar as CuentaPorPagar).MontoActualDeuda = Convert.ToDouble(reader.GetFloat(2));
                        //cuentaPP.TipoDeuda = Convert.ToString(reader.);


                        //Lleno la lista de cuentas por pagar 
                        listaCuentasPorPagar.Add(_cuentaPorPagar);

                    }

                }
                catch (SqlException)
                {
                    throw new Exception();
                }

                finally
                {
                    if (reader != null)
                        reader.Close();
                    conex.CerrarConexion();
                }

                return listaCuentasPorPagar;
            }
        }
        #endregion MostrarListadoCuentasPoPagarProveedorFechas
        //metodo con todos los filtros
        #region MostrarListadoCuentasPorPagar todos los filtros
        public List<CuentaPorPagar> ListaCuentasPorPagarTodosFiltros(string proveedor, string fechaInicio, string fechaFin, string tipoDeuda)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                List<CuentaPorPagar> listaCuentasPorPagar = new List<CuentaPorPagar>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[ConsultarCuentasPorPagarFechasProveedor]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@proveedor", proveedor);
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);
                    command.Parameters.AddWithValue("@tipoDeuda", tipoDeuda);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@Proveedor"].Direction = ParameterDirection.Input;
                    command.Parameters["@fechaInicio"].Direction = ParameterDirection.Input;
                    command.Parameters["@fechaFin"].Direction = ParameterDirection.Input;
                    command.Parameters["@tipoDeuda"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto de tipo cuentaPorPagar
                    while (reader.Read())
                    {

                        CuentaPorPagar cuentaPP = new CuentaPorPagar();
                        cuentaPP.IdCuentaPorPagar = reader.GetString(3);
                        cuentaPP.FechaEmision = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(1));
                        cuentaPP.FechaVencimiento = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(2));
                        cuentaPP.MontoActualDeuda = reader.GetInt32(0);


                        //Lleno la lista de cuentas por pagar 
                        listaCuentasPorPagar.Add(cuentaPP);

                    }

                    return listaCuentasPorPagar;
                }
                catch (SqlException)
                {
                    throw new Exception();
                }

                finally
                {
                    if (reader != null)
                        reader.Close();
                    conex.CerrarConexion();
                }
            }
        }
        #endregion MostrarListadoCuentasPorPagar todos los filtros

        //consultar detalle
        #region Consultar una CuentaPorPagar
        public Entidad ConsultarCuentaPorPagar(string idCuentaPorPagar)
        {
            
            //  instancia de un objeto de tipo conexion para acceder a la bd
            //  instancia de un objeto de tipo sqlCommand 
            ConexionDAOS miConexion = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            //se carga la informacion consultada en un objeto de tipo cuenta por pagar

            try
            {
                //  se abre la conexion a bd vudu
                miConexion.AbrirConexion();
                command.Connection = miConexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                //nombre del stored Procedure que aun no esta hecho
                command.CommandText = "[dbo].[ConsultarCuentaPorPagar]";
                command.CommandTimeout = 10;

                //  variables del stored procedure de sql server.
                command.Parameters.AddWithValue("@idCuentaPorPagar", idCuentaPorPagar);

                // Se indica que es un parametro de entrada
                command.Parameters["@idCuentaPorPagar"].Direction = ParameterDirection.Input;
               
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    (_cuentaPorPagar as CuentaPorPagar).IdCuentaPorPagar = Convert.ToString(reader.GetInt64(0));
                    (_cuentaPorPagar as CuentaPorPagar).FechaEmision = String.Format("{0:yyyy/MM/dd}", Convert.ToString(reader.GetDateTime(1)));
                    (_cuentaPorPagar as CuentaPorPagar).FechaVencimiento = String.Format("{0:yyyy/MM/dd}", Convert.ToString(reader.GetDateTime(2)));
                    (_cuentaPorPagar as CuentaPorPagar).TipoPago = reader.GetString(3);
                    (_cuentaPorPagar as CuentaPorPagar).Estatus = reader.GetString(4);
                    (_cuentaPorPagar as CuentaPorPagar).TipoDeuda = reader.GetString(5);

                    //Puede dar error si los inserts son nulos:
                    if (!reader.IsDBNull(6))
                    {
                        (_cuentaPorPagar as CuentaPorPagar).Detalle = reader.GetString(6);
                    }
                    else
                    {
                        (_cuentaPorPagar as CuentaPorPagar).Detalle = "";
                    }

                    (_cuentaPorPagar as CuentaPorPagar).MontoInicialDeuda = Convert.ToDouble(reader.GetFloat(7));

                    Proveedor miProveedor = new Proveedor();
                    miProveedor.Nombre = reader.GetString(8);
                    (_cuentaPorPagar as CuentaPorPagar).ListaProveedor.Add(miProveedor);

                    NumeroCuentaBanco miNumeroCuentaBanco = new NumeroCuentaBanco();
                    miNumeroCuentaBanco.NroCuentaBanco = reader.GetString(9);
                    (_cuentaPorPagar as CuentaPorPagar).ListaNumeroCuentaBanco.Add(miNumeroCuentaBanco);

                    Banco miBanco = new Banco();
                    miBanco.NombreBanco = reader.GetString(10);
                    (_cuentaPorPagar as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).Banco = miBanco;

                }

            }
            catch (SqlException)
            {
                throw new Exception();
            }

            //se cierra la conexion independientemente de que se haya detectado o no una excepcion.
            finally
            {
                if (reader != null)
                    reader.Close();
                miConexion.CerrarConexion();
            }

            return _cuentaPorPagar;
        }
        #endregion Consultar una CuentaPorPagar


        #region  Modificar

        public bool ModificarCuentaPorPagar(Entidad cuentaPP)
        {
            // se instancian conexion y sqlcomand para poder abrir la conexion
            ConexionDAOS miConexion = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            bool fueModificado = false;


            try
            {
                //se abre una conexion a base de datos
                miConexion.AbrirConexion();
                command.Connection = miConexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // nombre del store procedure
                command.CommandText = "[dbo].[ModificarCuentaPorPagar]";
                command.CommandTimeout = 10;

                //variables de entrada del stored procedure
                command.Parameters.AddWithValue("@idCuentaPP", (cuentaPP as CuentaPorPagar).IdCuentaPorPagar);
                command.Parameters.AddWithValue("@fechaEmision", String.Format(String.Format("{0:yyyy/MM/dd}", Convert.ToDateTime((cuentaPP as CuentaPorPagar).FechaEmision).Date)));
                command.Parameters.AddWithValue("@fechaVencimiento", String.Format("{0:yyyy/MM/dd}", String.Format("{0:yyyy/MM/dd}", Convert.ToDateTime((cuentaPP as CuentaPorPagar).FechaVencimiento).Date)));
                //construir la fecha, dia mes ano, o no funcionara

                command.Parameters.AddWithValue("@tipoPago", (cuentaPP as CuentaPorPagar).TipoPago);
                command.Parameters.AddWithValue("@tipoDeuda", (cuentaPP as CuentaPorPagar).TipoDeuda);
                command.Parameters.AddWithValue("@detalle", (cuentaPP as CuentaPorPagar).Detalle);
                command.Parameters.AddWithValue("@MontoCPP", (cuentaPP as CuentaPorPagar).MontoInicialDeuda);
                command.Parameters.AddWithValue("@numeroCuentaBancaria", (cuentaPP as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).NroCuentaBanco);
                //parametros de entrada
                command.Parameters["@idCuentaPP"].Direction = ParameterDirection.Input;
                command.Parameters["@fechaEmision"].Direction = ParameterDirection.Input;
                command.Parameters["@fechaVencimiento"].Direction = ParameterDirection.Input;
                command.Parameters["@tipoPago"].Direction = ParameterDirection.Input;
                command.Parameters["@tipoDeuda"].Direction = ParameterDirection.Input;
                command.Parameters["@detalle"].Direction = ParameterDirection.Input;
                command.Parameters["@MontoCPP"].Direction = ParameterDirection.Input;
                command.Parameters["@numeroCuentaBancaria"].Direction = ParameterDirection.Input;
                //se ejecuta el comando para captar los resultados que devuelva el store procedure
                command.ExecuteReader();

                fueModificado = true;
            }
            catch (SqlException)
            {
                fueModificado = false;
                throw new Exception();
            }

            // se cierra la conexion independientemente si fue exitosa o no la eliminacion.
            finally
            {
                miConexion.CerrarConexion();
            }

            return fueModificado;
        }
        #endregion Modificar

        #region MostrarListadoCuentasPorPagar Activar/Desactivar Proveedor

        public List<Entidad> ActivarDesactivarMostrarListaCuentasPorPagarProveedor(string nombreProveedor)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                List<Entidad> listaCuentasPorPagar = new List<Entidad>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[ActivarDesactivarConsultarCuentasPorPagarProveedor]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@proveedor", nombreProveedor);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@proveedor"].Direction = ParameterDirection.Input;

                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto de tipo cuentaPorPagar
                    while (reader.Read())
                    {

                        Entidad cuentaPP = Entidades.FabricasEntidad.FabricaEntidad.CrearCuentaPorPagar();
                        (cuentaPP as CuentaPorPagar).IdCuentaPorPagar = Convert.ToString(reader.GetInt64(0));
                        (cuentaPP as CuentaPorPagar).FechaEmision = String.Format("{0:yyyy/MM/dd}",reader.GetDateTime(1));
                        (cuentaPP as CuentaPorPagar).Estatus = reader.GetString(2);
                        (cuentaPP as CuentaPorPagar).MontoActualDeuda = Convert.ToDouble(reader.GetFloat(3));


                        //Lleno la lista de cuentas por pagar 
                        listaCuentasPorPagar.Add(cuentaPP);

                    }
                }
                catch (SqlException)
                {
                    throw new Exception();
                }

                finally
                {
                    if (reader != null)
                        reader.Close();
                    conex.CerrarConexion();
                }
                return listaCuentasPorPagar;
            }
        }

        #endregion

        #region llenarAbonoCpp2

        public Entidad llenarAbonarCpp2(string nombreProveedor, Int64 codigoCuenta)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            Entidad cuentaPP = FabricaEntidad.CrearCuentaPorPagar();

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[llenarAbonoCpp2]";
                command.CommandTimeout = 10;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@proveedor", nombreProveedor);
                command.Parameters.AddWithValue("@idCuentaPP", codigoCuenta);
                //Se indica que es un parametro de entrada
                command.Parameters["@proveedor"].Direction = ParameterDirection.Input;
                command.Parameters["@idCuentaPP"].Direction = ParameterDirection.Input;

                //CuentaPorPagar cuentaPP = new CuentaPorPagar();
                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto de tipo cuentaPorPagar
                if (reader.Read())
                {
                    NumeroCuentaBanco miNumeroCuentaBanco = new NumeroCuentaBanco();
                    miNumeroCuentaBanco.NroCuentaBanco = reader.GetString(0);
                    (cuentaPP as CuentaPorPagar).ListaNumeroCuentaBanco.Add(miNumeroCuentaBanco);

                    Banco miBanco = new Banco();
                    miBanco.NombreBanco = reader.GetString(1);
                    (cuentaPP as CuentaPorPagar).ListaNumeroCuentaBanco.ElementAt(0).Banco = miBanco;

                    (cuentaPP as CuentaPorPagar).TipoPago = reader.GetString(2);

                    Entidad miabono = FabricaEntidad.CrearAbono();
                    (miabono as Abono).MontoAbono = reader.GetDouble(3);
                    (cuentaPP as CuentaPorPagar).ListaAbono.Add(miabono as Abono);

                }

            }
            catch (SqlException)
            {
                throw new Exception();
            }

            finally
            {
                if (reader != null)
                    reader.Close();
                conex.CerrarConexion();
            }
            return cuentaPP;
        }
        #endregion


        #region CambiarEstatusCpp

        public bool CambiarEstatusCpp(Entidad miCuenta)
        {
            {
                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                bool fueInsertado = false;

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[CambiarEstatusCpp]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@estatusPP", (miCuenta as CuentaPorPagar).Estatus);
                    command.Parameters.AddWithValue("@idCuentaPP", (miCuenta as CuentaPorPagar).IdCuentaPorPagar);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@estatusPP"].Direction = ParameterDirection.Input;
                    command.Parameters["@idCuentaPP"].Direction = ParameterDirection.Input;

                    command.ExecuteReader();
                }
                catch (SqlException)
                {
                    fueInsertado = false;
                    throw new Exception("Error en la conexion a la Base de Datos al Modificar el Estatus de una Cuenta Por Pagar");
                }
                finally
                {
                    conex.CerrarConexion();
                    fueInsertado = true;
                }

                return fueInsertado;
            }
        }

        #endregion


        #region AbonarConsultarCuentasPorPagarFechas
        public List<Entidad> AbonarConsultarCuentasPorPagarFechas(string fechaInicio, string fechaFin)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            List<Entidad> listaCuentasPorPagar = new List<Entidad>();

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[AbonarConsultarCuentasPorPagarFechas]";
                command.CommandTimeout = 10;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@fechaFin", fechaFin);
                //Se indica que es un parametro de entrada
                command.Parameters["@fechaInicio"].Direction = ParameterDirection.Input;
                command.Parameters["@fechaFin"].Direction = ParameterDirection.Input;
                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto de tipo cuentaPorPagar



                while (reader.Read())
                {
                    Entidad _cuentaPorPagar = Entidades.FabricasEntidad.FabricaEntidad.CrearCuentaPorPagar();
                    (_cuentaPorPagar as CuentaPorPagar).IdCuentaPorPagar = Convert.ToString(reader.GetInt64(0));
                    (_cuentaPorPagar as CuentaPorPagar).FechaEmision = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(1));
                    (_cuentaPorPagar as CuentaPorPagar).FechaVencimiento = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(2));
                    Proveedor miProveedor = new Proveedor();
                    miProveedor.Nombre = reader.GetString(3);
                    (_cuentaPorPagar as CuentaPorPagar).ListaProveedor.Add(miProveedor);
                    (_cuentaPorPagar as CuentaPorPagar).MontoActualDeuda = Convert.ToDouble(reader.GetFloat(4));

                    //Lleno la lista de cuentas por pagar 
                    listaCuentasPorPagar.Add(_cuentaPorPagar);
                }
            }
            catch (SqlException)
            {
                throw new Exception();
            }

            finally
            {
                if (reader != null)
                    reader.Close();
                conex.CerrarConexion();
            }
            return listaCuentasPorPagar;
        }
        #endregion AbonarConsultarCuentasPorPagarFechas



        #region AbonarConsultarCuentasPorPagar
        public List<Entidad> AbonarConsultarCuentasPorPagar(string fechaInicio, string fechaFin, string proveedor)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            List<Entidad> listaCuentasPorPagar = new List<Entidad>();

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[AbonarConsultarCuentasPorPagar]";
                command.CommandTimeout = 10;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@fechaFin", fechaFin);
                command.Parameters.AddWithValue("@proveedor", proveedor);
                //Se indica que es un parametro de entrada
                command.Parameters["@fechaInicio"].Direction = ParameterDirection.Input;
                command.Parameters["@fechaFin"].Direction = ParameterDirection.Input;
                command.Parameters["@proveedor"].Direction = ParameterDirection.Input;
                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto de tipo cuentaPorPagar



                while (reader.Read())
                {
                    Entidad _cuentaPorPagar = Entidades.FabricasEntidad.FabricaEntidad.CrearCuentaPorPagar();
                    (_cuentaPorPagar as CuentaPorPagar).IdCuentaPorPagar = Convert.ToString(reader.GetInt64(0));
                    (_cuentaPorPagar as CuentaPorPagar).FechaEmision = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(1));
                    (_cuentaPorPagar as CuentaPorPagar).FechaVencimiento = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(2));
                    (_cuentaPorPagar as CuentaPorPagar).MontoActualDeuda = Convert.ToDouble(reader.GetFloat(4));

                    //Lleno la lista de cuentas por pagar 
                    listaCuentasPorPagar.Add(_cuentaPorPagar);
                }
            }
            catch (SqlException)
            {
                throw new Exception();
            }

            finally
            {
                if (reader != null)
                    reader.Close();
                conex.CerrarConexion();
            }
            return listaCuentasPorPagar;
        }
        #endregion AbonarConsultarCuentasPorPagar

        #region ConsultarCuentasPorPagarFechasActivar

        public List<Entidad> ConsultarCuentasPorPagarFechasActivar(string fechai, string fechaf)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            List<Entidad> listaCuentasPorPagar = new List<Entidad>();

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[ConsultarCuentasPorPagarFechasActivar]";
                command.CommandTimeout = 10;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@fechaInicio", fechai);
                command.Parameters.AddWithValue("@fechaFin", fechaf);
                //Se indica que es un parametro de entrada
                command.Parameters["@fechaInicio"].Direction = ParameterDirection.Input;
                command.Parameters["@fechaFin"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto de tipo cuentaPorPagar
                while (reader.Read())
                {
                    Entidad cuentaPP = FabricaEntidad.CrearCuentaPorPagar();
                    (cuentaPP as CuentaPorPagar).IdCuentaPorPagar = Convert.ToString(reader.GetInt64(0));
                    (cuentaPP as CuentaPorPagar).FechaEmision = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(1));
                    (cuentaPP as CuentaPorPagar).Estatus = reader.GetString(2);
                    Proveedor miProveedor = new Proveedor();
                    miProveedor.Nombre = reader.GetString(3);
                    (cuentaPP as CuentaPorPagar).ListaProveedor.Add(miProveedor);
                    (cuentaPP as CuentaPorPagar).MontoActualDeuda = Convert.ToDouble(reader.GetFloat(4));

                    //Lleno la lista de cuentas por pagar 
                    listaCuentasPorPagar.Add(cuentaPP);
                }
            }
            catch (SqlException)
            {
                throw new Exception();
            }

            finally
            {
                if (reader != null)
                    reader.Close();
                conex.CerrarConexion();
            }
            return listaCuentasPorPagar;
        }

        #endregion

        #region ConsultarCuentasPorPagarFechasProveedorActivar

        public List<Entidad> ConsultarCuentasPorPagarFechasProveedorActivar(string fechai, string fechaf, string proveedor)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            List<Entidad> listaCuentasPorPagar = new List<Entidad>();

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[ConsultarCuentasPorPagarFechasProveedorActivar]";
                command.CommandTimeout = 10;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@fechaInicio", fechai);
                command.Parameters.AddWithValue("@fechaFin", fechaf);
                command.Parameters.AddWithValue("@proveedor", proveedor);
                //Se indica que es un parametro de entrada
                command.Parameters["@fechaInicio"].Direction = ParameterDirection.Input;
                command.Parameters["@fechaFin"].Direction = ParameterDirection.Input;
                command.Parameters["@proveedor"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto de tipo cuentaPorPagar
                while (reader.Read())
                {
                    Entidad cuentaPP = FabricaEntidad.CrearCuentaPorPagar();
                    (cuentaPP as CuentaPorPagar).IdCuentaPorPagar = Convert.ToString(reader.GetInt64(0));
                    (cuentaPP as CuentaPorPagar).FechaEmision = String.Format("{0:yyyy/MM/dd}", reader.GetDateTime(1));
                    (cuentaPP as CuentaPorPagar).Estatus = reader.GetString(2);
                    (cuentaPP as CuentaPorPagar).MontoActualDeuda = Convert.ToDouble(reader.GetFloat(3));
                    listaCuentasPorPagar.Add(cuentaPP);
                }
            }
            catch (SqlException)
            {
                throw new Exception();
            }

            finally
            {
                if (reader != null)
                    reader.Close();
                conex.CerrarConexion();
            }
            return listaCuentasPorPagar;
        }

        #endregion

        #region ActivarDesactivarCpp

        public bool ActivarDesactivarCpp(Entidad miCuenta)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            bool fueInsertado = false;

            try
            {
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[ActivarDesactivarCpp]";
                command.CommandTimeout = 10;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@idCuentaPP", (miCuenta as CuentaPorPagar).IdCuentaPorPagar);
                command.Parameters.AddWithValue("@estatusPP", (miCuenta as CuentaPorPagar).Estatus);
                //Se indica que es un parametro de entrada
                command.Parameters["@idCuentaPP"].Direction = ParameterDirection.Input;
                command.Parameters["@estatusPP"].Direction = ParameterDirection.Input;

                command.ExecuteReader();
            }
            catch (SqlException)
            {
                fueInsertado = false;
                throw new Exception("Error en la conexion a la Base de Datos al Activar/Desactivar una Cuenta Por Pagar");
            }
            finally
            {
                conex.CerrarConexion();
                fueInsertado = true;
            }
            return fueInsertado;
        }

        #endregion

    }
}
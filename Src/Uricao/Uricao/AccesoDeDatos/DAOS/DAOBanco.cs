using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.EBancos;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOBanco : DAOSQLServer, iDAOBanco
    {
        #region MostrarBancoProveedores parametro Proveedor
        public List<Banco> ListaBancoProveedores(string nombreProveedor)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                List<Banco> listaBanco = new List<Banco>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[BuscarBancoProveedor]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@nombreProveedor", nombreProveedor);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@nombreProveedor"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto de tipo cuentaPorPagar
                    while (reader.Read())
                    {

                        Banco banco = new Banco();
                        banco.NombreBanco = reader.GetString(0);

                        //Lleno la lista de cuentas por pagar 
                        listaBanco.Add(banco);

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

                return listaBanco;

            }
        }
        #endregion MostrarBancoProveedores parametro Proveedor


        #region MostrarCuentaProveedores parametro Proveedor y Banco

        public List<NumeroCuentaBanco> ListaNumeroCuentaBancariaProveedores(string nombreProveedor, string nombreBanco)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                List<NumeroCuentaBanco> listaCuenta = new List<NumeroCuentaBanco>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[BuscarCuentaProveedor]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@nombreProveedor", nombreProveedor);
                    command.Parameters.AddWithValue("@nombreBanco", nombreBanco);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@nombreProveedor"].Direction = ParameterDirection.Input;
                    command.Parameters["@nombreBanco"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto de tipo cuentaPorPagar

                    while (reader.Read())
                    {

                        NumeroCuentaBanco cuenta = new NumeroCuentaBanco();
                        cuenta.NroCuentaBanco = reader.GetString(0);

                        //Lleno la lista de cuentas por pagar 
                        listaCuenta.Add(cuenta);

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

                return listaCuenta;
            }
        }
        #endregion MostrarBancoProveedores parametro Proveedor


        #region Enlista los bancos a mostrar a los clientes
        public List<string> ListaBancoCliente()
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                // List<Banco> listaBanco = new List<Banco>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[buscarBancoEmpresa]";
                    command.CommandTimeout = 10;
                    reader = command.ExecuteReader();

                    List<string> ListaBancoCliente = new List<string>();
                    while (reader.Read())
                    {


                        ListaBancoCliente.Add(reader.GetString(0));

                    }

                    return ListaBancoCliente;
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
        #endregion  Enlista los bancos a mostrar a los clientes

        #region Enlista los tipos de cuentas a mostrar a los usuarios
        public List<string> ListaTipoCuentas()
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                // List<Banco> listaBanco = new List<Banco>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[buscarTipoCuentas]";
                    command.CommandTimeout = 10;
                    reader = command.ExecuteReader();

                    List<string> ListaTiposCuentaCliente = new List<string>();
                    while (reader.Read())
                    {


                        ListaTiposCuentaCliente.Add(reader.GetString(0));

                    }

                    return ListaTiposCuentaCliente;
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
        #endregion  Enlista los tipos de cuentas a mostrar a los usuarios


        #region Agregar Banco
        //public Boolean AgregarBancoBD(string nombreBanco, string numeroCuenta, string tipoCuenta, Boolean estado)
        public Boolean AgregarBancoBD(string nombreBanco, string numeroCuenta, string tipoCuenta, int tipoAgregacion)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                // List<Banco> listaBanco = new List<Banco>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    if (tipoAgregacion == 1)
                    {
                        command.CommandText = "[dbo].[agregarBancos]";

                    }
                    if (tipoAgregacion == 2)
                    {
                        command.CommandText = "[dbo].[agregarBancosViejos]";
                    }
                    command.CommandTimeout = 10;
                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@nombreBanco", nombreBanco);
                    command.Parameters.AddWithValue("@numeroCuenta", numeroCuenta);
                    command.Parameters.AddWithValue("@tipoCuenta", tipoCuenta);
                    //Se indica que es un parametro de entrada
                    // command.Parameters["@nombreBanco"].Direction = ParameterDirection.Input;
                    command.ExecuteReader();
                    // guarda registro a registro cada objeto de tipo cuentaPorPagar

                    return true;
                }
                catch (SqlException)
                {
                    return false;
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
        #endregion Agregar Banco


    }
}
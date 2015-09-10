using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Uricao.Entidades.EBancos;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.AccesoDeDatos.IDAOS;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOCuentaBancaria : DAOSQLServer, iDAOCuentaBancaria
    {
        #region Consultar cuenta bancaria por banco
        public List<NumeroCuentaBanco> ListaCuentaBancarias(string nombreBanco)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                List<NumeroCuentaBanco> listaCtaBancaria = new List<NumeroCuentaBanco>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[consultarCuentaBancaria]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@nombreBanco", nombreBanco);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@nombreBanco"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();

                    
                    while (reader.Read())
                    {
                        NumeroCuentaBanco infoCuentaBancaria = new NumeroCuentaBanco();
                        infoCuentaBancaria.NomBanco = reader.GetString(0);
                        infoCuentaBancaria.TipoCuentaBanco = reader.GetString(1);
                        infoCuentaBancaria.NroCuentaBanco = reader.GetString(2);
                        

                        //Lleno la lista de cuentas por pagar 
                        listaCtaBancaria.Add(infoCuentaBancaria);

                    }

                    return listaCtaBancaria;
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
        #endregion Consultar cuenta bancaria por banco

        #region Consulta cuentas bancarias por tipo cuenta
        public List<NumeroCuentaBanco> ListaConsultaTipoCuenta(string nombreTipoCuenta)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                List<NumeroCuentaBanco> listaTipoCuenta = new List<NumeroCuentaBanco>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[consultaPorTipoCuenta]";
                    command.CommandTimeout = 10;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@tipoCuenta", nombreTipoCuenta);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@tipoCuenta"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();

                   
                    while (reader.Read())
                    {
                        NumeroCuentaBanco infoCuentaBancaria = new NumeroCuentaBanco();
                        infoCuentaBancaria.NomBanco = reader.GetString(0);
                        infoCuentaBancaria.TipoCuentaBanco = reader.GetString(1);
                        infoCuentaBancaria.NroCuentaBanco = reader.GetString(2);


                        //Lleno la lista de cuentas por pagar 
                        listaTipoCuenta.Add(infoCuentaBancaria);

                    }

                    return listaTipoCuenta;
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
        #endregion Consulta cuentas bancarias por tipo cuenta

        #region Consulta todas las cuentas bancarias
        public List<NumeroCuentaBanco> ListaConsultaCuentasBancarias()
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                List<NumeroCuentaBanco> listaDatosCuentaBancarias = new List<NumeroCuentaBanco>();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[consultaBancos]";
                    command.CommandTimeout = 10;
                    reader = command.ExecuteReader();

                    //Aqui van los parametros del store procesure
                    //command.Parameters.AddWithValue("@tipoCuenta", nombreTipoCuenta);
                    //Se indica que es un parametro de entrada
                    //command.Parameters["@tipoCuenta"].Direction = ParameterDirection.Input;
                    //reader = command.ExecuteReader();

                   
                    while (reader.Read())
                    {
                        NumeroCuentaBanco infoCuentaBancaria = new NumeroCuentaBanco();
                       
                        infoCuentaBancaria.NomBanco = reader.GetString(0);
                        infoCuentaBancaria.TipoCuentaBanco = reader.GetString(1);
                        infoCuentaBancaria.NroCuentaBanco = reader.GetString(2);


                        //Lleno la lista de cuentas por pagar 
                        listaDatosCuentaBancarias.Add(infoCuentaBancaria);

                    }

                    return listaDatosCuentaBancarias;
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
        #endregion Consulta todas las cuentas bancarias
    }
}
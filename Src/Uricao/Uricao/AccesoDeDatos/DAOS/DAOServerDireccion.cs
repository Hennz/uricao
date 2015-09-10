using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Uricao.LogicaDeNegocios.Clases.LNTratamientos;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using System.Data;
using System.Data.SqlClient;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.AccesoDeDatos.IDAOS;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAODireccion : DAOSQLServer, iDAOServerDireccion
    {
        #region EnlistarPaises
        public List<string> ListaPaises()
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
                    command.CommandText = "[dbo].[ComboPais]";
                    command.CommandTimeout = 10;
                    reader = command.ExecuteReader();

                    List<string> ListaPaises = new List<string>();
                    while (reader.Read())
                    {


                        ListaPaises.Add(reader.GetString(0));

                    }

                    return ListaPaises;
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
        #endregion EnlistarRoles parametro Proveedor

        #region EnlistarEstadoPaises
        public List<string> ListaEstado(string nombrePais)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[ComboEstadoPais]";
                    command.CommandTimeout = 10;

                    command.Parameters.AddWithValue("@parametro", nombrePais);
                    command.Parameters["@parametro"].Direction = ParameterDirection.Input;

                    reader = command.ExecuteReader();

                    List<string> ListaCiudades = new List<string>();
                    while (reader.Read())
                    {


                        ListaCiudades.Add(reader.GetString(0));

                    }

                    return ListaCiudades;
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
        #endregion EnlistarRoles parametro Proveedor

        #region EnlistarCiudadEstado
        public List<string> ListaCiudades(string nombreEstado)
        {

            {

                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionDAOS conex = new ConexionDAOS();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;


                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que no esta hecho
                    command.CommandText = "[dbo].[ComboCiudadEstado]";
                    command.CommandTimeout = 10;

                    command.Parameters.AddWithValue("@parametro", nombreEstado);
                    command.Parameters["@parametro"].Direction = ParameterDirection.Input;

                    reader = command.ExecuteReader();

                    List<string> ListaCiudades = new List<string>();
                    while (reader.Read())
                    {


                        ListaCiudades.Add(reader.GetString(0));

                    }

                    return ListaCiudades;
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
        #endregion EnlistarRoles parametro Proveedor
    }
}
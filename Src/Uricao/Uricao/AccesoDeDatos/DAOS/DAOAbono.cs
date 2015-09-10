using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.Entidades.ECuentasPorPagar;
using Uricao.Entidades.EBancos;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EAbonos;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.ECuentasPorCobrar;



namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOAbono : DAOSQLServer, iDAOAbono
    {
        IConexionDAOS _bd = FabricaConexion.AccesoConexion();
        SqlCommand _command = new SqlCommand();


        public bool AgregarPrimerAbono(Entidad _abono)
        {

            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.AgregarPrimerAbono", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@fecha", (_abono as Abono).FechaAbono);
                cmd.Parameters.Add(param);

                SqlParameter param2 = new SqlParameter("@factura", (_abono as Abono).Factura);
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@cuenta", (_abono as Abono).Cuenta);
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@monto", (_abono as Abono).MontoAbono);
                cmd.Parameters.Add(param4);
                dr = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error al Agregar en la Base de Datos", e);
            }
            finally
            {
                _bd.CerrarConexion();
            }
        }

        public bool AgregarAbonoCC(Entidad _abono)
        {

            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.AgregarAbono", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@fecha", (_abono as Abono).FechaAbono);
                cmd.Parameters.Add(param);

                SqlParameter param2 = new SqlParameter("@factura", (_abono as Abono).Factura);
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@cuenta", (_abono as Abono).Cuenta);
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@monto", (_abono as Abono).MontoAbono);
                cmd.Parameters.Add(param4);
                dr = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error al Agregar en la Base de Datos", e);
            }
            finally
            {
                _bd.CerrarConexion();
            }
        }

        public Entidad ConsultarAbono(Entidad _abono)
        {
            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Abono objetoCuenta = new Abono();
            //List<Totales> miLista = new List<Totales>();
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.consultarAbono", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@fechaAbono", (_abono as Abono).FechaAbono);
                cmd.Parameters.Add(param);
                SqlParameter param1 = new SqlParameter("@factura", (_abono as Abono).Factura);
                cmd.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@cuenta", (_abono as Abono).Cuenta);
                cmd.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter("@monto", (_abono as Abono).MontoAbono);
                cmd.Parameters.Add(param3);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    (objetoCuenta as Abono).Cuenta = Convert.ToInt32(dr.GetValue(0));
                    (objetoCuenta as Abono).Deuda = Convert.ToDouble(dr.GetValue(1));
                    (objetoCuenta as Abono).Factura = Convert.ToInt32(dr.GetValue(2));
                    (objetoCuenta as Abono).FechaAbono = dr.GetValue(3).ToString();
                    (objetoCuenta as Abono).MontoAbono = Convert.ToDouble(dr.GetValue(4));


                }

                _bd.CerrarConexion();
            }
            catch (Exception e)
            { }

            return objetoCuenta;
        }


        public double ConsultarDeuda(int idFactura)
        {
            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            double deuda = 0.0;
            //List<Totales> miLista = new List<Totales>();
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.consultarDeudaXFactura", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdFactura", idFactura);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.GetValue(0) != DBNull.Value)
                    {
                        deuda = Convert.ToDouble(dr.GetValue(0));
                    }
                    else
                    {
                        deuda = 0.0;
                    }
                }

                _bd.CerrarConexion();
            }
            catch (Exception e)
            { }

            return deuda;
        }

        public int CantidadAbonos(int idFactura)
        {
            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            int deuda = 0;
            //List<Totales> miLista = new List<Totales>();
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.CantidadAbonos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdFactura", idFactura);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.GetValue(0) != DBNull.Value)
                    {
                        deuda = Convert.ToInt32(dr.GetValue(0));
                    }
                    else
                    {
                        deuda = 0;
                    }

                }

                _bd.CerrarConexion();
            }
            catch (Exception e)
            { }

            return deuda;
        }


        #region Cargar Data Grid Abonos


        public List<Entidad> llenarGridAbonos(string nombreProveedor, Int64 codigoCuenta)
        {

            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            List<Entidad> listaAbono = new List<Entidad>();

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[llenarGridAbonos]";
                command.CommandTimeout = 10;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@proveedor", nombreProveedor);
                command.Parameters.AddWithValue("@idCuentaPP", codigoCuenta);
                //Se indica que es un parametro de entrada
                command.Parameters["@proveedor"].Direction = ParameterDirection.Input;
                command.Parameters["@idCuentaPP"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto de tipo cuentaPorPagar
                while (reader.Read())
                {

                    //Abono abonos = new Abono();
                    Entidad _abonos = FabricaEntidad.CrearAbono();
                    (_abonos as Abono).FechaAbono = String.Format("{0:dd/MM/yyyy}", reader.GetDateTime(0));
                    (_abonos as Abono).MontoAbono = reader.GetFloat(1);
                    (_abonos as Abono).Deuda = reader.GetFloat(2);

                    //Lleno la lista de cuentas por pagar 
                    listaAbono.Add(_abonos);

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
            return listaAbono;
        }

        #endregion



        #region agregarAbono

        public bool agregarAbono(Entidad miAbono, Int64 idCuentaPP)
        {
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionDAOS conex = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            bool fueInsertado = false;

            try
            {

                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[abonoCuentaPorPagar]";
                command.CommandTimeout = 10;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@fechaAbono", (miAbono as Abono).FechaAbono);
                command.Parameters.AddWithValue("@montoAbono", (miAbono as Abono).MontoAbono);
                command.Parameters.AddWithValue("@deuda", (miAbono as Abono).Deuda);
                command.Parameters.AddWithValue("@idCuentaPP", idCuentaPP);

                //Se indica que es un parametro de entrada
                command.Parameters["@fechaAbono"].Direction = ParameterDirection.Input;
                command.Parameters["@montoAbono"].Direction = ParameterDirection.Input;
                command.Parameters["@deuda"].Direction = ParameterDirection.Input;
                command.Parameters["@idCuentaPP"].Direction = ParameterDirection.Input;

                reader = command.ExecuteReader();

            }
            catch (SqlException)
            {
                fueInsertado = false;
                throw new Exception("Error en la conexion a la Base de Datos al Insertar una Cuenta Por Pagar");
            }

            finally
            {
                conex.CerrarConexion();
                fueInsertado = true;
            }
            return fueInsertado;
        }
        #endregion

    }// de la clase




}
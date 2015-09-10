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
using Uricao.Entidades.FabricasEntidad;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.Entidades.EEntidad;
namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOCuentasPorCobrar : DAOSQLServer, iDAOCuentasPorCobrar
    {

        IConexionDAOS db = FabricaConexion.AccesoConexion();

        public List<Entidad> consultarUsuarioCedula(string tipo, string cedula)
        {

            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Entidad objetoUsuario = FabricaEntidad.NuevaCuentaPorCobrar();
            List<Entidad> miLista = new List<Entidad>();

            // List<CuentaPorCobrar> lalista = new List<CuentaPorCobrar>();

            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.BuscarUsuarioCedula", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlParameter param = new SqlParameter("@cedula", "v-19293743");
                SqlParameter param = new SqlParameter("@cedula", cedula);
                cmd.Parameters.Add(param);
                SqlParameter param2 = new SqlParameter("@tipo", tipo);
                cmd.Parameters.Add(param2);
                // cmd.Parameters.AddWithValue("@cedula", "v-19293743");
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    objetoUsuario = FabricaEntidad.NuevaCuentaPorCobrar();
                    (objetoUsuario as CuentaPorCobrar).TipoCedula = dr.GetValue(0).ToString();
                    (objetoUsuario as CuentaPorCobrar).Cedula = dr.GetValue(1).ToString();
                    (objetoUsuario as CuentaPorCobrar).PrimerNombre = dr.GetValue(2).ToString();
                    (objetoUsuario as CuentaPorCobrar).Segundonombre = dr.GetValue(3).ToString();
                    (objetoUsuario as CuentaPorCobrar).Primerapellido = dr.GetValue(4).ToString();
                    (objetoUsuario as CuentaPorCobrar).Segundoapellido = dr.GetValue(5).ToString();
                    (objetoUsuario as CuentaPorCobrar).Estado = dr.GetValue(6).ToString();
                    (objetoUsuario as CuentaPorCobrar).Id = Convert.ToInt32(dr.GetValue(7).ToString());
                    miLista.Add(objetoUsuario);


                }

                db.CerrarConexion();
            }
            catch (Exception e)
            {

            }
            finally
            {
                db.CerrarConexion();
            }
            return miLista;
        }

        public List<Entidad> BuscarAbonos(int idfactura)
        {

            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Entidad objetoUsuario = FabricaEntidad.CrearAbono();
            List<Entidad> miLista = new List<Entidad>();

            // List<CuentaPorCobrar> lalista = new List<CuentaPorCobrar>();

            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.BuscarAbonos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlParameter param = new SqlParameter("@cedula", "v-19293743");
                SqlParameter param = new SqlParameter("@idFactura", idfactura);
                cmd.Parameters.Add(param);
                // cmd.Parameters.AddWithValue("@cedula", "v-19293743");
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    objetoUsuario = new Abono();
                    (objetoUsuario as Abono).MontoAbono = Convert.ToDouble(dr.GetValue(0).ToString());
                    (objetoUsuario as Abono).Deuda = Convert.ToDouble(dr.GetValue(1).ToString());
                    (objetoUsuario as Abono).FechaAbono = dr.GetValue(2).ToString();
                    miLista.Add(objetoUsuario);


                }

                db.CerrarConexion();
            }
            catch (Exception e)
            {

            }
            finally
            {
                db.CerrarConexion();
            }
            return miLista;
        }


        public List<Entidad> consultarFacturaCF(string fechainicio, string fechafin, string cedula, string tipo)
        {

            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Entidad objetoFactura = FabricaEntidad.NuevaFicticia();
            List<Entidad> miLista = new List<Entidad>();

            // List<CuentaPorCobrar> lalista = new List<CuentaPorCobrar>();

            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.BuscarFacturaCF", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlParameter param = new SqlParameter("@cedula", "v-19293743");
                SqlParameter param = new SqlParameter("@cedula", cedula);
                cmd.Parameters.Add(param);
                SqlParameter param2 = new SqlParameter("@tipo", tipo);
                cmd.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter("@fechaInicio", fechainicio);
                cmd.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter("@fechaFin", fechafin);
                cmd.Parameters.Add(param4);

                // cmd.Parameters.AddWithValue("@cedula", "v-19293743");
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    (objetoFactura as Ficticia).TotalAbono = (Convert.ToDouble(dr.GetValue(0)));
                    (objetoFactura as Ficticia).NumeroFactura = (Convert.ToInt32(dr.GetValue(1)));
                    (objetoFactura as Ficticia).FechaEmitida = (Convert.ToDateTime(dr.GetValue(2).ToString()));
                    (objetoFactura as Ficticia).TotalFactura = (Convert.ToDouble(dr.GetValue(3)));
                    (objetoFactura as Ficticia).Deuda = (Convert.ToDouble(dr.GetValue(3))) - (Convert.ToDouble(dr.GetValue(0)));
                    miLista.Add(objetoFactura);


                }

                db.CerrarConexion();
            }
            catch (Exception e)
            {

            }
            finally
            {
                db.CerrarConexion();
            }
            return miLista;
        }

        public Entidad consultarCuenta(int idCuenta)
        {

            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Entidad objetoCuenta = FabricaEntidad.NuevaCuentaPorCobrar();

            // List<CuentaPorCobrar> lalista = new List<CuentaPorCobrar>();

            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.ConsultarCuenta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@idCuenta", idCuenta);
                cmd.Parameters.Add(param);



                // cmd.Parameters.AddWithValue("@cedula", "v-19293743");
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    objetoCuenta = new CuentaPorCobrar();
                    (objetoCuenta as CuentaPorCobrar).Id = (Convert.ToInt32(dr.GetValue(0)));
                    (objetoCuenta as CuentaPorCobrar).Estado = dr.GetValue(1).ToString();

                }

                db.CerrarConexion();
            }
            catch (Exception e)
            {

            }
            finally
            {
                db.CerrarConexion();
            }
            return objetoCuenta;
        }


        public List<Entidad> consultarFacturaCedula(string cedula, string tipo)
        {

            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Entidad objetoFactura = FabricaEntidad.NuevaFicticia();
            List<Entidad> miLista = new List<Entidad>();

            // List<CuentaPorCobrar> lalista = new List<CuentaPorCobrar>();

            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.CargarFacturas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlParameter param = new SqlParameter("@cedula", "v-19293743");
                SqlParameter param = new SqlParameter("@cedula", cedula);
                cmd.Parameters.Add(param);
                SqlParameter param2 = new SqlParameter("@tipoCedula", tipo);
                cmd.Parameters.Add(param2);
                // cmd.Parameters.AddWithValue("@cedula", "v-19293743");
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //objetoFactura = new Ficticia();

                    if (dr.GetValue(0) != DBNull.Value)
                    {

                        (objetoFactura as Ficticia).TotalAbono = (Convert.ToDouble(dr.GetValue(0)));
                        (objetoFactura as Ficticia).Deuda = (Convert.ToDouble(dr.GetValue(3))) - (Convert.ToDouble(dr.GetValue(0)));
                    }
                    else
                    {
                        (objetoFactura as Ficticia).TotalAbono = 0.0;
                        (objetoFactura as Ficticia).Deuda = (Convert.ToDouble(dr.GetValue(3)));
                    }
                    (objetoFactura as Ficticia).NumeroFactura = (Convert.ToInt32(dr.GetValue(1)));
                    (objetoFactura as Ficticia).FechaEmitida = (Convert.ToDateTime(dr.GetValue(2).ToString()));
                    (objetoFactura as Ficticia).TotalFactura = (Convert.ToDouble(dr.GetValue(3)));
                    miLista.Add(objetoFactura);
                }

                db.CerrarConexion();
            }
            catch (Exception e)
            {

            }
            finally
            {
                db.CerrarConexion();
            }
            return miLista;
        }


        public List<Entidad> consultarUsuarioFechas(string fechainicio, string fechafin)
        {

            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Entidad objetoUsuario = FabricaEntidad.NuevaCuentaPorCobrar(); ;
            List<Entidad> miLista = new List<Entidad>();

            // List<CuentaPorCobrar> lalista = new List<CuentaPorCobrar>();

            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.BuscarFacturaFecha", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlParameter param = new SqlParameter("@cedula", "v-19293743");
                SqlParameter param = new SqlParameter("@fechaInicio", fechainicio);
                cmd.Parameters.Add(param);
                SqlParameter param2 = new SqlParameter("@fechaFin", fechafin);
                cmd.Parameters.Add(param2);
                // cmd.Parameters.AddWithValue("@cedula", "v-19293743");
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    (objetoUsuario as CuentaPorCobrar).TipoCedula = dr.GetValue(0).ToString();
                    (objetoUsuario as CuentaPorCobrar).Cedula = dr.GetValue(1).ToString();
                    (objetoUsuario as CuentaPorCobrar).PrimerNombre = dr.GetValue(2).ToString();
                    (objetoUsuario as CuentaPorCobrar).Segundonombre = dr.GetValue(3).ToString();
                    (objetoUsuario as CuentaPorCobrar).Primerapellido = dr.GetValue(4).ToString();
                    (objetoUsuario as CuentaPorCobrar).Segundoapellido = dr.GetValue(5).ToString();
                    (objetoUsuario as CuentaPorCobrar).Estado = dr.GetValue(6).ToString();

                    miLista.Add(objetoUsuario);


                }

                db.CerrarConexion();
            }
            catch (Exception e)
            {

            }
            finally
            {
                db.CerrarConexion();
            }
            return miLista;
        }


        public List<Entidad> consultarCuentaCobrarConStoredProcedure()
        {
            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Entidad objetoCuenta = FabricaEntidad.NuevaCuentaPorCobrar();
            List<Entidad> miLista = new List<Entidad>();
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.SelectCuentas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    (objetoCuenta as CuentaPorCobrar).Id = Convert.ToInt32(dr.GetValue(0));
                    (objetoCuenta as CuentaPorCobrar).Estado = dr.GetValue(1).ToString();

                    miLista.Add(objetoCuenta);
                }

                db.CerrarConexion();
            }
            catch (Exception e)
            {

            }
            finally
            {
                db.CerrarConexion();
            }
            return miLista;
        }


        public List<Entidad> consultarDetalleFactura(int factura)
        {

            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Entidad objetoUsuario = FabricaEntidad.NuevaCuentaPorCobrar();
            List<Entidad> miLista = new List<Entidad>();

            // List<CuentaPorCobrar> lalista = new List<CuentaPorCobrar>();

            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.ConsultarDetalleFacturaDos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@idFactura", factura);
                cmd.Parameters.Add(param);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    (objetoUsuario as Detalle).CantidadDetalle = Convert.ToInt32(dr.GetValue(0));
                    (objetoUsuario as Detalle).MontoDetalle = Convert.ToDouble(dr.GetValue(1));
                    (objetoUsuario as Detalle).NombreTratamiento = dr.GetValue(2).ToString();
                    miLista.Add(objetoUsuario);


                }

                db.CerrarConexion();
            }
            catch (Exception e)
            {

            }
            finally
            {
                db.CerrarConexion();
            }
            return miLista;
        }


        public Entidad consultarTotalesAbonoFactura(int cuenta)
        {
            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Totales objetoCuenta = FabricaEntidad.NuevosTotales();
            //List<Totales> miLista = new List<Totales>();
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.consultarTotalesAbonoFactura", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@idCuenta", cuenta);
                cmd.Parameters.Add(param);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    (objetoCuenta as Totales).TotalFactura = Convert.ToDouble(dr.GetValue(0));
                    (objetoCuenta as Totales).TotalAbono = Convert.ToDouble(dr.GetValue(1));

                }

                db.CerrarConexion();
            }
            catch (Exception e)
            { }

            return objetoCuenta;
        }


        public bool ModificarEstado(int idCuenta, string estado)
        {
            String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.ModificarEstadoCuenta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@estado", estado);
                cmd.Parameters.Add(param);
                SqlParameter param1 = new SqlParameter("@idCuenta", idCuenta);
                cmd.Parameters.Add(param1);
                dr = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error al Modificar en la Base de Datos", e);
            }
            finally
            {
                db.CerrarConexion();
            }
        }








    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOProveedor : DAOSQLServer, iDAOProveedor
    {
        IConexionDAOS db = FabricaConexion.AccesoConexion();

       public List<Entidad> consultarProveedores()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            List<Entidad> proveedores = new List<Entidad>();
            try
            {
                db.AbrirConexion();
                cmd.Connection = db.ObjetoConexion();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SeleccionarTodosLosProveedores";
                cmd.CommandTimeout = 10;
                
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidad proveedor = FabricaEntidad.NuevoProveedor(dr.GetValue(0).ToString(), dr.GetValue(1).ToString(), 0, "");

                    proveedores.Add(proveedor);
                }

                db.CerrarConexion();
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionProveedor("Error con proveedores", e);
            }
            finally
            {
                db.CerrarConexion();
            }
            return proveedores;
        }

       public Boolean AgregarProveedor(Entidad proveedor)
        {
            
            SqlCommand command = new SqlCommand();
            SqlDataReader tabla = null;
            try
            {
                db.AbrirConexion();
                command.Connection = db.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[AgregarProveedor]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@nombre", (proveedor as Proveedor).Nombre);
                command.Parameters.AddWithValue("@rif", (proveedor as Proveedor).Rif);
                command.Parameters.AddWithValue("@direccion", "1");
                
                tabla = command.ExecuteReader();
                tabla.Close();
                return true;
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionProveedor("Error con proveedores", e);
            }
            finally
            {
                db.CerrarConexion();
            }
        }


       public Boolean AgregarContacto(Entidad contacto,Int16 idProveedor)
       {
           SqlCommand command = new SqlCommand();
           SqlDataReader tabla = null;
           try
           {
               db.AbrirConexion();
               command.Connection = db.ObjetoConexion();
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.CommandText = "[dbo].[AgregarContacto]";
               command.CommandTimeout = 10;
               command.Parameters.AddWithValue("@nombre", (contacto as Contacto).Nombre);
               command.Parameters.AddWithValue("@apellido", (contacto as Contacto).Apellido);
               command.Parameters.AddWithValue("@correo", (contacto as Contacto).Correo);
               command.Parameters.AddWithValue("@fkidProveedor", idProveedor);

               tabla = command.ExecuteReader();
               tabla.Close();
               return true;
           }
           catch (NullReferenceException e)
           {
               throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
           }
           catch (SqlException e)
           {
               throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
           }
           catch (Exception e)
           {
               throw new ExcepcionProveedor("Error con proveedores", e);
           }
           finally
           {
               db.CerrarConexion();
           }
       }

       public Boolean ModificarProveedor(Entidad proveedor, Int16 idProveedor)
       {
           SqlCommand command = new SqlCommand();
           SqlDataReader tabla = null;
           try
           {
               db.AbrirConexion();
               command.Connection = db.ObjetoConexion();
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.CommandText = "[dbo].[ModificarProveedor]";
               command.CommandTimeout = 10;
               command.Parameters.AddWithValue("@ID", idProveedor);
               command.Parameters.AddWithValue("@rif", (proveedor as Proveedor).Rif);
               command.Parameters.AddWithValue("@nombre", (proveedor as Proveedor).Nombre);
               command.Parameters.AddWithValue("@estado", (proveedor as Proveedor).Estado);

               tabla = command.ExecuteReader();
               tabla.Close();
               return true;
           }
           catch (NullReferenceException e)
           {
               throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
           }
           catch (SqlException e)
           {
               throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
           }
           catch (Exception e)
           {
               throw new ExcepcionProveedor("Error con proveedores", e);
           }
           finally
           {
               db.CerrarConexion();
           }
       }

       public Entidad consultarProveedor(Entidad proveedorOrigen)
       {
           SqlCommand cmd = new SqlCommand();
           SqlDataReader dr;
           Entidad elproveedor = FabricaEntidad.NuevoProveedor();
           try
           {
              
               db.AbrirConexion();
               cmd.Connection = db.ObjetoConexion();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.ConsultarProveedor";
                cmd.CommandTimeout = 10;


               cmd.Parameters.AddWithValue("@rif", (proveedorOrigen as Proveedor).Rif);
               cmd.Parameters.AddWithValue("@nombre", (proveedorOrigen as Proveedor).Nombre);
               cmd.Parameters.AddWithValue("@direccion", (proveedorOrigen as Proveedor).Direccion);                           
               dr = cmd.ExecuteReader();
               
                dr.Read();
               (elproveedor as Proveedor).Rif = dr.GetValue(0).ToString();
               (elproveedor as Proveedor).Nombre = dr.GetValue(1).ToString();
               (elproveedor as Proveedor).Direccion = Convert.ToInt16(dr.GetValue(2).ToString());

               return elproveedor;
                
           }
           catch (NullReferenceException e)
           {
               throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
           }
           catch (SqlException e)
           {
               throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
           }
           catch (Exception e)
           {
               throw new ExcepcionProveedor("Error con proveedores", e);
           }
           finally
           {
               db.CerrarConexion();
           }
       }

       public Entidad consultarIdProveedor(Entidad proveedorOrigen)
       {
           SqlCommand cmd = new SqlCommand();
           SqlDataReader dr;
           Entidad elproveedor = FabricaEntidad.NuevoProveedor();
           try
           {
               db.AbrirConexion();
               cmd.Connection = db.ObjetoConexion();
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandText = "dbo.consultarIdProveedor";
               cmd.CommandTimeout = 10;

               cmd.Parameters.AddWithValue("@rif", (proveedorOrigen as Proveedor).Rif);
               cmd.Parameters.AddWithValue("@nombre", (proveedorOrigen as Proveedor).Nombre);
               cmd.Parameters.AddWithValue("@direccion", (proveedorOrigen as Proveedor).Direccion);
               cmd.CommandType = CommandType.StoredProcedure;
               dr = cmd.ExecuteReader();
               
               dr.Read();
               (elproveedor as Proveedor).Id = Convert.ToInt16(dr.GetValue(0).ToString());
               (elproveedor as Proveedor).Rif = dr.GetValue(1).ToString();
               (elproveedor as Proveedor).Nombre = dr.GetValue(2).ToString();
               (elproveedor as Proveedor).Direccion = Convert.ToInt16(dr.GetValue(3).ToString());

               return elproveedor;
           }
           catch (NullReferenceException e)
           {
               throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
           }
           catch (SqlException e)
           {
               throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
           }
           catch (Exception e)
           {
               throw new ExcepcionProveedor("Error con proveedores", e);
           }
           finally
           {
               db.CerrarConexion();
           }
           
       }

       public Entidad consultarContacto(Entidad contactoOrigen, Int16 fkidProveedor)
       {
           SqlCommand cmd = new SqlCommand();
           SqlDataReader dr;
           try
           {
               
               db.AbrirConexion();
               cmd.Connection = db.ObjetoConexion();
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandText = "dbo.ConsultarContacto";
               cmd.CommandTimeout = 10;


               Entidad contacto = FabricaEntidad.NuevoContacto();
               cmd.Parameters.AddWithValue("@apellido", (contactoOrigen as Contacto).Apellido);
               cmd.Parameters.AddWithValue("@nombre", (contactoOrigen as Contacto).Nombre);
               cmd.Parameters.AddWithValue("@correo", (contactoOrigen as Contacto).Correo);
               cmd.Parameters.AddWithValue("@fkidProveedor", fkidProveedor);
               cmd.CommandType = CommandType.StoredProcedure;
               dr = cmd.ExecuteReader();

               dr.Read();
               (contacto as Contacto).Nombre = dr.GetValue(0).ToString();
               (contacto as Contacto).Apellido = dr.GetValue(1).ToString();
               (contacto as Contacto).Correo = dr.GetValue(2).ToString();

               return contacto;
               
           }
           catch (NullReferenceException e)
           {
               throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
           }
           catch (SqlException e)
           {
               throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
           }
           catch (Exception e)
           {
               throw new ExcepcionProveedor("Error con proveedores", e);
           }
           finally
           {
               db.CerrarConexion();
           }
           
       }

       public Entidad buscarContactoConFK(String rif,Int16 posicion)
       {
           
           SqlCommand cmd = new SqlCommand();
           SqlDataReader dr;
           Entidad contacto = FabricaEntidad.NuevoContacto();
           try
           {
               db.AbrirConexion();
               cmd.Connection = db.ObjetoConexion();
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandText = "dbo.buscarContactoConFK";
               cmd.CommandTimeout = 10;
               
               cmd.Parameters.AddWithValue("@rif", rif);
               cmd.CommandType = CommandType.StoredProcedure;
               dr = cmd.ExecuteReader();
               for (int i = 1; i <= posicion; i++)
               {
                   dr.Read();
                   if (dr.GetValue(0) != null)
                   {
                       (contacto as Contacto).Nombre = dr.GetValue(0).ToString();
                       (contacto as Contacto).Apellido = dr.GetValue(1).ToString();
                       (contacto as Contacto).Correo = dr.GetValue(2).ToString();
                   }
                   else 
                   {
                       break; 
                   }
               }
               return contacto;
               
           }
           catch (NullReferenceException e)
           {
               throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
           }
           catch (SqlException e)
           {
               throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
           }
           catch (Exception e)
           {
               throw new ExcepcionProveedor("Error con proveedores", e);
           }
           finally
           {
               db.CerrarConexion();
           }
           
       }

       public String buscarIdProveedorPorRif(String rif)
       {
           String cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
           SqlConnection conexion = new SqlConnection();
           SqlCommand cmd = new SqlCommand();
           SqlDataReader dr;
           try
           {
               db.AbrirConexion();
               cmd.Connection = db.ObjetoConexion();
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandText = "dbo.buscarIdProveedorPorRif";
               cmd.CommandTimeout = 10;
               
               cmd.Parameters.AddWithValue("@rif", rif);
               cmd.CommandType = CommandType.StoredProcedure;
               dr = cmd.ExecuteReader();
               dr.Read();


               if (dr.GetValue(1).ToString().Equals(rif))
               {
                   return dr.GetValue(0).ToString();
               }
               else
               {
                   return "";
               }
           }
           catch (NullReferenceException e)
           {
               throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
           }
           catch (SqlException e)
           {
               throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
           }
           catch (Exception e)
           {
               throw new ExcepcionProveedor("Error con proveedores", e);
           }
           finally
           {
               db.CerrarConexion();
           }
       }

       public Entidad buscarProveedorPorNombre(String nombre)
       {
           
           SqlCommand cmd = new SqlCommand();
           SqlDataReader dr;
           Entidad elproveedor = FabricaEntidad.NuevoProveedor();
           try
           {
               db.AbrirConexion();
               cmd.Connection = db.ObjetoConexion();
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandText = "dbo.ConsultarProveedorPorNombre";
               cmd.CommandTimeout = 10;
               
               cmd.Parameters.AddWithValue("@nombre", nombre);
               cmd.CommandType = CommandType.StoredProcedure;
               dr = cmd.ExecuteReader();
               dr.Read();
               (elproveedor as Proveedor).Rif = dr.GetValue(1).ToString();
               (elproveedor as Proveedor).Nombre = dr.GetValue(2).ToString();
               (elproveedor as Proveedor).Direccion = Convert.ToInt16(dr.GetValue(3));

               if ((elproveedor as Proveedor).Nombre.Equals(nombre))
                   return elproveedor;
               else
                   return null;
           }
           catch (NullReferenceException e)
           {
               throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
           }
           catch (SqlException e)
           {
               throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
           }
           catch (Exception e)
           {
               throw new ExcepcionProveedor("Error con proveedores", e);
           }
           finally
           {
               db.CerrarConexion();
           }
           
       }
       
       public Entidad buscarProveedorPorRif(String rif)
       {
           
           SqlCommand cmd = new SqlCommand();
           SqlDataReader dr;
           Entidad elproveedor = FabricaEntidad.NuevoProveedor();
           try
           {
               db.AbrirConexion();
               cmd.Connection = db.ObjetoConexion();
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandText = "dbo.ConsultarProveedorPorRif";
               cmd.CommandTimeout = 10;

               cmd.Parameters.AddWithValue("@rif", rif);
               cmd.CommandType = CommandType.StoredProcedure;
               dr = cmd.ExecuteReader();

               dr.Read();
               (elproveedor as Proveedor).Rif = dr.GetValue(1).ToString();
               (elproveedor as Proveedor).Nombre = dr.GetValue(2).ToString();
               (elproveedor as Proveedor).Direccion = Convert.ToInt16(dr.GetValue(3));

               if ((elproveedor as Proveedor).Rif.Equals(rif))
                   return elproveedor;
               else
                   return null;
           }
           catch (NullReferenceException e)
           {
               throw new ExcepcionProveedor("No se encontraron Proveedores en la base de datos", e);
           }
           catch (SqlException e)
           {
               throw new ExcepcionProveedor("Error en la conexion de la base de datos", e);
           }
           catch (Exception e)
           {
               throw new ExcepcionProveedor("Error con proveedores", e);
           }
           finally
           {
               db.CerrarConexion();
           }
           
       }
    }
}
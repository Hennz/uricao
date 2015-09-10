using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using System.Data.SqlClient;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.FabricasEntidad;

using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.AccesoDeDatos.DAOS
{
    
		
	public class DAOPresupuestoFactura  : DAOSQLServer, iDAOPresupuestoFactura
    {
        IConexionDAOS bd = FabricaConexion.AccesoConexion();

        SqlCommand command = new SqlCommand();        
        private Entidad _miFactura = FabricaEntidad.CrearFactura();
        private Entidad _miPresupuesto = FabricaEntidad.CrearPresupuesto();
        private Entidad _miDetallePresupuesto = FabricaEntidad.CrearDetalle_Presupuesto_Factura();
        private Entidad _miUsuario = FabricaEntidad.NuevaUsuario();


        #region Generar factura
        public int RegresarIdFactura(Factura la_factura, int idUsuario)
        {
            int regreso = 0;
            try
            {
                bd.AbrirConexion();
                command = new SqlCommand();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[getIdFactura]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@id_Usuario", idUsuario); 
                command.Parameters.AddWithValue("@fecha_factura", la_factura.getFecha_Emitida().ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@total_factura", la_factura.getTotal_Factura());
                command.Parameters.AddWithValue("@nombre_razon", la_factura.getNombre_Razon());
                command.Parameters.AddWithValue("@cedula_razon", la_factura.getCedula_Razon());

                SqlDataReader readers = command.ExecuteReader();

                while (readers.Read())
                {
                    regreso = Convert.ToInt16(readers.GetValue(0));
                }
                readers.Close();
                bd.CerrarConexion();
                return regreso;
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        public Boolean AgregarDetalleFactura(Factura laFactura, int idUsuario)
        {
            try
            {
                bd.AbrirConexion();
                foreach (var detalle in laFactura.getListado_Factura())
                {
                    command = new SqlCommand();
                    command.Connection = bd.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[AgregarDetalleFactura]";
                    command.CommandTimeout = 10;

                    command.Parameters.AddWithValue("@id_usuario", idUsuario); //prueba
                    command.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    command.Parameters.AddWithValue("@monto", detalle.Total_pago_tratamiento);
                    command.Parameters.AddWithValue("@id_Factura", laFactura.getNro_Factura());
                    command.Parameters.AddWithValue("@id_Tratamiento", detalle.El_Tratamiento.Id);

                    SqlDataReader readers = command.ExecuteReader();

                    readers.Close();
                }
                bd.CerrarConexion();
                return true;
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        public bool AgregarFactura(Factura la_factura, int id_paciente)
        {
            try
            {
                bd.AbrirConexion();
                command = new SqlCommand();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[AgregarFactura]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@id_usuario", id_paciente);
                command.Parameters.AddWithValue("@nombre_razon", la_factura.getNombre_Razon());
                if (la_factura.TipoIdentRazon.Equals("V"))
                {
                    command.Parameters.AddWithValue("@tipo_identificacion", "Cedula");
                }
                else
                {
                    if (la_factura.TipoIdentRazon.Equals("E -"))
                    {
                        command.Parameters.AddWithValue("@tipo_identificacion", "Extranjero");
                    }
                    else
                    {
                         if (la_factura.TipoIdentRazon.Equals("RIF"))
                        {
                            command.Parameters.AddWithValue("@tipo_identificacion", "RIF");
                        }
                    }
                    
                }

                command.Parameters.AddWithValue("@cedula_razon", la_factura.getCedula_Razon());
                command.Parameters.AddWithValue("@fecha", la_factura.getFecha_Emitida());
                command.Parameters.AddWithValue("@hora_fecha", la_factura.getFecha_Emitida().Hour + ":" +
                    la_factura.getFecha_Emitida().Minute + ":" + la_factura.getFecha_Emitida().Second);
                command.Parameters.AddWithValue("@total_factura", la_factura.getTotal_Factura());
                command.Parameters.AddWithValue("@id_Direccion", la_factura.getId_Direccion());
                command.Parameters.AddWithValue("@tipo_id_paciente", la_factura.TipoIdentPaciente);

                if (la_factura.getEstado_Factura())
                    command.Parameters.AddWithValue("@pagado", 1);
                else
                    command.Parameters.AddWithValue("@pagado", 0);

                SqlDataReader readers = command.ExecuteReader();

                readers.Close();
                bd.CerrarConexion();
                return true;
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }

        }
        #endregion


        #region Consultar factura

        public List<Entidad> ConsultarFacturasTodas()
        {
            try
            {
                bd.AbrirConexion();
                command = new SqlCommand();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarListaFactura]";
                command.CommandTimeout = 10;
              
                List<Entidad> _listaFactura = new List<Entidad>();
                SqlDataReader readers = command.ExecuteReader();

                while (readers.Read())
                {
                    _miFactura = FabricaEntidad.CrearFactura();
                    
                    (_miFactura as Factura).Nro_factura = Convert.ToInt32(readers.GetValue(0));
                    (_miFactura as Factura).Nombre_razon = readers.GetValue(2).ToString();
                    (_miFactura as Factura).TipoIdentRazon = readers.GetValue(3).ToString();
                    (_miFactura as Factura).Cedula_razon = readers.GetValue(4).ToString();
                    (_miFactura as Factura).Fecha_emitida = Convert.ToDateTime(readers.GetValue(5).ToString());
                    (_miFactura as Factura).Total_factura = float.Parse(readers.GetValue(7).ToString());
                    (_miFactura as Factura).Id_direccion = Convert.ToInt32(readers.GetValue(8).ToString());

                    if (Convert.ToInt32(readers.GetValue(9)) == 1)
                    {
                        (_miFactura as Factura).Estado_factura = true;
                    }
                    else if (Convert.ToInt32(readers.GetValue(9)) == 0)
                    {
                        (_miFactura as Factura).Estado_factura = false;
                    }
                    else
                    {
                        throw new Exception("Hay un error en la base de datos de factura. El estado de una factura esta corrupto.");
                    }

                    _listaFactura.Add(_miFactura);
                }

                readers.Close();

                if (_listaFactura.Count == 0)
                {
                    return null;
                }
                else
                {
                    return _listaFactura;
                }

            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }


        }



        public List<Entidad> ConsultarFacturasRangoFechas(String fechaInicio, String fechaFin)
        {
            try
            {
                bd.AbrirConexion();
                command = new SqlCommand();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarFacturasRangoFechas]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@fechaFin", fechaFin);

                List<Entidad> _listaFactura = new List<Entidad>();

                SqlDataReader readers = command.ExecuteReader();

                while (readers.Read())
                {
                    _miFactura = FabricaEntidad.CrearFactura();

                    (_miFactura as Factura).Nro_factura = Convert.ToInt32(readers.GetValue(0));
                    (_miFactura as Factura).Nombre_razon = readers.GetValue(2).ToString();
                    (_miFactura as Factura).TipoIdentRazon = readers.GetValue(3).ToString();
                    (_miFactura as Factura).Cedula_razon = readers.GetValue(4).ToString();
                    (_miFactura as Factura).Fecha_emitida = Convert.ToDateTime(readers.GetValue(5).ToString());
                    (_miFactura as Factura).Total_factura = float.Parse(readers.GetValue(7).ToString());
                    (_miFactura as Factura).Id_direccion = Convert.ToInt32(readers.GetValue(8).ToString());

                    if (Convert.ToInt32(readers.GetValue(9)) == 1)
                    {
                        (_miFactura as Factura).Estado_factura = true;
                    }
                    else if (Convert.ToInt32(readers.GetValue(9)) == 0)
                    {
                        (_miFactura as Factura).Estado_factura = false;
                    }
                    else
                    {
                        throw new Exception("Hay un error en la base de datos de factura. El estado de una factura esta corrupto.");
                    }
                    _listaFactura.Add(_miFactura);
                }

                readers.Close();

                if (_listaFactura.Count == 0)
                {
                    return null;
                }
                else
                {
                    return _listaFactura;
                }

            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }


        /// <summary>
        /// Metodo para buscar una Factura.
        /// Consulta y devuelve factura, dada la cedula de identidad del usuario que la paga (String CI).
        /// </summary>
        /// <param name="nombreTratamiento"></param>
        /// <returns></returns>
        /// 
        public List<Entidad> ConsultarFacturaXCI(String CI)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarDatosUsuarioCI]";
                command.CommandTimeout = 10;

                List<Entidad> _listaFactura = new List<Entidad>();

                command.Parameters.AddWithValue("@paramCI", CI);
                SqlDataReader readerUsuario = command.ExecuteReader();


                if (readerUsuario.Read())
                {
                    int idUsuario = Int32.Parse(readerUsuario.GetValue(0).ToString());
                    readerUsuario.Close();
                    command.Parameters.RemoveAt("@paramCI");

                    command.CommandText = "[dbo].[ConsultarFacturaXIDUsuario]";
                    command.Parameters.AddWithValue("@paramID", idUsuario);
                    SqlDataReader readers = command.ExecuteReader();

                    while (readers.Read())
                    {

                        _miFactura = FabricaEntidad.CrearFactura();

                        (_miFactura as Factura).Nro_factura = Convert.ToInt32(readers.GetValue(0));
                        (_miFactura as Factura).Nombre_razon = readers.GetValue(2).ToString();
                        (_miFactura as Factura).TipoIdentRazon = readers.GetValue(3).ToString();
                        (_miFactura as Factura).Cedula_razon = readers.GetValue(4).ToString();
                        (_miFactura as Factura).Fecha_emitida = Convert.ToDateTime(readers.GetValue(5).ToString());
                        (_miFactura as Factura).Total_factura = float.Parse(readers.GetValue(7).ToString());
                        (_miFactura as Factura).Id_direccion = Convert.ToInt32(readers.GetValue(8).ToString());

                        if (Convert.ToInt32(readers.GetValue(9)) == 1)
                        {
                            (_miFactura as Factura).Estado_factura = true;
                        }
                        else if (Convert.ToInt32(readers.GetValue(9)) == 0)
                        {
                            (_miFactura as Factura).Estado_factura = false;
                        }
                        else
                        {
                            throw new Exception("Hay un error en la base de datos de factura. El estado de una factura esta corrupto.");
                        }

                        _listaFactura.Add(_miFactura);
                    }
                }

                return _listaFactura;

            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }

        }



        ///
        public Entidad ConsultarFacturaNumero(int nro_factura)
        {
            try
            {

                bd.AbrirConexion();
                command = new SqlCommand();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarFacturaNumero]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@paramID", nro_factura);                
                SqlDataReader readers = command.ExecuteReader();


                if (readers.Read())
                {
                    _miFactura = FabricaEntidad.CrearFactura();


                    (_miFactura as Factura).Nro_factura = Convert.ToInt32(readers.GetValue(0));
                    (_miFactura as Factura).Nombre_razon = readers.GetValue(2).ToString();
                    (_miFactura as Factura).TipoIdentRazon = readers.GetValue(3).ToString();
                    (_miFactura as Factura).Cedula_razon = readers.GetValue(4).ToString();
                    (_miFactura as Factura).Fecha_emitida = Convert.ToDateTime(readers.GetValue(5).ToString());
                    (_miFactura as Factura).Total_factura = float.Parse(readers.GetValue(7).ToString());
                    (_miFactura as Factura).Id_direccion = Convert.ToInt32(readers.GetValue(8).ToString());

                    if (Convert.ToInt32(readers.GetValue(9)) == 1)
                    {
                        (_miFactura as Factura).Estado_factura = true;
                    }
                    else if (Convert.ToInt32(readers.GetValue(9)) == 0)
                    {
                        (_miFactura as Factura).Estado_factura = false;
                    }
                    else
                    {
                        throw new Exception("Hay un error en la base de datos de factura. El estado de una factura esta corrupto.");
                    }
                }

                return _miFactura;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }

            finally
            {
                bd.CerrarConexion();
            }
        }


        /// <summary>
        /// Metodo para buscar una: cedula de identidad, dado el: numero de la factura de esa persona.
        /// </summary>
        /// <param name="nombreTratamiento"></param>
        /// <returns></returns>
        public String ConsultarCedulaFactura(int nro_factura)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "[dbo].[ConsultarFKUsuarioFactura]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@nro_factura", nro_factura);
                String id_usuario = null;
                SqlDataReader readerFactura = command.ExecuteReader();
                if (readerFactura.Read())
                {
                    id_usuario = readerFactura.GetValue(0).ToString();
                }
                readerFactura.Close();
                command.Parameters.RemoveAt("@nro_Factura");

                command.CommandText = "[dbo].[ConsultarCedulaUsuarioPresupuesto]";
                command.Parameters.AddWithValue("@paramIdUsuario", id_usuario);
                SqlDataReader readerUsuario = command.ExecuteReader();

                if (readerUsuario.Read())
                {
                    return readerUsuario.GetValue(1).ToString();
                }

                readerUsuario.Close();                
                return null;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
           // return null;

        }


        //public List<Detalle_Presupuesto_Factura> ConsultarDetalleFactura(int nro_factura)
        public List<Entidad> ConsultarDetalleFactura(int nro_factura)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarDetalleFactura]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@paramIdFactura", nro_factura);
                SqlDataReader readerDetalle = command.ExecuteReader();                

                //Sin Patron comandos era asi: List<Detalle_Presupuesto_Factura> lista = new List<Detalle_Presupuesto_Factura>();
                List<Entidad> lista = new List<Entidad>();

                while (readerDetalle.Read())
                {

                    _miDetallePresupuesto = FabricaEntidad.CrearDetalle_Presupuesto_Factura();

                    (_miDetallePresupuesto as Detalle_Presupuesto_Factura).Cantidad = Int32.Parse(readerDetalle.GetValue(1).ToString());
                    (_miDetallePresupuesto as Detalle_Presupuesto_Factura).Total_pago_tratamiento = float.Parse(readerDetalle.GetValue(2).ToString());                    
                    (_miDetallePresupuesto as Detalle_Presupuesto_Factura).El_Tratamiento = new Tratamiento();
                    (_miDetallePresupuesto as Detalle_Presupuesto_Factura).El_Tratamiento.Id = short.Parse(readerDetalle.GetValue(0).ToString());

                    lista.Add(_miDetallePresupuesto);
                }
                command.Parameters.RemoveAt("@paramIdFactura");
                return lista;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
            //return null;
        }

        public String ConsultarDireccionPaisFactura(int idDireccion)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "[dbo].[ConsultarDireccionXId]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@paramIdDir", idDireccion);
                String retorno = "";
                SqlDataReader readerDireccion = command.ExecuteReader();
                if (readerDireccion.Read())
                {
                    retorno = readerDireccion.GetValue(0).ToString();
                }
                readerDireccion.Close();
                command.Parameters.RemoveAt("@paramIdDir");

                return retorno;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }


        public String ConsultarDireccionEstadoFactura(int idDireccion)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "[dbo].[ConsultarDireccionXId]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@paramIdDir", idDireccion);
                String retorno = "";
                SqlDataReader readerDireccion = command.ExecuteReader();
                if (readerDireccion.Read())
                {
                    retorno = readerDireccion.GetValue(2).ToString();
                }
                readerDireccion.Close();
                command.Parameters.RemoveAt("@paramIdDir");

                return retorno;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }


        public String ConsultarDireccionCiudadFactura(int idDireccion)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "[dbo].[ConsultarDireccionXId]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@paramIdDir", idDireccion);
                String retorno = "";
                SqlDataReader readerDireccion = command.ExecuteReader();
                if (readerDireccion.Read())
                {
                    retorno = readerDireccion.GetValue(4).ToString();
                }
                readerDireccion.Close();
                command.Parameters.RemoveAt("@paramIdDir");

                return retorno;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }


        public String ConsultarDireccionMunicipioFactura(int idDireccion)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "[dbo].[ConsultarDireccionXId]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@paramIdDir", idDireccion);
                String retorno = "";
                SqlDataReader readerDireccion = command.ExecuteReader();
                if (readerDireccion.Read())
                {
                    retorno = readerDireccion.GetValue(6).ToString();
                }
                readerDireccion.Close();
                command.Parameters.RemoveAt("@paramIdDir");

                return retorno;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        public String ConsultarDireccionCalleFactura(int idDireccion)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "[dbo].[ConsultarDireccionXId]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@paramIdDir", idDireccion);
                String retorno = "";
                SqlDataReader readerDireccion = command.ExecuteReader();
                if (readerDireccion.Read())
                {
                    retorno = readerDireccion.GetValue(8).ToString();
                }
                readerDireccion.Close();
                command.Parameters.RemoveAt("@paramIdDir");

                return retorno;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        public String ConsultarDireccionEdificioFactura(int idDireccion)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "[dbo].[ConsultarDireccionXId]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@paramIdDir", idDireccion);
                String retorno = "";
                SqlDataReader readerDireccion = command.ExecuteReader();
                if (readerDireccion.Read())
                {
                    retorno = readerDireccion.GetValue(10).ToString();
                }
                readerDireccion.Close();
                command.Parameters.RemoveAt("@paramIdDir");

                return retorno;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }


    #endregion

        #region Consultar presupuesto

        public List<Entidad> ConsultarPresupuestosTodos()
        {
            try
            {
                bd.AbrirConexion();
                command = new SqlCommand();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarListaPresupuesto]";
                command.CommandTimeout = 10;

                List<Entidad> _listaPresupuesto = new List<Entidad>();
                SqlDataReader readers = command.ExecuteReader();

                while (readers.Read())
                {
                    _miPresupuesto = FabricaEntidad.CrearPresupuesto();
                    (_miPresupuesto as Presupuesto).Nro_presupuesto = Convert.ToInt32(readers.GetValue(0));
                    (_miPresupuesto as Presupuesto).Fecha_emision = Convert.ToDateTime(readers.GetValue(1).ToString());
                    (_miPresupuesto as Presupuesto).Total_presupuesto = float.Parse(readers.GetValue(2).ToString());
                    (_miPresupuesto as Presupuesto).Observaciones = readers.GetValue(3).ToString();

                    _listaPresupuesto.Add(_miPresupuesto);
                }
                readers.Close();

                if (_listaPresupuesto.Count == 0)
                {
                    return null;
                }
                else
                {
                    return _listaPresupuesto;
                }
                
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        public List<Entidad> ConsultarPresupuestosRangoFechas(String fechaInicio, String fechaFin)
        {
            try
            {
                bd.AbrirConexion();
                command = new SqlCommand();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarPresupuestosRangoFechas]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@fechaFin", fechaFin);

                List<Entidad> _listaPresupuesto = new List<Entidad>();
                SqlDataReader readers = command.ExecuteReader();

                while (readers.Read())
                {
                    _miPresupuesto = FabricaEntidad.CrearPresupuesto();
                    (_miPresupuesto as Presupuesto).Nro_presupuesto = Convert.ToInt32(readers.GetValue(0));
                    (_miPresupuesto as Presupuesto).Fecha_emision = readers.GetDateTime(1).Date;
                    (_miPresupuesto as Presupuesto).Total_presupuesto = float.Parse(readers.GetValue(2).ToString());
                    (_miPresupuesto as Presupuesto).Observaciones = readers.GetValue(3).ToString();

                    _listaPresupuesto.Add(_miPresupuesto);
                }


                readers.Close();

                if (_listaPresupuesto.Count == 0)
                {
                    return null;
                }
                else
                {
                    return _listaPresupuesto;
                }

            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        public Entidad ConsultarPresupuestoXCI(String CI)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarDatosUsuarioCI]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@paramCI", CI);

                SqlDataReader readerUsuario = command.ExecuteReader();

                if (readerUsuario.Read())
                {
                    int idUsuario = Int32.Parse(readerUsuario.GetValue(0).ToString());
                    readerUsuario.Close();
                    command.Parameters.RemoveAt("@paramCI");

                    command.CommandText = "[dbo].[ConsultarPresupuestoFKUsuario]";
                    command.Parameters.AddWithValue("paramFK", idUsuario);
                    SqlDataReader readerPresupuesto = command.ExecuteReader();

                    if (readerPresupuesto.Read())
                    {
                        _miPresupuesto = FabricaEntidad.CrearPresupuesto();
                        (_miPresupuesto as Presupuesto).Nro_presupuesto = Convert.ToInt32(readerPresupuesto.GetValue(0));
                        (_miPresupuesto as Presupuesto).Fecha_emision = Convert.ToDateTime(readerPresupuesto.GetValue(1).ToString());
                        (_miPresupuesto as Presupuesto).Total_presupuesto = float.Parse(readerPresupuesto.GetValue(2).ToString());
                        (_miPresupuesto as Presupuesto).Observaciones = readerPresupuesto.GetValue(3).ToString();
                        readerPresupuesto.Close();

                        return _miPresupuesto;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
            return null;
        }

        public Entidad ConsultarPresupuestoNumero(int nro_presupuesto)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarPresupuestoNumero]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@paramID", nro_presupuesto);

                SqlDataReader readers = command.ExecuteReader();

               if (readers.Read())
                {
                    _miPresupuesto = FabricaEntidad.CrearPresupuesto();
                    (_miPresupuesto as Presupuesto).Nro_presupuesto = Convert.ToInt32(readers.GetValue(0));
                    String valorFecha = readers.GetValue(1).ToString();
                    (_miPresupuesto as Presupuesto).Fecha_emision = Convert.ToDateTime(valorFecha);
                    (_miPresupuesto as Presupuesto).Total_presupuesto = float.Parse(readers.GetValue(2).ToString());
                    (_miPresupuesto as Presupuesto).Observaciones = readers.GetValue(3).ToString();
                    readers.Close();

                   return _miPresupuesto; 
               }
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }

            finally
            {
                bd.CerrarConexion();
            }
            return null;
        }

        public String ConsultarCedulaPresupuesto(int nro_presupuesto)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarFKUsuarioPresupuesto]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@nro_presupuesto",nro_presupuesto);

                String id_usuario = null;
                SqlDataReader readerPresupuesto = command.ExecuteReader();
                if (readerPresupuesto.Read())
                {
                    id_usuario = readerPresupuesto.GetValue(0).ToString();
                }
                readerPresupuesto.Close();
                command.Parameters.RemoveAt("@nro_presupuesto");

                command.CommandText = "[dbo].[ConsultarCedulaUsuarioPresupuesto]";
                command.Parameters.AddWithValue("@paramIdUsuario",id_usuario);
                SqlDataReader readerUsuario = command.ExecuteReader();

                if (readerUsuario.Read())
                {
                    return readerUsuario.GetValue(1).ToString();
                }
                    readerUsuario.Close();     
                    return null;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        public Entidad ConsultarDatosBasicosUsuarioPresupuesto(int nro_presupuesto)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "[dbo].[ConsultarFKUsuarioPresupuesto]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@nro_presupuesto", nro_presupuesto);
                String id_usuario = null;
                SqlDataReader readerPresupuesto = command.ExecuteReader();
                if (readerPresupuesto.Read())
                {
                    id_usuario = readerPresupuesto.GetValue(0).ToString();
                }
                readerPresupuesto.Close();
                command.Parameters.RemoveAt("@nro_presupuesto");

                command.CommandText = "[dbo].[ConsultarDatosUsuarioPresupuesto]";
                command.Parameters.AddWithValue("@paramIdUsuario", id_usuario);
                SqlDataReader readerUsuario = command.ExecuteReader();

                if (readerUsuario.Read())
                {
                    _miUsuario = FabricaEntidad.NuevaUsuario();
                    (_miUsuario as Usuario).Identificacion = readerUsuario.GetValue(1).ToString();
                    (_miUsuario as Usuario).TipoIdentificacion = readerUsuario.GetValue(2).ToString();
                    (_miUsuario as Usuario).PrimerNombre = readerUsuario.GetValue(3).ToString();
                    (_miUsuario as Usuario).PrimerApellido = readerUsuario.GetValue(4).ToString();
                    (_miUsuario as Usuario).SegundoApellido = readerUsuario.GetValue(5).ToString();
                    return _miUsuario;
                }

                readerUsuario.Close();
                return null;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        public List<Entidad> ConsultarDetallePresupuesto(int nro_presupuesto)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarDetallePresupuesto]";
                command.CommandTimeout = 10;

                command.Parameters.AddWithValue("@paramIdPresupuesto", nro_presupuesto);
                SqlDataReader readerDetalle = command.ExecuteReader();
                List<Entidad> miListaDetallePresupuesto = new List<Entidad>();

                while (readerDetalle.Read())
                {
                    _miDetallePresupuesto = FabricaEntidad.CrearDetalle_Presupuesto_Factura();
                    (_miDetallePresupuesto as Detalle_Presupuesto_Factura).Cantidad = Int32.Parse(readerDetalle.GetValue(1).ToString());
                    (_miDetallePresupuesto as Detalle_Presupuesto_Factura).Total_pago_tratamiento = float.Parse(readerDetalle.GetValue(2).ToString());
                    (_miDetallePresupuesto as Detalle_Presupuesto_Factura).El_Tratamiento = new Tratamiento();
                    (_miDetallePresupuesto as Detalle_Presupuesto_Factura).El_Tratamiento.Id = short.Parse(readerDetalle.GetValue(0).ToString());
                    miListaDetallePresupuesto.Add(_miDetallePresupuesto);
                }
                //command.Parameters.RemoveAt("@paramIdPresupuesto");
                return miListaDetallePresupuesto;
            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        //public List<Detalle_Presupuesto_Factura> ConsultarTratamientosListaDetalle(List<Detalle_Presupuesto_Factura> listaDetalle)
         public List<Entidad> ConsultarTratamientosListaDetalle(List<Entidad> listaDetalle)
        {
            try
            {
                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarTratamientosDetalle]";
                command.CommandTimeout = 10;

                foreach (Entidad detalle in listaDetalle)
                {
                    command.Parameters.AddWithValue("@paramIdTratamiento", (detalle as Detalle_Presupuesto_Factura).El_Tratamiento.Id);
                    SqlDataReader readerTratamiento = command.ExecuteReader();
                    if (readerTratamiento.Read())
                    {
                        (detalle as Detalle_Presupuesto_Factura).El_Tratamiento.Nombre = readerTratamiento.GetValue(0).ToString();
                    }
                    readerTratamiento.Close();

                    command.Parameters.RemoveAt("@paramIdTratamiento");                
                }

                return listaDetalle;

            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
           //return null;

        }


        #endregion

        #region Generar presupuesto

        public bool AgregarPresupuesto(Entidad elPresupuesto, int idUsuario)
         {
             try
             {
                 bd.AbrirConexion();
                 command = new SqlCommand();
                 command.Connection = bd.ObjetoConexion();
                 command.CommandType = System.Data.CommandType.StoredProcedure;
                 command.CommandText = "[dbo].[AgregarPresupuesto]";
                 command.CommandTimeout = 10;

                 command.Parameters.AddWithValue("@id_usuario", idUsuario);
                 command.Parameters.AddWithValue("@fechaPresupuesto", (elPresupuesto as Presupuesto).Fecha_emision);
                 command.Parameters.AddWithValue("@totalPresupuesto", (elPresupuesto as Presupuesto).Total_presupuesto);
                 command.Parameters.AddWithValue("@ObservacionesPresupuesto", (elPresupuesto as Presupuesto).Observaciones);

                 SqlDataReader readers = command.ExecuteReader();

                 readers.Close();

                 return true;
             }
             catch (SqlException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
             }
             catch (ArgumentException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
             }
             catch (NullReferenceException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
             }
             catch (OutOfMemoryException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
             }
             catch (StackOverflowException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
             }
             catch (Exception e)
             {
                 throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
             }
             finally
             {
                 bd.CerrarConexion();
             }
         }

        public bool AgregarDetallePresupuesto(Presupuesto elPresupuesto, int idUsuario, int idPresupuesto)
         {
             try
             {
                 bd.AbrirConexion();
                 foreach (var detalle in elPresupuesto.Listado_presupuesto)
                 {
                     command = new SqlCommand();
                     command.Connection = bd.ObjetoConexion();
                     command.CommandType = System.Data.CommandType.StoredProcedure;
                     command.CommandText = "[dbo].[AgregarDetallePresupuesto]";
                     command.CommandTimeout = 10;

                     command.Parameters.AddWithValue("@id_usuario", idUsuario);
                     command.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                     command.Parameters.AddWithValue("@monto", detalle.Total_pago_tratamiento);
                     command.Parameters.AddWithValue("@id_Presupuesto", idPresupuesto);
                     command.Parameters.AddWithValue("@id_Tratamiento", detalle.El_Tratamiento.Id);

                     SqlDataReader readers = command.ExecuteReader();

                     readers.Close();

                 }
                 
                 return true;
             }
             catch (SqlException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
             }
             catch (ArgumentException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
             }
             catch (NullReferenceException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
             }
             catch (OutOfMemoryException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
             }
             catch (StackOverflowException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
             }
             catch (Exception e)
             {
                 throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
             }
             finally
             {
                 bd.CerrarConexion();
             }
         }

        public int RegresarIdPresupuesto(Presupuesto elPresupuesto, int id_usuario)
         {
             int regreso = 0;
             try
             {
                 bd.AbrirConexion();
                 command = new SqlCommand();
                 command.Connection = bd.ObjetoConexion();
                 command.CommandType = System.Data.CommandType.StoredProcedure;
                 command.CommandText = "[dbo].[getIdPresupuesto]";
                 command.CommandTimeout = 10;

                 command.Parameters.AddWithValue("@id_usuario", id_usuario); 
                 command.Parameters.AddWithValue("@fecha_Presupuesto", elPresupuesto.Fecha_emision.ToString("yyyy-MM-dd"));
                 command.Parameters.AddWithValue("@total_presupuesto", elPresupuesto.Total_presupuesto);


                 SqlDataReader readers = command.ExecuteReader();

                 while (readers.Read())
                 {

                     regreso = Convert.ToInt16(readers.GetValue(0));
                 }


                 readers.Close();
                 return regreso;
             }
             catch (SqlException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
             }
             catch (ArgumentException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
             }
             catch (NullReferenceException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo", e);
             }
             catch (OutOfMemoryException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
             }
             catch (StackOverflowException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
             }
             catch (Exception e)
             {
                 throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
             }
             finally
             {
                 bd.CerrarConexion();
             }
         }
         
        public Int16 RegresarCostoTratamiento(int id_tratamiento)
         {
             Int16 regreso = 0;

             try
             {
                 bd.AbrirConexion();
                 command = new SqlCommand();

                 command.Connection = bd.ObjetoConexion();
                 command.CommandType = System.Data.CommandType.StoredProcedure;
                 command.CommandText = "[dbo].[RegresoTotalTratamiento]";
                 command.CommandTimeout = 10;

                 command.Parameters.AddWithValue("@idTratamiento", id_tratamiento);
                 SqlDataReader readers = command.ExecuteReader();

                 while (readers.Read())
                     regreso = Convert.ToInt16(readers.GetValue(0));

                 readers.Close();

             }
             catch (SqlException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
             }
             catch (ArgumentException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
             }
             catch (NullReferenceException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo",e);
             }
             catch (OutOfMemoryException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
             }
             catch (StackOverflowException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
             }
             catch (Exception e)
             {
                 throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
             }
             finally
             {
                 bd.CerrarConexion();
             }
             return regreso;
         }

        public int RegresarIdUsuario(string cedulaUsuario)
         {
             int regreso = 0;

             try
             {
                 bd.AbrirConexion();
                 command = new SqlCommand();

                 command.Connection = bd.ObjetoConexion();
                 command.CommandType = System.Data.CommandType.StoredProcedure;
                 command.CommandText = "[dbo].[DevolverIDUsuario]";
                 command.CommandTimeout = 10;


                 command.Parameters.AddWithValue("@paramcedulaUser", cedulaUsuario);
                 SqlDataReader readers = command.ExecuteReader();

                 while (readers.Read())
                 {

                     regreso = Convert.ToInt16(readers.GetValue(0));
                 }


                 readers.Close();


             }
             catch (SqlException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
             }
             catch (ArgumentException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
             }
             catch (NullReferenceException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo",e);
             }
             catch (OutOfMemoryException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
             }
             catch (StackOverflowException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
             }
             catch (Exception e)
             {
                 throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
             }
             finally
             {
                 bd.CerrarConexion();
             }
             return regreso;

         }

        public string regresarDatosUsuario(string cedulaUsuario, string tipoCi)
         {
             string regreso = "";

             try
             {
                 bd.AbrirConexion();
                 command = new SqlCommand();


                 bd.AbrirConexion();
                 command = new SqlCommand();

                 command.Connection = bd.ObjetoConexion();
                 command.CommandType = System.Data.CommandType.StoredProcedure;
                 command.CommandText = "[dbo].[DevolverDatosUsuarioPresupuesto]";
                 command.CommandTimeout = 10;


                 command.Parameters.AddWithValue("@paramcedulaUser", cedulaUsuario);
                 command.Parameters.AddWithValue("@paramUserTipoCi", tipoCi);
                 SqlDataReader readers = command.ExecuteReader();
                 while (readers.Read())
                 {

                     regreso = Convert.ToString(readers.GetValue(2)) + " " + Convert.ToString(readers.GetValue(3));
                 }


                 readers.Close();


             }
             catch (SqlException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
             }
             catch (ArgumentException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
             }
             catch (NullReferenceException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo",e);
             }
             catch (OutOfMemoryException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
             }
             catch (StackOverflowException e)
             {
                 throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
             }
             catch (Exception e)
             {
                 throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
             }
             finally
             {
                 bd.CerrarConexion();
             }
             return regreso;

         }

        #endregion

        #region Validar usuario y regresar id de direccion

        public int RegresarIdDireccionDeUsuario(int idUsuario)
        {
            int regreso = 0;
            try
            {
                bd.AbrirConexion();
                command = new SqlCommand();

                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[getIdDireccionFromUsuario]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@idUsuario", idUsuario);


                SqlDataReader readers = command.ExecuteReader();

                if (readers.Read())
                {
                    regreso = int.Parse(readers.GetValue(0).ToString());
                }

                readers.Close();
                bd.CerrarConexion();
            }
            catch (FormatException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Formato incorrecto de los datos en la base de datos", e);
            }
            
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
                //return 0;
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo",e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
            return regreso;
        }

        public bool validarUsuario(string cedulaUsuario, string tipoCi)
        {
            try
            {
                bd.AbrirConexion();
                command = new SqlCommand();

                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[DevolverDatosUsuarioPresupuesto]";
                command.CommandTimeout = 10;


                command.Parameters.AddWithValue("@paramcedulaUser", cedulaUsuario);
                command.Parameters.AddWithValue("@paramUserTipoCi", tipoCi);

                SqlDataReader readers = command.ExecuteReader();

                if (readers.Read())
                {
                    readers.Close();
                    return true;
                }

                readers.Close();
                bd.CerrarConexion();
                return false;

            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo",e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        #endregion

        #region Procedimientos de Tratamiento


        public List<Entidad> SqlBuscarXNombreTramiento(string nombreTratamientoBuscar)
        {

            List<Entidad> miListaTratamiento = new List<Entidad>();

            try
            {
                //Se abre la conexion a la base de datos
                bd.AbrirConexion();
                command = new SqlCommand();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[buscarPorNombreTratamiento]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@NombreTratamiento", nombreTratamientoBuscar);
                SqlDataReader reader = command.ExecuteReader();

                //Se recorre cada Fila
                while (reader.Read())
                {
                    Entidad miTratamiento = FabricaEntidad.NuevoTratamiento();
                    //Se asigna cada atributo al objeto tratamiento
                   (miTratamiento as Tratamiento).Id = Convert.ToInt16(reader.GetValue(0));
                   (miTratamiento as Tratamiento).Nombre = reader.GetValue(1).ToString();
                   (miTratamiento as Tratamiento).Duracion = Convert.ToInt16(reader.GetValue(2));
                   (miTratamiento as Tratamiento).Descripcion = reader.GetValue(3).ToString();
                   (miTratamiento as Tratamiento).Costo = Convert.ToInt16(reader.GetValue(4));
                   (miTratamiento as Tratamiento).Imagen = reader.GetValue(5).ToString();
                   (miTratamiento as Tratamiento).Explicacion = reader.GetValue(6).ToString();
                   (miTratamiento as Tratamiento).Estado = reader.GetValue(7).ToString();

                    miListaTratamiento.Add(miTratamiento);
                }
                reader.Close();

            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo",e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion(); // cerramos la conexion
            }

            if (miListaTratamiento.Count == 0)
                return null;
            else
                return miListaTratamiento;
        }



        //Declaracion de la entrega2:
        //public Tratamiento SqlBuscarXIdTratamiento(int idTratamientoParametro)
        public Entidad SqlBuscarXIdTratamiento(int idTratamientoParametro)
        {
            //CAMBIAR POR COMANDO CUANDO EL EQUIPO de TRATAMIENTO trabaje su Fabrica:
            //Entidad _miTratamiento = FabricaEntidad.CrearTratamiento();
            Entidad _miTratamiento = FabricaEntidad.NuevoTratamiento();            

            try
            {
                //Se instancia un objeto conexion:
                //Se abre la conexion a la base de datos

                bd.AbrirConexion();
                command.Connection = bd.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.BuscarXIdTratamientos";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@idTratamiento", idTratamientoParametro);
                SqlDataReader readers = command.ExecuteReader();

                //Devuelve una sola fila (un resultado):
                readers.Read();
                //Se asigna cada atributo al objeto tratamiento

                (_miTratamiento as Tratamiento).Id = Convert.ToInt16(readers.GetValue(0));
                (_miTratamiento as Tratamiento).Nombre = readers.GetValue(1).ToString();
                (_miTratamiento as Tratamiento).Duracion = Convert.ToInt16(readers.GetValue(2));
                (_miTratamiento as Tratamiento).Descripcion = readers.GetValue(3).ToString();
                (_miTratamiento as Tratamiento).Costo = Convert.ToInt16(readers.GetValue(4));
                (_miTratamiento as Tratamiento).Imagen = readers.GetValue(5).ToString();
                (_miTratamiento as Tratamiento).Explicacion = readers.GetValue(6).ToString();
                (_miTratamiento as Tratamiento).Estado = readers.GetValue(7).ToString();
                readers.Close();

            }
            catch (SqlException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con la base de datos", e);
            }
            catch (ArgumentException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Parametros no validos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Se esta referenciando a un objeto nulo",e);
            }
            catch (OutOfMemoryException e)
            {
                throw new ExceptionPresupuestoFactura("Error: No se puede reservar memoria mediante el operador new.", e);
            }
            catch (StackOverflowException e)
            {
                throw new ExceptionPresupuestoFactura("Error: La pila de ejecucion esta llena", e);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", e);
            }
            finally
            {
                bd.CerrarConexion();// cerramos la conexion
            }

            if ((_miTratamiento as Tratamiento).Id == 0)
            {
                return null;
            }
            else
                return _miTratamiento;
        }

        #endregion
    }
        

}
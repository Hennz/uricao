using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EAgendaCitas;
using Uricao.Entidades.ETratamientos;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using System.Data;
using System.Data.SqlClient;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using System.Configuration;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOAgendaCitas : DAOSQLServer, iDAOAgendaCitas
    {
        IConexionDAOS db = new ConexionDAOS();

        #region Atributos
        //private Entidad _miCita = FabricaEntidad.NuevaCita();
       // private List<Entidad> miListaCita =new List<Entidad>();

       
        #endregion 



        #region Agregar Cita
       
        public bool AgregarCita(Cita cita, String idcliente, String diaSemana)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr; 
            bool confirmacion = false;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.AgregarCita", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@fechacita", cita._Fecha);
                cmd.Parameters.AddWithValue("@horainiciocita", cita._HoraInicio);
                cmd.Parameters.AddWithValue("@horafincita", cita._HoraFin);
                cmd.Parameters.AddWithValue("@nombremedico", cita._NombreMedico);
                cmd.Parameters.AddWithValue("@apellidomedico", cita._ApellidoMedico);
                cmd.Parameters.AddWithValue("@nombretratamiento", cita._Tratamiento); 
                cmd.Parameters.AddWithValue("@fkidusuario", idcliente);
                cmd.Parameters.AddWithValue("@diasemana", diaSemana);
              

                dr = cmd.ExecuteReader();
                dr.Close();
                //mensaje de confirmacion exitoso
                confirmacion = true;
            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionCita(("Error: " + error.Message), error));
            }
            catch (Exception errorGeneral)
            {
                throw (new ExcepcionCita(("Error: " + errorGeneral.Message), errorGeneral));
            }
            finally
            {
                db.CerrarConexion();
            }            
            return confirmacion;
        }

        #endregion Agregar Cita

       
        
        #region Caso de uso Consultar Cita


        public List<Entidad> ConsultarCitaUnaFecha(String _fecha)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
           
            List<Entidad> miListaCita = new List<Entidad>();
            Entidad _miCita;
           
          
            try
            {

                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.ConsultarCitaPorFecha", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", _fecha);
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    _miCita = FabricaEntidad.NuevaCita();

                    (_miCita as Cita)._Id = Convert.ToInt32(dr.GetInt64(0));
                    (_miCita as Cita)._Fecha = dr.GetDateTime(1);
                    (_miCita as Cita)._HoraInicio = Convert.ToInt32(dr.GetInt32(2));
                    (_miCita as Cita)._HoraFin = Convert.ToInt32(dr.GetInt32(3));
                    (_miCita as Cita)._Confirmacion = dr.GetValue(4).ToString();
                    (_miCita as Cita)._Status = dr.GetValue(5).ToString();
                    (_miCita as Cita)._Tratamiento = dr.GetValue(6).ToString();
                    (_miCita as Cita)._IdMedico = Convert.ToInt16(dr.GetValue(7).ToString());
                    (_miCita as Cita)._NombreMedico = dr.GetString(8);
                    (_miCita as Cita)._ApellidoMedico = dr.GetString(9);


                    miListaCita.Add(_miCita);
                   
                }
                
                db.CerrarConexion();

            
            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionCita(("Error: " + error.Message), error));
            }
            catch (Exception errorGeneral)
            {
                throw (new ExcepcionCita(("Error: " + errorGeneral.Message), errorGeneral));
            }
            finally
            {
                db.CerrarConexion();
            }

            return miListaCita;
        }





        public List<Entidad> ConsultarCitaRangoFecha(String fechaInicio, String fechaFin)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

           // List<Cita> miListaCita = new List<Cita>();
            //Se instancia un objeto conexion 
            SqlCommand command = new SqlCommand();

            List<Entidad> miListaCita = new List<Entidad>();
            Entidad _miCita;
           

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.ConsultarCitaPorRangoFecha", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha1", fechaInicio);
                cmd.Parameters.AddWithValue("@fecha2", fechaFin);
                dr = cmd.ExecuteReader();

                //Se asigna cada atributo al objeto cita
                while (dr.Read())
                {
                    _miCita = FabricaEntidad.NuevaCita();

                    (_miCita as Cita)._Id = Convert.ToInt32(dr.GetInt64(0));
                    //(_miCita as Cita)._Fecha = DateTime.ParseExact(dr.GetValue(1).ToString(), @"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    (_miCita as Cita)._Fecha = dr.GetDateTime(1);
                    (_miCita as Cita)._HoraInicio = Convert.ToInt32(dr.GetInt32(2));
                    (_miCita as Cita)._HoraFin = Convert.ToInt32(dr.GetInt32(3));
                    (_miCita as Cita)._Confirmacion = dr.GetValue(4).ToString();
                    (_miCita as Cita)._Status = dr.GetValue(5).ToString();
                    (_miCita as Cita)._Tratamiento = dr.GetValue(6).ToString();
                    (_miCita as Cita)._IdMedico = Convert.ToInt16(dr.GetValue(7).ToString());
                    (_miCita as Cita)._NombreMedico = dr.GetString(8);
                    (_miCita as Cita)._ApellidoMedico = dr.GetString(9);

                    miListaCita.Add(_miCita);
                    
                }

                db.CerrarConexion();


            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionCita(("Error: " + error.Message), error));
            }
            catch (Exception errorGeneral)
            {
                throw (new ExcepcionCita(("Error: " + errorGeneral.Message), errorGeneral));
            }
            finally
            {
                db.CerrarConexion();
            }


            return miListaCita;
        }




        public List<Entidad> ConsultarCitaPorCedulaUsuario(String _cedulaPaciente)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            //List<Cita> miListaCita = new List<Cita>();
            //Se instancia un objeto conexion 
            List<Entidad> miListaCita = new List<Entidad>();
            Entidad _miCita;

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.ConsultarCitaPorCedulaUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", _cedulaPaciente);
                dr = cmd.ExecuteReader();
                

                //Se asigna cada atributo al objeto cita
                while (dr.Read())
                {
                    _miCita = FabricaEntidad.NuevaCita();

                    (_miCita as Cita)._Id = Convert.ToInt32(dr.GetInt64(0));
                    (_miCita as Cita)._Fecha = dr.GetDateTime(1);
                    (_miCita as Cita)._HoraInicio = Convert.ToInt32(dr.GetInt32(2));
                    (_miCita as Cita)._HoraFin = Convert.ToInt32(dr.GetInt32(3));
                    (_miCita as Cita)._Confirmacion = dr.GetValue(4).ToString();
                    (_miCita as Cita)._Status = dr.GetValue(5).ToString();
                    (_miCita as Cita)._Tratamiento = dr.GetValue(6).ToString();
                    (_miCita as Cita)._IdMedico = Convert.ToInt16(dr.GetValue(7).ToString());
                    (_miCita as Cita)._NombreMedico = dr.GetString(8);
                    (_miCita as Cita)._ApellidoMedico = dr.GetString(9);

                    miListaCita.Add(_miCita);
                }

                db.CerrarConexion();


            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionCita(("Error: " + error.Message), error));
            }
            catch (Exception errorGeneral)
            {
                throw (new ExcepcionCita(("Error: " + errorGeneral.Message), errorGeneral));
            }
            finally
            {
                db.CerrarConexion();
            }

            return miListaCita;
        }



        public List<Entidad> ConsultarCitaPorNombreMedico(String _nombre, String _apellido)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
           // List<Cita> miListaCita = new List<Cita>();
            //
            List<Entidad> miListaCita = new List<Entidad>();
            Entidad _miCita;

             try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.ConsultarCitaPorNombreMedico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", _nombre);
                cmd.Parameters.AddWithValue("@apellido", _apellido);
                dr = cmd.ExecuteReader();

                //Se asigna cada atributo al objeto cita
                while (dr.Read())
                {
                    _miCita = FabricaEntidad.NuevaCita();

                    (_miCita as Cita)._Id = Convert.ToInt32(dr.GetInt64(0));
                    (_miCita as Cita)._Fecha = dr.GetDateTime(1);
                    (_miCita as Cita)._HoraInicio = Convert.ToInt32(dr.GetInt32(2));
                    (_miCita as Cita)._HoraFin = Convert.ToInt32(dr.GetInt32(3));
                    (_miCita as Cita)._Confirmacion = dr.GetValue(4).ToString();
                    (_miCita as Cita)._Status = dr.GetValue(5).ToString();
                    (_miCita as Cita)._Tratamiento = dr.GetValue(6).ToString();
                    (_miCita as Cita)._IdMedico = Convert.ToInt16(dr.GetValue(7).ToString());
                    (_miCita as Cita)._NombreMedico = dr.GetString(8);
                    (_miCita as Cita)._ApellidoMedico = dr.GetString(9);

                    miListaCita.Add(_miCita);
                }

                db.CerrarConexion();


            }
             catch (SqlException error)
             {
                 //En caso de que se viole alguna restriccion sobre la BD
                 throw (new ExcepcionCita(("Error: " + error.Message), error));
             }
             catch (Exception errorGeneral)
             {
                 throw (new ExcepcionCita(("Error: " + errorGeneral.Message), errorGeneral));
             }
             finally
             {
                 db.CerrarConexion();
             }


            return miListaCita;
        }

        #endregion


        //Para el agregar una fecha

        
        #region ConsultarHorarioMedicoUnafecha


        public int[] ConsultarHorarioMedicoUnaFecha(String nombremedico, String apellidomedico, String diaSemana, String tratamiento)
        {
            //Se instancia un objeto conexion 
            ConexionDAOS miConexion = new ConexionDAOS();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            int[] _horariomedico= new int[8]; 
            try
            {
                //Se abre la conexion a la base de datos
                miConexion.AbrirConexion();
                command.Connection = miConexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConsultarHorarioMedico]";
                command.CommandTimeout = 10;
                command.Parameters.AddWithValue("@nombremedico", nombremedico);
                command.Parameters.AddWithValue("@apellidomedico", apellidomedico);
                command.Parameters.AddWithValue("@tratamiento", tratamiento);
                command.Parameters.AddWithValue("@diaSemana", diaSemana);


                //se ejecuta el metodo del store procedure que busca todos las del sistema
                reader = command.ExecuteReader();

                //Se asigna cada atributo al arregloque tiene el horario del medico
                while (reader.Read())
                {
                   
                

                    _horariomedico[0] = Convert.ToInt32(reader.GetInt32(0));
                    _horariomedico[1] = Convert.ToInt32(reader.GetInt32(1));
                    _horariomedico[2] = Convert.ToInt32(reader.GetInt32(2));

                   

                }

            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionCita(("Error: " + error.Message), error));
            }
            catch (Exception errorGeneral)
            {
                //uso interno del grupo 7, para capturar cualquier excepcion y posterior estudio para solventar el problema
                throw (new ExcepcionCita(("Error: " + errorGeneral.Message), errorGeneral));
            }

            finally
            {
                // se cierra la conexion
                miConexion.CerrarConexion();
            }

            return _horariomedico;
        }



        #endregion ConsultarHorarioMedicoUnafecha

        #region ConsultarCitasActualesUnaFecha


        public List<Entidad> ConsultarCitasActualesUnaFecha(String nombremedico, String apellidomedico, DateTime fecha)
        {
            //Se instancia un objeto conexion 
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr; 
            List<Entidad> listaCitas = new List<Entidad>();
            Entidad _miCita;

            try
            {
                //Se abre la conexion a la base de datos
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.ConsultarCitasActuales", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@nombremedico", nombremedico);
                cmd.Parameters.AddWithValue("@apellidomedico", apellidomedico);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                //se ejecuta el metodo del store procedure que busca todos las del sistema
                dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    _miCita = FabricaEntidad.NuevaCita();

                    (_miCita as Cita)._Id = Convert.ToInt32(dr.GetInt64(0));
                    (_miCita as Cita)._Fecha = dr.GetDateTime(1);
                    (_miCita as Cita)._HoraInicio = Convert.ToInt32(dr.GetInt32(2));
                    (_miCita as Cita)._HoraFin = Convert.ToInt32(dr.GetInt32(3));


                    listaCitas.Add(_miCita);

                }

                db.CerrarConexion();
              
                
            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionCita(("Error: " + error.Message), error));
            }

            finally
            {
                // se cierra la conexion
                db.CerrarConexion();
            }

            //return _citasActuales;
            return listaCitas;
        }



        #endregion ConsultarDisponibilidadCitaUnaFecha






        





        //Para cancelar y confirmar cita
        #region CancelarCita

        public bool CancelarCita(int idCita)
        {
            //se instancia un objeto de tipo conexion y sqlCommand
            //estos se utilizan para acceder a base de datos y ejecutar el stored procedure en sql server
            ConexionDAOS miConexion = new ConexionDAOS();
            SqlCommand command = new SqlCommand();

            try
            {
                miConexion.AbrirConexion(); //se abre una conexion a base de datos

                // se completa el objeto comando, con la informacion de la conexion , variables, y nombre del stored procedure.
                command.Connection = miConexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[CancelarCita]"; // nombre del StoreProcedure "modificarInvolucrado"
                command.CommandTimeout = 10;

                //variables del stored procedure de sql server.
                command.Parameters.AddWithValue("@idcita", idCita);


                command.Parameters["@idcita"].Direction = ParameterDirection.Input;


                //se ejecuta el comando
                command.ExecuteReader();

                // hacemos el return del ID del cliente para verficar que efectivamente se inserto el cliente
                return true;
            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionCita(("Error: " + error.Message), error));

            }
            catch (Exception errorGeneral)
            {
                //uso interno del grupo 7, para capturar cualquier excepcion y posterior estudio para solventar el problema
                throw (new ExcepcionCita(("Error: " + errorGeneral.Message), errorGeneral));

            }

            finally
            {
                miConexion.CerrarConexion();
            }
        }
        #endregion CancelarCita




        #region ConfirmarCita

        public bool ConfirmarCita(int idCita)
        {
            //se instancia un objeto de tipo conexion y sqlCommand
            //estos se utilizan para acceder a base de datos y ejecutar el stored procedure en sql server
            ConexionDAOS miConexion = new ConexionDAOS();
            SqlCommand command = new SqlCommand();

            try
            {
                miConexion.AbrirConexion(); //se abre una conexion a base de datos

                // se completa el objeto comando, con la informacion de la conexion , variables, y nombre del stored procedure.
                command.Connection = miConexion.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[ConfirmarCita]"; // nombre del StoreProcedure "modificarInvolucrado"
                command.CommandTimeout = 10;

                //variables del stored procedure de sql server.
                command.Parameters.AddWithValue("@idcita", idCita);


                command.Parameters["@idcita"].Direction = ParameterDirection.Input;


                //se ejecuta el comando
                command.ExecuteReader();

                // hacemos el return del ID del cliente para verficar que efectivamente se inserto el cliente
                return true;
            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionCita(("Error: " + error.Message), error));
                return false;
            }
            catch (Exception errorGeneral)
            {
                //uso interno del grupo 7, para capturar cualquier excepcion y posterior estudio para solventar el problema
                throw (new ExcepcionCita(("Error: " + errorGeneral.Message), errorGeneral));
                return false;
            }

            finally
            {
                miConexion.CerrarConexion();
            }
        }
        #endregion ConfirmarCita




        #region ModificarCita

        public bool ModificarCita(int _idCita, String _fecha, int _horaInicio, int _horaFin, String _tratamiento, String _nombreMedico, String _apellidoMedico, String _diaSemana)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("dbo.ModificarUnaCita", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcita",_idCita );
                cmd.Parameters.AddWithValue("@fechacita",_fecha );
                cmd.Parameters.AddWithValue("@horainiciocita",_horaInicio );
                cmd.Parameters.AddWithValue("@horafincita",_horaFin );
                cmd.Parameters.AddWithValue("@tratamiento",_tratamiento );
                cmd.Parameters.AddWithValue("@nombremedico", _nombreMedico);
                cmd.Parameters.AddWithValue("@apellidomedico",_apellidoMedico );
                cmd.Parameters.AddWithValue("@diasemana", _diaSemana);
                
               
                dr = cmd.ExecuteReader();



                //Se asigna cada atributo al objeto cita
               
                

                db.CerrarConexion();


            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionCita(("Error: " + error.Message), error));
                return false;
            }
            catch (Exception errorGeneral)
            {
                throw (new ExcepcionCita(("Error: " + errorGeneral.Message), errorGeneral));
                return false;
            }
            finally
            {
                db.CerrarConexion();
            }


            return true;
        }




        #endregion ModificarCita






    }
}
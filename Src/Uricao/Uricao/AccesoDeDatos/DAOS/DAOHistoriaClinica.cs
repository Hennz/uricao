// File: DAOHistoriaClinica.cs Company: La Cruz 
// Copyright (c) 01-08-2013 All Right Reserved
// author: Enrique La Cruz
using System;
using System.Collections.Generic;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;
using Uricao.Entidades.EHistoriaPaciente;
using System.Data;
using System.Data.SqlClient;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.IDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.AccesoDeDatos.Excepciones_A.Datos;

namespace Uricao.AccesoDeDatos.DAOS
{
    public class DAOHistoriaClinica : DAOSQLServer, iDAOHistoriaClinica
    {
        #region atributos
        private IConexionDAOS _conexion;
        private SqlCommand _cmd;
        private SqlDataReader _dr;
        //variable para devolver 
        private List<Entidad> _miLista;
        private bool _confirmacion;
        private int _idHistoriaClinica;
        #endregion

        #region Constructor de la clase
        public DAOHistoriaClinica()
        {
            //Peticion de nuevo objeto para la conexion
            _conexion = FabricaConexion.AccesoConexion();
            //Declaro comando sql para la ejecucion de funciones sql
            _cmd= new SqlCommand();
            _miLista =  new List<Entidad>();
            _confirmacion = false;
            _idHistoriaClinica = 0;
        }
        #endregion

        /*Consulta/Busqueda*/

        #region Consultar Todas las Historias Clinicas
        /***Metodo que devuelve todas las historias clinicas en la Base de datos***/
        public List<Entidad> ConsultarTodasHistoriaClinica()
        {          
            //List<string> telefono = new List<string>();
            Entidad _miHistoria;
            Entidad _cliente;
            try
            {
                _conexion.AbrirConexion();
                _cmd = new SqlCommand("dbo.BuscarTodasHistoriaClinica", _conexion.ObjetoConexion());
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 10;
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    _miHistoria = FabricaEntidad.NuevaHistoria();
                    _cliente = FabricaEntidad.NuevoCliente();

                    
                    (_cliente as Cliente).IdUsuario = Convert.ToInt32(_dr.GetValue(0));
                    (_cliente as Cliente).PrimerNombre = _dr.GetValue(1).ToString();
                    (_cliente as Cliente).SegundoNombre = _dr.GetValue(2).ToString();
                    (_cliente as Cliente).PrimerApellido = _dr.GetValue(3).ToString();
                    (_cliente as Cliente).SegundoApellido= _dr.GetValue(4).ToString();
                    (_cliente as Cliente).FechaNace = _dr.GetDateTime(5);
                    (_cliente as Cliente).Sexo = _dr.GetValue(6).ToString();
                    (_cliente as Cliente).Identificacion = _dr.GetValue(7).ToString();
                   /*(_cliente as Cliente).Direccion.Nombre = dr.GetValue(8).ToString();
                    (_cliente as Cliente).Direccion.Tipo = dr.GetValue(9).ToString();
                    telefono.Add(dr.GetValue(10).ToString());
                    telefono.Add(dr.GetValue(11).ToString());
                    telefono.Add(dr.GetValue(12).ToString());
                    (_cliente as Cliente).Telefono = telefono;*/
                    (_miHistoria as HistoriaClinica).Paciente = (_cliente as Cliente);                  
                    (_miHistoria as HistoriaClinica).FechaIngreso = Convert.ToDateTime(_dr.GetValue(8));
                    (_miHistoria as HistoriaClinica).NumeroHistoria = Convert.ToInt32(_dr.GetValue(9));
                    (_miHistoria as HistoriaClinica).Observacion = _dr.GetValue(10).ToString();
                    (_miHistoria as HistoriaClinica).Estado = _dr.GetValue(11).ToString().ToLower();
                    _miLista.Add(_miHistoria);
                
                }

                _conexion.CerrarConexion();

            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion();
            }
            return _miLista;
        }
        #endregion

        #region Consultar Historia Clinica
        /***Metodo que devuelve la historia clinica asociada a un nombre, apellido, cedula, o id de la Base de datos***/
        public List<Entidad> ConsultarHistoriaClinica(String nombre, String apellido, String cedula, int idHistoria)
        {
            //List<string> telefono = new List<string>();
            Entidad _miHistoria;
            Entidad _cliente;
            try
            {
                _conexion.AbrirConexion();
                _cmd = new SqlCommand("dbo.BuscarHistoriaClinica", _conexion.ObjetoConexion());
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 10;
                _cmd.Parameters.AddWithValue("@nombre", nombre);
                _cmd.Parameters.AddWithValue("@apellido", apellido);
                _cmd.Parameters.AddWithValue("@cedula", cedula);
                _cmd.Parameters.AddWithValue("@idHistoria", idHistoria);

                _cmd.Parameters["@nombre"].Direction = ParameterDirection.Input;
                _cmd.Parameters["@apellido"].Direction = ParameterDirection.Input;
                _cmd.Parameters["@cedula"].Direction = ParameterDirection.Input;
                _cmd.Parameters["@idHistoria"].Direction = ParameterDirection.Input;

                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    _miHistoria =FabricaEntidad.NuevaHistoria();
                    _cliente = FabricaEntidad.NuevoCliente();

                    (_cliente as Cliente).IdUsuario = Convert.ToInt32(_dr.GetValue(0));
                    (_cliente as Cliente).PrimerNombre = _dr.GetValue(1).ToString();
                    (_cliente as Cliente).SegundoNombre = _dr.GetValue(2).ToString();
                    (_cliente as Cliente).PrimerApellido = _dr.GetValue(3).ToString();
                    (_cliente as Cliente).SegundoApellido = _dr.GetValue(4).ToString();
                    (_cliente as Cliente).FechaNace = _dr.GetDateTime(5);
                    (_cliente as Cliente).Sexo = _dr.GetValue(6).ToString();
                    (_cliente as Cliente).Identificacion = _dr.GetValue(7).ToString();
                    /*  (_cliente as Cliente).Direccion.Nombre = dr.GetValue(8).ToString();
                      (_cliente as Cliente).Direccion.Tipo = dr.GetValue(9).ToString();
                      telefono.Add(dr.GetValue(10).ToString());
                      telefono.Add(dr.GetValue(11).ToString());
                      telefono.Add(dr.GetValue(12).ToString());
                      (_cliente as Cliente).Telefono = telefono;*/
                    (_miHistoria as HistoriaClinica).Paciente = (_cliente as Cliente);
                    (_miHistoria as HistoriaClinica).FechaIngreso = Convert.ToDateTime(_dr.GetValue(8));
                    (_miHistoria as HistoriaClinica).NumeroHistoria = Convert.ToInt32(_dr.GetValue(9));
                    (_miHistoria as HistoriaClinica).Observacion = _dr.GetValue(10).ToString();
                    (_miHistoria as HistoriaClinica).Estado = _dr.GetValue(11).ToString().ToLower();
                    _miLista.Add(_miHistoria);
                }
                
                _conexion.CerrarConexion();

            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion();
            }
            return _miLista;
        }
        #endregion

        #region Consultar Antecedente
        /***Metodo que devuelve los antecedentes de una determinada historia***/
        public List<Entidad> ConsultarAntecedente(int idHistoriaClinica)
        {
            Entidad _miAntecedente;
            try
            {
                _conexion.AbrirConexion();
                _cmd = new SqlCommand("dbo.ConsultarAntecedente", _conexion.ObjetoConexion());
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 10;
                _cmd.Parameters.AddWithValue("@idHistoria", idHistoriaClinica);
                _cmd.Parameters["@idHistoria"].Direction = ParameterDirection.Input;
                _dr = _cmd.ExecuteReader();

                    while (_dr.Read())
                    {
                        _miAntecedente = FabricaEntidad.NuevoAntecedente();
                        (_miAntecedente as Antecedente).IdAntecedente = Convert.ToInt32(_dr.GetValue(0).ToString());
                        (_miAntecedente as Antecedente).Respuesta = _dr.GetValue(1).ToString().ToLower();
                        _miLista.Add(_miAntecedente);
                    }
                
                _conexion.CerrarConexion();
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            return _miLista;
        }        
        #endregion

        #region Consultar Secuencia
        /***Metodo que devuelve las secuencias de una determinada historia***/
        public List<Entidad> ConsultarSecuencia(int idHistoria)
        {
            Entidad _miSecuencia;
            Entidad _doctor;
            Entidad _tratamiento;
            try
            {
                _conexion.AbrirConexion();
                _cmd = new SqlCommand("dbo.consultarSecuencia", _conexion.ObjetoConexion());
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 10;
                _cmd.Parameters.AddWithValue("@idHistoriaClinica", idHistoria);
                _cmd.Parameters["@idHistoriaClinica"].Direction = ParameterDirection.Input;
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    _miSecuencia = FabricaEntidad.NuevoDetalleSecuencia();
                    _doctor = FabricaEntidad.NuevaUsuario();
                    _tratamiento = FabricaEntidad.NuevoTratamiento();


                    (_miSecuencia as DetalleSecuencia).IdSecuencia = Convert.ToInt32(_dr.GetValue(0));
                    (_miSecuencia as DetalleSecuencia).Observacion = _dr.GetValue(1).ToString();
                    (_miSecuencia as DetalleSecuencia).Fecha = _dr.GetDateTime(2);
                    (_miSecuencia as DetalleSecuencia).Pieza = _dr.GetValue(3).ToString();
                    (_miSecuencia as DetalleSecuencia).Diagnostico = _dr.GetValue(4).ToString();
                    (_miSecuencia as DetalleSecuencia).Estado = _dr.GetValue(5).ToString();

                    (_tratamiento as Tratamiento).Id = Convert.ToInt16(_dr.GetValue(6).ToString());
                    (_doctor as Usuario).IdUsuario = Convert.ToInt32(_dr.GetValue(7).ToString());

                    (_miSecuencia as DetalleSecuencia).Odontologo = (_doctor as Usuario);
                    (_miSecuencia as DetalleSecuencia).Tratamiento = (_tratamiento as Tratamiento);
                    _miLista.Add(_miSecuencia);
                }

                _conexion.CerrarConexion();

            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion();
            }
            return _miLista;
        }        
        #endregion

        #region Consultar Secuencia
        /***Metodo que devuelve las secuencia por Id Secuencia***/
        public Entidad ConsultarSecuenciaXid(int idSecuencia)
        {
            Entidad _miSecuencia;
            Entidad _doctor;
            Entidad _tratamiento;
            try
            {
                _conexion.AbrirConexion();
                _cmd = new SqlCommand("dbo.consultarSecuenciaXid", _conexion.ObjetoConexion());
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 10;
                _cmd.Parameters.AddWithValue("@idHistoriaSecuencia", idSecuencia);
                _cmd.Parameters["@idHistoriaSecuencia"].Direction = ParameterDirection.Input;
                _dr = _cmd.ExecuteReader();

                _dr.Read();
                
                    _miSecuencia = FabricaEntidad.NuevoDetalleSecuencia();
                    _doctor = FabricaEntidad.NuevaUsuario();
                    _tratamiento = FabricaEntidad.NuevoTratamiento();


                    (_miSecuencia as DetalleSecuencia).IdSecuencia = Convert.ToInt32(_dr.GetValue(0));
                    (_miSecuencia as DetalleSecuencia).Observacion = _dr.GetValue(1).ToString();
                    (_miSecuencia as DetalleSecuencia).Fecha = _dr.GetDateTime(2);
                    (_miSecuencia as DetalleSecuencia).Pieza = _dr.GetValue(3).ToString();
                    (_miSecuencia as DetalleSecuencia).Diagnostico = _dr.GetValue(4).ToString();
                    (_miSecuencia as DetalleSecuencia).Estado = _dr.GetValue(5).ToString();

                    (_tratamiento as Tratamiento).Id = Convert.ToInt16(_dr.GetValue(6).ToString());
                    (_doctor as Usuario).IdUsuario = Convert.ToInt32(_dr.GetValue(7).ToString());

                    (_miSecuencia as DetalleSecuencia).Odontologo = (_doctor as Usuario);
                    (_miSecuencia as DetalleSecuencia).Tratamiento = (_tratamiento as Tratamiento);


                _conexion.CerrarConexion();

            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion();
            }
            return _miSecuencia;
        }    

        #endregion 

        #region Buscar Ultima idHistoria
        /***Metodo que devuelve el Id de la ultima historia insertada***/
        public int BuscarUltimaId()
        {
            
            try
            {
                //Buscar Id Max Historia Clinica
                _conexion.AbrirConexion();
                _cmd = new SqlCommand("dbo.UltimaHistoria", _conexion.ObjetoConexion());
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 10;
                _dr = _cmd.ExecuteReader();

                //Se recorre cada row
                _dr.Read();
                _idHistoriaClinica = Convert.ToInt32(_dr.GetValue(0));

                _conexion.CerrarConexion();
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                //se cierra la conexion a la BD
                _conexion.CerrarConexion();
            }
            return _idHistoriaClinica;
        }
        #endregion

        /*Insercion*/

        #region Agregar Historia Clinica    
        /***Metodo que agrega a la base de datos una Historia Clinica***/
         public bool AgregarHistoriaClinica(Entidad historiaClinica)
        {
            try
            {

                _conexion.AbrirConexion();
                _cmd = new SqlCommand("dbo.agregarHistoriaClinica", _conexion.ObjetoConexion());
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 10;
                _cmd.Parameters.AddWithValue("@fechaHistoriaClinica", (historiaClinica as HistoriaClinica).FechaIngreso);
                _cmd.Parameters.AddWithValue("@fkIdUsuario", (historiaClinica as HistoriaClinica).Paciente.IdUsuario);
                _cmd.Parameters.AddWithValue("@observacionHistoriaClinica", (historiaClinica as HistoriaClinica).Observacion);
                _cmd.Parameters.AddWithValue("@estadoHistoriaClinica", (historiaClinica as HistoriaClinica).Estado);
                SqlDataReader dr = _cmd.ExecuteReader();

                dr.Close();

                //mensaje de confirmacion exitoso
                _confirmacion = true;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                //se cierra la conexion a la BD
                _conexion.CerrarConexion();
            }
            return _confirmacion;
        }
        #endregion

        #region AgregarAntecedente     
        /*** Metodo que agrega respuestas a sus antecedentes correspondientes***/  
        public bool AgregarAntecedente(List<String> _respuestas, int idHistoriaClinica)
        {
            
            try
            {
                if (idHistoriaClinica == 0)
                {
                    idHistoriaClinica = BuscarUltimaId();
                }

                //Abro para insertar
                _conexion.AbrirConexion();
                foreach (String respuesta in _respuestas)
                {

                    //int idantecedente = i + 1;
                    _cmd = new SqlCommand("dbo.agregarAntecedente", _conexion.ObjetoConexion());
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.CommandTimeout = 10;
                    _cmd.Parameters.AddWithValue("@respuestaAntecedente", respuesta);
                    _cmd.Parameters.AddWithValue("@fkIdHistoriaClinica", idHistoriaClinica);
                    _dr = _cmd.ExecuteReader();
                    _dr.Read();
                    _dr.Close();
                }

                _confirmacion = true;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                //se cierra la conexion a la BD
                _conexion.CerrarConexion();
            }
            return _confirmacion;

        }

        #endregion

        #region Agregar Secuencia
        /**** Metodo que agrega una secuencia de tratamiento***/
        public bool AgregarSecuencia(List<Entidad> _secuencia, int idHistoria)
        {
            try
            {
                if (idHistoria == 0)
                {
                    idHistoria = BuscarUltimaId();
                }
                //Abro para insertar

                _conexion.AbrirConexion();
                foreach (Entidad secuencia in _secuencia)
                {

                    //int idantecedente = i + 1;
                    _cmd = new SqlCommand("dbo.agregarSecuencia", _conexion.ObjetoConexion());
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.CommandTimeout = 10;
                    _cmd.Parameters.AddWithValue("@observacionSecuencia", (secuencia as DetalleSecuencia).Observacion);
                    _cmd.Parameters.AddWithValue("@fkIdTratamiento", (secuencia as DetalleSecuencia).Tratamiento.Id);
                    _cmd.Parameters.AddWithValue("@fkIdDoctor", (secuencia as DetalleSecuencia).Odontologo.IdUsuario);
                    _cmd.Parameters.AddWithValue("@fechaSecuencia", (secuencia as DetalleSecuencia).Fecha);
                    _cmd.Parameters.AddWithValue("@fkIdHistoriaClinica",idHistoria);
                    _cmd.Parameters.AddWithValue("@piezaSecuencia", (secuencia as DetalleSecuencia).Pieza);
                    _cmd.Parameters.AddWithValue("@diagnosticoSecuencia", (secuencia as DetalleSecuencia).Diagnostico);
                    _cmd.Parameters.AddWithValue("@estadoSecuencia", (secuencia as DetalleSecuencia).Estado);
                    _dr = _cmd.ExecuteReader();
                    _dr.Read();
                    _dr.Close();

                }

                _confirmacion = true;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                //se cierra la conexion a la BD
                _conexion.CerrarConexion();
            }
            return _confirmacion;

        }
        #endregion

        /* Modificar */

        #region Modificar Historia Clinica
        /**** Metodo que modifica una historia de la BD***/
        public bool ModificarHistoriaClinica(Entidad _historiaClinica)
        {

            try
            {
                _conexion.AbrirConexion();
                _cmd = new SqlCommand("dbo.ModificarHistoriaClinica", _conexion.ObjetoConexion());
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 10;
                _cmd.Parameters.AddWithValue("@idHistoria", (_historiaClinica as HistoriaClinica).NumeroHistoria);
                _cmd.Parameters.AddWithValue("@fechaHistoria", (_historiaClinica as HistoriaClinica).FechaIngreso);
                _cmd.Parameters.AddWithValue("@observacion", (_historiaClinica as HistoriaClinica).Observacion);
                /*cmd.Parameters.AddWithValue("@estadoHistoria", (_historiaClinica as HistoriaClinica).Estado);*/
                _dr = _cmd.ExecuteReader();
                _dr.Read();
                _dr.Close();
                //asigno true a variable confirmacion
                _confirmacion = true;
            
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                //se cierra la conexion a la BD
                _conexion.CerrarConexion();
            }
            return _confirmacion;
        }
        #endregion

        #region Modificar Antecedente
        /***Metodo que modifica los antecedentes de una determinada historia***/
        public bool ModificarAntecedente(List<Entidad> _respuestas)
        {
            try
            {
                _conexion.AbrirConexion();
                foreach (Entidad respuesta in _respuestas)
                {

                    //int idantecedente = i + 1;
                    _cmd = new SqlCommand("dbo.modificarAntecedentes", _conexion.ObjetoConexion());
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.CommandTimeout = 10;
                    _cmd.Parameters.AddWithValue("@respuesta", (respuesta as Antecedente).Respuesta);
                    _cmd.Parameters.AddWithValue("@idAntecedente",(respuesta as Antecedente).IdAntecedente);
                    _dr = _cmd.ExecuteReader();
                    _dr.Read();
                    _dr.Close();

                }
                _confirmacion = true;

            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                //se cierra la conexion a la BD
                _conexion.CerrarConexion();
            }
            return _confirmacion;        
        }
        #endregion

        #region Modificar Secuencia
        /***Metodo que modifica la secuencia de una determinada historia***/
        public bool ModificarSecuencia(List<Entidad> _secuencias)
        {
            try
            {
                _conexion.AbrirConexion();
                foreach (Entidad secuencia in _secuencias)
                {

                    _cmd = new SqlCommand("dbo.modificarSecuencia", _conexion.ObjetoConexion());
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.CommandTimeout = 10;
                    _cmd.Parameters.AddWithValue("@idSecuencia", (secuencia as DetalleSecuencia).IdSecuencia);
                    _cmd.Parameters.AddWithValue("@observacionSecuencia", (secuencia as DetalleSecuencia).Observacion);
                    _cmd.Parameters.AddWithValue("@fkIdTratamiento ", (secuencia as DetalleSecuencia).Tratamiento.Id);
                    _cmd.Parameters.AddWithValue("@fkIdDoctor", (secuencia as DetalleSecuencia).Odontologo.IdUsuario);
                    _cmd.Parameters.AddWithValue("@fechaSecuencia", (secuencia as DetalleSecuencia).Fecha);
                    _cmd.Parameters.AddWithValue("@piezaSecuencia", (secuencia as DetalleSecuencia).Pieza);
                    _cmd.Parameters.AddWithValue("@diagnosticoSecuencia", (secuencia as DetalleSecuencia).Diagnostico);
                    _dr = _cmd.ExecuteReader();
                    _dr.Read();
                    _dr.Close();
                 
                }
                _confirmacion = true;

            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                //se cierra la conexion a la BD
                _conexion.CerrarConexion();
            }
            return _confirmacion;
        }
        #endregion

        /* Activar/Inactivar */

        #region Activar/Inactivar Historia Clinica
        /*** Metodo que activa o desactiva una Hisotia Clinica ***/
        public bool ActivarDesactivarHistoriaClinica(int idHistoriaClinica, String estado)
        {
            estado = estado.ToLower();
            switch(estado)
            {
                case "activo" : estado = "inactivo";
                    break;
                case "inactivo" : estado = "activo";
                    break;
            }

            try
            {
                _conexion.AbrirConexion();
                _cmd = new SqlCommand("dbo.ActivarDesactivarHistoriaClinica", _conexion.ObjetoConexion());
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 10;
                _cmd.Parameters.AddWithValue("@idHistoria", idHistoriaClinica);
                _cmd.Parameters.AddWithValue("@estadoHistoria", estado);
                _dr = _cmd.ExecuteReader();
                _dr.Read();
                _dr.Close();
                _confirmacion = true;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                //se cierra la conexion a la BD
                _conexion.CerrarConexion();
            }
            return _confirmacion;
        }
        #endregion

        #region Activar/Inactivar Secuencia
        /*** Metodo que activa o desactiva una secuencia ***/
        public bool ActivarDesactivarSecuencia(int idSecuencia, String estado)
        {
            bool confirmacion = false;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            estado = estado.ToLower();
            switch (estado)
            {
                case "activo": estado = "inactivo";
                    break;
                case "inactivo": estado = "activo";
                    break;
            }
            try
            {
                _conexion.AbrirConexion();
                cmd = new SqlCommand("dbo.ActivarDesactivarSecuencia", _conexion.ObjetoConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@idSecuencia", idSecuencia);
                cmd.Parameters.AddWithValue("@estadoSecuencia", estado);
                dr = cmd.ExecuteReader();
                dr.Read();
                dr.Close();
                confirmacion = true;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                //se cierra la conexion a la BD
                _conexion.CerrarConexion();
            }
            return confirmacion;
        }
        #endregion

        /*---------------------------------------------------------------- Usado por otros modulos ------------------------------------*/

        #region Consultar ID Tratamiento
        /// <summary>
        /// Metodo que consulta el Id del Tratamiento dado el nombre 
        /// Tratamiento
        /// </summary>
        /// <param name="tratamiento"></param>
        /// <returns></returns>
        public int ConsultarIdTratamiento(string tratamiento)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            int numero = 0;

            try
            {

                _conexion.AbrirConexion();
                cmd = new SqlCommand("dbo.consultarTratamientoId", _conexion.ObjetoConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreTratamiento", tratamiento);
                cmd.CommandTimeout = 10;//OJO
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                dr.Read();
                numero = Convert.ToInt32(dr.GetValue(0));

                _conexion.CerrarConexion();
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Tratamiento no encontrado", e);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error con la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDAOHistoriaClinica("Error en la Consulta de los datos", e);
            }
            finally
            {
                _conexion.CerrarConexion();
            }
            return numero;

        }
        #endregion
    }
}

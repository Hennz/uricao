using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.AccesoDeDatos.Conexion.InterfazConexion
{
    public class ConexionDAOS : IConexionDAOS
    {
        private static String cadenaConexion;
        SqlConnection objetoConexion;
        private static SqlConnection conexion;

        public ConexionDAOS()
        {
            try
            {
                objetoConexion = null;
                cadenaConexion = ConfigurationManager.ConnectionStrings["ConnUricao"].ToString();
                conexion = new SqlConnection(cadenaConexion);
            }
            catch (NullReferenceException)
            {
                throw new ExcepcionConexion("El estring de conexion del WebConfig no puede ser localizado");
                
            }


        }
        
        public static SqlConnection AccederAconexion
        {

            get { return conexion; }

            set { conexion = value; }

        }

        //Metodo para abrir la conexion
        public void AbrirConexion()
        {

            if (!String.IsNullOrEmpty(cadenaConexion))
            {
                objetoConexion = new SqlConnection(cadenaConexion);
                objetoConexion.Open();

                if (objetoConexion.State.ToString() != "Open")
                {
                    while (objetoConexion.State.ToString() != "Open")
                    {

                    }
                }
            }
        }

        //Metodo para cerrar la conexion
        public void CerrarConexion()
        {
            if (objetoConexion != null)
            {
                if (objetoConexion.State.ToString() == "Open")
                {
                    objetoConexion.Close();
                    objetoConexion.Dispose();
                }
            }
        }


        public SqlConnection ObjetoConexion()
        {
            return (objetoConexion);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.ERolesUsuarios
{
    public class Usuario: Entidad
    {
        private string login;
        private string password;
        private string primerNombre;       
        private string segundoNombre;
        private string primerApellido;
        private string segundoApellido;
        private string sexo;
        private string correo;
        private int idUsuario;
        private string tipoIdentificacion;
        private string identificacion;
        private Direccion direccion=new Direccion();
        private DateTime fechaNace;
        private DateTime fechaRegistro;
        private string foto;
        private List<string> telefono= new List<string>();
        private Rol rol=new Rol();
        private Boolean estatus;
        private string estado;
        private List<Privilegio> listaPrivilegio;
        #region Getter&Setter


        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string PrimerNombre
        {
            get { return primerNombre; }
            set { primerNombre = value; }
        }

        public string SegundoNombre
        {
            get { return segundoNombre; }
            set { segundoNombre = value; }
        }

        public string PrimerApellido
        {
            get { return primerApellido; }
            set { primerApellido = value; }
        }

        public string SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public string TipoIdentificacion
        {
            get { return tipoIdentificacion; }
            set { tipoIdentificacion = value; }
        }

        public string Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        public Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public DateTime FechaNace
        {
            get { return fechaNace; }
            set { fechaNace = value; }
        }

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public List<string> Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public Rol Rol
        {
            get { return rol; }
            set { rol= value; }
        }

        public Boolean Estatus   //toma el valor del check
        {
            get { return estatus; }
            set { estatus = value; }
        }

        public string Estado        //valida valor de la BD
        {
            get { return estado; }
            set
            {
                estado = value;
                if (Estado.Contains("Activo"))
                    estatus = true;
                else if (Estado.Contains("Inactivo"))
                    estatus = false;
            }
        }
        #endregion Getter&Setter

        public int CalcularEdad()
        {
            return 0;
        }
        public Usuario ConsultarUsuario(string loggin)
        {
            Usuario usu = new Usuario();
            DAOUsuario usuconexion = new DAOUsuario();
            usu = usuconexion.TraerUsuario(loggin);
            return usu;
        }


       
    }
}
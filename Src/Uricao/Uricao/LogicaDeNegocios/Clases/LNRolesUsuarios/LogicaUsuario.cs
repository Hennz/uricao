using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios
{
    public class LogicaUsuario
    {
        public Usuario DatosUsuarioInterfaz(string loggin){
            Usuario usu = new Usuario();
            return usu.ConsultarUsuario(loggin);
        }
        public Usuario ValidarLoggin(string loggin, string pass)
        {
            DAOUsuario bdUsuario = new DAOUsuario();
            Usuario usu = new Usuario();
            usu = bdUsuario.ConfirmacionLoggin(loggin, pass);
           /* if (usu.Password != null && usu.Login!=null)
            {
                if (usu.Password.Equals(pass))
                {
                    if (usu.Login.Equals(loggin))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }*/
            return usu;
        }

        #region Consultar Usuarios Todos
        public List<Entidad> ConsultarUsuarioTodo()
        {
            List<Entidad> listaUsu = new List<Entidad>();
            DAOUsuario ConsultaBD = new DAOUsuario();
            //listaUsu = ConsultaBD.ConsultarUsuarioParametrizado();
            return listaUsu;
        }
        #endregion Consultar Usuarios Todos

        #region Consultar Usuarios Parametrizado
        public List<Entidad> ConsultaUsuarioTipo(string parametro, int seleccionBusqueda)
        {
            List<Entidad> listaUsu = new List<Entidad>();
            DAOUsuario ConsultaBD = new DAOUsuario();
            listaUsu = ConsultaBD.ConsultarUsuarioParametrizado(parametro, seleccionBusqueda);
            return listaUsu;
        }
        #endregion Consultar Usuarios Parametrizado

        public List<string> llenarComboPais()
        {
            DAODireccion direccionBd = new DAODireccion();
            return direccionBd.ListaPaises();
        }
        public List<string> llenarComboCiudad(string nombreEstado)
        {
            DAODireccion direccionBd = new DAODireccion();
            return direccionBd.ListaCiudades(nombreEstado);
        }
        public List<string> llenarComboEstado(string nombrePais)
        {
            DAODireccion direccionBd = new DAODireccion();
            return direccionBd.ListaEstado(nombrePais);
        }

        #region Agregar Usuario
        public bool AgregarUsuario(Entidad usuario)
        {
            DAOUsuario AgregarBD = new DAOUsuario();
            return AgregarBD.AgregarUsuario(usuario);
        }
        #endregion Agregar Usuario

        #region Modificar Usuario
        public bool ModificarUsuario(Entidad usuario)
        {
            DAOUsuario ActualizarBD = new DAOUsuario();
            return ActualizarBD.ModificarUsuario(usuario);
        }
        #endregion Modificar Usuario
    }
    
}
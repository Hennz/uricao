using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.ERolesUsuarios
{
    public class Cliente:Usuario, IUsuarioControler
    {
        private string ocupacion;

        public string Ocupacion
        {
            get { return ocupacion; }
            set { ocupacion = value; }
        }


        public bool Agregar()
        {
            return false;
        }

        public bool Modificar(string cedula)
        {
            return false;
        }

        public List<Cliente> Consultar()
        {
            List<Cliente> miListaCliente = new List<Cliente>();

            return miListaCliente;
        }

        public Cliente ConsultarPorCedula(string cedula)
        {
            Cliente miCliente = new Cliente();

            return miCliente;
        }

        public List<Cliente> Consultar(string ocupacion)
        {
            List<Cliente> miListaClienteOcupacion = new List<Cliente>();

            return miListaClienteOcupacion;
        }

        public bool ActivarInactivar(string cedula)
        {
            return false;
        }

        public bool Auntenticar(string login, string password)
        {
            return false;
        }

        public bool CambiarPassword(string login, string password)
        {
            return false;
        }

        public bool RecuperarPassword(string login, string correo)
        {
            return false;
        }
    }
}
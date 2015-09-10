using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.PaginasWeb.PProveedores;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EProveedores
{
    public class Contacto : Entidad
    {
        private string nombre;
        private string apellido;
        private string correo;
        private List<Telefono> telefonos;

        public Contacto() { }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public List<Telefono> Telefonos
        {
            get { return telefonos; }
            set { telefonos = value; }
        }



    }
}
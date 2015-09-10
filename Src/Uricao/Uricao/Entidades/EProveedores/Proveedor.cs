using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Presentacion.PaginasWeb.PProveedores;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EProveedores
{
    public class Proveedor : Entidad
    {
        private Int16 id;
        private String rif;
        private String nombre;
        private Int16 direccion;
        private String estado;
        private List<Telefono> telefono;
        private List<Contacto> contactos;

        public Proveedor() { }

        public Proveedor(String Rif, String Nombre, Int16 Direccion, String Estado)
        {
            this.rif = Rif;
            this.nombre = Nombre;
            this.direccion = Direccion;
            this.estado = Estado;
        }

        /*----------Propiedades----------*/
        public Int16 Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Rif
        {
            get { return rif; }
            set { rif = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Int16 Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public List<Telefono> Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public List<Contacto> Contactos
        {
            get { return contactos; }
            set { contactos = value; }
        }


        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
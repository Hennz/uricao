using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.ERolesUsuarios
{
    public class Direccion : Entidad
    {
        private int id;
        private string nombre;
        private string tipo;
        private Direccion fk_dir;
        private string edificio;
        private string calle;
        private string municipio;
        private string ciudad;
        private string estado;
        private string pais;

        #region Getter&Setter
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        public string Edificio
        {
            get { return edificio; }
            set { edificio = value; }
        }
        
        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }

        public string Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }
        
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }
        
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        public Direccion Fk_dir
        {
            get { return fk_dir; }
            set { fk_dir = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion Getter&Setter

    }
}
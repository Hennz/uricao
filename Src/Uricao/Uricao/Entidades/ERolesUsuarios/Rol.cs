using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.Conexion;
using Uricao.Entidades.EEntidad;


namespace Uricao.Entidades.ERolesUsuarios
{
    public class Rol: Entidad
        
    {
        # region Atributos

        private int idRol;
        private string nombreRol;
        private List<Privilegio> listaPrivilegios;
        private string descripcionRol;
        private Boolean estadoRol;

        # endregion

        # region Constructores

       

        public Rol(int idRol, string nombreRol, List<Privilegio> listaPrivilegios, string descripcionRol, Boolean estado )
        {
            this.idRol = idRol;
            this.nombreRol = nombreRol;
            this.listaPrivilegios = listaPrivilegios;
            this.descripcionRol = descripcionRol;
            if (estado.Equals("Activo"))
                this.estadoRol = true;
            else if (estado.Equals("Inactivo"))
                this.estadoRol = false;
        }

        public Rol()
        {
            // TODO: Complete member initialization
        }

        #endregion


        /*public bool Agregar()
        {
            return false;
        }

        public bool Modificar(string id)
        {
            return false;
        }
        

        public List<Rol> Consultar()
        {
            List<Rol> miListaRol = new List<Rol>();

            return miListaRol;
        }

        
        public Rol ConsultarPorId(int id)
        {
            Rol miRol = new Rol();

            return miRol;
        }

        public List<Rol> ConsultarPorNombre(string nombre)
        {
            List<Rol> miListaRolNombre = new List<Rol>();

            return miListaRolNombre;
        }

        public List<Rol> ConsultarPorDescripcion(string descripcion)
        {
            List<Rol> miListaRolDescripcion = new List<Rol>();

            return miListaRolDescripcion;
        }

        public List<Rol> ConsultarPorEstado(string estado)
        {
            List<Rol> miListaRolEstado = new List<Rol>();

            return miListaRolEstado;
        }

        public bool ActivarInactivar(int id)
        {
            return false;
        }
        */

        # region Getters y Setters

        public int IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }

        public string NombreRol
        {
            get { return nombreRol; }
            set { nombreRol = value; }
        }

        public List<Privilegio> ListaPrivilegios
        {
            get { return listaPrivilegios; }
            set { listaPrivilegios = value; }
        }

        public string Descripcion
        {
            get { return descripcionRol; }
            set { descripcionRol = value; }
        }

        public Boolean Estado
        {
            get { return estadoRol; }
            set { estadoRol = value; }
        }

        #endregion

        //# region Otros Metodos

        //public List<Entidad> EnlistaRoles()
        //{
        //    try
        //    {
        //        DAORol Conexion = new DAORol();
        //        List<Entidad> listaRoles = new List<Entidad>();
        //        listaRoles = Conexion.ListaRoles();
        //        return listaRoles;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }


        //}

        //# endregion
    }
}
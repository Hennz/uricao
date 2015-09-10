using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EEntidad;


namespace Uricao.LogicaDeNegocios.Clases.LNRolesUsuarios
{
    public class LogicaRol
    {
        # region Metodos


     /*  public Rol AgregarRol(string nombre, string descrip, Boolean estado)
        {
            Rol nuevoRol = new Rol();
            Boolean agregar;
            try
            {
                nuevoRol.NombreRol = nombre;
                nuevoRol.Descripcion = descrip;
                nuevoRol.Estado = estado;

                agregar = new DAORol().AgregarRol(nuevoRol);

                if (agregar == true)
                {
                    return nuevoRol;
                }
                else
                {
                    return null;
                }
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Error en las Referenciasn estan Nulas", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error General", e);
            }

        }*/

       /* public Rol ModificarRol(int id, string nombre, string descrip, Boolean estado)
        {
            Rol rolModificar = new Rol();
            Boolean modificar = false;
            try
            {
                rolModificar.IdRol = id;
                rolModificar.NombreRol = nombre;
                rolModificar.Descripcion = descrip;
                rolModificar.Estado = estado;

                modificar = new DAORol().ModificarRoles(rolModificar);

                if (modificar == true)
                {
                    return rolModificar;
                }
                else
                {
                    return null;
                }
            }

            catch (NullReferenceException e)
            {
                throw new Exception("Error en las Referenciasn estan Nulas", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error General", e);
            }
        }
        */
        
        /*#region Consultar Rol Todo
        public List<Entidad> ConsultarRolTodoL(int id, string nombre, string descrip, Boolean estadoRol)
        {
            

            List<Entidad> listaRoles = new List<Entidad>();
            DAORol ConsultaBD = new DAORol();
            listaRoles = ConsultaBD.ConsultarRolTodo(id, nombre, descrip, estadoRol);
            return listaRoles;
        }
        #endregion Consultar Rol Todo */

  /*      #region Consultar Rol Parametrizado
        public List<Entidad> ConsultarRolParametrizado(int id, String nombre, String descrip, Boolean estado, int opcion)
        {
            List<Entidad> listaRoles = new List<Entidad>();
            //DAORol ConsultaBD = new DAORol();
            //listaRoles = ConsultaBD.ConsultarRolTodo();
            //return listaRoles;

            try
             {
                 switch (opcion)
                 {
                     case 0:
                         listaRoles = new DAORol().ConsultarRolTodo(id,nombre,descrip, estado);
                         break;

                     case 1:
                         listaRoles = new DAORol().ConsultarRolId(id);
                         break;

                     case 2:
                         listaRoles = new DAORol().ConsultarRolNombre(nombre);
                         break;

                     case 3:
                         listaRoles = new DAORol().ConsultarRolDescrip(descrip);
                         break;

                     case 4:
                         listaRoles = new DAORol().ConsultarRolEstado(estado);
                         break;
                 }
                
                 return listaRoles;
             }

             catch (NullReferenceException e)
             {
                 throw new Exception("Error en las Referenciasn estan Nulas", e);
             }
             catch (Exception e)
             {
                 throw new Exception("Error General", e);
            }
        }
        #endregion Consultar Rol Parametrizado*/

        #region AsignarRol //AsignarRol3
        public Boolean AsignarRol(Usuario miUsuario, Rol miRol)
        {
            Boolean asignar;
            try
            {
                asignar = new DAORol().AsirgnarRol(miUsuario, miRol);
                return asignar;
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Error en las Referenciasn estan Nulas", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error General", e);
            }
        }
        #endregion AsignarRol

      /*  #region ListaRoles // ActivarInactivar
        public List<string> ListaRoles()
         {
             Rol Roles = new Rol();
             List<string> listaroles=new List<string>();
             listaroles = Roles.EnlistaRoles();
             return listaroles;
         } 
         #endregion ListaRoles */

        # endregion 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Clases.LNProductosInventario;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Entidades.EProductosInventario;
using Uricao.AccesoDeDatos.DAOS;

namespace Uricao.LogicaDeNegocios.Clases.LNTratamientos
{
    public class LogicaImplemento
    {

        #region Agregar Implemento
        public bool AgregarImplemento(List<Implemento> implemento)
        {
            try
            {
                bool implementoAgregado = false;

                for (int i = 0; i < implemento.Count; i++)
                {
                    implementoAgregado = new DAOImplemento().SqlAgregarImplemento(implemento[i]);

                }

                return implementoAgregado;
            }
            catch (ExcepcionImplemento e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Implementos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la consulta de los Implementos", e);
            }

        }
        #endregion Agregar Implemento

        #region Buscar Productos
        public List<Producto> BuscarProductos()
        {
            try
            {
                List<Producto> producto = new List<Producto>();

                return producto;
            }
            catch (ExcepcionImplemento e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la lista", e);
            }
        }
        #endregion Buscar Productos
        //Listo
        #region Consultar lista Implementos
        //Listo Lista de implementos de un Tratamiento
        public List<Implemento> ConsultarImplemento(Tratamiento miTratamiento)
        {
            try
            {
                List<Implemento> miLista = new DAOImplemento().SqlConsultarImplemento(miTratamiento);
                return miLista;
            }
            catch (ExcepcionImplemento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionImplemento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Implementos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la consulta de los Implementos", e);
            }
        }
        #endregion
        //Listo
        #region Eliminar Tratamiento Implementos
        public bool EliminarImplementos(Tratamiento tratamientoPrimario)
        {
            try
            {
                bool ImplementosEliminados = new DAOImplemento().SqlEliminarImplementosAsociado(tratamientoPrimario);
                return ImplementosEliminados;
            }
            catch (ExcepcionImplemento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionImplemento("El parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la consulta de los Tratamientos", e);
            }
        }
        #endregion

        #region Consultar Implemento por nombre
        public List<Implemento> ConsultarXNombreImplemento(string nombreImplementoBuscar, Tratamiento tratamientoPrimario)
        {
            try
            {
                List<Implemento> miLista = new DAOImplemento().SqlBuscarXNombreImplemento(nombreImplementoBuscar,tratamientoPrimario);
                return miLista;
            }
            catch (ExcepcionImplemento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionImplemento("El nombre indicado no es valido", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("No se Tiene ningun Implemento con el nombre idicado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la consulta de los Implementos", e);
            }
        }
        #endregion

        //Listo
        #region Consultar lista Implementos de un tratamiento
        //Listo Lista de implementos de un Tratamiento
        public List<Implemento> CargarListaProductoNoImplemento(Tratamiento miTratamiento)
        {
            try
            {
                List<Implemento> miLista = new DAOImplemento().SqlConsultarNoImplementoTratamiento(miTratamiento);
                return miLista;
            }
            catch (ExcepcionImplemento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionImplemento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Implementos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la consulta de los Implementos", e);
            }
        }
        #endregion
    }
}
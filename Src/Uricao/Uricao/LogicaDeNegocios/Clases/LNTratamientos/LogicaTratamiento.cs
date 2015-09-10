using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Clases.LNProductosInventario;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Clases.LNTratamientos
{
    public class LogicaTratamiento
    {

        #region Consultar
        //Consultar Lista Tratamiento LISTO
        public List<Tratamiento> ConsultarTratamiento()
        {
            try
            {
                List<Tratamiento> miLista = new DAOTratamiento().SqlConsultarTratamiento();
                return miLista;
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }
        }
        
        //Consultar Tratamiento por Nombre
        public List<Tratamiento> ConsultarXNombreTratamiento(string nombreTratamientoBuscar)
        {
            try
            {
                List<Tratamiento> miLista = new DAOTratamiento().SqlBuscarXNombreTramiento(nombreTratamientoBuscar);
                return miLista;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("El nombre indicado no es valido", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("No se Tiene ningun Tratamiento con el nombre idicado", e);
            }
            catch (Exception e)
            {
                //throw e;
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }
        }
        
        //Consultar Tratamiento por ID
        public Tratamiento ConsultarXIdTratamiento(int idTratamientoBuscar)
        {
            try
            {
                Tratamiento miTratamiento = new DAOTratamiento().SqlBuscarXIdTratamiento(idTratamientoBuscar);
                return miTratamiento ;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }
        }

        //Consultar Tratamiento por Estatus
        public List<Tratamiento> ConsultarXEstatusTratamiento(string estatusTratamientoBuscar)
        {
            try
            {
                List<Tratamiento> miLista = new DAOTratamiento().SqlBuscarXEstadoTramiento(estatusTratamientoBuscar);
                return miLista;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("El Estado indicado no es valido", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("No se Tiene ningun Tratamiento con el Estatus idicado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }
        }
        
        //Listo Lista de Tratamientos Asociados
        public List<Tratamiento> ConsultarTratamientoAsociado(int _idTratamiento)
        {
            try
            {
                List<Tratamiento> miLista = new DAOTratamiento().ConsultarTratamientoAsociado(_idTratamiento);
                return miLista;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }
        }
        #endregion Consultar

        #region Agregar Tratamiento Asociado 
        public void AgregarTratamientoAsociado(Tratamiento tratamientoPrimario, List<Tratamiento> listaTratamiento)
        {
            try
            {
                for (int i = 0; i < listaTratamiento.Count; i++)
                {
                    bool TratamientosAgregados = new DAOTratamiento().SqlAgregarTratamientoAsociado(tratamientoPrimario, listaTratamiento[i]);
                }
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("El parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }
        }
        #endregion

        //Agrega El tratamiento con sus Implementos y Tratamientos Asociados
        #region Agregar Tratamiento
        public void AgregarTratamiento(Tratamiento tratamientoPrimario, List<Implemento> listaImplementos, List<Tratamiento> listaTratamiento)
        {
            try
            {
                bool TratamientoAgregado = new DAOTratamiento().SqlAgregarTratamiento(tratamientoPrimario);
                int IdTratamientoAgregado = new DAOTratamiento().SqlIdTratmientoNuevo();
                tratamientoPrimario.Id = Convert.ToInt16(IdTratamientoAgregado);
                AgregarTratamientoAsociado(tratamientoPrimario,listaTratamiento);

                for (int i = 0; i < listaImplementos.Count; i++)
                {
                    listaImplementos[i].IdTratamiento = Convert.ToInt16(IdTratamientoAgregado);
                }
                
                bool ImplementosAgregados = new LogicaImplemento().AgregarImplemento(listaImplementos);
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en agregar Tratamiento", e);
            }
        }
        #endregion Agregar Tratamiento
        //ELimina los tratamientos Asociados
        #region Eliminar Tratmiento Asociados
        public void EliminarTratamientoAsociado(Tratamiento tratamientoPrimario)
        {
            try
            {
                    bool TratamientosAgregados = new DAOTratamiento().SqlEliminarTratamientoAsociado(tratamientoPrimario);
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("El parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }
        }
        #endregion
        //Listo
        #region Modifiar Tratamiento
        public void ModificarTratamiento(Tratamiento tratamientoPrimario, List<Implemento> listaImplementos, List<Tratamiento> listaTratamiento)
        {
            try
            {
                bool modificarTratamientoDetalle = new DAOTratamiento().SqlModificarTratamiento(tratamientoPrimario);
                EliminarTratamientoAsociado(tratamientoPrimario);
                AgregarTratamientoAsociado(tratamientoPrimario, listaTratamiento);
                bool implementosAgregados = new LogicaImplemento().EliminarImplementos(tratamientoPrimario);
                bool ImplementosAgregados = new LogicaImplemento().AgregarImplemento(listaImplementos);
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamiento incorrecto", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }
        }
        #endregion
        //listo
        #region ActivarDesactivar Tratamiento
        public void EliminarTratamiento(Tratamiento miTratamientos)
        {
            try
            {
                bool tratamientoActivo= new DAOTratamiento().SqlActivarDesactivarTratamiento(miTratamientos);
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }

        }
        #endregion ActivarDesactivar Tratamiento

        #region Consultar Tratamiento Especifico (pertenece a Historia Clinica)
        /// <summary>
        /// Metodo que retorna los ID de tratamiento a partir del nombre del
        /// tratamiento.
        /// </summary>
        /// <param name="nombreTratamiento"></param>
        /// <returns></returns>

        public int ConsultarTratamientoEspecificoHistoriaClinica(string nombreTratamiento)
        {
            DAOHistoriaClinica objHistoria = new DAOHistoriaClinica();
            int idTratamiento = objHistoria.ConsultarIdTratamiento(nombreTratamiento);
            return idTratamiento;
        }
        #endregion Consultar Tratamiento Especifico (pertenece a Historia Clinica)

        #region validar string menor a 120 caracteres
        public bool ValidaString(String cadena)
        {
            try
            {
                if (cadena.Length > 120) return false;
                return true;
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Cadena vacia", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error", e);
            }
        }
        #endregion

        #region Consultar Lista Tratamientos No Asociados
        //Listo Lista de Tratamientos Asociados
        public List<Tratamiento> ConsultarTratamientoNoAsociado(int _idTratamiento)
        {
            try
            {
                List<Tratamiento> miLista = new DAOTratamiento().ConsultarTratamientoNoAsociado(_idTratamiento);
                return miLista;
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }
        }
        #endregion Consultar

        #region Validar Numero
        public bool ValidarNumero (string numberText)
        {
            int Result = 0;
            bool numberResult = false;
            if (int.TryParse(numberText, out Result))
            {
                numberResult = true;
            }
            return numberResult;
        }
        #endregion
    }
}
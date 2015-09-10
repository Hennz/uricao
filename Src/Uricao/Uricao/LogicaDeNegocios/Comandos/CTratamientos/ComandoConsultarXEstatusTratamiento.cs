using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoConsultarXEstatusTratamiento : Comando<List<Entidad>>
    {
        string _estatus;

        public ComandoConsultarXEstatusTratamiento(string estatusTratamientoBuscar)
        {
            this._estatus = estatusTratamientoBuscar;
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOTratamiento().SqlBuscarXEstadoTramiento(this._estatus);

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

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoConsultarXNombreTratamiento : Comando<List<Entidad>>
    {
        private string _nombreTratamiento;

        public ComandoConsultarXNombreTratamiento(string nombreTratamiento)
        {
            this._nombreTratamiento = nombreTratamiento;

        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOTratamiento().SqlBuscarXNombreTramiento(_nombreTratamiento);

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


    }
}
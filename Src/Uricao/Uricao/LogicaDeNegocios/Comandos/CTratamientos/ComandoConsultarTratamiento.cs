using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoConsultarTratamiento : Comando<List<Entidad>>
    {

        public ComandoConsultarTratamiento()
        {
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOTratamiento().SqlConsultarTratamiento();

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

    }

}
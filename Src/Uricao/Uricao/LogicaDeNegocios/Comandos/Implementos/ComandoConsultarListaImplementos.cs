using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.Implementos
{
    public class ComandoConsultarListaImplementos : Comando<List<Entidad>>
    {

        private Entidad _miTratamiento;

        public ComandoConsultarListaImplementos(Entidad miTratamiento)
        {
            this._miTratamiento = miTratamiento;
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOImplemento().SqlConsultarImplemento(this._miTratamiento);

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

    }

}
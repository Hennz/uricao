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
    public class ComandoEliminarTratamientoImplementos : Comando<bool>
    {

        private Entidad _miTratamiento;

        public ComandoEliminarTratamientoImplementos(Entidad miTratamiento)
        {
            this._miTratamiento = miTratamiento;
        }

        public override bool Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOImplemento().SqlEliminarImplementosAsociado(_miTratamiento);

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

    }

}
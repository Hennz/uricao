using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoConsultarTratamientoNoAsociado : Comando<List<Entidad>>
    {
        int _idTratamiento;
        public ComandoConsultarTratamientoNoAsociado(int idTratamiento)
        {
            this._idTratamiento = idTratamiento;
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {

                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOTratamiento().ConsultarTratamientoNoAsociado(this._idTratamiento);

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
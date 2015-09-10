using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoConsultarTratamientoAsociado : Comando<List<Entidad>>
    {
        int _idTratamiento;


        public ComandoConsultarTratamientoAsociado(int idTratamiento)
        {
            this._idTratamiento = idTratamiento;
        }


        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOTratamiento().ConsultarTratamientoAsociado(this._idTratamiento);

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
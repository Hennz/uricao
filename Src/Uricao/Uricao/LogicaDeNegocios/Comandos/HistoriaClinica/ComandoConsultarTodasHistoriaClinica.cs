using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Comandos.HistoriaClinica
{
    public class ComandoConsultarTodasHistoriaClinica : Comando<List<Entidad>>
    {

        public ComandoConsultarTodasHistoriaClinica()
        {
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOHistoriaClinica().ConsultarTodasHistoriaClinica();
            }
            catch (ExceptionHistoriaClinica e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExceptionHistoriaClinica("Error: Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionHistoriaClinica("Error: Datos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExceptionHistoriaClinica("Error: en la consulta", e);
            }
        }
    }
}
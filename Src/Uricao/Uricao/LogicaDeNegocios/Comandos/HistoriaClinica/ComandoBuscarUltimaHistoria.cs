using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Comandos.HistoriaClinica
{
    public class ComandoBuscarUltimaHistoria : Comando<int>
    {


        public  ComandoBuscarUltimaHistoria()
        {
            
        }

        public override int Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOHistoriaClinica().BuscarUltimaId();
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
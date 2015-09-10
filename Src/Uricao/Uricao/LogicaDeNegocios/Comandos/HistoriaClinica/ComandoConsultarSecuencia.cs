using System.Collections.Generic;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using System;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Comandos.HistoriaClinica
{
    public class ComandoConsultarSecuencia  : Comando<List<Entidad>>
    {

        int _idDiente;

        public ComandoConsultarSecuencia(int idDiente)
        {
            this._idDiente = idDiente;
           
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOHistoriaClinica().ConsultarSecuencia(_idDiente);
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
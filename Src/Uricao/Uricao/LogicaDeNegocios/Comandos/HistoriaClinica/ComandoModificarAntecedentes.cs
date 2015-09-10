using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Excepciones;


namespace Uricao.LogicaDeNegocios.Comandos.HistoriaClinica
{
    public class ComandoModificarAntecedente : Comando<bool>
    {

         private List<Entidad> _respuestas;

        public ComandoModificarAntecedente(List<Entidad> _respuestas)
        {
            this._respuestas = _respuestas;
         
        }

        public override bool Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOHistoriaClinica().ModificarAntecedente(_respuestas);
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
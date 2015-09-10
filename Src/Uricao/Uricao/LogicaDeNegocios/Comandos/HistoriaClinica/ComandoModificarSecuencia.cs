using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Comandos.HistoriaClinica
{
    public class ComandoModificarSecuencia : Comando<bool>
    {
        private List<Entidad> _secuencia;


        public ComandoModificarSecuencia(List<Entidad> _secuencia)
        {
            this._secuencia = _secuencia;
         
        }

        public override bool Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOHistoriaClinica().ModificarSecuencia(_secuencia);
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
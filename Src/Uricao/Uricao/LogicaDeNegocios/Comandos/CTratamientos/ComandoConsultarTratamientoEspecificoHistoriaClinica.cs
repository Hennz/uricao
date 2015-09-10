using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;


namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoConsultarTratamientoEspecificoHistoriaClinica : Comando<int>
    {
        private string _nombreTratamiento;

        public ComandoConsultarTratamientoEspecificoHistoriaClinica(string nombre)
        {
            this._nombreTratamiento = nombre;

        }




        public override int Ejecutar()
        {

            try
            {

                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOHistoriaClinica().ConsultarIdTratamiento(this._nombreTratamiento);

            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("El parametros invalidos", e);
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
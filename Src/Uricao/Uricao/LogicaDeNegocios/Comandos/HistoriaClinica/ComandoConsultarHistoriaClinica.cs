using System.Collections.Generic;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using System;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Comandos.HistoriaClinica
{
    public class ComandoConsultarHistoriaClinica : Comando<List<Entidad>>
    {
        String _nombre;
        String _apellido;
        String _cedula;
        int _idHistoria;

        public ComandoConsultarHistoriaClinica(String nombre, String apellido, String cedula, int idHistoria)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._cedula = cedula;
            this._idHistoria = idHistoria;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOHistoriaClinica().ConsultarHistoriaClinica(_nombre, _apellido, _cedula, _idHistoria);
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
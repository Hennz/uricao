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

    public class ComandoConsultarImplementoPorNombre : Comando<List<Entidad>>
    {
        private string _nombreImplementoBuscar;
        private Entidad _tratamientoPrimario;

        public ComandoConsultarImplementoPorNombre(string nombre, Entidad tratamiento)
        {
            this._tratamientoPrimario = tratamiento;
            this._nombreImplementoBuscar = nombre;
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOImplemento().SqlBuscarXNombreImplemento(this._nombreImplementoBuscar, this._tratamientoPrimario);

            }
            catch (ExcepcionImplemento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionImplemento("El nombre indicado no es valido", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("No se Tiene ningun Implemento con el nombre idicado", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la consulta de los Implementos", e);
            }

        }

    }

}
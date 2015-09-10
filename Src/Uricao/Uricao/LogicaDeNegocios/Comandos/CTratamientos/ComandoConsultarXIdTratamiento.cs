using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoConsultarXIdTratamiento : Comando<Entidad>
    {

        private int _idTratamientoBuscar;

        public ComandoConsultarXIdTratamiento(int idTratamientoBuscar)
        {
            this._idTratamientoBuscar = idTratamientoBuscar;

        }

        public override Entidad Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOTratamiento().SqlBuscarXIdTratamiento(this._idTratamientoBuscar);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOTratamiento : iDAO
    {

        Entidad SqlBuscarXIdTratamiento(int idTratamientoParametro);
        List<Entidad> SqlConsultarTratamiento();
        List<Entidad> SqlBuscarXEstadoTramiento(string estadoTratamientoBuscar);
        List<Entidad> SqlBuscarXNombreTramiento(string nombreTratamientoBuscar);
        List<Entidad> ConsultarTratamientoNoAsociado(int _idTratamiento);
        List<Entidad> ConsultarTratamientoAsociado(int _idTratamiento);
        bool SqlActivarDesactivarTratamiento(Entidad tratamientoPrimario);
        bool SqlModificarTratamiento(Entidad tratamientoPrimario);
        bool SqlEliminarTratamientoAsociado(Entidad tratamientoPrimario);
        bool SqlAgregarTratamientoAsociado(Entidad tratamientoPrimario, Entidad asociado);
        bool SqlAgregarTratamiento(Entidad tratamientoPrimario);
        int SqlIdTratmientoNuevo();

    }
}
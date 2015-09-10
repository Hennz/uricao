using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOImplemento : iDAO
    {
        bool SqlAgregarImplemento(Entidad implementoPrimario);
        List<Entidad> SqlConsultarImplemento(Entidad tratamientoPrimario);
        List<Entidad> SqlBuscarXNombreImplemento(string nombreImplementoBuscar, Entidad tratamientoPrimario);
        //Implemento SqlConsultarDetalleImplemento(int _idimplemento);
        bool SqlModificarImplemento(Entidad miImplemento);
        bool SqlEliminarImplementosAsociado(Entidad tratamientoPrimario);
        List<Entidad> SqlConsultarNoImplementoTratamiento(Entidad tratamientoPrimario);


    }
}
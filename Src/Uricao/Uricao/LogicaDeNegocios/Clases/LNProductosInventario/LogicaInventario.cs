using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EProductosInventario;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Clases.LNProductosInventario
{
    public class LogicaInventario
    {
        public decimal CalcularDisponibles(Entidad producto)
        {
            DAOInventario objDataBase = new DAOInventario();
            return objDataBase.CalcularEntrantes(producto) - objDataBase.CalcularConsumos(producto);
        }
    }
}
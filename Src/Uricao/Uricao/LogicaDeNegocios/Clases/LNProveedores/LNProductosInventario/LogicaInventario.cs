using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EProductosInventario;
using Uricao.AccesoDeDatos.SqlServer;

namespace Uricao.LogicaDeNegocios.Clases.LNProductosInventario
{
    public class LogicaInventario
    {
        public decimal CalcularDisponibles(Producto producto)
        {
            SqlServerInventario objDataBase = new SqlServerInventario();
            return objDataBase.CalcularEntrantes(producto) - objDataBase.CalcularConsumos(producto);
        }
    }
}
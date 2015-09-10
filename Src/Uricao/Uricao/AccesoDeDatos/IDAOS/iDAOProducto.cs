using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using System.Data.SqlClient;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOProducto : iDAO
    {
        List<Entidad> ConsultarProductos();

        List<Entidad> ConsultarProductosDetallados(Entidad productoGenerico);

        List<String> ConsultarCategorias();

        List<String> ConsultarMarcas();

        List<String> ConsultarMarcas(String proveedor);

        bool AgregarProducto(Entidad producto);

        bool AgregarDetalleProducto(Entidad producto);

        bool EditarProducto(Entidad producto);

        bool EditarProductoGenerico(Entidad producto, String nombreViejo);

        #region Consultar Productos realizado por el equipo de Tratamientos

        List<Entidad> SqlConsultarProductoImplemento();
        List<Entidad> SqlConsultarProductoNoImplemento(Entidad miTratamiento);
        List<Entidad> SqlConsultarXNombreProducto(string productoNombre);
        List<Entidad> SqlTraerProductos();

        #endregion Consultar Productos realizado por el equipo de Tratamientos

    }
}
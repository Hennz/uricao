using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOProveedor : iDAO
    {
        List<Entidad> consultarProveedores();

        Boolean AgregarProveedor(Entidad proveedor);

        Boolean AgregarContacto(Entidad contacto, Int16 idProveedor);

        Boolean ModificarProveedor(Entidad proveedor, Int16 idProveedor);

        Entidad consultarProveedor(Entidad proveedorOrigen);

        Entidad consultarIdProveedor(Entidad proveedorOrigen);

        Entidad consultarContacto(Entidad contactoOrigen, Int16 fkidProveedor);

        Entidad buscarContactoConFK(String rif, Int16 posicion);

        String buscarIdProveedorPorRif(String rif);

        Entidad buscarProveedorPorNombre(String nombre);

        Entidad buscarProveedorPorRif(String rif);
    }
}
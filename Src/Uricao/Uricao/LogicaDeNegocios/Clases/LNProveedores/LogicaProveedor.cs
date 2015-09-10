using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EProveedores;
using Uricao.AccesoDeDatos.DAOS;

namespace Uricao.LogicaDeNegocios.Clases.LNProveedores
{
    public class LogicaProveedor
    {

        public List<Proveedor> ObtenerProveedores()
        {
            //ComandoConsultarTodosProveedores
            List<Proveedor> proveedores = new List<Proveedor>();
            DAOProveedor objDataBase = new DAOProveedor();

            //proveedores = objDataBase.consultarProveedores();
            return proveedores;
        }

        public Proveedor ObtenerProveedoresPorNombre(string nombre)
        {
            //ComandoConsultarProveedoresPorNombre
            DAOProveedor objDataBase = new DAOProveedor();

            //return objDataBase.buscarProveedorPorNombre(nombre);
            return null;
        }

        public Proveedor ObtenerProveedoresPorRif(string rif)
        {
            //ComandoConsultarProveedoresPorRif
            DAOProveedor objDataBase = new DAOProveedor();

            //return objDataBase.buscarProveedorPorRif(rif);
            return null;
        }

        public bool agregarProveedor(Proveedor proveedor)
        {
            //ComandoAgregarProveedor
            DAOProveedor objDataBase = new DAOProveedor();

            //1-Agregar el producto asociado a esa categoria
            objDataBase.AgregarProveedor(proveedor);

            //2-Agregar el detalle_producto asociado al producto y a la marca 
            return true;
        }

        public void ModificarProveedor(Proveedor proveedor, string id)
        {
            //ComandoModificarProveedor
            DAOProveedor objDataBase = new DAOProveedor();
            //objDataBase.ModificarProveedor(proveedor, id);
        }

        public bool agregarContacto(Contacto contacto, int idProveedor)
        {
            //ComandoAgregarContacto
            DAOProveedor objDataBase = new DAOProveedor();
            //objDataBase.AgregarContacto(contacto, idProveedor);

            return true;
        }

        public bool consultarProveedor(Proveedor proveedor)
        {
            //ComandoConsultarProveedor
            DAOProveedor objDataBase = new DAOProveedor();

            //if (objDataBase.consultarProveedor(proveedor))
            //    return true;
            //else
            //    return false;
            return false;
        }

        public int consultarIdProveedor(Proveedor proveedor)
        {
            //ComandoConsultarIdProveedor
            DAOProveedor objDataBase = new DAOProveedor();
            //int id = objDataBase.consultarIdProveedor(proveedor);
            int id = 0;
            System.Diagnostics.Debug.WriteLine("int:["+id+"]\n");
            if (id != 0)
                return id;
            else
                return 0;
        }

        public bool consultarContacto(Contacto contacto, string fkidproveedor)
        {
            //ComandoConsultarContacto
            DAOProveedor objDataBase = new DAOProveedor();
            /*
            if (objDataBase.consultarContacto(contacto,fkidproveedor))
                return true;
            else
                return false;*/
            return false;
        }

        public Contacto verContacto(string rif,int posicion)
        {
            DAOProveedor objDataBase = new DAOProveedor();

            string Id = objDataBase.buscarIdProveedorPorRif(rif);
            Contacto contacto = new Contacto();
            //contacto = objDataBase.buscarContactoConFK(Id, posicion);
            if (contacto!=null)
                return contacto;
            else
                return null;
        }

    }
}
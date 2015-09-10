using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.ProductosInventario.Productos
{
    public class ComandoListaProductosNoImplemento : Comando<List<Entidad>>
    {

        Entidad _tratamiento;

        public ComandoListaProductosNoImplemento(Entidad miTratamiento) 
        {
            this._tratamiento = miTratamiento;
        }

        
        public  override List<Entidad> Ejecutar()
        {
            try
            {
                return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOProducto().SqlConsultarProductoNoImplemento(this._tratamiento);
               
            }
            catch (ArgumentException e)
            {
                throw new Exception("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Productos vacios", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de los Productos", e);
            }
        }
    }
}
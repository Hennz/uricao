using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EProductosInventario;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoBuscarProducto : Comando<List<Entidad>>
    {

        public ComandoBuscarProducto()
        {

        }

        //NO ESTA COMPLEMTO NECESITAMOS A LA GENTE DE PRODUCTO
        
        public override List<Entidad> Ejecutar()
        {
            return null;

        }

    }

}
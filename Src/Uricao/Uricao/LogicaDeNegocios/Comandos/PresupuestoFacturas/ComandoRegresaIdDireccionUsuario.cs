using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoRegresaIdDireccionUsuario :  Comando<int>
    {
         #region Atributos
        private int _idUsuario;
       
      
       
        #endregion

        #region Constructor
        public ComandoRegresaIdDireccionUsuario(int idUsuario)
        {
            this._idUsuario = idUsuario;
            

        }
        #endregion

        public override int Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().RegresarIdDireccionDeUsuario(_idUsuario);
           
            

           
        }
    }
}
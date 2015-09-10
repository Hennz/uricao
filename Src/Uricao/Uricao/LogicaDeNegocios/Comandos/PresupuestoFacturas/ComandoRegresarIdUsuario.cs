using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoRegresarIdUsuario: Comando<int>
    {
          #region Atributos
        private string _cedula;
        #endregion

        #region Constructor
        public ComandoRegresarIdUsuario(string cedula)
        {
            this._cedula = cedula;
            
        }
        #endregion


        #region Metodos
        public override int Ejecutar()
        {
            return FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().RegresarIdUsuario(_cedula);
        }

        #endregion
    }
}
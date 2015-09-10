using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.ECuentasPorCobrar;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.LogicaDeNegocios.Fabricas;


namespace Uricao.LogicaDeNegocios.Comandos.CuentasPorCobrar
{
    public class ComandoCalcularDeudaTotal:Comando<double>
    {
        #region Atributos
        #endregion Atributos
        #region Constructor
        public ComandoCalcularDeudaTotal()
        {
        }
        #endregion Constructor
        #region Metodos
        public override double Ejecutar()
        {
            return 0.0;
        }
        #endregion Metodos
    }
}
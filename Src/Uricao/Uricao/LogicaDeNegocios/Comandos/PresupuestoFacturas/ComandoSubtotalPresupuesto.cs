using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoSubtotalPresupuesto : Comando<int>
    {
        #region Atributos

        private List<Tratamiento> _listaTratamiento;

        #endregion

        #region Constructor

        public ComandoSubtotalPresupuesto(List<Tratamiento> _listaTratamiento)
        {
            this._listaTratamiento = _listaTratamiento;
        }

        #endregion

        #region Ejecutar

        public override int Ejecutar()
        {
            int subtotal = 0;
            for (int i = 0; i < _listaTratamiento.Count; i++)
            {
                subtotal = subtotal + _listaTratamiento[i].Costo;
            }
            return subtotal;
        }

        #endregion
    }
}
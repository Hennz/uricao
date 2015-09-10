using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.ETratamientos;

namespace Uricao.LogicaDeNegocios.Comandos.PresupuestoFacturas
{
    public class ComandoRegresarCostoTratamiento : Comando<int>
    {

        #region Atributos
        private int _idTratamiento;
        private int _posicion;
        private List<Tratamiento> _listaTramiento;
       
        #endregion

        #region Constructor
        public ComandoRegresarCostoTratamiento(int idTratamiento, List<Tratamiento> listado_tratamiento, int posicion)
        {
            this._idTratamiento = idTratamiento;
            this._listaTramiento = listado_tratamiento;
            this._posicion = posicion;

        }
        #endregion

        public override int Ejecutar()
        {
          int costoTratamiento = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOPresupuestoFactura().RegresarCostoTratamiento(this._idTratamiento);
           
            return (((int)( (this._listaTramiento[this._posicion] as Tratamiento).Duracion) * costoTratamiento));

           
        }
    }
}
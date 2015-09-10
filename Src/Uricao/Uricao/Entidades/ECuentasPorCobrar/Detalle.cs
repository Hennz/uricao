using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.ECuentasPorCobrar
{
    public class Detalle : Entidad
    {

        private string _nombreTratamiento;

        private int _cantidadDetalle;


        private double _montoDetalle;


        public Detalle()
        {

        }


        public double MontoDetalle
        {
            get { return _montoDetalle; }
            set { _montoDetalle = value; }
        }

        public string NombreTratamiento
        {
            get { return _nombreTratamiento; }
            set { _nombreTratamiento = value; }
        }

        public int CantidadDetalle
        {
            get { return _cantidadDetalle; }
            set { _cantidadDetalle = value; }
        }


    }
}
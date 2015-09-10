using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
namespace Uricao.Entidades.ECuentasPorCobrar
{
    public class Totales : Entidad
    {

        double _totalFactura;
        double _totalAbono;

        public Totales()
        {
        }


        public double TotalFactura
        {
            get { return _totalFactura; }
            set { _totalFactura = value; }
        }

        public double TotalAbono
        {
            get { return _totalAbono; }
            set { _totalAbono = value; }
        }
    }
}
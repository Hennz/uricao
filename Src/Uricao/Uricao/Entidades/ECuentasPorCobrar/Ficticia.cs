using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
namespace Uricao.Entidades.ECuentasPorCobrar
{
    public class Ficticia : Entidad
    {

        private int _numeroFactura;
        private DateTime _fechaEmitida;
        private double _totalFactura;
        private double _deuda;
        private double _totalAbono;


        public Ficticia()
        {
        }

        public int NumeroFactura
        {
            get { return _numeroFactura; }
            set { _numeroFactura = value; }
        }

        public double TotalAbono
        {
            get { return _totalAbono; }
            set { _totalAbono = value; }
        }

        public DateTime FechaEmitida
        {
            get { return _fechaEmitida; }
            set { _fechaEmitida = value; }
        }


        public double TotalFactura
        {
            get { return _totalFactura; }
            set { _totalFactura = value; }
        }


        public double Deuda
        {
            get { return _deuda; }
            set { _deuda = value; }
        }




    }
}
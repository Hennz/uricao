using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EProductosInventario
{
    public class Consumo : Entidad
    {
        private DateTime fechaConsumo;
        private int cantidad;

        public Consumo() { }

        /*----------Propiedades----------*/

        public DateTime FechaConsumo
        {
            get { return fechaConsumo; }
            set { fechaConsumo = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }




    }
}
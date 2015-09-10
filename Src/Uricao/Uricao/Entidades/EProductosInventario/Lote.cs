using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EProductosInventario
{
    public class Lote : Entidad
    {
        private Producto producto;
        private DateTime fechaIngreso;
        private DateTime fechaVencimiento;
        private int cantidad;
        private string ubicacion;
        private List<Consumo> consumos;

        public Lote() { }

        /*----------Propiedades----------*/

        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
        
        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public List<Consumo> Consumos
        {
            get { return consumos; }
            set { consumos = value; }
        }
    }
}
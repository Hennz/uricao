using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EPresupuestoFacturas
{
    public class Presupuesto : Entidad
    {

        #region Atributos

        private int nro_presupuesto;
        private List<Detalle_Presupuesto_Factura> listado_presupuesto;
        private double total_presupuesto;
        private DateTime fecha_emision;
        private String observaciones;

        #endregion

        #region Constructores

        public Presupuesto(int nro_presupuesto, double total_presupuesto, DateTime fecha)
        {
            this.nro_presupuesto = nro_presupuesto;
            this.total_presupuesto = total_presupuesto;
            this.listado_presupuesto = new List<Detalle_Presupuesto_Factura>();
            this.fecha_emision = fecha;
        }

        public Presupuesto()
        {
            listado_presupuesto = new List<Detalle_Presupuesto_Factura>();
        }

        #endregion

        #region Encapsulatmiento de Atributos

        public List<Detalle_Presupuesto_Factura> Listado_presupuesto
        {
            get { return listado_presupuesto; }
            set { listado_presupuesto = value; }
        }
        public int Nro_presupuesto
        {
            get { return nro_presupuesto; }
            set { nro_presupuesto = value; }
        }
        public double Total_presupuesto
        {
            get { return total_presupuesto; }
            set { total_presupuesto = value; }
        }
        public DateTime Fecha_emision
        {
            get { return fecha_emision; }
            set { fecha_emision = value; }
        }
        public String Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        #endregion

        public void addDetalle(Detalle_Presupuesto_Factura elDetalle)
        {
            listado_presupuesto.Add(elDetalle);
        }
        public Detalle_Presupuesto_Factura getDetalle_Presupuesto(int i)
        {
            Detalle_Presupuesto_Factura regreso = null;

            Object[] directorio = listado_presupuesto.ToArray();

            regreso = (Detalle_Presupuesto_Factura)directorio[i];

            return regreso;

        }
        public int getTamano_Lista()
        {
            Object[] directorio = listado_presupuesto.ToArray();
            return directorio.Length;

        }

        public bool Equals(Presupuesto otroPresupuesto)
        {
            if (this.fecha_emision != otroPresupuesto.fecha_emision)
                return false;
            if (this.nro_presupuesto != otroPresupuesto.nro_presupuesto)
                return false;
            if (this.observaciones.Equals(otroPresupuesto.observaciones) == false)
                return false;

            int i;

            if (this.listado_presupuesto.Count == otroPresupuesto.listado_presupuesto.Count)
            {
                for (i = 0; i < this.listado_presupuesto.Count; i++)
                {
                    if (this.listado_presupuesto[i].Equals(otroPresupuesto.listado_presupuesto[i]) == false)
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        #region metodos

        #region valida fecha

        /// <summary>
        /// valida que una fecha sea mayor o igual a otra
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public bool ValidarFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            int intervaloFechasValidadas = (fechaInicio.Date.CompareTo(fechaFin.Date));
            return (intervaloFechasValidadas <= 0);
        }

        #endregion

        #endregion



    } 
}

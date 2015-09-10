using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EPresupuestoFacturas
{
    public class Detalle_Presupuesto_Factura : Entidad
    {
        #region Atributos
        
        private Tratamiento el_Tratamiento;
        private double total_pago_tratamiento;
        private int cantidad;

        #endregion

        #region Constructores

        public Detalle_Presupuesto_Factura()
        { 
        }

        public Detalle_Presupuesto_Factura(Tratamiento el_Tratamiento, double total_pago_tratamiento, int cantidad)
        {
            this.el_Tratamiento = el_Tratamiento;
            this.total_pago_tratamiento = total_pago_tratamiento;
            this.cantidad = cantidad;
        }

        #endregion

        #region Encapsulamiento de Atributos

        public Tratamiento El_Tratamiento
        {
            get { return el_Tratamiento; }
            set { el_Tratamiento = value; }
        }

        public double Total_pago_tratamiento
        {
            get { return total_pago_tratamiento; }
            set { total_pago_tratamiento = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { value = cantidad; }
        }

        public bool Equals(Entidad otroDetalle)
        {
            if (this.cantidad != (otroDetalle as Detalle_Presupuesto_Factura).cantidad)
            {
                return false;
            }
            if (this.total_pago_tratamiento != (otroDetalle as Detalle_Presupuesto_Factura).total_pago_tratamiento)
            {
                return false;
            }
            if (this.el_Tratamiento.Equals((otroDetalle as Detalle_Presupuesto_Factura).el_Tratamiento) == false)
            {
                return false;
            }

            return true;
        }

        #endregion

    }
}

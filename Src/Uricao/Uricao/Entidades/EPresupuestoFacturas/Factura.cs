using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EPresupuestoFacturas
{
    public class Factura : Entidad
    {
        private int nro_factura;
        private List<Detalle_Presupuesto_Factura> listado_factura;
        private DateTime fecha_emitida;
        private String nombre_razon;
        private Boolean estado_factura;
        private String cedula_razon;
        private String cedula_paciente;
        private double total_factura;
        private int id_direccion;
        private String tipoIdentRazon;
        private String tipoIdentPaciente;



        public Factura(int nro_factura, double total_Factura, Boolean estado_factura, 
            String cedula_paciente, String tipoIdentPaciente,
            String cedula_razon, String tipoIdentRazon, 
            String nombre_razon, int id_direccion )
        {
            this.nro_factura = nro_factura;
            this.total_factura = total_Factura;
            this.listado_factura = new List<Detalle_Presupuesto_Factura>();
            this.estado_factura = estado_factura;
            this.fecha_emitida = System.DateTime.Now;
            this.cedula_paciente = cedula_paciente;
            this.nombre_razon = nombre_razon;
            this.cedula_razon = cedula_razon;
            this.id_direccion = id_direccion;
            this.tipoIdentRazon = tipoIdentRazon;
            this.tipoIdentPaciente = tipoIdentPaciente;
        }

        public Factura() {
            listado_factura = new List<Detalle_Presupuesto_Factura>();
        }

        public String TipoIdentRazon
        {
            get { return tipoIdentRazon;}
            set { this.tipoIdentRazon = value;}
        }
        public String TipoIdentPaciente
        {
            get { return tipoIdentPaciente; }
            set { this.tipoIdentPaciente = value;}
        }
        public int Nro_factura
        {
            get { return nro_factura; }
            set { nro_factura = value; }
        }
        public List<Detalle_Presupuesto_Factura> Listado_factura
        {
            get { return listado_factura; }
            set { listado_factura = value; }
        }
        public DateTime Fecha_emitida
        {
            get { return fecha_emitida; }
            set { fecha_emitida = value; }
        }
        public String Nombre_razon
        {
            get { return nombre_razon; }
            set { nombre_razon = value; }
        }
        public String Cedula_razon
        {
            get { return cedula_razon; }
            set { cedula_razon = value; }
        }
        public String Cedula_paciente
        {
            get { return cedula_paciente; }
            set { cedula_paciente = value; }
        }
        public double Total_factura
        {
            get { return total_factura; }
            set { total_factura = value; }
        }
        public Boolean Estado_factura
        {
            get { return estado_factura; }
            set { estado_factura = value; }
        }
        public int Id_direccion
        {
            get { return id_direccion; }
            set { id_direccion = value; }
        }

        public void setId_Direccion(int id_direccion)
        {
            this.id_direccion = id_direccion;
        }
        public int getId_Direccion()
        {
            return id_direccion;
        }
        public void setCedula_Razon(String cedula_razon)
        {
            this.cedula_razon = cedula_razon;
        }
        public string getCedula_Razon()
        {
            return cedula_razon;
        }
        public void setNombre_Razon(String nombre_razon)
        {
            this.nombre_razon = nombre_razon;
        }
        public string getNombre_Razon()
        {
            return nombre_razon;
        }
        public void setCedula_Paciente(String cedula_paciente)
        {
            this.cedula_paciente = cedula_paciente;
        }
        public string getCedula_Paciente()
        {
            return cedula_paciente;
        }
        public DateTime getFecha_Emitida()
        {
            return fecha_emitida;
        }
        public void setFecha_Emitida(DateTime fecha_emitida)
        {
            this.fecha_emitida = fecha_emitida;
        }
        public bool getEstado_Factura()
        {
            return estado_factura;
        }
        public void setEstado_Factura(bool estado_factura)
        {
            this.estado_factura = estado_factura;
        }
        public int getNro_Factura()
        {
            return this.nro_factura;
        }
        public List<Detalle_Presupuesto_Factura> getListado_Factura()
        {
            return this.listado_factura;
        }
        public double getTotal_Factura()
        {
            return total_factura;
        }
        public void setNro_Factura(int nro_factura)
        {
            this.nro_factura = nro_factura;
        }
        public void setTotal_Factura(double total_factura)
        {
            this.total_factura = total_factura;
        }
        public void addDetalle(Detalle_Presupuesto_Factura elDetalle)
        {
            listado_factura.Add(elDetalle);
        }
        public Detalle_Presupuesto_Factura getDetalle_Factura(int i)
        {
            Detalle_Presupuesto_Factura regreso = null;

            Object[] directorio = listado_factura.ToArray();

            regreso = (Detalle_Presupuesto_Factura)directorio[i];

            return regreso;

        }
        public int getTamano_Lista()
        {
            Object[] directorio = listado_factura.ToArray();
            return directorio.Length;

        }

        public bool Equals(Factura otraFactura)
        {
            if (this.nro_factura != otraFactura.nro_factura)
            {
                return false;
            }
            if (this.fecha_emitida != otraFactura.fecha_emitida)
            {
                return false;
            }
            if (this.nombre_razon != otraFactura.nombre_razon)
            {
                return false;
            }
            if (this.estado_factura != otraFactura.estado_factura)
            {
                return false;
            }
            if (this.cedula_razon != otraFactura.cedula_razon)
            {
                return false;
            }
            if (this.cedula_paciente != otraFactura.cedula_paciente)
            {
                return false;
            }
            if (this.total_factura != otraFactura.total_factura)
            {
                return false;
            }
            if (this.id_direccion != otraFactura.id_direccion)
            {
                return false;
            }
            if (this.tipoIdentRazon != otraFactura.tipoIdentRazon)
            {
                return false;
            }
            if (this.tipoIdentPaciente != otraFactura.tipoIdentPaciente)
            {
                return false;
            }
            if (this.fecha_emitida != otraFactura.fecha_emitida)
            {
                return false;
            }

            int i;
            if (this.listado_factura.Count == otraFactura.listado_factura.Count)
            {
                for (i = 0; i < this.listado_factura.Count; i++)
                {
                    if (this.listado_factura[i].Equals(otraFactura.listado_factura[i]) == false)
                    {
                        return false;
                    }
                }
            }
            else 
            {
                return false;
            }

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
            //fechaInicio.Date.Equals(fechaFin.Date) && 
            return (intervaloFechasValidadas <= 0);
        }

        #endregion

        #endregion
    }
}

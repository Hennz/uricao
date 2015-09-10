using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;


namespace Uricao.Entidades.EAgendaCitas
{
    public class Cita : Entidad
    {
        private int _id;
        private DateTime _fecha;
        private int _horaInicio;
        private int _horaFin;
        private String _confirmacion;
        private String _status;
       
        private String _tratamiento;
        private Int16 _idMedico;
        private String _nombreMedico;
        private String _apellidoMedico;

        //atributos de prueba
       
        private int numeroGridView;
        private string mensaje;


        //Getter y Setter

        public int _Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime _Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public int _HoraInicio
        {
            get { return _horaInicio; }
            set { _horaInicio = value; }
        }

        public int _HoraFin
        {
            get { return _horaFin; }
            set { _horaFin = value; }
        }

        public String _Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public String _Confirmacion
        {
            get { return _confirmacion; }
            set { _confirmacion = value; }
        }

        public String _Tratamiento
        {
            get { return _tratamiento; }
            set { _tratamiento = value; }
        }

        public Int16 _IdMedico
        {
            get { return _idMedico; }
            set { _idMedico = value; }
        }

        public String _NombreMedico
        {
            get { return _nombreMedico; }
            set { _nombreMedico = value; }
        }


        public String _ApellidoMedico
        {
            get { return _apellidoMedico; }
            set { _apellidoMedico = value; }
        }

        //Gettery setter de prueba

        public int NumeroGridView
        {
            get { return numeroGridView; }
            set { numeroGridView = value; }
        }

        public String Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        

        //Constructores
        public Cita()
        {
            _tratamiento = "";
            _confirmacion = "No Confirmada";
            _status = "Activa";
           
        }

        public Cita(DateTime _fecha, int _horaInicio, int _horaFin, String _nombreMedico, String _apellidoMedico, String _tratamiento)
        {
            
            _Fecha = _fecha;
            _HoraInicio = _horaInicio;
            _HoraFin = _horaFin;
            _NombreMedico = _nombreMedico;
            _ApellidoMedico = _apellidoMedico;
            _Tratamiento = _tratamiento;
           

        }

        public Cita( String _confirmacion, String _status)
        {

            _Status = _status;
            _Confirmacion = _confirmacion;


        }

        public Cita(int _id,DateTime _fecha, String _nombreMedico, String _apellidoMedico, String _tratamiento)
        {
            _Id = _id;
            _Fecha = _fecha;
            _NombreMedico = _nombreMedico;
            _ApellidoMedico = _apellidoMedico;
            _Tratamiento = _tratamiento;


        }



        public Cita(int _id, DateTime _fecha, int _horaInicio, int _horaFin, String _nombreMedico, String _apellidoMedico, String _tratamiento)
        {

            _Id = _id;
            _Fecha = _fecha;
            _HoraInicio = _horaInicio;
            _HoraFin = _horaFin;
            _NombreMedico = _nombreMedico;
            _ApellidoMedico = _apellidoMedico;
            _Tratamiento = _tratamiento;


        }

       

        /*
        
        //De prueba para el data grid
        public Cita(int nuevoNumeroGridView, string nuevoMensaje)
        {
            this.numeroGridView = nuevoNumeroGridView;
            this.mensaje = nuevoMensaje;
        }
        */
    }
}
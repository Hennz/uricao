using System;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;


namespace Uricao.Entidades.EHistoriaPaciente
{
    public class DetalleSecuencia : Entidad
    {
        #region Atributos

        private int idSecuencia;
        private DateTime _Fecha;
        private string _Observacion;
        private Tratamiento _tratamiento;
        private Usuario _odontologo;
        private String _pieza;
        private String _diagnostico;
        private int _idHistoriaBase;
        private String _estado;



        #endregion Atributos


        public DetalleSecuencia()
        {

        }

        #region Implementación de los Getter and Setter
        public String Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public String Pieza
        {
            get { return _pieza; }
            set { _pieza = value; }
        }

        public String Diagnostico
        {
            get { return _diagnostico; }
            set { _diagnostico = value; }
        }

        public int IdHistoriaBase
        {
            get { return _idHistoriaBase; }
            set { _idHistoriaBase = value; }
        }

        public DateTime Fecha 
        { 
            get { return _Fecha; } 
            set { this._Fecha = value; }
        }

        public string Observacion 
        { 
            get { return _Observacion; } 
            set { this._Observacion = value; }
        }

        public Tratamiento Tratamiento 
        { 
            get { return _tratamiento; } 
            set { this._tratamiento = value; } 
        }

        public Usuario Odontologo
        {
            get { return _odontologo; }
            set { this._odontologo = value; }
        }

        public int IdSecuencia
        {
            get { return idSecuencia; }
            set { idSecuencia = value; }
        }

        #endregion Implementación de los Getter and Setter
    }
}
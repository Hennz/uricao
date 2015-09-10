// File: HistoriaClinica.cs Company: La Cruz 
// Copyright (c) 01-08-2013 All Right Reserved
// author: Enrique La Cruz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EHistoriaPaciente
{
    public class HistoriaClinica: Entidad
    {
        #region Atributos

        private int _NumeroHistoria;
        private DateTime _FechaIngreso;
        private Cliente _Paciente;
        private string _Observacion;
        private List<Entidad> _ListaDetalleSecuencia;
        private List<Entidad> _ListaAntecedente;
        private List<Entidad> _ListaDiente;
        private String estado;

        #endregion Atributos

        #region Constructores

        public HistoriaClinica()
        {

        }

        #endregion Constructores

        #region Encapsulamiento

        public int NumeroHistoria
        {
            get { return _NumeroHistoria; }
            set { _NumeroHistoria = value; }
        }
        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }


        public Cliente Paciente
        {
            get { return _Paciente; }
            set { _Paciente = value; }
        }

        public DateTime FechaIngreso
        {
            get { return _FechaIngreso; }
            set { _FechaIngreso = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public List<Entidad> ListaDiente
        {
            get { return _ListaDiente; }
            set { _ListaDiente = value; }
        }
        public List<Entidad> ListaAntecedente
        {
            get { return _ListaAntecedente; }
            set { _ListaAntecedente = value; }
        }
        public List<Entidad> ListaDetalleSecuencia
        {
            get { return _ListaDetalleSecuencia; }
            set { _ListaDetalleSecuencia = value; }
        }
              
        #endregion Encapsulamiento
    }
}
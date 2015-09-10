// File: PrueabaDAOHistoriaClinica.cs Company: La Cruz 
// Copyright (c) 01-08-2013 All Right Reserved
// author: Enrique La Cruz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EHistoriaPaciente;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.ETratamientos;

namespace Uricao.PruebasUnitarias.PHistoriaClinica
{
    [TestFixture]
    public class PrueabaDAOHistoriaClinica
    {

        [Test]
        public void PrueabaConsultarTodasHistoriaClinica()
        {
            DAOHistoriaClinica _prueba = new DAOHistoriaClinica();
            List<Entidad> _historias = new List<Entidad>();
            _historias = _prueba.ConsultarTodasHistoriaClinica();
       
            foreach(Entidad _historia in _historias)
            {
                System.Console.WriteLine((_historia as HistoriaClinica).NumeroHistoria);
                System.Console.WriteLine((_historia as HistoriaClinica).FechaIngreso);
                System.Console.WriteLine((_historia as HistoriaClinica).Observacion);
                System.Console.WriteLine((_historia as HistoriaClinica).Estado);
            }

            Assert.IsNotNull(_historias);
        }

        [Test]
        public void PrueabaConsultarHistoriaClinica()
        {
            DAOHistoriaClinica _prueba = new DAOHistoriaClinica();
            List<Entidad> _historias = new List<Entidad>();
            String _nombre = "Carlos";
            String _apellido = "";
            String _cedula = "";
            int _idHistoria = 0;

            _historias = _prueba.ConsultarHistoriaClinica(_nombre,_apellido,_cedula,_idHistoria);

            foreach (Entidad _historia in _historias)
            {
                System.Console.WriteLine((_historia as HistoriaClinica).NumeroHistoria);
                System.Console.WriteLine((_historia as HistoriaClinica).FechaIngreso);
                System.Console.WriteLine((_historia as HistoriaClinica).Observacion);
                System.Console.WriteLine((_historia as HistoriaClinica).Estado);
            }

            int esperado = 1;
            int actual = (_historias[0] as HistoriaClinica).NumeroHistoria;

            Assert.AreEqual(esperado,actual);
            Assert.IsNotNull(_historias);
        }


        [Test]
        public void pruebaAgregarAntecedente()
        {
            DAOHistoriaClinica prueba = new DAOHistoriaClinica();
            List<String> _respuestas = new List<String>();
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("no");
            _respuestas.Add("ninguno");
            _respuestas.Add("ninguno");
            _respuestas.Add("ninguno");


            Console.WriteLine();
            Assert.IsTrue(prueba.AgregarAntecedente(_respuestas, 0));
        }

        [Test]
        public void pruebaConsultarAntecedente()
        {
            DAOHistoriaClinica prueba = new DAOHistoriaClinica();
            List<Entidad> _antecedente = new List<Entidad>();
            _antecedente = prueba.ConsultarAntecedente(1);

            foreach (Entidad d in _antecedente)
            {
                Console.WriteLine((d as Antecedente).Respuesta);

            }
            Assert.IsNotNull(_antecedente);
        }


        [Test]
        public void pruebaConsultarSecuencia()
        {
            DAOHistoriaClinica prueba = new DAOHistoriaClinica();
            List<Entidad> _secuencia = new List<Entidad>();
            _secuencia = prueba.ConsultarSecuencia(1);

            foreach (Entidad d in _secuencia)
            {
                Console.WriteLine((d as DetalleSecuencia).Observacion);

            }
            Assert.IsNotNull(_secuencia);
        }

        [Test]
        public void pruebaModificarAntecedente()
        {
            DAOHistoriaClinica prueba = new DAOHistoriaClinica();
            List<Entidad> _antecedente = new List<Entidad>();
            Entidad resp1 = FabricaEntidad.NuevoAntecedente();
            Entidad resp2 = FabricaEntidad.NuevoAntecedente();
            Entidad resp3 = FabricaEntidad.NuevoAntecedente();

            (resp1 as Antecedente).IdAntecedente = 1;
            (resp1 as Antecedente).Respuesta = "otra";
            (resp2 as Antecedente).IdAntecedente = 2;
            (resp2 as Antecedente).Respuesta = "prueab";
            (resp3 as Antecedente).IdAntecedente = 3;
            (resp3 as Antecedente).Respuesta = "Volver";

            _antecedente.Add(resp1);
            _antecedente.Add(resp2);
            _antecedente.Add(resp3);

            foreach (Entidad d in _antecedente)
            {
                Console.WriteLine((d as Antecedente).Respuesta);
            }

            Assert.IsNotNull(prueba.ModificarAntecedente(_antecedente));
        }


        [Test]
        public void pruebaModificarSecuencia()
        {/*
            DAOHistoriaClinica prueba = new DAOHistoriaClinica();
            List<Entidad> _secuencias = new List<Entidad>();
            Entidad secuencia = FabricaEntidad.NuevoDetalleSecuencia();
            Entidad medico = FabricaEntidad.NuevaUsuario();
            Entidad tratamiento = FabricaEntidad.NuevoTratamiento();

            (medico as Usuario).IdUsuario = 3;
            (tratamiento as Tratamiento).Id = 1; 
            (secuencia as DetalleSecuencia).IdSecuencia = 1;
            (secuencia as DetalleSecuencia).Observacion ="Prueba exitosa";
            (secuencia as DetalleSecuencia).Tratamiento = (tratamiento as Tratamiento);
            (secuencia as DetalleSecuencia).IdHistoriaBase = 1;
            (secuencia as DetalleSecuencia).Odontologo= (medico as Usuario);
            (secuencia as DetalleSecuencia).Fecha = DateTime.ParseExact("10/08/2012", @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture); 
            _secuencias.Add(secuencia);

            Assert.IsNotNull(prueba.ModificarSecuencia(_secuencias));*/
        }

        [Test]
        public void pruebaModificarHistoriaClinica()
        {
            DAOHistoriaClinica prueba = new DAOHistoriaClinica();
            Entidad historia = FabricaEntidad.NuevaHistoria();

            (historia as HistoriaClinica).NumeroHistoria = 1;
            (historia as HistoriaClinica).FechaIngreso = DateTime.ParseExact("15/10/2012", @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            (historia as HistoriaClinica).Estado ="activo";
            (historia as HistoriaClinica).Observacion = "sEGUNDA PRUEBA";

            Assert.IsNotNull(prueba.ModificarHistoriaClinica(historia));
        }

        [Test]
        public void pruebActivarDesactivarHistoriaClinica()
        {
            DAOHistoriaClinica prueba = new DAOHistoriaClinica();

            Assert.IsNotNull(prueba.ActivarDesactivarHistoriaClinica(1,"InACTiVO"));
        }

        [Test]
        public void PruebAgregarSecuencia()
        {
            DAOHistoriaClinica prueba = new DAOHistoriaClinica();
            List<Entidad> _secuencias = new List<Entidad>();
            Entidad secuencia = FabricaEntidad.NuevoDetalleSecuencia();
            Entidad medico = FabricaEntidad.NuevaUsuario();
            Entidad tratamiento = FabricaEntidad.NuevoTratamiento();

            (medico as Usuario).IdUsuario = 3;
            (tratamiento as Tratamiento).Id = 1;

            (secuencia as DetalleSecuencia).IdSecuencia = 1;
            (secuencia as DetalleSecuencia).Observacion = "Prueba exitosa";
            (secuencia as DetalleSecuencia).Tratamiento = (tratamiento as Tratamiento);
            (secuencia as DetalleSecuencia).IdHistoriaBase = 1;
            (secuencia as DetalleSecuencia).Odontologo = (medico as Usuario);
            (secuencia as DetalleSecuencia).Fecha = DateTime.ParseExact("10/08/2012", @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            _secuencias.Add(secuencia);

            Assert.IsNotNull(prueba.AgregarSecuencia(_secuencias,1));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Uricao.Entidades.EAgendaCitas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Presentacion.PaginasWeb;
using System.Data;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EAgendaCitas;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.LogicaDeNegocios.Comandos.AgendaCitas;
using Uricao.Presentacion.Presentador.PAgendaCitas;



namespace Uricao.PruebasUnitarias.PAgendaCitas
{
    [TestFixture]
    public class PruebasAgendayCitas
    {


        #region Pruebas de consultar cita;

        [Test]
        public void pruebaConsultarCitaNombreMedico()
        {
            String _nombreMedico = "Yeimy";
            String _apellidoMedico = "Martinez";
            int esperado = 7;
            List<Entidad> listaCitas = null;
            ComandoConsultarCitaPorNombreMedico _comando = FabricaComando.CrearComandoConsultarCitaPorNombreMedico(_nombreMedico, _apellidoMedico);
            listaCitas = _comando.Ejecutar();
            Assert.IsNotNull(listaCitas);
            Assert.AreEqual(esperado, listaCitas.Count);
        }

        [Test]
        public void pruebaConsultarCitaFecha()
        {
            List<Entidad> listaCitas = null;
            String _fechaString = "18/01/2013";
            int esperado = 1;
            DateTime _fecha = DateTime.ParseExact(_fechaString, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ComandoConsultarCitaFecha _comando = FabricaComando.CrearComandoConsultarCitaFecha(_fecha.ToString("yyyy-MM-dd"));
            listaCitas = _comando.Ejecutar();
            Assert.IsNotNull(listaCitas);
            Assert.AreEqual(esperado, listaCitas.Count);
        }

        [Test]
        public void pruebaConsultarCitaRangoFecha()
        {
            List<Entidad> listaCitas = null;
            String _fechaInicioString = "01/12/2012";
            String _fechaFinString = "31/12/2012";
            int esperado = 6;
            DateTime _fechaInicio = DateTime.ParseExact(_fechaInicioString, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime _fechaFin = DateTime.ParseExact(_fechaFinString, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ComandoConsultarCitaRangoFecha _comando = FabricaComando.CrearComandoConsultarCitaRangoFecha(_fechaInicio.ToString("yyyy-MM-dd"), _fechaFin.ToString("yyyy-MM-dd"));
            listaCitas = _comando.Ejecutar();
            Assert.IsNotNull(listaCitas);
            Assert.AreEqual(esperado, listaCitas.Count);
        }

        [Test]
        public void pruebaConsultarCitaPorCedulaUsuario()
        {
            List<Entidad> listaCitas = null;
            String _cedulaPaciente = "19560012";
            int esperado = 7;
            ComandoConsultarCitaPorCedulaUsuario _comando = FabricaComando.CrearComandoConsultarCitaPorCedulaUsuario(_cedulaPaciente);
            listaCitas = _comando.Ejecutar();
            Assert.IsNotNull(listaCitas);
            Assert.AreEqual(esperado, listaCitas.Count);
        }

        //para la consulta de modificar:

        [Test]
        public void pruebaConsultarCitasMedicoFecha()
        {
            // Consulta de disponibilidad 
            String _fechaString = "15/01/2013";
            int esperado = 8; // por que el array es de tamano 8
            String _nombreMedico = "Carlo";
            String _apellidoMedico = "Magurno";
            String _tratamiento = "Tartrectomia";
            String _diaSemana = "Martes";
            DateTime _fecha1 = DateTime.ParseExact(_fechaString, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Comando<int[]> _comando = FabricaComando.CrearComandoHorarioDisponibleMedicoFecha(_nombreMedico, _apellidoMedico, _fecha1, _tratamiento, _diaSemana);
            int[] _citasDisponibles = _comando.Ejecutar();
            Assert.IsNotNull(_citasDisponibles);
            Assert.AreEqual(esperado, _citasDisponibles.Count());
        }

        [Test]
        public void pruebaComandoModificarCita()
        {
            String _fechaNueva = "06/08/2013";
            String _nombreMedico = "Carlo";
            String _apellidoMedico = "Magurno";
            String _tratamiento = "Tartrectomia";
            String _diaSemana = "Martes";
            int _idCita = 7;
            int _Horai = 14;
            int _Horaf = 16;

            DateTime _fecha = DateTime.ParseExact(_fechaNueva, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            Comando<bool> _comando = FabricaComando.CrearComandoModificarCita(_idCita, _fechaNueva, _Horai, _Horaf, _tratamiento, _nombreMedico, _apellidoMedico, _diaSemana);
            bool _resultado = _comando.Ejecutar();
            Assert.IsTrue(_resultado);




        }

        //public void pruebaManejoDiaFecha()
        //{
        //    List<Entidad> listaCitas = null;
        //    PresentadorModificarCita presentador = new PresentadorModificarCita();
        //    String _fechaString = "28/01/2013";
        //    String _diaSemana = presentador.ManejoDiaFecha(_fechaString);

        //}



        #endregion
        [Test]
        public void pruebaAgregarCita()
        {
            String cedulaPaciente = "19560012";
            String diaSemana = "Lunes";
            DateTime _fecha = new DateTime();
            _fecha = Convert.ToDateTime("04/03/2013");
            Cita _cita = new Cita(_fecha, 8, 10, "Yeimy", "Martinez", "Tartrectomia");
            ComandoAgregarCita comando = FabricaComando.CrearComandoAgregarCita(_cita, cedulaPaciente, diaSemana);
            bool _resultado = comando.Ejecutar();
            Assert.AreEqual(true, _resultado);

        }



        [Test]
        public void pruebaCancelarCita()
        {
            int idCita = 1;
            ComandoCancelarCita _comando = FabricaComando.CrearComandoCancelarCita(idCita);
            bool _correcto = _comando.Ejecutar();
            Assert.IsTrue(_correcto);
        }

        [Test]
        public void pruebaConfirmarCita()
        {
            int idCita = 1;
            ComandoConfirmarCita _comando = FabricaComando.CrearComandoConfirmarCita(idCita);
            bool _correcto = _comando.Ejecutar();
            Assert.IsTrue(_correcto);
        }



        [Test]
        public void pruebaConstructorStatus()
        {
            Entidad _miCita = FabricaEntidad.NuevaCita();
            Assert.IsNotNull(_miCita);
            Assert.AreEqual("No Confirmada", (_miCita as Cita)._Confirmacion);
            Assert.AreEqual("Activa", (_miCita as Cita)._Status);
        }
        [Test]

        public void pruebaConstructorCita()
        {
            DateTime fecha = new DateTime();
            fecha = Convert.ToDateTime("04/03/2013");
            Entidad _cita = FabricaEntidad.NuevaCita();
            (_cita as Cita)._Fecha = fecha;
            (_cita as Cita)._HoraInicio = 8;
            (_cita as Cita)._HoraFin = 10;
            (_cita as Cita)._NombreMedico = "Yeimy";
            (_cita as Cita)._ApellidoMedico = "Martinez";
            (_cita as Cita)._Tratamiento = "Tartrectomia";
            Assert.IsNotNull(_cita as Cita);
            Assert.AreEqual(fecha, Convert.ToDateTime((_cita as Cita)._Fecha));
            Assert.AreEqual(8, (_cita as Cita)._HoraInicio);
            Assert.AreEqual(10, (_cita as Cita)._HoraFin);
            Assert.AreEqual("Yeimy", (_cita as Cita)._NombreMedico);
            Assert.AreEqual("Martinez", (_cita as Cita)._ApellidoMedico);
            Assert.AreEqual("Tartrectomia", (_cita as Cita)._Tratamiento);



        }


    }
}
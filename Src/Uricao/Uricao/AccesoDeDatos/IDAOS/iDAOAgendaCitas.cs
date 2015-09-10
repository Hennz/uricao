using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EAgendaCitas;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EEntidad;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOAgendaCitas : iDAO
    {

        bool AgregarCita(Cita cita, String idcliente, String diaSemana);
        int[] ConsultarHorarioMedicoUnaFecha(String nombremedico, String apellidomedico, String diaSemana, String tratamiento);
        List<Entidad> ConsultarCitasActualesUnaFecha(String nombremedico, String apellidomedico, DateTime fecha);
//Para Consulta de Cita
        List<Entidad> ConsultarCitaUnaFecha(String _fecha);
        List<Entidad> ConsultarCitaRangoFecha(String fechaInicio, String fechaFin);
        List<Entidad> ConsultarCitaPorCedulaUsuario(String _cedulaPaciente);
        List<Entidad> ConsultarCitaPorNombreMedico(String _nombre, String _apellido);

        bool ConfirmarCita(int _idcita);
        bool CancelarCita(int _idcita);
        
        bool ModificarCita(int idCita, String _fecha, int horaInicio, int horaFin, String tratamiento, String _nombreMedico, String _apellidoMedico, String diaSemana);
    }
}
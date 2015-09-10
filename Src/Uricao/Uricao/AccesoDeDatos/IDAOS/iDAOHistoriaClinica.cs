using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.AccesoDeDatos.IDAOS
{
    public interface iDAOHistoriaClinica : iDAO
    {

        //Consultar
        List<Entidad> ConsultarTodasHistoriaClinica();
        List<Entidad> ConsultarHistoriaClinica(String nombre, String apellido, String cedula, int idHistoria);
        List<Entidad> ConsultarAntecedente(int idHistoriaClinica);
        List<Entidad> ConsultarSecuencia(int idDiente);
        Entidad ConsultarSecuenciaXid(int idSecuencia);

        //Agregar
        bool AgregarHistoriaClinica(Entidad historiaClinica);
        bool AgregarAntecedente(List<String> _respuestas, int idHistoriaClinica);
        bool AgregarSecuencia(List<Entidad> _secuencia, int idDiente);

        //Modificar
        bool ModificarHistoriaClinica(Entidad _historiaClinica);
        bool ModificarAntecedente(List<Entidad> _respuestas);
        bool ModificarSecuencia(List<Entidad> _secuencias);

        //Activar/Inactivar
        bool ActivarDesactivarHistoriaClinica(int idHistoriaClinica, String estado);
        bool ActivarDesactivarSecuencia(int idSecuencia, String estado);

        //buscar ultimo
        int BuscarUltimaId();

        //Metodos usados por otros Grupos
        int ConsultarIdTratamiento(string tratamiento);




    }
}
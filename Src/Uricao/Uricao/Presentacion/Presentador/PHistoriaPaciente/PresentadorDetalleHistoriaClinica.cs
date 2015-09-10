using System;
using System.Collections.Generic;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EHistoriaPaciente;
using Uricao.LogicaDeNegocios.Fabricas;

namespace Uricao.Presentacion.Presentador.PHistoriaPaciente
{
    public class PresentadorDetalleHistoriaClinica
    {
        private IContratoDetalleHistoriaClinica _vista;
        Entidad historia;
        private List<Entidad> listaRespuestas;

        public PresentadorDetalleHistoriaClinica(IContratoDetalleHistoriaClinica _vista)
        {
            this._vista = _vista;
           
        }

        public void PintarDatos()
        {
            historia = (Entidad)_vista.Sesion["Historia"];
            if (!(historia == null))
            {
                _vista.SetLabelExito("Detalle exitoso");
                _vista.Nombre.Text = _vista.Nombre.Text + " " +
                                    (historia as HistoriaClinica).Paciente.PrimerNombre + " " +
                                    (historia as HistoriaClinica).Paciente.SegundoNombre + " " +
                                    (historia as HistoriaClinica).Paciente.PrimerApellido + " " +
                                    (historia as HistoriaClinica).Paciente.SegundoApellido;
                _vista.Fecha.Text = _vista.Fecha.Text + " " +(historia as HistoriaClinica).FechaIngreso.ToShortDateString();
                _vista.Edad.Text = _vista.Edad.Text + " " + Edad((historia as HistoriaClinica).Paciente.FechaNace);
                _vista.Sexo.Text = _vista.Sexo.Text + " " + (historia as HistoriaClinica).Paciente.Sexo;
                _vista.Ide.Text = _vista.Ide.Text + " " + (historia as HistoriaClinica).Paciente.Identificacion;
                _vista.Nace.Text = _vista.Nace.Text + " " + (historia as HistoriaClinica).Paciente.FechaNace.ToShortDateString();
                _vista.Direccion.Text = _vista.Direccion.Text + " " + (historia as HistoriaClinica).Paciente.Direccion.Tipo + " "
                    + (historia as HistoriaClinica).Paciente.Direccion.Nombre;
               
                List<string> tlf = new List<string>();
                tlf = (historia as HistoriaClinica).Paciente.Telefono;
                String telefono="";
                foreach(string t in tlf)
                    telefono=telefono+t+" ";

                _vista.Telefono.Text = _vista.Telefono.Text + " " + telefono;
                _vista.Obs.Text = _vista.Obs.Text + " " + (historia as HistoriaClinica).Observacion;

                listaRespuestas = FabricaComando.crearComandoConsultarAntecedente((historia as HistoriaClinica).NumeroHistoria).Ejecutar();
                _vista.P1.Text = _vista.P1.Text+" "+(listaRespuestas[0] as Antecedente).Respuesta;
                _vista.P2.Text = _vista.P2.Text + " " + (listaRespuestas[1] as Antecedente).Respuesta;
                _vista.P3.Text = _vista.P3.Text + " " + (listaRespuestas[2] as Antecedente).Respuesta;
                _vista.P4.Text = _vista.P4.Text + " " + (listaRespuestas[3] as Antecedente).Respuesta;
                _vista.P5.Text = _vista.P5.Text + " " + (listaRespuestas[4] as Antecedente).Respuesta;
                _vista.P6.Text = _vista.P6.Text + " " + (listaRespuestas[5] as Antecedente).Respuesta;
                _vista.P7.Text = _vista.P7.Text + " " + (listaRespuestas[6] as Antecedente).Respuesta;
                _vista.P8.Text = _vista.P8.Text + " " + (listaRespuestas[7] as Antecedente).Respuesta;
                _vista.P9.Text = _vista.P9.Text + " " + (listaRespuestas[8] as Antecedente).Respuesta;
                _vista.P16.Text = _vista.P16.Text + " " + (listaRespuestas[9] as Antecedente).Respuesta;
                _vista.P17.Text = _vista.P17.Text + " " + (listaRespuestas[10] as Antecedente).Respuesta;
                _vista.P18.Text = _vista.P18.Text + " " + (listaRespuestas[11] as Antecedente).Respuesta;
                _vista.P13.Text = _vista.P13.Text + " " + (listaRespuestas[12] as Antecedente).Respuesta;
                _vista.P14.Text = _vista.P14.Text + " " + (listaRespuestas[13] as Antecedente).Respuesta;
                _vista.P15.Text = _vista.P15.Text + " " + (listaRespuestas[14] as Antecedente).Respuesta;

                _vista.P10.Text = _vista.P10.Text + " " + (listaRespuestas[15] as Antecedente).Respuesta;
                _vista.P11.Text = _vista.P11.Text + " " + (listaRespuestas[16] as Antecedente).Respuesta;
                _vista.P12.Text = _vista.P12.Text + " " + (listaRespuestas[17] as Antecedente).Respuesta;

            }
            else
                _vista.SetLabelFalla("No se han pasado datos");
        }

        private String Edad(DateTime fechaNacimiento)
        {
             //Obtengo la diferencia en años.
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            //Obtengo la fecha de cumpleaños de este año.
            DateTime nacimientoAhora = fechaNacimiento.AddYears(edad);
             //Le resto un año si la fecha actual es anterior 
             //al día de nacimiento.
             if (DateTime.Now.CompareTo(nacimientoAhora) < 0)
             { 
                edad--; 
             }

             return edad.ToString();
        }


    }


}
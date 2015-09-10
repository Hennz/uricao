using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.EHistoriaPaciente;
using Uricao.Entidades.ETratamientos;

namespace Uricao.Presentacion.Presentador.PHistoriaPaciente
{
    public class PresentadorDetalleOdontodiagrama
    {
        IContratoDetalleOdontodiagrama _vista;
        Entidad secuencia;
        Entidad tratamiento;

        public PresentadorDetalleOdontodiagrama(IContratoDetalleOdontodiagrama _vista)
        {
            this._vista = _vista;
        }

        public void PintarDatos()
        {
            secuencia = (Entidad)_vista.Sesion["Secuencia"];
            tratamiento =(Entidad)_vista.Sesion["Tratamiento"];
            if (!(secuencia == null))
            {
                _vista.Diagnostico.Text = _vista.Diagnostico.Text+" "+(secuencia as DetalleSecuencia).Diagnostico;
                _vista.Fecha.Text = _vista.Fecha.Text+" "+(secuencia as DetalleSecuencia).Fecha.ToShortDateString();
                _vista.Medico.Text = _vista.Medico.Text+" "+"medico";
                _vista.Pieza.Text = _vista.Pieza.Text+" "+(secuencia as DetalleSecuencia).Pieza.ToString();
                _vista.Observaciones.Text = _vista.Observaciones.Text+" "+(secuencia as DetalleSecuencia).Observacion;
                _vista.Tratamiento.Text = _vista.Tratamiento.Text + " Nombre: " + (tratamiento as Tratamiento).Nombre.ToString() + " Descripcion: " +
                                        (tratamiento as Tratamiento).Descripcion + " Explicacion: " + (tratamiento as Tratamiento).Explicacion + " Costo: " +
                                        (tratamiento as Tratamiento).Costo;
                
            }
            else
                _vista.SetLabelFalla("No se han pasado datos");
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.Presentacion.Presentador.PHistoriaPaciente
{
    public class PresentadorAgregarAntecendente
    {
        private IContratoAgregarAntecedente _vista;
        Entidad a = FabricaEntidad.NuevaHistoria();
        public PresentadorAgregarAntecendente(IContratoAgregarAntecedente _vista)
        {
            this._vista = _vista;
        }

        public List<String> PasarListaRespuestas()
        {
            List<String> listaRespuestas = new List<string>();

                listaRespuestas.Add(_vista.Respuesta1.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta2.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta3.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta4.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta5.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta6.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta7.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta8.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta9.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta10.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta11.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta12.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta13.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta14.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta15.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta16.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta17.SelectedItem.Text);
                listaRespuestas.Add(_vista.Respuesta18.SelectedItem.Text);
            
            return listaRespuestas;
        }

        public bool validarDatos()
        {

            if (_vista.Respuesta1.SelectedItem != null && _vista.Respuesta2.SelectedItem != null && _vista.Respuesta3.SelectedItem != null && _vista.Respuesta4.SelectedItem != null &&
                _vista.Respuesta5.SelectedItem != null && _vista.Respuesta6.SelectedItem != null && _vista.Respuesta7.SelectedItem != null && _vista.Respuesta8.SelectedItem != null &&
                _vista.Respuesta9.SelectedItem != null && _vista.Respuesta10.SelectedItem != null && _vista.Respuesta11.SelectedItem != null && _vista.Respuesta12.SelectedItem != null &&
                _vista.Respuesta13.SelectedItem != null && _vista.Respuesta14.SelectedItem != null && _vista.Respuesta15.SelectedItem != null && _vista.Respuesta16.SelectedIndex > 0 &&
                _vista.Respuesta17.SelectedIndex > 0 && _vista.Respuesta18.SelectedIndex > 0)
            {
                return true;
            }
            else
            {
                _vista.SetLabelFalla("Porfavor complete todos los campos");
                return false;
            }
        }


    }
}
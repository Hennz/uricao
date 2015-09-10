using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.EHistoriaPaciente;
using System.Web.UI.WebControls;

namespace Uricao.Presentacion.Presentador.PHistoriaPaciente
{
    public class PresentadorModificarAntecedente
    {
        private IContratoModificarAntecedente _vista;
        Entidad historia;
        List<Entidad> listaRespuestas;

        public PresentadorModificarAntecedente(IContratoModificarAntecedente _vista)
        {
            this._vista = _vista;
        }

        public void LlenarDatos()
        {
            historia = (Entidad)_vista.Sesion["Historia"];
            if (!(historia == null))
            {
                listaRespuestas = FabricaComando.crearComandoConsultarAntecedente((historia as HistoriaClinica).NumeroHistoria).Ejecutar();
                
                if ((listaRespuestas[0] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta1.SelectedValue = "0";
                }
                else if ((listaRespuestas[0] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta1.SelectedValue = "1";
                }
                if ((listaRespuestas[1] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta2.SelectedValue = "0";
                }
                else if ((listaRespuestas[1] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta2.SelectedValue = "1";
                }

                if ((listaRespuestas[2] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta3.SelectedValue = "0";
                }
                else if ((listaRespuestas[2] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta3.SelectedValue = "1";
                }

                if ((listaRespuestas[3] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta4.SelectedValue = "0";
                }
                else if ((listaRespuestas[3] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta4.SelectedValue = "1";
                }
                
                if ((listaRespuestas[4] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta5.SelectedValue = "0";
                }
                else if ((listaRespuestas[4] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta5.SelectedValue = "1";
                }

                if ((listaRespuestas[5] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta6.SelectedValue = "0";
                }
                else if ((listaRespuestas[5] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta6.SelectedValue = "1";
                }

                if ((listaRespuestas[6] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta7.SelectedValue = "0";
                }
                else if ((listaRespuestas[6] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta7.SelectedValue = "1";
                }

                if ((listaRespuestas[7] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta8.SelectedValue = "0";
                }
                else if ((listaRespuestas[7] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta8.SelectedValue = "1";
                }

                if ((listaRespuestas[8] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta9.SelectedValue = "0";
                }
                else if ((listaRespuestas[8] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta9.SelectedValue = "1";
                }

                if ((listaRespuestas[9] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta10.SelectedValue = "0";
                }
                else if ((listaRespuestas[9] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta10.SelectedValue = "1";
                }
                if ((listaRespuestas[10] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta11.SelectedValue = "0";
                }
                else if ((listaRespuestas[10] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta11.SelectedValue = "1";
                }
                if ((listaRespuestas[11] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta12.SelectedValue = "0";
                }
                else if ((listaRespuestas[11] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta12.SelectedValue = "1";
                }
                if ((listaRespuestas[12] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta13.SelectedValue = "0";
                }
                else if ((listaRespuestas[12] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta13.SelectedValue = "1";
                }
                if ((listaRespuestas[13] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta14.SelectedValue = "0";
                }
                else if ((listaRespuestas[13] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta14.SelectedValue = "1";
                }
                if ((listaRespuestas[14] as Antecedente).Respuesta.Equals("no"))
                {
                    _vista.Respuesta15.SelectedValue = "0";
                }
                else if ((listaRespuestas[14] as Antecedente).Respuesta.Equals("si"))
                {
                    _vista.Respuesta15.SelectedValue = "1";
                }
                else
                    _vista.SetLabelFalla("No se han pasado datos");
                               

             // _vista.Respuesta17.Items.FindByValue((listaRespuestas[16] as Antecedente).Respuesta).Selected = true;
             // _vista.Respuesta18.Items.FindByValue((listaRespuestas[17] as Antecedente).Respuesta).Selected = true;
              

            }
            else
                _vista.SetLabelFalla("No se han pasado datos");
        }

        public void modificarAntecedente()
        {
            historia = (Entidad)_vista.Sesion["Historia"];
            if (validarDatos() && historia != null)
            {
                listaRespuestas = FabricaComando.crearComandoConsultarAntecedente((historia as HistoriaClinica).NumeroHistoria).Ejecutar();
                (listaRespuestas[0] as Antecedente).Respuesta = _vista.Respuesta1.SelectedItem.Text;
                (listaRespuestas[1] as Antecedente).Respuesta = _vista.Respuesta2.SelectedItem.Text;
                (listaRespuestas[2] as Antecedente).Respuesta = _vista.Respuesta3.SelectedItem.Text;
                (listaRespuestas[3] as Antecedente).Respuesta = _vista.Respuesta4.SelectedItem.Text;
                (listaRespuestas[4] as Antecedente).Respuesta = _vista.Respuesta5.SelectedItem.Text;
                (listaRespuestas[5] as Antecedente).Respuesta = _vista.Respuesta6.SelectedItem.Text;
                (listaRespuestas[6] as Antecedente).Respuesta = _vista.Respuesta7.SelectedItem.Text;
                (listaRespuestas[7] as Antecedente).Respuesta = _vista.Respuesta8.SelectedItem.Text;
                (listaRespuestas[8] as Antecedente).Respuesta = _vista.Respuesta9.SelectedItem.Text;
                (listaRespuestas[9] as Antecedente).Respuesta = _vista.Respuesta10.SelectedItem.Text;
                (listaRespuestas[10] as Antecedente).Respuesta = _vista.Respuesta11.SelectedItem.Text;
                (listaRespuestas[11] as Antecedente).Respuesta = _vista.Respuesta12.SelectedItem.Text;
                (listaRespuestas[12] as Antecedente).Respuesta = _vista.Respuesta13.SelectedItem.Text;
                (listaRespuestas[13] as Antecedente).Respuesta = _vista.Respuesta14.SelectedItem.Text;
                (listaRespuestas[14] as Antecedente).Respuesta = _vista.Respuesta15.SelectedItem.Text;
                (listaRespuestas[15] as Antecedente).Respuesta = _vista.Respuesta16.SelectedItem.Text;

                (listaRespuestas[16] as Antecedente).Respuesta = _vista.Respuesta17.SelectedItem.Text;
                (listaRespuestas[17] as Antecedente).Respuesta = _vista.Respuesta18.SelectedItem.Text;

                if (FabricaComando.CrearComandoModificarAntecedente(listaRespuestas).Ejecutar())
                {
                    _vista.SetLabelExito("Se modifico con exito");
                }
            }

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Presentacion.Contrato.CTratamientos;
using Uricao.Entidades.EEntidad;

namespace Uricao.Presentacion.Presentador.PTratamientos
{
    public class PresentadorModificarTratamiento
    {
        #region Atributos

        private IContratoModificarTratamiento _vista;


        #endregion Atributos

        #region Constructor

        public PresentadorModificarTratamiento(IContratoModificarTratamiento _vista) 
        {
            this._vista = _vista;
              
        }
        #endregion Constructor 

        #region Metodos

        #region GetData
       
        public List<Entidad> GetData()
        {
            List<Entidad> datos;
            try
            {
                datos = FabricaComando.CrearComandoConsultarTratamiento().Ejecutar();
            }
            catch (Exception e)
            {
                datos = null;
                //error.Text = e.Message;
            }
            return datos;

        }

        #endregion GetData

        public Entidad ModificarTratamiento(int index, int pagina, int tamano)
        {

            try
            {

                return FabricaComando.CrearComandoConsultarTratamiento().Ejecutar()[(pagina * tamano) + index];



            }
            catch (ExcepcionTratamiento ex)
            {
                //error.Text = ex.Message;
            }
            catch (Exception ex)
            {
                //error.Text = "Error" + ex.Message;

            }
            return null;
        }

        #endregion Metodos
    }
}
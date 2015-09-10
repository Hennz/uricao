using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CTratamientos;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.Presentacion.Presentador.PTratamientos
{
    public class PresentadorConsultarDetalleTratamiento
    {

        #region Atributos 

        private IContratoConsultarDetalleTratamiento _vista;


        #endregion Atributos

        #region Constructor 

        public PresentadorConsultarDetalleTratamiento(IContratoConsultarDetalleTratamiento vista)
        {
            this._vista = vista;
             
        }
        #endregion Constructor

        #region Metodos

        //SE LE PASA EL ID DEL TRATAMIENTO DE LA VARIABLE DE SESION
        public List<Entidad> GetData(int id)
        {
            List<Entidad> datos;
            try
            {
               // datos = new LogicaTratamiento().ConsultarTratamientoAsociado(tratamiento.Id);
                datos = FabricaComando.CrearComandoConsultarTratamientoAsociado(id).Ejecutar();
            }
            catch (Exception e)
            {
                datos = null;
               // error.Text = e.Message;
            }
            return datos;

        }

        //SE LE PASA EL TRATAMIENTO (OBJETO) DE LA VARIABLE DE SESION

        public List<Entidad> GetDataImplemento(Entidad tratamiento)
        {
            List<Entidad> datos;
            try
            {
                datos = FabricaComando.CrearComandoConsultarListaImplementos(tratamiento).Ejecutar();
            }
            catch (Exception e)
            {
                datos = null;
                //error.Text = e.Message;
            }
            return datos;

        }

        public Entidad ConsultarTratamiento(int index, int pagina, int tamano, int id)
        {

            try
            {

                return FabricaComando.CrearComandoConsultarTratamientoAsociado(id).Ejecutar()[(pagina * tamano) + index];
            
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
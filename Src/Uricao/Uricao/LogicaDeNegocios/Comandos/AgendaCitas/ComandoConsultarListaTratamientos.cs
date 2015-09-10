using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.AgendaCitas
{
    public class ComandoConsultarListaTratamientos : Comando<List<Entidad>>
    {
        #region Constructor
        public ComandoConsultarListaTratamientos()
        {

        }
        #endregion


        #region Metodos
        public override List<Entidad> Ejecutar()
        {
            /*
            ////////////////////////////////////////////////////// Arreglar esto cuando esten los comandos de tratamiento///////////////////////////////////////////
            //Uricao.LogicaDeNegocios.Clases.LNTratamientos.LogicaTratamiento miLogicaTratamiento = new Uricao.LogicaDeNegocios.Clases.LNTratamientos.LogicaTratamiento();
            List<Entidad> listaTratamiento = new List<Entidad>();
            //listaTratamiento = miLogicaTratamiento.ConsultarTratamiento();
            return listaTratamiento*/

            return null;
             
        }
        #endregion


    }
}
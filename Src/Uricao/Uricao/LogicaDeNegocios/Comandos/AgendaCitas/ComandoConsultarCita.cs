using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos
{
    public class ComandoConsultarCita : Comando<List<Entidad>>
    {

        public ComandoConsultarCita()
        { 
        
        }


        public override List<Entidad> Ejecutar()
        {
            return null;
        }
    }
}
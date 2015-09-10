using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos
{
    public abstract class Comando<T>
    {

        protected Entidad entidad;

        public Entidad Entidad
        {
            get { return entidad; }
            set { entidad = value; }
        }

                
         public abstract T Ejecutar();

    }
}
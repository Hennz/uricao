using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EHistoriaPaciente
{
    public class Antecedente : Entidad 
    {
        private int idAntecedente;
        private string _Respuesta;

        #region Constructor(es)

        /// <summary>
        /// constructor vacio de la clase Antecedente
        /// </summary>
        public Antecedente() 
        {

        }
       

        #endregion

        #region Implementación de los Getter and Setter

        public string Respuesta
        { 
            get { return _Respuesta; } 
            set { this._Respuesta = value; }
        }

        public int IdAntecedente
        {
            get { return idAntecedente; }
            set { idAntecedente = value; }
        }

        #endregion
    }
}
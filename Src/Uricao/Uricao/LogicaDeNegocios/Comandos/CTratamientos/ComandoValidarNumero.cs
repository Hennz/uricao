using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoValidarNumero : Comando<bool>
    {
        string _numberText;



        public ComandoValidarNumero(string numberText)
        {

            this._numberText = numberText;
        }


        public override bool Ejecutar()
        {
            int Result = 0;
            bool numberResult = false;
            if (int.TryParse(this._numberText, out Result))
            {
                numberResult = true;
            }
            return numberResult;
        }
    }
}
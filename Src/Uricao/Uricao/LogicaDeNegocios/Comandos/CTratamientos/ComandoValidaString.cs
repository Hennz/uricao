using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoValidaString : Comando<bool>
    {
        string _cadena;



        public ComandoValidaString(string cadena)
        {

            this._cadena = cadena;
        }


        public override bool Ejecutar()
        {
            try
            {
                if (this._cadena.Length > 120) return false;
                return true;
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Cadena vacia", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error", e);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;


namespace Uricao.LogicaDeNegocios.Comandos.Implementos
{

    public class ComandoAgregarImplemento : Comando<bool>
    {
        private List<Entidad> _implemento;

        public ComandoAgregarImplemento(List<Entidad> implemento)
        {
            this._implemento = implemento;
        }

        public override bool Ejecutar()
        {
            try
            {
                bool implementoAgregado = false;

                for (int i = 0; i < _implemento.Count; i++)
                {
                    implementoAgregado = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOImplemento().SqlAgregarImplemento(this._implemento[i]);
                    if (implementoAgregado == false)
                    {
                        break;
                    }
                }

                return implementoAgregado;
            }
            catch (ExcepcionImplemento e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionImplemento("Implementos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionImplemento("Error en la consulta de los Implementos", e);
            }

        }

    }

}
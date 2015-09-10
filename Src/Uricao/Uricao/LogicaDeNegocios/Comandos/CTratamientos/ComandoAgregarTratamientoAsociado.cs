using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoAgregarTratamientoAsociado : Comando<bool>
    {
        List<Entidad> _listaTratamiento;
        Entidad _tratamientoPrimario;

        public ComandoAgregarTratamientoAsociado(Entidad tratamientoPrimario, List<Entidad> listaTratamiento)
        {
            this._listaTratamiento = listaTratamiento;
            this._tratamientoPrimario = tratamientoPrimario;
        }



        public override bool Ejecutar()
        {
            try
            {
                bool tratamientosAgregados = true;

                for (int i = 0; i < this._listaTratamiento.Count; i++)
                {
                    tratamientosAgregados = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOTratamiento().SqlAgregarTratamientoAsociado(this._tratamientoPrimario, this._listaTratamiento[i]);
                    if (tratamientosAgregados == false)
                    {
                        return false;
                    }
                }

                return tratamientosAgregados;
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("El parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en la consulta de los Tratamientos", e);
            }

        }

    }
}
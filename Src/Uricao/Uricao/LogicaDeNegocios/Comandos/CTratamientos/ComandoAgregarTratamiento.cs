using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.AccesoDeDatos.FabricaDAOS;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Comandos.CTratamientos
{
    public class ComandoAgregarTratamiento : Comando<bool>
    {
        Entidad _tratamiento;
        List<Entidad> _listaImplementos;
        List<Entidad> _listaTratamiento;

        public ComandoAgregarTratamiento(Entidad tratamientoPrimario, List<Entidad> listaImplementos, List<Entidad> listaTratamiento)
        {
            this._tratamiento = tratamientoPrimario;
            this._listaTratamiento = listaTratamiento;
            this._listaImplementos = listaImplementos;
        }

        public override bool Ejecutar()
        {
            try
            {
                bool TratamientoAgregado = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOTratamiento().SqlAgregarTratamiento(this._tratamiento);
                int IdTratamientoAgregado = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOTratamiento().SqlIdTratmientoNuevo();
                (this._tratamiento as Tratamiento).Id = Convert.ToInt16(IdTratamientoAgregado);
                bool tratamientoAsociado = FabricaComando.CrearComandoAgregarTratamientoAsociado(this._tratamiento, this._listaTratamiento).Ejecutar();

                for (int i = 0; i < this._listaImplementos.Count; i++)
                {
                    (this._listaImplementos[i] as Implemento).IdTratamiento = Convert.ToInt16(IdTratamientoAgregado);
                }

                bool ImplementosAgregados = FabricaComando.CrearComandoAgregarImplemento(this._listaImplementos).Ejecutar();

                return true;
            }
            catch (ExcepcionTratamiento e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw new ExcepcionTratamiento("Parametros invalidos", e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionTratamiento("Tratamientos vacios", e);
            }
            catch (Exception e)
            {
                throw new ExcepcionTratamiento("Error en agregar Tratamiento", e);
            }

        }


    }
}
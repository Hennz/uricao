using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Presentacion.Contrato.CRolesUsuarios;

namespace Uricao.Presentacion.Presentador.PRolesUsuarios
{
    public class PresentadorConsultarUsuario
    {
        #region Atributos

        private IContratoConsultarUsuario _vista;
        private List<Entidad> _listaUsuarios;

        #endregion Atributos

        /*public Comando<List<Entidad>> ConsultarUsuario()
        {
            return FabricaComando.CrearComandoConsultarUsuario();
        }*/

        #region Constructor
        public PresentadorConsultarUsuario(IContratoConsultarUsuario vista)
        {
            _vista = vista;
        }
        #endregion Constructor

        #region Metodos

        public List<Entidad> CargarUsuarios(string parametro, int seleccion)
        {
            if (parametro == "Todo")
            {
                _listaUsuarios = FabricaComando.CrearComandoConsultarUsuario().Ejecutar();
            }
            else
            {
               // _listaUsuarios = FabricaComando.CrearComandoConsultarUsuarioParametrizado(parametro, seleccion).Ejecutar();
            }

            return _listaUsuarios;
        }

        #endregion Metodos

    }
}
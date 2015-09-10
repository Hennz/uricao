using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CTratamientos;
using Uricao.Entidades.EEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.ETratamientos;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Entidades.FabricasEntidad;

namespace Uricao.Presentacion.Presentador.PTratamientos
{
    public class PresentadorEliminarTratamiento
    {
        #region Atributos

            private IContratoEliminarTratamiento _vista;
            private int _index = 0;
            private List<Entidad> _miLista = new List<Entidad>();

        #endregion Atributos


        #region Constructor.

            public PresentadorEliminarTratamiento(IContratoEliminarTratamiento _vista)
            {
                this._vista = _vista;

            }

        #endregion Constructor.

        #region Metodos


            #region GetData



            public Entidad GetDataId()
            {
                Entidad datos;
                try
                {
                    datos = FabricaComando.CrearComandoConsultarXIdTratamiento(Convert.ToInt32(this._vista.CampoBusqueda.Text)).Ejecutar();
                }
                catch (Exception e)
                {
                    datos = null;
                    this._vista.SetLabelFalla(e.Message);
                }
                return datos;

            }

            public List<Entidad> GetDataNombre()
            {
                List<Entidad> datos;
                try
                {
                    datos = FabricaComando.CrearomandoConsultarXNombreTratamiento(this._vista.CampoBusqueda.Text).Ejecutar();
                }
                catch (Exception e)
                {
                    datos = null;
                    this._vista.SetLabelFalla(e.Message);
                }
                return datos;

            }

            public List<Entidad> GetDataEstado()
            {
                List<Entidad> datos;
                try
                {
                    datos = FabricaComando.CrearComandoConsultarXEstatusTratamiento(this._vista.CampoBusqueda.Text).Ejecutar();
                }
                catch (Exception e)
                {
                    datos = null;
                    this._vista.SetLabelFalla(e.Message);
                }
                return datos;

            }

            public List<Entidad> GetData()
            {
                List<Entidad> datos;
                try
                {
                    datos = FabricaComando.CrearComandoConsultarTratamiento().Ejecutar();
                }
                catch (Exception e)
                {
                    datos = null;
                    this._vista.SetLabelFalla(e.Message);
                }
                return datos;

            }



            #endregion GetData


            public void CargaTodos()
            {
                try
                {
                    List<Entidad> datos = GetData();

                    this._vista.GridTratamiento.DataSource = datos;
                    if (datos != null)
                    {
                        this._vista.GridTratamiento.DataBind();
                    }
                    else { this._vista.SetLabelFalla("No se pudo cargar los datos"); }
                }
                catch (Exception ex)
                {
                    this._vista.SetLabelFalla(ex.Message);
                }
            }

            public void CargaId()
            {
                try
                {
                    List<Entidad> auxiliar = new List<Entidad>();
                    auxiliar.Add(GetDataId());

                    this._vista.GridTratamiento.DataSource = auxiliar;
                    if (auxiliar != null)
                    {
                        this._vista.GridTratamiento.DataBind();
                    }
                    else { this._vista.SetLabelFalla("No se pudo cargar los datos"); }
                }
                catch (Exception)
                {
                    this._vista.SetLabelFalla("Error al cargar la data");
                }
            }

            public void CargaNombre()
            {
                try
                {
                    List<Entidad> datos = GetDataNombre();
                    this._vista.GridTratamiento.DataSource = datos;
                    if (datos != null)
                    {
                        this._vista.GridTratamiento.DataBind();
                    }
                    else
                    { //error.Text = "No se pueden mostrar los datos"; 
                    }
                }
                catch (Exception)
                {
                    this._vista.SetLabelFalla("Error al cargar la data");
                }
            }

            public void CargaEstado()
            {

                try
                {
                    List<Entidad> datos = GetDataEstado();

                    this._vista.GridTratamiento.DataSource = datos;
                    if (datos != null)
                    {
                        this._vista.GridTratamiento.DataBind();
                    }
                    else
                    {
                        this._vista.SetLabelFalla("No se pueden mostrar los Datos");
                    }
                }
                catch (Exception)
                {
                    this._vista.SetLabelFalla("Error al cargar la data");
                }
            }


        public bool CambiarEstadoTratamiento(int index , int pagina, int tamano, int parametro)
        {

            try
            {
                Entidad trat = FabricaEntidad.NuevoTratamiento();
                this._index = pagina * tamano;
                switch (parametro)
                {

                    case -1:

                         trat = FabricaComando.CrearComandoConsultarTratamiento().Ejecutar()[this._index + index];
                       
                    break;


                    case 0:

                         trat = FabricaComando.CrearComandoConsultarXIdTratamiento(Convert.ToInt32(this._vista.CampoBusqueda.Text)).Ejecutar();

                    break;

                    case 1 :

                        trat = FabricaComando.CrearComandoConsultarXEstatusTratamiento(this._vista.CampoBusqueda.Text).Ejecutar()[this._index + index];
                    
                    break;

                    case 2:

                        trat = FabricaComando.CrearomandoConsultarXNombreTratamiento(this._vista.CampoBusqueda.Text).Ejecutar()[this._index + index];
                    
                    break;
                }

                (trat as Tratamiento).CambiarEstado(trat);

                if (FabricaComando.CrearComandoEliminarTratamiento(trat).Ejecutar())
                {

                    return true;
                }

            }
            catch (ExcepcionTratamiento ex)
            {
                this._vista.SetLabelFalla(ex.Message);
            }
            catch (Exception ex)
            {
                this._vista.SetLabelFalla(ex.Message);

            }
            return false;
        }

        #endregion Metodos

    }
}
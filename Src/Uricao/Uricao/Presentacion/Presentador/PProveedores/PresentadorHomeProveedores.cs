using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Presentacion.Contrato.CProductosInventario;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using System.Web.UI.WebControls;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.Entidades.FabricasEntidad;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EProductosInventario;
using System.Data;
using Uricao.Presentacion.Contrato.CProveedores;

namespace Uricao.Presentacion.Presentador.PProveedores
{
    public class PresentadorHomeProveedores
    {
        List<Entidad> proveedores;       
        Entidad proveedor = FabricaEntidad.NuevoProveedor();
        private IContratoHomeProveedores _vista;

        public PresentadorHomeProveedores(IContratoHomeProveedores lavista)
        {
            this._vista = lavista;
        }
        //si
        public DataTable cargarTabla()
        {
            
            //proveedores.Clear();
            proveedores = FabricaComando.CrearComandoConsultarTodosProveedores().Ejecutar();
            DataTable table = new DataTable();
            table.Columns.Add("Rif", typeof(string));
            table.Columns.Add("Nombre", typeof(string));

            foreach (Entidad Eproveedor in proveedores)
            {
                if ((Eproveedor as Proveedor).Estado != "desactivado")
                    table.Rows.Add((Eproveedor as Proveedor).Rif, (Eproveedor as Proveedor).Nombre);
            }
            return table;
        }
        //si
        public DataTable cargarTablaPorNombre()
        {
            String nombre=_vista.GetNombre().Text.ToString();
            proveedor = FabricaComando.CrearComandoConsultarProveedoresPorNombre(nombre).Ejecutar();
            DataTable table = new DataTable();
            table.Columns.Add("Rif", typeof(string));
            table.Columns.Add("Nombre", typeof(string));
            if (proveedor != null)
            {
                table.Rows.Add((proveedor as Proveedor).Rif, (proveedor as Proveedor).Nombre);

                //proveedores.Clear();
                proveedores.Add(proveedor);
            }
            return table;
        }
        //si
        public DataTable cargarTablaPorRif()
        {
            proveedor = FabricaComando.CrearComandoConsultarProveedoresPorRif(_vista.GetTextBoxRif().Text.ToString()).Ejecutar();
            DataTable table = new DataTable();
            table.Columns.Add("Rif", typeof(string));
            table.Columns.Add("Nombre", typeof(string));

            if (proveedor != null)
            {
                table.Rows.Add((proveedor as Proveedor).Rif, (proveedor as Proveedor).Nombre);
                //proveedores.Clear();
                proveedores.Add(proveedor);
            }
            return table;
        }

        public Entidad ObtenerProvedoresXNombre()
        {
            proveedor = FabricaComando.CrearComandoConsultarProveedoresPorNombre(_vista.NombreP()).Ejecutar();
            return proveedor;
        }

        public Entidad ObtenerProvedoresXRif()
        {
            proveedor = FabricaComando.CrearComandoConsultarProveedoresPorRif(_vista.RifP()).Ejecutar();
            return proveedor;
        }

        public List<Entidad> ObtenerTodosProveedores()
        {
            proveedores = FabricaComando.CrearComandoConsultarTodosProveedores().Ejecutar();
            return proveedores;
        }
    }
}
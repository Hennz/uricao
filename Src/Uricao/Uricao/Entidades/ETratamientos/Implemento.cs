using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EProductosInventario;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.ETratamientos
{
    public class Implemento : Entidad
    {
        private Int16 _IdImplemento;
        private Int16 _IdTratamiento;
        private Int16 _IdProducto;
        private Int16 _Prioridad;
        private String _TipoProducto;
        private Int16 _Cantidad;
        private String _PrioridadS;
        private List<Producto> _ProductoAsociado;

        public Implemento() { }

        public Implemento(Int16 idTratamiento, Int16 idProducto, Int16 prioridad, String tipoProducto, Int16 cantidad, List<Producto> productoAsociado)
        {
            this._IdTratamiento = idTratamiento;
            this._IdProducto = idProducto;
            this._Prioridad = prioridad;
            if (_Prioridad == 1)
                _PrioridadS = "Alta";
            else if (_Prioridad == 2)
                _PrioridadS = "Baja";
            this._TipoProducto = tipoProducto;
            this._Cantidad = cantidad;
            this._ProductoAsociado = productoAsociado;
        }
        #region GetSet

        public Int16 IdImplemento { get { return _IdImplemento; } set { this._IdImplemento = value; } }

        public Int16 IdProducto { get { return _IdProducto; } set { this._IdProducto = value; } }

        public Int16 IdTratamiento { get { return _IdTratamiento; } set { this._IdTratamiento = value; } }

        public Int16 Prioridad
        {
            get { return _Prioridad; }
            set
            {
                this._Prioridad = value; if (_Prioridad == 1)
                    _PrioridadS = "Alta";
                else if (_Prioridad == 2)
                    _PrioridadS = "Baja";
            }
        }

        public String TipoProducto { get { return _TipoProducto; } set { this._TipoProducto = value; } }

        public Int16 Cantidad { get { return _Cantidad; } set { this._Cantidad = value; } }

        public List<Producto> TratamientoAsociado { get { return _ProductoAsociado; } set { this._ProductoAsociado = value; } }

        public String PrioridadS { get { return _PrioridadS; } set { this._PrioridadS = value; } }

        #endregion GetSet


    }
}
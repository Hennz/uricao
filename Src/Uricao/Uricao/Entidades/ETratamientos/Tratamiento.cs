using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.ETratamientos
{
    public class Tratamiento: Entidad
    {
        private Int16 _Id;
        private String _Nombre;
        private Int16 _Duracion;
        private Int16 _Costo;
        private String _Imagen;
        private String _Descripcion;
        private String _Explicacion;
        private String _Estado;
        private Boolean _Estate;
        private List<Tratamiento> _TratamientoAsociado;
        private List<Implemento> _ProductoAsociado;

        public Tratamiento() { }

        public Tratamiento(Int16 Id, String Nombre, Int16 Duracion, Int16 Costo, String Descripcion, String Explicacion, String Estado)
        {
            this._Id = Id;
            this._Nombre = Nombre;
            this._Duracion = Duracion;
            this._Costo = Costo;
            this._Descripcion = Descripcion;
            this._Explicacion = Explicacion;
            this._Estado = Estado;
            if (Estado.Contains("Activo"))
                _Estate = true;
            else if (Estado.Contains("Inactivo"))
                _Estate = false;
        }

        #region GetSet

        public Int16 Id { get { return _Id; } set { this._Id = value; } }

        public String Nombre { get { return _Nombre; } set { this._Nombre = value; } }

        public Int16 Duracion { get { return _Duracion; } set { this._Duracion = value; } }

        public Int16 Costo { get { return _Costo; } set { this._Costo = value; } }

        public String Imagen { get { return _Imagen; } set { this._Imagen = value; } }

        public String Descripcion { get { return _Descripcion; } set { this._Descripcion = value; } }

        public String Explicacion { get { return _Explicacion; } set { this._Explicacion = value; } }

        public String Estado
        {
            get { return _Estado; }
            set
            {
                this._Estado = value;
                
                if (Estado.Contains("Activo"))
                    _Estate = true;
                else if (Estado.Contains("Inactivo"))
                    _Estate = false; 
            }
        }

        public Boolean Estate { get { return _Estate; } set { this._Estate = value; } }

        public List<Tratamiento> TratamientoAsociado { get { return _TratamientoAsociado; } set { this._TratamientoAsociado = value; } }

        public List<Implemento> ProductoAsociado { get { return _ProductoAsociado; } set { this._ProductoAsociado = value; } }

        #endregion GetSet

        public void CambiarEstado(Entidad miTratamiento)
        {
            if ((miTratamiento as Tratamiento).Estado.Contains("Activo"))
                (miTratamiento as Tratamiento).Estado = "Inactivo";
            else if ((miTratamiento as Tratamiento).Estado.Contains("Inactivo"))
                (miTratamiento as Tratamiento).Estado = "Activo";
        }

    }
}
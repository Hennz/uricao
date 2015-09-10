using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.ECuentasPorCobrar
{
    public class CuentaPorCobrar : Entidad
    {

        private int _id;
        private string _estado;
        private string _primernombre;
        private string _segundonombre;
        private string _primerapellido;
        private string _segundoapellido;
        private string _cedula;
        private string _tipoCedula;



        public CuentaPorCobrar()
        {
        }


        public CuentaPorCobrar(int id, string estado, string primernombre, string segundonombre, string primerapellido, string segundoapellido, string cedula, string tipocedula)
        {
            this._id = id;
            this._estado = estado;
            this._primerapellido = primerapellido;
            this._segundoapellido = segundoapellido;
            this._primernombre = primernombre;
            this._segundonombre = segundonombre;
            this._cedula = cedula;
            this._tipoCedula = tipocedula;

        }

        public string TipoCedula
        {
            get { return _tipoCedula; }
            set { _tipoCedula = value; }
        }

        public int Id
        {
            get { return _id; }
            set { this._id = value; }
        }


        public string Estado
        {
            get { return _estado; }
            set { this._estado = value; }
        }

        public string PrimerNombre
        {
            get { return _primernombre; }
            set { this._primernombre = value; }
        }

        public string Segundonombre
        {
            get { return _segundonombre; }
            set { _segundonombre = value; }
        }

        public string Primerapellido
        {
            get { return _primerapellido; }
            set { _primerapellido = value; }
        }

        public string Cedula
        {
            get { return _cedula; }
            set { this._cedula = value; }
        }

        public string Segundoapellido
        {
            get { return _segundoapellido; }
            set { _segundoapellido = value; }
        }
    }
}
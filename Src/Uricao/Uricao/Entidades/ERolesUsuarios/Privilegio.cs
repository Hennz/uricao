using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uricao.Entidades.ERolesUsuarios
{
    public class Privilegio
    {
        private int idPrivilegio;
        private string nombrePrivilegio;
        private Boolean estado;

        public string NombrePrivilegio
        {
            get { return nombrePrivilegio; }
            set { nombrePrivilegio = value; }
        }
        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string ConsultarPrivilegio()
        {
            return "";
        }
        public int IdPrivilegio
        {
            get { return idPrivilegio; }
            set { idPrivilegio = value; }
        }
        public Privilegio AgregarPrivilegio(string NombrePrivilegio)
        {
            Privilegio privilegioRetorno=new Privilegio();
            return privilegioRetorno ;
        }
        public List<Privilegio> ActivarDesactivarPrivilegio(List<Privilegio> ListaPrivilegios){

            return ListaPrivilegios;
        }
        public Privilegio ModificarPrivilegio(Privilegio PrivilegioModificable)
        {
            return PrivilegioModificable;
        }
    }
}
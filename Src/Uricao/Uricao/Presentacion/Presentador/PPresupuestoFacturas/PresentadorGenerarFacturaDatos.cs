using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Contrato.CPresupuestoFacturas;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.LogicaDeNegocios.Comandos;
using Uricao.Entidades.EEntidad;
using Uricao.Entidades.FabricasEntidad;
using Uricao.LogicaDeNegocios.Fabricas;
using Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.ERolesUsuarios;

namespace Uricao.Presentacion.Presentador.PPresupuestoFacturas
{
    public class PresentadorGenerarFacturaDatos
    {
        #region Atributos

        private IContratoGenerarFacturaDatos _vista;
        private Comando<List<Entidad>> _miComandoFactura;
        private Comando<Entidad> _miComandoFacturaEntidad;
        
        private List<Entidad> listaUsuario;
        DAOUsuario miDaoUsuario = new DAOUsuario();
        private Comando<int> _miComando;
        private int _idUsuario;
        private Comando<int> _miComandoIdUsuario;
        private int _idDirUsuario;

        #endregion

        #region Constructor

        public PresentadorGenerarFacturaDatos(IContratoGenerarFacturaDatos vista)
        {
            this._vista = vista;
        }

        #endregion

        #region Métodos

        public string[] AgarrarValoresCamposDropDowns()
        {

            //1- explode (split) de los datos referentes al dropdownlist de: nombre del que paga la factura

            char[] delimiterChars = { '-' };
            char[] caracteresLimpiar = { ' ' };

            string[] lineaSeparadaDropUsuario1 = _vista.ADNombre_Persona.SelectedValue.Split(delimiterChars);

            //[0] = V, E, J     //[1] = cedula      //[2] = nombre1 y apellido1

            string tipoIdentRazon = lineaSeparadaDropUsuario1[0];
            string identRazon = lineaSeparadaDropUsuario1[1];
            //string nombre_Persona = lineaSeparadaDropUsuario1[2];

            //limpieza de caracteres blancos al principio y al final:

            tipoIdentRazon = tipoIdentRazon.TrimStart(caracteresLimpiar);
            tipoIdentRazon = tipoIdentRazon.TrimEnd(caracteresLimpiar);

            identRazon = identRazon.TrimStart(caracteresLimpiar);
            identRazon = identRazon.TrimEnd(caracteresLimpiar);

            //arreglando los espacios entre: "nombre1   nombre2      apellido1       apellido2"

            string nombre_Persona = string.Join(" ", lineaSeparadaDropUsuario1[2].Split(caracteresLimpiar, StringSplitOptions.RemoveEmptyEntries));

            nombre_Persona = nombre_Persona.TrimStart(caracteresLimpiar);
            nombre_Persona = nombre_Persona.TrimEnd(caracteresLimpiar);


            //2- explode (split) de los datos referentes al dropdownlist de: nombre del Paciente.

            string[] lineaSeparadaDropUsuario2 = _vista.ADPaciente.SelectedValue.Split(delimiterChars);

            //[0] = V, E, J     //[1] = cedula      //[2] = nombre y apellidos completo

            string tipoIdentRazon2 = lineaSeparadaDropUsuario2[0];
            string identRazon2 = lineaSeparadaDropUsuario2[1];
            //string nombre_Persona2 = lineaSeparadaDropUsuario2[2];

            //limpieza de caracteres blancos al principio y al final:

            tipoIdentRazon2 = tipoIdentRazon2.TrimStart(caracteresLimpiar);
            tipoIdentRazon2 = tipoIdentRazon2.TrimEnd(caracteresLimpiar);

            identRazon2 = identRazon2.TrimStart(caracteresLimpiar);
            identRazon2 = identRazon2.TrimEnd(caracteresLimpiar);

            //arreglando los espacios entre: "nombre1   nombre2      apellido1       apellido2"

            string nombre_Persona2 = string.Join(" ", lineaSeparadaDropUsuario2[2].Split(caracteresLimpiar, StringSplitOptions.RemoveEmptyEntries));

            nombre_Persona2 = nombre_Persona2.TrimStart(caracteresLimpiar);
            nombre_Persona2 = nombre_Persona2.TrimEnd(caracteresLimpiar);


            return new[] { tipoIdentRazon, identRazon, nombre_Persona, tipoIdentRazon2, identRazon2, nombre_Persona2 };

        }



        public Factura AgarrarValoresCampos()
        {

            //1- explode (split) de los datos referentes a los dropdownlists
            string[] lineaNombreFactura_paciente = AgarrarValoresCamposDropDowns();

            //[0] = V, E, J     //[1] = cedula      //[2] = nombre y apellidos completo
            //[3] = V, E, J     //[4] = cedula      //[5] = nombre y apellidos completo

            //3- Construir el objeto FACTURA:
            _miComandoIdUsuario = FabricaComando.CrearComandoRegresarIdUsuario(lineaNombreFactura_paciente[4]);
            _idUsuario = _miComandoIdUsuario.Ejecutar();
            _miComando = FabricaComando.CrearComandoRegresaIdDireccionUsuario(_idUsuario);
            _idDirUsuario = _miComando.Ejecutar();

            return new Factura(0, 0.0, true, lineaNombreFactura_paciente[4], lineaNombreFactura_paciente[3], lineaNombreFactura_paciente[1],
                lineaNombreFactura_paciente[0], lineaNombreFactura_paciente[2], _idDirUsuario);                         
        }


        public Boolean DatosFueronIntroducidos()
        {
            Boolean regreso = true;
            if (_vista.ADNombre_Persona.SelectedValue != "0")
            {
                _vista.ALNombreRazonError.Visible = true;
                _vista.ALNombreRazonError.Text = "* Dato No Introducido";
                regreso = false;
            }
            if (_vista.ADPaciente.SelectedValue != "0")
            {
                _vista.ALCIPacienteError.Visible = true;
                _vista.ALCIPacienteError.Text = "* Dato no Introducido";
                regreso = false;
            }

            return regreso;
        }

        public void CargarIdUsuario(DropDownList miDropUsuario)
        {

            listaUsuario = miDaoUsuario.ConsultarUsuarioTodo();


            for (int i = 0; i < listaUsuario.Count; i++)
            {
                //Queda:
                //[0] = V, E, J     //[1] = cedula      //[2] = nombre y apellidos completo

                miDropUsuario.Items.Add((listaUsuario.ElementAt(i) as Usuario).TipoIdentificacion + " - " + (listaUsuario.ElementAt(i) as Usuario).Identificacion + " - "
                    + (listaUsuario.ElementAt(i) as Usuario).PrimerNombre + (listaUsuario.ElementAt(i) as Usuario).SegundoNombre + (listaUsuario.ElementAt(i) as Usuario).PrimerApellido + (listaUsuario.ElementAt(i) as Usuario).SegundoApellido);

            }

           

        }

        public void RedireccionarG()
        {
            //Pasar el objeto Session:
            _vista.Sesion["la_Factura"] = AgarrarValoresCampos();

            
            _vista.Redireccionar("GenerarFacturaDetalle.aspx");

        }

        public void aBBotonContinuar_Click(object sender, EventArgs e)
        {
            _vista.ALNombreRazonError.Visible = false;
           _vista.ALCIPacienteError.Visible = false;

            //Factura la_factura = new Factura(0,0.0,false,aTPaciente.Text,aTIDentificacion.Text,aTNombre_Persona.Text,1);
            /*esta forma es como se pasa un objeto a otra pagina, hay que ponerlo exactamente como aparece,
            Session["el nombre del atributo que le quieras dar"] = el objeto que quieras pasar a la otra pagina.
            Cuando estes en la pagina destino, lo que tienes que hacer es volver a poner Session["y el nombre que le pusistes"] y darle un casteo*/

            try
            {
                RedireccionarG();

            }
            catch (HttpRequestValidationException ee)
            {
                //throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", ee);
            }
            catch (Exception ee)
            {
                //throw new ExceptionPresupuestoFactura("Error general ocurrido en tiempo de ejecucion ", ee);
            }

        }
        #endregion

    }
}
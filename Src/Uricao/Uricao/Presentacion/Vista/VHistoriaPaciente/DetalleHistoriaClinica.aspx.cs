using System;
using Uricao.Presentacion.Contrato.CHistoriaPaciente;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Uricao.Presentacion.Presentador.PHistoriaPaciente;

namespace Uricao.Presentacion.Vista.VHistoriaPaciente
{
    public partial class DetalleHistoriaClinica : System.Web.UI.Page, IContratoDetalleHistoriaClinica
    {
        private PresentadorDetalleHistoriaClinica _presentador;

        public  DetalleHistoriaClinica()
        {
            _presentador = new PresentadorDetalleHistoriaClinica(this);
        }
        
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                _presentador.PintarDatos(); 
            }
            
        }

        public HttpSessionState Sesion
        {
            get { return Session; }
        }
        
        public Label Nombre
        {
            get { return nombre; }
            set { nombre= value; }
        }

        public Label Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public Label Edad
        {
            get { return edad; }
            set { edad = value; }
        }
        public Label Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public Label Ide 
        {
            get { return ide; }
            set { ide = value; }
        }

        public Label Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public Label Nace 
        {
            get { return nace; }
            set { nace = value; }
        }
        public Label Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public Label Obs 
        {
            get { return obs; }
            set { obs = value; }
        }

        public Label P1
        {
            get { return p1; }
            set { p1 = value; }
        }

        public Label P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        public Label P3
        {
            get { return p3; }
            set { p3 = value; }
        }
        public Label P4
        {
            get { return p4; }
            set { p4 = value; }
        }
        public Label P5
        {
            get { return p5; }
            set { p5 = value; }
        }

        public Label P6
        {
            get { return p6; }
            set { p6 = value; }
        }
        public Label P7
        {
            get { return p7; }
            set { p7 = value; }
        }
        public Label P8
        {
            get { return p8; }
            set { p8 = value; }
        }
        public Label P9
        {
            get { return p9; }
            set { p9 = value; }
        }
        public Label P10
        {
            get { return p10; }
            set { p10 = value; }
        }
        public Label P11
        {
            get { return p11; }
            set { p11 = value; }
        }
        public Label P12
        {
            get { return p12; }
            set { p12 = value; }
        }
        public Label P13
        {
            get { return p13; }
            set { p13 = value; }
        }
        public Label P14
        {
            get { return p14; }
            set { p14 = value; }
        }
        public Label P15
        {
            get { return p15; }
            set { p15 = value; }
        }
        public Label P16
        {
            get { return p16; }
            set { p16 = value; }
        }
        public Label P17
        {
            get { return p17; }
            set { p17 = value; }
        }
        public Label P18
        {
            get { return p18; }
            set { p18 = value; }
        }

        public void SetLabelFalla(String text)
        {
            falla.Text = text;
            falla.Visible = true;
        }

        public void SetLabelExito(String text)
        {
            Exito.Text = text;
            Exito.Visible = true;
        }


        protected void defaultButton_Click(object sender, EventArgs e)
        {

        }
    }
}
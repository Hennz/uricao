<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleAgregarCita.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PAgendaCitas.DetalleAgregarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    $(function () {
        var pickerOpts = { dateFormat: "dd/mm/yy" };
        $("#datepicker").datepicker(pickerOpts);
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="superior">
    <h2>
        Detalle de la Cita 
    </h2>
    </div>
    <div class="texto-label" style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
<asp:Label ID="mensajeDeTransaccion" runat="server" Text="Text" ForeColor="Red" Visible="False">Mensaje</asp:Label></div>
    <div  style="float:left;">
           <fieldset style="width:740px; height:250px; margin-left:0px auto 0px auto;">
        <legend>Agregar Cita</legend>        
           <table style="margin:0px auto 0px auto;" border="0" cellspacing="10px" cellpadding="0px" align="center">
            <tr>
                <td>
                    <asp:Label ID="labelMedico" runat="server" Text="Label">Medico:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="labelNombreMedico" runat="server" Text="Label">Carlo</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelFecha" runat="server" Text="Label">Fecha:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="labelFechaCita" runat="server" Text="Label">01-12-12</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelHoraInicio" runat="server" Text="Label">Hora Inicio:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="labelHoraInicio_Campo" runat="server" Text="Label">01-12-12</asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="labelHoraFin" runat="server" Text="Label">Hora Fin:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="labelHoraFin_Campo" runat="server" Text="Label">01-12-12</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelTratamiento" runat="server" Text="Label">Tratamiento:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="labelNombreTratamiento" runat="server" Text="Label">Primera Cita</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelCiPaciente" runat="server" Text="Label">Cedula de paciente:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="aTBCiPaciente" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td colspan="6"  style="text-align:center">
                <asp:Button ID="aBAceptar" runat="server" Text="Aceptar" CssClass="button" 
                        onclick="aBAceptar_Click"/>
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>

</asp:Content>

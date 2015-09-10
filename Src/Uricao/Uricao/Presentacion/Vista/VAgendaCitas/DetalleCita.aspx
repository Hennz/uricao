<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleCita.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PAgendaCitas.WebForm1" %>
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
        Detalle de la Cita a Modificar
    </h2>
    </div>
    <div class="texto-label" style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
    <asp:Label ID="MensajeDeTransaccion" runat="server" Text="Text" ForeColor="Red" Visible="False">Mensaje</asp:Label></div>
    <div  style="float:left;">
        <fieldset style="width:740px; height:210px; margin-left:0px auto 0px auto;">
        <legend>Modificar Cita</legend>        
            <table style="margin:0px auto 0px auto;" border="0" cellspacing="10px" cellpadding="0px" align="center">
            <tr>
                <td>
                    <asp:Label ID="LabelMedico" runat="server" Text="Label">Medico:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelNombreMedico" runat="server" Text="Label">Carlo</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelFecha" runat="server" Text="Label">Fecha:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelFechaCita" runat="server" Text="Label">01-12-12</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label">Hora Inicio:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Label">01-12-12</asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Label">Hora Fin:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Label">01-12-12</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelTratamiento" runat="server" Text="Label">Tratamiento:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelNombreTratamiento" runat="server" Text="Label">Primera Cita</asp:Label>
                </td>
            </tr>
            <tr >
                <td colspan="2"  style="text-align:center">
                <asp:Button ID="defaultButton" runat="server" Text="Modificar" CssClass="button" 
                        onclick="defaultButton_Click"/>
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>

</asp:Content>

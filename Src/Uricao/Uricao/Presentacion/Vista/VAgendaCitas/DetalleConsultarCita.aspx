<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleConsultarCita.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PAgendaCitas.DetalleConsultarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    $(function () {
        var pickerOpts = { dateFormat: "dd/mm/yy" };
        $("#datepicker").datepicker(pickerOpts);
    });
    </script>

    <style type="text/css">
        .style1
        {
            width: 170px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="texto-label" style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
    <asp:Label ID="MensajeDeTransaccion" runat="server" Text="Text" ForeColor="Red" Visible="False">Mensaje</asp:Label>
    </div>  
        
        <fieldset style="width:740px; height:250px; margin:0px auto 0px auto;">
        <legend>Detalle Cita</legend>        
            <table style="margin:0px auto 0px auto;" border="0" cellspacing="10px" cellpadding="0px" align="center">           
            <tr>
                <td>
                    <asp:Label ID="LabelMedico" runat="server" Text="Label">Medico:</asp:Label>
                </td>
                <td class="style1">
                    <asp:Label ID="LabelNombreMedico" runat="server" Text="Label">Carlo Magurno</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelFecha" runat="server" Text="Label">Fecha:</asp:Label>
                </td>
                <td class="style1">
                    <asp:Label ID="LabelFechaCita" runat="server" Text="Label">01-12-12</asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="LabelHora" runat="server" Text="Label">Hora:</asp:Label>
                </td>
                <td class="style1">
                  <asp:Label ID="LabelHoraCita" runat="server" Text="Label">11:00 a.m</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelTratamiento" runat="server" Text="Label">Tratamiento:</asp:Label>
                </td>
                <td class="style1">
                    <asp:Label ID="LabelNombreTratamiento" runat="server" Text="Label">Primera Cita</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelConfirmacion" runat="server" Text="Label">Confirmacion:</asp:Label>
                </td>
                <td class="style1">
                    <asp:Label ID="LabelConfirmacionCita" runat="server" Text="Label">Confirmada</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelStatus" runat="server" Text="Label">Estatus:</asp:Label>
                </td>
                <td class="style1">
                    <asp:Label ID="LabelStatuscita" runat="server" Text="Label">Activa</asp:Label>
                </td>
            </tr>

            </table>


             <table style="margin:0px auto 0px auto;" border="0" cellspacing="0" cellpadding="0" align="center">
             <tr >
                <td colspan="2"  style="text-align:center">
                
                    &nbsp;</td>
                 
           
           
                <td colspan="2"  style="text-align:center">
                

                 
            
             
                <td colspan="2"  style="text-align:center">
                
                    &nbsp;</td>
                  </tr>
           
            </table>          
        </fieldset>

</asp:Content>

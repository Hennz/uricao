<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConfirmacionAccionCita.aspx.cs" Inherits="Uricao.Presentacion.Vista.VAgendaCitas.ConfirmacionAccionCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

 <style type="text/css">
        .style1
        {
            width: 168px;
        }
        .style2
        {
            width: 103px;
        }
        .style3
        {
            width: 300px;
        }
        .style4
        {
            width: 180px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="texto-label" style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
            <asp:Label ID="mensajeDeTransaccion" runat="server" Text="Text" ForeColor="Red" Visible="False">Mensaje</asp:Label>
        </div>
   
        <fieldset style="width:740px; height:210px; margin-left:0px auto 0px auto;">
        <legend>Confirmacion de la Accion</legend>   
             
              <table style="margin:0px auto 0px auto; border="0" 
                cellspacing="5px" cellpadding="0" >
                <tr>
                    <td>              
                    <asp:Label ID="Label1" runat="server" Text="Label">Desea Realizar la Accion?</asp:Label>
                    <asp:Label ID="aLConfirmar" runat="server" Text="Label">(Accion)</asp:Label>

                    </td>
                </tr>
                </table>
            <table style="margin:0px auto 0px auto; border="0" 
                cellspacing="5px" cellpadding="0" >
                 <tr>
                    <td class="style2">
                        <asp:Button ID="aBRealizar"  runat="server" Height="20px" Width="130px" 
                            Text = "Realizar" CssClass="button" onclick="aBRealizar_Click" />
                    </td>
      
                    <td class="style2">
                        <asp:Button ID="aBCancelar" runat="server" Height="20px" Width="130px" 
                            Text = "Cancelar" CssClass="button" onclick="aBCancelar_Click"/>
                    </td>
      
                </tr>
            </table>          
        </fieldset>
        <br />
                    


</asp:Content>

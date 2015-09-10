<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleBanco.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PBancos.DetalleBanco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 233px;
        }
        .style3
        {
            height: 3px;
        }
        .style4
        {
            width: 233px;
            height: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="superior">
   <br />
   <br />

    <div  style="float:left;">
        <fieldset style="width:700px; height:380px; margin-left:4%;">
        <legend>Consultar Datos Bancarios</legend>        

            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
                <td align="Center">
                    <asp:Label ID="Label4" runat="server" Text="Label">Banco:</asp:Label>
                </td>
                <td class="style2">
                    Banesco</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Label">Número de Cuenta:</asp:Label>
                </td>
                <td class="style2">
                    &nbsp;0134-1111-2222-3333-4444</td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style4">
                    </td>
            </tr>
            <tr>
                <td align="center">
 
                        <asp:Button ID="defaultButton0" runat="server" Text="Aceptar" CssClass="button" onclick="defaultButton_Click"         />
                </td>
                <td class="style2">
                                  <asp:Button ID="defaultButton" runat="server" Text="Modificar" CssClass="button" onclick="defaultButton_Click"  
        
                        />
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>

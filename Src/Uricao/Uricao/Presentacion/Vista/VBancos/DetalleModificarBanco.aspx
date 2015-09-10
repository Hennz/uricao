<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleModificarBanco.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PBancos.DetalleModificarBanco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 210px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="superior">
    <h2>
        gestion de bancos</h2>
    <p>
        En esta página se modificará la información de los números de cuenta de los bancos 
        de la empresa Uricao</p>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Operacion Fallida" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Operación Exitosa" CssClass="Exito"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset style="width:700px; height:380px; margin-left:4%;">
        <legend>Modificar Datos Bancarios</legend>        
            <table style="margin:5% auto auto 26%;" border="0" cellspacing="0" 
                cellpadding="0" align="left">
            <tr>
                <td align="center">
                    <asp:Label ID="Label4" runat="server" Text="Label">Banco:</asp:Label>
                </td>
                <td class="style1">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="129px">
                        <asp:ListItem Value="0">Banesco</asp:ListItem>
                        <asp:ListItem Value="1">Mercantil</asp:ListItem>
                        <asp:ListItem Value="2">Provincial</asp:ListItem>
                        <asp:ListItem Value="3">Venezuela</asp:ListItem>
                        <asp:ListItem Value="4">Otro</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label3" runat="server" Text="Label">Número de Cuenta:</asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="TextBox1" runat="server" Text="0134-1111-2222-3333-4444" Height="20px" Width="170px"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td colspan="2"  style="text-align:center">
                <asp:Button ID="defaultButton" runat="server" Text="Aceptar" CssClass="button" onclick="defaultButton_Click" 
                        />
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>

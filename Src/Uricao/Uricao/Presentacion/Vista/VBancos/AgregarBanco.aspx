<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarBanco.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PBancos.AgregarBanco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Operación Fallida" CssClass="falla" 
            Visible="False"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Operación Exitosa" CssClass="Exito" 
            Visible="False"></asp:Label>
    </div>

    <div  style="float:left;">
         <fieldset style="width:740px; height:210px; margin:0px auto 0px auto;">
        <legend>Agregar Datos Bancarios</legend>        
            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Label">Banco:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListBancos" runat="server" Height="20px" 
                        Width="130px" 
                        onselectedindexchanged="DropDownListBancos_SelectedIndexChanged" 
                        AutoPostBack="True">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                        <asp:ListItem Value="1">Mercantil</asp:ListItem>
                        <asp:ListItem Value="2">Provincial</asp:ListItem>
                        <asp:ListItem Value="3">Venezuela</asp:ListItem>
                        <asp:ListItem Value="4">Otro</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxNuevoBanco" runat="server" Height="20px" Width="130px" 
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Label">Número de Cuenta:</asp:Label>
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="TextBoxNumCuenta" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Tipo de Cuenta:</td>
                <td>
                    <asp:DropDownList ID="DropDownListTipoCuenta" runat="server" Height="20px" Width="130px">
                        <asp:ListItem Value="0">corriente</asp:ListItem>
                        <asp:ListItem Value="1">ahorro</asp:ListItem>
                        <asp:ListItem Value="2">maxima</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr >
                <td colspan="3"  style="text-align:center">
                <asp:Button ID="defaultButton" runat="server" Text="Aceptar" CssClass="button" onclick="defaultButton_Click" 
                        />
                </td>
  
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>

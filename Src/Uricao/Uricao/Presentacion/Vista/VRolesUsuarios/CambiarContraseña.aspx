<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.CambiaContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
        <h2>
            Cuenta</h2>
        <p>
        </p>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset style="width:700px; height:380px; margin-left:4%;">
            <legend>Cambio de Contraseña</legend>
           <table style="margin:0px auto 0px auto; height: 160px;" border="0" 
                cellspacing="5px" cellpadding="0" >
                <tr>
                    <td>
                        Contraseña anterior:</td>
                    <td>
                        <input id="Password3" type="password" /></td>
                </tr>
                <tr>
                    <td>
                        Nueva Contraseña:</td>
                    <td>
                        <input id="Password2" type="password" /></td>
                </tr>
                <tr>
                    <td>
                        Repetir Contraseña:</td>
                    <td>
                        <input id="Password1" type="password" /></td>
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

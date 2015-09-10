<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarRol.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.AgregarRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Operación FALLIDA" CssClass="falla" 
            Enabled="False" Visible="False"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Operación EXITOSA" CssClass="Exito" 
            Enabled="False" Visible="False"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset style="width:740px; height:210px; margin-left:0px auto 0px auto;">
        <legend>Agregar Rol</legend>        
           <table style="margin:0px auto 0px auto; height: 80px;" border="0"
                cellspacing="10px" cellpadding="0">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label">Nombre del Rol:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="nombreRol" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Label">Descripción del Rol:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="DescripcionRol" runat="server" Height="20px" Width="130px"></asp:TextBox>
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

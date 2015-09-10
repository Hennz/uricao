<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarRoles2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.ModificarRoles2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Operación FLLIDA" CssClass="falla" Visible="false"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Operacion EXITOSA" CssClass="Exito" Visible="false"></asp:Label>
    </div>
    <div  style="float:left;">
         <fieldset style="width:740px; height:210px; margin-left:0px auto 0px auto;">
        <legend>Modificar Rol</legend>        
            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0">
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Label">ID del Rol:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextId" runat="server" Height="20px" Width="130px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label">Nombre del Rol:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextNombre" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Label">Descripción del Rol:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextDescrip" runat="server" Height="90px" Width="400px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td colspan="2"  style="text-align:center">
                <asp:Button ID="defaultButton" runat="server" Text="Aceptar" CssClass="button" onclick="defaultButton_Click"/>
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>

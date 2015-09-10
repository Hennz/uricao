<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarPrivilegio3.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.AsignarPrivilegio3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 218px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
    <h2>
       Roles y Privilegios
    </h2>
    <p>       
    </p>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset style="width:700px; height:380px; margin-left:4%;">
        <legend>Asignar Privilegio</legend>        
            <table style="margin:5% auto auto 26%;" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label">Datos del Rol Seleccionado</asp:Label>
                </td>
                <td class="style1">
                    <asp:Label ID="Label2" runat="server" Text="Label">Datos de los Privilegios Seleccionado</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Nombre: 
                    <asp:TextBox ID="NombreRol" runat="server" Height="20px" Width="130px" Enabled="false"></asp:TextBox>
                </td>
                <td class="style1">
                    Nombre: 
                    <asp:TextBox ID="NombreUsu" runat="server" Height="20px" Width="130px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Descripción del Rol
                    <asp:TextBox ID="DescripcionRol" runat="server" Height="60px" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td class="style1">
                    Apellido: 
                    <asp:TextBox ID="Apellidousu" runat="server" Height="20px" Width="130px" Enabled="false"></asp:TextBox>
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

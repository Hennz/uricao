<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarRol2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.ConsultarRol2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
        <asp:Label ID="falla" runat="server" Text="Operación FALLIDA" CssClass="falla" 
            Enabled="False" Visible="False"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Operación EXITOSA" CssClass="Exito" 
            Enabled="False" Visible="False"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset style="width:700px; height:380px; margin-left:4%;">
        <legend>Consultar Rol</legend>        
            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0">
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Label">ID del Rol:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextIdRol" runat="server" Height="20px" Width="168px" 
                        ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label">Nombre del Rol:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextNombreRol" runat="server" Height="20px" Width="168px" 
                        ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Label">Descripción del Rol:</asp:Label>
                </td>
                
                <td>
                    <asp:TextBox ID="TextDescipRol" runat="server" Height="130px" Width="400px" TextMode="MultiLine"
                        ReadOnly="true"></asp:TextBox>
                </td>
                
                </tr>
            <tr >
                <td colspan="2"  style="text-align:center">
                    <br />
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <asp:Button ID="defaultButton" runat="server" Text="Aceptar" CssClass="button" onclick="defaultButton_Click"/>
                
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>

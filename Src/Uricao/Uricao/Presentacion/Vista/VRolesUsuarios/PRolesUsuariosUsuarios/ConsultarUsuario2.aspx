<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuario2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.ConsultarUsuario2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
    <h2>
        gestión de usuarios</h2>
    <p>       
    </p>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito"></asp:Label>
    </div>
    <div  style="float:left;">
<div  style="float:left;">
        <fieldset style="width:700px; height:380px; margin-left:4%;">
        <legend>Consultar Usuario</legend>        
            <table style="margin:0% auto auto 4%; height: 482px;" border="0" 
                cellspacing="0" cellpadding="0" dir="ltr">
            <tr>
                <td>
                    Nombre(s):</td>
                <td>
                    <asp:TextBox ID="Nombres" runat="server" Height="20px" Width="130px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                    <td>
                        Apellido(s)</td>
                <td>
                    <asp:TextBox ID="Apellidos" runat="server" Height="20px" Width="130px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Usuario:</td>
                <td>
                    &nbsp;<asp:TextBox ID="Usuario" runat="server" Height="20px" Width="130px" 
                        ontextchanged="TextBox3_TextChanged" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    Identificación:</td>
                <td>
                   <div class="ui-widget">
                    <asp:TextBox ID="Identificacion" runat="server" Height="20px" Width="130px" 
                           ReadOnly="True"></asp:TextBox>
                &nbsp;</div>
                </td>
            </tr>
             <tr>
                <td>
                    Fecha de nacimiento:</td>
                <td>
                    <asp:TextBox ID="FechaNac" runat="server" Height="20px" Width="130px" 
                        ReadOnly="True"></asp:TextBox>
                 </td>
                  <td>
                      Rol:</td>
                <td>
                    <asp:TextBox ID="Rol" runat="server" Height="20px" Width="130px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Sexo:</td>
                <td>
                    <asp:TextBox ID="Sexo" runat="server" Height="20px" Width="130px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                    <td>
                        Telefono(s):</td>
                <td>
                    <asp:TextBox ID="Telefonos" runat="server" Height="20px" Width="130px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Dirección:</td>
                <td class="style1">
                    <asp:TextBox ID="Direccion" runat="server" Height="28px" Width="177px" 
                        ReadOnly="True" Rows="3" Wrap="False"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="Direccion0" runat="server" Height="29px" Width="176px" 
                        ReadOnly="True" Rows="3" Wrap="False"></asp:TextBox>
                </td>
                    <td class="style1">
                    Estado</td>
                <td class="style1">
                    <asp:TextBox ID="Estado" runat="server" Height="20px" Width="130px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha de Ingreso:</td>
                <td>
                    <asp:TextBox ID="FechaIngreso" runat="server" Height="20px" Width="130px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                    <td>
                        Correo:</td>
                <td>
                    <asp:TextBox ID="Correo" runat="server" Height="20px" Width="130px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Buscar" runat="server" Text="Modificar" CssClass="button" onclick="Buscar_Click"  
                        />
                </td>
                <td>
                    &nbsp;</td>
                    <td>
                        &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>          
        </fieldset>
    </div>    </div>
</asp:Content>

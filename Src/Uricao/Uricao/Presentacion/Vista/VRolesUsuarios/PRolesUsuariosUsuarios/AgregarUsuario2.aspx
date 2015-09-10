<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.AgregarUsuario2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <div class="superior">
   
    <p>
        Ingrese los datos del usuario que desee ingesar       
    </p>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
    </div>
    <div  style="float:left;">
        <fieldset style="width:700px; height:380px; margin-left:4%;">
        <legend>Agregar Usuario</legend>        
            <table  style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0">
            <tr>
                <td>
                    *Nombre1:</td>
                <td>
                    <asp:TextBox ID="Nombre1AgrTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
                    <td>
                        Nombre2:</td>
                <td>
                    <asp:TextBox ID="Nombre2AgrTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    *Apellido1</td>
                <td>
                    &nbsp;<asp:TextBox ID="Apellido1AgrTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
                <td>
                    Apellido2
                </td>
                <td>
                   <div class="ui-widget">
                    <asp:TextBox ID="Apellido2AgrTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                &nbsp;</div>
                </td>
            </tr>
             <tr>
                <td>
                    *Fecha de nacimiento</td>
                <td>
                    <input type="text" id="datepicker0" size="17px" /></td>
                  <td>
                      *Rol</td>
                <td>
                    <asp:DropDownList ID="ComboRolAgr" runat="server" Height="20px" Width="130px">
                        <asp:ListItem Value="0">Ejemplo1</asp:ListItem>
                        <asp:ListItem Value="1">Ejemplo2</asp:ListItem>
                        <asp:ListItem Value="3">Ejemplo3</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    *Sexo</td>
                <td>
                    <asp:DropDownList ID="DropDownListSexoAgr" runat="server" Height="20px" Width="130px">
                        <asp:ListItem Value="0">Masculino</asp:ListItem>
                        <asp:ListItem Value="1">Femenino</asp:ListItem>
                    </asp:DropDownList>
                </td>
                    <td>
                        Telefono*</td>
                <td>
                    <asp:TextBox ID="TelfTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td colspan="4"  style="text-align:center">
                    &nbsp;</td>
            </tr>
            <br />
            <br />

             <td colspan="8" style="text-align:center;">
            <asp:Button ID="AgregarButton" runat="server" Text="Aceptar" CssClass="button" 
                         Width="143px" onclick="AgregarButton_Click" />
            </td>
            </table>          
        </fieldset>
    </div>
    </p>
</asp:Content>

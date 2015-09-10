<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarUsuarios2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.ModificarUsuarios2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            width: 626px;
        }
        .style5
        {
            width: 7px;
        }
        .style6
        {
            width: 102px;
        }
        .style7
        {
            width: 66px;
        }
        .style8
        {
            width: 109px;
        }
        .style9
        {
            width: 59px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
    <h2>
        Gestión de usuarios
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
        <legend>Modificar Usuario</legend>        
            <table style="margin:5% auto auto 4%;" border="0" cellspacing="0" 
                cellpadding="0"  class="style4">
            <tr>
                <td class="style5">
                    *Nombre1:</td>
                <td class="style6">
                    <asp:TextBox ID="Nombre1" runat="server" Height="20px" Width="90px"></asp:TextBox>
                </td>
                    <td class="style7">
                        Nombre2:</td>
                <td class="style8">
                    <asp:TextBox ID="Nombre2" runat="server" Height="20px" Width="94px"></asp:TextBox>
                </td>
                <td class="style8">
                    Usuario:</td>
                <td class="style9">
                    <asp:TextBox ID="Userr" runat="server" Height="20px" Width="85px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    *Apellido1</td>
                <td class="style6">
                    &nbsp;<asp:TextBox ID="Apellido1" runat="server" Height="20px" Width="87px"></asp:TextBox>
                </td>
                <td class="style7">
                    Apellido2
                </td>
                <td class="style8">
                   <div class="ui-widget">
                    <asp:TextBox ID="Apellido2" runat="server" Height="20px" Width="94px"></asp:TextBox>
                &nbsp;</div>
                </td>
                <td class="style8">
                    Correo@</td>
                <td class="style9">
                    <asp:TextBox ID="Correoo" runat="server" Height="20px" Width="85px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style5">
                    *Rol</td>
                <td class="style6">
                    <asp:DropDownList ID="Rol" runat="server" Height="20px" Width="100px">
                        <asp:ListItem Value="0">Ejemplo1</asp:ListItem>
                        <asp:ListItem Value="1">Ejemplo2</asp:ListItem>
                        <asp:ListItem Value="3">Ejemplo3</asp:ListItem>
                    </asp:DropDownList>
                 </td>
                  <td class="style7">
                      *Fecha de nacimiento</td>
                <td class="style8">
                    <input type="text" id="fechaN" size="17px" /></td>
                <td class="style8">
                    *Estado</td>
                <td class="style9">
                    <asp:TextBox ID="status" runat="server" Height="20px" Width="85px"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td class="style5">
                    *Sexo</td>
                <td class="style6">
                    <asp:DropDownList ID="Sexo" runat="server" Height="20px" Width="100px">
                        <asp:ListItem Value="0">Ejemplo1</asp:ListItem>
                        <asp:ListItem Value="1">Ejemplo2</asp:ListItem>
                        <asp:ListItem Value="3">Ejemplo3</asp:ListItem>
                    </asp:DropDownList>
                </td>
                    <td class="style7">
                        Telefono*</td>
                <td class="style8">
                    <asp:TextBox ID="Telefono" runat="server" Height="20px" Width="100px"></asp:TextBox>
                </td>
                <td class="style8">
                    *Cedula</td>
                <td class="style9">
                    <asp:TextBox ID="Identificacon" runat="server" Height="20px" Width="85px"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td class="style5">
                    *Direccion:<br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Pais:<br />
                    <br />
&nbsp;&nbsp;&nbsp; Estado:<br />
                    <br />
&nbsp;&nbsp;&nbsp; Ciudad:</td>
                <td class="style6">
                    <br />
                    <br />
                    <asp:DropDownList ID="Pais" runat="server" Height="20px" Width="100px" 
                        AutoPostBack="True" onselectedindexchanged="Pais_SelectedIndexChanged">
                        <asp:ListItem Value="0">Ejemplo1</asp:ListItem>
                        <asp:ListItem Value="1">Ejemplo2</asp:ListItem>
                        <asp:ListItem Value="3">Ejemplo3</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:DropDownList ID="Estado" runat="server" Height="20px" Width="100px" 
                        AutoPostBack="True">
                        <asp:ListItem Value="0">Ejemplo1</asp:ListItem>
                        <asp:ListItem Value="1">Ejemplo2</asp:ListItem>
                        <asp:ListItem Value="3">Ejemplo3</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:DropDownList ID="Ciudad" runat="server" Height="20px" Width="100px" 
                        AutoPostBack="True" onselectedindexchanged="Ciudad_SelectedIndexChanged" 
                        Visible="False">
                        <asp:ListItem Value="0">Ejemplo1</asp:ListItem>
                        <asp:ListItem Value="1">Ejemplo2</asp:ListItem>
                        <asp:ListItem Value="3">Ejemplo3</asp:ListItem>
                    </asp:DropDownList>
                </td>
                    <td class="style7">
                        Municipio:      Municipio:<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Calle:<br />
&nbsp;&nbsp;&nbsp; Edificio:</td>
                <td class="style8">
                    <asp:TextBox ID="Municipio" runat="server" Height="20px" Width="101px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:TextBox ID="Calle" runat="server" Height="20px" Width="102px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:TextBox ID="Edificio" runat="server" Height="20px" Width="99px"></asp:TextBox>
                </td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            <tr >
                <td colspan="4"  style="text-align:center">
                    <asp:Button ID="Modificar" runat="server" Text="Modificar" CssClass="button" onclick="Modificar_Click"  
                        />
                </td>
                <td  style="text-align:center">
                    &nbsp;</td>
                <td  style="text-align:center" class="style9">
                    &nbsp;</td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>

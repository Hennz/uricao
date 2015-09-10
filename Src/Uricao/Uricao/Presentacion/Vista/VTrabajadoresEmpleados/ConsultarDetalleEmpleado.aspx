<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master"
    AutoEventWireup="true" CodeBehind="ConsultarDetalleEmpleado.aspx.cs" Inherits="Uricao.Presentacion.Vista.VTrabajadoresEmpleados.ConsultarDetalleEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <asp:Label ID="LabelFalla" runat="server" CssClass="falla" Text="Label" Visible="false"></asp:Label>
        <asp:Label ID="LabelExito" runat="server" CssClass="Exito" Text="Label" Visible="false"></asp:Label>
    </div>
    <div>
        <fieldset>
            <legend>Ver Empleado</legend>
            <table align="center" border="0" cellpadding="10px" cellspacing="0">
                <tr>
                    <td class="style12">
                        Nombre:
                    </td>
                    <td class="style13" style="text-align:center;">
                        <asp:TextBox ID="TextNombre" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style14">
                        Apellido:
                    </td>
                    <td class="style15" style="text-align:center;">
                        <asp:TextBox ID="TextApellido" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        Cedula de Identidad:
                    </td>
                    <td class="style2" align="center">
                        <asp:TextBox ID="TextCedula" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style14">
                        &nbsp;Fecha de Nacimiento:
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="TextFecha" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="SexoAgr" runat="server" Text="Label">Sexo:</asp:Label>
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="DropDownSexo" runat="server" Height="20px" Width="130px">
                            <asp:ListItem Value="0">Masculino</asp:ListItem>
                            <asp:ListItem Value="1">Femenino</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style14">
                        &nbsp;
                    </td>
                    <td class="style6">
                        &nbsp;
                    </td>
                    <td class="style7">
                </tr>
                <tr>
                    <td class="style3">
                        &nbsp;Telefono:
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="TextTelefono" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style14">
                        Correo Electronico:
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="TextCorreo" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        Cargo:
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="DropDownCargo" runat="server" Height="20px" Width="130px">
                            <asp:ListItem Value="0">Administrador</asp:ListItem>
                            <asp:ListItem Value="1">Personal Odontologico</asp:ListItem>
                            <asp:ListItem Value="2">Asistente</asp:ListItem>
                            <asp:ListItem Value="3">Secretaria</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style14">
                        Sueldo:
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="TextSueldo" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Direccion:
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <br />
                        <br />
                        </br>
                    </td>
                    <td class="style9">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pais:<br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Estado:<br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Ciudad:<br />
                        <br />
                        &nbsp;&nbsp;&nbsp;
                        <br />
                        &nbsp;&nbsp;&nbsp;Detalle Direccion:
                    </td>
                    <td class="style10">
                        <br />
                        <br />
                        <asp:DropDownList ID="DropDownPais" runat="server" Height="20px" Width="130px" 
                            onselectedindexchanged="DropDownPais_SelectedIndexChanged" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <br />
                        <asp:DropDownList ID="DropDownEstado" runat="server" Height="20px" 
                            Width="130px" AutoPostBack="True" 
                            onselectedindexchanged="DropDownEstado_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <br />
                        <asp:DropDownList ID="DropDownCiudad" runat="server" Height="20px" Width="130px">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <br />
                        <asp:TextBox ID="TextDireccion" runat="server" Height="20px" Width="200px"></asp:TextBox>
                        <br />
                        <br />
                        <br />
                        </br>
                    </td>
                    <td class="style11">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="style6">
                        <asp:Button ID="BotonEditar" runat="server" CssClass="button" Text="Editar" OnClick="BotonEditar_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BotonDesactivar" runat="server" CssClass="button" Text="Desactivar"
                            OnClick="BotonDesactivar_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>

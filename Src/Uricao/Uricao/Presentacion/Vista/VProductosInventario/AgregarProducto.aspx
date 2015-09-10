<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master"
    AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PProductosInventario.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <div style="height: 30px; text-align: center; font-family: Verdana; font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" CssClass="falla" Text="" Visible="False"></asp:Label>
        <asp:Label ID="exito" runat="server" CssClass="Exito" Text="" Visible="False"></asp:Label>
    </div>
    <div style="float: left;">
        <fieldset style="width: auto; height: auto; margin-left: 4%;">
            <legend>Agregar Producto</legend>
            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="10" cellpadding="" >
                <tr>
                    <td>
                        <asp:Label ID="LabelCodigo" runat="server" Text="Label">Código:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxCodigo" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="LabelProveedor" runat="server" Text="Label">Proveedor:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListProveedor" runat="server" Height="20px" Width="130px"
                            OnSelectedIndexChanged="DropDownListProveedor_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelNombre" runat="server" Text="Label">Nombre:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxNombre" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="LabelMarca" runat="server" Text="Label">Marca:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListMarca" runat="server" Height="20px" Width="130px"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelTipo" runat="server" Text="Label">Tipo:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListTipo" runat="server" Height="20px" Width="130px">
                            <asp:ListItem Value="Producto médico">Producto médico</asp:ListItem>
                            <asp:ListItem Value="Equipo médico">Equipo médico</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="LabelCategoria" runat="server" Text="Label">Categoría:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListCategoria" runat="server" Height="20px" 
                            Width="130px" 
                            onselectedindexchanged="DropDownListCategoria_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelCalidad" runat="server" Text="Label">Calidad:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListCalidad" runat="server" Height="20px" Width="130px">
                            <asp:ListItem Value="Alta">Alta</asp:ListItem>
                            <asp:ListItem Value="Media">Media</asp:ListItem>
                            <asp:ListItem Value="Baja">Baja</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="LabelPrecio" runat="server" Text="Label">Precio: Bs. F</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxPrecio" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelInconvenientes" runat="server" Text="Label">Inconvenientes:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxInconvenientes" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="LabelCantidadMinima" runat="server" Text="Label">Minimo:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxCantidadMinima" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
              
                    <td  colspan="8" style="text-align:center;">
                        <asp:Button ID="botonAceptar" runat="server" Text="Aceptar" CssClass="button" OnClick="botonAceptar_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>

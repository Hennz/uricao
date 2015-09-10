<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VerProductoDetallado.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PProductosInventario.verProductoDetallado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" CssClass="falla" Text="" Visible="False"></asp:Label>
        <asp:Label ID="exito" runat="server" CssClass="Exito" Text="" Visible="False"></asp:Label>
    </div>
<div  style="float:left;">
        <fieldset style="width:740px; height:210px; margin-left:0px auto 0px auto;">
        <legend>Ver producto detallado</legend>        
            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0">
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
                    <asp:DropDownList ID="DropDownListProveedor" runat="server" Height="20px" Width="130px">
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
                     <asp:DropDownList ID="DropDownListMarca" runat="server" Height="20px" Width="130px">
                            <asp:ListItem Value="0">Marca 1</asp:ListItem>
                            <asp:ListItem Value="1">Marca 2</asp:ListItem>
                     </asp:DropDownList>   
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelTipo" runat="server" Text="Label">Tipo:</asp:Label>
                 </td>
                 <td>
                    <asp:DropDownList ID="DropDownListTipo" runat="server" Height="20px" Width="130px">
                        <asp:ListItem Value="0">Producto médico</asp:ListItem>
                        <asp:ListItem Value="1">Equipo médico</asp:ListItem>
                    </asp:DropDownList>
                 </td>
                 <td>
                    <asp:Label ID="LabelCategoria" runat="server" Text="Label">Categoría:</asp:Label>
                 </td>
                 <td>
                    <asp:DropDownList ID="DropDownListCategoria" runat="server" Height="20px" Width="130px">
                        <asp:ListItem Value="0">Guantes</asp:ListItem>
                        <asp:ListItem Value="1">Jeringas</asp:ListItem>
                    </asp:DropDownList>
                 </td>
             </tr>
             <tr>
                <td>
                    <asp:Label ID="LabelCalidad" runat="server" Text="Label">Calidad:</asp:Label>
                </td>
                <td>
                     <asp:DropDownList ID="DropDownListCalidad" runat="server" Height="20px" Width="130px">
                            <asp:ListItem Value="0">Alta</asp:ListItem>
                            <asp:ListItem Value="1">Media</asp:ListItem>
                            <asp:ListItem Value="1">Baja</asp:ListItem>
                     </asp:DropDownList>   
                </td>
                <td>
                    <asp:Label ID="LabelPrecio" runat="server" Text="Label">Precio:</asp:Label>
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
                    <asp:Label ID="LabelCantidadMinima" runat="server" Text="Label">Cantidad mínima en Inventario:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCantidadMinima" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4"  style="text-align:center;">
                <asp:Button ID="botonEditar" runat="server" Text="" CssClass="button" 
                        onclick="botonEditar_Click"/>
                </td>
             </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>

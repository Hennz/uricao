<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="HomeProveedores.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PProveedores.HomeProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="superior">
        <h2>
            Proveedores
        </h2>
        <p>
            
        </p>
    </div>

    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" CssClass="falla" Text="Label" 
            Visible="False"></asp:Label>
        <asp:Label ID="Exito" runat="server" CssClass="Exito" Text="Label" 
            Visible="False"></asp:Label>
    </div>

    <div style="margin-top:25px">

     <fieldset>
            <legend>Consultar Proveedores</legend>
            <table align="center" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan=2>
                        Ingrese Nombre o Rif para la busqueda por parametros</td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label">Nombre:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxNombre" runat="server" Height="20px" Width="130px"></asp:TextBox> 
                    </td>
                </tr>
                <tr>
                
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Rif:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxRif" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"  style="text-align:center;">
                        <asp:Button ID="defaultButton" runat="server" Text="Buscar" OnClick="defaultButton_Click" CssClass="button" />
                    </td>
                </tr>
            </table>

             
        </fieldset>


        <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" HorizontalAlign="Center" 
            onpageindexchanging="GridConsultar_PageIndexChanging" 
            onselectedindexchanged="GridConsultar_SelectedIndexChanged" 
            SelectedIndex="0" Width="720px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" CssClass="nada" ClientIDMode="AutoID">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField AccessibleHeaderText="Seleccion" ButtonType="Image" 
                    HeaderText="Detalle" SelectImageUrl="~/Presentacion/Imagenes/Buscar.png" 
                    ShowSelectButton="True" />
            </Columns>
            <EditRowStyle HorizontalAlign="Center" 
                VerticalAlign="Middle" BackColor="#2461BF" />
            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings PageButtonCount="4" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" 
                BackColor="#4870BE" />
        </asp:GridView>
    </div>

</asp:Content>

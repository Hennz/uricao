<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModifiarUsuarios.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.ModifiarRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <fieldset style="width:700px; height:480px; margin-left:4%;">
            <legend>Modificar Usuarios</legend>        
            <table style="margin:5% auto auto 26%;" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Buscar Usuario:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Botonn" runat="server" Text="Buscar" CssClass="button"                         />
                </td>
            </tr>
            </table>
            <asp:GridView ID="GridModificar" runat="server" AllowPaging="True" HorizontalAlign="Center" 
            PageSize="8" 
            SelectedIndex="0" Width="720px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" CssClass="nada">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField AccessibleHeaderText="Seleccion" ButtonType="Image" 
                    HeaderText="Modificar" EditImageUrl="~/Presentacion/Imagenes/Editar.png" 
                    ShowEditButton="True" />
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
        </fieldset>
</asp:Content>

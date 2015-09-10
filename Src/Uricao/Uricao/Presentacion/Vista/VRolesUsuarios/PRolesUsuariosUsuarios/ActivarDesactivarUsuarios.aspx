<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ActivarDesactivarUsuarios.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
  
    <p>      
    </p>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
    </div>
    <div  style="float:left;">
        <fieldset style="width:700px; height:480px; margin-left:4%;">
        <legend>Activar/Desactivar Roles</legend>        
            <table style="margin:5% auto auto 26%;" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td>
                    Busqueda de Usuario</td>
                <td>
                    <asp:DropDownList ID="Combo" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="Textobusqueda" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Boton" runat="server" Text="Buscar" CssClass="button" onclick="defaultButton_Click" 
                        />
                </td>
            </tr>
            </table>
            <asp:GridView ID="GridActivarDesactivar" runat="server" AllowPaging="True" HorizontalAlign="Center" 
             
            PageSize="8" 
            SelectedIndex="0" Width="720px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" CssClass="nada">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField AccessibleHeaderText="Seleccion" ButtonType="Image" 
                    HeaderText="Buscar" EditImageUrl="~/Presentacion/Imagenes/Eliminar.png" 
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
    </div>
</asp:Content>

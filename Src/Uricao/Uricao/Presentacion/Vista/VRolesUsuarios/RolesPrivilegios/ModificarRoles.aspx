<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarRoles.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.ModificarRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style="height:30px; text-align:center; font-family:Verdana;font-size: 1em;">
<asp:Label ID="info" Text="Al seleccionar la opcion: TODOS, se mostraran toda la informacion sobre los roles sin importar lo que introd. en el campo de texto" runat="server" ForeColor="Blue"></asp:Label>
    </div>
    <br />
    <fieldset style="width:700px; height:150px; margin-left:4%;">
            <legend>Modificar Roles</legend>        
            <table style="margin:5% auto auto 26%;" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td>
                    <asp:DropDownList ID="ComboOpcion" runat="server">
                        <asp:ListItem Value="0">Todos</asp:ListItem>
                        <asp:ListItem Value="1">ID</asp:ListItem>
                        <asp:ListItem Value="2">Nombre</asp:ListItem>
                        <asp:ListItem Value="3">Descripción</asp:ListItem>
                        <asp:ListItem Value="4">Estado</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="textOpcion" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button" onclick="Button1_Click" 
                        />
                </td>
                <div style="height:5px; text-align:center; font-family:Verdana;font-size: 0.8em;">
                <asp:Label ID="falla" runat="server" Text="" CssClass="falla" Visible="False"></asp:Label>
                <asp:Label ID="Exito" runat="server" Text="" CssClass="Exito" Visible="False"></asp:Label>
                </div>
                <br />
            </tr>
            </table>
             </fieldset>
             <br/>
            <asp:GridView ID="GridModificar" runat="server" AllowPaging="True" HorizontalAlign="Center" 
            onPageIndexChanging="GridModificar_PageIndexChanging"
            onselectedindexchanged="GridModificar_SelectedIndexChanged" PageSize="5" 
            SelectedIndex="0" Width="700px" CellPadding="0" ForeColor="#333333" 
            GridLines="None" CssClass="nada" ViewStateMode="Enabled" 
                AutoGenerateColumns="False" CellSpacing="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField AccessibleHeaderText="Seleccion" ButtonType="Image" 
                    HeaderText="Modificar" SelectImageUrl="~/Presentacion/Imagenes/Editar.png" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="IdRol" HeaderText="Id" />
                <asp:BoundField DataField="NombreRol" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
            </Columns>
            <EditRowStyle HorizontalAlign="Center" 
                VerticalAlign="Middle" BackColor="#2461BF" />
            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings PageButtonCount="4" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Justify" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" 
                BackColor="#4870BE" />
        </asp:GridView>
       
</asp:Content>

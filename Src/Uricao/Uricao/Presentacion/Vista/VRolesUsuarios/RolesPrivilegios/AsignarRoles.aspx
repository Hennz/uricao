<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarRoles.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito"></asp:Label>
    </div>
  
        <fieldset style="width:700px; height:100px; margin-left:4%;">
        <legend>Asignar Rol</legend>   
            <table style="margin:0px auto 0px auto; height: 88px;" border="0" 
                cellspacing="5px" cellpadding="0">
            
                <tr>
                    <td>
                        <asp:DropDownList ID="ComboOpcion" runat="server">
                        <asp:ListItem Value="0">Todos</asp:ListItem>
                        <asp:ListItem Value="1">Nombre</asp:ListItem>
                        <asp:ListItem Value="2">Apellido</asp:ListItem>
                        <asp:ListItem Value="3">Cedula</asp:ListItem>
                        <asp:ListItem Value="5">Usuario</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
            </table>       
        
        </fieldset>
     
    <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" HorizontalAlign="Center" 
            onselectedindexchanged="GridConsultar_SelectedIndexChanged" PageSize="8" 
            onPageIndexChanging="GridConsultar_PageIndexChanging"
            SelectedIndex="0" Width="100px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" CssClass="nada">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField AccessibleHeaderText="Seleccion" ButtonType="Image" 
                    HeaderText="Seleccionar" EditImageUrl="~/Presentacion/Imagenes/Buscar.png" 
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
</asp:Content>

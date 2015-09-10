<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarRoles2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.AsignrRoles2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
    
    <p>       
    </p>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset style="width:700px; height:380px; margin-left:4%;">
        <legend>Asignar Rol</legend>   
            <table style="margin:5% auto auto 10%;" border="0" cellspacing="0" 
                cellpadding="0">
            Buscar Rol que le desea asignar al Usuario
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
                    <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button" onclick="defaultButton_Click" 
                        />
                </td>
            </tr>
    </table>   
            <asp:GridView ID="GridConsultarRol" runat="server" AllowPaging="True" 
                PageSize="2" 
                Width="720px" CellPadding="4" ForeColor="#333333" 
                GridLines="None"  
                onPageIndexChanging="GridConsultarRol_PageIndexChanging" 
                onselectedindexchanged="GridConsultarRol_SelectedIndexChanged" 
                AllowSorting="True" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ButtonType="Image" 
                        HeaderText="Seleccionar" 
                        SelectImageUrl="~/Presentacion/Imagenes/Buscar.png" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdRol" HeaderText="Id de Rol" />
                    <asp:BoundField DataField="NombreRol" HeaderText="Nombre del Rol" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción del Rol" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
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

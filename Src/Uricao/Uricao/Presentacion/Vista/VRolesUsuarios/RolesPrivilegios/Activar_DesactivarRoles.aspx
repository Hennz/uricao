<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Activar_DesactivarRoles.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.Activar_DesactivarRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
    <h2>
       Roles y Privilegios
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
        <legend>Activar/Desactivar Roles</legend>        
            <table style="margin:5% auto auto 26%;" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <asp:GridView ID="GridConsultar" runat="server" AutoGenerateColumns="False" 
                CellPadding="6" ForeColor="#333333" GridLines="None" CellSpacing="3" Width="736px" 
                AllowPaging="True" PageSize="7" 
                onPageIndexChanging="GridConsultar_PageIndexChanging" 
                onselectedindexchanged="GridConsultar_SelectedIndexChanged" 
                HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ButtonType="Image" HeaderText="Detalle" 
                        SelectImageUrl="~/Presentacion/Imagenes/Buscar.png" ShowSelectButton="True" />
                    <asp:BoundField DataField="idRol" HeaderText="Id" />
                    <asp:BoundField DataField="nombreRol" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción del Rol" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            </tr>
            <tr>
                <td  style="text-align:center">
                <asp:Button ID="defaultButton" runat="server" Text="Act/Inact" CssClass="button" onclick="defaultButton_Click" 
                        />
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>

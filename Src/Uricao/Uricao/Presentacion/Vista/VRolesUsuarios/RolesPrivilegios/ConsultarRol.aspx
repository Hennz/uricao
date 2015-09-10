<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarRol.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.ConsultarRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="superior">
    <h2>
       Roles y Privilegios
    </h2>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1em;">
        <asp:Label ID="info" Text="Al seleccionar la opcion: TODOS, se mostraran toda la informacion sobre los roles sin importar lo que introd. en el campo de texto"
         runat="server" ForeColor="Blue"></asp:Label>
    </div>
    <br />
    <div  style="float:left;">
    <fieldset style="width:740px; height:90px; margin-left:0px auto 0px auto; text-align: center;">
        <legend>Consultar Rol</legend> 
           <table style="margin:0px auto 0px auto; height: 80px;" border="0" >

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
                    <asp:TextBox ID="textOpcion" runat="server" Height="20px" Width="168px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button" onclick="defaultButton_Click"/>
                </td>
        <div style="height:5px; text-align:center; font-family:Verdana;font-size: 0.8em;">
        <asp:Label ID="falla" runat="server" Text="" CssClass="falla" Visible="False"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="" CssClass="Exito" Visible="False"></asp:Label>
        </div>

            </tr>
            </table>
         </fieldset><br />
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
    </div>
</asp:Content>

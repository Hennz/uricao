<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarPrivilegio2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.AsignarPrivilegio2" %>
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
        <legend>Asignar Rol</legend>   
            <table style="margin:5% auto auto 10%;" border="0" cellspacing="0" 
                cellpadding="0">
            Buscar los Privilegios que desea agregar al Rol seleccionado
            <tr>
                <td>
                    <select id="Select1">
                        <option>Todo</option>
                        <option>ID</option>
                        <option>Nombre</option>
                    </select>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button" onclick="defaultButton_Click" 
                        />
                </td>
            </tr>
    </table>   
            <asp:GridView ID="GridConsultarUsu" runat="server" AllowPaging="True" HorizontalAlign="Center" 
                onpageindexchanging="GridConsultarUsu_PageIndexChanging" 
                onselectedindexchanged="GridConsultarUsu_SelectedIndexChanged" PageSize="8" 
                SelectedIndex="0" Width="720px" CellPadding="4" ForeColor="#333333" 
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
        </fieldset>
    </div>
</asp:Content>

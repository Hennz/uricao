<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarTratamiento.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PTratamientos.ModificarTratamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset style="width:700px; margin-left:4%;">
    <legend>Consultar Tratamiento</legend>
    <!--<table style="margin:0px auto 0px auto; height: 160px;" border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
                <td class="style1">
                    <asp:Label ID="error" runat="server" CssClass="falla" Font-Bold="True"></asp:Label>
                    <asp:RadioButtonList ID="ParametrosBusqueda" runat="server" 
                    RepeatDirection="Horizontal" CellPadding="3" CellSpacing="3" Width="480px" 
                    onselectedindexchanged="ParametrosBusqueda_SelectedIndexChanged">
                    <asp:ListItem>Id</asp:ListItem>
                    <asp:ListItem>Estado</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                 <td colspan="8" style="text-align:center;">
                    <asp:TextBox ID="Busqueda" runat="server" Width="395px" Height="21px" 
                     style="text-align: center"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Buscar" runat="server" Text="Buscar" onclick="Buscar_Click" />
                </td>
            </tr>
            </table>        -->
             <asp:GridView ID="GridViewTratamiento" runat="server" AutoGenerateColumns="False" 
            Style="text-align: center" CellPadding="4" GridLines="None" Width="600px" HorizontalAlign="Center"
            AllowPaging="True" PageSize="10" 
            OnSelectedIndexChanged="gridViewTratamiento_SelectedIndexChanged" 
            AllowSorting="True" OnRowCommand="GridViewTratamiento_RowCommand"
            OnPageIndexChanging="GridViewTratamiento_PageIndexChanging" 
            ShowFooter="true"
            >

            <HeaderStyle BackColor="#1d60ff"  ForeColor="White" />
            <FooterStyle BackColor="#1d60ff"  ForeColor="White" />
            <PagerStyle BackColor="#1d60ff" ForeColor="White" HorizontalAlign="Center" />

            <Columns>
                <asp:ButtonField ButtonType="Image" HeaderText="Buscar"  CommandName="Buscar"
                    ImageUrl="~/Presentacion/Imagenes/Buscar.png" Text="Botón" />
                <asp:BoundField DataField="Id" HeaderText="Codigo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                
            </Columns>
        </asp:GridView>

    </fieldset>
</asp:Content>
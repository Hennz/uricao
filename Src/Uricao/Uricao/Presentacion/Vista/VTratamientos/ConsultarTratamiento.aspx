<%@ Page Title="Consultar Tratamiento" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarTratamiento.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PTratamientos.ConsultarTratamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset style="width:700px; margin-left:4%; text-align:center;">
    <legend>Consultar Tratamiento</legend>
        <asp:Label ID="error" runat="server" CssClass="falla" Font-Bold="True"></asp:Label>
        <asp:RadioButtonList ID="ParametrosBusqueda" runat="server" 
            RepeatDirection="Horizontal" CellPadding="3" CellSpacing="3" Width="480px" 
            onselectedindexchanged="ParametrosBusqueda_SelectedIndexChanged">
            <asp:ListItem>Id</asp:ListItem>
            <asp:ListItem>Estado</asp:ListItem>
            <asp:ListItem>Nombre</asp:ListItem>
        </asp:RadioButtonList>
    <br />

    <asp:TextBox ID="Busqueda" runat="server" Width="395px" Height="21px" 
        style="text-align: center"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Buscar" runat="server" Text="Buscar" onclick="Buscar_Click" />
    <br />
    <br />
     
        <asp:GridView ID="GridViewTratamiento" runat="server" AutoGenerateColumns="False" 
            Style="text-align: center" CellPadding="4" GridLines="None" 
        Width="600px" HorizontalAlign="Center"
            AllowPaging="True" 
            OnSelectedIndexChanged="gridViewTratamiento_SelectedIndexChanged" 
            AllowSorting="True" OnRowCommand="GridViewTratamiento_RowCommand"
            OnPageIndexChanging="GridViewTratamiento_PageIndexChanging" 
            ShowFooter="True" ForeColor="#333333"
            >

            <HeaderStyle BackColor="#507CD1"  ForeColor="White" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1"  ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />

            <AlternatingRowStyle BackColor="White" />

            <Columns>
                <asp:ButtonField ButtonType="Image" HeaderText="Buscar"  CommandName="Buscar"
                    ImageUrl="~/Presentacion/Imagenes/Buscar.png" Text="Botón" />
                <asp:BoundField DataField="Id" HeaderText="Codigo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                
            </Columns>
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
            </fieldset>
</asp:Content>

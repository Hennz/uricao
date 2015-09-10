<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleCuentaPorCobrar.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar.DetalleCuentaPorCobrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="cambioPagina" runat="server">Cambio de pagina</asp:Label>
     <div class="superior">
        <h2>
            CONSULTAR CUENTA POR COBRAR
        </h2>
        
    </div>
    <div>
    
        <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" 
            CellPadding="4" CssClass="nada" ForeColor="#333333" GridLines="None" 
            HorizontalAlign="Center" onpageindexchanging="GridConsultar_PageIndexChanging" 
            onselectedindexchanged="GridConsultar_SelectedIndexChanged" PageSize="8" 
            SelectedIndex="0" Width="720px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField AccessibleHeaderText="Seleccion" ButtonType="Image" 
                    HeaderText="Detalle" SelectImageUrl="~/Presentacion/Imagenes/Buscar.png" 
                    ShowSelectButton="True" />
                <asp:BoundField AccessibleHeaderText="Nombre" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" 
                VerticalAlign="Middle" />
            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings PageButtonCount="4" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" HorizontalAlign="Center" 
                VerticalAlign="Middle" />
        </asp:GridView>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleCuentaCobrar.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar.DetalleCuentaCobrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="cambioPagina" runat="server">Cambio de pagina</asp:Label>
    <div>
    <div class="superior">
        <h2>
            CONSULTAR CUENTA POR COBRAR
        </h2>
        
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
    <asp:Label ID="falla" runat="server" CssClass="falla" Text="Label" 
        Visible="False"></asp:Label>
    
</div>
        <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" 
            CellPadding="4" CssClass="nada" ForeColor="#333333" GridLines="None" 
            HorizontalAlign="Center" onpageindexchanging="GridConsultar_PageIndexChanging" 
            onselectedindexchanged="GridConsultar_SelectedIndexChanged" PageSize="8" 
            Width="720px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField AccessibleHeaderText="Seleccion" ButtonType="Image" 
                    HeaderText="Detalle" SelectImageUrl="~/Presentacion/Imagenes/Buscar.png" 
                    ShowSelectButton="True" />
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

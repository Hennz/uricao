﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="SeleccionarProductoConsumo.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PProductosInventario.SeleccionarProductoConsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style="margin-top:25px">
<div style="height: 30px; text-align: center; font-family: Verdana; font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" CssClass="falla" Text="" Visible="False"></asp:Label>
        <asp:Label ID="exito" runat="server" CssClass="Exito" Text="" Visible="False"></asp:Label>
    </div>
    <fieldset style="width:auto; height:auto; margin-left:4%;">
        <legend>Seleccionar producto</legend>
        <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" HorizontalAlign="Center" 
            onpageindexchanging="GridConsultar_PageIndexChanging" 
            onselectedindexchanged="GridConsultar_SelectedIndexChanged" PageSize="8" 
            SelectedIndex="0" Width="720px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" CssClass="nada">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField AccessibleHeaderText="Seleccion" ButtonType="Image" 
                    HeaderText="Detalle" SelectImageUrl="~/Presentacion/Imagenes/Buscar.png" 
                    ShowSelectButton="True" />
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

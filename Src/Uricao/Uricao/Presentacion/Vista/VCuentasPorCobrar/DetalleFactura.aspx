<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleFactura.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar.DetalleFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
        <h2>
            Detalle factura
        </h2>
        
    </div>
      <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" CssClass="falla" Text="Label"></asp:Label>
        <asp:Label ID="Exito" runat="server" CssClass="Exito" Text="Label"></asp:Label>
    </div>
    <div>
         <fieldset style="width:740px; height:210px; margin:0px auto 0px auto;">
            <legend>Factura</legend>
            <table style="margin:0px auto 0px auto; height: 160px;" cellspacing="5px" border="0"  cellpadding="0" >
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label">Cédula:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server"></asp:Label> 
                    </td>
                    </tr>
                    
                    <tr>
                
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Label">Nombre:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server"></asp:Label>
                    </td>
                  
                   
               
                   
                   
                    </tr>
                
                <tr>
                 <td>
                        <asp:Label ID="Label3" runat="server" Text="Label">Apellido:</asp:Label>
                        
                    </td>
                    <td>
                         <asp:Label ID="Label13" runat="server"></asp:Label>
                        
                    </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Label">Factura:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server"></asp:Label> 
                    </td>
                </tr>
                    
            </table>

            
        </fieldset>
        
             <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" HorizontalAlign="Center" 
             onpageindexchanging="GridConsultar_PageIndexChanging" 
            onselectedindexchanged="GridConsultar_SelectedIndexChanged"
            
             PageSize="3" Width="720px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" CssClass="nada" Height="100px">
            <AlternatingRowStyle BackColor="White" />
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

        <br />

         <fieldset style="width:740px; height:50px; margin:0px auto 0px auto; text-align:center;">
            <legend>Abonos de la Factura</legend>
            <asp:LinkButton ID="LinkButton1" href="/Presentacion/PaginasWeb/PCuentasPorCobrar/AgregarAbono.aspx" runat="server">Agregar Nuevo Abono</asp:LinkButton>
           </fieldset>

         <asp:GridView ID="GridConsultar2" runat="server" AllowPaging="True" HorizontalAlign="Center" 
             onpageindexchanging="GridConsultar2_PageIndexChanging" 
            onselectedindexchanged="GridConsultar2_SelectedIndexChanged"
            
             PageSize="3" Width="720px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" CssClass="nada" Height="100px">
            <AlternatingRowStyle BackColor="White" />
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
        
    </div>
</asp:Content>

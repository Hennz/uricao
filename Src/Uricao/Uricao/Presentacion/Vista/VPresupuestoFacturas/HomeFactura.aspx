<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="HomeFactura.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.HomeFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table align= "center">
            <tr>
                <td> 
                    <asp:Button class = "button" id = "aBAgregar_Factura" runat = "server" Text = "Generar" Width = "133px"> 
                    </asp:Button> 
                    <!--esta es la creacion del buton, en el class va el nombre del style que se encuentra
                    en Site.css -->
                </td>
                <td>
                    <asp:Button class = "button" id = "aBConsultar_Factura" runat = "server" Text = "Consultar" Width = "133px"> 
                    </asp:Button> 
                </td>

                
            </tr>
        </table>
         
        &nbsp;
        
        &nbsp;

    </div>    
</asp:Content>
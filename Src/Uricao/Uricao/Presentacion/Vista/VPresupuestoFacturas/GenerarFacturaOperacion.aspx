<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GenerarFacturaOperacion.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.GenerarFacturaOperacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <fieldset>
    <div>
        <table align = "center">
            <tr>
                <td>
                    <div class=" active" style="height:30px;">
       <h2>
            Se ha Generado la Factura Exitosamente
       </h2>
    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                            </td>
                            <td>
                                <asp:Button class = "button" ID = "aBContinuar" runat = "server" Text = "Continuar">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                    
                </td>
            </tr>
        </table>
    </div>
    </fieldset>
</asp:Content>

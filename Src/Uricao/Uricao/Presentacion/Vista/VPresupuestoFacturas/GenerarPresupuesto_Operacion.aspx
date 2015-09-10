<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GenerarPresupuesto_Operacion.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.GenerarPresupuesto_Operacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <table align = "center">
            <tr>
                <td>
                    <asp:Label class = "inline" id = "aLSeleccionar" runat = "server" Text = "Se ha Procesado el presupuesto ">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Button class = "button" ID = "aBImprimir" runat = "server" Text = "Imprimir PDF" Width = "130px">
                                </asp:Button>
                            </td>
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

</asp:Content>

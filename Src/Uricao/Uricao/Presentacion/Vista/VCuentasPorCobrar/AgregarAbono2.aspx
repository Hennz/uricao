<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarAbono2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar.AgregarAbono2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function ValidNum(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return ((tecla > 47 && tecla < 58) || tecla == 46);
    }

    $(function () {
        var pickerOpts = { dateFormat: "dd/mm/yy" };
        $("#<%= datepicker.ClientID  %>").datepicker(pickerOpts);
    });
   

    function datepicker_onclick() {

    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
        <h2>
             AGREGAR ABONO
        </h2>
        <p>
            
        </p>
    </div>
    <div class="texto-label" style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" CssClass="falla" Text="Label" 
            Visible="False"></asp:Label>
        <asp:Label ID="Exito" runat="server" CssClass="Exito" Text="Label" 
            Visible="False"></asp:Label>
    </div><br />
    <div style="float:left;">
        <fieldset style="width:740px; height:210px; margin:0px auto 0px auto;">
            <legend>Agregar Abono</legend>
            <table style="margin:0px auto 0px auto; height: 160px;" cellspacing="5px" border="0" 
                cellpadding="0" align="center">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label">Cliente: </asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="Label4" runat="server" Text="Label">Factura: </asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Label">Datos Abono:</asp:Label>
                    </td>
                    <td>
                       
                        
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Label">Fecha:</asp:Label>
                    </td>
                    <td>
                           <asp:TextBox ID="datepicker" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                 
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label">Monto:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Monto" runat="server" Height="20px" Width="130px" ></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:Button ID="defaultButton" runat="server" CssClass="button" onclick="defaultButton_Click"
                             Text="Aceptar" />
                    </td>
                </tr>
               
            </table>
        </fieldset>
    </div>
</asp:Content>

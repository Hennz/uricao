<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarLote.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PProductosInventario.AgregarLote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="superior">
    <h2>
      Proveedores
    </h2>
    <p>
      <%--Descripcion de accion (opcional)  --%>      
    </p>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset style="width:700px; height:380px; margin-left:4%;">
        <legend>Agregar Lote</legend>        
            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0">
            <tr>
                <td>
                    <asp:Label ID="LabelProducto" runat="server" Text="Label">Producto:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxNombre" runat="server" Height="20px" Width="130px" 
                        Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelCantidad" runat="server" Text="Label">Cantidad:</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="TextBoxCantidad" runat="server" Height="20px" Width="130px"></asp:TextBox>
                 </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="LabelFechaIngreso" runat="server" Text="Label">Fecha Ingreso:</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="TextBoxFechaIngreso" runat="server" Height="20px" 
                        Width="130px" Enabled="False"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                 <td>
                    <asp:Label ID="LabelFechaVencimiento" runat="server" Text="Label">Fecha Vencimiento:</asp:Label>
                </td>
                <td>
                    <input type="text" id="datepickerFechaVencimiento" size="17px" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="LabelUbicacion" runat="server" Text="Label">Ubicacion:</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="TextBoxUbicacion" runat="server" Height="20px" Width="130px"></asp:TextBox>
                 </td>
            </tr>
            
            <tr >
                <td colspan="8" style="text-align:center;">
                <asp:Button ID="defaultButton" runat="server" Text="Agregar" CssClass="button" 
                        />
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>


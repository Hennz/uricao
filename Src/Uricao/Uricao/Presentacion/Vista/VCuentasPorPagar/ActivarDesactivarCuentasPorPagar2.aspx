<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ActivarDesactivarCuentasPorPagar2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorPagar.ActivarDesactivarCuentasPorPagar2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    $(function () {
        $("#datepicker").datepicker();
    });
    </script>
    <style type="text/css">
        .style1
        {
            width: 125px;
        }
        .style2
        {
            width: 153px;
        }
        .style3
        {
            width: 132px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
        <h2>
           Detalle de la Cuenta por Pagar
        </h2>    
    </div>

    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito"></asp:Label>
    </div>


    <fieldset>

        <legend>Detalle de la Cuenta por Pagar:</legend>

        <table style="margin:0% auto auto 0%;" border="0" cellspacing="0" cellpadding="0" align="center" >
         
        <tr>
            <td><strong>Codigo Cuenta:</strong></td>

            <td>
                <asp:Label ID="labelcuentaCodigo" runat="server"></asp:Label>
            </td>

            <td><strong>Razón Social / Empresa:</strong></td>
            <td>
                <asp:Label ID="labelproveedor" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td><strong>Banco:</strong></td>

            <td>
                <asp:Label ID="labelBanco" runat="server"></asp:Label>
            </td>
             
            <td><strong>Nº Cuenta Bancaria:</strong></td>

            <td>
                <asp:Label ID="labelNumeroCuenta" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td><strong>Tipo de Pago:</strong></td>

            <td>
                <asp:Label ID="labeltipoPago" runat="server"></asp:Label>
            </td>

            <td><strong>Concepto Deuda:</strong></td>

            <td>
                <asp:Label ID="label6" runat="server" Text="Proveedor"></asp:Label>
            </td>             
        </tr>

        <tr>     
            <td><strong>Deuda Inicial:</strong></td>

            <td>
                <asp:Label ID="labelmontoDeuda" runat="server"></asp:Label>
            </td>

            <td><strong>Deuda a la Fecha:</strong></td>

            <td>
                <asp:Label ID="labeldeudafinal" runat="server"></asp:Label>
            </td>

        </tr>

        <tr>     
            <td><strong>Estatus Actual:</strong></td>

            <td>
                <asp:Label ID="label1EstatusActual" runat="server"></asp:Label>
            </td>

            <td><strong></strong></td>

            <td>

            </td>

        </tr>


        </table>

    </fieldset>



    <!-- FIELDSET PARA "Abonar" hoy !-->

    <fieldset>

        <legend>Cambiar Estatus de la Cuenta Por Pagar:</legend>
   
        <table style="margin:0% auto auto 0%;" border="0" cellspacing="0" cellpadding="0" align="center" >
         
        <tr>


            <td class="style1" >
                <strong>Nuevo Estatus:</strong>

            </td>

            <td class="style2">
                <asp:DropDownList ID="dropDownListNuevoEstatus" runat="server" 
                    onselectedindexchanged="DropDownListNuevoEstatus_SelectedIndexChanged" 
                    AutoPostBack="True">

                    <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" >
                    </asp:ListItem>
                    <asp:ListItem Text="activo" Value="activo" Selected="False" >
                    </asp:ListItem>
                    <asp:ListItem Text="inactivo" Value="inactivo" Selected="False" >
                    </asp:ListItem>

                </asp:DropDownList>
                            
            </td>

            <td class="style3">
                <asp:Button ID="BotonAceptar" runat="server" Text="Aceptar" CssClass="button" onclick="BotonAceptar_Click" />                   
            </td>


        </tr>


        </table>

        
    </fieldset>


    
     
</asp:Content>
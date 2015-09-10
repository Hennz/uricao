<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AbonarCuentasPorPagar2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorPagar.AbonarCuentasPorPagar2" %>

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
           Detalle de la Cuenta por Pagar
        </h2>    
    </div>

    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"></asp:Label>
        <asp:Label ID="exito" runat="server" Text="Label" CssClass="Exito"></asp:Label>
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

        </table>

    </fieldset>



    <!-- FIELDSET PARA "Abonar" hoy !-->

    <fieldset>

        <legend>Cambiar Estado Cuenta Por Pagar:</legend>
   
        <table style="margin:0% auto auto 0%;" border="0" cellspacing="0" cellpadding="0" align="center" >
         
        <tr>


            <td >

                <div style="height:30px; width:130px; text-align:right; font-family:Verdana;font-size: 1.5em;">

                </div>            

            </td>

            <td><strong>Abono BsF.:</strong></td>

            <td>
                <asp:TextBox ID="textBox1" runat="server" Height="20px" Width="90px" MaxLength="20" Text="0"></asp:TextBox>
            </td>

            <td>
                <div style="height:30px; text-align:right; font-family:Verdana;font-size: 1.5em;">

                    <asp:Button ID="BotonAbonar" runat="server" Text="Abonar" CssClass="button" onclick="BotonAbonar_Click" />

                </div>            
            </td>


        </tr>


        </table>

    </fieldset>


    <!-- GRIDVIEW de ABONOS REALIZADOS YA HASTA LA FECHA (GIROS)  !-->

    <table style="width: 100%; margin-left:50px;">       
           
    <tr>
        <td>
        </td>

        <td class="style1" align="center" style="width: 591px">
            <br />
            <strong>Detalle de Pagos (Abonos):</strong>
        </td>

        <td style="width: 215px">
            &nbsp;
        </td>
    </tr>

    <tr>
            <td class="style19" align="center">
            &nbsp;
        </td>


        <td class="style1" align="center" style="width: 591px">
            <br />

             <asp:GridView ID="gridView2Abono" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" 
            HorizontalAlign="Center" Style="text-align: center" AllowPaging="True" PageSize="4" OnPageIndexChanging="GridView2Abono_PageIndexChanging" 
            OnSelectedIndexChanged="GridView2Abono_SelectedIndexChanged" OnRowCommand="GridView2Abono_RowCommand" Width="600px" CssClass="nada">


                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                         
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
        </td>

    </tr>

    </table>
    
     
</asp:Content>
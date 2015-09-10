<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarFactura.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.ConsultarFactura" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function CheckNumeric(e) {

            if (window.event) // IE 
            {
                if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8) {
                    event.returnValue = false;
                    return false;

                }
            }
            else { // Fire Fox
                if ((e.which < 48 || e.which > 57) & e.which != 8) {
                    e.preventDefault();
                    return false;

                }
            }
        }
     
    </script>
    <script type="text/javascript">
        $(function () {

            var pickerOpts = { dateFormat: "yy/mm/dd" };

            $("#<%= aTRangoInicio.ClientID  %>").datepicker(pickerOpts);
            $("#<%= aTRangoFinal.ClientID  %>").datepicker(pickerOpts);
        });

    </script>

    <style type="text/css">
        .style1
        {
            width: 111px;
        }
        .style2
        {
            width: 87px;
        }
    </style>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="superior" style="height:30px;">
        <h2>
           Consultar Facturas
        </h2> 
     </div>
           

    <div style="height:25px; text-align:center; font-family:Verdana;font-size: 1.5em;">

        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"    ForeColor="Red"></asp:Label>
        <asp:Label ID="exito" runat="server" Text="Label" CssClass="Exito"    ForeColor="Red"></asp:Label>

        <asp:RegularExpressionValidator ID="regularExpressionValidatorFechaEmision" runat="server" 
            ControlToValidate="aTRangoInicio" Display="Dynamic" 
            ErrorMessage="Error: Fecha Emisión en Formato no Válido" Font-Size="Large" 
            ForeColor="Red" 
            ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])" 
            ValidationGroup="1"></asp:RegularExpressionValidator>

        <asp:RegularExpressionValidator ID="regularExpressionValidatorFechaVencimiento" runat="server" 
            ControlToValidate="aTRangoFinal" Display="Dynamic" 
            ErrorMessage="Error: Fecha Vencimiento en Formato no Válido" Font-Size="Large" 
            ForeColor="Red" 
            ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
            ValidationGroup="1"></asp:RegularExpressionValidator>

    </div>




    <fieldset>

    <legend>Indique parámetros de busqueda:</legend>

    <table style="width: 100%; margin-left:10px;">

            <tr>
                <td>
                    <asp:RadioButton ID = "aRDFechas" runat = "server" Text = "Fechas" AutoPostBack="True" GroupName="a" Height="40px" Width = "80px" oncheckedchanged="ARDFechas_CheckedChanged">
                    </asp:RadioButton>
                </td>

                <td class="style1">Fecha Inicio</td>
                     <td><asp:TextBox ID = "aTRangoInicio" runat = "server" Width = "130px" Height="20px" Enabled="false" onkeypress="CheckNumeric(event);"></asp:TextBox></td>

                <td class="style1">Fecha Fin</td>
                    <td><asp:TextBox ID = "aTRangoFinal" runat = "server" Width = "130px" Height="20px" Enabled="false" onkeypress="CheckNumeric(event);"></asp:TextBox></td>       
            </tr>


            <tr>
                <td>
                    <asp:RadioButton ID = "aRDCi" runat = "server" Text = "Ci del Facturado" AutoPostBack="True" Height="40px" Width = "80px" GroupName="a" oncheckedchanged="ARDCi_CheckedChanged" >
                    </asp:RadioButton>
                </td>

                <td class="style1">
                    <asp:DropDownList ID="dropDownListCedula" runat="server" Enabled="false" Height="20px" Width="130px">
                        <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" > </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:RadioButton ID = "aRDNumero" runat = "server" Text = "Numero de factura" AutoPostBack="True" Height="40px" Width = "80px" GroupName="a" oncheckedchanged="ARDNumero_CheckedChanged">
                    </asp:RadioButton>
                </td>

                <td class="style1">
                    <asp:DropDownList ID="dropDownListNumeroFactura" Enabled="false" runat="server" Height="20px" Width="130px">
                        <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" > </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:RadioButton ID = "aRDTodos" runat = "server" 
                        Text = "Ver todas" Height="40px" Width = "85px" AutoPostBack="True" 
                        GroupName="a" oncheckedchanged="ARDTodos_CheckedChanged">
                    </asp:RadioButton>
                </td>
            </tr>



            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button class="button" ID="aBBuscar" text="BUSCAR" runat ="server" onClick="ABBotonBuscar_Click">
                    </asp:Button>
                </td>
            </tr>
      </table>


    </fieldset>





        <table align = "center">
            <tr>
                <td>
                    <asp:GridView ID="gridViewFactura" runat="server" AutoGenerateColumns="true" 
                                    Style="text-align: center" CellPadding="4"  GridLines="None" 
                        Width="600px" HorizontalAlign="Right"
                                                AllowPaging="True" PageSize="4" 
                        OnRowCommand="GridViewFactura_RowCommand"
                        OnPageIndexChanging="GridViewFactura_PageIndexChanging" >
                        <HeaderStyle BackColor="#1d60ff"  ForeColor="White" />
                        <FooterStyle BackColor="#1d60ff"  ForeColor="White" />
                        <PagerStyle BackColor="#1d60ff" ForeColor="White" HorizontalAlign="Center" />

                        <Columns>
                            <asp:ButtonField ButtonType="Image" HeaderText="Buscar" ImageUrl="~/Presentacion/Imagenes/Buscar.png" Text="Botón" CommandName="BotonTablaClick"/>
                        </Columns>
                    </asp:GridView>
                </td>

            </tr>
        </table>

</asp:Content>
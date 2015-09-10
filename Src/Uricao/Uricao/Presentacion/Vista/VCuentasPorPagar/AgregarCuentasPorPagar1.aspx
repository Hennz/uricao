<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarCuentasPorPagar1.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorPagar.AgregarCuentasPorPagar1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
    $(function () {
        $("#datepicker").datepicker();
    });
    </script>

<script type="text/javascript">
    $(function () {

        var pickerOpts = { dateFormat: "yy/mm/dd" };

        $("#<%= TextBox1FechaEmision.ClientID  %>").datepicker(pickerOpts);
        $("#<%= TextBox2FechaVencimiento.ClientID  %>").datepicker(pickerOpts);

    });

   </script>

    <style type="text/css">
        .style1
        {
            width: 219px;
        }
        .style2
        {
            width: 141px;
        }
        .style3
        {
            width: 162px;
        }
        .style4
        {
            width: 160px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior" style="height:30px;">
        <h2>
           Agregar una Cuenta por Pagar
        </h2>    
    </div>

    <div style="height:25px; text-align:center; font-family:Verdana;font-size: 1.5em;">

        <asp:RegularExpressionValidator ID="regularExpressionValidatorFechaEmision" runat="server" 
            ControlToValidate="TextBox1FechaEmision" Display="Dynamic" 
            ErrorMessage="Error: Fecha Emisión en Formato no Válido" Font-Size="Large" 
            ForeColor="Red" 
            ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])" 
            ValidationGroup="1"></asp:RegularExpressionValidator>

        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"    ForeColor="Red"></asp:Label>
       

        <asp:CompareValidator ID="validatorCompareDoubleTypeMonto" ControlToValidate="TextBox2Monto" ForeColor="Red" Type="Double" Display="Dynamic" Operator="DataTypeCheck"
        ErrorMessage="Error: Número de Monto no válido." runat="server">
        </asp:CompareValidator>

        <asp:Label ID="exito" runat="server" Text="Label" CssClass="Exito"    ForeColor="Red"></asp:Label>

        <asp:RegularExpressionValidator ID="regularExpressionValidatorFechaVencimiento" runat="server" 
            ControlToValidate="TextBox2FechaVencimiento" Display="Dynamic" 
            ErrorMessage="Error: Fecha Vencimiento en Formato no Válido" Font-Size="Large" 
            ForeColor="Red" 
            ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
            ValidationGroup="1"></asp:RegularExpressionValidator>

    </div>


    <fieldset>

        <!--legend>Agregar una Cuenta por Pagar:</legend !-->

        <table style="width: 100%; margin-left:0px;">
        
        <tr>
            <td class="style2"><strong>* Fecha Emisión:</strong></td>

            <td class="style3">
                <asp:TextBox ID="textBox1FechaEmision" runat="server" Height="20px" Width="91px" MaxLength="20" Text=""></asp:TextBox>            
                <br />
                <asp:RequiredFieldValidator ID="requiredFieldValidatorFechaEmision" runat="server" 
                    ControlToValidate="TextBox1FechaEmision" Display="Dynamic" 
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="138px"></asp:RequiredFieldValidator>
                
            </td>
            
            <td class="style4"><strong>* Fecha Vencimiento:</strong></td>

            <td>
                <asp:TextBox ID="textBox2FechaVencimiento" runat="server" Height="20px" Width="91px" MaxLength="20" Text=""></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="requiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox2FechaVencimiento" Display="Dynamic" 
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="127px"></asp:RequiredFieldValidator>
            </td>
        </tr>

 
        <tr>

            <td class="style2"><strong>* Razón Social / Empresa:</strong></td>

            <td class="style3">
                <asp:DropDownList ID="dropDownList3" runat="server" 
                    onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                    AutoPostBack="True" DataSourceID="SqlDataSource1" 
                    DataTextField="nombreProveedor" DataValueField="nombreProveedor">

                    <asp:ListItem Text="-- Seleccione --" Value="0"  >
                    </asp:ListItem>

                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnUricao %>" 
                    SelectCommand="SELECT [nombreProveedor] FROM [Proveedor]">
                </asp:SqlDataSource>
                <br />
                <asp:RequiredFieldValidator ID="requiredFieldValidatorRazonSocial" runat="server" 
                    ControlToValidate="DropDownList3" Display="Dynamic" InitialValue="0"
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="138px"></asp:RequiredFieldValidator>

            </td>

            <td class="style4"><strong>* Banco:</strong></td>

            <td>
                <asp:DropDownList ID="dropDownList4" runat="server" 
                    onselectedindexchanged="DropDownList4_SelectedIndexChanged" 
                    AutoPostBack="True" DataSourceID="SqlDataSource3" 
                    DataTextField="nombreBanco" DataValueField="nombreBanco">

                    <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" >
                    </asp:ListItem>

                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnUricao %>" 
                    SelectCommand="SELECT [nombreBanco] FROM [Banco]"></asp:SqlDataSource>
                <br />

                <asp:RequiredFieldValidator ID="requiredFieldValidatorBanco" runat="server" 
                    ControlToValidate="DropDownList4" Display="Dynamic" InitialValue="0"
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="138px"></asp:RequiredFieldValidator>

            </td>

        </tr>


        <tr>
            <td class="style2"><strong>* Nº Cuenta Bancaria:</strong></td>

            <td class="style3">
                <asp:DropDownList ID="dropDownList5" runat="server" 
                    onselectedindexchanged="DropDownList5_SelectedIndexChanged" 
                    DataSourceID="SqlDataSource2" DataTextField="numeroCuenta" 
                    DataValueField="numeroCuenta">

                    <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" >
                    </asp:ListItem>

                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnUricao %>" 
                    SelectCommand="SELECT [numeroCuenta] FROM [Cuenta_Bancaria]">
                </asp:SqlDataSource>

                <br />

                <asp:RequiredFieldValidator ID="requiredFieldValidatorNroCuentaBancaria" runat="server" 
                    ControlToValidate="DropDownList5" Display="Dynamic" InitialValue="0"
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="138px"></asp:RequiredFieldValidator>

            </td>
             
            <td class="style4"><strong>* Tipo de Pago:</strong></td>

            <td>
                <asp:DropDownList ID="dropDownList6" runat="server">

                    <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" ></asp:ListItem>
                    <asp:ListItem>credito</asp:ListItem>
                    <asp:ListItem>contado</asp:ListItem>

                </asp:DropDownList>

                <br />

                <asp:RequiredFieldValidator ID="requiredFieldValidatorTipoPago" runat="server" 
                    ControlToValidate="DropDownList5" Display="Dynamic" InitialValue="0"
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="138px"></asp:RequiredFieldValidator>


            </td>

        </tr>

        <tr>
            <td class="style2"><strong>* Monto Total (BsF):</strong></td>

            <td class="style3">
                <asp:TextBox ID="textBox2Monto" runat="server" Height="20px" Width="91px" MaxLength="20" Text="0.00"></asp:TextBox>

                <br />
                <asp:RequiredFieldValidator ID="requiredFieldValidatorMonto" runat="server" 
                    ControlToValidate="TextBox2Monto" Display="Dynamic" InitialValue = "0.00"
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="132px"></asp:RequiredFieldValidator>

            </td>


            <td class="style4">
            </td>

            <td>
            </td>
        </tr>

        </table>


        <table style="width: 100%; margin-left:0px;">
         
        <tr>
            <td class="style1" align="center" style="width: 250px"><strong>Detalle de la Deuda:</strong></td>

            <td style="width: 570px">
                <asp:TextBox ID="textBox3DetalleDeuda" runat="server" Width="495" TextMode="multiline" Rows="4" MaxLength="20" Text="Escriba el detalle de la Cuenta Por Pagar aquí."></asp:TextBox>
            </td>

        </tr>

        </table>

        <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">

            <asp:Button ID="BotonAceptar" runat="server" Text="Aceptar" CssClass="button" onclick="BotonAceptar_Click" />

        </div>

    </fieldset>

    
     
</asp:Content>
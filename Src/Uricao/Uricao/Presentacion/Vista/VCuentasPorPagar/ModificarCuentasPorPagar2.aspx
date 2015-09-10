<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarCuentasPorPagar2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorPagar.ModificarCuentasPorPagar2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    $(function () {
        $("#datepicker").datepicker();
    });
    </script>

      <script type="text/javascript">
          $(function () {

              var pickerOpts = { dateFormat: "yy/mm/dd" };

              $("#<%= fechaEmision.ClientID  %>").datepicker(pickerOpts);
              $("#<%= fechaVencimiento.ClientID  %>").datepicker(pickerOpts);
          });

    </script>
    <style type="text/css">
        .style1
        {
            width: 139px;
        }
        .style2
        {
            width: 140px;
        }
        .style3
        {
            width: 148px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height:25px; text-align:center; font-family:Verdana;font-size: 1.5em;">

        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" Visible="False"    ForeColor="Red"></asp:Label>
        <asp:Label ID="exito" runat="server" Text="Label" CssClass="Exito" Visible="False"   ForeColor="Red"></asp:Label>
    
        <asp:CompareValidator ID="validatorCompareDoubleTypeMonto" ControlToValidate="TextBox1" ForeColor="Red" Type="Double" Display="Dynamic" Operator="DataTypeCheck"
        ErrorMessage="Error: Número de Monto no válido."  Font-Size="X-Large" runat="server">
        </asp:CompareValidator>

        <asp:RegularExpressionValidator ID="regularExpressionValidatorFechaEmision" 
            runat="server" ControlToValidate="fechaEmision" Display="Dynamic" 
            ErrorMessage="ERROR: Formato  de Fecha Incorrecto" Font-Size="X-Large" 
            ForeColor="Red" 
            ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
        ValidationGroup="1"></asp:RegularExpressionValidator>


      <asp:RegularExpressionValidator ID="regularExpressionValidatorFechaVen" 
        runat="server" ControlToValidate="fechaVencimiento" Display="Dynamic" 
        ErrorMessage="ERROR: Formato  de Fecha Incorrecto" Font-Size="X-Large" 
        ForeColor="Red" 
        ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
        ValidationGroup="1"></asp:RegularExpressionValidator>

    </div>

    <fieldset>

        <legend>Detalle de la Cuenta por Pagar:</legend>

        <table style="margin:5% auto auto 4%;" border="0" cellspacing="0" cellpadding="0" align="center" >
         
        <tr>
            <td class="style2"><strong>Codigo Cuenta:</strong></td>

            <td>
                <asp:Label ID="labelcuentaCodigo" runat="server"></asp:Label>
            </td>

            <td class="style3"><strong>* Razón Social / Empresa:</strong></td>
            <td>
                <asp:Label ID="labelRazon" runat="server" Text="Label"></asp:Label>

                <asp:DropDownList ID="dropDownListRazon" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownListRazon_SelectedIndexChanged" 
                    DataSourceID="SqlDataSource2" DataTextField="nombreProveedor" 
                    DataValueField="nombreProveedor">

                    <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" >
                    </asp:ListItem>                    
                    
                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnUricao %>" 
                    SelectCommand="SELECT [nombreProveedor] FROM [Proveedor]">
                </asp:SqlDataSource>

                <br />
                <asp:RequiredFieldValidator ID="requiredFieldValidatorRazonS" runat="server" 
                    ControlToValidate="DropDownListRazon" Display="Dynamic" 
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="138px"></asp:RequiredFieldValidator>


            </td>
        </tr>

        <tr>
            <td class="style2"><strong>* Banco:</strong></td>

            <td>
                <asp:Label ID="labelBanco" runat="server" Text="Label"></asp:Label>

                <asp:DropDownList ID="dropDownListBanco" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownListBanco_SelectedIndexChanged" 
                    DataSourceID="SqlDataSource1" DataTextField="nombreBanco" 
                    DataValueField="nombreBanco">

                    <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" >
                    </asp:ListItem>
                    
                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnUricao %>" 
                    SelectCommand="SELECT [nombreBanco] FROM [Banco]"></asp:SqlDataSource>

                <br />
                <asp:RequiredFieldValidator ID="requiredFieldValidator1" runat="server" 
                    ControlToValidate="DropDownListBanco" Display="Dynamic" 
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="127px"></asp:RequiredFieldValidator>

            </td>
             
            <td class="style3"><strong>* Número Cuenta Bancaria:</strong></td>

            <td>
                <asp:Label ID="labelCuentaBancaria" runat="server" Text="Label"></asp:Label>

                <asp:DropDownList ID="dropDownListCuentaBancaria" runat="server" 
                    onselectedindexchanged="DropDownListCuentaBancaria_SelectedIndexChanged" 
                    DataSourceID="SqlDataSource3" DataTextField="numeroCuenta" 
                    DataValueField="numeroCuenta">

                    <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" >
                    </asp:ListItem>                    

                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnUricao %>" 
                    SelectCommand="SELECT [numeroCuenta] FROM [Cuenta_Bancaria]">
                </asp:SqlDataSource>

                <br />

                <asp:RequiredFieldValidator ID="requiredFieldValidatorNroCuentaBancaria" runat="server" 
                    ControlToValidate="DropDownListCuentaBancaria" Display="Dynamic" InitialValue="0"
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="138px"></asp:RequiredFieldValidator>

            </td>
        </tr>

        <tr>
            <td class="style2"><strong>* Tipo de Pago:</strong></td>

            <td>                
                <asp:Label ID="labelTipoPago" runat="server" Text="Label"></asp:Label>                

                <asp:DropDownList ID="dropDownListTipoPago" runat="server" 
                    onselectedindexchanged="DropDownListTipoPago_SelectedIndexChanged">
                    <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" >
                    </asp:ListItem>
                    <asp:ListItem Value="1">contado</asp:ListItem>
                    <asp:ListItem Value="2">credito</asp:ListItem>

                </asp:DropDownList>

                                <br />

                <asp:RequiredFieldValidator ID="requiredFieldValidator2" runat="server" 
                    ControlToValidate="DropDownListTipoPago" Display="Dynamic" InitialValue="0"
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="138px"></asp:RequiredFieldValidator>

            </td>

            <td class="style3"><strong>
                <br />
                * Monto Inicial</strong></td>

            <td>
               <asp:TextBox ID="textBox1" runat="server"></asp:TextBox> 

                <br />
                <asp:RequiredFieldValidator ID="requiredFieldValidatorMonto" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" InitialValue = "0.00"
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="132px"></asp:RequiredFieldValidator>

            </td>             
        </tr>

        <tr>     
            <td class="style2"><strong>* Fecha Emision:</strong></td>

            <td>
                
                <asp:TextBox ID="fechaEmision" runat="server"></asp:TextBox>
                <br />

                <asp:RequiredFieldValidator ID="requiredFieldValidator3" runat="server" 
                    ControlToValidate="fechaEmision" Display="Dynamic" 
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="138px"></asp:RequiredFieldValidator>

            </td>
            <td class="style3"><strong>* Fecha Vencimiento</strong></td>

              <td>
                <asp:TextBox ID="fechaVencimiento" runat="server"></asp:TextBox>
                <br />

                <asp:RequiredFieldValidator ID="requiredFieldValidator4" runat="server" 
                    ControlToValidate="fechaVencimiento" Display="Dynamic" 
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" 
                    Text="* Campo Obligatorio" Font-Size="X-Small" Width="138px"></asp:RequiredFieldValidator>

            </td>
        </tr>

        </table>

        <table style="width: 100%; margin-left:0px;">
         
        <tr>
            <td class="style1" align="center" style="width: 250px"><strong>Detalle de la Deuda:</strong></td>

            <td style="width: 570px">
                <asp:TextBox ID="textBox3DetalleDeuda" runat="server" Width="495px" 
                    TextMode="multiline" Rows="4" MaxLength="20" 
                    Text="Escriba el detalle de la Cuenta Por Pagar aquí." Height="61px"></asp:TextBox>
            </td>

        </tr>

        </table>


        <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">

            <asp:Button ID="BotonAceptar" runat="server" Text="Aceptar" CssClass="button" onclick="BotonAceptar_Click" />

        </div>

    </fieldset>
        
</asp:Content>
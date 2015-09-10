<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarCuentasPorPagar1.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorPagar.ModificarCuentasPorPagar1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    $(function () {
        $("#datepicker").datepicker();
    });
    </script>

     <script type="text/javascript">
         $(function () {

             var pickerOpts = { dateFormat: "yy/mm/dd" };

             $("#<%= algo.ClientID  %>").datepicker(pickerOpts);
             $("#<%= TextBox1.ClientID  %>").datepicker(pickerOpts);

         });

    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior" >
        <h2>
           Modificar Cuentas por Pagar
        </h2>    
    </div>


    <div style="height:25px; text-align:center; font-family:Verdana;font-size: 1.5em;">

        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="algo" Display="Dynamic" ErrorMessage="Error: Fecha Emisión en Formato no Válido"
            Font-Size="Large" ForeColor="Red" ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])" 
            ValidationGroup="1"></asp:RegularExpressionValidator>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
        ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Error: Fecha Vencimiento en Formato no Válido"
            Font-Size="Large" ForeColor="Red" ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])" 
            ValidationGroup="1"></asp:RegularExpressionValidator>

        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" Visible="False"    ForeColor="Red"></asp:Label>

        <asp:Label ID="exito" runat="server" Text="Label" CssClass="Exito" Visible="False"   ForeColor="Red"></asp:Label>

        </div>

       <fieldset>

        <legend>Buscar la Cuenta Por Pagar a Modificar:</legend>        


    <table style="width: 100%; margin-left:0px;">
         
    <tr>
        <td>Fecha Inicio</td>

        <td>
            <asp:TextBox ID="algo" runat="server" Height="20px" Width="130px"></asp:TextBox>

        </td>
            <td>Fecha Fin</td>

        <td>
            <asp:TextBox ID="textBox1" runat="server" Height="20px" Width="130px"></asp:TextBox>
        
        </td>
    </tr>
    <tr>
        <td>Razon Social</td>

        <td>
            <asp:DropDownList ID="dropDownList2" runat="server" 
                onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                DataSourceID="SqlDataSource1" DataTextField="nombreProveedor" 
                DataValueField="nombreProveedor">

                <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" >
                </asp:ListItem>

            </asp:DropDownList>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnUricao %>" 
                SelectCommand="SELECT [nombreProveedor] FROM [Proveedor]">
            </asp:SqlDataSource>

        </td>
             
        <td></td>
        <td></td>

    </tr>

    </table>

    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Button ID="defaultButton" runat="server" Text="Aceptar" 
        CssClass="button" onclick="defaultButton_Click" />
    </div>

    </fieldset>


    <table style="width: 100%; margin-left:50px;">       
           
    <tr>
        <td>
        </td>
        <td class="style1" align="center" style="width: 591px">
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
             <asp:GridView ID="gridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" align="center" Height="73px" Width="656px"  OnRowCommand="GridView1_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                         <Columns>
                         <asp:ButtonField HeaderText ="Ver Detalle" CommandName="Consultar" ButtonType="image" ImageUrl="~/Presentacion/Imagenes/Buscar.png"  />

                        </Columns>
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
<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AbonarCuentasPorPagar1.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorPagar.AbonarCuentasPorPagar1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    $(function () {
        $("#datepicker").datepicker();
    });
    </script>

      <script type="text/javascript">
          $(function () {

              var pickerOpts = { dateFormat: "yy/mm/dd" };

              $("#<%= fechai.ClientID  %>").datepicker(pickerOpts);
              $("#<%= fechaf.ClientID  %>").datepicker(pickerOpts);

        });

    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior" style="height:30px;">
        <h2>
           Abonar en una Cuenta por Pagar
        </h2> 
     </div>
           
    <div style="height:25px; text-align:center; font-family:Verdana;font-size: 1.5em;">

        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="fechai" Display="Dynamic" ErrorMessage="Error: Fecha Emisión en Formato no Válido"
            Font-Size="Large" ForeColor="Red" ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])" 
            ValidationGroup="1"></asp:RegularExpressionValidator>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
        ControlToValidate="fechaf" Display="Dynamic" ErrorMessage="Error: Fecha Vencimiento en Formato no Válido"
            Font-Size="Large" ForeColor="Red" ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])" 
            ValidationGroup="1"></asp:RegularExpressionValidator>

        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" Visible="False"    ForeColor="Red"></asp:Label>

        <asp:Label ID="exito" runat="server" Text="Label" CssClass="Exito" Visible="False"   ForeColor="Red"></asp:Label>

        </div>

    <fieldset>

    <legend>Buscar la Cuenta Por Pagar para Abonar:</legend>

    <table style="width: 100%; margin-left:10px;">
         
    <tr>
        <td>Fecha Inicio</td>
            <td><asp:TextBox ID="fechai" runat="server" Height="20px" Width="130px"></asp:TextBox></td>
        <td>Fecha Fin</td>
            <td><asp:TextBox ID="fechaf" runat="server" Height="20px" Width="130px"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Razon Social</td>
        <td>
            <asp:DropDownList ID="razonSocial" runat="server" Height="20px" Width="130px" 
                 DataTextField="nombreProveedor" 
                DataValueField="nombreProveedor" DataSourceID="SqlDataSource1">
                     <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" >
                    </asp:ListItem>
            </asp:DropDownList>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnUricao %>" 
                SelectCommand="SELECT [nombreProveedor] FROM [Proveedor]">
            </asp:SqlDataSource>
            
        </td>
             
    </tr>

    </table>

    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">

        <asp:Button ID="BotonAceptar" runat="server" Text="Aceptar" CssClass="button" onclick="BotonAceptar_Click" />

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

             <asp:GridView ID="gridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" 
            HorizontalAlign="Center" Style="text-align: center" AllowPaging="True" PageSize="4" OnPageIndexChanging="GridView1_PageIndexChanging" 
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand" Width="600px" CssClass="nada">


                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                         <Columns>
                         <asp:ButtonField HeaderText ="Ver Detalle" ButtonType="image" CommandName="BotonAceptar" ImageUrl="~/Presentacion/Imagenes/Buscar.png"  />

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
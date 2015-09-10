<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ActivarDesactivarCuentasPorPagar1.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorPagar.ActivarDesactivarCuentasPorPagar1" %>

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
    <div class="superior">
        <h2>
            Activar/Desactivar Cuentas por Pagar
        </h2>    
    </div>

    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" ForeColor="Red"></asp:Label>
        <asp:Label ID="exito" runat="server" Text="Label" CssClass="Exito" ForeColor="Red"></asp:Label>
    </div>


    <fieldset>

    <legend>Buscar la Cuenta Por Pagar para Activar/Desactivar:</legend>

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
            <asp:DropDownList ID="razonSocial" runat="server" DataSourceID="SqlDataSource1" 
                DataTextField="nombreProveedor" DataValueField="nombreProveedor">

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

            <asp:Button ID="BotonAceptar" runat="server" Text="Buscar" CssClass="button" onclick="BotonAceptar_Click" />
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
            <asp:GridView ID="gridView1" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="true" GridLines="None" HorizontalAlign="Center" Style="text-align: center" AllowPaging="True" PageSize="4" OnPageIndexChanging="GridView1_PageIndexChanging" 
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand" Width="600px" CssClass="nada">

                <AlternatingRowStyle BackColor="White" />

                <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#2461BF" />
                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />

                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerSettings PageButtonCount="4" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#4870BE" />

                        
                <Columns>
                    
                <asp:ButtonField HeaderText ="Ver Detalle" ButtonType="image" CommandName="BotonAceptar" ImageUrl="~/Presentacion/Imagenes/cambiar_estado.png"  />

                </Columns>

            </asp:GridView>
        </td>

    </tr>

    </table>
    
    
     

    
     
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarBanco.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PBancos.EditarBanco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style41
        {
            width: 22px;
        }
        .style43
        {
            width: 45px;
        }
        .style44
        {
            width: 14px;
        }
        .style45
        {
            width: 85px;
        }
        .style46
        {
            width: 16px;
        }
        .style47
        {
            width: 69px;
        }
        .style48
        {
            width: 12px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Operacion Fallida" CssClass="falla" Visible="false"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Operación Exitosa" CssClass="Exito" Visible="false"></asp:Label>
    </div>

    <div  style="float:left;">
     <fieldset style="width:740px; height:70px; margin:0px auto 0px auto;">
        <legend>Consultar Datos Bancarios</legend>     
            <table border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td rowspan="0" nowrap="nowrap" class="style44">
                    Buscar por:</td>
                <td rowspan="0" class="style41" nowrap="nowrap">
                    <asp:RadioButton ID="RadioButtonBanco" runat="server" 
                        GroupName="ConsultaDatosBancarios" Text="Banco:" oncheckedchanged="RadioButtonBanco_CheckedChanged1" 
                       />

                    </td>
                <td align="left" rowspan="0" class="style43" nowrap="nowrap">
                    <asp:DropDownList ID="comboBoxBanco" runat="server">
                        <asp:ListItem Value="0">Banesco</asp:ListItem>
                        <asp:ListItem Value="1">Mercantil</asp:ListItem>
                        <asp:ListItem Value="2">Venezuela</asp:ListItem>
                        <asp:ListItem Value="3">Todos</asp:ListItem>
                    </asp:DropDownList>

                    </td>
              
                <td align="left" rowspan="1" nowrap="nowrap" class="style45">
                    <asp:RadioButton ID="RadioButtonTipoCuenta" runat="server" 
                        GroupName="ConsultaDatosBancarios" Text="Tipo de Cuenta" 
                        oncheckedchanged="RadioButtonTipoCuenta_CheckedChanged" />
                    
                    </td>
              
                <td rowspan="0" nowrap="nowrap" class="style46">
                    <asp:DropDownList ID="DropDownListTipoCuenta" runat="server" Width="87px">
                        <asp:ListItem Value="0">Corriente</asp:ListItem>
                        <asp:ListItem Value="1">Ahorro</asp:ListItem>
                    </asp:DropDownList>

                    </td>
              
                <td rowspan="0" class="style47" nowrap="nowrap">
                    <asp:RadioButton ID="RadioButtonConsultaCompleta" runat="server" 
                        GroupName="ConsultaDatosBancarios" Text="Todos" 
                        oncheckedchanged="RadioButtonConsultaCompleta_CheckedChanged"/>

                </td>
              
                <td rowspan="0" nowrap="nowrap" class="style48">
                <asp:Button ID="botonBuscarBanco" runat="server" Text="Buscar" CssClass="button" onclick="defaultButton_Click"/>

                </td>
              
            </tr>
            </table>  
                           
        </fieldset><br />

            <asp:GridView ID="GridViewConsultarBanco" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" 
                ForeColor="#333333" 
                GridLines="None" PageSize="2" ViewStateMode="Enabled" Visible="False" 
                CaptionAlign="Bottom" HorizontalAlign="Center" 
                onselectedindexchanged="GridViewConsultarBanco_SelectedIndexChanged" 
                Width="700px" Height="193px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ButtonType="Image" HeaderText="Detalle" SelectImageUrl="~/Presentacion/Imagenes/Buscar.png" ShowSelectButton="True" />
                    <asp:BoundField DataField="nomBanco" HeaderText="Banco" SortExpression="NroCuentaBanco"  />
                    <asp:BoundField DataField="NroCuentaBanco" HeaderText="Tipo de Cuenta" SortExpression="NroCuentaBanco" />
                    <asp:BoundField DataField="TipoCuentaBanco" HeaderText="Numero de Cuenta" SortExpression="TipoCuentaBanco" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView> 
             
            

    </div>
     
</asp:Content>

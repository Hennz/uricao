<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ActivarDesactivarBanco.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PBancos.ActivarDesactivarBanco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="superior" >
    <h2>
        gestion de bancos
    </h2>
 
    </div>
    <div class="texto-label" style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Operacion Fallida" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Operación Exitosa" CssClass="Exito"></asp:Label>
    </div>
     <div  style="float:left;">
          <fieldset style="width:740px; height:80px; margin:0px auto 0px auto;">
        <legend>Activar/Desactivar Datos Bancarios</legend>        
            <table style="margin:0px auto 0px auto;  " border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Label">Banco:</asp:Label>
                </td>
                <td class="style1">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="0">Banesco</asp:ListItem>
                        <asp:ListItem Value="1">Mercantil</asp:ListItem>
                        <asp:ListItem Value="2">Venezuela</asp:ListItem>
                        <asp:ListItem Value="3">Todos</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style3">
                <asp:Button ID="defaultButton" runat="server" Text="Buscar" CssClass="button" onclick="defaultButton_Click"/>
                </td>
            </tr>
            </table>   <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnUricao %>" 
                onselecting="SqlDataSource1_Selecting" 
                SelectCommand="SELECT Banco.idBanco, Banco.nombreBanco, Banco.rifBanco, Cuenta_Bancaria.numeroCuenta FROM Banco INNER JOIN Cuenta_Bancaria ON Banco.idBanco = Cuenta_Bancaria.fkIdBanco">
            </asp:SqlDataSource><br /><br />  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="idBanco" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                GridLines="None" Height="200px" PageSize="6" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CheckBoxField HeaderText="Check" />
                    <asp:BoundField DataField="idBanco" HeaderText="idBanco" ReadOnly="True" 
                        SortExpression="idBanco" Visible="False" />
                    <asp:BoundField DataField="nombreBanco" HeaderText="Banco" 
                        SortExpression="nombreBanco" />
                    <asp:BoundField DataField="rifBanco" HeaderText="Rif" 
                        SortExpression="rifBanco" />
                    <asp:BoundField DataField="numeroCuenta" HeaderText="Numero Cuenta" 
                        SortExpression="numeroCuenta" />
                </Columns>
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
                    </fieldset>

          
            
 

    </div>
</asp:Content>

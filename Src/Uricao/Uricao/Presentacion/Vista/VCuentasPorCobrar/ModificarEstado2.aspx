<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarEstado2.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar.ModificarEstado2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" CssClass="falla" Text="Label"></asp:Label>
        <asp:Label ID="Exito" runat="server" CssClass="Exito" Text="Label"></asp:Label>
    </div>
    <div>
        <fieldset style="width:740px; height:210px; margin:0px auto 0px auto;">
            <legend>Datos Cuenta Cliente</legend>
             <table style="margin:0px auto 0px auto; height: 160px;" cellspacing="5px" border="0"  cellpadding="0" >
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label">Cédula:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelCedula" runat="server"></asp:Label> 
                    </td>
                    </tr>
                    <tr>
                
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Nombres:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelNombre" runat="server"></asp:Label>
                    </td>
                  </tr>
                  <tr>
                   
               
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Apellidos:"></asp:Label>
                        
                    </td>
                    <td>
                         <asp:Label ID="LabelApellidos" runat="server"></asp:Label>
                        
                    </td>
                   
                    </tr>

             <tr>
             <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Label ID="Label2" runat="server" Text="Label">Estado:</asp:Label>
                         <br />
                         <br />
                         <br />
                         <br />
                         <br />
                         <br />
                         <br />
                         <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label5" runat="server" Text="Label">Total:</asp:Label><br />
                         <br />
                    </td>
                     <td>
                         <asp:Label ID="estado" runat="server"></asp:Label>
                          <br />
                         <br />
                          <asp:DropDownList ID="estadoNuevo" runat="server" Height="20px" Width="130px">
                        <asp:ListItem Value="Activa">Activa</asp:ListItem>
                        <asp:ListItem Value="Por Pagar">Por Pagar</asp:ListItem>
                        <asp:ListItem Value="Pagada">Pagada</asp:ListItem>
                        <asp:ListItem Value="Desactivar">Desactivar</asp:ListItem>
                    </asp:DropDownList>
                         <br />
                         <br />
                    <asp:Button ID="defaultButton" runat="server" Text="Modificar" OnClick="defaultButton_Click" CssClass="button" />
                         <br />
                         <br />
                         <br />
                         <asp:Label ID="total" runat="server"></asp:Label>
                         
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                    </td>
                         
                  

             </tr>
             </table><br />
        </fieldset>
        
             <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" HorizontalAlign="Center" 
             onpageindexchanging="GridConsultar_PageIndexChanging" 
            onselectedindexchanged="GridConsultar_SelectedIndexChanged"
            
             PageSize="5" Width="720px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" CssClass="nada" Height="100px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField AccessibleHeaderText="Seleccion" ButtonType="Image" 
                    HeaderText="Detalle" SelectImageUrl="~/Presentacion/Imagenes/Buscar.png" 
                    ShowSelectButton="True" />
            </Columns>
            <EditRowStyle HorizontalAlign="Center" 
                VerticalAlign="Middle" BackColor="#2461BF" />
            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings PageButtonCount="4" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" 
                BackColor="#4870BE" />
        </asp:GridView>
    </div>
</asp:Content>

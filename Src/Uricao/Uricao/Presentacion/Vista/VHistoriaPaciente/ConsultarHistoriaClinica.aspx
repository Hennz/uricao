<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarHistoriaClinica.aspx.cs" Inherits="Uricao.Presentacion.Vista.VHistoriaPaciente.ConsultarHistoriaClinica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    fieldset tr
{
   padding: 0px;  
}
 fieldset td 
 {
    border-width: 1px;
    padding:0px;
    border:0px;
	border-style: inset;
	
 }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height: 30px; text-align: center; font-family: Verdana; font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" Visible="false"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito" Visible="false"></asp:Label>
    </div>
        <fieldset style="width: 700px; margin-left: 4%;">
            <legend>Consultar Historia Clinica</legend>
              <table style="margin:0px auto 0px auto; height: 160px;" border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
                <td style="text-align:center;">
                <label>Indique alguno de los datos del paciente a buscar</label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                CellPadding="5" CellSpacing="5" Width="650px" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Text="nombre" Value="1">Nombre</asp:ListItem>
                    <asp:ListItem Text="apellido" Value="2">Apellido</asp:ListItem>
                    <asp:ListItem Text="cedula" Value="3">Cédula</asp:ListItem>
                    <asp:ListItem Text="idHistoria" Value="4">Numero Historia</asp:ListItem>
                    <asp:ListItem Text="Todo" Value="5">Todo</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:center;">
                    <asp:TextBox ID="Busqueda" runat="server" Width="295px" Height="21px" Style="text-align: center"></asp:TextBox>
                      <br />
                      <asp:RegularExpressionValidator id="nameRegex" runat="server" 
                        ControlToValidate="Busqueda" 
                        ValidationExpression="^[a-zA-Z'.0-9\s]{1,50}$" 
                        ErrorMessage="Caracteres Invalidos">
                      </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="height:20px;">                  
                    <asp:HyperLink ID="agregar" runat="server" Text="agregar" 
                    NavigateUrl="/Presentacion/Vista/VHistoriaPaciente/AgregarAntecedente.aspx" Visible="false">
                    No se encontro la Historia click para agregarla
                    </asp:HyperLink>
                    
                </td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:center;">
                    <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button" 
                        onclick="Button1_Click"  />
                </td>
            </tr>
            </table>
            
        </fieldset>
        <br />
      
        <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CssClass="nada" HorizontalAlign="Center"
                OnSelectedIndexChanged="GridConsultar_SelectIndexChange"
                PageSize="5" SelectedIndex="0" 
        onrowdatabound="GridConsultar_RowDataBound" 
        onrowcommand="GridConsultar_RowCommand" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
                onpageindexchanging="GridConsultar_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField ButtonType="Image" HeaderText="Detalle"  CommandName="Detalle" 
                    ImageUrl="~/Presentacion/Imagenes/Buscar.png" Text="Detalle" />
                     <asp:ButtonField ButtonType="Image" HeaderText="Editar"  CommandName="Editar" 
                    ImageUrl="~/Presentacion/Imagenes/Editar.png" Text="Editar" />
                    <asp:ButtonField ButtonType="Image" HeaderText="Cambiar Estado"  CommandName="CambiarEstado" 
                    ImageUrl="~/Presentacion/Imagenes/cambiar_estado.png" Text="Cambiar Estado" />
                    <asp:BoundField DataField="Historia" HeaderText="Historia" />                    
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:ButtonField ButtonType="Image" 
                    HeaderText="Odontograma"  CommandName="Odontograma" 
                    ImageUrl="~/Presentacion/Imagenes/diente.png" Text="Ograma" />
                </Columns>
                <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" 
                    BackColor="#2461BF" />
                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerSettings PageButtonCount="4" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" 
                    BackColor="#4870BE" />
            </asp:GridView>
</asp:Content>

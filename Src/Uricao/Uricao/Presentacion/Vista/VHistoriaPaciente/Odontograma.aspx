<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Odontograma.aspx.cs" Inherits="Uricao.Presentacion.Vista.VHistoriaPaciente.Odontograma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var pickerOpts = { dateFormat: "dd/mm/yy" };
            $("#<%= date.ClientID  %>").datepicker(pickerOpts);
        });
    </script>
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
 <div style="height: 18px; text-align: center; font-family: Verdana; font-size: 1.4em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" Visible="false"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito" Visible="false"></asp:Label>
    </div>
   <div  style="float:left;">
        <fieldset style="width:700px; height:300px; margin-left:4%;">
        <legend>Secuencia</legend>                
          <asp:Image ID="Image1" runat="server" Height="125px" ImageUrl="~/Presentacion/Imagenes/odontograma.JPG" Width="580px" />  <br />
                            <asp:RegularExpressionValidator id="nameRegex" runat="server" 
                            ControlToValidate="date" 
                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" 
                            ErrorMessage="Formato invalido">
                                                    </asp:RegularExpressionValidator>
                      <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="observaciones" 
                            ValidationExpression="^[a-zA-Z'.0-9\s]{1,40}$" 
                            ErrorMessage="Solo texto">
                         </asp:RegularExpressionValidator>

        <table style="margin:10px auto 0 auto;" border="0" cellspacing="2px" cellpadding="0px">
            <tr style="padding:0px">
                <td >
                    <asp:Label ID="Label5" runat="server" Text="Label">Fecha</asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="date" runat="server"></asp:TextBox>
                </td>
                  <td style="text-align:right;">
                    <asp:Label ID="Label6" runat="server" Text="Label">Medico</asp:Label>
                      </td>
                <td >
                    <asp:DropDownList ID="medico" runat="server" Height="20px" Width="120px">
                    </asp:DropDownList>
                    </td>

            <td colspan="2">
                    <asp:Label ID="Label2" runat="server" Text="Label">Pieza:</asp:Label>
                </td>
               
 
                </tr>
               <tr >
                   <td>
                    
                    <asp:Label ID="Label7" runat="server" Text="Label">Diagnostico:</asp:Label>
                    
                </td>
                                <td style="text-align:left;">
                                  
                    <asp:DropDownList ID="diagnostico" runat="server" Height="20px" 
                        Width="120px">
                        <asp:ListItem Value="0"><--Seleccione--></asp:ListItem>
                        <asp:ListItem Value="1">Caries</asp:ListItem>                                      
                        <asp:ListItem Value="2">Obturacion</asp:ListItem>
                        <asp:ListItem Value="3">Corona</asp:ListItem>
                        <asp:ListItem Value="4">Tramo</asp:ListItem>
                        <asp:ListItem Value="5">Diente ausente</asp:ListItem>
                        <asp:ListItem Value="6">Diente a extraer</asp:ListItem>
                    </asp:DropDownList>
                   </td>
                   <td>
                    <asp:Label ID="Label4" runat="server" Text="Label">Tratamiento</asp:Label>
                   </td>
                <td style="text-align:left; ">
                                  
                    <asp:DropDownList ID="tratamiento" runat="server" Height="20px" Width="120px">
                    </asp:DropDownList>
                </td>
                <td>
                <asp:Label ID="Label1" runat="server" Text="Label">Rango:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="rango1" runat="server" Height="20px" 
                         Width="70px">
                         <asp:ListItem Text="Desde" Value="0"></asp:ListItem>
                    </asp:DropDownList>

   <asp:DropDownList ID="rango2" runat="server" Height="20px" 
                        Width="70px">
                        <asp:ListItem Text="Hasta" Value="0"></asp:ListItem>
                    </asp:DropDownList>

                
                </td>

               </tr>
               <tr>
                <td colspan="2">
                    <asp:Label ID="Label3" runat="server" Text="Label">Observaciones</asp:Label>
                </td><td colspan="5">
                    <asp:TextBox ID="observaciones" runat="server" Height="40px" Width="350px"
                       TextMode="MultiLine"  ></asp:TextBox>

                </td>
            </tr>
                <tr >
                <td colspan="6"  style="text-align:center" class="style2" align="right">
                <asp:Button ID="defaultButton" runat="server" Text="Agregar" CssClass="button" 
                        onclick="defaultButton_Click" />
                </td>             
            </tr>
            </table>          
    
     
        </fieldset>
        <br />
        <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CssClass="nada" HorizontalAlign="Center"
                PageSize="3" SelectedIndex="0" 
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
                    <asp:BoundField DataField="Secuencia" HeaderText="Secuencia" />                    
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Pieza" HeaderText="Pieza" />
                    <asp:BoundField DataField="Diagnostico" HeaderText="Diagnostico" />
                    <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
                    <asp:BoundField DataField="Doctor" HeaderText="Doctor" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
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
    </div>
</asp:Content>

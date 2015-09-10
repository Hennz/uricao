<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarHistoriaClinica.aspx.cs" Inherits="Uricao.Presentacion.Vista.VHistoriaPaciente.ModificarHistoriaClinica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var pickerOpts = { dateFormat: "dd/mm/yy" };
            $("#<%= date.ClientID  %>").datepicker(pickerOpts);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" Visible="false"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito" Visible="false"></asp:Label>
    </div>

<div  style="float:left;">
        <fieldset style="width:700px; height:280px; margin-left:4%;">
        <legend>Modificar Historia Clinica</legend>        
            <table style="margin:10px auto 0 auto; height: 221px; width: 416px;" border="0" 
                cellspacing="7px" cellpadding="3px" align="center">
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="Label1" runat="server" Text="Label" >Paciente:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ComboClientes" runat="server" Height="20px" Width="200px">
                    </asp:DropDownList>
                </td>
                                   
            </tr>
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="Label4" runat="server" Text="Label">Fecha Historia:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="date" runat="server" Height="21px" Width="127px"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator id="nameRegex" runat="server" 
                            ControlToValidate="date" 
                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" 
                            ErrorMessage="Formato invalido">
                        </asp:RegularExpressionValidator>
                    <br />
                </td>

            </tr>
             <tr>
                <td style="text-align:left;">
                    <asp:Label ID="Label3" runat="server" Text="Label">Observaciones</asp:Label>
                </td>
                <td >

                    <asp:TextBox ID="TObservaciones" runat="server" Height="60px" 
                        TextMode="MultiLine" Width="198px"></asp:TextBox><br />
                          <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="TObservaciones" 
                            ValidationExpression="^[a-zA-Z'.0-9\s]{1,40}$" 
                            ErrorMessage="Solo texto">
                         </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="Label2" runat="server" Text="Label">Antecedentes</asp:Label>
                </td>
                <td >
                     <asp:HyperLink ID="modificar" runat="server" Text="modificar antecedente" 
                    NavigateUrl="/Presentacion/Vista/VHistoriaPaciente/ModificarAntecedente.aspx">
                    Modificar Antecedente
                    </asp:HyperLink>     
                    
                </td>
               
            </tr>
            <tr >
                <td colspan="2"  style="text-align:center" class="style1">
              
                        <asp:Button ID="Button1" runat="server" Text="Editar" CssClass="button" 
                        onclick="defaultButton_Click" />       
                    
                 </td>    
                
            </tr>
            </table>          
        </fieldset>
         <br />
        
        <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CssClass="nada" HorizontalAlign="Center"
                PageSize="5" SelectedIndex="0" Width="600px" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Historia" HeaderText="Historia" />                    
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
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

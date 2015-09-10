<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarHistoriaClinica.aspx.cs" Inherits="Uricao.Presentacion.Vista.VHistoriaPaciente.AgregarHistoriaClinica" ValidateRequest="true" %>
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
        <legend>Agregar Historia Clinica</legend>        
            <table style="margin:10px auto 0 auto;" border="0" cellspacing="7px" cellpadding="3px" >
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="Label1" runat="server" Text="Label" >Seleccione Paciente:</asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ComboClientes" runat="server" Height="20px" Width="200px" 
                        onselectedindexchanged="ComboClientes_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                                   
            </tr>
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="Label4" runat="server" Text="Label">Fecha Historia:</asp:Label>
                </td>
                <td colspan="2" style="text-align:left;">
                    <asp:TextBox ID="date" runat="server"></asp:TextBox>
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
                <td colspan="2" >

                    <asp:TextBox ID="TObservaciones" runat="server" Height="60px" 
                        TextMode="MultiLine" Width="198px">
                        </asp:TextBox><br />
                          <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="TObservaciones" 
                            ValidationExpression="^[a-zA-Z'.0-9\s]{1,40}$" 
                            ErrorMessage="Solo texto">
                         </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td colspan="4">
                
                    <asp:HyperLink ID="agregar" runat="server" Text="agregar" 
                    NavigateUrl="/Presentacion/Vista/VHistoriaPaciente/Odontograma.aspx" Visible="false">
                    ¿Desea agregar Odontograma?
                    </asp:HyperLink>
                
                </td>
            </tr>
            <tr >
                <td colspan="4"  style="text-align:center">
                <asp:Button ID="defaultButton" runat="server" Text="Button" CssClass="button" 
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

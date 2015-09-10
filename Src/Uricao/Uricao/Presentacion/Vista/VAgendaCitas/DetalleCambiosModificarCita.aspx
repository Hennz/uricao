<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleCambiosModificarCita.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PAgendaCitas.DetalleCambiosModificarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function ValidNum(e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return (tecla > 64 && tecla < 91) || (tecla > 96 && tecla < 123) || (tecla == 127);
        }
        $(function () {
        var pickerOpts = { dateFormat: "dd/mm/yy" };
        $("#datepicker").datepicker(pickerOpts);
        $("#datepicker2").datepicker(pickerOpts);
        $("#datepicker3").datepicker(pickerOpts);
        $("#<%= aTBFecha.ClientID  %>").datepicker(pickerOpts);

    });
    </script>

    <style type="text/css">
        .style1
        {
            width: 168px;
        }
        .style2
        {
            width: 103px;
        }
        .style3
        {
            width: 141px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="texto-label" style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
<asp:Label ID="mensajeDeTransaccion" runat="server" Text="Text" ForeColor="Red" Visible="False">Mensaje</asp:Label></div>
        <fieldset style="width:740px; height:250px; margin:0px auto 0px auto;">
        <legend>Modificar Cita</legend>        
            <table style="margin:0px auto 0px auto; height: 160px;" border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
                <td class="style3">
                    <asp:Label ID="Label1" runat="server" Text="Label">Nombre medico:</asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="aTBNombre" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="Label">Apellido medico:</asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="aTBApellido" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td class="style3">
                    <asp:Label ID="Label5" runat="server" Text="Label">Tratamiento:</asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="aDDTratamiento" runat="server" Height="30px" Width="135px">
                         <asp:ListItem Value="0">Seleccione la opcion</asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
            </tr>

            <tr>
                 <td class="style3">
                      <asp:Label ID="LabelFecha" runat="server" Text="Label">Fecha:</asp:Label>
                </td>
               
                <td class="style2">
                     <asp:TextBox ID="aTBFecha" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    
                </td>
            </tr>

       
            <tr >
                <td colspan="2"  style="text-align:center; padding:10px">
                <asp:Button ID="defaultButton" runat="server" Text="Ver Disponibilidad" CssClass="button" 
                        onclick="defaultButton_Click" Height="23px" Width="140px" />
                </td>
            </tr>
            </table>          
        </fieldset>
  <br />
    
                  <asp:GridView ID="gridViewCitasDisponibles" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" align="center" Height="72px" Width="675px" 
                        OnRowCommand="GridViewCitasDisponibles_RowCommand" AllowPaging="True"  
                        onpageindexchanging="GridViewCitasDisponibles_PageIndexChanging" 
        PageSize="5" HorizontalAlign="Center" >
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerSettings PageButtonCount="4" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                         <Columns>
                         
                         <asp:ButtonField HeaderText ="Elegir" CommandName="Consultar" ButtonType="image" ImageUrl="~/Presentacion/Imagenes/Check.png"  />
                         
                        </Columns>
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>

</asp:Content>

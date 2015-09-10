<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarCita.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PAgendaCitas.ConsultarCita" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function ValidNum(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return (tecla > 64 && tecla < 91) || (tecla > 96 && tecla < 123) || (tecla ==127 );
    }

    $(function () {
        function ValidNum2(e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return (tecla > 47 && tecla < 58) || (tecla == 47);
        }

        var pickerOpts = { dateFormat: "dd/mm/yy" };
        $("#<%= aTBFecha.ClientID  %>").datepicker(pickerOpts);
        $("#<%= aTBFechaRangoInicio.ClientID  %>").datepicker(pickerOpts);
        $("#<%= aTBFechaRangoFin.ClientID  %>").datepicker(pickerOpts);

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
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="texto-label" style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
    <asp:Label ID="mensajeDeTransaccion" runat="server" Text="Text" ForeColor="Red" Visible="False">Mensaje</asp:Label>
       
    </div>

 <fieldset style="width:740px; height:260px; margin:0px auto 0px auto;">
        <legend>Consultar Cita</legend>        
           <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
             <td class="style1">
                     <asp:RadioButton ID="aRBMedico" runat="server" Text=" Por Datos del Medico" 
                         AutoPostBack="True" GroupName="radioButtonsConsultarCita" 
                         oncheckedchanged="aRBMedico_CheckedChanged" />
                </td>
                <td class="style3">
                    <asp:Label ID="Label1" runat="server" Text="Label">Nombre medico:</asp:Label>
                </td>
                <td class="style2">
                    
                    <asp:TextBox ID="aTBNombre" runat="server" Height="20px" Width="130px"></asp:TextBox>
                       
                </td>
                
                <td class = "style2">
                    <asp:RequiredFieldValidator ID="aRFVnombre" runat="server" ControlToValidate="aTBNombre" 
                    ErrorMessage="Este Campo es Necesario" Display="Dynamic" />
                    <asp:FilteredTextBoxExtender ID="aFTBEnombre" runat="server"
                    TargetControlID="aTBNombre" FilterType="Custom, UppercaseLetters, LowercaseLetters" 
                    ValidChars = "!@#$%^&*())_+{}[];',. "/>
                </td>
                    
                
            </tr>
            <tr>
                <td class ="style1">
                </td>
                <td class="style3">
                    
                    <asp:Label ID="Label2" runat="server" Text="Label">Apellido medico:</asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="aTBApellido" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
                <td class = "style2">
                    <asp:RequiredFieldValidator ID="aRFVapellido" runat="server" ControlToValidate="aTBApellido" 
                    ErrorMessage="Este Campo es Necesario" Display="Dynamic" />
                    <asp:FilteredTextBoxExtender ID="aFTBEapellido" runat="server"
                    TargetControlID="aTBApellido" FilterType="Custom, UppercaseLetters, LowercaseLetters" 
                    ValidChars = "!@#$%^&*())_+{}[];',. "/>
                </td>
            </tr>

            <tr>
                 <td class="style1">
                     <asp:RadioButton ID="aRBFecha" runat="server" Text=" Por Fecha Especifica:" 
                         AutoPostBack="True" GroupName="radioButtonsConsultarCita" 
                         oncheckedchanged="aRBFecha_CheckedChanged"/>
                </td>
                
                <td class="style2">                     
                     <asp:TextBox ID="aTBFecha" runat="server" Height="20px" Width="130px" ValidationGroup="Login"></asp:TextBox>
                </td>
                
           
              
            </tr> 
            <tr>
               <td class="style1">
                     <asp:RadioButton ID="aRBFechaRango" runat="server" Text=" Por rango de Fechas:" 
                         AutoPostBack="True" GroupName="radioButtonsConsultarCita" 
                         oncheckedchanged="aRBFechaRango_CheckedChanged" />
                </td>
              
                
                <td class = "style3">
                    <asp:Label ID="Label3" runat="server" Text="Desde: "></asp:Label>
                    <asp:TextBox ID="aTBFechaRangoInicio" runat="server" Height="20px" Width="130px" ValidationGroup="Login" ></asp:TextBox>
                </td>
               
                 <td class = "style3">
                    <asp:Label ID="Label4" runat="server" Text="Hasta: "></asp:Label>
                    <asp:TextBox ID="aTBFechaRangoFin" runat="server" Height="20px" Width="130px" ValidationGroup="Login" ></asp:TextBox>
                </td>
                
            
            </tr>
            <tr>
             <td class="style1">
                     <asp:RadioButton ID="aRBCiPaciente" runat="server" 
                         Text=" Por Cedula de paciente:" AutoPostBack="True" 
                         GroupName="radioButtonsConsultarCita" 
                         oncheckedchanged="aRBCiPaciente_CheckedChanged"/>
                </td>
                
               <td class="style3">
                    <asp:Label ID="Label5" runat="server" Text="Label">Cedula Paciente:</asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="aTBCiPaciente" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
                <td class = "style2">
                    <asp:RequiredFieldValidator ID="aRFVpaciente" runat="server" ControlToValidate="aTBCiPaciente" 
                    ErrorMessage="Este Campo es Necesario" Display="Dynamic" />
                    <asp:FilteredTextBoxExtender ID="aFTBEpaciente" runat="server"
                    TargetControlID="aTBCiPaciente" FilterType="Numbers"/>
                </td>
            
            </tr>
             
            <tr >
                <td colspan="6"  style="text-align:center">
                <asp:Button ID="defaultButton" runat="server" Text="Aceptar" CssClass="button" 
                        onclick="defaultButton_Click" Height="27px" Width="80px" />
                </td>
            </tr>
            </table>          
        </fieldset>
  
        
                    <br />
                       <asp:GridView ID="gridViewCitasDisponibles" runat="server" AllowPaging="True"  
            onpageindexchanging="GridViewCitasDisponibles_PageIndexChanging" 
            onselectedindexchanged="GridViewCitasDisponibles_SelectedIndexChanged" 
                         OnRowCommand="GridViewCitasDisponibles_RowCommand" PageSize="5" 
            Width="653px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Height="50px" HorizontalAlign="Center" >
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" />
                        <PagerSettings PageButtonCount="4" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />

                         <Columns>
                         <asp:ButtonField HeaderText ="Ver Detalle" CommandName="Consultar" ButtonType="image" ImageUrl="~/Presentacion/Imagenes/Buscar.png"  />


                        </Columns>
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>


</asp:Content>

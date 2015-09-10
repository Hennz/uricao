<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarEmpleado.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PTrabajadoresEmpleados.AgregarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function datepicker_onclick() {

        }

// ]]>
    </script>
    <style type="text/css">
        .style2
        {
            width: 187px;
            text-align: left;
        }
        .style3
        {
            width: 304px;
            text-align: right;
        }
        .style6
        {
            text-align: left;
        }
        .style7
        {
            width: 304px;
        }
        .style8
        {
            width: 304px;
            text-align: right;
            height: 166px;
        }
        .style9
        {
            width: 187px;
            text-align: left;
            height: 166px;
        }
        .style10
        {
            width: 808px;
            text-align: right;
            height: 166px;
        }
        .style11
        {
            text-align: left;
            height: 166px;
        }
        .style12
        {
            width: 304px;
            text-align: right;
            height: 23px;
        }
        .style13
        {
            width: 187px;
            text-align: left;

        }
        .style14
        {
            width: 808px;
            text-align: right;
        }
        .style15
        {
            text-align: left;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div align="center">
        <asp:Label ID="fallaAgregar" runat="server" CssClass="falla" Text="Label" Visible="false"></asp:Label>
        <asp:Label ID="ExitoAgregar" runat="server" CssClass="Exito" Text="Label" Visible="false"></asp:Label>
    </div>
    <div>
        <fieldset>
            <legend>Agregar Empleado</legend>
            <table align="center" border="0" cellpadding="10px" cellspacing="0">
                <tr>
                    <td class="style12">
                      Nombre:</td>
                        <td class="style13"><asp:TextBox ID="TextNombre" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style14">
                        Apellido:</td>
                    <td class="style15">
                        <asp:TextBox ID="TextApellido" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        Cedula de Identidad:</td>
                    <td class="style2">
                        <asp:TextBox ID="TextCedula" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style14">
                         &nbsp;Fecha de Nacimiento:</td>
                    <td class="style6">
                   
                        <asp:TextBox ID="TextFecha" Text="yyyy-mm-dd" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>                
                <tr>
                    <td class="style3">
                        <asp:Label ID="SexoAgr" runat="server" Text="Label">Sexo:</asp:Label>
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="DropDownListSexo" runat="server" Height="20px" Width="130px">
                            <asp:ListItem Value="0">Masculino</asp:ListItem>
                            <asp:ListItem Value="1">Femenino</asp:ListItem>                          
                        </asp:DropDownList>
                    </td>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style6">
                        &nbsp;</td>
              
                <td class="style7">
                </tr>
                <tr>
                    <td class="style3">
                        &nbsp;Telefono:</td>
                    <td class="style2">
                        <asp:TextBox ID="TextTelefono" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style14">
                        Correo Electronico:</td>
                    <td class="style6">
                        <asp:TextBox ID="TextCorreo" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        Cargo:</td>
                    <td class="style2">
                        <asp:DropDownList ID="DropDownListCargo" runat="server" Height="20px" Width="130px">
                           
                            <asp:ListItem Value="0">Administrador</asp:ListItem>
                            <asp:ListItem Value="1">Doctor</asp:ListItem>
                            <asp:ListItem Value="2">Asistente</asp:ListItem>
                            <asp:ListItem Value="3">Secretaria</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                     <td class="style14">
                        Sueldo:</td>
                    <td class="style6">
                        <asp:TextBox ID="TextSueldo" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>                    
                </tr>
                    <tr><td>     </td><td colspan="2"> 
                        <br />
                        <br />
                        Direccion: </td><td>    </td><td>     </td>  </tr>
                <tr>
                    <td class="style8">
                        <br />
<br/>
                      
                        </br>

                     </td>
                    <td class="style9">
                           
                        <br />  
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pais:<br />
<br/>
                       
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Estado:<br />
<br/>

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ciudad:<br />
                        <br />
&nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;Detalle Direccion:</td>
                    <td class="style10">
                   
                        <br />                      
                        
                        </br>
                        <br />
                        
                         <asp:DropDownList ID="DropDownListPais" runat="server" Height="20px" 
                            Width="130px" 
                            onselectedindexchanged="DropDownListPais_SelectedIndexChanged" 
                            AutoPostBack="True">
                            <asp:ListItem Value="0">Venezuela</asp:ListItem>
                          
                        </asp:DropDownList>
                          <br />
                       <br />
                       
                          <br />   
                       <asp:DropDownList ID="DropDownListEstado" runat="server" Height="20px" 
                            Width="130px" 
                            onselectedindexchanged="DropDownListEstado_SelectedIndexChanged" 
                            AutoPostBack="True">
                            
                            
                          
                        </asp:DropDownList>
                        <br />  
                        <br />  <br />

                           <asp:DropDownList ID="DropDownListCiudad" runat="server" Height="20px" 
                            Width="130px" AutoPostBack="True">
                        
                            
                          
                        </asp:DropDownList>
                        <br />  
                        <br /> <br />
                        <asp:TextBox ID="TextDireccion" runat="server" Height="20px" Width="130px"></asp:TextBox>
                        <br /><br />

                         <br/></br>
                       </td>
                    <td class="style11">   
                        <br />
                         <br />                 
                         
                         <br />  
                        <br />
                         <br />  
                    </td>
                </tr>
                
                
                <tr>
                    <td colspan="4" class="style6">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="AgregarButton" runat="server" CssClass="button" 
                            onclick="AgregarButton_Click" Text="Agregar" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>

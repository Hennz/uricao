<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.AgregarUsuario" %>
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
        .style5
        {
            width: 847px;
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
            width: 847px;
            text-align: right;
            height: 166px;
        }
        .style11
        {
            text-align: left;
            height: 166px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
        <h2>
            Agregar Usuario
        </h2>
    </div>
    <div>
        <asp:Label ID="fallaAgregar" runat="server" CssClass="falla" Text="Error al agregar el Empleado" 
            Visible="False"></asp:Label>
        <asp:Label ID="ExitoAgregar" runat="server" CssClass="Exito" Text="Empleado agregado con Exito" 
            Visible="False"></asp:Label>
    </div>
    <div>
        <fieldset>
            <legend>Agregar Usuario</legend>
            <table align="center" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="style3">
                        Nombre de Usuario:
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="NombreUsuarioTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        Constraseña:
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="PasswordTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    </tr>
                    <tr>
                    <td class="style3">
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Nombre:</td>
                        <td class="style2"><asp:TextBox ID="NombreAgrTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        Apellido:</td>
                    <td class="style6">
                        <asp:TextBox ID="ApellidoAgrTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        Cedula de Identidad:</td>
                    <td class="style2">
                        <asp:RadioButton ID="VenezolanoRadioButton" runat="server" Text="V" 
                            GroupName="Nacionalidad" Checked="True" />
                        <asp:RadioButton ID="ExtranjeroRadioButton" runat="server" Text="E" GroupName="Nacionalidad" />
                        <asp:TextBox ID="CiAgrTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style5">
                         &nbsp;Fecha de Nacimiento:</td>
                    <td class="style6">
                   
                        <input id="FechaNacimientoAgrdatepicker" size="20px" type="text" onclick="return datepicker_onclick()" />
                    </td>
                </tr>                
                <tr>
                    <td class="style3">
                        <asp:Label ID="SexoAgr" runat="server" Text="Label">Sexo:</asp:Label>
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="DropDownListSexoAgr" runat="server" Height="20px" Width="130px">
                            <asp:ListItem Value="0">Sexo</asp:ListItem>
                            <asp:ListItem Value="1">Masculino</asp:ListItem>
                            <asp:ListItem Value="3">Femenino</asp:ListItem>                          
                        </asp:DropDownList>
                    </td>
                    <td class="style5">
                        Fecha de Ingreso:</td>
                    <td class="style6">
                        <input id="FechaIngresoAgrdatePicker" size="20px" type="text" onclick="return datepicker_onclick()" />
                    </td>
                </tr>
                <td class="style7">Direccion:</td>
                <tr>
                    <td class="style8">
                        Pais:<br />
<br/>
                       
                        Estado:<br />
<br/>

                        Ciudad:<br />
<br/>
                      
                        Municipio:</br>

                     </td>
                    <td class="style9">
                            <asp:DropDownList ID="PaisDropDownList" runat="server" Height="20px" Width="130px">
                            <asp:ListItem Value="0">Venezuela</asp:ListItem>
                          
                        </asp:DropDownList>
                          <br />
                       
                       
                          <br />   
                       <asp:DropDownList ID="EstadoDropDownList" runat="server" Height="20px" Width="130px">
                            
                            
                          
                        </asp:DropDownList>
                        <br />  
                        <br />  

                           <asp:DropDownList ID="CiudadDropDownList" runat="server" Height="20px" Width="130px">
                        
                            
                          
                        </asp:DropDownList>
                        <br />
                        <br />  
                    <asp:TextBox ID="Municipio" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style10">
                   
                        Calle:<br />                      
                        
                        </br>Edif. o Casa: <br />
                        
                         </br> Detalle Direccion:<br />
                        
                       
                        </br>

                         <br/></br>

                    <td class="style11">   
                    <asp:TextBox ID="Calle" runat="server" Height="20px" Width="130px"></asp:TextBox>
                        <br />
                        <br />     
                         <asp:DropDownList ID="EdifCasaDropDownList" runat="server" Height="20px" 
                            Width="130px">
                             <asp:ListItem Value="0">Edificio</asp:ListItem>
                             <asp:ListItem Value="1">Casa</asp:ListItem>
                        </asp:DropDownList>
                         <br />                 
                         <br />  
                        <asp:TextBox ID="EdifAgrTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                        <br />
                         <br />  
                        <br />
                         <br />  
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        Numero de Telefono:</td>
                    <td class="style2">
                        <asp:TextBox ID="CodigoTelfTextBox" runat="server" Width="34px"></asp:TextBox>
                        <asp:TextBox ID="TelfAgrTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        Correo Electronico:</td>
                    <td class="style6">
                        <asp:TextBox ID="CorreoAgrTextBox" runat="server" Height="20px" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                          
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GenerarFacturaDatos.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.GenerarFacturaDatos" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

     <div class="superior" style="height:30px;">
       <h2>
            Generar Factura
       </h2>
    </div>
     
       <fieldset>
    <div style="height:25px; text-align:center; font-family:Verdana;font-size: 1.5em;">

        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"    ForeColor="Red"></asp:Label>

        <asp:Label ID="exito" runat="server" Text="Label" CssClass="Exito"    ForeColor="Red"></asp:Label>

    </div>

    <div >

        <table align ="center">
            <tr>
                <td>
                    <asp:Label class = "inline" ID = "Label1" runat = "server" Text = "Informacion Importante para la factura">
                    </asp:Label>
                </td>
            </tr>
            
        
        </table>
        &nbsp;
        &nbsp;
    </div>
    <div>
        <table align= "center">
            <tr>
                <td> 
                    <asp:Label class = "inline" ID = "aLNombre_Persona" runat = "server" Text = "RIF/CI y Nombre:">
                    </asp:Label>
                </td>

                <td>
                </td>                  

                <td class="style1">

                    <asp:DropDownList ID="aDNombre_Persona" runat="server" Height="20px" 
                        Width="184px">
                        <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" > </asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID = "aLNombreRazonError" runat = "server"  Text= "*" Visible="false" ForeColor = "Red">
                    </asp:Label>

                </td>
            </tr>


            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID = "aLFormatoRazon" runat = "server"  Text= ""  Font-Size ="Smaller">
                    </asp:Label>    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label class = "inline" ID = "aLCIPaciente" runat = "server" Text = "Cedula del Paciente">
                    </asp:Label>
                </td>
                <td>
                </td>

                <td class="style1">

                    <asp:DropDownList ID="aDPaciente" runat="server" Height="20px" 
                        Width="184px">
                        <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" > </asp:ListItem>
                    </asp:DropDownList>
                    

                    <asp:Label ID = "aLCIPacienteError" runat = "server"  Text= "*" Visible="false" ForeColor = "Red">
                    </asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID = "aLFormatoCI" runat = "server"  Text= "" Visible="false" Font-Size ="Smaller">
                    </asp:Label>    
                </td>
            </tr>
            
            
                
        </table>
        &nbsp;
        &nbsp;

    </div>
    <div>
        <table align = "center">
            <tr>
                <td>
                    <asp:Button class = "button" ID = "aBBotonContinuar" runat = "server" 
                        Text = "Continuar" onclick="aBBotonContinuar_Click">
                    </asp:Button>
                </td>
            </tr>
        </table>
        


    </div>  
     </fieldset> 
</asp:Content>

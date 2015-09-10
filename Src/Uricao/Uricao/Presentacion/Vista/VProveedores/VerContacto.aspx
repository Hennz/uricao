<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VerContacto.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PProveedores.VerProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="superior">

    <p>
      <%--Descripcion de accion (opcional)  --%>      
    </p>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" 
            Visible="False"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito" 
            Visible="False"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset  style="width:740px; height:210px; margin-left:0px auto 0px auto;">
        <legend>Ver Contacto</legend>        
            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0" align="center" >
            <tr>
                <td>
                    <asp:Label ID="LabelNombre" runat="server" Text="Label">Nombre:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxNombre" runat="server" Height="20px" Width="130px" 
                        Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelApellido" runat="server" Text="Label">Apellido:</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="TextBoxApellido" runat="server" Height="20px" Width="130px" 
                        Enabled="False"></asp:TextBox>
                 </td>
            </tr>
             <tr>
                 <td>
                    <asp:Label ID="LabelEmail" runat="server" Text="Label">Email:</asp:Label>
                 </td>
                 <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server" Height="20px" Width="130px" 
                         Enabled="False"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                 
            </tr>
            
            <tr >
                <td align="center">
                
                </td>
                <td colspan="2"  style="text-align:center;">
                <asp:Button ID="ButtonSiguiente" runat="server" Text="Finalizar" CssClass="button" 
                        onclick="ButtonSiguiente_Click"/>
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>

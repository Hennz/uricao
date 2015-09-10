<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VerProveedor.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PProveedores.VerProveedor1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" 
            Visible="False"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito" 
            Visible="False"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset style="width:740px; height:210px; margin-left:0px auto 0px auto;">
        <legend>Ver Proveedor</legend>        
            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0">
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
                    <asp:Label ID="LabelRif" runat="server" Text="Label">Rif:</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="TextBoxRif" runat="server" Height="20px" Width="130px" 
                        Enabled="False"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelContactos" runat="server" Text="Label">Contactos:</asp:Label>
                </td>
               
                    <td colspan="2"  style="text-align:left;">
                <asp:Button ID="ButtonContacto" runat="server" Text="Ver Contactos" CssClass="button" Width="130px" onclick="contactoButton_Click" 
                        />
                
                
            </tr>
            <tr >
                <td colspan="2"  style="text-align:center;">
                <asp:Button ID="defaultButton" runat="server" Text="Editar" CssClass="button" onclick="defaultButton_Click" 
                        />
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>


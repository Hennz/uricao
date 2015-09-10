<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarPrivilegios.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.RolesPrivilegios.AgregarPrivilegios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior">
    <h2>
       Roles y Privilegios
    </h2>
    <p>       
    </p>
    </div>
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset style="width:700px; height:380px; margin-left:4%;">
        <legend>Agregar Privilegio</legend>        
            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label">Nombre del Privilegio:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>\
            <tr >
                <td colspan="2"  style="text-align:center">
                <asp:Button ID="defaultButton" runat="server" Text="Aceptar" CssClass="button"  
                        />
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>

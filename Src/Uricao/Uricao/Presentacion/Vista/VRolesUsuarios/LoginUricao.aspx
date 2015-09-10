<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/LoginMaestro.Master" AutoEventWireup="true" CodeBehind="LoginUricao.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PRolesUsuarios.LoginUricao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="superior" style="height:60px">
    <h2>
       Bienvenido
    </h2>
    <p>
      Indique Contraseña y password para acceder         
    </p>
    </div>
    
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="" CssClass="Exito"></asp:Label>
    </div>
         <fieldset style="width:500px; height:350px; margin-left:15%;">
        <legend>Inicie sesion</legend>        
            <table style="margin:50px auto 0px auto; height: 160px; " border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
                <td>
                    Usuario:</td>
                <td>
                    <asp:TextBox ID="nombre" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Contraseña</td>
                <td>
                    <input id="Clave" type="password" runat="server" style="width:130px; height:19px;"/></td>
            </tr>
            <tr>
                <td>
                <asp:Button ID="LoginButton" runat="server" Text="Login" 
                        OnClick="onClickLoginButton" CssClass="button" />
                </td>
                <td>
                    <!--<asp:CheckBox ID="CheckBox1" runat="server" 
                        oncheckedchanged="CheckBox1_CheckedChanged" />Recordarme-->
                </td>
            </tr>
            </table>          
        </fieldset>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarProveedor.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PProveedores.AgregarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="superior">
    <h2>
      Proveedores
    </h2>
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
        <fieldset style="width:700px; height:380px; margin-left:4%;">
        <legend>Agregar Proveedor</legend>        
            <table style="margin:0px auto 0px auto; height: 160px; width: 99%;" border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
                <td>
                    <asp:Label ID="LabelNombre" runat="server" Text="Label">Nombre:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxNombre" runat="server" Height="20px" Width="130px" 
                        ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelRif" runat="server" Text="Label">Rif:</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="TextBoxRif" runat="server" Height="20px" Width="130px"></asp:TextBox>
                 </td>
            </tr>
            <tr>
               
                    <td>
                <asp:Button ID="ButtonContacto" runat="server" Text="Agregar Contacto" Width="170px" CssClass="button" onclick="ButtonContacto_Click" />
                   </td>
              </tr>
                
            
            </table>          
        </fieldset>
    </div>
</asp:Content>


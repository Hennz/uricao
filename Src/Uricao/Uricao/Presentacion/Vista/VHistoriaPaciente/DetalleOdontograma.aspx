<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleOdontograma.aspx.cs" Inherits="Uricao.Presentacion.Vista.VHistoriaPaciente.DetalleOdontograma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    fieldset tr
{
   padding: 0px;  
}
 fieldset td 
 {
    border-width: 1px;
    padding:0px;
    border:0px;
	border-style: inset;
	
 }
 .detalle
 {
     text-align:justify;
 }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" Visible="false"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito" Visible="false"></asp:Label>
    </div> 
   <div  style="float:left;">
        <fieldset style="width:700px; height:300px; margin-left:4%;">
        <legend>Secuencia</legend>                

        <div style="text-align:left">
  <p style="width:600px; margin:20px auto 0 auto; text-align:justify;">
                    <asp:Label ID="fecha" runat="server" Text="Label">Fecha</asp:Label><br />
                    <asp:Label ID="medico" runat="server" Text="Label">Medico</asp:Label>
                    <br />

                    
                    <asp:Label ID="pieza" runat="server" Text="Label">Pieza:   </asp:Label><br />
                    <asp:Label ID="diagnostico" runat="server" Text="Label">Diagnostico:</asp:Label>
                     <br />
                    <label>Tratamiento:</label><br />
                    <asp:Label ID="tratamiento" runat="server" Text="" CssClass="detalle"></asp:Label>
                    <br />
                  
                     <asp:Label ID="observaciones" runat="server" Text="Label" CssClass="detalle">Observaciones</asp:Label>
 </p>              
 <br />
     </div>
        </fieldset>
        </div>
</asp:Content>

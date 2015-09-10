<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GenerarFacturaDetalleCompleto.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.GenerarFacturaDetalleCompleto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <style type="text/css">
        #Text1
        {
            height: 95px;
            width: 138px;
        }
        #aTObservaciones
        {
            height: 43px;
            width: 374px;
        }
        </style>
    
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
    <div >
        <table align ="center">
            <tr>
                <td>
                    Detalle de la Factura</td>
            </tr>

        </table>
    </div>

     
     <div >
        <table align ="center">
            <tr>
                <td>
                    <asp:Label ID="label4" runat="server" Text="Fecha emision:"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="aLFechafactura" runat="server" Text="00/00/00"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label1" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="aLNombre" runat="server" Text="Nombre, apellido 1 apellido 2"></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="aLci" runat="server" Text="CI/RIF:"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="aLCIRIF" runat="server" Text="0000000000"></asp:Label>
                </td>
            </tr>
            </table>

      </div>
    <div>
    <table align ="center">
            <tr>
                <td>
                    Detalle de la Factura: 
                </td>
            </tr>
        </table>
    </div>

         
        <table align ="center">
          <asp:GridView ID="aGTratamiento" runat="server" AutoGenerateColumns="False" Style="text-align: center" CellPadding="4"  GridLines="None" Width="450px" Height="40px" HorizontalAlign="Center" AllowPaging="True" PageSize="3"  >
            <HeaderStyle BackColor="#1d60ff"  ForeColor="White" />
            <FooterStyle BackColor="#1d60ff"  ForeColor="White" />
            <PagerStyle BackColor="#1d60ff" ForeColor="White" HorizontalAlign="Center" />
              <Columns>
             
               <asp:BoundField DataField="Nombre" HeaderText="Concepto" />
               <asp:BoundField DataField="Duracion" HeaderText="Cantidad" />
               <asp:BoundField DataField="Costo" HeaderText="Monto" />
              
              </Columns>
            </asp:GridView>
          </table>
        
    

  
   <table align ="center">
            <tr>
                <td width="70px">
                    SubTotal:
                </td>
                <td>
                   Bs.F.:
                </td>
                <td>
                    
                    <asp:Label ID="aLSubtotal" runat="server" Text="0,00"></asp:Label>
                    
                </td>
            </tr>

             <tr>
                <td>
                    I.V.A.:
                </td>
                 <td>
                   Bs.F.:
                </td>
                <td>
                    
                    <asp:Label ID="aLIVA" runat="server" Text="0,00"></asp:Label>
                    
                </td>
            </tr>
             <tr>
                <td>
                   <b> Total:</b>
                </td>
                <td>
                  <b> Bs.F.:</b>
                </td>
                <td>
                    <asp:Label ID="aLTotal" runat="server" Text="0,00" Font-Bold  ></asp:Label> 
                </td>
            </tr>
        </table>
         
 
 
   
        <table align = "center">
            <tr>
                <td>
                    <asp:Button class = "button" ID = "aBBotonAceptar" runat = "server" 
                        Text = "Continuar" onclick="aBBotonAceptar_Click">
                    </asp:Button>
                </td>
            </tr>
        </table>
        
 </fieldset> 
    
   
</asp:Content>

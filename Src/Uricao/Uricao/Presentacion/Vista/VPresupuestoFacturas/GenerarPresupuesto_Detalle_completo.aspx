<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GenerarPresupuesto_Detalle_completo.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.GenerarPresupuesto_Detalle_completo" %>
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
    <div class="superior" style="height:30px;">
       <h2>
            Detalle Presupuesto
       </h2>
    </div>
     
       <fieldset>

       <table style="width: 100%; margin-left:10px;">


             <tr>
                <td width="150px">
                    <asp:Label ID="Label6" runat="server" Text="Presupuesto No.:"></asp:Label>
                </td>
                <td>
                </td>
                <td >
                    <asp:Label ID="aLNumeroPresupuesto" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Fecha emision:"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="aLFechaPresupuessto" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Nombre Paciente"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="aLNombre" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Cedula:"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="aLCedula" runat="server" Text=""></asp:Label>
                </td>
            </tr>
    </table>

    </fieldset>

        <table align ="center">
          <asp:GridView ID="aGPresupuesto" runat="server" AutoGenerateColumns="False" Style="text-align: center" CellPadding="4"  GridLines="None" Width="450px" Height="40px" HorizontalAlign="Center" AllowPaging="True" PageSize="3"  >
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

   <div>
   <table align ="center">
            <tr>
                <td width="150px">
                    SubTotal:
                </td>
                <td>
                   Bs.F.:
                </td>
                <td>
                    
                    <asp:Label ID="aLSubtotal" runat="server" Text=""></asp:Label>
                    
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
                    
                    <asp:Label ID="aLIVA" runat="server" Text=""></asp:Label>
                    
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
                    <asp:Label ID="aLTotal" runat="server" Text="" Font-Bold  ></asp:Label> 
                </td>
            </tr>
        </table>
         &nbsp;
        &nbsp;
   </div>

   <table align = "center">   
        <tr>
          <td>
           Observaciones:</td>
          <td>  </td>
          <td width="400">
              <asp:Label ID="lObservaciones" runat="server"  Text=""></asp:Label>
           </td>
           </tr>
        </table>
        &nbsp;
        &nbsp;
    <div>

        <table align = "center">
         <tr>
         
           <td>
             <asp:Button class = "button" ID = "aBBotonAceptar" runat = "server" Text = "Aceptar">
             </asp:Button>
            </td>
           </tr>
        </table>
        &nbsp;
        &nbsp;
     </div>
    
   
</asp:Content>

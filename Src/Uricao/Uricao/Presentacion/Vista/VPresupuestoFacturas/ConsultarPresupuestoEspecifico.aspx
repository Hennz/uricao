<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarPresupuestoEspecifico.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.ConsultarPresupuestoEspecifico" %>
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
  

    <fieldset>

    <legend>Detalle del Presupuesto:</legend>

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
                    <asp:Label ID="aLFechaPresupuesto" runat="server" Text=""></asp:Label>
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
          <asp:GridView ID="gridViewDetalle" runat="server" AutoGenerateColumns="True" Style="text-align: center" CellPadding="4"  
          GridLines="None" Width="500px"  HorizontalAlign="Center" AllowPaging="True" PageSize="4" >
            <HeaderStyle BackColor="#1d60ff"  ForeColor="White" />
            <FooterStyle BackColor="#1d60ff"  ForeColor="White" />
            <PagerStyle BackColor="#1d60ff" ForeColor="White" HorizontalAlign="Center" />
            </asp:GridView>
          </table>

<fieldset>
   <table align ="center">
            <tr>

            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
                <td width="150px">
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
            </td>
            <td>
            </td>
            <td>
            </td>

                <td width="150px">
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
            </td>
             <td>
            </td>
            <td>
            </td>
                <td>
                   <b> Total:</b>
                </td>
                <td>
                  <b> Bs.F.:</b>
                </td>
                <td>
                    <asp:Label ID="aLTotal" runat="server" Text="0,00"  ></asp:Label> 
                </td>
            </tr>


        <tr>

        <td>
            </td>
            <td>
            </td>
            <td>
            </td>
          <td>
           Observaciones:</td>
          <td>  </td>
          <td width="400">
              <asp:Label ID="aLObservaciones" runat="server"  Text=""></asp:Label>
           </td>
           </tr>


            <tr>
           <td>
            </td>
            <td>
            </td>
            <td>
            </td>
           <td>
             <asp:Button class = "button" ID = "Button1" runat = "server" Text = "Imprimir" a>
             </asp:Button>
            </td>
           </tr>

        </table>
</fieldset>


  

   
</asp:Content>

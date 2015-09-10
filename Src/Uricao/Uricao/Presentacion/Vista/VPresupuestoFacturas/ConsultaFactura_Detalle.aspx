<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultaFactura_Detalle.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.ConsultaFactura_Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>

    <legend>Detalle de la Factura:</legend>

    <table style="width: 100%; margin-left:10px;">

            <tr>
                <td> 
                    <asp:Label class = "inline" id = "aLNombre_Persona" runat = "server" Text = "Nombre del Responsable">
                    </asp:Label>
                </td>

                <td>
                    <asp:label id = "aLNombre_Persona_campo" runat = "server" Text ="">
                    </asp:label>
                </td>

            </tr>

            <tr>
                <td> 
                    <asp:Label class = "inline" id = "aLIdentificion" runat = "server" Text = "RIF/CI">
                    </asp:Label>
                </td>



                <td>
                    <asp:label id = "aLIdentificacion" runat = "server" Text ="">
                    </asp:label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label class = "inline" id ="aLDireccion" runat ="server" Text = "Direccion">
                    </asp:Label>
                </td>
            </tr>

            <tr>

                <td> 
                    <asp:Label class = "label.inline" id = "aLEstado" runat = "server" Text = "Estado">
                    </asp:Label>
                </td>


                <td>
                    <asp:label id = "aLEstado_campo" runat = "server" Width = "120px" Height="16px"></asp:label>
                </td>
            </tr>

            <tr>
                <td> 
                    <asp:Label class = "label.inline" id = "aLCiudad" runat = "server" Text = "Ciudad">
                    </asp:Label>
                </td>

                

                <td>
                    <asp:label id = "aLCiudad_campo" runat = "server" Width = "120px" Text="">
                    </asp:label>
                </td>
           </tr>
                        
           <tr>
                <td>
                    <asp:Label class = "label.inline" ID = "aLMunicipio" runat = "server" Text = "Municipio">
                    </asp:Label>
                </td>
               

                <td>
                    <asp:label ID = "aLMunicipio_campo"  Text="" runat = "server" Width = "120px">                                   
                    </asp:label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label class = "label.inline" ID = "Label1" runat = "server" Text = "Calle">
                    </asp:Label>
                </td>
                
                <td>
                    <asp:label ID = "aLCalle_campo"  Text="" runat = "server" Width = "120px">
                                    
                    </asp:label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label class = "label.inline" ID = "aLEdificio" runat = "server" Text = "Edificio">
                    </asp:Label>
                </td>
               

                <td>
                    <asp:label ID = "aLEdificio_campo" runat = "server" >
                    </asp:label>
                </td>
            </tr>
                        
            <tr>
                <td>
                    <asp:Label class = "inline" ID = "aLPaciente" runat = "server" Text = "Nombre del Paciente">
                    </asp:Label>
                </td>
               

                <td>
                    <asp:label ID = "aLPaciente_campo" runat = "server" >
                    </asp:label>
                </td>
            </tr>
                
        </table>
            
</fieldset>

       
   <table align ="center" >

            <tr>
               <td>
               
               </td>
            </tr>

            <tr>
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
                    <asp:Label ID="aLTotal" runat="server" Text="0,00"   ></asp:Label> 
                </td>
            </tr>

            <tr>
               <td>
               
               </td>
            </tr>

        </table>


        <table align ="center">
          <asp:GridView ID="gridViewDetalle" runat="server" AutoGenerateColumns="true" Style="text-align: center" CellPadding="4"  GridLines="None" Width="500px"  HorizontalAlign="Center" AllowPaging="True" PageSize="4"  >
            <HeaderStyle BackColor="#1d60ff"  ForeColor="White" />
            <FooterStyle BackColor="#1d60ff"  ForeColor="White" />
            <PagerStyle BackColor="#1d60ff" ForeColor="White" HorizontalAlign="Center" />
            </asp:GridView>
          </table>

</asp:Content>
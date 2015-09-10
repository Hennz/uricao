<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GenerarFacturaDetalle.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.GenerarFacturaDetalle" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
    

    <div>
        <table align = "center">
            <tr>
                <td>
                    <asp:Label  class = "inline" ID = "aLNombre_Detalle" runat = "server" text = "Detalle del Factura">
                    </asp:Label>
                </td>
            </tr>
        </table>
    </div>
    &nbsp;
    &nbsp;
    <div>
       
         <center>
             <asp:Label ID="aLAviso" runat="server" Text="Tratamiento no encontrado" Visible="false" ForeColor="Red" ></asp:Label>
         </center>
          <center>
             <asp:Label ID="aLAvisoAgregado" runat="server" Text="Tratamiento Agregado" Visible="false" ForeColor="Blue"></asp:Label>
         </center>
         <center>
             <asp:Label ID="aLMensaje_Error" runat="server" Text="Tratamiento Agregado" Visible="false" ForeColor="Red"></asp:Label>
         </center>
        
     
    </div>
    &nbsp;
    &nbsp;
    <div >
        <table align ="center">
            <tr>
                <td>
                    <asp:Label class = "inline" id = "label2" runat = "server" 
                        Text = "Buscar por: "></asp:Label>
                </td>
                <td>
                     
                    <asp:RadioButton ID="aRBNombre" runat="server" Text = "Nombre" 
                        oncheckedchanged="aRBNombre_CheckedChanged" GroupName= "B"
                        AutoPostBack = "True">
                    </asp:RadioButton>
                    <asp:RadioButton ID="aRBTodos" runat="server" Text = "Todos" 
                    oncheckedchanged="aRBTodos_CheckedChanged" GroupName= "B"
                        AutoPostBack = "True">
                    </asp:RadioButton>
                </td>
            </tr>
             
            <tr>
                <td width="100px"> 
                    <asp:Label class = "label.inline" id = "label3" runat = "server" 
                        Text = "Tratamiento:"  Visible ="false"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dropDownListTratamiento" runat="server" Visible="false">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button class = "button" ID = "aBBuscar" runat = "server" Text = "Buscar" 
                        onclick="aBBuscar_Click">
                    </asp:Button>
                
                </td>
            </tr>

        </table>
        <table align ="center">
            <tr>
                <td>

                

            
                
                </td>
            </tr>
        </table>
      </div>

      <div>
        <table align ="center">
          <asp:GridView ID="aGTratamiento" runat="server" AutoGenerateColumns="False" 
                Style="text-align: center" CellPadding="4"  GridLines="None" Width="350px" 
                Height="100px" HorizontalAlign="Center" AllowPaging="True" PageSize="6" 
                onrowcommand="aGTratamiento_RowCommand" 
                onselectedindexchanged="aGTratamiento_SelectedIndexChanged">
            <HeaderStyle BackColor="#1d60ff"  ForeColor="White" />
            <FooterStyle BackColor="#1d60ff"  ForeColor="White" />
            <PagerStyle BackColor="#1d60ff" ForeColor="White" HorizontalAlign="Center" />
              <Columns>
               <asp:ButtonField ButtonType="Image" HeaderText="Agregar" CommandName = "Agregar_Tratamiento" ImageUrl="~/Presentacion/Imagenes/Buscar.png" Text="Agregar" />
               <asp:BoundField DataField="Id" HeaderText="Codigo" />
               <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
               <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                  <asp:DropDownList ID="aDFCantidad" AutoPostBack="true" runat="server" DataTextField="Name" DataValueField="Name">
                    <asp:ListItem>x1</asp:ListItem>
                    <asp:ListItem>x2</asp:ListItem>
                    <asp:ListItem>x3</asp:ListItem>
                  </asp:DropDownList>
                </ItemTemplate>
               </asp:TemplateField>
              </Columns>
            </asp:GridView>
          </table>
    </div>
  
    <div>
        <center>
             <asp:Button class = "button" ID = "aBBotonContinuar" runat = "server" 
                   Text = "Aceptar" onclick="aBBotonContinuar_Click">
             </asp:Button>
          </center>
        
     </div>
     </fieldset>
</asp:Content>

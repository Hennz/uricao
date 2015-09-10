<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GenerarPresupuesto_Detalle.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.GenerarPresupuesto_Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 97px;
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

       <legend>Ingrese los siguientes datos:</legend>

       <table style="width: 100%; margin-left:10px;">

       
         <center>
             <asp:Label ID="aLAviso" runat="server" Text="Tratamiento no encontrado" Visible="false" ForeColor="Red" ></asp:Label>
         </center>
          <center>
             <asp:Label ID="aLAvisoAgregado" runat="server" Text="Tratamiento Agregado" Visible="false" ForeColor="Blue"></asp:Label>
         </center>
        
     </table>

        <table align ="center">
            <tr>
                <td>
                    <asp:Label class = "inline" id = "Label2" runat = "server" 
                        Text = "Buscar por :   "></asp:Label>

                </td>
                <td>
                 <asp:RadioButton ID="aRBNombre" Text="Nombre" oncheckedchanged="aRBNombre_CheckedChanged"
                  runat="server" GroupName="grupoDeRB" AutoPostBack="true" />
                 </td>
                
                 <td>
                 <asp:RadioButton ID="aRBTodos" Text="Todos"  oncheckedchanged="aRBTodos_CheckedChanged" 
                 runat="server" GroupName="grupoDeRB" AutoPostBack="true"/>
                </td>
            </tr>

          
            <tr>
                <td Width="100px"> 
                    <asp:Label class = "label.inline" id = "Label3" runat = "server" 
                        Text = "Tratamiento:" ></asp:Label>
                </td>

                <td>
                     <asp:DropDownList ID="dropDownListTratamiento" runat="server" Visible="false">
                    </asp:DropDownList>
                </td>
               
            </tr>

        </table>

     </fieldset>

     <table align ="center">
             
             <tr>

                <td></td>
                <td></td>
                <td></td>
                <td></td>
            
                <td>
                    <asp:Button class = "button" ID = "aBBuscar" runat = "server" Text = "Buscar" OnClick="aBBuscar_Click">
                    </asp:Button>               
                </td>

            </tr>
    </table>


        <table align ="center" style="height: 0px">
          <asp:GridView ID="aGTratamiento" runat="server" AutoGenerateColumns="False" 
                Style="text-align: center" CellPadding="4"  GridLines="None" Width="350px" 
                Height="100px" HorizontalAlign="Center" AllowPaging="True" PageSize="8" 
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

        <table align = "center">
         <tr>
           <td>
             <asp:Button class = "button" ID = "aBBotonContinuar" runat = "server" Text = "Aceptar" Enabled="false" OnClick="aBBotonContinuar_Click">
             </asp:Button>
            </td>
           </tr>
        </table>

</asp:Content>

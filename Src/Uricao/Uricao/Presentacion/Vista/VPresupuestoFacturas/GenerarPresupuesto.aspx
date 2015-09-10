<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GenerarPresupuesto.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.GenerarPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <style type="text/css">
        #Text1
        {
            height: 95px;
            width: 138px;
        }
        #aTObservaciones
        {
            height: 65px;
            width: 238px;
        }
        .style1
        {
            width: 248px;
        }
    </style>

      <script language="javascript" type="text/javascript">
          function CheckNumeric(e) {

              if (window.event) // IE 
              {
                  if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8) {
                      event.returnValue = false;
                      return false;

                  }
              }
              else { // Fire Fox
                  if ((e.which < 48 || e.which > 57) & e.which != 8) {
                      e.preventDefault();
                      return false;

                  }
              }
          }
     
    </script>
    
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
   <div class="superior" style="height:30px;">
       <h2>
            Generar Presupuestos
       </h2>
    </div>
     
       <fieldset>

       <legend>Ingrese los siguientes datos:</legend>
           
       <table style="width: 100%; margin-left:10px;">

            <tr>
                <td>
                   <asp:Label class = "label.inline" id = "aLCI_Persona" runat = "server" 
                        Text = "CI Paciente:"></asp:Label>
                </td>
                <td>
                
                    <asp:DropDownList ID="dDLTipoCi" runat="server">
                        <asp:ListItem Value="V">V</asp:ListItem>
                        <asp:ListItem Value="E">E</asp:ListItem>
                        <asp:ListItem Value="P">P</asp:ListItem>
                    </asp:DropDownList>
                
                </td>
                <td>
                    <asp:TextBox id = "aTCI_Persona" runat = "server" Text ="" Width="168px" 
                        onkeypress="CheckNumeric(event);" MaxLength="15"  ></asp:TextBox>
                </td>
                
            </tr>

            <tr>
                <td>
                    <asp:Label ID="aLValidarUsuario" runat="server" Visible="false" Text="El usuario no esta registrado" ForeColor="Red"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="alCampoObligatorio" runat="server" Visible="false" Text="Campo Obliatorio Ingresar Cedula" ForeColor="Red"></asp:Label>
                </td>
            </tr>
           
            <tr>

              <td>
               Observaciones:</td>
              <td>  </td>
              <td class="style1">
                    <asp:TextBox ID="aTObservaciones" runat="server"></asp:TextBox></td>
            </tr>
   
             <tr>
                <td></td>
                <td>
                    <asp:Button class = "button" ID = "aBBotonContinuar" runat = "server" Text = "Continuar" OnClick="aBBotonContinuar_click">
                     </asp:Button>
                </td>
           </tr>

        </table>
    
    </fieldset>


</asp:Content>

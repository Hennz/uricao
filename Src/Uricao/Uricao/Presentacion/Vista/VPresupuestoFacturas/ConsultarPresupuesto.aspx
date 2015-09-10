<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarPresupuesto.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PPresupuestoFacturas.ConsultarPresupuesto" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

    
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
    <script type="text/javascript">
        $(function () {

            var pickerOpts = { dateFormat: "yy/mm/dd" };

            $("#<%= aTRangoInicio.ClientID  %>").datepicker(pickerOpts);
            $("#<%= aTRangoFinal.ClientID  %>").datepicker(pickerOpts);
        });

    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="superior" style="height:30px;">
       <h2>
            Consultar Presupuestos
       </h2>
     </div>
     
       <fieldset>

       <legend>Indique parámetros de busqueda:</legend>

       <table style="width: 100%; margin-left:10px;">

            <tr>
 
                <td>
                    <asp:RadioButton ID = "aRDFechas" runat = "server" Text = "Fechas" AutoPostBack="True" GroupName="a" oncheckedchanged="aRDFechas_CheckedChanged">
                    </asp:RadioButton>
                </td>
               
                <td class="style1">Fecha Inicio</td>
                    <td><asp:TextBox ID = "aTRangoInicio" runat = "server" Width = "130px"></asp:TextBox></td>
                <td class="style1">Fecha Fin</td>
                    <td><asp:TextBox ID = "aTRangoFinal" runat = "server" Width = "130px"></asp:TextBox> </td>           
            </tr>

            <tr>
                <td>
                    <asp:RadioButton ID = "aRDCi" runat = "server" Text = "Ci del paciente" 
                        AutoPostBack="True" GroupName="a" oncheckedchanged="aRDCi_CheckedChanged" >
                    </asp:RadioButton>
                </td>
                <td class="style1">
                    <asp:DropDownList ID="dropDownListCedula" runat="server" Height="20px" Width="130px">
                        <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" > </asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>

            <tr>
                <td>
                    <asp:RadioButton ID = "aRDNumero" runat = "server" Text = "Numero Presupuesto" 
                        AutoPostBack="True" GroupName="a" oncheckedchanged="aRDNumero_CheckedChanged">
                    </asp:RadioButton>
                </td>
                <td class="style1">
                    <asp:DropDownList ID="dropDownListNumeroPresupuesto" runat="server" 
                        Height="20px" Width="130px">
                        <asp:ListItem Text="-- Seleccione --" Value="0" Selected="True" > </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>    
            <tr >
                <td>
                    <asp:RadioButton ID = "aRDTodos" runat = "server" 
                        Text = "Ver todos"  AutoPostBack="True" 
                        GroupName="a" oncheckedchanged="aRDTodos_CheckedChanged">
                    </asp:RadioButton>
                </td>
            </tr>
            <tr>
                <td>                  
                </td>
                <td>                  
                </td>
                <td>
                    <asp:Button class = "button" ID = "aBBuscar" text = " BUSCAR" runat = "server" onclick="aBBotonBuscar_Click">
                    </asp:Button>
                </td>
            </tr>
        </table>
        </fieldset>
        


          <asp:GridView ID="gridViewPresupuesto" runat="server" AutoGenerateColumns="true" Style="text-align: center" CellPadding="4"  GridLines="None" Width="500px"  HorizontalAlign="Center" AllowPaging="True" PageSize="4" 
          OnPageIndexChanging="gridViewPresupuesto_PageIndexChanging" OnRowCommand="PresupuestosRowCommand" >
            <HeaderStyle BackColor="#1d60ff"  ForeColor="White" />
            <FooterStyle BackColor="#1d60ff"  ForeColor="White" />
            <PagerStyle BackColor="#1d60ff" ForeColor="White" HorizontalAlign="Center" />
              <Columns>
               <asp:ButtonField ButtonType="Image" HeaderText="Buscar" ImageUrl="~/Presentacion/Imagenes/Buscar.png" Text="Botón" CommandName="BotonTablaClick"/>
              </Columns>
            </asp:GridView>
 
   
</asp:Content>

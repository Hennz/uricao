<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarCuentaCobrar.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PCuentasPorCobrar.ConsultarCuentaCobrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">

    function ValidNum(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return (tecla > 47 && tecla < 58);
    }

    $(function () {
        var pickerOpts = { dateFormat: "dd/mm/yy" };
        $("#<%= datepicker.ClientID  %>").datepicker(pickerOpts);
    });
    $(function () {
        var pickerOpts = { dateFormat: "dd/mm/yy" };
        $("#<%= datepicker1.ClientID  %>").datepicker(pickerOpts);
    });

    function datepicker_onclick() { 
    
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="superior" style="height: 60px">
    <h2>
        CONSULTAR CUENTA POR COBRAR
    </h2>
    <p>
        Se busca una cuenta por cedula y/o rango de fechas
    </p>
</div>
<div class="texto-label" style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
    <asp:Label ID="falla" runat="server" CssClass="falla" Text="Label" 
        Visible="False"></asp:Label>
    <asp:Label ID="Exito" runat="server" CssClass="Exito" Text="Label" 
        Visible="False"></asp:Label>
</div>
       <fieldset style="width:740px; height:210px; margin:0px auto 0px auto;">
        <legend>Buscar Cuenta</legend>
        <table style="margin:0px auto 0px auto; height: 160px;" cellspacing="5px" border="0" 
                cellpadding="0" align="center">   
            <tr>

                <td>

                    <asp:Label ID="Label1" runat="server" Text="Label">Cédula:</asp:Label>


                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" CellPadding="3" 
                        CellSpacing="10" RepeatDirection="Horizontal" RepeatLayout="Flow" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                        ontextchanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                         <asp:ListItem Value="V">V</asp:ListItem>
                          
                         <asp:ListItem>E</asp:ListItem>
                    </asp:RadioButtonList> 
                    </td>
                <td>
               


                    <asp:TextBox ID="TextCedula" runat="server" Height="20px" Width="130px" 
                        ontextchanged="TextCedula_TextChanged" ></asp:TextBox>
                </td>
            </tr>

            <tr>

             
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Label">Fecha Inicio:</asp:Label>
                </td>
                <td>
                     
                     <asp:TextBox ID="datepicker" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>


            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Label">Fecha Fin:</asp:Label>
                </td>
                <td>
                   
                    <asp:TextBox ID="datepicker1" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
            </tr>

            <tr >
                <td colspan="2"  style="text-align:center">
                    <asp:Button ID="aceptar" runat="server" CssClass="button"  Text="Aceptar" onclick="aceptar_Click"   
                    />
                </td>
            </tr>

            
            </table>
    </fieldset>
</asp:Content>

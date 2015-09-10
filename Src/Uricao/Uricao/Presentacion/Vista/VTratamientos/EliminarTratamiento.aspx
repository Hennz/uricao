<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="EliminarTratamiento.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PTratamientos.EliminarTratamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">

    function ValidNum(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return  (tecla > 47 && tecla < 58) || (tecla == 127) ;
    }


    function ValidString(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return  (tecla > 64 && tecla < 91) ||  (tecla > 96 && tecla < 123) || (tecla == 127) ;
    }

    </script>

 <fieldset style="margin-left:4%;">
    <legend>Activar/Desactivar Tratamiento</legend>
 
     <table style="margin:0px auto 0px auto; height: 160px;" border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
                <td class="style1">
                    <asp:Label ID="error" runat="server" CssClass="falla" Font-Bold="True"></asp:Label>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" CellPadding="5" CellSpacing="5" Width="484px" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem>Id</asp:ListItem>
                        <asp:ListItem>Estado</asp:ListItem>
                        <asp:ListItem>Nombre</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
             <td colspan="8" style="text-align:center;">
                <asp:TextBox ID="Busqueda" runat="server" Width="395px" Height="21px" 
                style="text-align: center" ontextchanged="Busqueda_TextChanged"></asp:TextBox>
            </td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:center;">
                    <asp:Button ID="Button1" runat="server" Text="Buscar" onclick="Button1_Click" />
                </td>
            </td>
            </table>
             <asp:GridView ID="GridViewTratamiento" runat="server" AutoGenerateColumns="False" 
            Style="text-align: center" CellPadding="4" GridLines="None" Width="600px" HorizontalAlign="Center"
            AllowPaging="True" PageSize="10" 
            OnSelectedIndexChanged="gridViewTratamiento_SelectedIndexChanged" 
            AllowSorting="True" OnRowCommand="GridViewTratamiento_RowCommand"
            OnPageIndexChanging="GridViewTratamiento_PageIndexChanging" 
            ShowFooter="true"
            >

            <HeaderStyle BackColor="#1d60ff"  ForeColor="White" />
            <FooterStyle BackColor="#1d60ff"  ForeColor="White" />
            <PagerStyle BackColor="#1d60ff" ForeColor="White" HorizontalAlign="Center" />

            <Columns>
                <asp:ButtonField ButtonType="Image" HeaderText="Cambiar Estado"  CommandName="Buscar"
                    ImageUrl="~/Presentacion/Imagenes/cambiar_estado.png" Text="Botón" />
                <asp:BoundField DataField="Id" HeaderText="Codigo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                
            </Columns>
        </asp:GridView>     
            </fieldset>
      
     
</asp:Content>

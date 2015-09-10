<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuarios.aspx.cs" Inherits="Uricao.Presentacion.Vista.VRolesUsuarios.PRolesUsuariosUsuarios.ConsultarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito"></asp:Label>
    </div>
    <div  style="float:left;">
        <fieldset style="width:700px; height:480px; margin-left:4%;">
        <legend>Consultar Usuarios</legend>        
            <table style="margin:0% auto auto 26%;" border="0" cellspacing="0" 
                cellpadding="0" align="center">
            <tr>
                <td>
                    Buscar Usuario:</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="False" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="130px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Buscar" runat="server" Text="Buscar" CssClass="button" onclick="Buscar_Click"  
                        />
                </td>
            </tr>
            </table>
            <asp:GridView ID="GridConsultar" runat="server" AllowPaging="True" HorizontalAlign="Center" 
            PageSize="3" 
            SelectedIndex="0" Width="700px" CellPadding="0" ForeColor="#333333" 
            GridLines="None" CssClass="nada" AutoGenerateColumns="False" 
                CaptionAlign="Bottom" Height="131px" Visible="False" 
                onPageIndexChanging="GridConsultar_PageIndexChanging"
                onselectedindexchanged="GridConsultar_SelectedIndexChanged"
                >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Image" 
                    HeaderText="Detalle" SelectImageUrl="~/Presentacion/Imagenes/Buscar.png" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="primerNombre" HeaderText="Nombre" />
                <asp:BoundField DataField="primerApellido" HeaderText="Apellido" />
                <asp:BoundField DataField="login" HeaderText="Usuario" />
                <asp:BoundField DataField="identificacion" HeaderText="Identificación" />
                <asp:BoundField DataField="rol.nombreRol" HeaderText="Rol" />
            </Columns>
            <EditRowStyle HorizontalAlign="Center" 
                VerticalAlign="Middle" BackColor="#2461BF" />
            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Height="50" Font-Italic="False" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" 
                BackColor="#4870BE" />
        </asp:GridView>
        </fieldset>
    </div>
</asp:Content>

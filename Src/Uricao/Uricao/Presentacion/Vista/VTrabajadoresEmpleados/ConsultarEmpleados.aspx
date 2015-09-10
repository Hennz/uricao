<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master"
    AutoEventWireup="true" CodeBehind="ConsultarEmpleados.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PTrabajadoresEmpleados.ConsultarEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div align="center">
        <asp:Label ID="fallaAgregar" runat="server" CssClass="falla" Text="Label" Visible="false"></asp:Label>
        <asp:Label ID="ExitoAgregar" runat="server" CssClass="Exito" Text="Label" Visible="false"></asp:Label>
    </div>
    <div>
        <fieldset style="width: 740px; height: 100px; margin-left: 0px auto 0px auto;">
            <legend>Buscar Empleados</legend>
            <table align="center" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Cedula:
                    </td>
                    <td>
                        <asp:TextBox ID="TextCedula" runat="server" Height="20px" Width="160px" 
                            TextMode="Number"></asp:TextBox>
                    </td>
                    <td>
                        Cargo:
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownCargo" runat="server" Height="20px" Width="160px">
                            <asp:ListItem Value="0">Seleccione un Cargo</asp:ListItem>
                            <asp:ListItem Value="Administrador">Administrador</asp:ListItem>
                            <asp:ListItem Value="Doctor">Doctor</asp:ListItem>
                            <asp:ListItem Value="Asistente">Asistente</asp:ListItem>
                            <asp:ListItem Value="Secretaria">Secretaria</asp:ListItem>
                            <asp:ListItem Value="Personal Odontologico">Personal Odontologico</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nombre:
                    </td>
                    <td>
                        <asp:TextBox ID="TextNombre" runat="server" Height="20px" Width="160px"></asp:TextBox>
                    </td>
                    <td>
                        Apellido:
                    </td>
                    <td>
                        <asp:TextBox ID="TextApellido" runat="server" Height="20px" Width="160px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; padding-top: 10px">
                        <asp:CheckBox ID="CheckInactivos" runat="server"></asp:CheckBox>
                        <asp:Label ID="LabelCheck" runat="server">Ver sólo empleados Inactivos</asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <td colspan="4" style="text-align: center; padding-top: 10px">
            <asp:Button ID="BotonBuscar" runat="server" CssClass="button" OnClick="BotonBuscar_Click"
                Text="Buscar" />
        </td>
        <br />
        <br />
        <asp:GridView ID="gridConsultar" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" Height="35px" CellPadding="4" ForeColor="#333333"
            GridLines="None" Style="text-align: center" Width="737px" PageSize="8" OnSelectedIndexChanged="GridConsultar_SelectIndexChanged"
            OnPageIndexChanging="gridConsultar_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField HeaderText="Detalle" SelectImageUrl="~/Presentacion/Imagenes/Buscar.png"
                    ShowSelectButton="True" ButtonType="Image" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" Width="70%" />
        </asp:GridView>
    </div>
</asp:Content>

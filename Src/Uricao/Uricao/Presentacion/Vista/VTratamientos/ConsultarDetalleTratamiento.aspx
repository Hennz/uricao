<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarDetalleTratamiento.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PTratamientos.ConsultarDetalleTratamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset style="width:740px; margin-left:0px auto 0px auto;">
   <legend>Consultar Detalle Tratamiento</legend>
   <asp:Label ID="error" runat="server" CssClass="falla" Font-Bold="True"></asp:Label>
<asp:Wizard ID="Wizard1"  runat="server" DisplaySideBar="False" Height="402px" 
        ActiveStepIndex="0"  
        StepPreviousButtonStyle-CssClass="button" 
        StartNextButtonStyle-CssClass="button" 
        StepNextButtonStyle-CssClass="button" 
        FinishCompleteButtonStyle-CssClass="button"
        FinishPreviousButtonStyle-CssClass="button"
        FinishDestinationPageUrl="~/Presentacion/Vista/VTratamientos/HomeTratamiento.aspx" 
        FinishCompleteButtonText="Finalizar" StepNextButtonText="Siguiente"
        StartNextButtonText="Siguiente" 
        FinishPreviousButtonText="Anterior" StepPreviousButtonText="Anterior">

<FinishCompleteButtonStyle CssClass="button"></FinishCompleteButtonStyle>

<FinishPreviousButtonStyle CssClass="button"></FinishPreviousButtonStyle>

<StartNextButtonStyle CssClass="button"></StartNextButtonStyle>

<StepNextButtonStyle CssClass="button"></StepNextButtonStyle>

<StepPreviousButtonStyle CssClass="button"></StepPreviousButtonStyle>

    <WizardSteps>
        <asp:WizardStep ID="WizardStep1" runat="server" Title="Paso 1">
    <br />

    <br />
    Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Nombre" 
        runat="server" Width="408px" Readonly="true" 
         ></asp:TextBox>
    <br />
    <br />
    Duración:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Duracion" runat="server" Width="102px" Readonly="true"></asp:TextBox>
    &nbsp;&nbsp; &nbsp;&nbsp; Costo:&nbsp;
    <asp:TextBox ID="Costo" runat="server" Width="61px" Readonly="true"></asp:TextBox>
    <br />
    <br />
    Descripción:&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <asp:TextBox ID="Descripcion" runat="server" Height="90px" Width="500px" textmode ="MultiLine" 
     Readonly="true"></asp:TextBox>
    <br />
<br />
    Explicación de como es realizado:<br />
    <asp:TextBox ID="Explicacion" runat="server" Height="90px" Width="500px" TextMode ="MultiLine" Readonly="true"></asp:TextBox>
    <br />
    <br />
<br />
<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
<br />
<br />
 </asp:WizardStep>
        <asp:WizardStep ID="WizardStep2" runat="server" Title="Paso 2">
        <legend>Tratamientos Asociados</legend> 
            <br />
            <br />
            <asp:Label ID="mensajetratamiento" runat="server"></asp:Label>
            <br />
            &nbsp;<asp:GridView ID="GridViewTratamiento" runat="server" AutoGenerateColumns="False" 
            Style="text-align: center" CellPadding="1" CellSpacing="1"  GridLines="None" 
            Width="600px" HorizontalAlign="Center" AllowPaging="True" PageSize="8" 
            OnSelectedIndexChanged="gridViewTratamiento_SelectedIndexChanged" 
            AllowSorting="True" OnRowCommand="GridViewTratamiento_RowCommand" 
                ShowFooter="true" OnPageIndexChanging="GridViewTratamiento_PageIndexChanging">

            <HeaderStyle BackColor="#1d60ff"  ForeColor="White" />
            <FooterStyle BackColor="#1d60ff"  ForeColor="White" />
            <PagerStyle BackColor="#1d60ff" ForeColor="White" HorizontalAlign="Center" />

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Codigo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
               
            </Columns>
        </asp:GridView>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep3" runat="server" Title="Paso 3">
        <legend>Productos Asociados</legend> 
            <asp:Label ID="mensajeproducto" runat="server"></asp:Label>

     <asp:GridView ID="GridViewProducto" runat="server" AutoGenerateColumns="False" 
            Style="text-align: center" CellPadding="4"  GridLines="None" Width="600px" HorizontalAlign="Center"
                        AllowPaging="True" PageSize="8" 
                OnSelectedIndexChanged="gridViewProducto_SelectedIndexChanged" 
                ShowFooter="true" 
                OnPageIndexChanging="GridViewProducto_PageIndexChanging" >
            <HeaderStyle BackColor="#1d60ff"  ForeColor="White" />
            <FooterStyle BackColor="#1d60ff"  ForeColor="White" />
            <PagerStyle BackColor="#1d60ff" ForeColor="White" HorizontalAlign="Center" />

            <Columns>
                <asp:BoundField DataField="IdImplemento" HeaderText="Codigo" />
                <asp:BoundField DataField="TipoProducto" HeaderText="Nombre" />
                <asp:BoundField DataField="PrioridadS" HeaderText="Prioridad" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            </Columns>
        </asp:GridView>
        </asp:WizardStep>
    </WizardSteps>
</asp:Wizard>
</fieldset>
</asp:Content>

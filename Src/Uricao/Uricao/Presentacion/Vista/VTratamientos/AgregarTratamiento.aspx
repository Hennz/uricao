<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarTratamiento.aspx.cs" Inherits="Uricao.Presentacion.PaginasWeb.PTratamientos.AgregarTratamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <br />
  
        <fieldset style="width:740px; margin:0px auto 0px auto;">
<legend>Agregar Tratamiento</legend>
<table align="center">
<asp:Label ID="error" runat="server" CssClass="falla" Font-Bold="True"></asp:Label>
</table>
 
    <asp:Wizard ID="Agregar"  runat="server" DisplaySideBar="False" Height="380px" 
         ActiveStepIndex="0" 
        
        FinishCompleteButtonText="Agregar" 
        StepNextButtonText="Siguiente" StartNextButtonText="Siguiente" 
        StepPreviousButtonStyle-CssClass="button" StartNextButtonStyle-CssClass="button" 
        StepNextButtonStyle-CssClass="button" FinishCompleteButtonStyle-CssClass="button"
        FinishPreviousButtonStyle-CssClass="button" FinishPreviousButtonText="Anterior" 
        StepPreviousButtonText="Anterior"  OnFinishButtonClick="Agregar_FinishButtonClick">
<FinishCompleteButtonStyle CssClass="button"></FinishCompleteButtonStyle>

<FinishPreviousButtonStyle CssClass="button"></FinishPreviousButtonStyle>

<StartNextButtonStyle CssClass="button"></StartNextButtonStyle>

<StepNextButtonStyle CssClass="button"></StepNextButtonStyle>

<StepPreviousButtonStyle CssClass="button"></StepPreviousButtonStyle>
    <WizardSteps>
        <asp:WizardStep ID="WizardStep1" runat="server" Title="Paso 1">
            <br />
                <br />

  
            Nombre*:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="NombreTratamiento" 
            runat="server" Width="430px"></asp:TextBox>
            <br />
            <br />
            Duración*:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Duracion" runat="server" Width="50px"></asp:TextBox>   
            &nbsp;Sesión (1 Sesion = 1 Hora) &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; Costo*:&nbsp;
            <asp:Label ID="Label1" runat="server" CssClass="falla" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="Costo" runat="server" Width="61px"></asp:TextBox>   Bs.
            <br />
            <br /><br /><br />
            Descripción*:&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:TextBox ID="Descripcion" runat="server" Height="90px" Width="500px" TextMode="MultiLine">
            </asp:TextBox>
            <br /><br />
            Explicación de como es realizado*:<br />
            <asp:TextBox ID="Explicacion" runat="server" Height="90px" Width="500px" TextMode="MultiLine"></asp:TextBox><br />
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep2" runat="server" Title="Paso 2">
      
        <legend>Asociar Productos</legend>
            <table style="width:100%; margin:0px auto 0px auto">
                <tr>
                    <td rowspan="2">
                        Sin Asociar<br />
                        <asp:ListBox ID="ProductoSAsociado" runat="server" Height="280px" 
                            Width="240px"></asp:ListBox>
                    </td>
                    <td>
                        <div ID="datosImplemento" runat="server">
                            <asp:Label ID="Label" runat="server" Text="Cantidad:"></asp:Label>
                            <br />
                            <asp:Label ID="cont" runat="server" Text="Primera" Visible="false"></asp:Label>
                            <br />
                            &nbsp;<asp:TextBox ID="Cantidad" runat="server" Width="25px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="Cantidad0" runat="server" Text="Prioridad:"></asp:Label>
                            <br />
                            <asp:DropDownList ID="Prioridad" runat="server">
                                <asp:ListItem Value="1">Alta</asp:ListItem>
                                <asp:ListItem Value="2">Baja</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td rowspan="2">
                        Asociado<br />
                        <asp:ListBox ID="ProductoAsociado" runat="server" Height="280px" 
                            Width="240px"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="AgregarProducto" runat="server" CssClass="button" 
                            OnClick="AgregarProducto_Click" Text="Agregar" />
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="EliminarProducto" runat="server" CssClass="button" 
                            OnClick="EliminarProducto_Click" Text="Eliminar" />
                    </td>
                    </tr>
            </table>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep3" runat="server" Title="Paso 3">
       <legend>Asociar Tratamientos</legend>
            <br />
            <br />
            <table style="width:100%; margin:0px auto 0px auto">
                <tr>
                    <td>
                        Sin Asociar<br />
                        <asp:ListBox ID="TratamientoSAsociado" runat="server" Height="280px" 
                            Width="260px" 
                            OnSelectedIndexChanged="AgregarTratamientoAsociado_Click"></asp:ListBox>
                    </td>
                    <td>
                        <asp:Button ID="AgregarTratamientoAsociado" runat="server" CssClass="button" 
                            Text="Agregar" OnClick="AgregarTratamientoAsociado_Click" />
                                      <br />
                        <br />
                        <br />
                        <asp:Button ID="EliminarTratamientoAsociado" runat="server" CssClass="button" 
                            Text="Eliminar" OnClick="EliminarTratamientoAsociado_Click" />
                    </td>
                    <td>
                        Asociado<br />
                        <asp:ListBox ID="TratamientoAsociado" runat="server" Height="280px" 
                            Width="260px" OnSelectedIndexChanged="EliminarTratamientoAsociado_Click"></asp:ListBox>
                    </td>
               </tr>
               
            </table>
                   
        </asp:WizardStep>
    </WizardSteps>
    </asp:Wizard>
  
    </fieldset>
</asp:Content>

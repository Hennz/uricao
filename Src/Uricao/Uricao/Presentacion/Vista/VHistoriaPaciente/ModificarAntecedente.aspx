<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarAntecedente.aspx.cs" Inherits="Uricao.Presentacion.Vista.VHistoriaPaciente.ModificarAntecedente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" Visible="false"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito" Visible="false"></asp:Label>
    </div>
    <div  style="float:left;">
    <asp:Label ID="Label19" runat="server" Text="Label" >A continuacion debera contestar una serie de preguntas</asp:Label>
        <fieldset style="width:99%; height:460px;">
        <legend>Cuestionario Antecedentes</legend>        
            <table style="margin:5px auto 0 auto;" border="0" cellspacing="3px" cellpadding="0">
            <tr>
                <td style="text-align:center;">
                    <asp:Label ID="Label1" runat="server" Text="Label" >¿Esta bajo tratamiento medico?</asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="horizontal">
                    <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>

                <td style="text-align:center;">
                       <asp:Label ID="Label7" runat="server" Text="Label" >A padecido de algun problema sanguineo</asp:Label>   
                </td>  
                        <td>
                                                      <asp:DropDownList ID="respuesta16" runat="server" Width="130px">
                                       <asp:ListItem Value="0"><--Seleccione--></asp:ListItem>
                                       <asp:ListItem Value="1">Ninguna</asp:ListItem>                                      
                                       <asp:ListItem Value="2">Hemofilia</asp:ListItem>
                                       <asp:ListItem Value="3">Anemia</asp:ListItem>
                                       <asp:ListItem Value="4">Leucemia</asp:ListItem>
                                  </asp:DropDownList>

                </td>                         
            </tr>
            <tr>
               <td style="text-align:center;">
                    <asp:Label ID="Label2" runat="server" Text="Label" >¿Toma actualmente algun medicamento?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="text-align:center;">
                    <asp:Label ID="Label6" runat="server" Text="Label" >A tenido reaccion alergica a:</asp:Label>
                </td>
                               <td style="text-align:left;">
                                   <asp:DropDownList ID="respuesta17" runat="server" Width="130px">
                                        <asp:ListItem Value="0"><--Seleccione--></asp:ListItem>
                                        <asp:ListItem Value="1">Ninguna</asp:ListItem>
                                        <asp:ListItem Value="2">Aspirina</asp:ListItem>
                                        <asp:ListItem Value="3">Yodo</asp:ListItem>
                                        <asp:ListItem Value="4">Merthiolate</asp:ListItem>
                                        <asp:ListItem Value="5">Otros</asp:ListItem>
                                        <asp:ListItem Value="6">Penicilina</asp:ListItem>
                                        <asp:ListItem Value="7">Anestecia</asp:ListItem>
                                   </asp:DropDownList>
                </td>
                                   
            </tr>
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="Label4" runat="server" Text="Label">¿Le han practicado intervencion?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="text-align:center;">                   
                    <asp:Label ID="Label5" runat="server" Text="Label" >Sufre o ha sugrido de:</asp:Label>
                </td>
                <td style="text-align:left;">
                            <asp:DropDownList ID="respuesta18" runat="server" Width="130px">
                            <asp:ListItem Value="0"><--Seleccione--></asp:ListItem>
                            <asp:ListItem Value="1">Ninguna</asp:ListItem>                          
                            <asp:ListItem Value="2">Diabetes</asp:ListItem>
                            <asp:ListItem Value="3">Enfermedades venereas</asp:ListItem>
                            <asp:ListItem Value="4">Problemas del Corazon</asp:ListItem>
                            <asp:ListItem Value="5">Tiroides</asp:ListItem>
                            <asp:ListItem Value="5">Hepatitis</asp:ListItem>
                            <asp:ListItem Value="6">Asma</asp:ListItem>
                            </asp:DropDownList>
                </td>

            </tr>
             <tr>
                <td style="text-align:center;">
                    <asp:Label ID="Label3" runat="server" Text="Label">Ha recibido transfusion sanguinea</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="text-align:center;">
                    <asp:Label ID="Label8" runat="server" Text="Label" >¿Esta tomando pastillas anticonceptivas?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td style="text-align:center;">
                    <asp:Label ID="Label9" runat="server" Text="Label">¿Ha consumido o consume drogas?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
               <td style="text-align:center;">
                    <asp:Label ID="Label10" runat="server" Text="Label" >¿Ha tenido limitacion en abrir/cerrar la boca?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList11" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
              <td style="text-align:center;">
                    <asp:Label ID="Label11" runat="server" Text="Label">¿Sangra excesivamente al cortarse?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
               <td style="text-align:center;">
                    <asp:Label ID="Label12" runat="server" Text="Label" >¿Siente ruidos en la mandibula al masticar?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList12" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td style="text-align:center;">
                    <asp:Label ID="Label13" runat="server" Text="Label">¿Es usted V.I.H +?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
               <td style="text-align:center;">
                    <asp:Label ID="Label14" runat="server" Text="Label" >¿Sufre de herpes recurrentemente?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList13" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align:center;">
                    <asp:Label ID="Label15" runat="server" Text="Label">¿Toma algun medicamento retroviral?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
               <td style="text-align:center;">
                    <asp:Label ID="Label16" runat="server" Text="Label" >¿Fumas?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList14" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align:center;">
                    <asp:Label ID="Label17" runat="server" Text="Label">¿Estad usted embarazada?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
               <td style="text-align:center;">
                    <asp:Label ID="Label18" runat="server" Text="Label" >¿Muerde objetos con los dientes?</asp:Label>
                </td>
                               <td style="text-align:left;">
                    <asp:RadioButtonList ID="RadioButtonList15" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="no" Value="0"></asp:ListItem>
                        <asp:ListItem Text="si" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr >
                <td colspan="4"  style="text-align:center; padding:5px;" class="style1">
                <asp:Button ID="defaultButton" runat="server" Text="Aceptar" CssClass="button" 
                        onclick="defaultButton_Click" />
                </td>
            </tr>
            </table>          
        </fieldset>
    </div>
</asp:Content>

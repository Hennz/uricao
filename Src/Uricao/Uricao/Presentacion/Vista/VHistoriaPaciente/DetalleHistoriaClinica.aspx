<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/PaginaMaestra.Master"
    AutoEventWireup="true" CodeBehind="DetalleHistoriaClinica.aspx.cs" Inherits="Uricao.Presentacion.Vista.VHistoriaPaciente.DetalleHistoriaClinica" ValidateRequest="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 

    <style type="text/css">
        .labelStyle1
        {
           margin-left: 20px;
           padding: 5px;
        }
       .labelStyle2
        {
           margin-right:20px;
           padding: 5px;
        }
        .labelStyle3
        {
           margin-left:40px;
           padding: 5px;
        }
         .labelStyle4
        {
           margin-left:120px;
           padding: 5px;
        }
        .labelStyle5
        {
           margin-left:70px;
           padding: 5px;
        }
         .labelStyle6
        {
           margin-left:5px;
           padding: 5px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div style="height:30px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="Label" CssClass="falla" Visible="false"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="Label" CssClass="Exito" Visible="false"></asp:Label>
    </div>  
    <div  style="float:left;">
        <fieldset style="width:700px; height:460px; margin-left:4%;">
        <legend>Detalle Historia Clinica</legend>        

            <table style="margin:10px auto 0 auto; height: 221px; width: auto;" border="0" 
                cellspacing="7px" cellpadding="3px" align="center">
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="fecha" runat="server" Text="Label">Fecha:</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="nombre" runat="server" Text="Label">Nombre Completo:</asp:Label>
                <asp:Label ID="edad" runat="server" Text="Edad:" CssClass="labelStyle1"></asp:Label>
                    <asp:Label ID="sexo" runat="server" Text="Sexo:" CssClass="labelStyle1"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="text-align:left;">
                    <asp:Label ID="ide" runat="server" Text="Label">C.I/P</asp:Label>
                    <asp:Label ID="direccion" runat="server" Text="Direccion:" 
                        CssClass="labelStyle1"></asp:Label>
                </td>
                </tr>
            <tr>
             <td style="text-align:left;">
                    <asp:Label ID="nace" runat="server" Text="Fecha de nacimiento" 
                        CssClass="labelStyle2"></asp:Label>
                    <asp:Label ID="telefono" runat="server" Text="Label">Telefono</asp:Label>
                    </td>
            </tr>
            <tr >
                 <td style="text-align:left;">
                     <asp:Label ID="obs" runat="server" Text="Label">Observaciones:</asp:Label>
                 </td>    
                
            </tr>
              <tr >
                 <td style="text-align:left; padding:0px 0px 5px;">
                     <h2>Antecedente</h2>
                 </td>    
                
            </tr>
           <tr>
                <td style="text-align:left;">
                    <asp:Label ID="p1" runat="server" Text="¿Esta bajo tratamiento medico?" 
                        CssClass="labelStyle2" ></asp:Label>

                       <asp:Label ID="p10" runat="server" 
                        Text="A padecido de algun problema sanguineo" CssClass="labelStyle3" ></asp:Label>   
                </td>                 
            </tr>
            <tr>
               <td style="text-align:left;">
                    <asp:Label ID="p2" runat="server" Text="¿Toma actualmente algun medicamento?" 
                        CssClass="labelStyle2" ></asp:Label>
                    <asp:Label ID="p11" runat="server" Text="A tenido reaccion alergica a:" 
                         ></asp:Label>
                </td>
                                   
            </tr>
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="p3" runat="server" Text="¿Le han practicado intervencion?" 
                        CssClass="labelStyle2"></asp:Label>
                    <asp:Label ID="p12" runat="server" Text="Sufre o ha sugrido de:" 
                        CssClass="labelStyle1" ></asp:Label>
                </td>

            </tr>
             <tr>
                <td style="text-align:left;">
                    <asp:Label ID="p4" runat="server" Text="Ha recibido transfusion sanguinea" 
                        CssClass="labelStyle2"></asp:Label>
                    <asp:Label ID="p13" runat="server" 
                        Text="¿Esta tomando pastillas anticonceptivas?" CssClass="labelStyle1" ></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="text-align:left;">
                    <asp:Label ID="p5" runat="server" Text="¿Ha consumido o consume drogas?" 
                        CssClass="labelStyle2"></asp:Label>
                    <asp:Label ID="p14" runat="server" 
                        Text="¿Ha tenido limitacion en abrir/cerrar la boca?" CssClass="labelStyle6" ></asp:Label>
                </td>
            </tr>
             <tr>
              <td style="text-align:left;">
                    <asp:Label ID="p6" runat="server" Text="¿Sangra excesivamente al cortarse?" 
                        CssClass="labelStyle2"></asp:Label>
                    <asp:Label ID="p15" runat="server" 
                        Text="¿Siente ruidos en la mandibula al masticar?" CssClass="labelStyle6" ></asp:Label>
                </td>

            </tr>
             <tr>
                <td style="text-align:left;">
                    <asp:Label ID="p7" runat="server" Text="¿Es usted V.I.H +?" 
                        CssClass="labelStyle2"></asp:Label>
                    <asp:Label ID="p16" runat="server" Text="¿Sufre de herpes recurrentemente?" 
                        CssClass="labelStyle4" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="p8" runat="server" Text="¿Toma algun medicamento retroviral?" 
                        CssClass="labelStyle2"></asp:Label>
                    <asp:Label ID="p17" runat="server" Text="¿Fumas?" CssClass="labelStyle6" ></asp:Label>
                </td>
            </tr>
            <tr>
                 <td style="text-align:left;">
                    <asp:Label ID="p9" runat="server" Text="Label" CssClass="labelStyle2">¿Estad usted embarazada?</asp:Label>
                    <asp:Label ID="p18" runat="server" Text="¿Muerde objetos con los dientes?" 
                         CssClass="labelStyle5" ></asp:Label>
                </td>
               
  
            </tr>
                <tr >
                <td colspan="4"  style="text-align:center">
              
                       <!-- <asp:Button ID="Button2" runat="server" Text="Aceptar" CssClass="botonHistoriaClinica" 
                        onclick="defaultButton_Click" />   -->    
                    
                 </td>    
                
            </tr>
            </table>              
        </fieldset>
    </div>
</asp:Content>
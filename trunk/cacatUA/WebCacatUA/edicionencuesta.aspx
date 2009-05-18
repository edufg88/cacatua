<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="edicionencuesta.aspx.cs" Inherits="WebCacatUA.edicionencuesta" Title="Encuestas - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/encuestasEdicion.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><asp:Label ID="Label_nombreSeccion" runat="server" Text="<%$ Resources: I18N, Encuestas %>"></asp:Label></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">
    <div id="div_volver">
        <a href="encuestas.aspx"><%= Resources.I18N.VolverEncuestas %></a>
    </div>
     <div id="div_nuevapregunta">
     <%= Resources.I18N.Pregunta %>
         <asp:TextBox ID="TextBox_Pregunta" runat="server"></asp:TextBox>
        <asp:Button ID="Button_cambiar" runat="server" Text="<%$ Resources: I18N, Cambiar %>" 
            onclick="Button_cambiar_Click" />  
     </div>
    <div id="div_opciones">
        <asp:Table ID="Table_encuesta" runat="server" CssClass="tabla_encuestas" 
            CellPadding="0" CellSpacing="0"></asp:Table>     
    </div>
    <div id="div_nuevaopcion">
        <%= Resources.I18N.NuevaOpcion %>
        <asp:TextBox ID="TextBox_crearopcion" runat="server" />
        <asp:Button ID="Button_crearopcion" runat="server" Text="<%$ Resources: I18N, Añadir %>" 
            onclick="Button_crearopcion_Click" />
    </div>     
</asp:Content>
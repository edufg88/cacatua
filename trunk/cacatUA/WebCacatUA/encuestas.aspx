<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="encuestas.aspx.cs" Inherits="WebCacatUA.encuestas" Title="Encuestas - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/encuestasEdicion.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><asp:Label ID="Label_nombreSeccion" runat="server" Text="<%$ Resources: I18N, Encuestas %>"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">
    <%= Resources.I18N.InfoEncuestas %>
     <div id="div_encuestas">
        <asp:Table ID="Table_encuestas" runat="server" CssClass="tabla_encuestas" 
            CellPadding="0" CellSpacing="0"></asp:Table>        
    </div>      
    <div id="div_crearencuesta">
        <asp:Button ID="Button_crearencuesta" runat="server" 
        onclick="Button_crearencuesta_Click" Text="Nueva encuesta" />
    </div>   
</asp:Content>


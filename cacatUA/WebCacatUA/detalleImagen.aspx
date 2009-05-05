<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="detalleImagen.aspx.cs" Inherits="WebCacatUA.Formulario_web1" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><asp:Label ID="Label_nombreUsuario" runat="server" Text="Galeria de fotos"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">
    <asp:Panel ID="panelPrincipal" runat="server">
        <asp:Image ID="imagenPrincipal" runat="server" Width="600px" ImageUrl=""/>
    </asp:Panel>
    
    <asp:Panel ID="panelDatos" runat="server">
    </asp:Panel>
    <asp:Table ID="tablaComentarios" runat="server">
    </asp:Table>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeFile="usuario.aspx.cs" Inherits="usuario" Title="CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" Runat="Server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" Runat="Server">
<p><asp:Label ID="Label_nombreUsuario" runat="server" Text="Nombre del usuario"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" Runat="Server">
    <p>
       En usuario.apsx tiene que salir la información del usuario (nombre, nombre completo, email, dni, etc.), toda esa mierdaca.
    </p>
</asp:Content>


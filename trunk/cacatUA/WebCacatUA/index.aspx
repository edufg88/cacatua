<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" Title="CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
<p>Página de inicio</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">
    <p>
        <asp:Label ID="Label_TextoInicial" runat="server" Text="<%$ Resources: I18N, TextoInicial %>"></asp:Label>
    </p>
</asp:Content>


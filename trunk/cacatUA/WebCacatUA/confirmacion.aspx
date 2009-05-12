<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="confirmacion.aspx.cs" Inherits="confirmacion" Title="CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
    <div id="mensajeConfirmar">
        <asp:Label ID="Label_confirmacion" runat="server"></asp:Label>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">
    <div id="link">
        <asp:HyperLink ID="HyperLink_confirmacion" runat="server"></asp:HyperLink>
    </div>
</asp:Content>

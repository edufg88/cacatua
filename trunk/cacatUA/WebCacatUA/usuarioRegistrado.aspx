<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="usuarioRegistrado.aspx.cs" Inherits="usuarioRegistrado" Title="Registro de usuario - CacatUa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
<div id="cabeceraRegistro">
        <p>
        Usuario registrado correctamente
        </p>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">
<div id="contenido">
    
    <asp:LinkButton ID="LinkButton_volverInicio" runat="server" 
        onclick="LinkButton_volverInicio_Click">Volver a la página de inicio</asp:LinkButton>
    
</div>
</asp:Content>

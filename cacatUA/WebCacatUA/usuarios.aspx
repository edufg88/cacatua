<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeFile="usuarios.aspx.cs" Inherits="usuarios" Title="Usuarios - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
<p>Usuarios</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">
<p>Se muestra el listado de usuarios, con buscador, para poder seleccionar uno de ellos. Cuando se seleccione se podrá ver al usuario en detalle (se redireccionará, por ejemplo, a usuario.aspx?id=1255). Desde usuario.aspx?id=1255 se ve la información del usuario, con la posiblidad de ver sus fotos, grupos, o lo que sea.</p>
</asp:Content>


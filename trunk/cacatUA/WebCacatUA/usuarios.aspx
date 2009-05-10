<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeFile="usuarios.aspx.cs" Inherits="usuarios" Title="Usuarios - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="estilos/usuarios.css" media="screen" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
    <div id="cabeceraUsuarios">
        <asp:Label ID="Label_usuarios" runat="server" Text="<%$ Resources: I18N, Usuarios %>"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">
    <div id="migasUsuarios">
    
    </div>
    <div id="navegacionUsuarios">
    
    </div>
    <div id="contenidoUsuarios">
        <div id="busquedaUsuarios">
        
            <div id="criteriosBusquedaUsuarios">
            
            </div>
        </div>
        <div id="mostrarUsuarios">
        </div>
        <div id="usuarios">
            <asp:Table ID="Table_usuarios" runat="server" CssClass="tablaUsuarios" 
                CellPadding="0" CellSpacing="0"></asp:Table>
        </div>
        <div id="paginacionUsuarios">
            <div id="cantidadPaginasUsuarios">
            </div>
            <div id="paginasUsuarios">
            </div>
        </div>
    </div>
    
<p>&nbsp;</p>
</asp:Content>


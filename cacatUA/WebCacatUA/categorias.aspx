<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="categorias.aspx.cs" Inherits="WebCacatUA.categorias" Title="Categorias de usuario - CacatUA"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/categoriasUsuario.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><asp:Label ID="Label_nombreSeccion" runat="server" Text="Categorias"></asp:Label></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">
    <asp:Label ID="Label_Texto" runat="server" Text=""></asp:Label>
     <div id="div_categorias">
        <asp:Table ID="Table_categorias" runat="server" CssClass="tabla_categorias" 
            CellPadding="0" CellSpacing="0"></asp:Table>        
    </div>         
</asp:Content>
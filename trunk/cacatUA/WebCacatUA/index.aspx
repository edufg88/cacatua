<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" Title="CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="estilos/index.css" media="screen" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
<p><asp:Label ID="Label_paginaInicio" runat="server" Text="<%$ Resources: I18N, PaginaInicio %>"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">
    <p>
        <asp:Label ID="Label_TextoInicial" runat="server" Text="<%$ Resources: I18N, TextoInicial %>"></asp:Label>
    </p>    
    
    <div id="contenidoIndex">
        <div id="ultimosMateriales">
            <asp:Label ID="Label_ultimosMateriales2" CssClass="cabeceraIndex" runat="server" Text="<%$ Resources: I18N, UltimosMateriales %>"></asp:Label>
            <div class="contenidoIndex">
                <asp:Label ID="Label_ultimosMateriales" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        <div id="ultimosHilos">
            <asp:Label ID="Label_ultimosHilos2" CssClass="cabeceraIndex" runat="server" Text="<%$ Resources: I18N, UltimosHilos %>"></asp:Label>
            <div class="contenidoIndex">
                <asp:Label ID="Label_ultimosHilos" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        <div id="ultimosUsuarios">
            <asp:Label ID="Label_ultimosUsuarios2" CssClass="cabeceraIndexUsuarios" runat="server" Text="<%$ Resources: I18N, UltimosUsuarios %>"></asp:Label>
            <div class="contenidoIndex">
                <asp:Label ID="Label_ultimosUsuarios" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    
    
</asp:Content>


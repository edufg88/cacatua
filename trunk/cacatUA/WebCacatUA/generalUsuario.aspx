<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeFile="generalUsuario.aspx.cs" Inherits="generalUsuario" Title="CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" Runat="Server">
    <link rel="stylesheet" type="text/css" href="estilos/generalUsuario.css" media="screen" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" Runat="Server">
<p><asp:Label ID="Label_nombreUsuario" runat="server" Text="<%$ Resources: I18N, TablonUsuario %>"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" Runat="Server">
    <div id="galeria">
        <div id="infoGaleria">
            <asp:LinkButton ID="LinkButton_infoGaleria" CssClass="textoInfo" runat="server" 
                Text="<%$ Resources: I18N, UltimasImagenes %>" onclick="LinkButton_infoGaleria_Click"></asp:LinkButton>
        </div>
        <div id="contenidoGaleria">
            <asp:Table ID="Table_galeria" runat="server" CssClass="tablaGaleria" 
                CellPadding="0" CellSpacing="0"></asp:Table>
        </div>
    </div>
    <div id="firmas">
        <div id="infoFirmas">
            <asp:LinkButton ID="LinkButton_infoFirmas" CssClass="textoInfo" runat="server" 
                Text="<%$ Resources: I18N, UltimasFirmas %>" onclick="LinkButton_infoFirmas_Click"></asp:LinkButton>
        </div>
        <div id="contenidoFirmas">
            <asp:Table ID="Table_firmas" runat="server" CssClass="tablaFirmas" 
                CellPadding="0" CellSpacing="0"></asp:Table>
        </div>
    </div>
</asp:Content>
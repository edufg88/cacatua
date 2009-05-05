<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="galeriaDetalle.aspx.cs" Inherits="WebCacatUA.Formulario_web1" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/galeria.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><asp:Label ID="Label_nombreUsuario" runat="server" Text="Galeria de fotos"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">

    <div id="contenidoGaleriaDetalle">
        <p id="tituloImagen"><asp:Label ID="labelTitulo" runat="server" Text="Titulo"></asp:Label></p><br />
        <br />
        <br />
        <asp:Label ID="labelFecha" runat="server" Text="Fecha"></asp:Label><br />
        <asp:Label ID="labelUsuario" runat="server" Text="Usuario"></asp:Label><br />
        <br />
        <br />
        <asp:Panel ID="panelImagen" runat="server">
            <asp:Image ID="imagenPrincipal" runat="server" Width="90%" ImageUrl=""/>
        </asp:Panel>
        <br />
        <br />
        <asp:Label ID="labelDescripcion" runat="server" Text="Descripcion"></asp:Label>
        <br />
        <br />
        <h2>Comentarios</h2>
        <br />
        <asp:Table ID="tablaComentarios" runat="server" Width="90%">
        </asp:Table>
        <br />
        <br />
        <h3>Añadir comentario</h3>
        <asp:TextBox ID="TextBoxComentario" runat="server" Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
        <p style="width: 90%; text-align: center;"><asp:Button ID="botonComentar" runat="server" Text="Comentar" OnClick="guardarComentario" /></p>
   
   </div>
</asp:Content>

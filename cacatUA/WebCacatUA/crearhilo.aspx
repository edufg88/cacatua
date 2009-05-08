<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeFile="crearhilo.aspx.cs" Inherits="crearhilo" Title="Crear nuevo hilo - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="estilos/crearhilo.css" media="screen" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
        <div id="cabeceraCrearHilo">
            <asp:Label ID="Label_crearNuevoHilo" runat="server" Text="<%$ Resources: I18N, CrearNuevoHilo %>"></asp:Label>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">

<asp:Panel ID="Panel_contenidoCrearHilo" runat="server">
    <table id="tablaCrearHilo">
        <tr>
            <td class="columna1CrearHilo"><span>&nbsp;</span></td>
            <td class="columna2CrearHilo">
                <asp:Label ID="Label_tituloError" runat="server" ForeColor="Red" Text="El número de caracteres debe estar entre 1 y 100." Visible="False"></asp:Label>
            </td>
        </tr>
        <tr id="filaTituloCrearHilo">
            <td class="columna1CrearHilo"><asp:Label ID="Label_titulo" runat="server" Text="<%$ Resources: I18N, Titulo %>"></asp:Label></td>
            <td class="columna2CrearHilo">
                <asp:TextBox ID="TextBox_titulo" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="columna1CrearHilo"><span>&nbsp;</span></td>
            <td class="columna2CrearHilo">
                <asp:Label ID="Label_textoError" runat="server" ForeColor="Red" Text="El número de caracteres debe estar entre 1 y 5000." Visible="False"></asp:Label>
            </td>
        </tr>
        <tr id="filaTextoCrearHilo">
            <td class="columna1CrearHilo"><asp:Label ID="Label_texto" runat="server" Text="<%$ Resources: I18N, Texto %>"></asp:Label></td>
            <td class="columna2CrearHilo">
                <asp:TextBox ID="TextBox_texto" runat="server" TextMode="MultiLine" Width="100%" Rows="5"></asp:TextBox>
            </td>
        </tr>
        <tr id="filaEnviarCrearHilo">
            <td colspan="2"><asp:Button ID="Button_enviar" runat="server" Text="<%$ Resources: I18N, Enviar %>" /></td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="Panel_creadoCorrectamente" runat="server" Visible="False">
    <p><%= Resources.I18N.HiloCreadoCorrectamente %>.</p>
    <asp:HyperLink ID="HyperLink_verHilo" runat="server"><%= Resources.I18N.VerHilo %></asp:HyperLink>
</asp:Panel>

<asp:Panel ID="Panel_noCreado" runat="server" Visible="False">
    <p><%= Resources.I18N.FalloCrearHilo %>.</p>
    <a href="foro.aspx"><%= Resources.I18N.VolverForo %></a>
</asp:Panel>

</asp:Content>
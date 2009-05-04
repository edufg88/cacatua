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
        <tr id="filaTituloCrearHilo">
            <td class="columna1CrearHilo"><asp:Label ID="Label_titulo" runat="server" Text="<%$ Resources: I18N, Titulo %>"></asp:Label></td>
            <td class="columna2CrearHilo"><asp:TextBox ID="TextBox_titulo" runat="server" Width="100%"></asp:TextBox></td>
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

<asp:Panel ID="Panel_sinCategoria" runat="server" Visible="False">
    <p>Para crear un hilo debe estar dentro de alguna categoría.</p>
</asp:Panel>

<asp:Panel ID="Panel_creadoCorrectamente" runat="server" Visible="False">
    <p>Hilo creado correctamente.</p>
</asp:Panel>

<asp:Panel ID="Panel_noCreado" runat="server" Visible="False">
    <p>Fallo al crear el hilo.</p>
</asp:Panel>

</asp:Content>
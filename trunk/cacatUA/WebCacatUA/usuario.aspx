<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeFile="usuario.aspx.cs" Inherits="usuario" Title="CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" Runat="Server">
    <link rel="stylesheet" type="text/css" href="estilos/usuario.css" media="screen" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" Runat="Server">
<p><asp:Label ID="Label_nombreUsuario" runat="server" Text="<%$ Resources: I18N, DatosUsuario %>"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" Runat="Server">
    <div id="datosUsuario">
        <table id="tablaDatosUsuario" cellpadding="0" cellspacing="0">
            <tr>
                <td class="columna1DatosUsuario">&nbsp;</td>
                <td class="columna2DatosUsuario"><asp:Label ID="Label_nombreUsuarioError" runat="server" Text="Label" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario"><%= Resources.I18N.NombreUsuario %>:</td>
                <td class="columna2DatosUsuario"><asp:TextBox ID="TextBox_nombreUsuario" runat="server" ReadOnly="True" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario">&nbsp;</td>
                <td class="columna2DatosUsuario"><asp:Label ID="Label_nombreCompletoError" runat="server" Text="Label" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario"><%= Resources.I18N.NombreCompleto %>:</td>
                <td class="columna2DatosUsuario"><asp:TextBox ID="TextBox_nombreCompleto" runat="server" ReadOnly="True" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario">&nbsp;</td>
                <td class="columna2DatosUsuario"><asp:Label ID="Label_contrasenaError" runat="server" Text="Label" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario"><%= Resources.I18N.Contrasena %>:</td>
                <td class="columna2DatosUsuario">
                    <asp:TextBox ID="TextBox_contrasena" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:TextBox ID="TextBox_contrasena2" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario">&nbsp;</td>
                <td class="columna2DatosUsuario"><asp:Label ID="Label_correoElectronicoError" runat="server" Text="Label" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario"><%= Resources.I18N.CorreoElectronico %>:</td>
                <td class="columna2DatosUsuario"><asp:TextBox ID="TextBox_correoElectronico" runat="server" ReadOnly="True" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario">&nbsp;</td>
                <td class="columna2DatosUsuario"><asp:Label ID="Label_dniError" runat="server" Text="Label" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario"><%= Resources.I18N.DNI %>:</td>
                <td class="columna2DatosUsuario"><asp:TextBox ID="TextBox_dni" runat="server" ReadOnly="True" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario">&nbsp;</td>
                <td class="columna2DatosUsuario"><asp:Label ID="Label_informacionAdicionalError" runat="server" Text="Label" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario"><%= Resources.I18N.InformacionAdicional %>:</td>
                <td class="columna2DatosUsuario"><asp:TextBox ID="TextBox_informacionAdicional" runat="server" TextMode="MultiLine" Rows="4" ReadOnly="True" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="columna1DatosUsuario">&nbsp;</td>
                <td class="columna2DatosUsuario">&nbsp;</td>
            </tr>
            <tr class="ultimaFilaDatosUsuario">
                <td class="columna1DatosUsuario"></td>
                <td class="columna2DatosUsuario">
                <asp:Button ID="Button_guardar" runat="server" Text="<%$ Resources: I18N, GuardarCambios %>" onclick="Button_guardar_Click" />
                <asp:Button ID="Button_cancelar" runat="server" Text="<%$ Resources: I18N, Cancelar %>" />
                <asp:HyperLink ID="HyperLink_editar" runat="server"><%= Resources.I18N.EditarDatos %></asp:HyperLink></td>
            </tr>
        </table>
    </div>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="galeriaEditar.aspx.cs" Inherits="WebCacatUA.Formulario_web14" Title="Galería - CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><asp:Label ID="Label_nombreUsuario" runat="server" Text="Editar imagen"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">

    <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
    <asp:Table ID="Table1" runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell style="width:30%"><asp:Label ID="Label_titulo" runat="server" Text="Label"><%= Resources.I18N.Titulo %></asp:Label></asp:TableCell>
            <asp:TableCell style="width:70%"><asp:TextBox ID="TextBox_tituloNuevaImagen" runat="server"></asp:TextBox></asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
            <asp:TableCell style="width:30%"><asp:Label ID="Label_descripcion" runat="server" Text="Label"><%= Resources.I18N.Descripcion %></asp:Label></asp:TableCell>
            <asp:TableCell style="width:70%"><asp:TextBox ID="TextBox_descripcionNuevaImagen" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
       
        <asp:TableRow>
            <asp:TableCell style="width:30%"><asp:Button ID="Button1" runat="server" Text="<%$ Resources: I18N, Guardar %>" onclick="Button1_Click"/></asp:TableCell>
        </asp:TableRow>
    
    </asp:Table>


</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="enviarmensaje.aspx.cs" Inherits="enviarmensaje" Title="CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p>
        Enviar mensaje</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">
    Para:
    <asp:Label ID="Label_para" runat="server"></asp:Label>
    <br />
    <br />
    Mensaje:<br />
    <asp:TextBox ID="TextBox_mensaje" runat="server" Height="187px" Width="589px"></asp:TextBox>
    <br />
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Enviar" />
    <asp:Button ID="Button_borrar" runat="server" onclick="Button_borar_Click" 
        Text="Limpiar" />
&nbsp;
</asp:Content>

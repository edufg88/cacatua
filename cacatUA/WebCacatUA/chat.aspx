<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="chat.aspx.cs" Inherits="WebCacatUA.chat" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">
    <asp:ListBox ID="ListBox_usuarios" runat="server"></asp:ListBox>
    <asp:TextBox ID="TextBox_chat" Width=100% runat="server" TextMode="MultiLine"></asp:TextBox>
    <asp:TextBox ID="TextBox_mensaje" Width=100% TextMode="MultiLine" runat="server"></asp:TextBox>
    <asp:Button ID="Button_enviar" runat="server" Text="Button" />
</asp:Content>

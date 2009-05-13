﻿<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="enviarmensaje.aspx.cs" Inherits="enviarmensaje" Title="CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
        <asp:Label ID="Label_enviarMensaje" runat="server" Text="<%$ Resources: I18N, EnviarMensaje %> "></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">
    <div id="para">
        <asp:Label ID="Label_paratext" runat="server" Text="<%$ Resources: I18N, Para %>"></asp:Label>
        :
        <asp:Label ID="Label_para" runat="server"></asp:Label>
    </div>
    <br />
    <div id="mensaje">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources: I18N, Mensaje %>"></asp:Label>
        :
        <br />
        <asp:TextBox ID="TextBox_mensaje" runat="server" Height="187px" Width="589px" 
            MaxLength="5000"></asp:TextBox>
    </div>
    <div id="botones">
        <asp:Button ID="Button_enviar" runat="server" onclick="Button_enviar_Click" 
            Text="<%$ Resources: I18N, Enviar %>" />
        <asp:Button ID="Button_borrar" runat="server" onclick="Button_borrar_Click" 
            Text="<%$  Resources: I18N, Limpiar %>" />
    </div>
</asp:Content>
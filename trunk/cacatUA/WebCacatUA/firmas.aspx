<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="firmas.aspx.cs" Inherits="firmas" Title="CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p>
        Firmas de
        <asp:Label ID="Label_usuario" runat="server"></asp:Label>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">
    <div><asp:Panel ID="Panel_firmas" runat="server" Height="250px" Width="600px">
        </asp:Panel></div>
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="Button_firmar" runat="server" Text="Firmar" 
    onclick="Button_firmar_Click"/>
        </asp:Panel>
    </div>
    <div><asp:Panel ID="Panel_firmar" runat="server" Height="120px" Width="603px" 
        Visible="False">
        <asp:TextBox ID="TextBox_firmar" runat="server" Height="75px" Width="600px"></asp:TextBox>
        <asp:Button ID="Button_enviar" runat="server" onclick="Button_enviar_Click" 
            Text="Enviar" />
        <asp:Button ID="Button_limpiar" runat="server" onclick="Button_limpiar_Click" 
            Text="Limpiar" />
    </asp:Panel>
    </div>
</asp:Content>

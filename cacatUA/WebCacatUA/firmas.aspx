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
    <div>
    <asp:Label ID="Label_mostrandoFirmas" runat="server" Text=""></asp:Label>
    <asp:Button ID="Button_paginaAnterior2" runat="server" Text="<%$ Resources: I18N, Anterior %>" 
                onclick="Button_paginaAnterior_Click" />
            <asp:DropDownList ID="DropDownList_pagina2" runat="server" Width="40px" 
                onselectedindexchanged="DropDownList_pagina2_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="Button_paginaSiguiente2" runat="server" Text="<%$ Resources: I18N, Siguiente %>" 
                onclick="Button_paginaSiguiente_Click" />
    <asp:Panel ID="Panel_firmas" runat="server" Height="250px" Width="600px">
        </asp:Panel></div>
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="Button_firmar" runat="server" Text="Firmar" 
    onclick="Button_firmar_Click"/>
    <asp:Button ID="Button_paginaAnterior" runat="server" Text="<%$ Resources: I18N, Anterior %>" 
                onclick="Button_paginaAnterior_Click" />
            <asp:DropDownList ID="DropDownList_pagina" runat="server" Width="40px" 
                onselectedindexchanged="DropDownList_pagina_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="Button_paginaSiguiente" runat="server" Text="<%$ Resources: I18N, Siguiente %>" 
                onclick="Button_paginaSiguiente_Click" />
        </asp:Panel>
    </div>
    <div><asp:Panel ID="Panel_firmar" runat="server" Height="120px" Width="603px" 
        Visible="False">
        <asp:TextBox ID="TextBox_firmar" runat="server" Height="75px" Width="600px" 
            MaxLength="5000"></asp:TextBox>
        <asp:Button ID="Button_enviar" runat="server" onclick="Button_enviar_Click" 
            Text="Enviar" />
        <asp:Button ID="Button_limpiar" runat="server" onclick="Button_limpiar_Click" 
            Text="Limpiar" />
    </asp:Panel>
    </div>
</asp:Content>

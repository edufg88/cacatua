<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="mensajes.aspx.cs" Inherits="mensajes" Title="CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/mensajes.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <asp:Label ID="Label_titulo" runat="server" Text="<%$ Resources: I18N, MensajesPrivados %>"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">

<div id="mostrandoOrdenar">
    <asp:Table ID="Table_ordenar" runat="server" Width="100%">
        <asp:TableRow Width="100%">
            <asp:TableCell CssClass="columna1Ordenar" Width="50%">
                <asp:Label ID="Label_mostrandoMensajes" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="columna2Ordenar">
                <asp:Label ID="Label_ordenarPor" runat="server" Text="<%$ Resources: I18N, OrdenarPor %>"></asp:Label>
                <asp:DropDownList ID="DropDownList_ordenar" runat="server"
                    AutoPostBack="True" 
                    onselectedindexchanged="DropDownList_ordenar_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList_orden" runat="server"
                    AutoPostBack="True" 
                    onselectedindexchanged="DropDownList_orden_SelectedIndexChanged">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
<asp:Panel ID="Panel_resultados" runat="server">
    <div id="mostrandoMensajes">
        <asp:Table ID="Table_mensajes" runat="server" CellPadding="0" CellSpacing="0" CssClass="tablaMensajes"></asp:Table>
    </div>
    <div id="paginacionInf">
        <div id="cantidadInf">
            <asp:Label ID="Label_cantidadPagina" runat="server" Text="Cantidad por página: "></asp:Label>
            <asp:DropDownList ID="DropDownList_cantidadPagina" runat="server" Width="50px" 
                AutoPostBack="True" 
                onselectedindexchanged="DropDownList_cantidadPagina_SelectedIndexChanged">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem Selected="True">5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>100</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="paginasInf">
            <asp:Button ID="Button_paginaAnterior" runat="server" Text="<%$ Resources: I18N, Anterior %>" 
                onclick="Button_paginaAnterior_Click" />
            <asp:DropDownList ID="DropDownList_pagina" runat="server" Width="40px" 
                onselectedindexchanged="DropDownList_pagina_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="Button_paginaSiguiente" runat="server" Text="<%$ Resources: I18N, Siguiente %>" 
                onclick="Button_paginaSiguiente_Click" />
        </div>
    </div>
</asp:Panel>
    
</asp:Content>

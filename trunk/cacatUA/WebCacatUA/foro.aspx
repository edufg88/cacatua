<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeFile="foro.aspx.cs" Inherits="foro" Title="Foro - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="estilos/foro.css" media="screen" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
        <div id="cabeceraForo">
            <asp:Label ID="Label_foro" runat="server" Text="<%$ Resources: I18N, Foro %>"></asp:Label>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">

<div id="migasForo">
    <asp:Label ID="Label_migas" runat="server" Text=""></asp:Label>
</div>
            
<div id="navegacionForo">
    <div id="nombreCategoriasForo">
        <asp:Label ID="Label_categorias" runat="server" Text="<%$ Resources: I18N, Categorias %>"></asp:Label>
    </div>
    <asp:Panel ID="Panel_categorias" runat="server"></asp:Panel>
</div>

<div id="contenidoForo">
    <div id="busquedaForo">

        <asp:TextBox ID="TextBox_filtroBusqueda" runat="server" Width="40%"></asp:TextBox>
        <asp:Button ID="Button_buscar" runat="server" 
            Text="<%$ Resources: I18N, Buscar %>" Width="10%" 
            onclick="Button_buscar_Click"/>

        <asp:Label ID="Label_ordenarPor" runat="server" Text="<%$ Resources: I18N, OrdenarPor %>"></asp:Label>
        <asp:DropDownList ID="DropDownList_ordenar" runat="server" Width="22%" 
            AutoPostBack="True" 
            onselectedindexchanged="DropDownList_ordenar_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList_orden" runat="server" Width="12%" 
            AutoPostBack="True" 
            onselectedindexchanged="DropDownList_orden_SelectedIndexChanged">
        </asp:DropDownList>

    </div>
    
    <div id="mostrandoForo">
        <asp:Label ID="Label_mostrandoForo" runat="server" Text=""></asp:Label>
        <div id="crearHiloForo">
            <asp:Button ID="Button_crearHiloForo" runat="server" 
                Text="<%$ Resources: I18N, CrearNuevoHilo %>" 
                onclick="Button_crearHiloForo_Click" />
        </div>
        
    </div>
    
    <div id="hilosForo">
        <asp:Table ID="Table_hilosForo" runat="server" CssClass="tablaHilosForo" 
            CellPadding="0" CellSpacing="0"></asp:Table>        
    </div>
    
    <div id="paginacionForo">
        <div id="cantidadPaginaForo">
            <asp:Label ID="Label_cantidadPagina" runat="server" Text="Cantidad por página: "></asp:Label>
            <asp:DropDownList ID="DropDownList_cantidadPagina" runat="server" Width="50px" 
                AutoPostBack="True" 
                onselectedindexchanged="DropDownList_cantidadPagina_SelectedIndexChanged">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem Selected="True">10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>100</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="paginasForo">
            <asp:Button ID="Button_paginaAnterior" runat="server" Text="<%$ Resources: I18N, Anterior %>" 
                onclick="Button_paginaAnterior_Click" />
            <asp:DropDownList ID="DropDownList_pagina" runat="server" Width="40px" 
                onselectedindexchanged="DropDownList_pagina_SelectedIndexChanged" 
                AutoPostBack="True"></asp:DropDownList>
            <asp:Button ID="Button_paginaSiguiente" runat="server" Text="<%$ Resources: I18N, Siguiente %>" 
                onclick="Button_paginaSiguiente_Click" />
        </div>
    </div>
    
</div>

</asp:Content>
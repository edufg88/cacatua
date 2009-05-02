<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeFile="foro.aspx.cs" Inherits="foro" Title="Foro - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="estilos/foro.css" media="screen" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
        <div id="cabeceraForo">
            Foro
            <div id="migasForo">
                <asp:Label ID="Label_migas" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">

<div id="navegacionForo">
    <div id="nombreCategoriasForo">Categorías</div>
    <asp:Panel ID="Panel_categorias" runat="server"></asp:Panel>
</div>

<div id="contenidoForo">
    <div id="busquedaForo">

        <asp:TextBox ID="TextBox_filtroBusqueda" runat="server" Width="40%"></asp:TextBox>
        <asp:Button ID="Button_buscar" runat="server" Text="Button" Width="10%"/>

        <asp:Label ID="Label_ordenarPor" runat="server" Text="Ordenar por:"></asp:Label>
        <asp:DropDownList ID="DropDownList_ordenar" runat="server" Width="22%">
            <asp:ListItem Value="titulo">título</asp:ListItem>
            <asp:ListItem Value="fecha">fecha</asp:ListItem>
            <asp:ListItem Selected="True" Value="fecharespuesta">fecha de última respuesta</asp:ListItem>
            <asp:ListItem Value="respuestas">número de respuestas</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList_orden" runat="server" Width="12%">
            <asp:ListItem Value="ascendente">ascendente</asp:ListItem>
            <asp:ListItem Value="descendente">descendente</asp:ListItem>
        </asp:DropDownList>

    </div>
    
    <div id="mostrandoForo">
        <asp:Label ID="Label_mostrandoForo" runat="server" Text=""></asp:Label>
    </div>
    
    <div id="hilosForo">
        <asp:Label ID="Label_hilos" runat="server" Text=""></asp:Label>
    </div>
    
    <div id="paginacionForo">
        <div id="cantidadPaginaForo">
            <asp:Label ID="Label_cantidadPagina" runat="server" Text="Cantidad por página: "></asp:Label>
            <asp:DropDownList ID="DropDownList_cantidadPagina" runat="server" Width="40px">
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
            <asp:Button ID="Button_paginaAnterior" runat="server" Text="Anterior" 
                onclick="Button_paginaAnterior_Click" />
            <asp:DropDownList ID="DropDownList_pagina" runat="server" Width="40px" 
                onselectedindexchanged="DropDownList_pagina_SelectedIndexChanged" 
                AutoPostBack="True"></asp:DropDownList>
            <asp:Button ID="Button_paginaSiguiente" runat="server" Text="Siguiente" 
                onclick="Button_paginaSiguiente_Click" />
        </div>
    </div>
    
</div>

</asp:Content>
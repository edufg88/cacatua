<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeFile="hilo.aspx.cs" Inherits="hilo" Title="Hilo - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="estilos/hilo.css" media="screen" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
        <div id="cabeceraRespuestasHilo">
            <asp:Label ID="Label_nombreHilo" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">
            
<div id="contenidoRespuestasHilo">
    
    <div id="migasRespuestasHilo">
        <asp:Label ID="Label_migas" runat="server" Text=""></asp:Label>
    </div>

    <div id="mostrandoRespuestasHilo">
        <asp:Label ID="Label_mostrandoRespuestasHilo" runat="server" Text=""></asp:Label>
        <div id="crearRespuesta">
            <asp:Button ID="Button_crearRespuesta" runat="server" 
                Text="<%$ Resources: I18N, AnadirRespuesta %>" PostBackUrl="#anadirRespuesta" />
        </div>
    </div>
    
    <div id="respuestasHilo">
        <asp:Table ID="Table_respuestasHilo" runat="server" CssClass="tablaRespuestasHilo" 
            CellPadding="0" CellSpacing="0"></asp:Table>        
    </div>
    
    <div id="paginacionRespuestasHilo">
        <div id="cantidadPaginaRespuestasHilo">
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
        <div id="paginasRespuestasHilo">
            <asp:Button ID="Button_paginaAnterior" runat="server" Text="<%$ Resources: I18N, Anterior %>" 
                onclick="Button_paginaAnterior_Click" />
            <asp:DropDownList ID="DropDownList_pagina" runat="server" Width="40px" 
                onselectedindexchanged="DropDownList_pagina_SelectedIndexChanged" 
                AutoPostBack="True"></asp:DropDownList>
            <asp:Button ID="Button_paginaSiguiente" runat="server" Text="<%$ Resources: I18N, Siguiente %>" 
                onclick="Button_paginaSiguiente_Click" />
        </div>
    </div>
    
    <asp:Panel ID="Panel_anadirRespuesta" runat="server">
        <div id="anadirRespuesta">
            <asp:Label ID="Label_anadirRespuesta" runat="server" Text="<%$ Resources: I18N, AnadirUnaRespuesta %>"></asp:Label>
            <div id="barraAnadirRespuesta"></div>
            <div id="textareaAnadirRespuesta">
                <asp:TextBox ID="TextBox_anadirRespuesta" runat="server" Rows="4" TextMode="MultiLine" Width="100%"></asp:TextBox>
            </div>
            <asp:Button ID="Button_anadirRespusta" runat="server" Text="<%$ Resources: I18N, EnviarRespuesta %>" 
                onclick="Button_anadirRespusta_Click" />
        </div>
    </asp:Panel>    
</div>

</asp:Content>
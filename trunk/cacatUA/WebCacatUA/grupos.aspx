<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="grupos.aspx.cs" Inherits="grupos" Title="CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
    <asp:Label ID="Label_titulo" runat="server" Text="<%$ Resources: I18N, Grupos %>"></asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">
    <asp:Button ID="Button_crearGrupos" runat="server" 
        Text="<%$ Resources: I18N, CrearGrupo  %>" onclick="Button_crearGrupos_Click" />
    
    <div id="busquedaGrupos">
        <div id="filtroBusqueda">
            <asp:TextBox ID="TextBox_filtroBusqueda" runat="server" Width="85%"></asp:TextBox>
            <asp:Button ID="Button_buscar" runat="server" 
                Text="<%$ Resources: I18N, Buscar %>" Width="10%"
                onclick="Button_buscar_Click"/>
        </div>
        <div id="criteriosBusqueda">
            <asp:Label ID="Label_mostrandoGrupos" runat="server"></asp:Label>
            <div id="ordenar">
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
        </div>
    </div>
    <div id="paginacionSup">
        <div id="cantidadSup">
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
        <div id="paginaSup">
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
        
     <div id="mostrarGrupos">
         <asp:Table ID="Table_grupos" runat="server" CellPadding="0" CellSpacing="0"></asp:Table>
    </div>   
        
    <div id="paginacionInf">
        <div id="cantidadInf">
            <asp:Label ID="Label_cantidadPagina2" runat="server" Text="Cantidad por página: "></asp:Label>
            <asp:DropDownList ID="DropDownList_cantidadPagina2" runat="server" Width="50px" 
                AutoPostBack="True" 
                onselectedindexchanged="DropDownList_cantidadPagina2_SelectedIndexChanged">
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
        <div id="paginaInf">
            <asp:Button ID="Button_paginaAnterior2" runat="server" Text="<%$ Resources: I18N, Anterior %>" 
                onclick="Button_paginaAnterior_Click" />
            <asp:DropDownList ID="DropDownList_pagina2" runat="server" Width="40px" 
                onselectedindexchanged="DropDownList_pagina2_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="Button_paginaSiguiente2" runat="server" Text="<%$ Resources: I18N, Siguiente %>" 
                onclick="Button_paginaSiguiente_Click" />
        </div>
    </div>
</asp:Content>

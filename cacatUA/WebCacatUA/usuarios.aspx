<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeFile="usuarios.aspx.cs" Inherits="usuarios" Title="Usuarios - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="estilos/usuarios.css" media="screen" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
    <div id="cabeceraUsuarios">
        <asp:Label ID="Label_usuarios" runat="server" Text="<%$ Resources: I18N, Usuarios %>"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">
    <div id="migasUsuarios">
        <asp:Label ID="Label_migas" runat="server" Text=""></asp:Label>
    </div>
    <!--
    <div id="navegacionUsuarios">
    </div>
    -->
    <div id="contenidoUsuarios">
        <div id="busquedaUsuarios">
            <div id="campoBusqueda" class="tablaBusqueda">
                <asp:Panel ID="Panel_panel" runat="server" DefaultButton="Button_buscar">
                <table style="width: 100%" cellpadding="0" cellspacing="0" class="tablaBusqueda">              
                    <tr>
                        <td style="width: 35%"></td>
                        <td style="width: 30%">
                            <asp:TextBox ID="TextBox_filtroBusqueda" runat="server" Width="100%" 
                                Height="18px"></asp:TextBox>
                        </td>
                        <td style="width: 2%">
                        </td>
                        <td style="width: 8%;">
                            <asp:Button ID="Button_buscar" runat="server" align="left"
                                Text="<%$ Resources: I18N, Buscar %>"
                                onclick="Button_buscar_Click"/>
                        </td>
                        <td style="width: 25%"></td>
                    </tr>
                </table>
                </asp:Panel>
            </div>
            <div id="criteriosBusquedaUsuarios" class="tablaBusqueda" >
                <asp:Label ID="Label_buscarPor" runat="server" Text="<%$ Resources: I18N, Buscar%>"></asp:Label>
                :
                <asp:RadioButton ID="RadioButton_usuario" runat="server" 
                    Text="<%$ Resources: I18N, Usuario %>" Checked="True" GroupName="busqueda" />
                <asp:RadioButton ID="RadioButton_nombre" runat="server" 
                    Text="<%$ Resources: I18N, Nombre %>" GroupName="busqueda" />
                <asp:RadioButton ID="RadioButton_correo" runat="server" 
                    Text="<%$ Resources: I18N, CorreoElectronico %>" GroupName="busqueda"/>
            </div>
            <div id="criteriosOrdenacionUsuarios" class="tablaBusqueda">
                <asp:Label ID="Label_ordenarPor" runat="server" Text="<%$ Resources: I18N, OrdenarPor %>"></asp:Label>
                :
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
        <div id="mostrandoUsuarios">
            <asp:Label ID="Label_mostrandoUsuarios" runat="server" Text=""></asp:Label>
        </div>
        <div id="usuarios">
            <asp:Table ID="Table_usuarios" runat="server" CssClass="tablaUsuarios" 
                CellPadding="0" CellSpacing="0"></asp:Table>
        </div>
        <div id="paginacionUsuarios">
            <div id="cantidadPaginaUsuarios">
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
            <div id="paginasUsuarios">
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
    <a href="generalUsuario.aspx?usuario=jorge"> HOLA PINCHA AQUI </a>
<p>&nbsp;</p>
</asp:Content>


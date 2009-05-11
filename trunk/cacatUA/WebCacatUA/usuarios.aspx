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
            <table style="width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 50%">
                        <asp:TextBox ID="TextBox_filtroBusqueda" runat="server" Width="100%" 
                            Height="18px"></asp:TextBox>
                    </td>
                    <td style="width: 5%"></td>
                    <td style="width: 45%;">
                        <asp:Button ID="Button_buscar" runat="server" 
                            Text="<%$ Resources: I18N, Buscar %>" Width="20%"
                            onclick="Button_buscar_Click"/>
                    </td>
                </tr>
            </table>
            <div id="criteriosBusquedaUsuarios">
                <asp:Label ID="Label_buscarPor" runat="server" Text="<%$ Resources: I18N, Buscar%>"></asp:Label>
                :
                <asp:RadioButton ID="RadioButton_usuario" runat="server" 
                    Text="<%$ Resources: I18N, Usuario %>" Checked="True" GroupName="busqueda" />
                <asp:RadioButton ID="RadioButton_nombre" runat="server" 
                    Text="<%$ Resources: I18N, Nombre %>" GroupName="busqueda" />
                <asp:RadioButton ID="RadioButton_correo" runat="server" 
                    Text="<%$ Resources: I18N, CorreoElectronico %>" GroupName="busqueda"/>
            </div>
            <div id="criteriosOrdenacionUsuarios">
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
            <br/>
        </div>
        <div id="mostrarUsuarios">
        </div>
        <div id="usuarios">
            <asp:Table ID="Table_usuarios" runat="server" CssClass="tablaUsuarios" 
                CellPadding="0" CellSpacing="0"></asp:Table>
        </div>
        <div id="paginacionUsuarios">
            <div id="cantidadPaginasUsuarios">
            </div>
            <div id="paginasUsuarios">
            </div>
        </div>
    </div>
    
<p>&nbsp;</p>
</asp:Content>


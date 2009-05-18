<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="firmas.aspx.cs" Inherits="firmas" Title="Firmas - CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/firmas.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
        <asp:Label ID="Label_titulo" runat="server" text="<%$ Resources: I18N, Firmas %>"></asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">
    <asp:Panel ID="Panel_panel" runat="server">
        <div id="paginacion">
            <asp:Label ID="Label_mostrandoFirmas" runat="server" Text=""></asp:Label>
            <!--
            <div id="paginaSup">
                <asp:Button ID="Button_paginaAnterior2" runat="server" Text="<%$ Resources: I18N, Anterior %>" 
                    onclick="Button_paginaAnterior_Click" />
                <asp:DropDownList ID="DropDownList_pagina2" runat="server" Width="40px" 
                    onselectedindexchanged="DropDownList_pagina2_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:Button ID="Button_paginaSiguiente2" runat="server" Text="<%$ Resources: I18N, Siguiente %>" 
                    onclick="Button_paginaSiguiente_Click" />
            </div>
            -->
        </div>
        <asp:Panel ID="Panel_resultados" runat="server">
        <div id="mostrarFirmas">
            <asp:Table ID="Table_firmas" runat="server" CellPadding="0" CellSpacing="0" CssClass="tablaFirmas"></asp:Table>
        </div>
        </asp:Panel>
        
        <div id="botones">
            <div id="botonFirmar">
                <asp:Button ID="Button_firmar" runat="server" Text="<%$ Resources: I18N, Firmar %>" 
                    onclick="Button_firmar_Click"/>
            </div>
            <div id="paginaInf">
                <asp:Panel ID="Panel_paginación" runat="server">
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
        </div>
        <div id="panelfirmar">
            <asp:Panel ID="Panel_firmar" runat="server" Height="120px" Width="603px" 
                Visible="False">
                <asp:TextBox ID="TextBox_firmar" runat="server" Height="75px" Width="600px" 
                    MaxLength="5000" TextMode="MultiLine" Rows="5"></asp:TextBox>
                <asp:Button ID="Button_enviar" runat="server" onclick="Button_enviar_Click" 
                    Text="<%$ Resources: I18N, Enviar %>" />
                <asp:Button ID="Button_limpiar" runat="server" onclick="Button_limpiar_Click" 
                    Text="<%$ Resources: I18N, Limpiar %>" />
            </asp:Panel>
        </div>
    </asp:Panel>
</asp:Content>

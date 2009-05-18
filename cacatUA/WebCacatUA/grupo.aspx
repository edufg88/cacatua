<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="grupo.aspx.cs" Inherits="grupo" Title="Grupo - CacatUA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
    <asp:Label ID="Label_grupo" runat="server" Text="<%$ Resources: I18N, Grupo %>"></asp:Label> 
    &nbsp;<asp:Label ID="Label_nombre" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">
    <div id="Descripcion">
        <asp:Label ID="Label_tituloDesc" runat="server" Text="<%$ Resources: I18N, Descripcion %>"></asp:Label>
        :
        <asp:Label ID="Label_Desc" runat="server"></asp:Label>
    </div>
    <br />
    <div id="miembros">
        <asp:Label ID="Label_miembros" runat="server" Text="<%$ Resources: I18N, MiembrosMayus %>"></asp:Label>
        <div id="mostrarMiembros">
            <asp:Table ID="Table_miembros" runat="server" CellPadding="0" CellSpacing="0"></asp:Table>
        </div>
    </div>
    <br />
    <div id="botones">
        <asp:Button ID="Button_apuntarse" runat="server" 
            Text= "<%$ Resources: I18N, Apuntarse %>" onclick="Button_apuntarse_Click" 
            Visible="False" />
        <asp:Button ID="Button_desapuntarse" runat="server" 
            Text= "<%$ Resources: I18N, Desapuntarse %>" 
            onclick="Button_desapuntarse_Click" Visible="False" />
        <asp:Button ID="Button_enviarmensaje" runat="server" 
            Text= "<%$ Resources: I18N, Enviarmensaje %>"
            onclick="Button_enviarmensaje_Click" />
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="creargrupo.aspx.cs" Inherits="creargrupo" Title="CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
        <asp:Label ID="Label_creandoGrupo" runat="server" Text="<%$ Resources: I18N, CrearGrupo %>"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">
    <div id="Nombre">
        <asp:Label ID="Label_Nombre" runat="server" Text="<%$ Resources: I18N, Nombre %>"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox_nombre" runat="server" MaxLength="100" Width="305px"></asp:TextBox>
        <asp:Label ID="Label_infoGrupo" runat="server" ForeColor="Red"></asp:Label>
        <asp:RequiredFieldValidator id="RequiredFieldValidator_nombre"
                    ControlToValidate="TextBox_nombre"
                    Display="Static"
                    ErrorMessage="El campo 'nombre' no se puede dejar en blanco"
                    runat="server"/> 
    </div>
    <div id="Descripcion">
        <asp:Label ID="Label_descripcion" runat="server" Text="<%$ Resources: I18N, Descripcion %>"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox_descripcion" runat="server" Height="86px" 
            Width="305px" MaxLength="5000"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidator_descripcion"
                    ControlToValidate="TextBox_descripcion"
                    Display="Static"
                    ErrorMessage="El campo 'descipción' no se puede dejar en blanco"
                    runat="server"/> 
    </div>
    <div>
        <asp:Button ID="Button_crear" runat="server" 
            Text="<%$ Resources: I18N, Crear %>" onclick="Button_crear_Click" />
        <asp:Button ID="Button_limpiar" runat="server" 
            Text="<%$ Resources: I18N, Limpiar %>" CausesValidation="False" 
            onclick="Button_limpiar_Click" />
    </div>
</asp:Content>

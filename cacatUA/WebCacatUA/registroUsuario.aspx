<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="registroUsuario.aspx.cs" Inherits="registroUsuario" Title="Registro de usuario - CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/registroUsuario.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
    <div id="cabeceraRegistro">
        <p>
        Registro de usuario
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">
    <div id="contenido">
        <p class="etiqueta">Nick de usuario</p>
        <p>    
            <asp:TextBox ID="TextBox_usuario" runat="server"></asp:TextBox>
            <asp:Label ID="Label_infoUsuario" runat="server" ForeColor="Red" CssClass="infoError"></asp:Label>
        </p>
        <p class="etiqueta">Contraseña</p>
        <p>
            <asp:TextBox ID="TextBox_contrasena" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Label ID="Label_infoContrasena" runat="server" ForeColor="Red" CssClass="infoError"></asp:Label>
        </p>
        <p class="etiqueta">Confirmar contraseña</p>
        <p>
            <asp:TextBox ID="TextBox_confirmarContrasena" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Label ID="Label_infoConfContrasena" runat="server" ForeColor="Red" CssClass="infoError"></asp:Label>
        </p>
        <p class="etiqueta">Nombre</p>
        <p>
            <asp:TextBox ID="TextBox_nombre" runat="server"></asp:TextBox>
            <asp:Label ID="Label_infoNombre" runat="server" ForeColor="Red" CssClass="infoError"></asp:Label>
        </p>
        <p class="etiqueta">DNI</p>
        <p>
            <asp:TextBox ID="TextBox_dni" runat="server"></asp:TextBox>
            <asp:Label ID="Label_infoDni" runat="server" ForeColor="Red" CssClass="infoError"></asp:Label>
        </p>
        <p class="etiqueta">Correo</p>
        <p>
            <asp:TextBox ID="TextBox_correo" runat="server"></asp:TextBox>
            <asp:Label ID="Label_infoCorreo" runat="server" ForeColor="Red" CssClass="infoError"></asp:Label>
        </p>
        <p class="etiqueta">Información Adicional</p>
        <p>
            <asp:TextBox ID="TextBox_adicional" TextMode="MultiLine" Columns="20" Rows="4" runat="server"></asp:TextBox>
            <asp:Label ID="Label_infoAdicional" runat="server" ForeColor="Red" CssClass="infoError"></asp:Label>
        </p>
    
        <p class="pie">       
            <asp:Button ID="Button_confirmar" runat="server" Text="Confirmar" 
                onclick="Button_confirmar_Click" />
            <asp:Button ID="Button_limpiar" runat="server" Text="Limpiar" 
                onclick="Button_limpiar_Click" />   
        </p>
    </div>
</asp:Content>
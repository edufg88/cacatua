<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="peticion.aspx.cs" Inherits="WebCacatUA.peticion"  Title="Petición - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="estilos/index.css" media="screen" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
    <p><asp:Label ID="Label_paginaInicio" runat="server" Text="Petición"></asp:Label></p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">  
    <div id="div_infopeticion">
        Aquí puedes exponer incidentes, errores o sugerencias que hayas encontrado.
    </div>
    <div id="div_formpeticion">
        <div id="div_usuario">
            Usuario:
            <asp:TextBox ID="TextBox_Usuario" runat="server" MaxLength="200" 
                ReadOnly="True"></asp:TextBox>
        </div>
        <div id="div_asunto">
            Asunto: 
            <asp:TextBox ID="TextBox_Asunto" runat="server" MaxLength="200"></asp:TextBox>
        </div>
        <div id="div_peticion"></div>
            Petición:
            <asp:TextBox ID="TextBox_Peticion" runat="server" TextMode="MultiLine" 
            Width="156px"></asp:TextBox>
        <div id="div_enviar">
            <asp:Button ID="Button_enviar" runat="server" Text="Enviar" />
        </div>
    </div>
</asp:Content>



